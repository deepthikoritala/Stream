using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using Stream.Models;

namespace Stream.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
           
            return View();
        }

        public JsonResult getLanguages()
        {
            Languages obj = new Languages();
            List<LanguageViewModel> res= obj.getLanguages();
            return Json(res,JsonRequestBehavior.AllowGet);
        }

        public JsonResult getContent(string language,int? FileType=0)
        {
            List<TestimonyViewModel> res = new List<TestimonyViewModel>();
            Testimony obj = new Testimony();
            res = obj.getTestimonies();
            var result = res.Where(r => r.Language == language);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Images()
        {

            return View();
        }
        public ActionResult Videos()
        {

            return View();
        }



    }
}