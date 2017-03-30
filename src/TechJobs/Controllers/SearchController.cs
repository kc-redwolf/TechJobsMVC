using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;

namespace TechJobs.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search";
            return View();
        }

        // TODO #1 - Create a Results action method to process 
        // search request and display results

        public IActionResult Results(string searchTerm, string searchType)
        {
            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search";

               if (searchType.Equals("all") && searchTerm.Equals("all"))

            {
                if (!string.IsNullOrEmpty(searchTerm))

                {
                    ViewBag.jobs = JobData.FindAll();
                }

            }
                if (searchType.Equals("all") && !searchTerm.Equals("all"))
                 {
                    ViewBag.jobs = JobData.FindByValue(searchTerm);
                }
                if (!searchType.Equals("all"))
                 {
                    ViewBag.jobs = JobData.FindByColumnAndValue(searchType, searchTerm);
                }


                return View("Index");
            
            
        }

    }
}
