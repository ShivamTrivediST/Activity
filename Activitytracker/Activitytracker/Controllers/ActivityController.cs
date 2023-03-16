using Activitytracker.DAL;
using Activitytracker.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Activitytracker.Controllers
{
    public class ActivityController : Controller
    {
        private ActivityModel model;
        ActivityDataLayer dataLayer = new ActivityDataLayer();
        // GET: Activity
        public ActionResult Index()
        {
            var result = dataLayer.GetAllData(Convert.ToInt32(Session["UserID"]));
            return View(result);
        }
        public ActionResult Add()
        {
            return View();
        }
        public ActionResult Addactivity(ActivityModel model)
        {
                if (ModelState.IsValid)
                {
                    //ViewBag["errorMessage"] = "";
                    ActivityDataLayer dal = new ActivityDataLayer();
                    bool bl = dal.Addactivity(model, Convert.ToInt32(Session["UserID"]));
                    if (bl == true)
                    {
                        ViewBag.Message = "Activity Added Successfully!";
                    }
                    //else
                    //{
                    //    ViewBag.Message = "User Already Exist!";
                    //    // ViewBag["errorMessage"] = "Invalid credential!";
                    //}

                }
                return RedirectToAction("Add");
                 
        }

       

        // GET: Employee/DeleteEmp/5    
        public ActionResult Delete(int id)
        {
            try
            {
                ActivityDataLayer EmpRepo = new ActivityDataLayer();
                if (EmpRepo.DeleteActivity(id))
                {
                    ViewBag.AlertMsg = "Activity details deleted successfully";

                }
                return RedirectToAction("Index");

            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult Editactivity() 
        { return View(); }
    }
}