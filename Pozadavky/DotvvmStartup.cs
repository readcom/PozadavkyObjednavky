using System.Web.Hosting;
using Microsoft.Owin;
using Microsoft.Owin.FileSystems;
using Microsoft.Owin.StaticFiles;
using Owin;
using DotVVM.Framework;
using DotVVM.Framework.Configuration;
using DotVVM.Framework.Routing;

namespace Pozadavky
{
    public class DotvvmStartup : IDotvvmStartup
    {
        // For more information about this class, visit https://dotvvm.com/docs/tutorials/basics-project-structure
        public void Configure(DotvvmConfiguration config, string applicationPath)
        {
            config.RouteTable.Add("Default", "", "Views/home.dothtml");
            config.RouteTable.Add("PozadavkyList", "manager/{Id}", "Views/manager.dothtml");
            config.RouteTable.Add("PozadavekNew", "pozadaveknew/{Id}", "Views/pozadaveknew.dothtml", new {id = 0});
            config.RouteTable.Add("PozadavekEdit", "pozadavek/{Id}", "Views/pozadavek.dothtml");



            // Uncomment the following line to auto-register all dothtml files in the Views folder
            config.RouteTable.AutoDiscoverRoutes(new DefaultRouteStrategy(config));
        }
    }
}
