﻿namespace QLNhaTro_API.Models
{
    public class Message
    {
        private int status;
        private string notification;

        public Message(int status, string notification)
        {
            this.status = status;
            this.notification = notification;
        }

        public string Notification { get => notification; set => notification = value; }
        public int Status { get => status; set => status = value; }
    }
}