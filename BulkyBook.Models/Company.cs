﻿using System.ComponentModel.DataAnnotations;

namespace BulkyBook.Models
{
    public class Company
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Display(Name ="Street Address")]
        public string? StreetAddress { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        [Display(Name = "Postal Code")]
        public int? PostalCode { get; set; }
        [Display(Name = "Phone Number")]
        public int? PhoneNumber { get; set; }
    }
}
