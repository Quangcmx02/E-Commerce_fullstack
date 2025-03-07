﻿using Microsoft.AspNetCore.Identity;

namespace AsmC5.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? PhotoUrl { get; set; }
        public string? Adress { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiryTime { get; set; }

        public ICollection<Order> Orders { get; set; } = new List<Order>();

    }
}
