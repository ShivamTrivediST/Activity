using Activitytracker.DAL;
using Activitytracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Activitytracker.Controllers
{
    public class LoginController : Controller
    {
        private UserModel model;
        
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Logout()
        {
            Session["userID"] = "";
            Session["userName"] = "";
            Session.Abandon();
            return RedirectToAction("Login", "Login");

        }
        public ActionResult Login(LoginModel loginModel)
        {
            
                //ViewBag["errorMessage"] = "";
                RegisterDataLayer dal = new RegisterDataLayer();
                UserModel userModel = dal.USerLogin(loginModel);
                if (userModel.UserID > 0)
                {
                    Session["UserID"] = userModel.UserID.ToString();
                    Session["UserName"] = userModel.UserName.ToString();
                }
                else
                {
                    ViewBag.Message = "Invalid credential!";
                    // ViewBag["errorMessage"] = "Invalid credential!";
                }
                
            
            return RedirectToAction("Index","Activity");
        }
    }
}