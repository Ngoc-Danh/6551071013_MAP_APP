using HotelManagement.DangNhap;

namespace HotelManagement
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            HienThiThongTinNguoiDung();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn đăng xuất?", "Đăng xuất",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            this.Hide();
            using (var formLogin = new FormDangNhap())
            {
                if (formLogin.ShowDialog() == DialogResult.OK)
                {
                    HienThiThongTinNguoiDung();
                    HienThiTrangChu();
                    this.Show();
                }
                else
                {
                    this.Close();
                }
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Form formCon = new ThongKe.FormThongKe();
            LoadFormCon(formCon);
        }

        private void btnTrangChu_Click(object sender, EventArgs e)
        {
            HienThiTrangChu();
            // Bấm "Trang chủ" thì quay lại màn hình UserControl FormTrangChu
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form formCon = new TaiKhoan.FormDanhSachTaiKhoan();
            formCon.TopLevel = false;
            formCon.FormBorderStyle = FormBorderStyle.None;
            formCon.Dock = DockStyle.Fill;
            XoaNoiDungPanelMain();
            panelMain.Controls.Add(formCon);
            formCon.Show();
        }


        private void button4_Click(object sender, EventArgs e)
        {
            // Loại phòng (Mục 8)
            Form formCon = new LoaiPhong.FormDanhSachLoaiPhong();
            LoadFormCon(formCon);
        }

        private void button7_Click(object sender, EventArgs e)
        {

            Form formCon = new NhanVien.FormDanhSachNhanVien();
            formCon.TopLevel = false;
            formCon.FormBorderStyle = FormBorderStyle.None;
            formCon.Dock = DockStyle.Fill;
            XoaNoiDungPanelMain();
            panelMain.Controls.Add(formCon);
            formCon.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form formCon = new KhachHang.FormDanhSachKhachHang();
            formCon.TopLevel = false;
            formCon.FormBorderStyle = FormBorderStyle.None;
            formCon.Dock = DockStyle.Fill;
            XoaNoiDungPanelMain();
            panelMain.Controls. Add ( formCon);
            formCon .Show();
        }

        private void btnQuanLyPhong_Click(object sender, EventArgs e)
        {
            // Phòng (Mục 7)
            Form formCon = new Phong.FormDanhSachPhong();
            LoadFormCon(formCon);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Form formCon = new TienNghi.FormDanhSachTienNghi();
            formCon.TopLevel = false;
            formCon.FormBorderStyle = FormBorderStyle.None;
            formCon.Dock = DockStyle.Fill;
            XoaNoiDungPanelMain();
            panelMain.Controls.Add(formCon);
            formCon.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Form formCon = new DichVu.FormDanhSachDichVu();
            formCon.TopLevel = false;
            formCon.FormBorderStyle = FormBorderStyle.None;
            formCon.Dock = DockStyle.Fill;
            XoaNoiDungPanelMain();   // hàm có trong bản FormMain mình gửi trước; nếu chưa có, dùng panelMain.Controls.Clear();
            panelMain.Controls.Add(formCon);
            formCon.Show();
        }

        private void btnSoDoPhong_Click(object sender, EventArgs e)
        {
            // Sơ đồ phòng (sẽ được mở rộng ở Mục 6)
            Form formCon = new SoDoPhong.FormSoDoPhong();
            LoadFormCon(formCon);
        }


        private void button9_Click(object sender, EventArgs e)
        {
            Form formCon = new PhieuThue.FormDanhSachPhieuThue();
            formCon.TopLevel = false;
            formCon.FormBorderStyle = FormBorderStyle.None;
            formCon.Dock = DockStyle.Fill;
            XoaNoiDungPanelMain();
            panelMain.Controls.Add(formCon);
            formCon.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Form formCon = new HoaDon.FormDanhSachHoaDon();
            formCon.TopLevel = false;
            formCon.FormBorderStyle = FormBorderStyle.None;
            formCon.Dock = DockStyle.Fill;
            XoaNoiDungPanelMain(); // hàm có trong bản FormMain mình gửi trước; nếu chưa có, dùng panelMain.Controls.Clear();
            panelMain.Controls.Add(formCon);
            formCon.Show();
        }


        private void FormMain_Load(object sender, EventArgs e)
        {
            HienThiTrangChu();
        }

        private void HienThiThongTinNguoiDung()
        {
            lblTenNguoiDung.Text = FormDangNhap.TenNV_DangNhap;
            lblTenNguoiDung.Left = (panel2.Width - lblTenNguoiDung.PreferredWidth) / 2;
        }

        private void XoaNoiDungPanelMain()
        {
            foreach (Control c in panelMain.Controls.Cast<Control>().ToList())
            {
                panelMain.Controls.Remove(c);
                c.Dispose();
            }
        }

        private void LoadUserControl(UserControl uc)
        {
            XoaNoiDungPanelMain();
            uc.Dock = DockStyle.Fill;
            panelMain.Controls.Add(uc);
            uc.BringToFront();
        }

        private void LoadFormCon(Form formCon)
        {
            XoaNoiDungPanelMain();
            formCon.TopLevel = false;
            formCon.FormBorderStyle = FormBorderStyle.None;
            formCon.Dock = DockStyle.Fill;
            panelMain.Controls.Add(formCon);
            formCon.Show();
        }

        private void HienThiTrangChu()
        {
            if (panelMain.Controls.Count == 1 && panelMain.Controls[0] is FormTrangChu)
                return;
            LoadUserControl(new FormTrangChu());
        }

        private void HienThiDangPhatTrien(string tenChucNang)
        {
            XoaNoiDungPanelMain();
            panelMain.Controls.Add(new Label
            {
                Dock = DockStyle.Fill,
                Text = tenChucNang + Environment.NewLine + "(chức năng đang được xây dựng)",
                Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Italic),
                ForeColor = Color.DarkCyan,
                TextAlign = ContentAlignment.MiddleCenter
            });
        }
    }
}