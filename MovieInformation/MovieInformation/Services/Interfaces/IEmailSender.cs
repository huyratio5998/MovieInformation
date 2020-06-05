using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieInformation.Models.Email;

namespace MovieInformation.Services.Interfaces
{
    public interface IEmailSender
    {
        void SendEmail(Message message);
        Task SendEmailAsync(Message message);
    }
}
