
namespace HotelManagement.TienNghi
{
    partial class FormDanhSachTienNghi
    {
        private System.ComponentModel.IContainer components = null;

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
            btnThemMoi = new System.Windows.Forms.Button();
            dtgDanhSachTienNghi = new System.Windows.Forms.DataGridView();
            btnXuatExcel = new System.Windows.Forms.Button();
            txtTimKiem = new System.Windows.Forms.TextBox();
            pictureBox1 = new System.Windows.Forms.PictureBox();

            ((System.ComponentModel.ISupportInitialize)dtgDanhSachTienNghi).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();

            // btnThemMoi
            btnThemMoi.BackColor = System.Drawing.Color.LightPink;
            btnThemMoi.Font = new System.Drawing.Font(
                "Microsoft Sans Serif", 12F,
                System.Drawing.FontStyle.Bold,
                System.Drawing.GraphicsUnit.Point, 0);

            btnThemMoi.Location = new System.Drawing.Point(841, 8);
            btnThemMoi.Name = "btnThemMoi";
            btnThemMoi.Size = new System.Drawing.Size(167, 37);
            btnThemMoi.TabIndex = 15;
            btnThemMoi.Text = "Thêm mới";
            btnThemMoi.UseVisualStyleBackColor = false;
            btnThemMoi.Click += btnThemMoi_Click;

            // dtgDanhSachTienNghi
            dtgDanhSachTienNghi.ColumnHeadersHeightSizeMode =
                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            dtgDanhSachTienNghi.Location = new System.Drawing.Point(3, 62);
            dtgDanhSachTienNghi.Name = "dtgDanhSachTienNghi";
            dtgDanhSachTienNghi.RowHeadersWidth = 51;
            dtgDanhSachTienNghi.RowTemplate.Height = 24;
            dtgDanhSachTienNghi.Size = new System.Drawing.Size(1035, 615);
            dtgDanhSachTienNghi.TabIndex = 14;
            dtgDanhSachTienNghi.CellClick += dtgDanhSachTienNghi_CellClick;

            // btnXuatExcel
            btnXuatExcel.BackColor = System.Drawing.Color.DarkTurquoise;
            btnXuatExcel.Font = new System.Drawing.Font(
                "Microsoft Sans Serif", 12F,
                System.Drawing.FontStyle.Bold,
                System.Drawing.GraphicsUnit.Point, 0);

            btnXuatExcel.Location = new System.Drawing.Point(640, 8);
            btnXuatExcel.Name = "btnXuatExcel";
            btnXuatExcel.Size = new System.Drawing.Size(167, 37);
            btnXuatExcel.TabIndex = 13;
            btnXuatExcel.Text = "Xuất file Excel";
            btnXuatExcel.UseVisualStyleBackColor = false;
            btnXuatExcel.Click += btnXuatExcel_Click;

            // txtTimKiem
            txtTimKiem.Font = new System.Drawing.Font(
                "Microsoft Sans Serif", 13F,
                System.Drawing.FontStyle.Regular,
                System.Drawing.GraphicsUnit.Point, 0);

            txtTimKiem.Location = new System.Drawing.Point(199, 13);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new System.Drawing.Size(187, 32);
            txtTimKiem.TabIndex = 11;
            txtTimKiem.TextChanged += txtTimKiem_TextChanged;

            // pictureBox1
            pictureBox1.Image = ResourceHelper.ToImage (global:: HotelManagement.Properties.Resources.search);

            pictureBox1.Location = new System.Drawing.Point(154, 8);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(39, 37);
            pictureBox1.TabIndex = 12;
            pictureBox1.TabStop = false;

            // FormDanhSachTienNghi
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;

            ClientSize = new System.Drawing.Size(1043, 685);

            Controls.Add(btnThemMoi);
            Controls.Add(dtgDanhSachTienNghi);
            Controls.Add(btnXuatExcel);
            Controls.Add(pictureBox1);
            Controls.Add(txtTimKiem);

            Name = "FormDanhSachTienNghi";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Quản lý thông tin tiện nghi";

            Load += FormDanhSachTienNghi_Load;

            ((System.ComponentModel.ISupportInitialize)dtgDanhSachTienNghi).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();

            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button btnThemMoi;
        private System.Windows.Forms.DataGridView dtgDanhSachTienNghi;
        private System.Windows.Forms.Button btnXuatExcel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtTimKiem;
    }
}
