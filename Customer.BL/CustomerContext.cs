using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Customer.BL.Models;
using Microsoft.EntityFrameworkCore;

namespace Customer.BL
{
    public class CustomerContext : DbContext
    {
        public CustomerContext (DbContextOptions<CustomerContext> options)
            : base(options)
        {
        }

        public DbSet<Customer.BL.Models.Customer> Customer { get; set; } = default!;
    }
}
