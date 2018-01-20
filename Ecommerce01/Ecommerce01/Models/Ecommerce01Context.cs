using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Ecommerce01.Models
{
    public class Ecommerce01Context : DbContext
    {
        //DefaultConnection: in Web.config
        public Ecommerce01Context() : base("DefaultConnection")
        {
        }

        public DbSet<Departament> Departaments { get; set; }
        
        public DbSet<Province> Provinces { get; set; }

        //public DbSet<City> Cities { get; set; }
        //add
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //for department
            modelBuilder.Entity<Departament>()
                .Property(d => d.Latitud)
                .HasPrecision(18, 6);
            modelBuilder.Entity<Departament>()
               .Property(d => d.Longitud)
               .HasPrecision(18, 6);

            //for province
            modelBuilder.Entity<Province>()
                     .Property(p => p.Latitud)
                     .HasPrecision(18, 6);
            modelBuilder.Entity<Province>()
                     .Property(p => p.Longitud)
                     .HasPrecision(18, 6);
            ////for city
            //modelBuilder.Entity<City>()
            //        .Property(c => c.Latitud)
            //        .HasPrecision(18, 6);
            //modelBuilder.Entity<City>()
            //         .Property(c => c.Longitud)
            //         .HasPrecision(18, 6);

        }
    }
}