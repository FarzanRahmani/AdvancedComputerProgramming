using Microsoft.EntityFrameworkCore;
using Shop.Core; // baraye inke Clothe ro beshnase
// using P8.Server.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Data
{
    public class ShopContext : DbContext
    {
        public ShopContext(DbContextOptions<ShopContext> options)
        : base(options)
        {}
        public DbSet<Clothe> Clothes { get; set; } // DBSet --> table --> attribute(column) - tuple(record-row)
        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            ChangeTracker.DetectChanges();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
    }
}