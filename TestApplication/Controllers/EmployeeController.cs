using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestApplication.Repository;
namespace TestApplication.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult GetAllEmployeeDetails()
        {
            EmployeeRepo empRepo = new EmployeeRepo();
            ModelState.Clear();
            return View(empRepo.GetDisplayData());
        }
    }
}