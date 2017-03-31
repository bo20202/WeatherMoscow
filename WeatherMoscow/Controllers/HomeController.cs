using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeatherMoscow.DataHelpers;
using WeatherMoscow.Models;

namespace WeatherMoscow.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult WeatherList()
        {
            using (WeatherContext db = new WeatherContext())
            {
                IEnumerable<Weather> weather = db.Weathers.ToList();
                return View(weather);
            }
        }

        [HttpGet]
        public ActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public void Upload(IEnumerable<HttpPostedFileBase> uploads)
        {
            List<Weather> weatherObjects = new List<Weather>();
            foreach (var file in uploads)
            {
                if (file != null)
                {
                    ExcelParser parser = new ExcelParser();
                    Stream fileStream = file.InputStream;
                    weatherObjects.AddRange(parser.ParseFile(fileStream));
                }
            }

            using (WeatherContext db = new WeatherContext())
            {
                db.Weathers.AddRange(weatherObjects);
                db.SaveChanges();
                RedirectToAction("Upload");
            }
        }
    }
}