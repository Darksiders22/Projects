using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Models;
using Models.Interfaces;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Data
{
    public class StoreDbContext : DbContext
    {
        private IConfigurationRoot configuration { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<SaleOrder> SalesOrders { get; set; }
        public StoreDbContext()
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeCustomers>().HasOne(x => x.Employee).WithMany(x => x.EmployeeCustomers).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<EmployeeCustomers>().HasOne(x => x.Customer).WithMany(x => x.EmployeeCustomers).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Person>().HasData(new Person() { FirstName = "Maria", LastName = "Marinova", Email = "marinova@gmail.com", Password = "skalichka", Id = 65, CreatedAt = DateTime.Now });
            modelBuilder.Entity<Employee>().HasData(new Employee() { EmployeeNumber = "007", DepartmentId = 555, Telephone = "0895698741", PersonId = 65, Id = 1, CreatedAt = DateTime.Now });
            modelBuilder.Entity<Product>().HasData(new Product() { ProductName = "AR-15", Description = "Modern US riffle with 5.56 rounds.", CurrentQuantity = 10, CreatedAt = DateTime.Now,Id=4 },
                new Product() { ProductName = "Glock20", Description = "Moder 9mm pistol with selectable modes.", CurrentQuantity = 8, CreatedAt = DateTime.Now,Id=1 },
                new Product() { ProductName = "ASVAL", Description = "Russian rifle using a rare 9.39mm round restricted for use", CurrentQuantity = 1, CreatedAt = DateTime.Now ,Id=2,});
      
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            configuration = new ConfigurationBuilder().SetBasePath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)).AddJsonFile("appsettings.json").Build();
            optionsBuilder.UseSqlServer(this.configuration.GetConnectionString("DefaultConnection"));
        }
        public override int SaveChanges()
        {

            return this.SaveChanges(true);
        }
        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            this.ApplyEntityChanges();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }
        private void ApplyEntityChanges()
        {
            var entries = this.ChangeTracker.Entries().Where(x => x.Entity is IAuditInfo && x.State == EntityState.Added || x.State == EntityState.Deleted || x.State == EntityState.Modified).ToList();

            foreach (var entry in entries)
            {
                var entity = (IAuditInfo)entry.Entity;

                if (entry.State == EntityState.Added)
                {
                    entity.CreatedAt = DateTime.Now;
                }
                else if (entry.State == EntityState.Deleted)
                {
                    entity.DeletedAt = DateTime.Now;

                }
                else
                {
                    entity.ModifiedAt = DateTime.Now;
                }
            }
        }

    }
}