using JobMS.Auth_IdentityModel;
using JobMS.Models;
using JobMS.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace JobMS.Controllers;

public class ApplicationController : Controller
{
    private readonly IApplicationRepository _applicationRepository;
    private readonly IJobRepository _jobRepository;
    private readonly UserManager<User> _userManager;

    public ApplicationController(IApplicationRepository applicationRepository, IJobRepository jobRepository, UserManager<User> userManager)
    {
        _applicationRepository = applicationRepository;
        _jobRepository = jobRepository;
        _userManager = userManager;
    }

    [HttpGet]
    public async Task<IActionResult> Index(CancellationToken cancellationToken)
    {
        var data = await _applicationRepository.GetAllApplicationsAsync(cancellationToken);
        if (data == null)
        {
            return NotFound();
        }
        return View(data);
    }

    [HttpGet]
    public async Task<IActionResult> CreateOrEdit(long id, CancellationToken cancellationToken)
    {
           ViewBag.JobId = await _jobRepository.GetJobDropdownAsync();
        if (id == 0)
        {
            return View(new Application());
        }

        var data = await _applicationRepository.GetApplicationByIdAsync(id, cancellationToken);
        if (data == null)
        {
            return NotFound();
        }

        return View(data);
    }
    [HttpPost]
    public async Task<IActionResult> CreateOrEdit(Application application, CancellationToken cancellationToken)
    {
        ViewBag.JobId = await _jobRepository.GetJobDropdownAsync();

        var user = await _userManager.GetUserAsync(User);

        if (user == null)
        {
            return RedirectToAction("Login", "Account");
        }

        application.UserId = user.Id; // ? SAFE LONG TYPE

        if (application.Id == 0)
        {
            await _applicationRepository.AddApplicationAsync(application, cancellationToken);
        }
        else
        {
            await _applicationRepository.UpdateApplicationAsync(application, cancellationToken);
        }

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<IActionResult> Delete(long id, CancellationToken cancellationToken)
    {
        await _applicationRepository.DeleteApplicationAsync(id, cancellationToken);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Details(long id, CancellationToken cancellationToken)
    {
        var data = await _applicationRepository.GetApplicationByIdAsync(id, cancellationToken);
        if (data == null)
        {
            return NotFound();
        }

        return View(data);
    }
}