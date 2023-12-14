﻿using System.ComponentModel.DataAnnotations;

namespace MyShop.Models
{
    public class User
    {
        [Key]
        public Guid UserId { get; set; } 
        public string FullName { get; set; }
        public string Email { get; set; } 
        public string Password { get; set; }
        public string Role { get; set; } = "User";
    }
}
