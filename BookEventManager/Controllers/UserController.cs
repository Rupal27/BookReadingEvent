using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Shared_Library;
using Shared_Library.Interface;
using BALUser;

namespace BookEventManager.Controllers
{
    public class UserController : Controller
    {
        IBusinessUser _busiuser;
        IBusinessBook _busibook;

       public UserController(IBusinessUser busiuser, IBusinessBook busibook)
        {
            _busiuser = busiuser;
            _busibook = busibook;
        }



        // GET: User

        public ActionResult RegisterUser()
        {
            return View("Create");
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult RegisterUser([Bind(Include = "ID,Email,Password,FullName")] CreateUserDTO user)
        {

            if (ModelState.IsValid)
            {
                _busiuser.InsertUser(user);
                return RedirectToAction("ViewAction","Book");

            }
            else
                return View("Create");

        }

        public ActionResult LoginUser()
        {
            return View("LoginPage");
        }



        [HttpPost]
        public ActionResult LoginUser([Bind(Include = "Password,FullName,Email")] LoginUserDTO login)
        {
            if (ModelState.IsValid)
            {
                if(login.Email.Equals("admin@gmail.com")&&login.FullName.Equals("admin")&&login.Password.Equals("abcd"))
                {
                    Session["id"] = 8;
                    Session["user"] = login.Email;
                    return RedirectToAction("ViewAction", "Book");
                }

               LoginUserDTO users= _busiuser.LoginUser(login);
                if (users!=null)
                {
                    Session["id"] = users.UserID;
                    Session["user"] = login.Email;
                   _busibook.GetAllList(users.UserID);
                    return RedirectToAction("ViewAction", "Book");
                }
                else
                {
                    ModelState.AddModelError("", "User not found in Database");
                    return View("LoginPage");
                }
            }
            else
                return View("LoginPage");

        }
        public ActionResult LogOut()
        {
            Session["user"] = null;
            return RedirectToAction("ViewAction","Book");
        }
    }
}