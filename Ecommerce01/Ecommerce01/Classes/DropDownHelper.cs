﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ecommerce01.Models;

namespace Ecommerce01.Classes 
{
    public class DropDownHelper : IDisposable
    {
        private static Ecommerce01Context db = new Ecommerce01Context();

        public static List<Departament> GetDepartaments()
        {
            var departments = db.Departaments.ToList();
            departments.Add(new Departament
            {
                DepartamentId = 0,
                Name = "[Selezione una Regione...]"
            });
            return departments = departments.OrderBy(d => d.Name).ToList();
        }

        public static List<Province> GetProvinces()
        {
            var provinces = db.Provinces.ToList();
            provinces.Add(new Province
            {
                ProvinceId = 0,
                Name = "[Selezione una Provincia...]"
            });
            return provinces = provinces.OrderBy(p => p.Name).ToList();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}