using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public class PaymentDetailContext : DbContext
    {        
        public PaymentDetailContext(DbContextOptions<PaymentDetailContext> options) : base(options)
        { 
        }

        public DbSet<PaymentDetail> PaymentDetails { get; set; }
        public DbSet<StudentDetails> Students { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<FireAlarm> fireAlarms { get; set; }

    }
}
