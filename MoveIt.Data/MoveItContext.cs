﻿using MoveIt.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace MoveIt.Data
{
    public class MoveItContext : DbContext
    {

        public DbSet<Members> Members { get; set; } = default!;

        public MoveItContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public override int SaveChanges()
        {
            OnBeforeSaveChanges();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            OnBeforeSaveChanges();
            return await base.SaveChangesAsync(cancellationToken);
        }

        private void OnBeforeSaveChanges()
        {
            var entities = ChangeTracker.Entries().Where(x => x.Entity is BaseModel && (x.State == EntityState.Added || x.State == EntityState.Modified)).ToList();

            foreach (var entity in entities)
            {
                if (entity.State == EntityState.Added)
                {
                    ((BaseModel)entity.Entity).CreatedAt = DateTime.Now;
                }

                ((BaseModel)entity.Entity).UpdatedAt = DateTime.Now;
            }
        }
    }
}