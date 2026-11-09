using ClosedXML.Excel;
using ClosedXML.Excel.Drawings;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Globalization;
using System.IO;
using System.Linq;
using PdfFont = iTextSharp.text.Font;
using PdfImage = iTextSharp.text.Image;
using PdfRect = iTextSharp.text.Rectangle;

namespace HotelManagement.ThongKe
{
    internal static class ThongKeReportExporter
    {
        public static void XuatPdf(
            string filePath,
            ThongKeKetQua data,
            string nguoiLap,
            byte[]? chartDoanhThuPhongPng,
            byte[]? chartSoPhongDatPng,
            byte[]? chartDichVuPng)
        {
            BaseFont baseFont = TaoFontTiengViet();
            var fontTieuDe = new PdfFont(baseFont, 16, PdfFont.BOLD, new BaseColor(24, 58, 122));
            var fontMuc = new PdfFont(baseFont, 12, PdfFont.BOLD, new BaseColor(24, 58, 122));
            var fontDam = new PdfFont(baseFont, 10, PdfFont.BOLD, BaseColor.Black);
            var fontThuong = new PdfFont(baseFont, 10, PdfFont.NORMAL, BaseColor.Black);
            var fontNghieng = new PdfFont(baseFont, 10, PdfFont.ITALIC, new BaseColor(80, 86, 98));
            var fontHeaderBang = new PdfFont(baseFont, 10, PdfFont.BOLD, BaseColor.White);

            var mauHeaderBang = new BaseColor(30, 74, 138);
            var mauNenNhat = new BaseColor(242, 246, 252);
            var mauNenTong = new BaseColor(232, 240, 250);

            using var doc = new Document(PageSize.A4, 28, 28, 28, 28);
            using (var stream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                PdfWriter.GetInstance(doc, stream);
                doc.Open();

                var title = new Paragraph("BÁO CÁO THỐNG KÊ TÌNH HÌNH KINH DOANH KHÁCH SẠN", fontTieuDe)
                {
                    Alignment = Element.ALIGN_CENTER,
                    SpacingAfter = 6
                };
                doc.Add(title);

                var sub = new Paragraph(
                    $"Khoảng thời gian: Từ ngày {data.TuNgay:dd/MM/yyyy} đến ngày {data.DenNgay:dd/MM/yyyy}",
                    fontNghieng)
                {
                    Alignment = Element.ALIGN_CENTER,
                    SpacingAfter = 4
                };
                doc.Add(sub);

                var meta = new Paragraph(
                    $"Ngày xuất báo cáo: {DateTime.Now:dd/MM/yyyy HH:mm}   |   Người lập: {(string.IsNullOrWhiteSpace(nguoiLap) ? "Quản trị" : nguoiLap)}",
                    fontNghieng)
                {
                    Alignment = Element.ALIGN_CENTER,
                    SpacingAfter = 14
                };
                doc.Add(meta);

                // 1. Tổng quan chỉ số
                doc.Add(TaoTieuDeMuc("I. TỔNG QUAN CHỈ SỐ KINH DOANH", fontMuc));

                var tblKpi = new PdfPTable(2)
                {
                    WidthPercentage = 100,
                    SpacingAfter = 12
                };
                tblKpi.SetWidths(new float[] { 44f, 56f });

                (string Label, string Value)[] kpiRows =
                {
                    ("Doanh thu thuê phòng", ThongKeService.DinhDangTien(data.DoanhThuThuePhong)),
                    ("Doanh thu dịch vụ", ThongKeService.DinhDangTien(data.DoanhThuDichVu)),
                    ("Tổng doanh thu thực thu", ThongKeService.DinhDangTien(data.TongDoanhThu)),
                    ("Tổng số phòng được đặt", $"{data.SoPhongDat} lượt (đã thanh toán/xong: {data.SoPhongDaThanhToan})"),
                    ("Loại phòng doanh thu cao nhất", data.LoaiPhongDoanhThuCaoNhatHienThi),
                    ("Loại phòng được đặt nhiều nhất", data.LoaiPhongDatNhieuNhatHienThi),
                    ("Dịch vụ doanh thu cao nhất", data.DichVuDoanhThuCaoNhatHienThi)
                };

                for (int i = 0; i < kpiRows.Length; i++)
                {
                    BaseColor? bg = (i % 2 == 1) ? mauNenNhat : null;
                    tblKpi.AddCell(TaoOPdf(kpiRows[i].Label, fontDam, Element.ALIGN_LEFT, true, bg));
                    tblKpi.AddCell(TaoOPdf(kpiRows[i].Value, fontThuong, Element.ALIGN_LEFT, true, bg));
                }
                doc.Add(tblKpi);

                // 2. Bảng loại phòng
                doc.Add(TaoTieuDeMuc("II. THỐNG KÊ THEO LOẠI PHÒNG", fontMuc));

                var tblLoaiPhong = new PdfPTable(4)
                {
                    WidthPercentage = 100,
                    SpacingAfter = 12
                };
                tblLoaiPhong.SetWidths(new float[] { 34f, 20f, 22f, 24f });

                foreach (string h in new[] { "Loại phòng", "Số lượt đặt", "Đã thanh toán", "Doanh thu phòng (VND)" })
                {
                    tblLoaiPhong.AddCell(TaoOPdf(h, fontHeaderBang, Element.ALIGN_CENTER, true, mauHeaderBang));
                }

                var datLookup = data.SoLuongDatTheoLoaiPhong
                    .ToDictionary(x => x.TenLoaiPhong, StringComparer.OrdinalIgnoreCase);

                for (int i = 0; i < data.DoanhThuTheoLoaiPhong.Count; i++)
                {
                    var row = data.DoanhThuTheoLoaiPhong[i];
                    int soLuotDat = datLookup.TryGetValue(row.TenLoaiPhong, out var sItem) ? sItem.SoLuotDat : 0;
                    BaseColor? bg = (i % 2 == 1) ? mauNenNhat : null;

                    tblLoaiPhong.AddCell(TaoOPdf(row.TenLoaiPhong, fontThuong, Element.ALIGN_LEFT, true, bg));
                    tblLoaiPhong.AddCell(TaoOPdf(soLuotDat.ToString(CultureInfo.InvariantCulture), fontThuong, Element.ALIGN_CENTER, true, bg));
                    tblLoaiPhong.AddCell(TaoOPdf(row.SoLuotThanhToan.ToString(CultureInfo.InvariantCulture), fontThuong, Element.ALIGN_CENTER, true, bg));
                    tblLoaiPhong.AddCell(TaoOPdf(row.DoanhThu.ToString("N0", CultureInfo.InvariantCulture), fontThuong, Element.ALIGN_RIGHT, true, bg));
                }

                tblLoaiPhong.AddCell(TaoOPdf("Tổng cộng", fontDam, Element.ALIGN_LEFT, true, mauNenTong));
                tblLoaiPhong.AddCell(TaoOPdf(data.SoPhongDat.ToString(CultureInfo.InvariantCulture), fontDam, Element.ALIGN_CENTER, true, mauNenTong));
                tblLoaiPhong.AddCell(TaoOPdf(data.SoPhongDaThanhToan.ToString(CultureInfo.InvariantCulture), fontDam, Element.ALIGN_CENTER, true, mauNenTong));
                tblLoaiPhong.AddCell(TaoOPdf(data.DoanhThuThuePhong.ToString("N0", CultureInfo.InvariantCulture), fontDam, Element.ALIGN_RIGHT, true, mauNenTong));
                doc.Add(tblLoaiPhong);

                // 3. Bảng dịch vụ
                doc.Add(TaoTieuDeMuc("III. THỐNG KÊ DỊCH VỤ ĐÃ SỬ DỤNG", fontMuc));

                var tblDichVu = new PdfPTable(5)
                {
                    WidthPercentage = 100,
                    SpacingAfter = 14
                };
                tblDichVu.SetWidths(new float[] { 32f, 18f, 14f, 14f, 22f });

                foreach (string h in new[] { "Tên dịch vụ", "Đơn giá (VND)", "Số lượng", "Tỉ lệ (%)", "Doanh thu (VND)" })
                {
                    tblDichVu.AddCell(TaoOPdf(h, fontHeaderBang, Element.ALIGN_CENTER, true, mauHeaderBang));
                }

                if (data.DichVuDaSuDung.Count == 0)
                {
                    var oTrong = TaoOPdf("Không có dịch vụ được sử dụng trong khoảng thời gian này.", fontNghieng, Element.ALIGN_CENTER, true, null);
                    oTrong.Colspan = 5;
                    tblDichVu.AddCell(oTrong);
                }
                else
                {
                    for (int i = 0; i < data.DichVuDaSuDung.Count; i++)
                    {
                        var dv = data.DichVuDaSuDung[i];
                        BaseColor? bg = (i % 2 == 1) ? mauNenNhat : null;

                        tblDichVu.AddCell(TaoOPdf(dv.TenDichVu, fontThuong, Element.ALIGN_LEFT, true, bg));
                        tblDichVu.AddCell(TaoOPdf(dv.DonGia.ToString("N0", CultureInfo.InvariantCulture), fontThuong, Element.ALIGN_RIGHT, true, bg));
                        tblDichVu.AddCell(TaoOPdf(dv.SoLuong.ToString(CultureInfo.InvariantCulture), fontThuong, Element.ALIGN_CENTER, true, bg));
                        tblDichVu.AddCell(TaoOPdf(dv.TiLePhanTram.ToString("0.0", CultureInfo.InvariantCulture) + "%", fontThuong, Element.ALIGN_CENTER, true, bg));
                        tblDichVu.AddCell(TaoOPdf(dv.DoanhThu.ToString("N0", CultureInfo.InvariantCulture), fontThuong, Element.ALIGN_RIGHT, true, bg));
                    }

                    tblDichVu.AddCell(TaoOPdf("Tổng cộng", fontDam, Element.ALIGN_LEFT, true, mauNenTong));
                    tblDichVu.AddCell(TaoOPdf("", fontDam, Element.ALIGN_RIGHT, true, mauNenTong));
                    tblDichVu.AddCell(TaoOPdf(data.TongSoLuongDichVu.ToString(CultureInfo.InvariantCulture), fontDam, Element.ALIGN_CENTER, true, mauNenTong));
                    tblDichVu.AddCell(TaoOPdf("100.0%", fontDam, Element.ALIGN_CENTER, true, mauNenTong));
                    tblDichVu.AddCell(TaoOPdf(data.DoanhThuDichVu.ToString("N0", CultureInfo.InvariantCulture), fontDam, Element.ALIGN_RIGHT, true, mauNenTong));
                }
                doc.Add(tblDichVu);

                // 4. Biểu đồ trực quan
                float usableWidth = doc.PageSize.Width - doc.LeftMargin - doc.RightMargin;
                if (chartDoanhThuPhongPng != null || chartSoPhongDatPng != null || chartDichVuPng != null)
                {
                    doc.NewPage();
                    doc.Add(TaoTieuDeMuc("IV. BIỂU ĐỒ TRỰC QUAN", fontMuc));

                    ThemAnhBieuDoPdf(doc, "1. Biểu đồ doanh thu thuê phòng theo loại phòng", chartDoanhThuPhongPng, fontDam, usableWidth, 215f);
                    ThemAnhBieuDoPdf(doc, "2. Biểu đồ số phòng được đặt theo loại phòng", chartSoPhongDatPng, fontDam, usableWidth, 215f);
                    ThemAnhBieuDoPdf(doc, "3. Biểu đồ tỷ trọng các dịch vụ được sử dụng", chartDichVuPng, fontDam, usableWidth, 240f);
                }

                doc.Close();
            }
        }

