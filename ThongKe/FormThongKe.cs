using FastReport.DataVisualization.Charting;
using HotelManagement.DangNhap;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManagement.ThongKe
{
    public partial class FormThongKe : Form
    {
        private static readonly Color MauNenCanvas = Color.FromArgb(240, 244, 249);
        private static readonly Color MauMauveCard = Color.FromArgb(216, 195, 210);
        private static readonly Color MauVienMauve = Color.FromArgb(182, 158, 176);
        private static readonly Color MauVienKpi = Color.FromArgb(170, 176, 188);
        private static readonly Color MauCotMacDinh = Color.FromArgb(38, 132, 232);
        private static readonly Color MauCotHover = Color.FromArgb(18, 94, 184);

        private static readonly Color[] BangMauPie =
        {
            Color.FromArgb(46, 107, 230),
            Color.FromArgb(234, 115, 39),
            Color.FromArgb(30, 158, 104),
            Color.FromArgb(217, 70, 70),
            Color.FromArgb(124, 77, 255),
            Color.FromArgb(0, 151, 167),
            Color.FromArgb(194, 24, 91),
            Color.FromArgb(109, 76, 65),
            Color.FromArgb(69, 90, 100)
        };

        private readonly ThongKeService _service = new ThongKeService();
        private readonly List<Image> _loadedIcons = new List<Image>();

        private ThongKeKetQua? _duLieuHienTai;
        private CancellationTokenSource? _ctsTaiDuLieu;
        private Form? _hostFormTheoDoi;
        private Panel? _hostPanelTheoDoi;

        private int _hoveredDoanhThuIdx = -1;
        private int _hoveredDatPhongIdx = -1;
        private int _selectedPieIdx = -1;

        public FormThongKe()
        {
            InitializeComponent();
            TaiIcons();
            CauHinhGiaoDienVaTuongTac();
            CauHinhCacBieuDo();

            Disposed += FormThongKe_Disposed;
            ParentChanged += (_, _) => GanSuKienResizeHost();
            Resize += (_, _) => CapNhatKichThuocCanvas();
            Shown += (_, _) => CapNhatKichThuocCanvas();
        }

        private void TaiIcons()
        {
            picThuePhong.Image = DangKyIcon(Properties.Resources.ThuePhongChart);
            picDichVu.Image = DangKyIcon(Properties.Resources.DichVuChart);
            picDatPhong.Image = DangKyIcon(Properties.Resources.DatPhongChart);
            picTop1PhongDoanhThu.Image = DangKyIcon(Properties.Resources.top1);
            picTop1PhongDat.Image = DangKyIcon(Properties.Resources.top1);
            picTop1DichVu.Image = DangKyIcon(Properties.Resources.top1);
        }

        private Image DangKyIcon(byte[] rawBytes)
        {
            Image img = ResourceHelper.ToImage(rawBytes);
            _loadedIcons.Add(img);
            return img;
        }

        private void CauHinhGiaoDienVaTuongTac()
        {
            BatDoubleBuffer(pnlRootCanvas);
            BatDoubleBuffer(tlpLayout);
            BatDoubleBuffer(tlpKpiCards);
            BatDoubleBuffer(tlpNoiDungChinh);
            BatDoubleBuffer(tlpCotTrai);
            BatDoubleBuffer(tlpCotPhai);

            Panel[] kpiCards = { pnlKpiThuePhong, pnlKpiDichVu, pnlKpiSoPhongDat };
            foreach (Panel card in kpiCards)
            {
                BatDoubleBuffer(card);
                card.Paint += (_, e) => VeCardBoGoc(card, e.Graphics, MauVienKpi, 8);
            }

            Panel[] mauveCards =
            {
                pnlTopLoaiPhongDoanhThu,
                pnlTopLoaiPhongDat,
                pnlTopDichVu,
                pnlBieuDoDichVu,
                pnlBieuDoDoanhThuPhong,
                pnlBieuDoSoPhongDat
            };
            foreach (Panel card in mauveCards)
            {
                BatDoubleBuffer(card);
                card.Paint += (_, e) => VeCardBoGoc(card, e.Graphics, MauVienMauve, 8);
            }

            btnXuatBaoCao.BringToFront();

            // Click KPI cards -> drill-down
            GanSuKienClickDeCon(pnlKpiThuePhong, () => MoChiTietDatPhongTheoLoai(null, chiDoanhThuPhong: true));
            GanSuKienClickDeCon(pnlKpiDichVu, MoChiTietDichVu);
            GanSuKienClickDeCon(pnlKpiSoPhongDat, () => MoChiTietDatPhongTheoLoai(null, chiDoanhThuPhong: false));

            // Click Highlight cards -> drill-down
            GanSuKienClickDeCon(pnlTopLoaiPhongDoanhThu, () =>
                MoChiTietDatPhongTheoLoai(_duLieuHienTai?.LoaiPhongDoanhThuCaoNhatTen, chiDoanhThuPhong: true));
            GanSuKienClickDeCon(pnlTopLoaiPhongDat, () =>
                MoChiTietDatPhongTheoLoai(_duLieuHienTai?.LoaiPhongDatNhieuNhatTen, chiDoanhThuPhong: false));
            GanSuKienClickDeCon(pnlTopDichVu, MoChiTietDichVu);

            lblGhiChuPie.Click += (_, _) => MoChiTietDichVu();

            // Tooltips tương tác trên thẻ
            toolTipDashboard.AutoPopDelay = 8000;
            toolTipDashboard.InitialDelay = 250;
            toolTipDashboard.ReshowDelay = 100;
            toolTipDashboard.ShowAlways = true;

            GanToolTipDeCon(pnlKpiThuePhong, "Nhấn để xem chi tiết doanh thu thuê phòng");
            GanToolTipDeCon(pnlKpiDichVu, "Nhấn để xem bảng thống kê các dịch vụ đã sử dụng");
            GanToolTipDeCon(pnlKpiSoPhongDat, "Nhấn để xem toàn bộ lượt đặt phòng trong khoảng thời gian");
            GanToolTipDeCon(pnlTopLoaiPhongDoanhThu, "Nhấn để xem chi tiết loại phòng doanh thu cao nhất");
            GanToolTipDeCon(pnlTopLoaiPhongDat, "Nhấn để xem chi tiết loại phòng được đặt nhiều nhất");
            GanToolTipDeCon(pnlTopDichVu, "Nhấn để xem chi tiết doanh thu từng dịch vụ");

            // Tương tác động trên 2 biểu đồ cột
            chartDoanhThuPhong.MouseMove += ChartDoanhThuPhong_MouseMove;
            chartDoanhThuPhong.MouseLeave += (_, _) => DatLaiHoverCot(chartDoanhThuPhong, ref _hoveredDoanhThuIdx);
            chartDoanhThuPhong.MouseClick += ChartDoanhThuPhong_MouseClick;

            chartSoPhongDat.MouseMove += ChartSoPhongDat_MouseMove;
            chartSoPhongDat.MouseLeave += (_, _) => DatLaiHoverCot(chartSoPhongDat, ref _hoveredDatPhongIdx);
            chartSoPhongDat.MouseClick += ChartSoPhongDat_MouseClick;

            // Tương tác động trên biểu đồ tròn
            chartDichVu.MouseMove += ChartDichVu_MouseMove;
            chartDichVu.MouseLeave += (_, _) => chartDichVu.Cursor = Cursors.Default;
            chartDichVu.MouseClick += ChartDichVu_MouseClick;
            chartDichVu.MouseDoubleClick += (_, _) => MoChiTietDichVu();

            // Nhấn Enter trong DateTimePicker để lọc nhanh
            dtpTuNgay.KeyDown += DatePicker_KeyDown;
            dtpDenNgay.KeyDown += DatePicker_KeyDown;
        }

        private void CauHinhCacBieuDo()
        {
            CauHinhBieuDoCot(chartDoanhThuPhong, "DoanhThuPhong", "Doanh thu theo loại phòng", "#,##0");
            CauHinhBieuDoCot(chartSoPhongDat, "SoPhongDat", "Số lượng đặt", "N0");
            CauHinhBieuDoTron(chartDichVu);
        }

        private static void CauHinhBieuDoCot(Chart chart, string seriesName, string legendTitle, string yFormat)
        {
            chart.Series.Clear();
            chart.ChartAreas.Clear();
            chart.Legends.Clear();
            chart.Titles.Clear();

            chart.BackColor = Color.White;
            chart.AntiAliasing = AntiAliasingStyles.All;
            chart.TextAntiAliasingQuality = TextAntiAliasingQuality.High;

            var ca = new ChartArea("Main")
            {
                BackColor = Color.White
            };
            ca.AxisX.MajorGrid.Enabled = false;
            ca.AxisX.LineColor = Color.FromArgb(145, 152, 165);
            ca.AxisX.MajorTickMark.LineColor = Color.FromArgb(145, 152, 165);
            ca.AxisX.Interval = 1;
            ca.AxisX.IsLabelAutoFit = true;
            ca.AxisX.LabelAutoFitStyle = LabelAutoFitStyles.DecreaseFont | LabelAutoFitStyles.WordWrap;
            ca.AxisX.LabelStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            ca.AxisX.LabelStyle.ForeColor = Color.FromArgb(40, 46, 56);

            ca.AxisY.MajorGrid.Enabled = true;
            ca.AxisY.MajorGrid.LineColor = Color.FromArgb(228, 232, 238);
            ca.AxisY.LineColor = Color.FromArgb(145, 152, 165);
            ca.AxisY.MajorTickMark.LineColor = Color.FromArgb(145, 152, 165);
            ca.AxisY.IsStartedFromZero = true;
            ca.AxisY.Minimum = 0;
            ca.AxisY.LabelStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            ca.AxisY.LabelStyle.ForeColor = Color.FromArgb(55, 62, 74);
            ca.AxisY.LabelStyle.Format = yFormat;
            chart.ChartAreas.Add(ca);

            var legend = new Legend("Legend")
            {
                Docking = Docking.Top,
                Alignment = StringAlignment.Center,
                LegendStyle = LegendStyle.Row,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Regular),
                ForeColor = Color.FromArgb(55, 62, 74),
                BackColor = Color.Transparent
            };
            chart.Legends.Add(legend);

            var series = new Series(seriesName)
            {
                ChartArea = "Main",
                Legend = "Legend",
                LegendText = legendTitle,
                ChartType = SeriesChartType.Column,
                Color = MauCotMacDinh,
                BorderWidth = 0,
                IsXValueIndexed = true
            };
            series["PointWidth"] = "0.52";
            chart.Series.Add(series);
        }

        private static void CauHinhBieuDoTron(Chart chart)
        {
            chart.Series.Clear();
            chart.ChartAreas.Clear();
            chart.Legends.Clear();
            chart.Titles.Clear();

            chart.BackColor = Color.White;
            chart.AntiAliasing = AntiAliasingStyles.All;
            chart.TextAntiAliasingQuality = TextAntiAliasingQuality.High;

            var ca = new ChartArea("Main")
            {
                BackColor = Color.White
            };
            chart.ChartAreas.Add(ca);

            var legend = new Legend("Legend")
            {
                Docking = Docking.Right,
                Alignment = StringAlignment.Center,
                LegendStyle = LegendStyle.Column,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Regular),
                ForeColor = Color.FromArgb(45, 50, 58),
                BackColor = Color.Transparent,
                MaximumAutoSize = 42F
            };
            chart.Legends.Add(legend);

            var series = new Series("DichVuSuDung")
            {
                ChartArea = "Main",
                Legend = "Legend",
                ChartType = SeriesChartType.Pie,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                LabelForeColor = Color.White,
                BorderColor = Color.White,
                BorderWidth = 2
            };
            series["PieStartAngle"] = "270";
            series["PieLabelStyle"] = "Inside";
            series.SmartLabelStyle.Enabled = true;
            chart.Series.Add(series);
        }

        private async void FormThongKe_Load(object? sender, EventArgs e)
        {
            GanSuKienResizeHost();
            CapNhatKichThuocCanvas();

            try
            {
                var (tuNgay, denNgay) = await _service.LayKhoangNgayMacDinhAsync();
                if (IsDisposed)
                    return;

                dtpTuNgay.Value = tuNgay;
                dtpDenNgay.Value = denNgay;
            }
            catch
            {
                if (!IsDisposed)
                {
                    dtpTuNgay.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
                    dtpDenNgay.Value = DateTime.Today;
                }
            }

            await TaiDuLieuThongKeAsync();
        }

        private async void btnXemThongKe_Click(object? sender, EventArgs e)
        {
            await TaiDuLieuThongKeAsync();
        }

        private async void DatePicker_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                await TaiDuLieuThongKeAsync();
            }
        }

        private async Task TaiDuLieuThongKeAsync()
        {
            DateTime tuNgay = dtpTuNgay.Value.Date;
            DateTime denNgay = dtpDenNgay.Value.Date;

            if (tuNgay > denNgay)
            {
                MessageBox.Show(
                    "Ngày bắt đầu không được lớn hơn ngày kết thúc!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                dtpTuNgay.Focus();
                return;
            }

            _ctsTaiDuLieu?.Cancel();
            _ctsTaiDuLieu?.Dispose();
            _ctsTaiDuLieu = new CancellationTokenSource();
            CancellationToken token = _ctsTaiDuLieu.Token;

            btnXemThongKe.Enabled = false;
            btnXuatBaoCao.Enabled = false;
            Cursor = Cursors.WaitCursor;

            try
            {
                ThongKeKetQua ketQua = await _service.LayThongKeAsync(tuNgay, denNgay, token);
                if (IsDisposed || token.IsCancellationRequested)
                    return;

                _duLieuHienTai = ketQua;
                _hoveredDoanhThuIdx = -1;
                _hoveredDatPhongIdx = -1;
                _selectedPieIdx = -1;

                CapNhatGiaoDien(ketQua);
            }
            catch (OperationCanceledException)
            {
                // Bỏ qua nếu người dùng vừa đổi bộ lọc
            }
            catch (Exception ex)
            {
                if (!IsDisposed)
                {
                    MessageBox.Show(
                        "Lỗi khi tải dữ liệu thống kê: " + ex.Message,
                        "Lỗi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            finally
            {
                if (!IsDisposed)
                {
                    btnXemThongKe.Enabled = true;
                    btnXuatBaoCao.Enabled = true;
                    Cursor = Cursors.Default;
                }
            }
        }

        private void CapNhatGiaoDien(ThongKeKetQua data)
        {
            // KPI Summary Cards
            lblGiaTriDoanhThuPhong.Text = ThongKeService.DinhDangTien(data.DoanhThuThuePhong);
            lblGiaTriDoanhThuDichVu.Text = ThongKeService.DinhDangTien(data.DoanhThuDichVu);
            lblGiaTriSoPhongDat.Text = data.SoPhongDat.ToString("N0", CultureInfo.InvariantCulture);

            // Top-1 Highlight Cards
            lblGiaTriTopPhongDoanhThu.Text = data.LoaiPhongDoanhThuCaoNhatHienThi;
            lblGiaTriTopPhongDat.Text = data.LoaiPhongDatNhieuNhatHienThi;
            lblGiaTriTopDichVu.Text = data.DichVuDoanhThuCaoNhatHienThi;

            // Update tooltips chi tiết hơn
            GanToolTipDeCon(
                pnlKpiThuePhong,
                $"Doanh thu thuê phòng đã thanh toán/hoàn tất: {ThongKeService.DinhDangTien(data.DoanhThuThuePhong)}\n({data.SoPhongDaThanhToan} lượt hoàn tất) — Nhấn để xem chi tiết");
            GanToolTipDeCon(
                pnlKpiDichVu,
                $"Doanh thu dịch vụ: {ThongKeService.DinhDangTien(data.DoanhThuDichVu)}\nTổng số lượng đã dùng: {data.TongSoLuongDichVu:N0} — Nhấn để xem chi tiết");
            GanToolTipDeCon(
                pnlKpiSoPhongDat,
                $"Tổng số phòng đã đặt: {data.SoPhongDat:N0} lượt\nNhấn để xem danh sách chi tiết");

            CapNhatBieuDoDoanhThuPhong(data);
            CapNhatBieuDoSoPhongDat(data);
            CapNhatBieuDoDichVu(data);
        }

        private void CapNhatBieuDoDoanhThuPhong(ThongKeKetQua data)
        {
            var series = chartDoanhThuPhong.Series[0];
            var ca = chartDoanhThuPhong.ChartAreas[0];
            series.Points.Clear();

            decimal maxDt = 0m;
            foreach (var item in data.DoanhThuTheoLoaiPhong)
            {
                if (item.DoanhThu > maxDt)
                    maxDt = item.DoanhThu;

                int idx = series.Points.AddY((double)item.DoanhThu);
                var pt = series.Points[idx];
                pt.AxisLabel = item.TenLoaiPhong;
                pt.Color = MauCotMacDinh;
                pt.ToolTip = $"{item.TenLoaiPhong}\nDoanh thu: {ThongKeService.DinhDangTien(item.DoanhThu)}\nSố lượt hoàn tất: {item.SoLuotThanhToan} lượt\n(Nhấn vào cột để xem chi tiết)";
            }

            if (maxDt <= 0m)
            {
                ca.AxisY.Minimum = 0;
                ca.AxisY.Maximum = 1_000_000;
                ca.AxisY.Interval = 200_000;
            }
            else
            {
                ca.AxisY.Minimum = 0;
                ca.AxisY.Maximum = double.NaN;
                ca.AxisY.Interval = double.NaN;
                ca.RecalculateAxesScale();
            }

            chartDoanhThuPhong.Invalidate();
        }

        private void CapNhatBieuDoSoPhongDat(ThongKeKetQua data)
        {
            var series = chartSoPhongDat.Series[0];
            var ca = chartSoPhongDat.ChartAreas[0];
            series.Points.Clear();

            int maxCount = 0;
            foreach (var item in data.SoLuongDatTheoLoaiPhong)
            {
                if (item.SoLuotDat > maxCount)
                    maxCount = item.SoLuotDat;

                int idx = series.Points.AddY(item.SoLuotDat);
                var pt = series.Points[idx];
                pt.AxisLabel = item.TenLoaiPhong;
                pt.Color = MauCotMacDinh;
                pt.ToolTip = $"{item.TenLoaiPhong}\nTổng số phòng đặt: {item.SoLuotDat} lượt"
                    + $"\n• Hoàn tất/Thanh toán: {item.SoLuotHoanTat}"
                    + $"\n• Đang thuê: {item.SoLuotDangThue}"
                    + $"\n• Đã đặt: {item.SoLuotDangDat}"
                    + "\n(Nhấn vào cột để xem chi tiết)";
            }

            ca.AxisY.Minimum = 0;
            if (maxCount <= 0)
            {
                ca.AxisY.Maximum = 5;
                ca.AxisY.Interval = 1;
            }
            else
            {
                double step = Math.Max(1, Math.Ceiling(maxCount / 5.0));
                double top = Math.Ceiling(maxCount / step) * step;
                if (top <= maxCount)
                    top += step;

                ca.AxisY.Interval = step;
                ca.AxisY.Maximum = top;
            }

            chartSoPhongDat.Invalidate();
        }

        private void CapNhatBieuDoDichVu(ThongKeKetQua data)
        {
            var series = chartDichVu.Series[0];
            series.Points.Clear();

            if (data.DichVuDaSuDung.Count == 0 || data.TongSoLuongDichVu <= 0)
            {
                chartDichVu.Visible = false;
                lblGhiChuPie.Visible = false;
                lblEmptyDichVu.Visible = true;
                lblEmptyDichVu.BringToFront();
                return;
            }

            lblEmptyDichVu.Visible = false;
            chartDichVu.Visible = true;
            lblGhiChuPie.Visible = true;
            lblGhiChuPie.Text = "Nhấn vào miếng biểu đồ để chọn dịch vụ — Nhấn đúp để xem bảng chi tiết";

            for (int i = 0; i < data.DichVuDaSuDung.Count; i++)
            {
                var dv = data.DichVuDaSuDung[i];
                int idx = series.Points.AddY(dv.SoLuong);
                var pt = series.Points[idx];
                pt.Color = BangMauPie[i % BangMauPie.Length];
                pt.LegendText = dv.TenDichVu;
                pt.Label = dv.TiLePhanTram >= 4.0 ? dv.SoLuong.ToString(CultureInfo.InvariantCulture) : string.Empty;
                pt.ToolTip = $"{dv.TenDichVu}\nSố lượng: {dv.SoLuong:N0} ({dv.TiLePhanTram:0.0}%)\nDoanh thu: {ThongKeService.DinhDangTien(dv.DoanhThu)}";
                pt.LegendToolTip = pt.ToolTip;
            }

            chartDichVu.Invalidate();
        }

        private void ChartDoanhThuPhong_MouseMove(object? sender, MouseEventArgs e)
        {
            CapNhatHoverCot(chartDoanhThuPhong, e.Location, ref _hoveredDoanhThuIdx);
        }

        private void ChartSoPhongDat_MouseMove(object? sender, MouseEventArgs e)
        {
            CapNhatHoverCot(chartSoPhongDat, e.Location, ref _hoveredDatPhongIdx);
        }

        private static void CapNhatHoverCot(Chart chart, Point mousePos, ref int hoveredIdx)
        {
            HitTestResult hit = chart.HitTest(mousePos.X, mousePos.Y);
            int newIdx = (hit.ChartElementType == ChartElementType.DataPoint && hit.PointIndex >= 0)
                ? hit.PointIndex
                : -1;

            chart.Cursor = newIdx >= 0 ? Cursors.Hand : Cursors.Default;

            if (newIdx == hoveredIdx)
                return;

            var points = chart.Series[0].Points;
            if (hoveredIdx >= 0 && hoveredIdx < points.Count)
                points[hoveredIdx].Color = MauCotMacDinh;

            if (newIdx >= 0 && newIdx < points.Count)
                points[newIdx].Color = MauCotHover;

            hoveredIdx = newIdx;
            chart.Invalidate();
        }

        private static void DatLaiHoverCot(Chart chart, ref int hoveredIdx)
        {
            chart.Cursor = Cursors.Default;
            if (hoveredIdx >= 0 && chart.Series.Count > 0 && hoveredIdx < chart.Series[0].Points.Count)
            {
                chart.Series[0].Points[hoveredIdx].Color = MauCotMacDinh;
                hoveredIdx = -1;
                chart.Invalidate();
            }
        }

        private void ChartDoanhThuPhong_MouseClick(object? sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left || _duLieuHienTai == null)
                return;

            HitTestResult hit = chartDoanhThuPhong.HitTest(e.X, e.Y);
            if (hit.ChartElementType != ChartElementType.DataPoint || hit.PointIndex < 0)
                return;

            if (hit.PointIndex < _duLieuHienTai.DoanhThuTheoLoaiPhong.Count)
            {
                string tenLoai = _duLieuHienTai.DoanhThuTheoLoaiPhong[hit.PointIndex].TenLoaiPhong;
                MoChiTietDatPhongTheoLoai(tenLoai, chiDoanhThuPhong: true);
            }
        }

        private void ChartSoPhongDat_MouseClick(object? sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left || _duLieuHienTai == null)
                return;

            HitTestResult hit = chartSoPhongDat.HitTest(e.X, e.Y);
            if (hit.ChartElementType != ChartElementType.DataPoint || hit.PointIndex < 0)
                return;

            if (hit.PointIndex < _duLieuHienTai.SoLuongDatTheoLoaiPhong.Count)
            {
                string tenLoai = _duLieuHienTai.SoLuongDatTheoLoaiPhong[hit.PointIndex].TenLoaiPhong;
                MoChiTietDatPhongTheoLoai(tenLoai, chiDoanhThuPhong: false);
            }
        }

        private void ChartDichVu_MouseMove(object? sender, MouseEventArgs e)
        {
            HitTestResult hit = chartDichVu.HitTest(e.X, e.Y);
            bool hitPie = (hit.ChartElementType == ChartElementType.DataPoint || hit.ChartElementType == ChartElementType.DataPointLabel)
                          && hit.PointIndex >= 0;
            bool hitLegend = hit.ChartElementType == ChartElementType.LegendItem
                             && hit.Object is LegendItem li
                             && li.SeriesPointIndex >= 0;

            chartDichVu.Cursor = (hitPie || hitLegend) ? Cursors.Hand : Cursors.Default;
        }

        private void ChartDichVu_MouseClick(object? sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left || _duLieuHienTai == null || _duLieuHienTai.DichVuDaSuDung.Count == 0)
                return;

            HitTestResult hit = chartDichVu.HitTest(e.X, e.Y);
            int clickedIdx = -1;

            if ((hit.ChartElementType == ChartElementType.DataPoint || hit.ChartElementType == ChartElementType.DataPointLabel)
                && hit.PointIndex >= 0)
            {
                clickedIdx = hit.PointIndex;
            }
            else if (hit.ChartElementType == ChartElementType.LegendItem && hit.Object is LegendItem li && li.SeriesPointIndex >= 0)
            {
                clickedIdx = li.SeriesPointIndex;
            }

            if (clickedIdx < 0 || clickedIdx >= chartDichVu.Series[0].Points.Count)
                return;

            int newSelected = (_selectedPieIdx == clickedIdx) ? -1 : clickedIdx;
            _selectedPieIdx = newSelected;

            var points = chartDichVu.Series[0].Points;
            for (int i = 0; i < points.Count; i++)
            {
                points[i]["Exploded"] = (i == newSelected) ? "true" : "false";
            }

            if (newSelected >= 0 && newSelected < _duLieuHienTai.DichVuDaSuDung.Count)
            {
                var dv = _duLieuHienTai.DichVuDaSuDung[newSelected];
                lblGhiChuPie.Text = $"Đã chọn: {dv.TenDichVu} — Số lượng: {dv.SoLuong:N0} ({dv.TiLePhanTram:0.0}%) — Doanh thu: {ThongKeService.DinhDangTien(dv.DoanhThu)}";
            }
            else
            {
                lblGhiChuPie.Text = "Nhấn vào miếng biểu đồ để chọn dịch vụ — Nhấn đúp để xem bảng chi tiết";
            }

            chartDichVu.Invalidate();
        }

        private void MoChiTietDatPhongTheoLoai(string? tenLoaiPhong, bool chiDoanhThuPhong)
        {
            if (_duLieuHienTai == null)
                return;

            IEnumerable<ChiTietDatPhongThongKeItem> query = _duLieuHienTai.ChiTietDatPhongs;
            if (!string.IsNullOrWhiteSpace(tenLoaiPhong))
            {
                query = query.Where(x => string.Equals(x.TenLoaiPhong, tenLoaiPhong, StringComparison.OrdinalIgnoreCase));
            }
            if (chiDoanhThuPhong)
            {
                query = query.Where(x => x.DaThanhToan);
            }

            var danhSach = query.ToList();
            string tieuDe = string.IsNullOrWhiteSpace(tenLoaiPhong)
                ? (chiDoanhThuPhong ? "Chi tiết doanh thu thuê phòng" : "Chi tiết toàn bộ lượt đặt phòng")
                : (chiDoanhThuPhong ? $"Chi tiết doanh thu — Loại phòng: {tenLoaiPhong}" : $"Chi tiết đặt phòng — Loại phòng: {tenLoaiPhong}");

            using var dlg = FormChiTietThongKe.TaoDialogDatPhong(
                tieuDe,
                _duLieuHienTai.TuNgay,
                _duLieuHienTai.DenNgay,
                danhSach,
                chiDoanhThuPhong);
            dlg.ShowDialog(this);
        }

        private void MoChiTietDichVu()
        {
            if (_duLieuHienTai == null)
                return;

            using var dlg = FormChiTietThongKe.TaoDialogDichVu(
                "Chi tiết thống kê dịch vụ đã sử dụng",
                _duLieuHienTai.TuNgay,
                _duLieuHienTai.DenNgay,
                _duLieuHienTai.DichVuDaSuDung);
            dlg.ShowDialog(this);
        }

        private void btnXuatBaoCao_Click(object? sender, EventArgs e)
        {
            if (_duLieuHienTai == null)
            {
                MessageBox.Show("Chưa có dữ liệu thống kê để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using var saveDialog = new SaveFileDialog
            {
                Title = "Xuất báo cáo thống kê kinh doanh",
                Filter = "PDF Report (*.pdf)|*.pdf|Excel Workbook (*.xlsx)|*.xlsx",
                DefaultExt = "pdf",
                FileName = $"BaoCaoThongKe_{_duLieuHienTai.TuNgay:yyyyMMdd}_{_duLieuHienTai.DenNgay:yyyyMMdd}"
            };

            if (saveDialog.ShowDialog(this) != DialogResult.OK)
                return;

            try
            {
                Cursor = Cursors.WaitCursor;

                byte[]? chartDtPng = ChupAnhBieuDoPng(chartDoanhThuPhong);
                byte[]? chartDatPng = ChupAnhBieuDoPng(chartSoPhongDat);
                byte[]? chartDvPng = _duLieuHienTai.DichVuDaSuDung.Count > 0 ? ChupAnhBieuDoPng(chartDichVu) : null;
                string nguoiLap = FormDangNhap.TenNV_DangNhap;

                string ext = Path.GetExtension(saveDialog.FileName);
                if (string.Equals(ext, ".xlsx", StringComparison.OrdinalIgnoreCase))
                {
                    ThongKeReportExporter.XuatExcel(
                        saveDialog.FileName,
                        _duLieuHienTai,
                        nguoiLap,
                        chartDtPng,
                        chartDatPng,
                        chartDvPng);
                }
                else
                {
                    ThongKeReportExporter.XuatPdf(
                        saveDialog.FileName,
                        _duLieuHienTai,
                        nguoiLap,
                        chartDtPng,
                        chartDatPng,
                        chartDvPng);
                }

                Cursor = Cursors.Default;

                DialogResult moFile = MessageBox.Show(
                    "Xuất báo cáo thống kê thành công!\nBạn có muốn mở file vừa xuất không?",
                    "Thông báo",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information);

                if (moFile == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(saveDialog.FileName)
                    {
                        UseShellExecute = true
                    });
                }
            }
            catch (IOException)
            {
                Cursor = Cursors.Default;
                MessageBox.Show(
                    "Không ghi được file. Có thể file đang được mở ở chương trình khác, hãy đóng lại rồi thử lại.",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show(
                    "Lỗi khi xuất báo cáo: " + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private static byte[]? ChupAnhBieuDoPng(Chart chart)
        {
            if (chart.Width <= 0 || chart.Height <= 0)
                return null;

            using var ms = new MemoryStream();
            chart.SaveImage(ms, ChartImageFormat.Png);
            return ms.ToArray();
        }

        private void GanSuKienResizeHost()
        {
            if (_hostFormTheoDoi != null)
            {
                _hostFormTheoDoi.Resize -= HostForm_Resize;
                _hostFormTheoDoi = null;
            }
            _hostPanelTheoDoi = null;

            if (Parent is Panel hostPanel && hostPanel.Parent is Form hostForm)
            {
                _hostPanelTheoDoi = hostPanel;
                _hostFormTheoDoi = hostForm;
                _hostFormTheoDoi.Resize += HostForm_Resize;
            }
        }

        private void HostForm_Resize(object? sender, EventArgs e)
        {
            CapNhatKichThuocCanvas();
        }

        private void CapNhatKichThuocCanvas()
        {
            if (IsDisposed || pnlRootCanvas == null)
                return;

            int targetWidth;
            int targetHeight;

            if (_hostPanelTheoDoi != null && _hostFormTheoDoi != null)
            {
                int availW = _hostFormTheoDoi.ClientSize.Width - _hostPanelTheoDoi.Left - SystemInformation.VerticalScrollBarWidth - 6;
                int availH = _hostFormTheoDoi.ClientSize.Height - _hostPanelTheoDoi.Top - 8;

                availW = Math.Min(availW, ClientSize.Width);
                availH = Math.Min(availH, ClientSize.Height);

                targetWidth = Math.Clamp(availW, 1140, 1620);
                targetHeight = Math.Clamp(availH, 760, 920);
            }
            else
            {
                targetWidth = Math.Max(1140, ClientSize.Width);
                targetHeight = Math.Max(760, ClientSize.Height);
            }

            if (pnlRootCanvas.Width != targetWidth || pnlRootCanvas.Height != targetHeight)
            {
                pnlRootCanvas.Size = new Size(targetWidth, targetHeight);
            }
        }

        private static void VeCardBoGoc(Panel panel, Graphics g, Color borderColor, int radius)
        {
            if (panel.Width <= 2 || panel.Height <= 2)
                return;

            g.SmoothingMode = SmoothingMode.AntiAlias;

            var rect = new Rectangle(0, 0, panel.Width - 1, panel.Height - 1);
            using GraphicsPath roundPath = TaoDuongDanBoGoc(rect, radius);

            // Che 4 góc vuông phía ngoài đường bo tròn bằng màu nền canvas để viền bo mịn
            using (var maskPath = new GraphicsPath(FillMode.Alternate))
            {
                maskPath.AddRectangle(new Rectangle(-1, -1, panel.Width + 2, panel.Height + 2));
                maskPath.AddPath(roundPath, false);
                using var bgBrush = new SolidBrush(MauNenCanvas);
                g.FillPath(bgBrush, maskPath);
            }

            using var pen = new Pen(borderColor, 1F);
            g.DrawPath(pen, roundPath);
        }

        private static GraphicsPath TaoDuongDanBoGoc(Rectangle bounds, int radius)
        {
            int d = radius * 2;
            var path = new GraphicsPath();
            path.AddArc(bounds.X, bounds.Y, d, d, 180, 90);
            path.AddArc(bounds.Right - d, bounds.Y, d, d, 270, 90);
            path.AddArc(bounds.Right - d, bounds.Bottom - d, d, d, 0, 90);
            path.AddArc(bounds.X, bounds.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            return path;
        }

        private static void BatDoubleBuffer(Control control)
        {
            typeof(Control)
                .GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic)
                ?.SetValue(control, true);
        }

        private void GanSuKienClickDeCon(Control root, Action onClick)
        {
            root.Cursor = Cursors.Hand;
            root.Click += (_, _) => onClick();
            foreach (Control child in root.Controls)
            {
                GanSuKienClickDeCon(child, onClick);
            }
        }

        private void GanToolTipDeCon(Control root, string text)
        {
            toolTipDashboard.SetToolTip(root, text);
            foreach (Control child in root.Controls)
            {
                GanToolTipDeCon(child, text);
            }
        }

        private void FormThongKe_Disposed(object? sender, EventArgs e)
        {
            if (_hostFormTheoDoi != null)
            {
                _hostFormTheoDoi.Resize -= HostForm_Resize;
                _hostFormTheoDoi = null;
            }

            _ctsTaiDuLieu?.Cancel();
            _ctsTaiDuLieu?.Dispose();
            _ctsTaiDuLieu = null;

            foreach (Image img in _loadedIcons)
            {
                img.Dispose();
            }
            _loadedIcons.Clear();
        }
    }
}
