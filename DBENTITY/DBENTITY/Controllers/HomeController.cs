using DBENTITY.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace DBENTITY.Controllers
{
    public class HomeController : Controller
    {
        private readonly DbcorenContext  _DBContext;

        public HomeController(DbcorenContext context)
        {
            _DBContext = context;
        }

        public IActionResult Index()
        {

            List<Empleado>lista = _DBContext.Empleados.Include(c =>c.oCargo).ToList();

            return View();
        }

     
   
    }
}