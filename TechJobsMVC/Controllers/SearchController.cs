using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechJobsMVC.Data;
using TechJobsMVC.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TechJobsMVC.Controllers
{
    public class SearchController : Controller
    {
        public static List<Job> jobs;
        public static string radio;
        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.jobs = jobs;
            ViewBag.radio = radio;
            ViewBag.columns = ListController.ColumnChoices;
            return View();
        }


        public IActionResult Results(string searchType, string searchTerm)
        { 
            if(searchTerm == null)
            {
                jobs = JobData.FindAll();
            }
            else
            {
                jobs = JobData.FindByColumnAndValue(searchType, searchTerm);
            }
            radio = searchType;
            ViewBag.columns = ListController.ColumnChoices;
            return Redirect("/Search/index");
        }
    }
}
