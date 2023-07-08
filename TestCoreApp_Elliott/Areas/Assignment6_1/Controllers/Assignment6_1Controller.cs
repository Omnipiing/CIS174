using Microsoft.AspNetCore.Mvc;
using TestCoreApp_Elliott.Assignment6_1.Models;

namespace TestCoreApp_Elliott.Assignment6_1.Controllers
{
    [Area("Assignment6_1")]
    public class Assignment6_1Controller : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Assignment6_1(int accessLevel)
        {
            List<Student> students = GetStudents(accessLevel);

            AssignmentViewModel viewModel = new AssignmentViewModel
            {
                Students = students,
                AccessLevel = accessLevel
            };

            return View(viewModel);
        }

        [HttpPost]
        private List<Student> GetStudents(int accessLevel)
        {
            List<Student> students = new List<Student>();

            students.Add(new Student { FirstName = "John", LastName = "BonJovi", Grade = "B" });
            students.Add(new Student { FirstName = "Lars", LastName = "Ulrich", Grade = "F" });
            students.Add(new Student { FirstName = "Maynard", LastName = "James Keenan", Grade = "A" });

            return students;
        }
    }
}
