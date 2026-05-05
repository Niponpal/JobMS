using iText.Kernel.Pdf;
using iText.Kernel.Font;
using iText.IO.Font.Constants;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JobMS.Data;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace JobMS.Controllers
{
    public class ReportController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReportController(ApplicationDbContext context)
        {
            _context = context;
        }

        // =========================
        // 1. VIEW METHODS
        // =========================

        public IActionResult ApplicationStatusReport()
        {
            var data = _context.Applications
                .AsNoTracking()
                .GroupBy(a => a.Status)
                .Select(g => new ApplicationStatusVM
                {
                    Status = g.Key ?? "Pending",
                    Count = g.Count()
                })
                .ToList();

            return View(data);
        }

        public IActionResult JobPostingReport()
        {
            var data = _context.Jobs
                .AsNoTracking()
                .Select(j => new JobPostingVM
                {
                    JobTitle = j.JobTitle,
                    CompanyName = j.CompanyName,
                    JobLocation = j.JobLocation,
                    SalaryRange = j.SalaryRange,
                    Status = j.Status,
                    CreatedAt = j.CreatedAt
                })
                .ToList();

            return View(data);
        }

        public IActionResult DateWiseReport()
        {
            var data = _context.Jobs
                .AsNoTracking()
                .GroupBy(j => j.CreatedAt.Date)
                .Select(g => new DateWiseReportVM
                {
                    Date = g.Key,
                    Count = g.Count()
                })
                .OrderBy(x => x.Date)
                .ToList();

            return View(data);
        }

        // =========================
        // 2. PDF DOWNLOAD METHODS
        // =========================

        public IActionResult DownloadApplicationStatusReport()
        {
            var data = _context.Applications
                .GroupBy(a => a.Status)
                .Select(g => new { Status = g.Key, Count = g.Count() })
                .ToList();

            var rows = new List<string[]>
            {
                new[] { "Status", "Total Applications" }
            };

            foreach (var item in data)
                rows.Add(new[] { item.Status ?? "Pending", item.Count.ToString() });

            return GeneratePdf("Application Status Report", rows);
        }

        public IActionResult DownloadJobPostingReport()
        {
            var data = _context.Jobs.ToList();

            var rows = new List<string[]>
            {
                new[] { "Job Title", "Company", "Location", "Salary", "Status", "Date" }
            };

            foreach (var item in data)
            {
                rows.Add(new[]
                {
                    item.JobTitle ?? "",
                    item.CompanyName ?? "",
                    item.JobLocation ?? "",
                    item.SalaryRange ?? "",
                    item.Status ?? "",
                    item.CreatedAt.ToString("yyyy-MM-dd")
                });
            }

            return GeneratePdf("Job Posting Report", rows);
        }

        public IActionResult DownloadDateWiseReport()
        {
            var data = _context.Jobs
                .GroupBy(j => j.CreatedAt.Date)
                .Select(g => new { Date = g.Key, Count = g.Count() })
                .OrderBy(x => x.Date)
                .ToList();

            var rows = new List<string[]>
            {
                new[] { "Date", "Total Jobs" }
            };

            foreach (var item in data)
                rows.Add(new[] { item.Date.ToString("yyyy-MM-dd"), item.Count.ToString() });

            return GeneratePdf("Date Wise Job Report", rows);
        }

        // =========================
        // 3. PDF GENERATOR
        // =========================

        private IActionResult GeneratePdf(string title, List<string[]> rows)
        {
            MemoryStream ms = new MemoryStream();

            PdfWriter writer = new PdfWriter(ms);
            PdfDocument pdf = new PdfDocument(writer);
            Document document = new Document(pdf);

            PdfFont boldFont = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);

            document.Add(new Paragraph(title)
                .SetFont(boldFont)
                .SetFontSize(18)
                .SetTextAlignment(TextAlignment.CENTER)
                .SetMarginBottom(20));

            Table table = new Table(rows[0].Length).UseAllAvailableWidth();

            foreach (var header in rows[0])
                table.AddHeaderCell(new Cell().Add(new Paragraph(header).SetFont(boldFont)));

            for (int i = 1; i < rows.Count; i++)
                foreach (var col in rows[i])
                    table.AddCell(new Paragraph(col ?? ""));

            document.Add(table);
            document.Close();

            return File(ms.ToArray(), "application/pdf", $"{title}.pdf");
        }
    }
}

