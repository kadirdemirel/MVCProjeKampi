using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules.FluentValidation;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjeKampi.Controllers
{
    public class ContactController : Controller
    {
        ContactManager contactManager = new ContactManager(new EfContactDal());
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        ContactValidator validationRules = new ContactValidator();

        // GET: Contact
        public ActionResult Index()
        {
            var contactValues = contactManager.GetList();
            ViewBag.value3 = contactValues.Count();
            return View(contactValues);
        }
        public ActionResult GetContactDetails(int id)
        {
            var contactValues = contactManager.GetById(id);
            return View(contactValues);

        }
        public PartialViewResult MessageListMenu()
        {
            string p;
            p = (string)Session["AdminUserName"];
            var inbox = messageManager.GetListInbox(p);
            ViewBag.value = inbox.Count();

           
            var messageList2 = messageManager.GetListSendBox(p);
            var contactValues = contactManager.GetList();

          
            ViewBag.value2 = messageList2.Count();
            ViewBag.value3 = contactValues.Count();
            return PartialView();
        }
        [HttpGet]
        public ActionResult ContactUs()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ContactUs(Contact contact)
        {

            ContactValidator contactValidator = new ContactValidator();
            ValidationResult validationResult = contactValidator.Validate(contact);
            if (validationResult.IsValid)
            {
                contact.ContactDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                contactManager.ContactAdd(contact);
                return RedirectToAction("HomePage", "Home");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }



        }
    }
}