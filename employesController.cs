using CRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRUD.repository;

namespace CRUD.Controllers
{
    public class employesController : Controller
    {
        // GET: employes
        private IEmployerepository _employeeRepository;
        public employesController()
        {
            _employeeRepository = new Employerepository(new APIEntities());
        }
        public employesController(IEmployerepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        [HttpGet]
        public ActionResult Index()
        {
            var model = _employeeRepository.GetAll();
            return View(model);
        }
        [HttpGet]
        public ActionResult AddEmployee()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddEmployee(Employess model)
        {
            if (ModelState.IsValid)
            {
                _employeeRepository.Insert(model);
                _employeeRepository.Save();
                return RedirectToAction("Index", "employes");
            }
            return View();
        }
        [HttpGet]
        public ActionResult EditEmployee(int id)
        {
            Employess model = _employeeRepository.GetById(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult EditEmployee(Employess model)
        {
            if (ModelState.IsValid)
            {
                _employeeRepository.Update(model);
                _employeeRepository.Save();
                return RedirectToAction("Index", "employes");
            }
            else
            {
                return View(model);
            }
        }
        [HttpGet]
        public ActionResult DeleteEmployee(int id)
        {
            Employess model = _employeeRepository.GetById(id);
            return View(model);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            _employeeRepository.Delete(id);
            _employeeRepository.Save();
            return RedirectToAction("Index", "employes");
        }
    }
}
    
