using JobMS.Auth_IdentityModel;
using JobMS.Helper;
using JobMS.Models;
using JobMS.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading.Tasks;

namespace JobMS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IJobRepository _jobRepository;
        private readonly ISignInHelper _signInHelper;
        private readonly UserManager<User> _userManager;
        private readonly IApplicationRepository _applicationRepository;



        public HomeController(ILogger<HomeController> logger, IJobRepository jobRepository, ISignInHelper signInHelper, UserManager<User> userManager, IApplicationRepository applicationRepository)
        {
            _logger = logger;
            _jobRepository = jobRepository;
            _signInHelper = signInHelper;
            _userManager = userManager;
            _applicationRepository = applicationRepository;
            

        }

  
        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {

            var jobs = await _jobRepository.GetActiveJobsAsync(cancellationToken);
            if(jobs != null)
            {
                return View(jobs);
            }   
            return NotFound();
        }

        public async Task<IActionResult> Contact(CancellationToken cancellationToken)
        {

            return View();
        }

        public async Task<IActionResult> MyJobs(CancellationToken cancellationToken)
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
                return RedirectToAction("Login", "Account");

            var jobs = await _applicationRepository
                .GetAppliedJobsByUserAsync(user.Id, cancellationToken);

            return View(jobs);
        }


        // JobController.cs
        public async Task<IActionResult> ViewDetails(long id, CancellationToken cancellationToken)
        {
            if (id <= 0)
                return BadRequest();

            var job = await _jobRepository.GetJobsByIdAsync(id, cancellationToken);

            if (job == null)
                return NotFound();

            return View(job);   
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Error404()
        {
            Response.StatusCode = 404;
            return View("404");
        }

    }
}
