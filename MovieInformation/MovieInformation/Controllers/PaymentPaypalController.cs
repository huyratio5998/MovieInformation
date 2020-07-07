using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieInformation.Services.Interfaces;
using PayPal.Api;

namespace MovieInformation.Controllers
{
    public class PaymentPaypalController : Controller
    {
        private IPaymentPaypalService _paymentPaypal;

        public PaymentPaypalController(IPaymentPaypalService paymentPaypal)
        {           
            _paymentPaypal = paymentPaypal;
        }
        [HttpGet]        
        public async Task<IActionResult> CreatePayment()
        {
            var result = await _paymentPaypal.CreatePayment();            
            foreach (var item in result.links)
            {
                if (item.rel.Equals("approval_url"))
                {                    
                    return Redirect(item.href);                                       
                }
            }
            return RedirectToAction("Index","Home"); ;           
        }      
        [HttpGet]        
        public async Task<IActionResult> ExecutePayment(string paymentId, string token, string PayerID)
        {
            Payment result = await _paymentPaypal.ExecutePayment(PayerID, paymentId);
            return RedirectToAction("PaySuccess","Home");
        }
        [HttpGet]        
        public async Task<IActionResult> CancelPayment()
        {
            return  RedirectToAction("Index","Home");
        }
    }
}