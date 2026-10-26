using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Models
{
    public partial class HotelManagementContext
    {
        // Đổi Server cho đúng máy của bạn
        private const string ConnectionString =
            "Server=localhost,1433;Database=HotelManagement;Trusted_Connection=True;TrustServerCertificate=True;";

        // Constructor không tham số
        public HotelManagementContext()
        {
        }

        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConnectionString);
            }
        }
    }
}