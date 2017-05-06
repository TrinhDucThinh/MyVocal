using System.Web.Mvc;

namespace MyVocal.Web.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Service()
        {
            return View();
        }
    }
}