﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string UserAddress { get; set; }
        public string UserPhoneNumber { get; set; }
        public string UserCompanyName { get; set; }
        public string UserCompanyAddress { get; set; }
    }
}