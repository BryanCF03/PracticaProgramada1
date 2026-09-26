using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Inventario.Abstracciones.ModelosParaUI;
using Semana1_Framework.ModelBinders;

namespace Semana1_Framework
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            System.Web.Mvc.ModelBinders.Binders.Add(
             typeof(InventarioDto),
             new InventarioModelBinder()
         );
        }
    }
}
