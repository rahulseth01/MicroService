using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CustomerService.Models
{
    public partial class devcustomerserverContext : DbContext
    {
        public devcustomerserverContext()
        {
        }

        public devcustomerserverContext(DbContextOptions<devcustomerserverContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Users> Users { get; set; }
    }
}
