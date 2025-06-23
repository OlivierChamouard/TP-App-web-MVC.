using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using System.Net;
using System.Reflection;
using TPLOCAL1.Models;

//Subject is find at the root of the project and the logo in the wwwroot/ressources folders of the solution
//--------------------------------------------------------------------------------------
//Careful, the MVC model is a so-called convention model instead of configuration,
//The controller must imperatively be name with "Controller" at the end !!!
namespace TPLOCAL1.Controllers
{
    public class HomeController : Controller
    {
        //methode "naturally" call by router
        public ActionResult Index(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                //retourn to the Index view (see routing in Program.cs)
                return View();
            else
            {
                //Call different pages, according to the id pass as parameter
                switch (id)
                {
                    case "OpinionList":
                        //code reading of the xml files provide
                        string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Data", "DataAvis.xml");
                        OpinionList opinionList = new OpinionList();
                        List<Opinion> opinions = opinionList.GetAvis(filePath);
                        return View("OpinionList", opinions);
                    case "Form":
                        ViewData["Sexe"] = InfoPerso.SexeOption
                            .Select(option => new SelectListItem { Text = option, Value = option })
                            .ToList();
                        ViewData["Cours"] = InfoPerso.CoursOption
                          .Select(option => new SelectListItem { Text = option, Value = option })
                          .ToList();
                        return View(id);
                    default:
                        //retourn to the Index view (see routing in Program.cs)
                        return View();
                }
            }
        }

        [HttpGet]
        public IActionResult Validation(InfoPerso infoPerso)
        {
            return View(infoPerso);
        }
        [HttpPost]
        public ActionResult ValidationForm(InfoPerso model)
        {

            if (!ModelState.IsValid)
            {
                ViewData["Sexe"] = InfoPerso.SexeOption
                .Select(option => new SelectListItem { Text = option, Value = option })
                .ToList();
                ViewData["Cours"] = InfoPerso.CoursOption
               .Select(option => new SelectListItem { Text = option, Value = option })
               .ToList();
                return View("Form", model);
            }
            return RedirectToAction("Validation", model);

        }
    }

}