using JobMS.Helper;
using JobMS.Models;
using JobMS.Repository;
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



        public HomeController(ILogger<HomeController> logger, IJobRepository jobRepository, ISignInHelper signInHelper)
        {
            _logger = logger;
            _jobRepository = jobRepository;
            _signInHelper = signInHelper;
        }

        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var alljobs = await _jobRepository.GetAllJobsAsync(cancellationToken);
            if (alljobs != null)
            {
                return View(alljobs);
            }
            return NotFound();
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

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
