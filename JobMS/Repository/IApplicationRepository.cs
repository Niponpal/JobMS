using JobMS.Models;

namespace JobMS.Repository;

public interface IApplicationRepository
{
    // CRUD operations for Application entity
    Task<IEnumerable<Application>> GetAllApplicationsAsync(CancellationToken cancellationToken);
    Task<Application?> GetApplicationByIdAsync(long id, CancellationToken cancellationToken);
    Task<Application> AddApplicationAsync(Application application, CancellationToken cancellationToken);
    Task<Application?> UpdateApplicationAsync(Application application, CancellationToken cancellationToken);
    Task<Application> DeleteApplicationAsync(long id, CancellationToken cancellationToken);
  
}
