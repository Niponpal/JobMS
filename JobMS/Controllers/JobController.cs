using JobMS.Models;
using JobMS.Repository;
using Microsoft.AspNetCore.Mvc;

namespace JobMS.Controllers;

public class JobController : Controller
{
    private readonly IJobRepository _jobRepository;

    public JobController(IJobRepository jobRepository)
    {
        _jobRepository = jobRepository;
    }

    [HttpGet]
    public async Task<IActionResult> Index(CancellationToken cancellationToken)
    {
        var jobs = await _jobRepository.GetAllJobsAsync(cancellationToken);
        return View(jobs);
    }

    [HttpGet]
    public async Task<IActionResult> CreateOrEdit(long id, CancellationToken cancellationToken)
    {
        if (id == 0)
        {
            return View(new Job());
        }
        else
        {
            var job = await _jobRepository.GetJobsByIdAsync(id, cancellationToken);
            if (job == null)
            {
                TempData["error"] = "Job not found!";
                return RedirectToAction(nameof(Index));
            }
            return View(job);
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrEdit(Job job, CancellationToken cancellationToken)
    {
        try
        {
            if (job.Id == 0)
            {
                await _jobRepository.AddJobAsync(job, cancellationToken);
                TempData["success"] = "Job created successfully!";
            }
            else
            {
                await _jobRepository.UpdateJobAsync(job, cancellationToken);
                TempData["success"] = "Job updated successfully!";
            }
        }
        catch (Exception)
        {
            TempData["error"] = "Something went wrong!";
        }

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<IActionResult> Delete(long id, CancellationToken cancellationToken)
    {
        try
        {
            var job = await _jobRepository.DeleteJobAsync(id, cancellationToken);

            if (job == null)
            {
                TempData["error"] = "Job not found!";
            }
            else
            {
                TempData["success"] = "Job deleted successfully!";
            }
        }
        catch (Exception)
        {
            TempData["error"] = "Delete failed!";
        }

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Details(long id, CancellationToken cancellationToken)
    {
        var job = await _jobRepository.GetJobsByIdAsync(id, cancellationToken);
        if (job == null)
        {
            TempData["error"] = "Job not found!";
            return RedirectToAction(nameof(Index));
        }
        return View(job);
    }
}