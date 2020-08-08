using Microsoft.Extensions.Configuration;
using PayPal.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieInformation.Services.ClassImp
{
    public class PayPalHandler
    {
        public readonly Dictionary<string, string> _payPalConfig;
        public PayPalHandler(IConfiguration config)
        {
            _payPalConfig = new Dictionary<string, string>()
         {
        { "clientId" , config.GetSection("paypal:settings:clientId").Value },
        { "clientSecret", config.GetSection("paypal:settings:clientSecret").Value },
        { "mode", config.GetSection("paypal:settings:mode").Value },
        { "business", config.GetSection("paypal:settings:business").Value },
        { "merchantId", config.GetSection("paypal:settings:merchantId").Value },
    };            
        }        
    }
}
