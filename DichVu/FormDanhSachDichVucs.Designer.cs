
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;


namespace HotelManagement.DichVu
{
    partial class FormDanhSachDichVu
    {
        private IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            btnThemMoi = new Button();
            dtgDanhSachDichVu = new DataGridView();
            btnXuatExcel = new Button();
            txtTimKiem = new TextBox();
            pictureBox1 = new PictureBox();

            ((ISupportInitialize)dtgDanhSachDichVu).BeginInit();
            ((ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();

            // btnThemMoi
            btnThemMoi.BackColor = Color.LightPink;
            btnThemMoi.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnThemMoi.Location = new Point(673, 28);
            btnThemMoi.Margin = new Padding(3, 4, 3, 4);
            btnThemMoi.Name = "btnThemMoi";
            btnThemMoi.Size = new Size(167, 46);
            btnThemMoi.TabIndex = 15;
            btnThemMoi.Text = "Thêm mới";
            btnThemMoi.UseVisualStyleBackColor = false;
            btnThemMoi.Click += btnThemMoi_Click;

            // dtgDanhSachDichVu
            dtgDanhSachDichVu.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgDanhSachDichVu.Location = new Point(12, 90);
            dtgDanhSachDichVu.Margin = new Padding(3, 4, 3, 4);
            dtgDanhSachDichVu.Name = "dtgDanhSachDichVu";
            dtgDanhSachDichVu.RowHeadersWidth = 51;
            dtgDanhSachDichVu.RowTemplate.Height = 24;
            dtgDanhSachDichVu.Size = new Size(945, 679);
            dtgDanhSachDichVu.TabIndex = 14;
            dtgDanhSachDichVu.CellClick += dtgDanhSachDichVu_CellClick;

            // btnXuatExcel
            btnXuatExcel.BackColor = Color.DarkTurquoise;
            btnXuatExcel.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnXuatExcel.Location = new Point(475, 28);
            btnXuatExcel.Margin = new Padding(3, 4, 3, 4);
            btnXuatExcel.Name = "btnXuatExcel";
            btnXuatExcel.Size = new Size(167, 46);
            btnXuatExcel.TabIndex = 13;
            btnXuatExcel.Text = "Xuất file Excel";
            btnXuatExcel.UseVisualStyleBackColor = false;
            btnXuatExcel.Click += btnXuatExcel_Click;

            // txtTimKiem
            txtTimKiem.Font = new Font("Microsoft Sans Serif", 13F, FontStyle.Regular, GraphicsUnit.Point);
            txtTimKiem.Location = new Point(73, 34);
            txtTimKiem.Margin = new Padding(3, 4, 3, 4);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(187, 32);
            txtTimKiem.TabIndex = 11;
            txtTimKiem.TextChanged += txtTimKiem_TextChanged;

            // pictureBox1
            pictureBox1.Image = ResourceHelper.ToImage(Properties.Resources.search);
            pictureBox1.Location = new Point(28, 28);
            pictureBox1.Margin = new Padding(3, 4, 3, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(39, 46);
            pictureBox1.TabIndex = 12;
            pictureBox1.TabStop = false;

            // FormDanhSachDichVu
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(961, 784);

            Controls.Add(btnThemMoi);
            Controls.Add(dtgDanhSachDichVu);
            Controls.Add(btnXuatExcel);
            Controls.Add(pictureBox1);
            Controls.Add(txtTimKiem);

            Margin = new Padding(3, 4, 3, 4);
            Name = "FormDanhSachDichVu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý thông tin dịch vụ";

            ((ISupportInitialize)dtgDanhSachDichVu).EndInit();
            ((ISupportInitialize)pictureBox1).EndInit();

            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnThemMoi;
        private DataGridView dtgDanhSachDichVu;
        private Button btnXuatExcel;
        private PictureBox pictureBox1;
        private TextBox txtTimKiem;
    }
}
