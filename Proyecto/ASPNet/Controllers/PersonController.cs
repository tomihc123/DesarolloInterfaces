﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dal.Lists;

namespace ASPNet.Controllers
{
    public class PersonController : Controller
    {
        public IActionResult Index()
        {

            return View(new clsPersonListDal().getPersons());
        }
    }
}
