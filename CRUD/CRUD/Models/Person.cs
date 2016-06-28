using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace CRUD.Models
{
    public class Person
    {
        [Key]
        public int id { get; set; }
        public string Oficio { get; set; }
        public string Empresa { get; set; }
        public string Experiencia { get; set; }
       
    }
}