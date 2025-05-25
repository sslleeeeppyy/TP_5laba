using Microsoft.AspNetCore.Mvc;
using TP_2laba.Models;
using System.Collections.Generic;

namespace TP_2laba.Controllers
{
    public class ExpertiseDepartmentController : Controller
    {
        // Для простоты: временное хранилище (вместо БД)
        private static List<ExpertiseDepartment> departments = new List<ExpertiseDepartment>();

        public IActionResult Index(int? currentId)
        {
            ViewBag.CurrentId = currentId;
            return View(departments);
        }

        public IActionResult Details(int id)
        {
            var dept = departments.Find(d => d.Id == id);
            if (dept == null) return NotFound();
            return View(dept);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ExpertiseDepartment department)
        {
            if (ModelState.IsValid)
            {
                department.Id = departments.Count + 1;
                departments.Add(department);
                return RedirectToAction("Index");
            }
            return View(department);
        }

        public IActionResult Edit(int id)
        {
            var dept = departments.Find(d => d.Id == id);
            if (dept == null) return NotFound();
            return View(dept);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ExpertiseDepartment department)
        {
            var dept = departments.Find(d => d.Id == department.Id);
            if (dept == null) return NotFound();
            if (ModelState.IsValid)
            {
                dept.Name = department.Name;
                dept.HeadFullName = department.HeadFullName;
                dept.EmployeeCount = department.EmployeeCount;
                dept.FoundationDate = department.FoundationDate;
                dept.Email = department.Email;
                return RedirectToAction("Index");
            }
            return View(department);
        }

        [HttpPost]
        public IActionResult SetHelper(bool useExternal, int? currentId)
        {
            TempData["useExternal"] = useExternal;
            return RedirectToAction("Index", new { currentId });
        }
    }
} 