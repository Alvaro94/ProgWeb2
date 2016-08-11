using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace crud.Models
{
    public class product
    {
        public int id { get; set; }
        public string name { get; set; }
        public string category { get; set; }
         public int price { get; set; }
        
    }

    class ProductosDbContext: DbContext
    {
        public DbSet<product> product { get; set; }
    }


}



