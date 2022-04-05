using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UnlockFreshCMS.Controllers
{
    public class ErrorsController : Controller
    {
        [HttpGet]
        public ActionResult Error404(string message)
        {
            //Response.StatusCode = 404;
            return View();
        }

        [HttpGet]
        public ActionResult Error500(string message)
        {
            //Response.StatusCode = 500;
            return View();
        }
	}
}