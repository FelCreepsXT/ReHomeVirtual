﻿using System;

namespace ReHomeVirtualBackEnd.Initialization.Resources
{
    public class UserResource
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public DateTime Brithday { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public bool Active { get; set; }
    }
}
