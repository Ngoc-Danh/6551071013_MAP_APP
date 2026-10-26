namespace HotelManagement.LoaiPhong
{
    partial class FormDanhSachLoaiPhong
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            dtgDanhSachLoaiPhong = new DataGridView();
            btnXuatExcel = new Button();
            txtTimKiem = new TextBox();
            pictureBox1 = new PictureBox();
            btnThemMoi = new Button();
            ((System.ComponentModel.ISupportInitialize)dtgDanhSachLoaiPhong).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // dtgDanhSachLoaiPhong
            // 
            dtgDanhSachLoaiPhong.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgDanhSachLoaiPhong.Location = new Point(12, 66);
            dtgDanhSachLoaiPhong.Name = "dtgDanhSachLoaiPhong";
            dtgDanhSachLoaiPhong.RowHeadersWidth = 51;
            dtgDanhSachLoaiPhong.RowTemplate.Height = 24;
            dtgDanhSachLoaiPhong.Size = new Size(1015, 615);
            dtgDanhSachLoaiPhong.TabIndex = 9;
            dtgDanhSachLoaiPhong.CellClick += dtgDanhSachLoaiPhong_CellClick;
            // 
            // btnXuatExcel
            // 
            //btnXuatExcel.BackColor = Color.DarkTurquoise;
            //btnXuatExcel.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            //btnXuatExcel.Location = new Point(546, 12);
            //btnXuatExcel.Name = "btnXuatExcel";
            //btnXuatExcel.Size = new Size(167, 37);
            //btnXuatExcel.TabIndex = 7;
            //btnXuatExcel.Text = "Xuất file Excel";
            //btnXuatExcel.UseVisualStyleBackColor = false;
            //btnXuatExcel.Click += btnXuatExcel_Click;
            // 
            // txtTimKiem
            // 
            txtTimKiem.Font = new Font("Microsoft Sans Serif", 13F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTimKiem.Location = new Point(105, 17);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(187, 32);
            txtTimKiem.TabIndex = 5;
            txtTimKiem.TextChanged += txtTimKiem_TextChanged;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = ResourceHelper.ToImage(Properties.Resources.search);
            pictureBox1.Location = new Point(60, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(39, 37);
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // btnThemMoi
            // 
            btnThemMoi.BackColor = Color.LightPink;
            btnThemMoi.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnThemMoi.Location = new Point(747, 12);
            btnThemMoi.Name = "btnThemMoi";
            btnThemMoi.Size = new Size(167, 37);
            btnThemMoi.TabIndex = 10;
            btnThemMoi.Text = "Thêm mới";
            btnThemMoi.UseVisualStyleBackColor = false;
            btnThemMoi.Click += btnThemMoi_Click;
            // 
            // FormDanhSachLoaiPhong
            // 
            AutoScaleDimensions = new SizeF(8F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1039, 699);
            Controls.Add(btnThemMoi);
            Controls.Add(dtgDanhSachLoaiPhong);
            Controls.Add(btnXuatExcel);
            Controls.Add(pictureBox1);
            Controls.Add(txtTimKiem);
            Name = "FormDanhSachLoaiPhong";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Danh sách loại phòng";
            ((System.ComponentModel.ISupportInitialize)dtgDanhSachLoaiPhong).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView dtgDanhSachLoaiPhong;
        private System.Windows.Forms.Button btnXuatExcel;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnThemMoi;
    }
}