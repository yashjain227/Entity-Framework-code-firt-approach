using System.Diagnostics;
using codefirst.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace codefirst.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        private readonly StudentDbContext student;
        public HomeController(StudentDbContext student)
        {
            this.student = student;
        }

        public async Task<IActionResult> Index()
        {
            var mystu = await student.Students.ToListAsync();
            return View(mystu);
        }

        public IActionResult Create()
        {
            
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Student st)
        {
            if (ModelState.IsValid)
            {
               await student.Students.AddAsync(st);
               // Console.WriteLine(st.Id);
               await student.SaveChangesAsync();
                TempData["inserted"] = "record inserted successfully";
                return RedirectToAction("Index", "Home");
            }

            return View();
        }
        public async Task<IActionResult> Details(int id)
        {
            var mystu = await student.Students.FirstOrDefaultAsync(x=>x.Id==id);
            return View(mystu);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var mystu = await student.Students.FindAsync(id);
            return View(mystu);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id,Student st)
        {
              student.Students.Update(st);
          await  student.SaveChangesAsync();
            TempData["updated"] = "record update successfully";
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Delete(int id)
        {
            var mystu =  student.Students.Find(id);
            return View(mystu);
            
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, Student st)
        {
            student.Students.Remove(st);

            TempData["deleted"] = "record deleted successfully";

            await student.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }



        public IActionResult searchresult(string searchstring)
        {
            IQueryable<Student> stu = student.Students;
            if (!string.IsNullOrEmpty(searchstring))
            {
               stu= stu.Where(x => x.Name.Contains(searchstring)); 
            }
           var st= stu.ToList();
            ViewBag.search = searchstring;
            return View(st);
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
