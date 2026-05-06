using JobMS.Auth_IdentityModel;
using JobMS.FilesUpload;
using JobMS.Models.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace JobMS.Controllers;

public class AccountController : Controller
{
    private readonly SignInManager<User> _signInManager;
    private readonly UserManager<User> _userManager;
    private readonly IAuthService _authService;
    private readonly IFileService _fileService;

    public AccountController(
        SignInManager<User> signInManager,
        UserManager<User> userManager,
        IAuthService authService,
        IFileService fileService)
    {
        _signInManager = signInManager;
        _userManager = userManager;
        _authService = authService;
        _fileService = fileService;
    }

    // ================= REGISTER GET =================
    [HttpGet]
    [AllowAnonymous]
    public IActionResult Register()
    {
        return View(new RegisterViewModel());
    }


    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        string? imageFileName = null;

        if (model.ImageFile != null)
        {
            imageFileName = await _fileService.Upload(model.ImageFile, "uploads/users");
        }

        var result = await _authService.Register(model, imageFileName);

        if (!result.Success)
        {
            result.Errors.ForEach(e => ModelState.AddModelError("", e));
            return View(model);
        }

        var user = await _userManager.FindByEmailAsync(model.Email);

        if (user != null)
        {
            user.ImageUrl = imageFileName; // ✅ FIXED HERE
            await _userManager.UpdateAsync(user);

            await _signInManager.SignInAsync(user, isPersistent: false);
        }

        TempData["success"] = "Registration successful!";
        return RedirectToAction("Index", "Home");
    }

    // ================= LOGIN GET =================
    [HttpGet]
    [AllowAnonymous]
    public IActionResult Login()
    {
        return View();
    }

    // ================= LOGIN POST =================
    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var user = await _userManager.FindByEmailAsync(model.Email);
        if (user == null)
        {
            TempData["error"] = "Invalid login attempt.";
            return View(model);
        }

        var result = await _signInManager.PasswordSignInAsync(
            user,
            model.Password,
            isPersistent: false,
            lockoutOnFailure: false
        );

        if (result.Succeeded)
        {
            var roles = await _userManager.GetRolesAsync(user);
            var roleName = roles.FirstOrDefault();

            TempData["success"] = "Login successful!";

            if (roleName == "Employer" || roleName == "Administrator")
                return RedirectToAction("Index", "Dashboard");

            return RedirectToAction("Index", "Home");
        }

        TempData["error"] = "Invalid login attempt.";
        return View(model);
    }

    // ================= LOGOUT =================
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();

        TempData["info"] = "Logged out successfully!";
        return RedirectToAction("Index", "Home");
    }

    // ================= ACCESS DENIED =================
    [HttpGet]
    [AllowAnonymous]
    public IActionResult AccessDenied()
    {
        return View();
    }
}