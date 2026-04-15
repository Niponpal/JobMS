using JobMS.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace JobMS.Repository
{
    public interface IJobRepository
    { 
        Task<IEnumerable<Job>> GetAllJobsAsync(CancellationToken cancellationToken);
        Task<Job> GetJobsByIdAsync(long id, CancellationToken cancellationToken);
        Task<Job> AddJobAsync(Job job, CancellationToken cancellationToken);
        Task<Job> UpdateJobAsync(Job job, CancellationToken cancellationToken);
        Task<Job> DeleteJobAsync(long id, CancellationToken cancellationToken);
        Task<IEnumerable<SelectListItem>> GetJobDropdownAsync();
    }
}

