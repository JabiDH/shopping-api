using Microsoft.AspNetCore.Identity;
using ShoppingCart.Dtos.Auth;
using ShoppingCart.Services.Token;
using System.Text;

namespace ShoppingCart.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly ITokenService tokenService;
        public AuthService(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, ITokenService tokenService)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.tokenService = tokenService;
        }


        public async Task<RegisterResponseDto> RegisterAsync(RegisterRequestDto request)
        {
            // Check if user exist
            var user = await userManager.FindByEmailAsync(request.Email);
            if (user != null) 
            {
                return new RegisterResponseDto()
                {
                    Error = "User already exist. Please login."
                };
            }

            // Check roles
            if (AreValidRoles(request.Roles))
            {
                // Create user                       
                var identityUser = new IdentityUser() { Email = request.Email, UserName = request.Email };
                var identityResult = await userManager.CreateAsync(identityUser, request.Password);

                if (!identityResult.Succeeded)
                {
                    var error = $"User registration failed. {GetIdentityErrorMessage(identityResult)}";
                    return new RegisterResponseDto() { Error = error };
                }

                identityResult = await userManager.AddToRolesAsync(identityUser, request.Roles);
                if (!identityResult.Succeeded)
                {
                    var error = $"User registration Succeed. But no roles added, check roles. {GetIdentityErrorMessage(identityResult)}";
                    return new RegisterResponseDto() { Error = error };
                }

                return new RegisterResponseDto() { Email = identityUser.Email };
            }
            else 
            {
                return new RegisterResponseDto() { Error = "User registration failed. Invalid roles." };
            }            
        }

        public async Task<LoginResponseDto> LoginAsync(LoginRequestDto request)
        {
            var user = await userManager.FindByEmailAsync(request.Email);

            if (user != null) 
            {
                // Check password
                var correctPassword = await userManager.CheckPasswordAsync(user, request.Password);
                if (correctPassword)
                {
                    var roles = await userManager.GetRolesAsync(user);
                    if (roles != null)
                    {                        
                        var token = tokenService.CreateJwtToken(user, roles.ToList(), request.ExpireOn);
                        return new LoginResponseDto()
                        {
                            Token = token,
                            Email = request.Email,                            
                            ExpireOnInSeconds = request.ExpireOn
                        };
                    }
                }
            }

            return new LoginResponseDto()
            {
                Error = "Incorrect email or password.",
                Email = request.Email
            };
        }

        private string GetIdentityErrorMessage(IdentityResult identityResult)
        {
            StringBuilder errBuilder = new StringBuilder();
            foreach (IdentityError err in identityResult.Errors)
            {
                errBuilder.AppendLine($"{err.Code}: {err.Description}");
            }
            return errBuilder.ToString();
        }

        private bool AreValidRoles(string[] roles) 
        {
            if (roles == null || roles.Length == 0) 
            {
                return false; 
            }

            bool areValid = true;
            if (roles != null && roles.Length > 0) 
            {
                var existingRoles = roleManager.Roles.Select(r => r.Name.ToLower()).ToList();
                foreach (string role in roles)
                {
                    if (!existingRoles.Contains(role.ToLower()))
                    {
                        areValid = false;
                        break;
                    }                    
                }
            }

            return areValid;
        }
    }
}
