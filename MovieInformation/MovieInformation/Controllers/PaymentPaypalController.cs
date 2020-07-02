using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using MovieInformation.Services.Interfaces;
using PayPal.Api;

namespace MovieInformation.Controllers
{
    public class PaymentPaypalController : ApiController
    {
        private IPaymentPaypalService _paymentPaypal;

        public PaymentPaypalController(IPaymentPaypalService paymentPaypal)
        {
            _paymentPaypal = paymentPaypal;
        }
        [HttpGet]        
        public async Task<IHttpActionResult> CreatePayment()
        {
            var result = await _paymentPaypal.CreatePayment();            
            foreach (var item in result.links)
            {
                if (item.rel.Equals("approval_url"))
                {
                    return Redirect(item.href);
                   
                }
            }
            return NotFound();           
        }
        [HttpGet]        
        public async Task<IHttpActionResult> ExecutePayment(string paymentId, string token, string PayerID)
        {
            Payment result = await _paymentPaypal.ExecutePayment(PayerID, paymentId);
            return Ok(result);
        }
        [HttpGet]        
        public async Task<IHttpActionResult> CancelPayment()
        {
            return NotFound();
        }
    }
}