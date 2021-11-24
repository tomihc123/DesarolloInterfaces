using ASP.Models;
using BL.Handler;
using BL.Lists;
using Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ASP.Controllers
{
    public class PersonController : Controller
    {
        // GET: PersonController
        public ActionResult Index()
        {

            clsPersonListBL clsPersonListBL = new clsPersonListBL();
            List<PersonWithDepartamentName> list = new List<PersonWithDepartamentName>();
            
            foreach(clsPerson person in clsPersonListBL.getPersons())
            {

                list.Add(new PersonWithDepartamentName(person));

            } 


            return View(list);
        }

        // GET: PersonController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PersonController/Create
        public ActionResult Create()
        {
            return View(new PersonWithListDepartamentName());
        }

        // POST: PersonController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {

            new clsHandlerPersonBL().insertPerson(new clsPerson(collection["name"], collection["lastName"], DateTime.Parse(collection["birthDate"]), collection["phoneNumber"], collection["address"], Int32.Parse(collection["iddepartamento"])));

            return RedirectToAction(nameof(Index));

        }

        // GET: PersonController/Edit/5
        public ActionResult Edit(int id)
        {

            clsPersonListBL clsPersonListBL = new clsPersonListBL();
            PersonWithListDepartamentName personWithListDepartamentName = null;
            List<clsPerson> lista = clsPersonListBL.getPersons();
            foreach (clsPerson person in lista)
            {

                if(person.id == id)
                {
                    personWithListDepartamentName = new PersonWithListDepartamentName(person);
                }

            }

            return View(personWithListDepartamentName);
        }

        // POST: PersonController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {

            
            new clsHandlerPersonBL().updatePerson(new clsPerson(id, collection["name"], collection["lastName"], DateTime.Parse(collection["birthDate"]), collection["phoneNumber"], collection["address"], Int32.Parse(collection["iddepartamento"])));

            return RedirectToAction(nameof(Index));

        }

        // GET: PersonController/Delete/5
        public ActionResult Delete(int id)
        {
            clsPersonListBL clsPersonListBL = new clsPersonListBL();
            PersonWithDepartamentName personWithDepartamentName = null;


            foreach (clsPerson person in clsPersonListBL.getPersons())
            {
                if(person.id == id)
                {
                    personWithDepartamentName = new PersonWithDepartamentName(person);
                }

            }

            return View(personWithDepartamentName);
        }

        // POST: PersonController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            new clsHandlerPersonBL().deletePerson(id);

            return RedirectToAction(nameof(Index));


        }
    }
}