        public static void XuatExcel(
            string filePath,
            ThongKeKetQua data,
            string nguoiLap,
            byte[]? chartDoanhThuPhongPng,
            byte[]? chartSoPhongDatPng,
            byte[]? chartDichVuPng)
        {
            using var workbook = new XLWorkbook();

            // Sheet 1: Tổng quan & Biểu đồ
            var ws = workbook.Worksheets.Add("Thống kê tổng quan");
            ws.Cell(1, 1).Value = "BÁO CÁO THỐNG KÊ TÌNH HÌNH KINH DOANH KHÁCH SẠN";
            ws.Range(1, 1, 1, 6).Merge().Style.Font.SetBold(true).Font.SetFontSize(14).Font.SetFontColor(XLColor.DarkBlue);
            ws.Cell(2, 1).Value = $"Khoảng thời gian: {data.TuNgay:dd/MM/yyyy} - {data.DenNgay:dd/MM/yyyy}";
            ws.Cell(3, 1).Value = $"Ngày xuất: {DateTime.Now:dd/MM/yyyy HH:mm} | Người lập: {(string.IsNullOrWhiteSpace(nguoiLap) ? "Quản trị" : nguoiLap)}";

            int row = 5;
            ws.Cell(row, 1).Value = "CHỈ SỐ TỔNG QUAN";
            ws.Range(row, 1, row, 2).Merge().Style.Font.SetBold(true).Fill.SetBackgroundColor(XLColor.FromArgb(216, 195, 210));
            row++;

            (string Label, object Val, string? NumFmt)[] kpis =
            {
                ("Doanh thu thuê phòng (VND)", data.DoanhThuThuePhong, "#,##0"),
                ("Doanh thu dịch vụ (VND)", data.DoanhThuDichVu, "#,##0"),
                ("Tổng doanh thu (VND)", data.TongDoanhThu, "#,##0"),
                ("Số phòng được đặt (lượt)", data.SoPhongDat, "#,##0"),
                ("Loại phòng doanh thu cao nhất", data.LoaiPhongDoanhThuCaoNhatHienThi, null),
                ("Loại phòng được đặt nhiều nhất", data.LoaiPhongDatNhieuNhatHienThi, null),
                ("Dịch vụ doanh thu cao nhất", data.DichVuDoanhThuCaoNhatHienThi, null)
            };

            foreach (var item in kpis)
            {
                ws.Cell(row, 1).Value = item.Label;
                ws.Cell(row, 1).Style.Font.Bold = true;
                var valCell = ws.Cell(row, 2);
                if (item.Val is decimal dVal)
                    valCell.Value = dVal;
                else if (item.Val is int iVal)
                    valCell.Value = iVal;
                else
                    valCell.Value = item.Val?.ToString() ?? "";

                if (!string.IsNullOrEmpty(item.NumFmt))
                    valCell.Style.NumberFormat.Format = item.NumFmt;

                row++;
            }

            row++;
            ws.Cell(row, 1).Value = "THỐNG KÊ THEO LOẠI PHÒNG";
            ws.Range(row, 1, row, 4).Merge().Style.Font.SetBold(true).Fill.SetBackgroundColor(XLColor.FromArgb(216, 195, 210));
            row++;

            string[] roomHeaders = { "Loại phòng", "Số lượt đặt", "Đã thanh toán", "Doanh thu phòng (VND)" };
            for (int c = 0; c < roomHeaders.Length; c++)
            {
                var cell = ws.Cell(row, c + 1);
                cell.Value = roomHeaders[c];
                cell.Style.Font.Bold = true;
                cell.Style.Fill.BackgroundColor = XLColor.FromArgb(30, 74, 138);
                cell.Style.Font.FontColor = XLColor.White;
            }
            row++;

            var datLookup = data.SoLuongDatTheoLoaiPhong
                .ToDictionary(x => x.TenLoaiPhong, StringComparer.OrdinalIgnoreCase);

            foreach (var rItem in data.DoanhThuTheoLoaiPhong)
            {
                int soLuotDat = datLookup.TryGetValue(rItem.TenLoaiPhong, out var sItem) ? sItem.SoLuotDat : 0;
                ws.Cell(row, 1).Value = rItem.TenLoaiPhong;
                ws.Cell(row, 2).Value = soLuotDat;
                ws.Cell(row, 3).Value = rItem.SoLuotThanhToan;
                ws.Cell(row, 4).Value = rItem.DoanhThu;
                ws.Cell(row, 4).Style.NumberFormat.Format = "#,##0";
                row++;
            }

            row++;
            ws.Cell(row, 1).Value = "DỊCH VỤ ĐÃ SỬ DỤNG";
            ws.Range(row, 1, row, 5).Merge().Style.Font.SetBold(true).Fill.SetBackgroundColor(XLColor.FromArgb(216, 195, 210));
            row++;

            string[] dvHeaders = { "Tên dịch vụ", "Đơn giá (VND)", "Số lượng", "Tỉ lệ (%)", "Doanh thu (VND)" };
            for (int c = 0; c < dvHeaders.Length; c++)
            {
                var cell = ws.Cell(row, c + 1);
                cell.Value = dvHeaders[c];
                cell.Style.Font.Bold = true;
                cell.Style.Fill.BackgroundColor = XLColor.FromArgb(30, 74, 138);
                cell.Style.Font.FontColor = XLColor.White;
            }
            row++;

            foreach (var dv in data.DichVuDaSuDung)
            {
                ws.Cell(row, 1).Value = dv.TenDichVu;
                ws.Cell(row, 2).Value = dv.DonGia;
                ws.Cell(row, 2).Style.NumberFormat.Format = "#,##0";
                ws.Cell(row, 3).Value = dv.SoLuong;
                ws.Cell(row, 4).Value = Math.Round(dv.TiLePhanTram, 1);
                ws.Cell(row, 4).Style.NumberFormat.Format = "0.0";
                ws.Cell(row, 5).Value = dv.DoanhThu;
                ws.Cell(row, 5).Style.NumberFormat.Format = "#,##0";
                row++;
            }

            ws.Columns(1, 5).AdjustToContents();

            int chartCol = 7;
            int chartRow = 5;
            ThemAnhBieuDoExcel(ws, chartDoanhThuPhongPng, "ChartDoanhThuPhong", chartRow, chartCol);
            ThemAnhBieuDoExcel(ws, chartSoPhongDatPng, "ChartSoPhongDat", chartRow + 17, chartCol);
            ThemAnhBieuDoExcel(ws, chartDichVuPng, "ChartDichVu", chartRow + 34, chartCol);

            // Sheet 2: Chi tiết đặt phòng
            var wsDetail = workbook.Worksheets.Add("Chi tiết đặt phòng");
            string[] detailHeaders =
            {
                "Mã CTDP", "Mã phiếu thuê", "Phòng", "Loại phòng", "Khách hàng",
                "Check-in", "Check-out", "Trạng thái", "Tiền phòng (VND)", "Tiền dịch vụ (VND)", "Tổng cộng (VND)"
            };
            for (int c = 0; c < detailHeaders.Length; c++)
            {
                var cell = wsDetail.Cell(1, c + 1);
                cell.Value = detailHeaders[c];
                cell.Style.Font.Bold = true;
                cell.Style.Fill.BackgroundColor = XLColor.FromArgb(30, 74, 138);
                cell.Style.Font.FontColor = XLColor.White;
            }

            int dRow = 2;
            foreach (var item in data.ChiTietDatPhongs)
            {
                wsDetail.Cell(dRow, 1).Value = item.MaCtdp;
                wsDetail.Cell(dRow, 2).Value = item.MaPt;
                wsDetail.Cell(dRow, 3).Value = item.MaPhong;
                wsDetail.Cell(dRow, 4).Value = item.TenLoaiPhong;
                wsDetail.Cell(dRow, 5).Value = item.TenKhachHang;
                wsDetail.Cell(dRow, 6).Value = item.CheckIn;
                wsDetail.Cell(dRow, 6).Style.NumberFormat.Format = "dd/MM/yyyy";
                wsDetail.Cell(dRow, 7).Value = item.CheckOut;
                wsDetail.Cell(dRow, 7).Style.NumberFormat.Format = "dd/MM/yyyy";
                wsDetail.Cell(dRow, 8).Value = item.TrangThai;
                wsDetail.Cell(dRow, 9).Value = item.TienPhong;
                wsDetail.Cell(dRow, 9).Style.NumberFormat.Format = "#,##0";
                wsDetail.Cell(dRow, 10).Value = item.TienDichVu;
                wsDetail.Cell(dRow, 10).Style.NumberFormat.Format = "#,##0";
                wsDetail.Cell(dRow, 11).Value = item.TongTien;
                wsDetail.Cell(dRow, 11).Style.NumberFormat.Format = "#,##0";
                dRow++;
            }
            wsDetail.Columns().AdjustToContents();

            workbook.SaveAs(filePath);
        }

