using System;

namespace ChatMVC.Models
{
    public class Message
    {
        public int Id { get; set; }

        public string User { get; set; }

        public string MessageText { get; set; }

        public DateTime SentAt { get; set; }
    }
}