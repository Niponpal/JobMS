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

    public async Task<IActionResult> Index(CancellationToken cancellationToken)
    {
        var data = await _applicationRepository.GetAllApplicationsAsync(cancellationToken);
        if (data == null)
        {
            return NotFound();
        }
        return View(data);
    }
}
