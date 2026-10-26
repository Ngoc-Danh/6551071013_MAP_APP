using HotelManagement.DangNhap;
using System;
using System.Windows.Forms;

namespace HotelManagement
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            using (FormDangNhap formDangNhap = new FormDangNhap())
            {
                if (formDangNhap.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
            }

            Application.Run(new FormMain());
        }
    }
}