﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wellmeadows_Hospital.DAL;

namespace Wellmeadows_Hospital.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            StaffRepository staff = new StaffRepository();

            staff.CreateStaff();
            staff.UpdateStaff();
            staff.GetStaff();
            //staff.DeleteStaff();

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}