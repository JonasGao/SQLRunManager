﻿namespace SQLRunManager.Models
{
    public class User : Model
    {
        public string Email { get; set; }

        public string NickName { get; set; }

        public string Password { get; set; }
    }
}