using GShop.GarmentsShop;
using GShop.UsersMgt;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GShop
{
    public class GarmentsContext : DbContext 
    {

        public GarmentsContext()  : base("ConStr")
        {
            Configuration.LazyLoadingEnabled = false;
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // many to many
            modelBuilder.Entity<Product>()
                .HasMany<Color>(p => p.ColorsOffered)
                .WithMany();

            // many to many
            modelBuilder.Entity<Product>()
                .HasMany<Size>(p => p.SizesOffered)
                .WithMany();

            // 1 to 1
            modelBuilder.Entity<User>()
                .HasOptional<Address>(u => u.Address)
                .WithRequired();






        }
        
        public DbSet<UserAccountStatus> userAccountStatuses { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<City> Cities { get; set; }

        public DbSet<Role>  Roles { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<SubCategory> SubCategories { get; set; }

        public DbSet<Color> Colors { get; set; }

        public DbSet<Size> Sizes { get; set; }

        public DbSet<Fabric> Fabrics { get; set; }

        public DbSet<Product> Products { get; set; }






    }
}
