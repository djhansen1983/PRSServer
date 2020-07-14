using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PRS_Server.Models
{
    public class prsDbAppContext : DbContext
    {

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Vendor> Vendors { get; set; }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<Request> Requests { get; set; }

        public virtual DbSet<Requestline> Requestlines { get; set; }

        public prsDbAppContext() { } //constructor

        public prsDbAppContext(DbContextOptions<prsDbAppContext> options)
            : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connStr = @"server=localhost\sqlexpress;database=PRSDB;trusted_connection=true;";

                optionsBuilder.UseLazyLoadingProxies();

                optionsBuilder.UseSqlServer(connStr);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vendor>(e =>
            {
                e.HasIndex("Code").IsUnique();
            });

            modelBuilder.Entity<User>(e =>
            {
                e.HasIndex("Username").IsUnique();
            });

            modelBuilder.Entity<Product>(e =>
            {
                e.HasIndex("PartNbr").IsUnique();
            });
        }
    }
}
