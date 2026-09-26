using Inventario.Abstracciones.ModelosParaUI;
using System.Web.Mvc;

namespace Semana1_Framework.ModelBinders
{
    public class InventarioModelBinder : IModelBinder
    {
        public object BindModel(
            ControllerContext controllerContext,
            ModelBindingContext bindingContext)
        {
            InventarioDto inventario = new InventarioDto();

            var codigo = bindingContext.ValueProvider.GetValue("CodigoDelRepuesto");
            var nombre = bindingContext.ValueProvider.GetValue("NombreDelRepuesto");
            var marca = bindingContext.ValueProvider.GetValue("MarcaDelRepuesto");
            var vehiculo = bindingContext.ValueProvider.GetValue("Vehiculo");
            var modelo = bindingContext.ValueProvider.GetValue("Modelo");
            var anio = bindingContext.ValueProvider.GetValue("Anio");
            var cantidad = bindingContext.ValueProvider.GetValue("Cantidad");
            var estado = bindingContext.ValueProvider.GetValue("Estado");

            if (codigo != null)
                inventario.CodigoDelRepuesto = codigo.AttemptedValue.Trim();

            if (nombre != null)
                inventario.NombreDelRepuesto = nombre.AttemptedValue.Trim();

            if (marca != null)
                inventario.MarcaDelRepuesto = marca.AttemptedValue.Trim();

            if (vehiculo != null)
                inventario.Vehiculo = vehiculo.AttemptedValue.Trim();

            if (modelo != null)
                inventario.Modelo = modelo.AttemptedValue.Trim();

            int anioConvertido;
            if (anio != null && int.TryParse(anio.AttemptedValue, out anioConvertido))
                inventario.Anio = anioConvertido;

            int cantidadConvertida;
            if (cantidad != null && int.TryParse(cantidad.AttemptedValue, out cantidadConvertida))
                inventario.Cantidad = cantidadConvertida;

            if (estado != null)
                inventario.Estado = estado.AttemptedValue.Contains("true");

            return inventario;
        }
    }
}