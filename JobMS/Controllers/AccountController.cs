using JobMS.Auth_IdentityModel;
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

    public AccountController(
        SignInManager<User> signInManager,
        UserManager<User> userManager,
        IAuthService authService)
    {
        _signInManager = signInManager;
        _userManager = userManager;
        _authService = authService;
    }

    // ================= REGISTER GET =================
    [HttpGet]
    [AllowAnonymous]
    public IActionResult Register()
    {
        return View(new RegisterViewModel());
    }

    // ================= REGISTER POST =================
    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var result = await _authService.Register(model);

        if (!result.Success)
        {
            result.Errors.ForEach(e => ModelState.AddModelError("", e));
            TempData["error"] = "Registration failed!";
            return View(model);
        }

        // AUTO LOGIN AFTER REGISTER
        var user = await _userManager.FindByEmailAsync(model.Email);

        if (user != null)
        {
            await _signInManager.SignInAsync(user, isPersistent: false);
        }

        TempData["success"] = "Registration successful!";
        return RedirectToAction("Index", "Dashboard");
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

        var result = await _signInManager.PasswordSignInAsync(
            model.Email,
            model.Password,
            isPersistent: false,
            lockoutOnFailure: false
        );

        if (result.Succeeded)
        {
            TempData["success"] = "Login successful!";
            return RedirectToAction("Index", "Dashboard");
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