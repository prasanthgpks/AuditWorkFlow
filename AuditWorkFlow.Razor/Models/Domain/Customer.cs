﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AuditWorkFlow.Razor.Models.Domain
{
    public class Customer
    {
        public Guid Id { get; set; }
        [MaxLength(150)]
        [MinLength(3)]
        [Required(ErrorMessage = "Length should be min 3 and max 150")]
        public string FirstName { get; set; }
        [MaxLength(150)]
        public string LastName { get; set; }
        [MaxLength(150)]
        public string Email { get; set; }
        [MaxLength(150)]
        public string CountryCode { get; set; }
        [MaxLength(150)]
        public string PhoneNumber { get; set; }
        [MaxLength(150)]
        public string PanNumber { get; set; }
        [DefaultValue(1)]
        public int StatusCode { get; set; }

        public string Status { get; set; }

    }
}
