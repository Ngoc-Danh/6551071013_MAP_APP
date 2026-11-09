using HotelManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HotelManagement.ThongKe
{
    public sealed class DoanhThuLoaiPhongItem
    {
        public string TenLoaiPhong { get; init; } = "";
        public decimal DoanhThu { get; init; }
        public int SoLuotThanhToan { get; init; }
    }

    public sealed class SoLuongDatLoaiPhongItem
    {
        public string TenLoaiPhong { get; init; } = "";
        public int SoLuotDat { get; init; }
        public int SoLuotDangDat { get; init; }
        public int SoLuotDangThue { get; init; }
        public int SoLuotHoanTat { get; init; }
    }

    public sealed class DichVuSuDungItem
    {
        public string MaDichVu { get; init; } = "";
        public string TenDichVu { get; init; } = "";
        public decimal DonGia { get; init; }
        public int SoLuong { get; init; }
        public decimal DoanhThu { get; init; }
        public double TiLePhanTram { get; init; }
    }

    public sealed class ChiTietDichVuTheoPhongItem
    {
        public string MaCtdp { get; init; } = "";
        public string MaDv { get; init; } = "";
        public string TenDv { get; init; } = "";
        public int SoLuong { get; init; }
        public decimal DonGia { get; init; }
        public decimal ThanhTien { get; init; }
    }

    public sealed class ChiTietDatPhongThongKeItem
    {
        public string MaCtdp { get; init; } = "";
        public string MaPt { get; init; } = "";
        public string MaPhong { get; init; } = "";
        public string TenLoaiPhong { get; init; } = "";
        public string TenKhachHang { get; init; } = "";
        public DateTime CheckIn { get; init; }
        public DateTime CheckOut { get; init; }
        public string TrangThai { get; init; } = "";
        public bool DaThanhToan { get; init; }
        public decimal TienPhong { get; init; }
        public decimal TienDichVu { get; init; }
        public decimal TongTien => TienPhong + TienDichVu;
    }

    public sealed class ThongKeKetQua
    {
        public DateTime TuNgay { get; init; }
        public DateTime DenNgay { get; init; }
        public decimal DoanhThuThuePhong { get; init; }
        public decimal DoanhThuDichVu { get; init; }
        public decimal TongDoanhThu => DoanhThuThuePhong + DoanhThuDichVu;
        public int SoPhongDat { get; init; }
        public int SoPhongDaThanhToan { get; init; }
        public int TongSoLuongDichVu { get; init; }

        public string LoaiPhongDoanhThuCaoNhatHienThi { get; init; } = "Chưa có dữ liệu";
        public string? LoaiPhongDoanhThuCaoNhatTen { get; init; }

        public string LoaiPhongDatNhieuNhatHienThi { get; init; } = "Chưa có dữ liệu";
        public string? LoaiPhongDatNhieuNhatTen { get; init; }

        public string DichVuDoanhThuCaoNhatHienThi { get; init; } = "Chưa có dữ liệu";
        public string? DichVuDoanhThuCaoNhatMa { get; init; }

        public IReadOnlyList<DoanhThuLoaiPhongItem> DoanhThuTheoLoaiPhong { get; init; } = Array.Empty<DoanhThuLoaiPhongItem>();
        public IReadOnlyList<SoLuongDatLoaiPhongItem> SoLuongDatTheoLoaiPhong { get; init; } = Array.Empty<SoLuongDatLoaiPhongItem>();
        public IReadOnlyList<DichVuSuDungItem> DichVuDaSuDung { get; init; } = Array.Empty<DichVuSuDungItem>();
        public IReadOnlyList<ChiTietDatPhongThongKeItem> ChiTietDatPhongs { get; init; } = Array.Empty<ChiTietDatPhongThongKeItem>();
        public IReadOnlyList<ChiTietDichVuTheoPhongItem> ChiTietDichVus { get; init; } = Array.Empty<ChiTietDichVuTheoPhongItem>();
    }

    public sealed class ThongKeService
    {
        public static string DinhDangTien(decimal soTien)
        {
            return soTien.ToString("N0", CultureInfo.InvariantCulture) + " VND";
        }

        public async Task<(DateTime TuNgay, DateTime DenNgay)> LayKhoangNgayMacDinhAsync(
            CancellationToken cancellationToken = default)
        {
            DateTime homNay = DateTime.Today;
            DateTime dauThang = new DateTime(homNay.Year, homNay.Month, 1);
            DateTime hetHomNay = homNay.AddDays(1);

            using var db = new HotelManagementContext();

            bool coDuLieuThangNay = await db.Ctdps
                .AsNoTracking()
                .AnyAsync(c => c.DaXoa != true
                            && c.MaPtNavigation.DaXoa != true
                            && c.TrangThai != "Đã hủy"
                            && c.TrangThai != "Đã huỷ"
                            && c.CheckIn >= dauThang
                            && c.CheckIn < hetHomNay,
                    cancellationToken);

            if (coDuLieuThangNay)
            {
                return (dauThang, homNay);
            }

            var phamVi = await db.Ctdps
                .AsNoTracking()
                .Where(c => c.DaXoa != true
                         && c.MaPtNavigation.DaXoa != true
                         && c.TrangThai != "Đã hủy"
                         && c.TrangThai != "Đã huỷ")
                .GroupBy(_ => 1)
                .Select(g => new
                {
                    MinCheckIn = g.Min(x => x.CheckIn),
                    MaxCheckIn = g.Max(x => x.CheckIn)
                })
                .FirstOrDefaultAsync(cancellationToken);

            if (phamVi == null)
            {
                return (dauThang, homNay);
            }

            DateTime tuNgay = phamVi.MinCheckIn.Date;
            DateTime denNgay = phamVi.MaxCheckIn.Date > homNay ? phamVi.MaxCheckIn.Date : homNay;
            return (tuNgay, denNgay);
        }

        public async Task<ThongKeKetQua> LayThongKeAsync(
            DateTime tuNgay,
            DateTime denNgay,
            CancellationToken cancellationToken = default)
        {
            DateTime start = tuNgay.Date;
            DateTime endDate = denNgay.Date;
            DateTime endExclusive = endDate.AddDays(1);

            using var db = new HotelManagementContext();

            var loaiPhongRaw = await db.LoaiPhongs
                .AsNoTracking()
                .OrderBy(l => l.MaLph)
                .Select(l => new
                {
                    l.MaLph,
                    l.TenLph
                })
                .ToListAsync(cancellationToken);

            var ctdpRaw = await db.Ctdps
                .AsNoTracking()
                .Where(c => c.DaXoa != true
                         && c.MaPtNavigation.DaXoa != true
                         && c.TrangThai != "Đã hủy"
                         && c.TrangThai != "Đã huỷ"
                         && c.CheckIn >= start
                         && c.CheckIn < endExclusive)
                .OrderByDescending(c => c.CheckIn)
                .ThenBy(c => c.MaCtdp)
                .Select(c => new
                {
                    c.MaCtdp,
                    c.MaPt,
                    c.MaPh,
                    TenLoaiPhong = c.MaPhNavigation != null && c.MaPhNavigation.MaLphNavigation != null
                        ? c.MaPhNavigation.MaLphNavigation.TenLph
                        : "Khác",
                    TenKhachHang = c.MaPtNavigation != null && c.MaPtNavigation.MaKhNavigation != null
                        ? c.MaPtNavigation.MaKhNavigation.TenKh
                        : "",
                    c.CheckIn,
                    c.CheckOut,
                    TrangThai = c.TrangThai ?? "",
                    TienPhong = c.ThanhTien ?? 0m,
                    HasHoaDon = c.HoaDons.Any(h => h.DaXoa != true)
                })
                .ToListAsync(cancellationToken);

            var ctdvRaw = await db.Ctdvs
                .AsNoTracking()
                .Where(v => v.DaXoa != true
                         && v.MaCtdpNavigation.DaXoa != true
                         && v.MaCtdpNavigation.MaPtNavigation.DaXoa != true
                         && v.MaCtdpNavigation.TrangThai != "Đã hủy"
                         && v.MaCtdpNavigation.TrangThai != "Đã huỷ"
                         && v.MaCtdpNavigation.CheckIn >= start
                         && v.MaCtdpNavigation.CheckIn < endExclusive)
                .Select(v => new
                {
                    v.MaCtdp,
                    v.MaDv,
                    TenDv = v.MaDvNavigation != null ? v.MaDvNavigation.TenDv : v.MaDv,
                    v.Sl,
                    DonGia = v.DonGia > 0m
                        ? v.DonGia
                        : (v.MaDvNavigation != null ? v.MaDvNavigation.DonGia : 0m),
                    ThanhTienRaw = v.ThanhTien
                })
                .ToListAsync(cancellationToken);

            // Xác định tập Booking đã thanh toán / hoàn tất để ghi nhận doanh thu thực thu
            static bool LaDaThanhToan(string trangThai, bool hasHoaDon) =>
                hasHoaDon
                || string.Equals(trangThai, "Đã xong", StringComparison.OrdinalIgnoreCase)
                || string.Equals(trangThai, "Đã thanh toán", StringComparison.OrdinalIgnoreCase);

            var ctdpMap = ctdpRaw.ToDictionary(
                x => x.MaCtdp,
                x => LaDaThanhToan(x.TrangThai, x.HasHoaDon),
                StringComparer.OrdinalIgnoreCase);

            // Dịch vụ đã dùng gắn với từng CTDP (ưu tiên các phiếu đã thanh toán cho doanh thu)
            var dichVuPaidRows = new List<ChiTietDichVuTheoPhongItem>();
            var tienDichVuTheoCtdp = new Dictionary<string, decimal>(StringComparer.OrdinalIgnoreCase);

            foreach (var v in ctdvRaw)
            {
                decimal thanhTien = v.ThanhTienRaw ?? (v.DonGia * v.Sl);
                if (tienDichVuTheoCtdp.TryGetValue(v.MaCtdp, out decimal current))
                    tienDichVuTheoCtdp[v.MaCtdp] = current + thanhTien;
                else
                    tienDichVuTheoCtdp[v.MaCtdp] = thanhTien;

                if (ctdpMap.TryGetValue(v.MaCtdp, out bool paid) && paid)
                {
                    dichVuPaidRows.Add(new ChiTietDichVuTheoPhongItem
                    {
                        MaCtdp = v.MaCtdp,
                        MaDv = v.MaDv,
                        TenDv = (v.TenDv ?? v.MaDv).Trim(),
                        SoLuong = v.Sl,
                        DonGia = v.DonGia,
                        ThanhTien = thanhTien
                    });
                }
            }

            var chiTietDatPhongs = ctdpRaw.Select(c =>
            {
                bool paid = LaDaThanhToan(c.TrangThai, c.HasHoaDon);
                decimal tienDv = tienDichVuTheoCtdp.TryGetValue(c.MaCtdp, out decimal dv) ? dv : 0m;
                return new ChiTietDatPhongThongKeItem
                {
                    MaCtdp = c.MaCtdp,
                    MaPt = c.MaPt,
                    MaPhong = c.MaPh,
                    TenLoaiPhong = string.IsNullOrWhiteSpace(c.TenLoaiPhong) ? "Khác" : c.TenLoaiPhong.Trim(),
                    TenKhachHang = c.TenKhachHang ?? "",
                    CheckIn = c.CheckIn,
                    CheckOut = c.CheckOut,
                    TrangThai = c.TrangThai,
                    DaThanhToan = paid,
                    TienPhong = c.TienPhong,
                    TienDichVu = tienDv
                };
            }).ToList();

            // Hợp nhất tên loại phòng duy nhất (tránh trùng cột khi DB có nhiều MaLPH cùng TenLPH)
            var danhSachTenLoaiPhong = new List<string>();
            var daCoLoaiPhong = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            foreach (var lp in loaiPhongRaw)
            {
                string ten = string.IsNullOrWhiteSpace(lp.TenLph) ? lp.MaLph : lp.TenLph.Trim();
                if (daCoLoaiPhong.Add(ten))
                {
                    danhSachTenLoaiPhong.Add(ten);
                }
            }

            foreach (var ct in chiTietDatPhongs)
            {
                if (daCoLoaiPhong.Add(ct.TenLoaiPhong))
                {
                    danhSachTenLoaiPhong.Add(ct.TenLoaiPhong);
                }
            }

            var doanhThuTheoLoaiPhong = new List<DoanhThuLoaiPhongItem>(danhSachTenLoaiPhong.Count);
            var soLuongDatTheoLoaiPhong = new List<SoLuongDatLoaiPhongItem>(danhSachTenLoaiPhong.Count);

            foreach (string tenLph in danhSachTenLoaiPhong)
            {
                var nhom = chiTietDatPhongs
                    .Where(x => string.Equals(x.TenLoaiPhong, tenLph, StringComparison.OrdinalIgnoreCase))
                    .ToList();

                var nhomPaid = nhom.Where(x => x.DaThanhToan).ToList();

                doanhThuTheoLoaiPhong.Add(new DoanhThuLoaiPhongItem
                {
                    TenLoaiPhong = tenLph,
                    DoanhThu = nhomPaid.Sum(x => x.TienPhong),
                    SoLuotThanhToan = nhomPaid.Count
                });

                soLuongDatTheoLoaiPhong.Add(new SoLuongDatLoaiPhongItem
                {
                    TenLoaiPhong = tenLph,
                    SoLuotDat = nhom.Count,
                    SoLuotDangDat = nhom.Count(x => string.Equals(x.TrangThai, "Đã đặt", StringComparison.OrdinalIgnoreCase)),
                    SoLuotDangThue = nhom.Count(x => string.Equals(x.TrangThai, "Đang thuê", StringComparison.OrdinalIgnoreCase)),
                    SoLuotHoanTat = nhomPaid.Count
                });
            }

            int tongSlDichVu = dichVuPaidRows.Sum(d => d.SoLuong);
            var dichVuDaSuDung = dichVuPaidRows
                .GroupBy(d => d.MaDv, StringComparer.OrdinalIgnoreCase)
                .Select(g =>
                {
                    int sl = g.Sum(x => x.SoLuong);
                    decimal dt = g.Sum(x => x.ThanhTien);
                    string tenDv = g.First().TenDv;
                    decimal donGia = g.First().DonGia;
                    return new DichVuSuDungItem
                    {
                        MaDichVu = g.Key,
                        TenDichVu = tenDv,
                        DonGia = donGia,
                        SoLuong = sl,
                        DoanhThu = dt,
                        TiLePhanTram = tongSlDichVu > 0 ? (sl * 100.0 / tongSlDichVu) : 0.0
                    };
                })
                .OrderByDescending(x => x.SoLuong)
                .ThenByDescending(x => x.DoanhThu)
                .ThenBy(x => x.TenDichVu, StringComparer.OrdinalIgnoreCase)
                .ToList();

            decimal tongDoanhThuPhong = chiTietDatPhongs.Where(x => x.DaThanhToan).Sum(x => x.TienPhong);
            decimal tongDoanhThuDichVu = dichVuPaidRows.Sum(x => x.ThanhTien);
            int soPhongDat = chiTietDatPhongs.Count;
            int soPhongDaThanhToan = chiTietDatPhongs.Count(x => x.DaThanhToan);

            // Top 1 Loại phòng doanh thu cao nhất
            string top1PhongDtHienThi = "Chưa có dữ liệu";
            string? top1PhongDtTen = null;
            decimal maxDtPhong = doanhThuTheoLoaiPhong.Count > 0 ? doanhThuTheoLoaiPhong.Max(x => x.DoanhThu) : 0m;
            if (maxDtPhong > 0m)
            {
                var topItems = doanhThuTheoLoaiPhong.Where(x => x.DoanhThu == maxDtPhong).ToList();
                top1PhongDtTen = topItems[0].TenLoaiPhong;
                string tenNoi = string.Join(", ", topItems.Select(x => x.TenLoaiPhong));
                top1PhongDtHienThi = $"{tenNoi} ({DinhDangTien(maxDtPhong)})";
            }

            // Top 1 Loại phòng được đặt nhiều nhất
            string top1PhongDatHienThi = "Chưa có dữ liệu";
            string? top1PhongDatTen = null;
            int maxLuotDat = soLuongDatTheoLoaiPhong.Count > 0 ? soLuongDatTheoLoaiPhong.Max(x => x.SoLuotDat) : 0;
            if (maxLuotDat > 0)
            {
                var topItems = soLuongDatTheoLoaiPhong.Where(x => x.SoLuotDat == maxLuotDat).ToList();
                top1PhongDatTen = topItems[0].TenLoaiPhong;
                string tenNoi = string.Join(", ", topItems.Select(x => x.TenLoaiPhong));
                top1PhongDatHienThi = $"{tenNoi} ({maxLuotDat} lượt)";
            }

            // Top 1 Dịch vụ doanh thu cao nhất
            string top1DvHienThi = "Chưa có dữ liệu";
            string? top1DvMa = null;
            decimal maxDtDv = dichVuDaSuDung.Count > 0 ? dichVuDaSuDung.Max(x => x.DoanhThu) : 0m;
            if (maxDtDv > 0m)
            {
                var topItems = dichVuDaSuDung.Where(x => x.DoanhThu == maxDtDv).ToList();
                top1DvMa = topItems[0].MaDichVu;
                string tenNoi = string.Join(", ", topItems.Select(x => x.TenDichVu));
                top1DvHienThi = $"{tenNoi} ({DinhDangTien(maxDtDv)})";
            }

            return new ThongKeKetQua
            {
                TuNgay = start,
                DenNgay = endDate,
                DoanhThuThuePhong = tongDoanhThuPhong,
                DoanhThuDichVu = tongDoanhThuDichVu,
                SoPhongDat = soPhongDat,
                SoPhongDaThanhToan = soPhongDaThanhToan,
                TongSoLuongDichVu = tongSlDichVu,
                LoaiPhongDoanhThuCaoNhatHienThi = top1PhongDtHienThi,
                LoaiPhongDoanhThuCaoNhatTen = top1PhongDtTen,
                LoaiPhongDatNhieuNhatHienThi = top1PhongDatHienThi,
                LoaiPhongDatNhieuNhatTen = top1PhongDatTen,
                DichVuDoanhThuCaoNhatHienThi = top1DvHienThi,
                DichVuDoanhThuCaoNhatMa = top1DvMa,
                DoanhThuTheoLoaiPhong = doanhThuTheoLoaiPhong,
                SoLuongDatTheoLoaiPhong = soLuongDatTheoLoaiPhong,
                DichVuDaSuDung = dichVuDaSuDung,
                ChiTietDatPhongs = chiTietDatPhongs,
                ChiTietDichVus = dichVuPaidRows
            };
        }
    }
}
