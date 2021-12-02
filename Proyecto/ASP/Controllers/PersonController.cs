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

            List<PersonWithDepartamentName> list; 

            try
            {

                 list = new List<PersonWithDepartamentName>();

                clsPersonListBL clsPersonListBL = new clsPersonListBL();

                foreach (clsPerson person in clsPersonListBL.getPersons())
                {
                    list.Add(new PersonWithDepartamentName(person));
                }

            } catch(Exception)
            {
                return View("Error", new ErrorViewModel());
            }

            return View(list);
        }

        // GET: PersonController/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                return View(new PersonWithDepartamentName(new clsPersonListBL().getPerson(id)));

            } catch(Exception)
            {
                return View("Error", new ErrorViewModel());
            }
        }

        // GET: PersonController/Create
        public ActionResult Create()
        {

            try
            {
                return View(new PersonWithListDepartamentName());

            }
            catch (Exception)
            {
                return View("Error", new ErrorViewModel());
            }

        }

        // POST: PersonController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(clsPerson clsPerson)
        {

            try
            {
                if(ModelState.IsValid)
                {
                    new clsHandlerPersonBL().insertPerson(clsPerson);
                } else
                {
                    return View(new PersonWithListDepartamentName());
                }


            } catch (Exception)
            {
                return View("Error", new ErrorViewModel());
            }

            return RedirectToAction(nameof(Index));

        }

        // GET: PersonController/Edit/5
        public ActionResult Edit(int id)
        {


            try
            {
                return View(new PersonWithListDepartamentName(new clsPersonListBL().getPerson(id)));

            }
            catch (Exception)
            {
                return View("Error", new ErrorViewModel());
            }


        }

        // POST: PersonController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(clsPerson clsPerson)
        {


            try
            {
                if(ModelState.IsValid)
                {

                    new clsHandlerPersonBL().updatePerson(clsPerson);


                } else
                {
                    return View(new PersonWithListDepartamentName(new clsPersonListBL().getPerson(clsPerson.id)));

                }

            }
            catch (Exception)
            {
                return View("Error", new ErrorViewModel());

            }

            return RedirectToAction(nameof(Index));

        }

        // GET: PersonController/Delete/5
        public ActionResult Delete(int id)
        {


            try
            {
                return View(new PersonWithDepartamentName(new clsPersonListBL().getPerson(id)));

            }
            catch (Exception)
            {
                return View("Error", new ErrorViewModel());

            }

        }

        // POST: PersonController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {

            try
            {
                new clsHandlerPersonBL().deletePerson(id);

            } catch(Exception)
            {
                return View("Error", new ErrorViewModel());
            }


            return RedirectToAction(nameof(Index));


        }
    }
}
