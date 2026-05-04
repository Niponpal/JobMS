using JobMS.Auth_IdentityModel;
using JobMS.FilesUpload;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace JobMS.Controllers;

[Authorize]
public class UserController : Controller
{
    private readonly UserManager<User> _userManager;
    private readonly IFileService _fileService;

    public UserController(UserManager<User> userManager, IFileService fileService)
    {
        _userManager = userManager;
        _fileService = fileService;
    }


    [HttpGet]
    public IActionResult Index()
    {
        var users = _userManager.Users.ToList();
        return View(users);
    }

    // ✅ Show user details
    [HttpGet]
    public async Task<IActionResult> Details()
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null) return NotFound();

        return View(user);
    }

    // ✅ Load Edit Page with existing data
    [HttpGet]
    public async Task<IActionResult> EditProfile()
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null) return NotFound();

        return View(user);
    }

    // ✅ Update Profile
    [HttpPost]
    public async Task<IActionResult> EditProfile(User model, IFormFile? ProfileImage)
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null) return NotFound();

        // Update name
        user.UserName = model.UserName;

        // Update image
        if (ProfileImage != null && ProfileImage.Length > 0)
        {
            // 🔥 delete old image
            if (!string.IsNullOrEmpty(user.ImageUrl))
            {
                _fileService.DeleteFile(
                    Path.GetFileName(user.ImageUrl),
                    "Images"
                );
            }

            // upload new image
            user.ImageUrl = await _fileService.Upload(ProfileImage, "Images");
        }

        await _userManager.UpdateAsync(user);

        return RedirectToAction("Details");
    }
}


