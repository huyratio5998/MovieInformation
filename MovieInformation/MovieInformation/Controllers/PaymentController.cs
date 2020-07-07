using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MovieInformation.Models;
using MovieInformation.Services.Interfaces;
using PayPal.Api;
namespace MovieInformation.Controllers
{
    public class PaymentController : Controller
    {
        private UserManager<MovieInformationUser> _userManager;
        private IPaymentService _paymentService;

        public PaymentController(UserManager<MovieInformationUser> userManager, IPaymentService paymentService)
        {
            _userManager = userManager;
            _paymentService = paymentService;
        }

       public async Task<IActionResult> CreatePayment(string Amount, string Currency)
        {
            try
            {
                var user = await _userManager.GetUserAsync(User);
                var transaction = _paymentService.GetTransactionByUserId(user.Id);
                if (transaction != null)
                {
                    double addAmount = double.Parse(Amount);
                    double tAmount = double.Parse(transaction.amount);
                    tAmount += addAmount;
                    transaction.amount = tAmount.ToString();
                    transaction.expireDate=transaction.expireDate.AddDays(365);
                    _paymentService.UpdateTransaction(transaction);
                }
                else
                {
                    // create transaction
                    var paymentDB = new Models.Payment()
                    {
                        userId = Guid.Parse(user.Id),
                        amount = Amount,
                        currency = Currency,
                        expireDate = DateTime.Now.ToUniversalTime().AddDays(365)
                    };
                    _paymentService.AddTransaction(paymentDB);
                }             
                return RedirectToAction("Index", "Home");
            }catch(Exception e)
            {
                throw e;
            }
        }
       
    }
}