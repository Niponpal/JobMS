using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JobMS.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobMS.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _context;

        // Constructor - Dependency Injection
        public DashboardController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            // KPI Calculations
            var totalJobs = await _context.Jobs.CountAsync();
            var totalApplications = await _context.Applications.CountAsync();
            var activeJobs = await _context.Jobs.CountAsync(j => j.Status == "Active");
            var avgApplications = totalJobs > 0
                ? Math.Round((decimal)totalApplications / totalJobs, 1)
                : 0;

            // Recent Jobs (Latest 5)
            var recentJobs = await _context.Jobs
                .OrderByDescending(j => j.CreatedAt)
                .Take(5)
                .ToListAsync();

            // Recent Applications (Latest 8) with Job information
            var recentApplications = await _context.Applications
                .Include(a => a.Job)
                .OrderByDescending(a => a.Id)
                .Take(8)
                .ToListAsync();

            // Pass data to View
            ViewBag.TotalJobs = totalJobs;
            ViewBag.TotalApplications = totalApplications;
            ViewBag.ActiveJobs = activeJobs;
            ViewBag.AvgApplications = avgApplications;

            ViewBag.RecentJobs = recentJobs ?? new List<Job>();
            ViewBag.RecentApplications = recentApplications ?? new List<Application>();

            return View();
        }
    }
}