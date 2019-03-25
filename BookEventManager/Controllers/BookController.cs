using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shared_Library;
using Shared_Library.Interface;
using BLL;


namespace BookEventManager.Controllers
{
    public class BookController : Controller
    {
        IBusinessBook _busibook;/*= new BusinessLogicBook();*/

        public BookController(IBusinessBook busibook)
        {
            _busibook = busibook;
        }

        public ActionResult CreateBookReadingEvent()
        {
            return View("BookEvent");
        }

        [HttpPost]

        public ActionResult Create([Bind(Include = "ID,EventType,Title,StartTime,Date,Location,Duration")] BookDTO book)
        {
            if (ModelState.IsValid)
            {
                book.UserID = int.Parse(Session["id"].ToString());
                _busibook.InsertBook(book);

                return RedirectToAction("ViewAction");

            }
            else
                return View("BookEvent");

        }


        public ActionResult ViewAction()
        {
            List<BookDTO>[] arraybooklist = new List<BookDTO>[2];
            var booklist = new List<BookDTO>();
            var beforeevent = new List<BookDTO>();
            var afterevent = new List<BookDTO>();
            booklist = _busibook.GetAll();

            foreach (BookDTO element in booklist)
            {
                if (element.Date < DateTime.Now)
                {
                    beforeevent.Add(element);
                }
                else
                {
                    afterevent.Add(element);
                }
            }
            arraybooklist[0] = beforeevent;
            arraybooklist[1] = afterevent;

            return View("ViewEvent", arraybooklist);
        }


        public ActionResult DetailsAction(BookDTO book)
        {
            return View("Details", book);
        }

        public ActionResult EditMyEvent(BookDTO book)
        {
            int id = int.Parse(Session["id"].ToString());
           
            return View("EditPage",book);

        }
        [HttpPost]
        public ActionResult EditEventPost(BookDTO book)
        {
            int id = int.Parse(Session["id"].ToString());
            _busibook.Update(book);
            return View("Details", book);

        }

        public ActionResult MyEvents()
        {
            List<BookDTO>[] myeventlist = new List<BookDTO>[2];
            var booklist = new List<BookDTO>();
            var beforeevent = new List<BookDTO>();
            var afterevent = new List<BookDTO>();
            int id = int.Parse(Session["id"].ToString());
            booklist = _busibook.GetAllList(id);
            foreach (BookDTO element in booklist)
            {
                if (element.Date < DateTime.Now)
                {
                    beforeevent.Add(element);
                }
                else
                {
                    afterevent.Add(element);
                }
            }
            myeventlist[0] = beforeevent;
            myeventlist[1] = afterevent;

            return View("ViewLoginUserEvents", myeventlist);

        }
    }
}