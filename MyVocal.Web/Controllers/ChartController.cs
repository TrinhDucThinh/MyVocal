using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyVocal.Web.Controllers
{
    public class ChartController : Controller
    {
        // GET: Chart
        public ActionResult PieChart()
        {
            return View();
        }

        public ActionResult PieChartCanvas()
        {
            return View();
        }
    }
}