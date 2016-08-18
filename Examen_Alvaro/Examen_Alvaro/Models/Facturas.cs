using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Examen_Alvaro.Models
{
    public class Facturas
    {
        [Key]
        public int clienteId { get; set; }
        public string Fecha { get; set; }
        public string Producto { get; set; }
        public string Cantida { get; set; }
        public string TipoUnidad { get; set; }
        public string PrecioTotal { get; set; }
        public double Impuesto { get; set; }
    }
}