namespace HotelManagement.ThongKe
{
    partial class FormThongKe
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null!;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            toolTipDashboard = new ToolTip(components);

            pnlRootCanvas = new Panel();
            tlpLayout = new TableLayoutPanel();

            pnlFilter = new Panel();
            pnlFilterLeft = new FlowLayoutPanel();
            lblTuNgay = new Label();
            dtpTuNgay = new DateTimePicker();
            lblDenNgay = new Label();
            dtpDenNgay = new DateTimePicker();
            btnXemThongKe = new Button();
            btnXuatBaoCao = new Button();

            tlpKpiCards = new TableLayoutPanel();
            pnlKpiThuePhong = new Panel();
            picThuePhong = new PictureBox();
            tlpKpiThuePhongText = new TableLayoutPanel();
            lblTieuDeDoanhThuPhong = new Label();
            lblGiaTriDoanhThuPhong = new Label();

            pnlKpiDichVu = new Panel();
            picDichVu = new PictureBox();
            tlpKpiDichVuText = new TableLayoutPanel();
            lblTieuDeDoanhThuDichVu = new Label();
            lblGiaTriDoanhThuDichVu = new Label();

            pnlKpiSoPhongDat = new Panel();
            picDatPhong = new PictureBox();
            tlpKpiSoPhongDatText = new TableLayoutPanel();
            lblTieuDeSoPhongDat = new Label();
            lblGiaTriSoPhongDat = new Label();

            tlpNoiDungChinh = new TableLayoutPanel();
            tlpCotTrai = new TableLayoutPanel();

            pnlTopLoaiPhongDoanhThu = new Panel();
            picTop1PhongDoanhThu = new PictureBox();
            tlpTop1PhongDoanhThuText = new TableLayoutPanel();
            lblTieuDeTopPhongDoanhThu = new Label();
            lblGiaTriTopPhongDoanhThu = new Label();

            pnlTopLoaiPhongDat = new Panel();
            picTop1PhongDat = new PictureBox();
            tlpTop1PhongDatText = new TableLayoutPanel();
            lblTieuDeTopPhongDat = new Label();
            lblGiaTriTopPhongDat = new Label();

            pnlTopDichVu = new Panel();
            picTop1DichVu = new PictureBox();
            tlpTop1DichVuText = new TableLayoutPanel();
            lblTieuDeTopDichVu = new Label();
            lblGiaTriTopDichVu = new Label();

            pnlBieuDoDichVu = new Panel();
            lblTieuDeBieuDoDichVu = new Label();
            pnlHostChartDichVu = new Panel();
            chartDichVu = new FastReport.DataVisualization.Charting.Chart();
            lblEmptyDichVu = new Label();
            lblGhiChuPie = new Label();

            tlpCotPhai = new TableLayoutPanel();
            pnlBieuDoDoanhThuPhong = new Panel();
            lblTieuDeBieuDoDoanhThu = new Label();
            pnlHostChartDoanhThu = new Panel();
            chartDoanhThuPhong = new FastReport.DataVisualization.Charting.Chart();

            pnlBieuDoSoPhongDat = new Panel();
            lblTieuDeBieuDoSoPhongDat = new Label();
            pnlHostChartSoPhongDat = new Panel();
            chartSoPhongDat = new FastReport.DataVisualization.Charting.Chart();

