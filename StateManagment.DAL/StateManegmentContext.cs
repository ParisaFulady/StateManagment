using AStateManagment.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace StateManagment.DAL
{
    public class StateManegmentContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=StateManegmentDB;User Id = sa;Password = ABCabc123456;");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Car>().HasChangeTrackingStrategy(ChangeTrackingStrategy.ChangingAndChangedNotifications)
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Person> Person { get; set; }
        public DbSet<Contacts> Contacts { get; set; }
        public DbSet<JobData> JobData { get; set; }
    }
}
