using JobMS.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace JobMS.Repository;

public class JobRepository : IJobRepository
{
    private readonly ApplicationDbContext _context;
    public JobRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Job> AddJobAsync(Job job, CancellationToken cancellationToken)
    {
        await _context.Jobs.AddAsync(job, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return job;
    }

    public async Task<Job> DeleteJobAsync(long id, CancellationToken cancellationToken)
    {
       var job = await _context.Jobs.FindAsync(id,cancellationToken);
         if(job == null)
         {
          return null;
        }
         _context.Jobs.Remove(job);
        return job;
    }

    public async Task<IEnumerable<Job>> GetAllJobsAsync(CancellationToken cancellationToken)
    {
       var jobs = await _context.Jobs.ToListAsync(cancellationToken);
        if(jobs == null)
        {
          return null;
        }
        return jobs;
    }

   

    public async Task<Job> GetJobsByIdAsync(long id, CancellationToken cancellationToken)
    {
       var data = await _context.Jobs.FindAsync(id,cancellationToken);
        if(data == null)
        {
          return null;
        }
        return data;
    }

    public async Task<Job> UpdateJobAsync(Job job, CancellationToken cancellationToken)
    {
      var data = await _context.Jobs.FindAsync(job.Id,cancellationToken);
        if(data != null)
        {
            data.JobID = job.JobID;
            data.JobTitle = job.JobTitle;
            data.Description = job.Description;
            data.SalaryRange = job.SalaryRange;
            data.Deadline = job.Deadline;
            data.Status = job.Status;
            await _context.SaveChangesAsync(cancellationToken);
            return data;
        }
        return null;
    }

    // This method is intended to return a list of SelectListItem for populating a dropdown in the UI.

    public async Task<IEnumerable<SelectListItem>> GetJobDropdownAsync()
    {
        var data = await _context.Jobs.Select(x => new SelectListItem
        {
            Text = x.JobTitle,
            Value = x.Id.ToString()
        }).ToListAsync();
        return data;
    }

    public async Task<IEnumerable<Job>> GetActiveJobsAsync(CancellationToken cancellationToken)
    {
        return await _context.Jobs
            .Where(j => j.Status == "Active" &&
                       (j.Deadline == null || j.Deadline >= DateTime.Today))
            .OrderByDescending(j => j.CreatedAt)
            .ToListAsync(cancellationToken);
    }
}
