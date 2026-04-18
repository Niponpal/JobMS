using JobMS.Auth_IdentityModel;
using JobMS.Models.Auth;
using Microsoft.AspNetCore.Identity;

namespace JobMS;

public interface IAuthService
{
    Task<RegistrationResponse> Register(RegisterViewModel model);
}

public class AuthService : IAuthService
{
    private readonly UserManager<User> _userManager;

    public AuthService(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    public async Task<RegistrationResponse> Register(RegisterViewModel request)
    {
        var existingUser = await _userManager.FindByEmailAsync(request.Email);
        if (existingUser != null)
        {
            return new RegistrationResponse
            {
                Success = false,
                Errors = new() { $"Email '{request.Email}' is already registered." }
            };
        }

        var user = new User
        {
            UserName = request.Name,
            Email = request.Email,
            PhoneNumber = request.PhoneNumber,

            // ✅ fix: ImageUrl string, so null রাখলাম (upload পরে handle করবা)
            ImageUrl = null,

            CreatedAt = DateTime.Now,
            EmailConfirmed = true,
            SecurityStamp = Guid.NewGuid().ToString()
        };

        // ✅ fix: PasswordHash use
        var result = await _userManager.CreateAsync(user, request.PasswordHash);

        if (!result.Succeeded)
        {
            return new RegistrationResponse
            {
                Success = false,
                Errors = result.Errors.Select(e => e.Description).ToList()
            };
        }

        await _userManager.AddToRoleAsync(user, "Student");

        return new RegistrationResponse
        {
            Success = true,
            UserId = user.Id.ToString() // ✅ fix long → string
        };
    }
}