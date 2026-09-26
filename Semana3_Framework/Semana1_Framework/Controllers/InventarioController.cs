using Inventario.Abstracciones.LogicaDeNegocio.Inventario.ListarInventario;
using Inventario.Abstracciones.ModelosParaUI;
using Inventario.LogicaDeNegocio.Inventario.ListarInventario;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Semana1_Framework.Controllers
{
    public class InventarioController : Controller
    {
        private IListarInventarioLN _listarInventario;

        public InventarioController()
        {
            _listarInventario = new ListarInventarioLN();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListarInventario()
        {
            List<InventarioDto> laListaDeInventario =
                _listarInventario.Obtener();

            return View(laListaDeInventario);
        }

        public ActionResult DetallesInventario(string codigo)
        {
            InventarioDto inventario =
                _listarInventario.BuscarPorCodigo(codigo);

            if (inventario == null)
            {
                return HttpNotFound();
            }

            return View(inventario);
        }

        // GET: Inventario/RegistrarInventario
        [HttpGet]
        [Route("inventario/nuevo")]
        public ActionResult RegistrarInventario()
        {
            return View();
        }

        [HttpPost]
        [Route("inventario/nuevo")]
        public ActionResult RegistrarInventario(InventarioDto inventario)
        {
            try
            {
                _listarInventario.Registrar(inventario);

                return RedirectToAction("ListarInventario");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;

                return View(inventario);
            }
        }

        public ContentResult EstadoInventario()
        {
            return Content("El sistema de inventario se encuentra activo.");
        }

        public FileResult DescargarReporte()
        {
            string contenido =
                "REPORTE DE INVENTARIO\n\n" +
                "Código: 0001\n" +
                "Repuesto: Compensador\n" +
                "Marca: KYB\n" +
                "Vehículo: Toyota Corolla\n" +
                "Cantidad: 5\n" +
                "Estado: Disponible";

            byte[] archivo = System.Text.Encoding.UTF8.GetBytes(contenido);

            return File(archivo, "text/plain", "ReporteInventario.txt");
        }
        public RedirectResult IrALista()
        {
            return Redirect("/Inventario/ListarInventario");
        }


        // GET
        [HttpGet]
        public ActionResult EditarInventario(string codigo)
        {
            InventarioDto inventario =
                _listarInventario.BuscarPorCodigo(codigo);

            if (inventario == null)
            {
                return HttpNotFound();
            }

            return View(inventario);
        }

        [HttpPost]
        public ActionResult EditarInventario(InventarioDto inventario)
        {

            _listarInventario.Editar(inventario);
            return RedirectToAction("ListarInventario");
        }

    }
}