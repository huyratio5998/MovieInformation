using Microsoft.Extensions.Configuration;
using MovieInformation.Services.Interfaces;
using PayPal.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace MovieInformation.Services.ClassImp
{
    public class PaymentPaypal : IPaymentPaypalService
    {
        private IConfiguration _config;
        private APIContext apiContext;
        private string accessToken;
        public PaymentPaypal(IConfiguration config)
        {
            _config = config;
        }
        public async Task<Payment> CreatePayment()
        {
            var config = new PayPalHandler(_config);
            accessToken = new OAuthTokenCredential(config._payPalConfig).GetAccessToken();
            apiContext = new APIContext(accessToken)
            {
                Config = config._payPalConfig
            };
            var createPayment = new Payment();
            try
            {
                Payment payment = new Payment
                {
                    intent = "sale",
                    payer = new Payer { payment_method = "paypal" },
                    transactions = new List<Transaction>
                    {
                        new Transaction
                        {
                            amount=new Amount{currency="EUR",total="250"},
                            description="Register Vip Account"
                        }
                    },
                    redirect_urls = new RedirectUrls
                    {
                        cancel_url = "https://localhost:44369/PaymentPaypal/CancelPayment",
                        return_url = "https://localhost:44369/PaymentPaypal/ExecutePayment"
                    }
                };
                createPayment = await Task.Run(() => payment.Create(apiContext));
                return createPayment;
            }catch(Exception e)
            {
                throw e;
            }
        }

     

        public async Task<Payment> ExecutePayment(string payerId, string paymentId)
        {
            var config = new PayPalHandler(_config);
            accessToken = new OAuthTokenCredential(config._payPalConfig).GetAccessToken();
            apiContext = new APIContext(accessToken)
            {
                Config = config._payPalConfig
            };
            PaymentExecution paymentExecution = new PaymentExecution()
            {
                payer_id = payerId
            };
            Payment payment = new Payment() { id = paymentId };
            Payment executePayment = await Task.Run(() => payment.Execute(apiContext, paymentExecution));
            return executePayment;
        }
    }
}
