using System.Configuration;
using System.Web.Mvc;
using whatsbuilding.Models;

namespace whatsbuilding.Controllers {
    public class HomeController:Controller {

        [OutputCache(Duration=60)]
        public ActionResult Index(string tfsCollectionUrl) {
            var tfsProjectCollectionUrl=tfsCollectionUrl??ConfigurationManager.AppSettings["TfsCollectionUrl"];
            if(!string.IsNullOrEmpty(tfsProjectCollectionUrl)) {
                IControllerRepository controllerRepo=new TfsControllerRepository();
                var buildControllers=controllerRepo.GetBuildControllers(tfsProjectCollectionUrl);
                Response.AddHeader("Refresh", "60");
                return View(buildControllers);
            } else{
                return View("BlankHome");
            }
        }




    }
}
