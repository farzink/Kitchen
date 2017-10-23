using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Kitchen.Api.Filter;
using Kitchen.CommonModel.Identity;
using Kitchen.CommonModel.ViewModel;
using Kitchen.CoreService.Service;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Kitchen.Api.Controllers
{
    [EnableCors("CorsPolicy")]
    [Route("api/[controller]")]
    public class AuthenticationController : Controller
    {
        private SignInManager<ApplicationUser> signInManager;
        private UserManager<ApplicationUser> userManager;
        private IConfiguration configuration;
        private ProfileService profileService;

        public AuthenticationController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, IConfigurationRoot configuration, ProfileService profileService)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.configuration = configuration;
            this.profileService = profileService;
        }
        [ValidateModel]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel model)
        {
            try
            {
                //should be later on changed to a transaction
                var profileViewModel = new ProfileViewModel
                {
                    Firstname = model.FirstName,
                    Lastname = model.LastName,
                    Email = model.Email
                };
                var resultModel = await profileService.AddAsync(profileViewModel);
                if (resultModel.Item == null)
                    throw new Exception();

                var user = new ApplicationUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    ProfileId = resultModel.Item.Id
                };
                var result = await userManager.CreateAsync(user, model.Password);
                if (!result.Succeeded)
                {
                    await profileService.DeleteAsync(resultModel.Item);
                    return BadRequest();
                }
                await userManager.AddClaimsAsync(user, new List<Claim>
                    {
                        new Claim("pid", resultModel.Item.Id.ToString()),
                        new Claim("email", resultModel.Item.Email),
                        new Claim("firstname", resultModel.Item.Firstname),
                        new Claim("lastname", resultModel.Item.Lastname)
                    });
                //await mailService.SendAsync(model.Email, "successfully refistered", "registration notice");
                return Ok(resultModel.Item);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        [HttpPost("token")]
        public async Task<IActionResult> CreateToken([FromBody] RegisterViewModel model)
        {
            try
            {
                var user = await userManager.FindByNameAsync(model.Email);
                if (user != null)
                {
                    //if (_hasher.VerifyHashedPassword(user, user.PasswordHash, model.Password) == PasswordVerificationResult.Success)
                    if (await userManager.CheckPasswordAsync(user, model.Password))
                    {
                        var userClaims = await userManager.GetClaimsAsync(user);

                        var claims = new[]
                        {
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                        }.Union(userClaims);

                        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Tokens:Key"]));
                        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                        var token = new JwtSecurityToken(
                          issuer: configuration["Tokens:Issuer"],
                          audience: configuration["Tokens:Audience"],
                          claims: claims,
                          expires: DateTime.UtcNow.AddDays(60),
                          signingCredentials: creds
                          );

                        return Ok(new
                        {
                            token = new JwtSecurityTokenHandler().WriteToken(token),
                            expiration = token.ValidTo
                        });
                    }
                }

            }
            catch (Exception ex)
            {
                //_logger.LogError($"Exception thrown while creating JWT: {ex}");
            }

            return BadRequest("Failed to generate token");
        }
    }

    public class RegisterViewModel
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [Required(ErrorMessage = "password cant be empty")]
        [MinLength(8, ErrorMessage = "password must have at least 8 characters")]
        public string Password { get; set; }
        [Required(ErrorMessage = "first name cant be empty")]
        [MaxLength(64, ErrorMessage = "first name cant be longer than 64")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "last name cant be empty")]
        [MaxLength(64, ErrorMessage = "last name cant be longer than 64")]
        public string LastName { get; set; }
    }
}
