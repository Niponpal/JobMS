using JobMS.Auth_IdentityModel;
using JobMS.FilesUpload;
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
        private readonly IFileService _fileService;

        public ApplicationController(
            IApplicationRepository applicationRepository,
            IJobRepository jobRepository,
            UserManager<User> userManager,
            IFileService fileService)
        {
            _applicationRepository = applicationRepository;
            _jobRepository = jobRepository;
            _userManager = userManager;
            _fileService = fileService;
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



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOrEdit(Application application, IFormFile? ResumeFile, CancellationToken cancellationToken)
        {
            var job = await _jobRepository.GetJobsByIdAsync(application.JobId, cancellationToken);
            if (job == null)
            {
                TempData["error"] = "Invalid job!";
                return RedirectToAction("Index", "Home");
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                TempData["error"] = "Please login first!";
                return RedirectToAction("Login", "Account");
            }

            // ?? FILE UPLOAD
            if (ResumeFile != null)
            {
                application.ResumePath = await _fileService.Upload(ResumeFile, "uploads/resumes");
            }

            ModelState.Remove("User");
            ModelState.Remove("Job");
            ModelState.Remove("ApplicationId");

            if (!ModelState.IsValid)
            {
                ViewBag.JobTitle = job.JobTitle;
                return View(application);
            }

            var exists = await _applicationRepository.IsAlreadyAppliedAsync(
                application.JobId,
                user.Id,
                cancellationToken);

            if (exists)
            {
                TempData["warning"] = "You already applied for this job!";
                return RedirectToAction("Index", "Home");
            }

            application.UserId = user.Id;

            try
            {
                if (application.Id == 0)
                {
                    application.ApplicationId = "APP-" + DateTime.Now.Ticks;
                    await _applicationRepository.AddApplicationAsync(application, cancellationToken);
                    TempData["success"] = "Application submitted successfully!";
                }
                else
                {
                    await _applicationRepository.UpdateApplicationAsync(application, cancellationToken);
                    TempData["success"] = "Application updated successfully!";
                }
            }
            catch
            {
                TempData["error"] = "Something went wrong while submitting!";
            }

            return RedirectToAction("Index", "Home");
        }

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


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(long id, CancellationToken cancellationToken)
        {
            if (id <= 0)
            {
                TempData["error"] = "Invalid request!";
                return RedirectToAction(nameof(Index));
            }

            try
            {
                var app = await _applicationRepository.GetApplicationByIdAsync(id, cancellationToken);

                if (app != null)
                {
                    // ?? DELETE FILE FIRST
                    if (!string.IsNullOrEmpty(app.ResumePath))
                    {
                        var fileName = Path.GetFileName(app.ResumePath);
                        _fileService.DeleteFile(fileName, "uploads/resumes");
                    }

                    await _applicationRepository.DeleteApplicationAsync(id, cancellationToken);
                }

                TempData["success"] = "Application deleted successfully!";
            }
            catch (Exception)
            {
                TempData["error"] = "Delete failed!";
            }

            return RedirectToAction(nameof(Index));
        }
    }
}