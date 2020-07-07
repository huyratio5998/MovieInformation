using MovieInformation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieInformation.Services.Interfaces
{
    public interface IPaymentService
    {
        bool AddTransaction(Payment payment);
        bool UpdateTransaction(Payment payment);
        bool CheckUserVipAccount(string Id);
        Payment GetTransactionByUserId(string userId);
    }
}
