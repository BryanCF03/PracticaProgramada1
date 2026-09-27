using Clientes.Abstracciones.LogicaDeNegocio.Clientes;
using Clientes.Abstracciones.ModelosParaUI;
using Clientes.LogicaDeNegocio.Clientes;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Semana1_Framework.Controllers
{
    public class ClientesController : Controller
    {
        private IClientesLN _clientesLN;

        public ClientesController()
        {
            _clientesLN = new ClientesLN();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListarClientes()
        {
            List<ClienteDto> laListaDeClientes =
                _clientesLN.Obtener();

            return View(laListaDeClientes);
        }

        public ActionResult DetallesCliente(string identificacion)
        {
            ClienteDto cliente =
                _clientesLN.BuscarPorIdentificacion(identificacion);

            if (cliente == null)
            {
                return HttpNotFound();
            }

            return View(cliente);
        }

        // GET: Clientes/RegistrarCliente
        [HttpGet]
        public ActionResult RegistrarCliente()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegistrarCliente(ClienteDto cliente)
        {
            try
            {
                _clientesLN.Registrar(cliente);

                return RedirectToAction("ListarClientes");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;

                return View(cliente);
            }
        }

        // GET
        [HttpGet]
        public ActionResult EditarCliente(string identificacion)
        {
            ClienteDto cliente =
                _clientesLN.BuscarPorIdentificacion(identificacion);

            if (cliente == null)
            {
                return HttpNotFound();
            }

            return View(cliente);
        }

        [HttpPost]
        public ActionResult EditarCliente(ClienteDto cliente)
        {
            _clientesLN.Editar(cliente);

            return RedirectToAction("ListarClientes");
        }
    }
}