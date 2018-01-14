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

        public DbSet<City> Cities { get; set; }
    }
}