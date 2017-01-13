using System;


namespace SWFC.Models
{
    public class MessageViewModel
    {
        public int MessageId { get; set; }

        public string Username { get; set; }

        public DateTime MessagePosted { get; set; } = DateTime.Now;

        public string MessageContent { get; set; }

        public string State { get; set; }
    }
}