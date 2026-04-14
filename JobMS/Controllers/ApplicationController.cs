using JobMS.Models;
using JobMS.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace JobMS.Controllers;

public class ApplicationController : Controller
{
    private readonly IApplicationRepository _applicationRepository;

    public ApplicationController(IApplicationRepository applicationRepository)
    {
        _applicationRepository = applicationRepository;
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
    public async Task<IActionResult> CreateOrEdit(int id, CancellationToken cancellationToken)
    {
        if (id == 0)
        {
            return View(new Application()); // ✅ FIX HERE
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

        if (application.Id == 0)
        {
            await _applicationRepository.AddApplicationAsync(application, cancellationToken);
            return RedirectToAction(nameof(Index));
        }
        else
        {
            await _applicationRepository.UpdateApplicationAsync(application, cancellationToken);
        }
        return RedirectToAction(nameof(Index));

    }
    [HttpPost]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        await _applicationRepository.DeleteApplicationAsync(id, cancellationToken);
        return RedirectToAction(nameof(Index));
    }
    [HttpGet]
    public async Task<IActionResult> Details(int id, CancellationToken cancellationToken)
    {
        var data = await _applicationRepository.GetApplicationByIdAsync(id, cancellationToken);
        if (data == null)
        {
            return NotFound();
        }
        return View(data);
    }
}
