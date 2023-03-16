using Activitytracker.DAL;
using Activitytracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace Activitytracker.Controllers
{
    public class RegistrationController : Controller
    {
        // GET: Registration
        public ActionResult Index(UserModel model)
        {
            return View();
        }
        public ActionResult Register(UserModel model)
        {
            if (ModelState.IsValid)
            {
                //ViewBag["errorMessage"] = "";
                RegisterDataLayer dal = new RegisterDataLayer();
                bool bl = dal.SignUpUser(model);
                if (bl == true)
                {
                    ViewBag.Message = "User Registered Successfully!";
                }
                else
                {
                    ViewBag.Message = "User Already Exist!";
                    // ViewBag["errorMessage"] = "Invalid credential!";
                }

            }
            return View("Index");
        }
    }
}