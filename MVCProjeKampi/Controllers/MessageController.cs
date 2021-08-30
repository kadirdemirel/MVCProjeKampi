using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules.FluentValidation;
using DataAccessLayer.EntityFramework;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MVCProjeKampi.Controllers
{
    public class MessageController : Controller
    {
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        MessageValidator validationRules = new MessageValidator();
        // GET: Message
        [Authorize]
        public ActionResult Inbox()
        {
            string p;
            p = (string)Session["AdminUserName"];
            var inbox = messageManager.GetListInbox(p);
            ViewBag.value = inbox.Count();
            var messageList = messageManager.GetListInbox(p);


            return View(messageList);
        }

        public ActionResult SendBox()
        {
            string p;
            p = (string)Session["AdminUserName"];
            var messageList = messageManager.GetListSendBox(p);


            return View(messageList);
        }
        public ActionResult GetInboxMessageDetails(int id)
        {
            var messageValues = messageManager.GetById(id);
            messageValues.ReadReceipt = true;
            messageManager.MessageUpdate(messageValues);
            return View(messageValues);
        }
        public ActionResult GetSendBoxMessageDetails(int id)
        {
            var messageValues = messageManager.GetById(id);
            return View(messageValues);
        }
        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewMessage(EntityLayer.Concrete.Message message)
        {
            ValidationResult validationResult = validationRules.Validate(message);
            if (validationResult.IsValid)
            {
                message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                messageManager.MessageAdd(message);
                return RedirectToAction("SendBox");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}