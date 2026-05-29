using Microsoft.AspNetCore.Mvc;
using WebApplicationADO_CRUD.Models;

namespace WebApplicationADO_Crud.Controllers
{
    public class StudentController : Controller
    {
        DataLayer _dl;
        public StudentController(DataLayer dl) // coming from program.cs file
        {
            _dl = dl;
        }
        public IActionResult Index()
        {
            var studentList = _dl.FetchAllStudents();
            return View(studentList);
        }
        public IActionResult Details(int id)
        {
            var studentInfo = _dl.getStudentById(id);
            return View(studentInfo);
        }
        public IActionResult Delete(int id)
        {
            bool success = _dl.RemoveStudent(id);
            if (success)
            {
                TempData["Message"] = "Delete Success";
            }
            else
            {
                TempData["Message"] = "Error";
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Student obj)
        {
            bool success = _dl.AddStudent(obj);
            if (success)
            {
                TempData["Message"] = "Insert Success";
            }
            else
            {
                TempData["Message"] = "Error";
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var stu = _dl.getStudentById(id);
            return View(stu);
        }
        [HttpPost]
        public IActionResult Edit(Student obj)
        {
            bool success = _dl.UpdateStudent(obj);
            if (success)
            {
                TempData["Message"] = "Update Success";
            }
            else
            {
                TempData["Message"] = "Error";
            }
            return RedirectToAction("Index");
        }

    }
}
