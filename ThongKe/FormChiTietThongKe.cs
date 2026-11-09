using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace HotelManagement.ThongKe
{
    internal sealed class FormChiTietThongKe : Form
    {
        private readonly Label _lblTieuDe;
        private readonly Label _lblPhamVi;
        private readonly DataGridView _dgvChiTiet;
        private readonly Label _lblTongKet;
        private readonly Button _btnDong;

        private FormChiTietThongKe(string tieuDe, string phamViThoiGian, string tongKet)
        {
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 248, 252);
            ClientSize = new Size(980, 560);
            MinimumSize = new Size(760, 420);
            StartPosition = FormStartPosition.CenterParent;
            ShowInTaskbar = false;
            FormBorderStyle = FormBorderStyle.Sizable;
            MinimizeBox = false;
            MaximizeBox = true;
            Text = tieuDe;

            var pnlTop = new Panel
            {
                Dock = DockStyle.Top,
                Height = 76,
                Padding = new Padding(18, 12, 18, 8),
                BackColor = Color.FromArgb(24, 58, 122)
            };

            _lblTieuDe = new Label
            {
                Dock = DockStyle.Top,
                Height = 30,
                Font = new Font("Segoe UI", 13.5F, FontStyle.Bold),
                ForeColor = Color.White,
                Text = tieuDe,
                AutoEllipsis = true
            };

            _lblPhamVi = new Label
            {
                Dock = DockStyle.Bottom,
                Height = 24,
                Font = new Font("Segoe UI", 10F, FontStyle.Regular),
                ForeColor = Color.FromArgb(215, 228, 248),
                Text = phamViThoiGian,
                AutoEllipsis = true
            };

            pnlTop.Controls.Add(_lblTieuDe);
            pnlTop.Controls.Add(_lblPhamVi);

            var pnlBottom = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 62,
                Padding = new Padding(18, 10, 18, 12),
                BackColor = Color.White
            };

            _btnDong = new Button
            {
                Dock = DockStyle.Right,
                Width = 116,
                Text = "Đóng",
                Font = new Font("Segoe UI", 10.5F, FontStyle.Bold),
                BackColor = Color.FromArgb(38, 132, 232),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            _btnDong.FlatAppearance.BorderSize = 0;
            _btnDong.Click += (_, _) => Close();
            CancelButton = _btnDong;

            _lblTongKet = new Label
            {
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                ForeColor = Color.FromArgb(24, 58, 122),
                TextAlign = ContentAlignment.MiddleLeft,
                Text = tongKet,
                AutoEllipsis = true
            };

            pnlBottom.Controls.Add(_lblTongKet);
            pnlBottom.Controls.Add(_btnDong);

            var pnlGridHost = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(16, 12, 16, 12),
                BackColor = Color.FromArgb(245, 248, 252)
            };

            _dgvChiTiet = new DataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AllowUserToResizeRows = false,
                MultiSelect = false,
                RowHeadersVisible = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                EnableHeadersVisualStyles = false,
                GridColor = Color.FromArgb(228, 233, 242),
                Font = new Font("Segoe UI", 10F, FontStyle.Regular)
            };
            _dgvChiTiet.RowTemplate.Height = 34;
            _dgvChiTiet.ColumnHeadersHeight = 38;
            _dgvChiTiet.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            _dgvChiTiet.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(216, 195, 210),
                ForeColor = Color.FromArgb(24, 58, 122),
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Alignment = DataGridViewContentAlignment.MiddleCenter
            };
            _dgvChiTiet.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(248, 250, 253)
            };
            _dgvChiTiet.DefaultCellStyle = new DataGridViewCellStyle
            {
                SelectionBackColor = Color.FromArgb(220, 235, 252),
                SelectionForeColor = Color.FromArgb(20, 30, 50)
            };

            pnlGridHost.Controls.Add(_dgvChiTiet);

            Controls.Add(pnlGridHost);
            Controls.Add(pnlBottom);
            Controls.Add(pnlTop);
        }

        public static FormChiTietThongKe TaoDialogDatPhong(
            string tieuDe,
            DateTime tuNgay,
            DateTime denNgay,
            IReadOnlyList<ChiTietDatPhongThongKeItem> danhSach,
            bool chiHienThiDoanhThuPhong)
        {
            decimal tongTienPhong = danhSach.Where(x => x.DaThanhToan).Sum(x => x.TienPhong);
            decimal tongTienDv = danhSach.Where(x => x.DaThanhToan).Sum(x => x.TienDichVu);
            string tongKet = chiHienThiDoanhThuPhong
                ? $"Tổng cộng ({danhSach.Count} lượt đã thanh toán): Tiền phòng {ThongKeService.DinhDangTien(tongTienPhong)}  |  Dịch vụ {ThongKeService.DinhDangTien(tongTienDv)}"
                : $"Tổng số lượt đặt: {danhSach.Count} (Đã thanh toán/xong: {danhSach.Count(x => x.DaThanhToan)})  |  Doanh thu phòng thực thu: {ThongKeService.DinhDangTien(tongTienPhong)}";

            var frm = new FormChiTietThongKe(
                tieuDe,
                $"Khoảng thời gian: {tuNgay:dd/MM/yyyy} – {denNgay:dd/MM/yyyy}",
                tongKet);

            var dgv = frm._dgvChiTiet;
            dgv.Columns.Add("MaCtdp", "Mã CTDP");
            dgv.Columns.Add("MaPt", "Phiếu thuê");
            dgv.Columns.Add("MaPhong", "Phòng");
            dgv.Columns.Add("TenLoaiPhong", "Loại phòng");
            dgv.Columns.Add("TenKhachHang", "Khách hàng");
            dgv.Columns.Add("CheckIn", "Check-in");
            dgv.Columns.Add("CheckOut", "Check-out");
            dgv.Columns.Add("TrangThai", "Trạng thái");
            dgv.Columns.Add("TienPhong", "Tiền phòng (VND)");
            dgv.Columns.Add("TienDichVu", "Tiền DV (VND)");

            dgv.Columns["MaCtdp"]!.FillWeight = 9;
            dgv.Columns["MaPt"]!.FillWeight = 9;
            dgv.Columns["MaPhong"]!.FillWeight = 8;
            dgv.Columns["TenLoaiPhong"]!.FillWeight = 11;
            dgv.Columns["TenKhachHang"]!.FillWeight = 17;
            dgv.Columns["CheckIn"]!.FillWeight = 10;
            dgv.Columns["CheckOut"]!.FillWeight = 10;
            dgv.Columns["TrangThai"]!.FillWeight = 10;
            dgv.Columns["TienPhong"]!.FillWeight = 9;
            dgv.Columns["TienDichVu"]!.FillWeight = 7;

            dgv.Columns["CheckIn"]!.DefaultCellStyle.Format = "dd/MM/yyyy";
            dgv.Columns["CheckOut"]!.DefaultCellStyle.Format = "dd/MM/yyyy";
            dgv.Columns["CheckIn"]!.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns["CheckOut"]!.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns["MaPhong"]!.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns["TrangThai"]!.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgv.Columns["TienPhong"]!.DefaultCellStyle.Format = "N0";
            dgv.Columns["TienPhong"]!.DefaultCellStyle.FormatProvider = CultureInfo.InvariantCulture;
            dgv.Columns["TienPhong"]!.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgv.Columns["TienDichVu"]!.DefaultCellStyle.Format = "N0";
            dgv.Columns["TienDichVu"]!.DefaultCellStyle.FormatProvider = CultureInfo.InvariantCulture;
            dgv.Columns["TienDichVu"]!.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            foreach (var item in danhSach)
            {
                dgv.Rows.Add(
                    item.MaCtdp,
                    item.MaPt,
                    item.MaPhong,
                    item.TenLoaiPhong,
                    item.TenKhachHang,
                    item.CheckIn,
                    item.CheckOut,
                    item.TrangThai,
                    item.TienPhong,
                    item.TienDichVu);
            }

            dgv.ClearSelection();
            return frm;
        }

        public static FormChiTietThongKe TaoDialogDichVu(
            string tieuDe,
            DateTime tuNgay,
            DateTime denNgay,
            IReadOnlyList<DichVuSuDungItem> danhSach)
        {
            int tongSl = danhSach.Sum(x => x.SoLuong);
            decimal tongTien = danhSach.Sum(x => x.DoanhThu);
            string tongKet = $"Tổng số lượng sử dụng: {tongSl:N0}  |  Tổng doanh thu dịch vụ: {ThongKeService.DinhDangTien(tongTien)}";

            var frm = new FormChiTietThongKe(
                tieuDe,
                $"Khoảng thời gian: {tuNgay:dd/MM/yyyy} – {denNgay:dd/MM/yyyy}",
                tongKet);

            var dgv = frm._dgvChiTiet;
            dgv.Columns.Add("MaDichVu", "Mã DV");
            dgv.Columns.Add("TenDichVu", "Tên dịch vụ");
            dgv.Columns.Add("DonGia", "Đơn giá (VND)");
            dgv.Columns.Add("SoLuong", "Số lượng");
            dgv.Columns.Add("TiLe", "Tỉ lệ (%)");
            dgv.Columns.Add("DoanhThu", "Doanh thu (VND)");

            dgv.Columns["MaDichVu"]!.FillWeight = 12;
            dgv.Columns["TenDichVu"]!.FillWeight = 28;
            dgv.Columns["DonGia"]!.FillWeight = 16;
            dgv.Columns["SoLuong"]!.FillWeight = 12;
            dgv.Columns["TiLe"]!.FillWeight = 12;
            dgv.Columns["DoanhThu"]!.FillWeight = 20;

            dgv.Columns["MaDichVu"]!.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns["SoLuong"]!.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns["TiLe"]!.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgv.Columns["DonGia"]!.DefaultCellStyle.Format = "N0";
            dgv.Columns["DonGia"]!.DefaultCellStyle.FormatProvider = CultureInfo.InvariantCulture;
            dgv.Columns["DonGia"]!.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgv.Columns["DoanhThu"]!.DefaultCellStyle.Format = "N0";
            dgv.Columns["DoanhThu"]!.DefaultCellStyle.FormatProvider = CultureInfo.InvariantCulture;
            dgv.Columns["DoanhThu"]!.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            foreach (var dv in danhSach)
            {
                dgv.Rows.Add(
                    dv.MaDichVu,
                    dv.TenDichVu,
                    dv.DonGia,
                    dv.SoLuong,
                    dv.TiLePhanTram.ToString("0.0", CultureInfo.InvariantCulture) + "%",
                    dv.DoanhThu);
            }

            dgv.ClearSelection();
            return frm;
        }
    }
}
