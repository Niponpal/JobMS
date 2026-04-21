using JobMS.Auth_IdentityModel;
using JobMS.Models;
using JobMS.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace JobMS.Controllers
{
    [Authorize]
    public class ApplicationController : Controller
    {
        private readonly IApplicationRepository _applicationRepository;
        private readonly IJobRepository _jobRepository;
        private readonly UserManager<User> _userManager;

        public ApplicationController(
            IApplicationRepository applicationRepository,
            IJobRepository jobRepository,
            UserManager<User> userManager)
        {
            _applicationRepository = applicationRepository;
            _jobRepository = jobRepository;
            _userManager = userManager;
        }

        // =========================
        // INDEX
        // =========================
        [HttpGet]
        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var data = await _applicationRepository.GetAllApplicationsAsync(cancellationToken);
            return View(data);
        }

        // =========================
        // CREATE (GET)
        // =========================
        [HttpGet]
        public async Task<IActionResult> CreateOrEdit(long jobId, CancellationToken cancellationToken)
        {
            if (jobId <= 0)
                return BadRequest();

            var job = await _jobRepository.GetJobsByIdAsync(jobId, cancellationToken);
            if (job == null)
                return NotFound();

            ViewBag.JobTitle = job.JobTitle;

            return View(new Application
            {
                JobId = job.Id
            });
        }

        // =========================
        // CREATE / EDIT (POST)
        // =========================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOrEdit(Application application, CancellationToken cancellationToken)
        {
            var job = await _jobRepository.GetJobsByIdAsync(application.JobId, cancellationToken);
            if (job == null)
                return BadRequest("Invalid Job");

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return RedirectToAction("Login", "Account");

            // ?? FIX: remove navigation validation issue
            ModelState.Remove("User");
            ModelState.Remove("Job");
            ModelState.Remove("ApplicationId");

            if (!ModelState.IsValid)
            {
                ViewBag.JobTitle = job.JobTitle;
                return View(application);
            }

            // ?? Prevent duplicate application
            var exists = await _applicationRepository.IsAlreadyAppliedAsync(
                application.JobId,
                user.Id,
                cancellationToken);

            if (exists)
            {
                ModelState.AddModelError("", "You already applied for this job.");
                ViewBag.JobTitle = job.JobTitle;
                return View(application);
            }

            application.UserId = user.Id;

            // AUTO ID
            if (application.Id == 0)
            {
                application.ApplicationId = "APP-" + DateTime.Now.Ticks;
                await _applicationRepository.AddApplicationAsync(application, cancellationToken);
            }
            else
            {
                await _applicationRepository.UpdateApplicationAsync(application, cancellationToken);
            }

            return RedirectToAction(nameof(Index));
        }

        // =========================
        // DETAILS
        // =========================
        [HttpGet]
        public async Task<IActionResult> Details(long id, CancellationToken cancellationToken)
        {
            if (id <= 0)
                return BadRequest();

            var data = await _applicationRepository.GetApplicationByIdAsync(id, cancellationToken);
            if (data == null)
                return NotFound();

            return View(data);
        }

        // =========================
        // DELETE
        // =========================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(long id, CancellationToken cancellationToken)
        {
            if (id <= 0)
                return BadRequest();

            await _applicationRepository.DeleteApplicationAsync(id, cancellationToken);

            return RedirectToAction(nameof(Index));
        }
    }
}