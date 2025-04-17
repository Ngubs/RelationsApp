using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RelationsApp.Data;

namespace RelationsApp.Controllers
{
    /*This class definition makes the use of Primary Constructor. 
     * Usually the implementation looks some like this :
     * public class StudentController{
     * 
     *      private readonly AppDbContext _db;
     * 
     *      public StudentController(AppDbContext db){
     *          _db = db;
     *      }
     * }
    */
    public class StudentController(AppDbContext db) : Controller
    {
        private readonly AppDbContext _db = db;
        public async Task<IActionResult> Index()
        {
            /*
             * The use of the .Include() function is to make sure that each object in 
             * list of student objects will contain an Address object
             */
            var students = await _db.Students.Include(a => a.Address).ToListAsync();
            return View(students);
        }
    }
}
