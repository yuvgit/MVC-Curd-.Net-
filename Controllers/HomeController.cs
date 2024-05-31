using Microsoft.AspNetCore.Mvc;
using Project_Curd.Models;
using System.Diagnostics;

namespace Project_Curd.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        private readonly DBContextLayer _dbContextLayer;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}
        public HomeController(DBContextLayer db)
        {
            _dbContextLayer = db;
        }

        public IActionResult Index()
        {
            return View(_dbContextLayer.Teachers);
        }
         
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TeacherModel model)
        {
            if (ModelState.IsValid)
            {
                _dbContextLayer.Teachers.Add(model);
                _dbContextLayer.SaveChanges();
                return RedirectToAction("Index");
            }
            else 
                return View();
        }
        public IActionResult Update(int id)
        {
            return View(_dbContextLayer.Teachers.Where(a=>a.Id==id).FirstOrDefault());
        }
        [HttpPost]
        [ActionName("Update")]
        public IActionResult Update_Post(TeacherModel teacher)
        {
            _dbContextLayer.Teachers.Update(teacher);
            _dbContextLayer.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
             var teacher = _dbContextLayer.Teachers.Where(a=>a.Id==id).FirstOrDefault();
             _dbContextLayer.Teachers.Remove(teacher);
            _dbContextLayer.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
