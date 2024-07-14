using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;
using System.Collections.Generic;

namespace SalesWebMvc.Controllers
{
    public class DepartmentsController : Controller
    {
        public IActionResult Index()
        {
            List<Department> departmentsList = new List<Department>()
            {
                new Department { Id = 1, Name = "Eletronics" },
                new Department { Id = 2, Name = "Fashion" },
                new Department { Id = 3, Name = "Games" }
            };
            
            return View(departmentsList);
        }
    }
}
