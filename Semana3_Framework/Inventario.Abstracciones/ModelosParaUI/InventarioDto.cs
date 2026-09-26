using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Inventario.Abstracciones.ModelosParaUI
{
    public class InventarioDto
    {
        public string CodigoDelRepuesto { get; set; }
        public string NombreDelRepuesto { get; set; }
        public string MarcaDelRepuesto { get; set; }
        public string Vehiculo { get; set; }
        public string Modelo { get; set; }
        public int Anio { get; set; }
        public int Cantidad { get; set; }
        public DateTime FechaDeRegistro { get; set; }
        public DateTime FechaDeModificacion { get; set; }
        public bool Estado { get; set; }
        public HttpPostedFileBase archivo { get; set; }
    }
}

