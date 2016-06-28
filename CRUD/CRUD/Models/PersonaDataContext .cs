using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace CRUD.Models
{
    public class PersonaDataContext : DbContext
    {
        public DbSet Person { get; set; }

        public System.Data.Entity.DbSet<CRUD.Models.Person> People { get; set; }

    }
}