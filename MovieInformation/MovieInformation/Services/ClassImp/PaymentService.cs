using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using MovieInformation.Data;
using MovieInformation.Models;
using MovieInformation.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MovieInformation.Services.ClassImp
{
    public class PaymentService : IPaymentService
    {        
        private ApplicationDbContext _context;
        public PaymentService(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool AddTransaction(Payment payment)
        {
            try
            {
                _context.Payments.Add(payment);
                _context.SaveChanges();
                return true;
            }
            catch(Exception e)
            {                
                return false;                
            }
                        
        }

        public bool CheckUserVipAccount(string Id)
        {
            var check = _context.Payments.Any(x => x.userId.ToString().Equals(Id.Trim()));
            return check;
        }
    }
}
