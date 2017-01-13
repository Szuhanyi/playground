using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OptimUI.Models;
// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace OptimUI.Controllers
{
    public class OptimController : Controller
    {
        // my understanding is that this class tanslates the http requests to logic calls
        // GET: /<controller>/
        public IActionResult Index()
        {// return static methods. Or whatever
            return View();
        }

        // GET: /<controller>/ but my understanding is incomplete . 
        public IActionResult Send(Problem test)
        {
            return null;
        }
    }
}
