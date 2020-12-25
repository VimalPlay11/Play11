using BusinessLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Play11.Controllers
{
    public class LoginController : Controller
    {
        UserBL objUserBL = new UserBL();

        // GET: Login
        public ActionResult Index(string message)
        {
            if (message == "le1")
                ViewData["ValidateUser"] = "<script>alert('Invalid credentials');</script>";
            else if (message == "re1")
                ViewData["ValidateUser"] = "<script>alert('Email Id is already registered');</script>";
            else if (message == "rs")
                ViewData["ValidateUser"] = "<script>alert('Registered Successfully!! Start Playing..');</script>";
            else if (message == "sto")
                ViewData["ValidateUser"] = "<script>alert('Kindly login to start playing with us...');</script>";
            else if (message == "apd")
                ViewData["ValidateUser"] = "<script>alert('Permission Denied! Unauthourized Access');</script>";
            return View();
        }
        public ActionResult RegisterUser(FormCollection UserDetails)
        {

            string UserName = UserDetails["registerUserName"];
            string EmailId = UserDetails["registerEmailId"];
            string Password = UserDetails["registerPassword"];
            string PhoneNumber = UserDetails["registerPhoneNumber"];
            var res = objUserBL.RegisterNewUser(UserName, EmailId, Password, PhoneNumber);

            string msg = "";
            if (res == 1)
            {
                msg = "rs";
            }
            else if (res == 0)
            {
                msg = "re1";
            }
            return RedirectToAction("Index", new { message = msg });
        }
        public ActionResult ValidateUser(FormCollection loginDetails)
        {
            UserEL objUserEL;
            string userMailId = loginDetails["EmailId"];
            string userPassword = loginDetails["Password"];
            objUserEL = objUserBL.ValidateUserLogin(userMailId, userPassword);
            Session["UserName"] = objUserEL.userName;
            Session["UserId"] = objUserEL.userId;
            if (objUserEL.userRoleId == 1)
            {
                Session["AdminValid"] = "AdminValid";
                return RedirectToAction("Index", "Admin");
            }
            else if (objUserEL.userRoleId == 2)
            {
                Session["UserValid"] = "UserValid";
                return RedirectToAction("Index", "Match");
            }
            else
            {
                string msg = "le1";
                return RedirectToAction("Index", new { message = msg });
            }

        }
        public ActionResult logout()
        {

            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }

    }
}