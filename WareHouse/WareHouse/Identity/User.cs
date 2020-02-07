﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WareHouse.Identity
{
	public class User
	{
        public int Id { get; set; }
        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public Role Role { get; set; }
    }

    public enum Role
    {
        Admin,
        Worker
    }
}
