using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentinformationMVC.Models;
using StudentinformationMVC.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace StudentinformationMVC.Controllers
{
    public class StudetinformationController: Controller
    {
        // GET: PersonalDataController

         StudentinformationRepository objstudent;
        public StudetinformationController()
        {
             objstudent = new StudentinformationRepository();
        }
        // GET: StudetinformationController1
        public ActionResult List()
        {
            return View("List", objstudent.select());
        }

        // GET: StudetinformationController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: StudetinformationController1/Create
        public ActionResult Create()
        {
            return View("Create",new StudentinformationModels());
        }

        // POST: StudetinformationController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StudentinformationModels data)
        {
            try
            {
                objstudent.Insert(data);
                return RedirectToAction(nameof(List));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudetinformationController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: StudetinformationController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudetinformationController1/Delete/5
        public ActionResult Delete(int studentid)
        {
            var res = objstudent.selectwithid(studentid);
            return View("Delete",res);
        }

        // POST: StudetinformationController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int studentid, StudentinformationModels collection)
        {
            try
            {
                objstudent.Delete(studentid);
                return RedirectToAction(nameof(List));
            }
            catch
            {
                return View();
            }
        }
    }
}
