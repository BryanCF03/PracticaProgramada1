using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Semana1_Framework.Models;
using Newtonsoft.Json;
using System.Web.Mvc;

namespace Semana1_Framework.Controllers
{
    
    public class ContactoController : Controller
    {
        // GET: Contacto
        public ActionResult Index()
        {

            ContactoModel contacto = new ContactoModel();

            contacto.Nombre = "Jose Pablo Delgado";
            contacto.Correo = "soporte@ufidelitas.ac.cr";
            return View(contacto);
        }


        public ActionResult JsonContacto()
        {
            ContactoModel contacto = new ContactoModel();

            contacto.Nombre = "Jose Pablo Delgado";
            contacto.Correo = "soporte@ufidelitas.ac.cr";

            string json = JsonConvert.SerializeObject(contacto,Formatting.Indented);

            return Content(json, "application/json");
        }
    }
}