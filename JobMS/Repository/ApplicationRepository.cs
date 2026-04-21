using JobMS.Models;
using Microsoft.EntityFrameworkCore;

namespace JobMS.Repository;

public class ApplicationRepository : IApplicationRepository
{
    // Assuming you have an ApplicationDbContext that inherits from DbContext and has a DbSet<Application>

    private readonly ApplicationDbContext _context;
    public ApplicationRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    // Implement the CRUD operations for Application entity
    public async Task<Application> AddApplicationAsync(Application application, CancellationToken cancellationToken)
    {
        var data = await _context.Applications.AddAsync(application, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return application;
    }

    public async Task<Application> DeleteApplicationAsync(long id, CancellationToken cancellationToken)
    {
       var data =await _context.Applications.FindAsync( id, cancellationToken);
        if (data != null)
        {
            _context.Applications.Remove(data);
            await _context.SaveChangesAsync(cancellationToken);
            return data;
        }
        return null;
    }

    public async Task<IEnumerable<Application>> GetAllApplicationsAsync(CancellationToken cancellationToken)
    {
        var data = await _context.Applications.ToListAsync(cancellationToken);
        if (data != null)
        {
            return data;
        }
        return null;
    }

    public async Task<Application?> GetApplicationByIdAsync(long id, CancellationToken cancellationToken)
    {
       var data = await _context.Applications.FindAsync(id, cancellationToken);
        if (data != null)
        {
            return data;
        }
        return null;
    }

    public async Task<Application?> UpdateApplicationAsync(Application application, CancellationToken cancellationToken)
    {
        var data = await _context.Applications.FindAsync(application.Id, cancellationToken);
        if (data != null)
        {
            data.ApplicationId = application.ApplicationId;
            data.Name = application.Name;
            data.PresentSalary = application.PresentSalary;
            data.ExpectionSalary = application.ExpectionSalary;
            data.Degree = application.Degree;
            data.University = application.University;
            data.CGPA = application.CGPA;
            data.CompletionYear = application.CompletionYear;
            data.ResumePath = application.ResumePath;
            //data.UserId = application.UserId;
            data.JobId = application.JobId;
            _context.Applications.Update(data);
            await _context.SaveChangesAsync(cancellationToken);
            return data;
        }
        return null;
    }
    public async Task<bool> IsAlreadyAppliedAsync(long jobId, long userId, CancellationToken cancellationToken)
    {
        return await _context.Applications
            .AnyAsync(x => x.JobId == jobId && x.UserId == userId, cancellationToken);
    }
}
