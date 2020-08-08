using PayPal.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace MovieInformation.Services.Interfaces
{
    public interface IPaymentPaypalService
    {        
        Task<Payment> CreatePayment();
        Task<Payment> ExecutePayment(string payerId, string paymentId);
    }
}
