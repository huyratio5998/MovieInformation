using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieInformation.Models;
using MovieInformation.Services.Interfaces;

namespace MovieInformation.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<MovieInformationUser> _userManager;
        private readonly SignInManager<MovieInformationUser> _signInManager;
        private readonly IPaymentService _paymentService;

        public IndexModel(
            UserManager<MovieInformationUser> userManager,
            SignInManager<MovieInformationUser> signInManager,
            IPaymentService paymentService
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _paymentService = paymentService;
        }

        public string Username { get; set; }
        public string ExpireDate { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }
            public string Birthday { get; set; }
            public string Picture { get; set; }
            public string Name { get; set; }
            public string Gender { get; set; }
            public string Username { get; set; }
        }

        private async Task LoadAsync(MovieInformationUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            var vipInfor = _paymentService.GetTransactionByUserId(user.Id);
            ViewData["CountTimeExpire"] = 0;
            if (vipInfor != null) {
                ViewData["CountTimeExpire"] = (vipInfor.expireDate - DateTime.Now.ToUniversalTime()).TotalDays.ToString("0.00");
                ExpireDate = vipInfor.expireDate.ToString("dd-MM-yyyy");
            }
            //Username = userName;

            Input = new InputModel
            {
                Username = userName,
                PhoneNumber = phoneNumber,
                Birthday=user.Birthday,
                Picture=user.Picture,
                Name=user.Nickname,
                Gender=user.Gender
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            //var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            //if (Input.PhoneNumber != phoneNumber)
            //{
            //    var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
            //    if (!setPhoneResult.Succeeded)
            //    {
            //        StatusMessage = "Unexpected error when trying to set phone number.";
            //        return RedirectToPage();
            //    }
            //}
            user.Gender = Input.Gender;
            user.Birthday = Input.Birthday;
            user.PhoneNumber = Input.PhoneNumber;
            user.Nickname = Input.Name;
            user.UserName = Input.Username;
            var update= await _userManager.UpdateAsync(user);
            if (!update.Succeeded)
            {
                StatusMessage = "Unexpected error when trying to update user information.";
                return RedirectToPage();
            }
            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}
