using Mango.Services.Email.DbContexts;
using Mango.Services.Email.Messages;
using Mango.Services.Email.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mango.Services.Email.Repository
{
    public class EmailRepository : IEmailRepository
    {
        private readonly DbContextOptions<ApplicationDbContext> _dbContext;

        public EmailRepository(DbContextOptions<ApplicationDbContext> dbContext)
        {
            _dbContext = dbContext;
        }

        public object Emaillog { get; private set; }

        public async Task SendAndLogEmail(UpdatePaymentResultMessage message)
        {
            //implement an email sender

            //log email sent
            EmailLog emaillog = new EmailLog()
            {
                Email = message.Email,
                EmailSent = DateTime.Now,
                Log = $"Order - {message.OrderId} has been created successfully"
            };

            await using var _db = new ApplicationDbContext(_dbContext);
            _db.EmailLogs.Add(emaillog);
            await _db.SaveChangesAsync();
        }
    }
}
