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

        public bool UpdateTransaction(Payment payment)
        {
            try
            {
                _context.Entry(payment).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool CheckUserVipAccount(string Id)
        {
            Guid id = Guid.Parse(Id);
            var check = _context.Payments.FirstOrDefault(x => x.userId==id);
            if (check!=null) return true;
            return false;
        }
        public Payment GetTransactionByUserId(string userId)
        {
            Guid UserId = Guid.Parse(userId);
            var result = _context.Payments.FirstOrDefault(x => x.userId==UserId);
            if (result != null) return result;
            return null;
        }

      
    }
}
