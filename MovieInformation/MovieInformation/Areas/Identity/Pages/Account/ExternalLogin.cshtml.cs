using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MovieInformation.Models;
using MovieInformation.Services.ApiModels.Requests;
using MovieInformation.Services.ApiModels.Responses;
using MovieInformation.Services.Interfaces;

namespace MovieInformation.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class ExternalLoginModel : PageModel
    {
        private readonly SignInManager<MovieInformationUser> _signInManager;
        private readonly UserManager<MovieInformationUser> _userManager;
        private readonly IEmailSender _emailSender;
        private readonly ILogger<ExternalLoginModel> _logger;
        private  IUserSessionService _userSessionService;
        private readonly string _api_key;
        private readonly IConfiguration _config;

        public ExternalLoginModel(
            SignInManager<MovieInformationUser> signInManager,
            UserManager<MovieInformationUser> userManager,
            ILogger<ExternalLoginModel> logger,
            IEmailSender emailSender, IUserSessionService userSessionService,
            IConfiguration config)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _logger = logger;
            _config = config;
            _emailSender = emailSender;
            _userSessionService = userSessionService;
            _api_key = _config.GetValue<string>("AppSettings:Api_Key");
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string LoginProvider { get; set; }

        public string ReturnUrl { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }
            public string Birthday { get; set; }
            public string Picture { get; set; }
            public string Name { get; set; }
            public string Gender { get; set; }            
        }

        public IActionResult OnGetAsync()
        {
            return RedirectToPage("./Login");
        }

        public IActionResult OnPost(string provider, string returnUrl = null)
        {
            // Request a redirect to the external login provider.
            var redirectUrl = Url.Page("./ExternalLogin", pageHandler: "Callback", values: new { returnUrl="" });
            var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
            return new ChallengeResult(provider, properties);
        }
    
        public async Task<IActionResult> OnGetCallbackAsync(string returnUrl = null, string remoteError = null)
        {
            
            returnUrl = returnUrl?? Url.Content("~/Home/Index");
            if (remoteError != null)
            {
                ErrorMessage = $"Error from external provider: {remoteError}";
                return RedirectToPage("./Login", new {ReturnUrl = returnUrl });
            }
            var info = await _signInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                ErrorMessage = "Error loading external login information.";
                return RedirectToPage("./Login", new { ReturnUrl = returnUrl });
            }

            // Sign in the user with this external login provider if the user already has a login.
            var result = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false, bypassTwoFactor : true);
            if (result.Succeeded)
            {
                // create new guessSession when login
                //var user = await _userManager.GetUserAsync(User);
                //if (user == null)
                //{
                //    return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
                //}
                //MovieRequest request = new MovieRequest();
                //request.Api_key = _api_key;
                //var createGuessSession =await _userSessionService.CreateGuessSession(request);
                //user.Guest_session_id = createGuessSession.Guest_session_id;                
                //var update = await _userManager.UpdateAsync(user);               
                _logger.LogInformation("{Name} logged in with {LoginProvider} provider.", info.Principal.Identity.Name, info.LoginProvider);

                return LocalRedirect(returnUrl);
            }
            if (result.IsLockedOut)
            {
                return RedirectToPage("./Lockout");
            }
            else
            {             
                // If the user does not have an account, then ask the user to create an account.
                ReturnUrl = returnUrl;
                LoginProvider = info.LoginProvider;
                var email = info.Principal.FindFirstValue(ClaimTypes.Email)?? "";
                var name = info.Principal.FindFirstValue(ClaimTypes.Name) ?? "";
                var dob = info.Principal.FindFirstValue(ClaimTypes.DateOfBirth) ?? "";
                var gender = info.Principal.FindFirstValue(ClaimTypes.Gender) ?? "";
                var identifier = info.Principal.FindFirstValue(ClaimTypes.NameIdentifier) ?? "";
                string picture;
                switch (LoginProvider)
                {
                    case "Facebook":
                        picture = $"https://graph.facebook.com/{identifier}/picture?type=large";
                        break;
                    case "Google":                        
                            picture = info.Principal.FindFirstValue("picture");
                            break;                    
                    default:
                        picture = "";
                        break;
                }
                
                Input= new InputModel
                {
                    Email = email, //User Email  
                    Name = name, //user Display Name  
                    Birthday = dob.ToString(), //User DOB  
                    Gender = gender, //User Gender  
                    Picture = picture //User Profile Image  
                };
                return Page();
                
            }
        }

        public async Task<IActionResult> OnPostConfirmationAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/Home/Index");
            // Get the information about the user from the external login provider
            var info = await _signInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                ErrorMessage = "Error loading external login information during confirmation.";
                return RedirectToPage("./Login", new { ReturnUrl = returnUrl });
            }

            if (ModelState.IsValid)
            {
                var user = new MovieInformationUser { UserName = Input.Email, Email = Input.Email, Nickname=Input.Name,Birthday=Input.Birthday,Gender=Input.Gender,Picture=Input.Picture };
                var result = await _userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    result = await _userManager.AddLoginAsync(user, info);
                    if (result.Succeeded)
                    {
                        _logger.LogInformation("User created an account using {Name} provider.", info.LoginProvider);

                        var userId = await _userManager.GetUserIdAsync(user);
                        var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                        code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                        //var callbackUrl = Url.Page(
                        //    "/Account/ConfirmEmail",
                        //    pageHandler: null,
                        //    values: new { area = "Identity", userId = userId, code = code },
                        //    protocol: Request.Scheme);

                        //await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        //    $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                        // If account confirmation is required, we need to show the link if we don't have a real email sender
                        //if (_userManager.Options.SignIn.RequireConfirmedAccount)
                        //{
                        //    return RedirectToPage("./RegisterConfirmation", new { Email = Input.Email });
                        //}

                        var currentUser = await _userManager.FindByIdAsync(userId);
                        if (currentUser == null)
                        {
                            return NotFound($"Unable to load user with ID '{userId}'.");
                        }

                        var currentCode = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));
                        var confirmEmail = await _userManager.ConfirmEmailAsync(user, currentCode);
                        if (confirmEmail.Succeeded)
                        {
                            await _signInManager.SignInAsync(user, isPersistent: false, info.LoginProvider);
                            return LocalRedirect(returnUrl);
                        }
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            LoginProvider = info.LoginProvider;
            ReturnUrl = returnUrl;
            return Page();
        }
    }
}