            pnlRootCanvas.SuspendLayout();
            tlpLayout.SuspendLayout();
            pnlFilter.SuspendLayout();
            pnlFilterLeft.SuspendLayout();
            tlpKpiCards.SuspendLayout();
            pnlKpiThuePhong.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picThuePhong).BeginInit();
            tlpKpiThuePhongText.SuspendLayout();
            pnlKpiDichVu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picDichVu).BeginInit();
            tlpKpiDichVuText.SuspendLayout();
            pnlKpiSoPhongDat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picDatPhong).BeginInit();
            tlpKpiSoPhongDatText.SuspendLayout();
            tlpNoiDungChinh.SuspendLayout();
            tlpCotTrai.SuspendLayout();
            pnlTopLoaiPhongDoanhThu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picTop1PhongDoanhThu).BeginInit();
            tlpTop1PhongDoanhThuText.SuspendLayout();
            pnlTopLoaiPhongDat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picTop1PhongDat).BeginInit();
            tlpTop1PhongDatText.SuspendLayout();
            pnlTopDichVu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picTop1DichVu).BeginInit();
            tlpTop1DichVuText.SuspendLayout();
            pnlBieuDoDichVu.SuspendLayout();
            pnlHostChartDichVu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chartDichVu).BeginInit();
            tlpCotPhai.SuspendLayout();
            pnlBieuDoDoanhThuPhong.SuspendLayout();
            pnlHostChartDoanhThu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chartDoanhThuPhong).BeginInit();
            pnlBieuDoSoPhongDat.SuspendLayout();
            pnlHostChartSoPhongDat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chartSoPhongDat).BeginInit();
            SuspendLayout();

            //
            // pnlRootCanvas
            //
            pnlRootCanvas.BackColor = Color.FromArgb(240, 244, 249);
            pnlRootCanvas.Controls.Add(tlpLayout);
            pnlRootCanvas.Location = new Point(0, 0);
            pnlRootCanvas.Name = "pnlRootCanvas";
            pnlRootCanvas.Padding = new Padding(14, 10, 14, 12);
            pnlRootCanvas.Size = new Size(1380, 880);
            pnlRootCanvas.TabIndex = 0;

            //
            // tlpLayout
            //
            tlpLayout.BackColor = Color.Transparent;
            tlpLayout.ColumnCount = 1;
            tlpLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpLayout.Controls.Add(pnlFilter, 0, 0);
            tlpLayout.Controls.Add(tlpKpiCards, 0, 1);
            tlpLayout.Controls.Add(tlpNoiDungChinh, 0, 2);
            tlpLayout.Dock = DockStyle.Fill;
            tlpLayout.Name = "tlpLayout";
            tlpLayout.RowCount = 3;
            tlpLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 52F));
            tlpLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 112F));
            tlpLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpLayout.TabIndex = 0;

            //
            // pnlFilter
            //
            pnlFilter.BackColor = Color.Transparent;
            pnlFilter.Controls.Add(pnlFilterLeft);
            pnlFilter.Controls.Add(btnXuatBaoCao);
            pnlFilter.Dock = DockStyle.Fill;
            pnlFilter.Margin = new Padding(0, 0, 0, 6);
            pnlFilter.Name = "pnlFilter";
            pnlFilter.Size = new Size(1352, 46);
            pnlFilter.TabIndex = 0;

            //
            // pnlFilterLeft
            //
            pnlFilterLeft.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlFilterLeft.AutoSize = false;
            pnlFilterLeft.BackColor = Color.Transparent;
            pnlFilterLeft.Controls.Add(lblTuNgay);
            pnlFilterLeft.Controls.Add(dtpTuNgay);
            pnlFilterLeft.Controls.Add(lblDenNgay);
            pnlFilterLeft.Controls.Add(dtpDenNgay);
            pnlFilterLeft.Controls.Add(btnXemThongKe);
            pnlFilterLeft.FlowDirection = FlowDirection.LeftToRight;
            pnlFilterLeft.Location = new Point(0, 0);
            pnlFilterLeft.Name = "pnlFilterLeft";
            pnlFilterLeft.Padding = new Padding(0, 4, 0, 0);
            pnlFilterLeft.Size = new Size(1180, 44);
            pnlFilterLeft.WrapContents = false;

            //
            // lblTuNgay
            //
            lblTuNgay.AutoSize = true;
            lblTuNgay.Font = new Font("Segoe UI", 10.5F, FontStyle.Regular);
            lblTuNgay.ForeColor = Color.FromArgb(30, 36, 48);
            lblTuNgay.Margin = new Padding(0, 9, 8, 0);
            lblTuNgay.Name = "lblTuNgay";
            lblTuNgay.Text = "Từ ngày";

            //
            // dtpTuNgay
            //
            dtpTuNgay.CustomFormat = "dd/MM/yyyy";
            dtpTuNgay.Font = new Font("Segoe UI", 10.5F, FontStyle.Regular);
            dtpTuNgay.Format = DateTimePickerFormat.Custom;
            dtpTuNgay.Margin = new Padding(0, 4, 22, 0);
            dtpTuNgay.Name = "dtpTuNgay";
            dtpTuNgay.Size = new Size(156, 31);
            dtpTuNgay.TabIndex = 1;

            //
            // lblDenNgay
            //
            lblDenNgay.AutoSize = true;
            lblDenNgay.Font = new Font("Segoe UI", 10.5F, FontStyle.Regular);
            lblDenNgay.ForeColor = Color.FromArgb(30, 36, 48);
            lblDenNgay.Margin = new Padding(0, 9, 8, 0);
            lblDenNgay.Name = "lblDenNgay";
            lblDenNgay.Text = "Đến ngày";

            //
            // dtpDenNgay
            //
            dtpDenNgay.CustomFormat = "dd/MM/yyyy";
            dtpDenNgay.Font = new Font("Segoe UI", 10.5F, FontStyle.Regular);
            dtpDenNgay.Format = DateTimePickerFormat.Custom;
            dtpDenNgay.Margin = new Padding(0, 4, 22, 0);
            dtpDenNgay.Name = "dtpDenNgay";
            dtpDenNgay.Size = new Size(156, 31);
            dtpDenNgay.TabIndex = 2;

            //
            // btnXemThongKe
            //
            btnXemThongKe.BackColor = Color.White;
            btnXemThongKe.Cursor = Cursors.Hand;
            btnXemThongKe.FlatAppearance.BorderColor = Color.FromArgb(148, 158, 174);
            btnXemThongKe.FlatAppearance.BorderSize = 1;
            btnXemThongKe.FlatAppearance.MouseOverBackColor = Color.FromArgb(232, 240, 254);
            btnXemThongKe.FlatStyle = FlatStyle.Flat;
            btnXemThongKe.Font = new Font("Segoe UI", 10.5F, FontStyle.Regular);
            btnXemThongKe.ForeColor = Color.FromArgb(24, 30, 40);
            btnXemThongKe.Margin = new Padding(0, 2, 12, 0);
            btnXemThongKe.Name = "btnXemThongKe";
            btnXemThongKe.Size = new Size(146, 36);
            btnXemThongKe.TabIndex = 3;
            btnXemThongKe.Text = "Xem thống kê";
            btnXemThongKe.UseVisualStyleBackColor = false;
            btnXemThongKe.Click += btnXemThongKe_Click;

            //
            // btnXuatBaoCao
            //
            btnXuatBaoCao.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnXuatBaoCao.BackColor = Color.FromArgb(24, 66, 130);
            btnXuatBaoCao.Cursor = Cursors.Hand;
            btnXuatBaoCao.FlatAppearance.BorderSize = 0;
            btnXuatBaoCao.FlatAppearance.MouseOverBackColor = Color.FromArgb(34, 86, 165);
            btnXuatBaoCao.FlatStyle = FlatStyle.Flat;
            btnXuatBaoCao.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            btnXuatBaoCao.ForeColor = Color.White;
            btnXuatBaoCao.Location = new Point(1196, 6);
            btnXuatBaoCao.Margin = new Padding(0);
            btnXuatBaoCao.Name = "btnXuatBaoCao";
            btnXuatBaoCao.Size = new Size(156, 36);
            btnXuatBaoCao.TabIndex = 4;
            btnXuatBaoCao.Text = "Xuất báo cáo";
            btnXuatBaoCao.UseVisualStyleBackColor = false;
            btnXuatBaoCao.Click += btnXuatBaoCao_Click;

            //
            // tlpKpiCards
            //
            tlpKpiCards.BackColor = Color.Transparent;
            tlpKpiCards.ColumnCount = 3;
            tlpKpiCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333F));
            tlpKpiCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3334F));
            tlpKpiCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333F));
            tlpKpiCards.Controls.Add(pnlKpiThuePhong, 0, 0);
            tlpKpiCards.Controls.Add(pnlKpiDichVu, 1, 0);
            tlpKpiCards.Controls.Add(pnlKpiSoPhongDat, 2, 0);
            tlpKpiCards.Dock = DockStyle.Fill;
            tlpKpiCards.Margin = new Padding(0, 0, 0, 10);
            tlpKpiCards.Name = "tlpKpiCards";
            tlpKpiCards.RowCount = 1;
            tlpKpiCards.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpKpiCards.TabIndex = 1;

            //
            // pnlKpiThuePhong
            //
            pnlKpiThuePhong.BackColor = Color.FromArgb(249, 127, 114);
            pnlKpiThuePhong.Controls.Add(tlpKpiThuePhongText);
            pnlKpiThuePhong.Controls.Add(picThuePhong);
            pnlKpiThuePhong.Cursor = Cursors.Hand;
            pnlKpiThuePhong.Dock = DockStyle.Fill;
            pnlKpiThuePhong.Margin = new Padding(0, 0, 8, 0);
            pnlKpiThuePhong.Name = "pnlKpiThuePhong";
            pnlKpiThuePhong.Padding = new Padding(16, 10, 14, 10);
            pnlKpiThuePhong.TabIndex = 0;

            //
            // picThuePhong
            //
            picThuePhong.BackColor = Color.Transparent;
            picThuePhong.Dock = DockStyle.Left;
            picThuePhong.Name = "picThuePhong";
            picThuePhong.Size = new Size(72, 82);
            picThuePhong.SizeMode = PictureBoxSizeMode.Zoom;
            picThuePhong.TabStop = false;

            //
            // tlpKpiThuePhongText
            //
            tlpKpiThuePhongText.BackColor = Color.Transparent;
            tlpKpiThuePhongText.ColumnCount = 1;
            tlpKpiThuePhongText.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpKpiThuePhongText.Controls.Add(lblTieuDeDoanhThuPhong, 0, 0);
            tlpKpiThuePhongText.Controls.Add(lblGiaTriDoanhThuPhong, 0, 1);
            tlpKpiThuePhongText.Dock = DockStyle.Fill;
            tlpKpiThuePhongText.Name = "tlpKpiThuePhongText";
            tlpKpiThuePhongText.RowCount = 2;
            tlpKpiThuePhongText.RowStyles.Add(new RowStyle(SizeType.Percent, 46F));
            tlpKpiThuePhongText.RowStyles.Add(new RowStyle(SizeType.Percent, 54F));

            //
            // lblTieuDeDoanhThuPhong
            //
            lblTieuDeDoanhThuPhong.BackColor = Color.Transparent;
            lblTieuDeDoanhThuPhong.Dock = DockStyle.Fill;
            lblTieuDeDoanhThuPhong.Font = new Font("Segoe UI", 11.5F, FontStyle.Regular);
            lblTieuDeDoanhThuPhong.ForeColor = Color.FromArgb(24, 28, 34);
            lblTieuDeDoanhThuPhong.Name = "lblTieuDeDoanhThuPhong";
            lblTieuDeDoanhThuPhong.Text = "Doanh thu thuê phòng";
            lblTieuDeDoanhThuPhong.TextAlign = ContentAlignment.BottomCenter;

            //
            // lblGiaTriDoanhThuPhong
            //
            lblGiaTriDoanhThuPhong.AutoEllipsis = true;
            lblGiaTriDoanhThuPhong.BackColor = Color.Transparent;
            lblGiaTriDoanhThuPhong.Dock = DockStyle.Fill;
            lblGiaTriDoanhThuPhong.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblGiaTriDoanhThuPhong.ForeColor = Color.FromArgb(18, 22, 28);
            lblGiaTriDoanhThuPhong.Name = "lblGiaTriDoanhThuPhong";
            lblGiaTriDoanhThuPhong.Text = "0 VND";
            lblGiaTriDoanhThuPhong.TextAlign = ContentAlignment.TopCenter;

            //
            // pnlKpiDichVu
            //
            pnlKpiDichVu.BackColor = Color.FromArgb(182, 168, 68);
            pnlKpiDichVu.Controls.Add(tlpKpiDichVuText);
            pnlKpiDichVu.Controls.Add(picDichVu);
            pnlKpiDichVu.Cursor = Cursors.Hand;
            pnlKpiDichVu.Dock = DockStyle.Fill;
            pnlKpiDichVu.Margin = new Padding(4, 0, 4, 0);
            pnlKpiDichVu.Name = "pnlKpiDichVu";
            pnlKpiDichVu.Padding = new Padding(16, 10, 14, 10);
            pnlKpiDichVu.TabIndex = 1;

            //
            // picDichVu
            //
            picDichVu.BackColor = Color.Transparent;
            picDichVu.Dock = DockStyle.Left;
            picDichVu.Name = "picDichVu";
            picDichVu.Size = new Size(72, 82);
            picDichVu.SizeMode = PictureBoxSizeMode.Zoom;
            picDichVu.TabStop = false;

            //
            // tlpKpiDichVuText
            //
            tlpKpiDichVuText.BackColor = Color.Transparent;
            tlpKpiDichVuText.ColumnCount = 1;
            tlpKpiDichVuText.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpKpiDichVuText.Controls.Add(lblTieuDeDoanhThuDichVu, 0, 0);
            tlpKpiDichVuText.Controls.Add(lblGiaTriDoanhThuDichVu, 0, 1);
            tlpKpiDichVuText.Dock = DockStyle.Fill;
            tlpKpiDichVuText.Name = "tlpKpiDichVuText";
            tlpKpiDichVuText.RowCount = 2;
            tlpKpiDichVuText.RowStyles.Add(new RowStyle(SizeType.Percent, 46F));
            tlpKpiDichVuText.RowStyles.Add(new RowStyle(SizeType.Percent, 54F));

            //
            // lblTieuDeDoanhThuDichVu
            //
            lblTieuDeDoanhThuDichVu.BackColor = Color.Transparent;
            lblTieuDeDoanhThuDichVu.Dock = DockStyle.Fill;
            lblTieuDeDoanhThuDichVu.Font = new Font("Segoe UI", 11.5F, FontStyle.Regular);
            lblTieuDeDoanhThuDichVu.ForeColor = Color.FromArgb(24, 28, 34);
            lblTieuDeDoanhThuDichVu.Name = "lblTieuDeDoanhThuDichVu";
            lblTieuDeDoanhThuDichVu.Text = "Doanh thu dịch vụ";
            lblTieuDeDoanhThuDichVu.TextAlign = ContentAlignment.BottomCenter;

            //
            // lblGiaTriDoanhThuDichVu
            //
            lblGiaTriDoanhThuDichVu.AutoEllipsis = true;
            lblGiaTriDoanhThuDichVu.BackColor = Color.Transparent;
            lblGiaTriDoanhThuDichVu.Dock = DockStyle.Fill;
            lblGiaTriDoanhThuDichVu.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblGiaTriDoanhThuDichVu.ForeColor = Color.FromArgb(18, 22, 28);
            lblGiaTriDoanhThuDichVu.Name = "lblGiaTriDoanhThuDichVu";
            lblGiaTriDoanhThuDichVu.Text = "0 VND";
            lblGiaTriDoanhThuDichVu.TextAlign = ContentAlignment.TopCenter;

            //
            // pnlKpiSoPhongDat
            //
            pnlKpiSoPhongDat.BackColor = Color.FromArgb(128, 174, 120);
            pnlKpiSoPhongDat.Controls.Add(tlpKpiSoPhongDatText);
            pnlKpiSoPhongDat.Controls.Add(picDatPhong);
            pnlKpiSoPhongDat.Cursor = Cursors.Hand;
            pnlKpiSoPhongDat.Dock = DockStyle.Fill;
            pnlKpiSoPhongDat.Margin = new Padding(8, 0, 0, 0);
            pnlKpiSoPhongDat.Name = "pnlKpiSoPhongDat";
            pnlKpiSoPhongDat.Padding = new Padding(16, 10, 14, 10);
            pnlKpiSoPhongDat.TabIndex = 2;

            //
            // picDatPhong
            //
            picDatPhong.BackColor = Color.Transparent;
            picDatPhong.Dock = DockStyle.Left;
            picDatPhong.Name = "picDatPhong";
            picDatPhong.Size = new Size(72, 82);
            picDatPhong.SizeMode = PictureBoxSizeMode.Zoom;
            picDatPhong.TabStop = false;

            //
            // tlpKpiSoPhongDatText
            //
            tlpKpiSoPhongDatText.BackColor = Color.Transparent;
            tlpKpiSoPhongDatText.ColumnCount = 1;
            tlpKpiSoPhongDatText.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpKpiSoPhongDatText.Controls.Add(lblTieuDeSoPhongDat, 0, 0);
            tlpKpiSoPhongDatText.Controls.Add(lblGiaTriSoPhongDat, 0, 1);
            tlpKpiSoPhongDatText.Dock = DockStyle.Fill;
            tlpKpiSoPhongDatText.Name = "tlpKpiSoPhongDatText";
            tlpKpiSoPhongDatText.RowCount = 2;
            tlpKpiSoPhongDatText.RowStyles.Add(new RowStyle(SizeType.Percent, 46F));
            tlpKpiSoPhongDatText.RowStyles.Add(new RowStyle(SizeType.Percent, 54F));

            //
            // lblTieuDeSoPhongDat
            //
            lblTieuDeSoPhongDat.BackColor = Color.Transparent;
            lblTieuDeSoPhongDat.Dock = DockStyle.Fill;
            lblTieuDeSoPhongDat.Font = new Font("Segoe UI", 11.5F, FontStyle.Regular);
            lblTieuDeSoPhongDat.ForeColor = Color.FromArgb(24, 28, 34);
            lblTieuDeSoPhongDat.Name = "lblTieuDeSoPhongDat";
            lblTieuDeSoPhongDat.Text = "Số phòng đặt";
            lblTieuDeSoPhongDat.TextAlign = ContentAlignment.BottomCenter;

            //
            // lblGiaTriSoPhongDat
            //
            lblGiaTriSoPhongDat.AutoEllipsis = true;
            lblGiaTriSoPhongDat.BackColor = Color.Transparent;
            lblGiaTriSoPhongDat.Dock = DockStyle.Fill;
            lblGiaTriSoPhongDat.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblGiaTriSoPhongDat.ForeColor = Color.FromArgb(18, 22, 28);
            lblGiaTriSoPhongDat.Name = "lblGiaTriSoPhongDat";
            lblGiaTriSoPhongDat.Text = "0";
            lblGiaTriSoPhongDat.TextAlign = ContentAlignment.TopCenter;

            //
            // tlpNoiDungChinh
            //
            tlpNoiDungChinh.BackColor = Color.Transparent;
            tlpNoiDungChinh.ColumnCount = 2;
            tlpNoiDungChinh.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 41.5F));
            tlpNoiDungChinh.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 58.5F));
            tlpNoiDungChinh.Controls.Add(tlpCotTrai, 0, 0);
            tlpNoiDungChinh.Controls.Add(tlpCotPhai, 1, 0);
            tlpNoiDungChinh.Dock = DockStyle.Fill;
            tlpNoiDungChinh.Name = "tlpNoiDungChinh";
            tlpNoiDungChinh.RowCount = 1;
            tlpNoiDungChinh.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpNoiDungChinh.TabIndex = 2;

            //
            // tlpCotTrai
            //
            tlpCotTrai.BackColor = Color.Transparent;
            tlpCotTrai.ColumnCount = 1;
            tlpCotTrai.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpCotTrai.Controls.Add(pnlTopLoaiPhongDoanhThu, 0, 0);
            tlpCotTrai.Controls.Add(pnlTopLoaiPhongDat, 0, 1);
            tlpCotTrai.Controls.Add(pnlTopDichVu, 0, 2);
            tlpCotTrai.Controls.Add(pnlBieuDoDichVu, 0, 3);
            tlpCotTrai.Dock = DockStyle.Fill;
            tlpCotTrai.Margin = new Padding(0, 0, 8, 0);
            tlpCotTrai.Name = "tlpCotTrai";
            tlpCotTrai.RowCount = 4;
            tlpCotTrai.RowStyles.Add(new RowStyle(SizeType.Absolute, 82F));
            tlpCotTrai.RowStyles.Add(new RowStyle(SizeType.Absolute, 82F));
            tlpCotTrai.RowStyles.Add(new RowStyle(SizeType.Absolute, 84F));
            tlpCotTrai.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            //
            // pnlTopLoaiPhongDoanhThu
            //
            pnlTopLoaiPhongDoanhThu.BackColor = Color.FromArgb(216, 195, 210);
            pnlTopLoaiPhongDoanhThu.Controls.Add(tlpTop1PhongDoanhThuText);
            pnlTopLoaiPhongDoanhThu.Controls.Add(picTop1PhongDoanhThu);
            pnlTopLoaiPhongDoanhThu.Cursor = Cursors.Hand;
            pnlTopLoaiPhongDoanhThu.Dock = DockStyle.Fill;
            pnlTopLoaiPhongDoanhThu.Margin = new Padding(0, 0, 0, 8);
            pnlTopLoaiPhongDoanhThu.Name = "pnlTopLoaiPhongDoanhThu";
            pnlTopLoaiPhongDoanhThu.Padding = new Padding(14, 8, 12, 8);

            //
            // picTop1PhongDoanhThu
            //
            picTop1PhongDoanhThu.BackColor = Color.Transparent;
            picTop1PhongDoanhThu.Dock = DockStyle.Left;
            picTop1PhongDoanhThu.Name = "picTop1PhongDoanhThu";
            picTop1PhongDoanhThu.Size = new Size(46, 56);
            picTop1PhongDoanhThu.SizeMode = PictureBoxSizeMode.Zoom;
            picTop1PhongDoanhThu.TabStop = false;

            //
            // tlpTop1PhongDoanhThuText
            //
            tlpTop1PhongDoanhThuText.BackColor = Color.Transparent;
            tlpTop1PhongDoanhThuText.ColumnCount = 1;
            tlpTop1PhongDoanhThuText.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpTop1PhongDoanhThuText.Controls.Add(lblTieuDeTopPhongDoanhThu, 0, 0);
            tlpTop1PhongDoanhThuText.Controls.Add(lblGiaTriTopPhongDoanhThu, 0, 1);
            tlpTop1PhongDoanhThuText.Dock = DockStyle.Fill;
            tlpTop1PhongDoanhThuText.Name = "tlpTop1PhongDoanhThuText";
            tlpTop1PhongDoanhThuText.RowCount = 2;
            tlpTop1PhongDoanhThuText.RowStyles.Add(new RowStyle(SizeType.Percent, 45F));
            tlpTop1PhongDoanhThuText.RowStyles.Add(new RowStyle(SizeType.Percent, 55F));

            //
            // lblTieuDeTopPhongDoanhThu
            //
            lblTieuDeTopPhongDoanhThu.BackColor = Color.Transparent;
            lblTieuDeTopPhongDoanhThu.Dock = DockStyle.Fill;
            lblTieuDeTopPhongDoanhThu.Font = new Font("Segoe UI", 10.5F, FontStyle.Regular);
            lblTieuDeTopPhongDoanhThu.ForeColor = Color.FromArgb(72, 76, 84);
            lblTieuDeTopPhongDoanhThu.Name = "lblTieuDeTopPhongDoanhThu";
            lblTieuDeTopPhongDoanhThu.Text = "Loại phòng doanh thu cao nhất";
            lblTieuDeTopPhongDoanhThu.TextAlign = ContentAlignment.BottomCenter;

            //
            // lblGiaTriTopPhongDoanhThu
            //
            lblGiaTriTopPhongDoanhThu.AutoEllipsis = true;
            lblGiaTriTopPhongDoanhThu.BackColor = Color.Transparent;
            lblGiaTriTopPhongDoanhThu.Dock = DockStyle.Fill;
            lblGiaTriTopPhongDoanhThu.Font = new Font("Segoe UI", 12.5F, FontStyle.Bold);
            lblGiaTriTopPhongDoanhThu.ForeColor = Color.FromArgb(26, 48, 148);
            lblGiaTriTopPhongDoanhThu.Name = "lblGiaTriTopPhongDoanhThu";
            lblGiaTriTopPhongDoanhThu.Text = "Chưa có dữ liệu";
            lblGiaTriTopPhongDoanhThu.TextAlign = ContentAlignment.TopCenter;

            //
            // pnlTopLoaiPhongDat
            //
            pnlTopLoaiPhongDat.BackColor = Color.FromArgb(216, 195, 210);
            pnlTopLoaiPhongDat.Controls.Add(tlpTop1PhongDatText);
            pnlTopLoaiPhongDat.Controls.Add(picTop1PhongDat);
            pnlTopLoaiPhongDat.Cursor = Cursors.Hand;
            pnlTopLoaiPhongDat.Dock = DockStyle.Fill;
            pnlTopLoaiPhongDat.Margin = new Padding(0, 0, 0, 8);
            pnlTopLoaiPhongDat.Name = "pnlTopLoaiPhongDat";
            pnlTopLoaiPhongDat.Padding = new Padding(14, 8, 12, 8);

            //
            // picTop1PhongDat
            //
            picTop1PhongDat.BackColor = Color.Transparent;
            picTop1PhongDat.Dock = DockStyle.Left;
            picTop1PhongDat.Name = "picTop1PhongDat";
            picTop1PhongDat.Size = new Size(46, 56);
            picTop1PhongDat.SizeMode = PictureBoxSizeMode.Zoom;
            picTop1PhongDat.TabStop = false;

            //
            // tlpTop1PhongDatText
            //
            tlpTop1PhongDatText.BackColor = Color.Transparent;
            tlpTop1PhongDatText.ColumnCount = 1;
            tlpTop1PhongDatText.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpTop1PhongDatText.Controls.Add(lblTieuDeTopPhongDat, 0, 0);
            tlpTop1PhongDatText.Controls.Add(lblGiaTriTopPhongDat, 0, 1);
            tlpTop1PhongDatText.Dock = DockStyle.Fill;
            tlpTop1PhongDatText.Name = "tlpTop1PhongDatText";
            tlpTop1PhongDatText.RowCount = 2;
            tlpTop1PhongDatText.RowStyles.Add(new RowStyle(SizeType.Percent, 45F));
            tlpTop1PhongDatText.RowStyles.Add(new RowStyle(SizeType.Percent, 55F));

            //
            // lblTieuDeTopPhongDat
            //
            lblTieuDeTopPhongDat.BackColor = Color.Transparent;
            lblTieuDeTopPhongDat.Dock = DockStyle.Fill;
            lblTieuDeTopPhongDat.Font = new Font("Segoe UI", 10.5F, FontStyle.Regular);
            lblTieuDeTopPhongDat.ForeColor = Color.FromArgb(72, 76, 84);
            lblTieuDeTopPhongDat.Name = "lblTieuDeTopPhongDat";
            lblTieuDeTopPhongDat.Text = "Loại phòng được đặt nhiều nhất";
            lblTieuDeTopPhongDat.TextAlign = ContentAlignment.BottomCenter;

            //
            // lblGiaTriTopPhongDat
            //
            lblGiaTriTopPhongDat.AutoEllipsis = true;
            lblGiaTriTopPhongDat.BackColor = Color.Transparent;
            lblGiaTriTopPhongDat.Dock = DockStyle.Fill;
            lblGiaTriTopPhongDat.Font = new Font("Segoe UI", 12.5F, FontStyle.Bold);
            lblGiaTriTopPhongDat.ForeColor = Color.FromArgb(26, 48, 148);
            lblGiaTriTopPhongDat.Name = "lblGiaTriTopPhongDat";
            lblGiaTriTopPhongDat.Text = "Chưa có dữ liệu";
            lblGiaTriTopPhongDat.TextAlign = ContentAlignment.TopCenter;

            //
            // pnlTopDichVu
            //
            pnlTopDichVu.BackColor = Color.FromArgb(216, 195, 210);
            pnlTopDichVu.Controls.Add(tlpTop1DichVuText);
            pnlTopDichVu.Controls.Add(picTop1DichVu);
            pnlTopDichVu.Cursor = Cursors.Hand;
            pnlTopDichVu.Dock = DockStyle.Fill;
            pnlTopDichVu.Margin = new Padding(0, 0, 0, 10);
            pnlTopDichVu.Name = "pnlTopDichVu";
            pnlTopDichVu.Padding = new Padding(14, 8, 12, 8);

            //
            // picTop1DichVu
            //
            picTop1DichVu.BackColor = Color.Transparent;
            picTop1DichVu.Dock = DockStyle.Left;
            picTop1DichVu.Name = "picTop1DichVu";
            picTop1DichVu.Size = new Size(46, 56);
            picTop1DichVu.SizeMode = PictureBoxSizeMode.Zoom;
            picTop1DichVu.TabStop = false;

            //
            // tlpTop1DichVuText
            //
            tlpTop1DichVuText.BackColor = Color.Transparent;
            tlpTop1DichVuText.ColumnCount = 1;
            tlpTop1DichVuText.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpTop1DichVuText.Controls.Add(lblTieuDeTopDichVu, 0, 0);
            tlpTop1DichVuText.Controls.Add(lblGiaTriTopDichVu, 0, 1);
            tlpTop1DichVuText.Dock = DockStyle.Fill;
            tlpTop1DichVuText.Name = "tlpTop1DichVuText";
            tlpTop1DichVuText.RowCount = 2;
            tlpTop1DichVuText.RowStyles.Add(new RowStyle(SizeType.Percent, 45F));
            tlpTop1DichVuText.RowStyles.Add(new RowStyle(SizeType.Percent, 55F));

            //
            // lblTieuDeTopDichVu
            //
            lblTieuDeTopDichVu.BackColor = Color.Transparent;
            lblTieuDeTopDichVu.Dock = DockStyle.Fill;
            lblTieuDeTopDichVu.Font = new Font("Segoe UI", 10.5F, FontStyle.Regular);
            lblTieuDeTopDichVu.ForeColor = Color.FromArgb(72, 76, 84);
            lblTieuDeTopDichVu.Name = "lblTieuDeTopDichVu";
            lblTieuDeTopDichVu.Text = "Dịch vụ doanh thu cao nhất";
            lblTieuDeTopDichVu.TextAlign = ContentAlignment.BottomCenter;

            //
            // lblGiaTriTopDichVu
            //
            lblGiaTriTopDichVu.AutoEllipsis = true;
            lblGiaTriTopDichVu.BackColor = Color.Transparent;
            lblGiaTriTopDichVu.Dock = DockStyle.Fill;
            lblGiaTriTopDichVu.Font = new Font("Segoe UI", 12.5F, FontStyle.Bold);
            lblGiaTriTopDichVu.ForeColor = Color.FromArgb(26, 48, 148);
            lblGiaTriTopDichVu.Name = "lblGiaTriTopDichVu";
            lblGiaTriTopDichVu.Text = "Chưa có dữ liệu";
            lblGiaTriTopDichVu.TextAlign = ContentAlignment.TopCenter;

            //
            // pnlBieuDoDichVu
            //
            pnlBieuDoDichVu.BackColor = Color.FromArgb(216, 195, 210);
            pnlBieuDoDichVu.Controls.Add(pnlHostChartDichVu);
            pnlBieuDoDichVu.Controls.Add(lblTieuDeBieuDoDichVu);
            pnlBieuDoDichVu.Dock = DockStyle.Fill;
            pnlBieuDoDichVu.Margin = new Padding(0);
            pnlBieuDoDichVu.Name = "pnlBieuDoDichVu";
            pnlBieuDoDichVu.Padding = new Padding(12, 6, 12, 12);

            //
            // lblTieuDeBieuDoDichVu
            //
            lblTieuDeBieuDoDichVu.BackColor = Color.Transparent;
            lblTieuDeBieuDoDichVu.Dock = DockStyle.Top;
            lblTieuDeBieuDoDichVu.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTieuDeBieuDoDichVu.ForeColor = Color.FromArgb(18, 60, 122);
            lblTieuDeBieuDoDichVu.Height = 36;
            lblTieuDeBieuDoDichVu.Name = "lblTieuDeBieuDoDichVu";
            lblTieuDeBieuDoDichVu.Text = "Các dịch vụ được sử dụng";
            lblTieuDeBieuDoDichVu.TextAlign = ContentAlignment.MiddleCenter;

            //
            // pnlHostChartDichVu
            //
            pnlHostChartDichVu.BackColor = Color.White;
            pnlHostChartDichVu.Controls.Add(lblEmptyDichVu);
            pnlHostChartDichVu.Controls.Add(chartDichVu);
            pnlHostChartDichVu.Controls.Add(lblGhiChuPie);
            pnlHostChartDichVu.Dock = DockStyle.Fill;
            pnlHostChartDichVu.Name = "pnlHostChartDichVu";

            //
            // chartDichVu
            //
            chartDichVu.BackColor = Color.White;
            chartDichVu.Dock = DockStyle.Fill;
            chartDichVu.Name = "chartDichVu";
            chartDichVu.TabIndex = 0;

            //
            // lblEmptyDichVu
            //
            lblEmptyDichVu.BackColor = Color.White;
            lblEmptyDichVu.Dock = DockStyle.Fill;
            lblEmptyDichVu.Font = new Font("Segoe UI", 10.5F, FontStyle.Italic);
            lblEmptyDichVu.ForeColor = Color.FromArgb(120, 128, 142);
            lblEmptyDichVu.Name = "lblEmptyDichVu";
            lblEmptyDichVu.Text = "Không có dịch vụ được sử dụng trong khoảng thời gian này";
            lblEmptyDichVu.TextAlign = ContentAlignment.MiddleCenter;
            lblEmptyDichVu.Visible = false;

            //
            // lblGhiChuPie
            //
            lblGhiChuPie.AutoEllipsis = true;
            lblGhiChuPie.BackColor = Color.White;
            lblGhiChuPie.Cursor = Cursors.Hand;
            lblGhiChuPie.Dock = DockStyle.Bottom;
            lblGhiChuPie.Font = new Font("Segoe UI", 8.5F, FontStyle.Italic);
            lblGhiChuPie.ForeColor = Color.FromArgb(90, 102, 122);
            lblGhiChuPie.Height = 22;
            lblGhiChuPie.Name = "lblGhiChuPie";
            lblGhiChuPie.Text = "Nhấn vào từng phần để nổi bật dịch vụ — Nhấn đúp để xem chi tiết";
            lblGhiChuPie.TextAlign = ContentAlignment.MiddleCenter;

            //
            // tlpCotPhai
            //
            tlpCotPhai.BackColor = Color.Transparent;
            tlpCotPhai.ColumnCount = 1;
            tlpCotPhai.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpCotPhai.Controls.Add(pnlBieuDoDoanhThuPhong, 0, 0);
            tlpCotPhai.Controls.Add(pnlBieuDoSoPhongDat, 0, 1);
            tlpCotPhai.Dock = DockStyle.Fill;
            tlpCotPhai.Margin = new Padding(8, 0, 0, 0);
            tlpCotPhai.Name = "tlpCotPhai";
            tlpCotPhai.RowCount = 2;
            tlpCotPhai.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpCotPhai.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));

            //
            // pnlBieuDoDoanhThuPhong
            //
            pnlBieuDoDoanhThuPhong.BackColor = Color.FromArgb(216, 195, 210);
            pnlBieuDoDoanhThuPhong.Controls.Add(pnlHostChartDoanhThu);
            pnlBieuDoDoanhThuPhong.Controls.Add(lblTieuDeBieuDoDoanhThu);
            pnlBieuDoDoanhThuPhong.Dock = DockStyle.Fill;
            pnlBieuDoDoanhThuPhong.Margin = new Padding(0, 0, 0, 6);
            pnlBieuDoDoanhThuPhong.Name = "pnlBieuDoDoanhThuPhong";
            pnlBieuDoDoanhThuPhong.Padding = new Padding(12, 6, 12, 12);

            //
            // lblTieuDeBieuDoDoanhThu
            //
            lblTieuDeBieuDoDoanhThu.BackColor = Color.Transparent;
            lblTieuDeBieuDoDoanhThu.Dock = DockStyle.Top;
            lblTieuDeBieuDoDoanhThu.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTieuDeBieuDoDoanhThu.ForeColor = Color.FromArgb(18, 60, 122);
            lblTieuDeBieuDoDoanhThu.Height = 36;
            lblTieuDeBieuDoDoanhThu.Name = "lblTieuDeBieuDoDoanhThu";
            lblTieuDeBieuDoDoanhThu.Text = "Doanh thu thuê phòng";
            lblTieuDeBieuDoDoanhThu.TextAlign = ContentAlignment.MiddleCenter;

            //
            // pnlHostChartDoanhThu
            //
            pnlHostChartDoanhThu.BackColor = Color.White;
            pnlHostChartDoanhThu.Controls.Add(chartDoanhThuPhong);
            pnlHostChartDoanhThu.Dock = DockStyle.Fill;
            pnlHostChartDoanhThu.Name = "pnlHostChartDoanhThu";

            //
            // chartDoanhThuPhong
            //
            chartDoanhThuPhong.BackColor = Color.White;
            chartDoanhThuPhong.Dock = DockStyle.Fill;
            chartDoanhThuPhong.Name = "chartDoanhThuPhong";
            chartDoanhThuPhong.TabIndex = 0;

            //
            // pnlBieuDoSoPhongDat
            //
            pnlBieuDoSoPhongDat.BackColor = Color.FromArgb(216, 195, 210);
            pnlBieuDoSoPhongDat.Controls.Add(pnlHostChartSoPhongDat);
            pnlBieuDoSoPhongDat.Controls.Add(lblTieuDeBieuDoSoPhongDat);
            pnlBieuDoSoPhongDat.Dock = DockStyle.Fill;
            pnlBieuDoSoPhongDat.Margin = new Padding(0, 6, 0, 0);
            pnlBieuDoSoPhongDat.Name = "pnlBieuDoSoPhongDat";
            pnlBieuDoSoPhongDat.Padding = new Padding(12, 6, 12, 12);

            //
            // lblTieuDeBieuDoSoPhongDat
            //
            lblTieuDeBieuDoSoPhongDat.BackColor = Color.Transparent;
            lblTieuDeBieuDoSoPhongDat.Dock = DockStyle.Top;
            lblTieuDeBieuDoSoPhongDat.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTieuDeBieuDoSoPhongDat.ForeColor = Color.FromArgb(18, 60, 122);
            lblTieuDeBieuDoSoPhongDat.Height = 36;
            lblTieuDeBieuDoSoPhongDat.Name = "lblTieuDeBieuDoSoPhongDat";
            lblTieuDeBieuDoSoPhongDat.Text = "Số phòng được đặt";
            lblTieuDeBieuDoSoPhongDat.TextAlign = ContentAlignment.MiddleCenter;

            //
            // pnlHostChartSoPhongDat
            //
            pnlHostChartSoPhongDat.BackColor = Color.White;
            pnlHostChartSoPhongDat.Controls.Add(chartSoPhongDat);
            pnlHostChartSoPhongDat.Dock = DockStyle.Fill;
            pnlHostChartSoPhongDat.Name = "pnlHostChartSoPhongDat";

            //
            // chartSoPhongDat
            //
            chartSoPhongDat.BackColor = Color.White;
            chartSoPhongDat.Dock = DockStyle.Fill;
            chartSoPhongDat.Name = "chartSoPhongDat";
            chartSoPhongDat.TabIndex = 0;

            //
            // FormThongKe
            //
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.FromArgb(240, 244, 249);
            ClientSize = new Size(1380, 880);
            Controls.Add(pnlRootCanvas);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormThongKe";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Báo cáo thống kê kinh doanh";
            Load += FormThongKe_Load;

            pnlRootCanvas.ResumeLayout(false);
            tlpLayout.ResumeLayout(false);
            pnlFilter.ResumeLayout(false);
            pnlFilterLeft.ResumeLayout(false);
            pnlFilterLeft.PerformLayout();
            tlpKpiCards.ResumeLayout(false);
            pnlKpiThuePhong.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picThuePhong).EndInit();
            tlpKpiThuePhongText.ResumeLayout(false);
            pnlKpiDichVu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picDichVu).EndInit();
            tlpKpiDichVuText.ResumeLayout(false);
            pnlKpiSoPhongDat.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picDatPhong).EndInit();
            tlpKpiSoPhongDatText.ResumeLayout(false);
            tlpNoiDungChinh.ResumeLayout(false);
            tlpCotTrai.ResumeLayout(false);
            pnlTopLoaiPhongDoanhThu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picTop1PhongDoanhThu).EndInit();
            tlpTop1PhongDoanhThuText.ResumeLayout(false);
            pnlTopLoaiPhongDat.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picTop1PhongDat).EndInit();
            tlpTop1PhongDatText.ResumeLayout(false);
            pnlTopDichVu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picTop1DichVu).EndInit();
            tlpTop1DichVuText.ResumeLayout(false);
            pnlBieuDoDichVu.ResumeLayout(false);
            pnlHostChartDichVu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)chartDichVu).EndInit();
            tlpCotPhai.ResumeLayout(false);
            pnlBieuDoDoanhThuPhong.ResumeLayout(false);
            pnlHostChartDoanhThu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)chartDoanhThuPhong).EndInit();
            pnlBieuDoSoPhongDat.ResumeLayout(false);
            pnlHostChartSoPhongDat.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)chartSoPhongDat).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ToolTip toolTipDashboard = null!;
        private Panel pnlRootCanvas = null!;
        private TableLayoutPanel tlpLayout = null!;
        private Panel pnlFilter = null!;
        private FlowLayoutPanel pnlFilterLeft = null!;
        private Label lblTuNgay = null!;
        private DateTimePicker dtpTuNgay = null!;
        private Label lblDenNgay = null!;
        private DateTimePicker dtpDenNgay = null!;
        private Button btnXemThongKe = null!;
        private Button btnXuatBaoCao = null!;
        private TableLayoutPanel tlpKpiCards = null!;
        private Panel pnlKpiThuePhong = null!;
        private PictureBox picThuePhong = null!;
        private TableLayoutPanel tlpKpiThuePhongText = null!;
        private Label lblTieuDeDoanhThuPhong = null!;
        private Label lblGiaTriDoanhThuPhong = null!;
        private Panel pnlKpiDichVu = null!;
        private PictureBox picDichVu = null!;
        private TableLayoutPanel tlpKpiDichVuText = null!;
        private Label lblTieuDeDoanhThuDichVu = null!;
        private Label lblGiaTriDoanhThuDichVu = null!;
        private Panel pnlKpiSoPhongDat = null!;
        private PictureBox picDatPhong = null!;
        private TableLayoutPanel tlpKpiSoPhongDatText = null!;
        private Label lblTieuDeSoPhongDat = null!;
        private Label lblGiaTriSoPhongDat = null!;
        private TableLayoutPanel tlpNoiDungChinh = null!;
        private TableLayoutPanel tlpCotTrai = null!;
        private Panel pnlTopLoaiPhongDoanhThu = null!;
        private PictureBox picTop1PhongDoanhThu = null!;
        private TableLayoutPanel tlpTop1PhongDoanhThuText = null!;
        private Label lblTieuDeTopPhongDoanhThu = null!;
        private Label lblGiaTriTopPhongDoanhThu = null!;
        private Panel pnlTopLoaiPhongDat = null!;
        private PictureBox picTop1PhongDat = null!;
        private TableLayoutPanel tlpTop1PhongDatText = null!;
        private Label lblTieuDeTopPhongDat = null!;
        private Label lblGiaTriTopPhongDat = null!;
        private Panel pnlTopDichVu = null!;
        private PictureBox picTop1DichVu = null!;
        private TableLayoutPanel tlpTop1DichVuText = null!;
        private Label lblTieuDeTopDichVu = null!;
        private Label lblGiaTriTopDichVu = null!;
        private Panel pnlBieuDoDichVu = null!;
        private Label lblTieuDeBieuDoDichVu = null!;
        private Panel pnlHostChartDichVu = null!;
        private FastReport.DataVisualization.Charting.Chart chartDichVu = null!;
        private Label lblEmptyDichVu = null!;
        private Label lblGhiChuPie = null!;
        private TableLayoutPanel tlpCotPhai = null!;
        private Panel pnlBieuDoDoanhThuPhong = null!;
        private Label lblTieuDeBieuDoDoanhThu = null!;
        private Panel pnlHostChartDoanhThu = null!;
        private FastReport.DataVisualization.Charting.Chart chartDoanhThuPhong = null!;
        private Panel pnlBieuDoSoPhongDat = null!;
        private Label lblTieuDeBieuDoSoPhongDat = null!;
        private Panel pnlHostChartSoPhongDat = null!;
        private FastReport.DataVisualization.Charting.Chart chartSoPhongDat = null!;
    }
}
