using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeatherMoscow.DataHelpers;
using WeatherMoscow.Models;
using WeatherMoscow.Models.ViewModels;

namespace WeatherMoscow.Controllers
{
    public class WeatherController : Controller
    {
        public ActionResult WeatherList(int? year, int? month, int page = 1)
        {
            int pageSize = 50;
            ViewBag.year = year;
            ViewBag.month = month;

            IEnumerable<Weather> weather;
            using (WeatherContext db = new WeatherContext())
            {
                weather = db.Weathers;

                if (year != null)
                {
                    weather = weather.Where(x => x.Date.Year == year);
                }

                if (month != null)
                {
                    weather = weather.Where(x => x.Date.Month == month);
                }

                int totalItems = weather.Count();
                weather = weather.OrderBy(m => m.Date)
                                 .Skip((page - 1) * pageSize)
                                 .Take(pageSize);

                PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = totalItems };
                WeatherViewModel weatherViewModel = new WeatherViewModel { PageInfo = pageInfo, Weathers = weather.ToList() };


                return View(weatherViewModel);
            }
        }

        [HttpGet]
        public ActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public RedirectToRouteResult Upload(IEnumerable<HttpPostedFileBase> uploads)
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
            }
            return RedirectToAction("Index", "Home");
        }
    }
}