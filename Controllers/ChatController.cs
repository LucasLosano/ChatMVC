using System;
using System.Linq;
using ChatMVC.Data;
using ChatMVC.DTO;
using ChatMVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ChatMVC.Controllers
{
    [Authorize]
    public class ChatController : Controller
    {
        public ApplicationDbContext Database { get; }

        public ChatController(ApplicationDbContext database)
        {
            this.Database = database;
        }

        public IActionResult Index()
        {
            ViewBag.Messages = Database.Messages.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult SendMessage(MessageDTO messageDTO)
        {
            if(!ModelState.IsValid)
            {
                ViewBag.Messages = Database.Messages.ToList();
                return View("Index");
            }

            Message message = new Message();
            message.MessageText = messageDTO.MessageText;
            message.User = messageDTO.User;
            message.SentAt = DateTime.Now;

            Database.Messages.Add(message);
            Database.SaveChanges();
            
            return RedirectToAction("Index","Chat");
        }

        [HttpGet]
        [AllowAnonymous]
        public string Messages()
        {
            var messageCount = Database.Messages.Count();

            return messageCount.ToString();
        }
    }
}