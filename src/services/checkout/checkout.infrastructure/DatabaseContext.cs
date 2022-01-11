using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using checkout.domain.PaymentAggregate;
using Microsoft.EntityFrameworkCore;

namespace checkout.infrastructure
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }
        public DbSet<InvoiceAddress> InvoiceAddresses { get; set; }
        public DbSet<Payment> Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.UseSerialColumns();
            base.OnModelCreating(modelBuilder);
        }
    }
}
