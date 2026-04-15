using JobMS.Models;
using JobMS.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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
        var jobs =await _jobRepository.GetAllJobsAsync(cancellationToken);
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
                return NotFound();
            }
            return View(job);
        }
    }
    [HttpPost]
    public async Task<IActionResult> CreateOrEdit(Job job, CancellationToken cancellationToken)
    {
     
            if (job.Id == 0)
            {
                await _jobRepository.AddJobAsync(job, cancellationToken);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                await _jobRepository.UpdateJobAsync(job, cancellationToken);
            }
            return RedirectToAction(nameof(Index));
       
    }
    [HttpPost]
    public async Task<IActionResult> Delete(long id, CancellationToken cancellationToken)
    {
        var job = await _jobRepository.DeleteJobAsync(id, cancellationToken);
        if (job == null)
        {
            return NotFound();
        }
        return RedirectToAction(nameof(Index));
    }
    [HttpGet]   
    public async Task<IActionResult> Details(long id, CancellationToken cancellationToken)
    {
        var job = await _jobRepository.GetJobsByIdAsync(id, cancellationToken);
        if (job == null)
        {
            return NotFound();
        }
        return View(job);
    }

}
