using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules.FluentValidation;
using DataAccessLayer.EntityFramework;
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
            var messageList = messageManager.GetListInbox();
            var messageList2 = messageManager.GetListSendBox();
            var contactValues = contactManager.GetList();
        
            ViewBag.value = messageList.Count();
            ViewBag.value2 = messageList2.Count();
            ViewBag.value3 = contactValues.Count();
            return PartialView();
        }
    }
}