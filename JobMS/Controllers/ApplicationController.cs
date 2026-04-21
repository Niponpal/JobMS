using JobMS.Auth_IdentityModel;
using JobMS.Models;
using JobMS.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace JobMS.Controllers;

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

  
    [HttpGet]
    public async Task<IActionResult> Index(CancellationToken cancellationToken)
    {
        var data = await _applicationRepository.GetAllApplicationsAsync(cancellationToken);

        if (data == null)
            return NotFound();

        return View(data);
    }

   
    [HttpGet]
    public async Task<IActionResult> CreateOrEdit(long jobId, CancellationToken cancellationToken)
    {
        ViewBag.JobId = await _jobRepository.GetJobDropdownAsync();

        // new application with jobId
        var model = new Application
        {
            JobId = jobId
        };

        return View(model);
    }

   
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateOrEdit(Application application, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.JobId = await _jobRepository.GetJobDropdownAsync();
            return View(application);
        }

        var user = await _userManager.GetUserAsync(User);

        if (user == null)
        {
            return RedirectToAction("Login", "Account");
        }

      
        application.UserId = user.Id;

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
    [ValidateAntiForgeryToken]
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
            return NotFound();

        return View(data);
    }
}