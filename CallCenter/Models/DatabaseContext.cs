using Microsoft.EntityFrameworkCore;

namespace CallCenter.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        protected DatabaseContext()
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Complaint> Complaints { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderClient> OrderClients { get; set; }
        public virtual DbSet<OrderClientDetail> OrderClientDetails { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductClient> ProductClients { get; set; }
        public virtual DbSet<Service> Services { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().HasData(
                new Department { Id = 1, Name = "Department 1" },
                new Department { Id = 2, Name = "Department 2" },
                new Department { Id = 3, Name = "Department 3" },
                new Department { Id = 4, Name = "Department 4" }
            );

            modelBuilder.Entity<Service>().HasData(
                new Service { Id = 1, Name = "Inbound", Price = 4000 },
                new Service { Id = 2, Name = "Outbound", Price = 5000 }
            );

            modelBuilder.Entity<Account>().HasData(
                new Account { Id = 1, Username = "Super admin", Password = BCrypt.Net.BCrypt.HashPassword("123"), Email = "superadmin@gmail.com", Phone = "123", DepartmentId = 1, Role = "super admin", Status = true },
                new Account { Id = 2, Username = "Admin1 1", Password = BCrypt.Net.BCrypt.HashPassword("123"), Email = "admin11@gmail.com", Phone = "123", DepartmentId = 2, Role = "admin 1", Status = true },
                new Account { Id = 3, Username = "Admin2 1", Password = BCrypt.Net.BCrypt.HashPassword("123"), Email = "admin21@gmail.com", Phone = "123", DepartmentId = 3, Role = "admin 2", Status = true },
                new Account { Id = 4, Username = "Customer 1", Password = BCrypt.Net.BCrypt.HashPassword("123"), Email = "customer1@gmail.com", Phone = "123", Role = "customer", Status = true }
            );

            modelBuilder.Entity<Order>().HasData(
                new Order { Id = 1, CustomerId = 4, StaffId = 2, Status = true, Duration = 20 },
                new Order { Id = 2, CustomerId = 4, StaffId = 3, Status = true, Duration = 30 }
            );

            modelBuilder.Entity<Client>().HasData(
                new Client { Id = 1, CustomerId = 4, Name = "Client 1", Description = "Description" },
                new Client { Id = 2, CustomerId = 4, Name = "Client 2", Description = "Description" },
                new Client { Id = 3, CustomerId = 4, Name = "Client 3", Description = "Description" }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, CustomerId = 4, Name = "Product 1" },
                new Product { Id = 2, CustomerId = 4, Name = "Product 2" },
                new Product { Id = 3, CustomerId = 4, Name = "Product 3" }
            );

            modelBuilder.Entity<ProductClient>().HasData(
                new ProductClient { Id = 1, ProductId = 1, ClientId = 1 },
                new ProductClient { Id = 2, ProductId = 2, ClientId = 1 },
                new ProductClient { Id = 3, ProductId = 3, ClientId = 2 },
                new ProductClient { Id = 4, ProductId = 1, ClientId = 2 },
                new ProductClient { Id = 5, ProductId = 3, ClientId = 3 },
                new ProductClient { Id = 6, ProductId = 2, ClientId = 3 }
            );

            modelBuilder.Entity<OrderClient>().HasData(
                new OrderClient { Id = 1, StaffId = 3, OrderId = 2, Description = "abc" },
                new OrderClient { Id = 2, StaffId = 3, OrderId = 2 }
            );

            modelBuilder.Entity<OrderClientDetail>().HasData(
                new OrderClientDetail { Id = 1, OrderClientId = 2, ProductId = 1, Description = "abc" },
                new OrderClientDetail { Id = 2, OrderClientId = 2, ProductId = 3, Description = "abc" }
            );
        }
    }
}
