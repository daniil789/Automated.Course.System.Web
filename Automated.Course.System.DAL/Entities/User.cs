﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Automated.Course.System.DAL.Entities
{
    public partial class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime Birthday { get; set; }
    }
}