        private static BaseFont TaoFontTiengViet()
        {
            string thuMucFont = Environment.GetFolderPath(Environment.SpecialFolder.Fonts);
            string[] danhSachFont = { "arial.ttf", "tahoma.ttf", "segoeui.ttf", "times.ttf" };
            foreach (string tenFile in danhSachFont)
            {
                string duongDan = Path.Combine(thuMucFont, tenFile);
                if (File.Exists(duongDan))
                {
                    return BaseFont.CreateFont(duongDan, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                }
            }
            throw new FileNotFoundException("Không tìm thấy font hỗ trợ tiếng Việt trong thư mục Fonts của Windows.");
        }

        private static Paragraph TaoTieuDeMuc(string text, PdfFont font)
        {
            return new Paragraph(text, font)
            {
                SpacingBefore = 6,
                SpacingAfter = 6
            };
        }

        private static PdfPCell TaoOPdf(
            string text,
            PdfFont font,
            int alignment,
            bool coVien,
            BaseColor? backgroundColor)
        {
            var cell = new PdfPCell(new Phrase(text, font))
            {
                HorizontalAlignment = alignment,
                VerticalAlignment = Element.ALIGN_MIDDLE,
                PaddingTop = 5,
                PaddingBottom = 5,
                PaddingLeft = 6,
                PaddingRight = 6
            };

            if (!coVien)
            {
                cell.Border = PdfRect.NO_BORDER;
            }
            else
            {
                cell.BorderColor = new BaseColor(200, 208, 220);
            }

            if (backgroundColor != null)
            {
                cell.BackgroundColor = backgroundColor;
            }

            return cell;
        }

        private static void ThemAnhBieuDoPdf(
            Document doc,
            string caption,
            byte[]? pngBytes,
            PdfFont captionFont,
            float maxWidth,
            float maxHeight)
        {
            if (pngBytes == null || pngBytes.Length == 0)
                return;

            var p = new Paragraph(caption, captionFont)
            {
                SpacingBefore = 6,
                SpacingAfter = 4
            };
            doc.Add(p);

            var img = PdfImage.GetInstance(pngBytes);
            img.Alignment = Element.ALIGN_CENTER;
            img.ScaleToFit(maxWidth, maxHeight);
            img.SpacingAfter = 8;
            doc.Add(img);
        }

        private static void ThemAnhBieuDoExcel(
            IXLWorksheet ws,
            byte[]? pngBytes,
            string name,
            int row,
            int col)
        {
            if (pngBytes == null || pngBytes.Length == 0)
                return;

            using var ms = new MemoryStream(pngBytes);
            ws.AddPicture(ms, XLPictureFormat.Png, name)
                .MoveTo(ws.Cell(row, col))
                .WithSize(540, 280);
        }
    }
}