//using iText.Kernel.Pdf;
//using iText.Kernel.Font;
//using iText.IO.Font.Constants;
//using iText.Layout;
//using iText.Layout.Element;
//using iText.Layout.Properties;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using JobMS.Data;
//using System.IO;
//using System.Linq;
//using System.Collections.Generic;

//namespace JobMS.Controllers
//{
//    public class ReportController : Controller
//    {
//        private readonly ApplicationDbContext _context;

//        public ReportController(ApplicationDbContext context)
//        {
//            _context = context;
//        }

//        // ======================================
//        // 1. APPLICATION STATUS REPORT
//        // ======================================
//        public IActionResult ApplicationStatusReport()
//        {
//            var data = _context.Applications
//                .AsNoTracking()
//                .GroupBy(a => a.Status)
//                .Select(g => new
//                {
//                    Status = g.Key,
//                    Count = g.Count()
//                })
//                .ToList();

//            var rows = new List<string[]>
//            {
//                new[] { "Status", "Total Applications" }
//            };

//            foreach (var item in data)
//            {
//                rows.Add(new[]
//                {
//                    item.Status ?? "Unknown",
//                    item.Count.ToString()
//                });
//            }

//            return GeneratePdf("Application Status Report", rows);
//        }

//        // ======================================
//        // 2. JOB POSTING REPORT
//        // ======================================
//        public IActionResult JobPostingReport()
//        {
//            var data = _context.Jobs
//                .AsNoTracking()
//                .Select(j => new
//                {
//                    j.JobTitle,
//                    j.CompanyName,
//                    j.JobLocation,
//                    j.SalaryRange,
//                    j.Status,
//                    j.CreatedAt
//                })
//                .ToList();

//            var rows = new List<string[]>
//            {
//                new[] { "Job Title", "Company", "Location", "Salary", "Status", "Posted Date" }
//            };

//            foreach (var item in data)
//            {
//                rows.Add(new[]
//                {
//                    item.JobTitle ?? "N/A",
//                    item.CompanyName ?? "N/A",
//                    item.JobLocation ?? "N/A",
//                    item.SalaryRange ?? "N/A",
//                    item.Status ?? "N/A",
//                    item.CreatedAt.ToString("yyyy-MM-dd")
//                });
//            }

//            return GeneratePdf("Job Posting Report", rows);
//        }

//        // ======================================
//        // 3. DATE WISE JOB REPORT
//        // ======================================
//        public IActionResult DateWiseReport()
//        {
//            var data = _context.Jobs
//                .AsNoTracking()
//                .GroupBy(j => j.CreatedAt.Date)
//                .Select(g => new
//                {
//                    Date = g.Key,
//                    Count = g.Count()
//                })
//                .OrderBy(x => x.Date)
//                .ToList();

//            var rows = new List<string[]>
//            {
//                new[] { "Date", "Total Jobs Posted" }
//            };

//            foreach (var item in data)
//            {
//                rows.Add(new[]
//                {
//                    item.Date.ToString("yyyy-MM-dd"),
//                    item.Count.ToString()
//                });
//            }

//            return GeneratePdf("Date Wise Job Report", rows);
//        }

//        // ======================================
//        // COMMON PDF GENERATOR (FIXED)
//        // ======================================
//        private IActionResult GeneratePdf(string title, List<string[]> rows)
//        {
//            MemoryStream ms = new MemoryStream(); // ❌ using removed

//            PdfWriter writer = new PdfWriter(ms);
//            PdfDocument pdf = new PdfDocument(writer);
//            Document document = new Document(pdf);

//            PdfFont boldFont = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);

//            // TITLE
//            document.Add(new Paragraph(title)
//                .SetFont(boldFont)
//                .SetFontSize(18)
//                .SetTextAlignment(TextAlignment.CENTER)
//                .SetMarginBottom(20));

//            int columnCount = rows[0].Length;
//            Table table = new Table(columnCount).UseAllAvailableWidth();

//            // HEADER
//            foreach (var header in rows[0])
//            {
//                table.AddHeaderCell(
//                    new Cell().Add(new Paragraph(header)
//                    .SetFont(boldFont))
//                );
//            }

//            // DATA
//            for (int i = 1; i < rows.Count; i++)
//            {
//                foreach (var col in rows[i])
//                {
//                    table.AddCell(new Paragraph(col ?? ""));
//                }
//            }

//            document.Add(table);
//            document.Close(); // closes pdf safely

//            byte[] pdfBytes = ms.ToArray(); // ✅ safe access

//            return File(pdfBytes, "application/pdf", $"{title}.pdf");
//        }
//    }
//}