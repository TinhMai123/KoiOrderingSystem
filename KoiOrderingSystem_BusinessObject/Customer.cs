using System;
using System.Collections.Generic;

namespace KoiOrderingSystem_BusinessObject
{
    public partial class Customer
    {
        public Customer()
        {
            CheckIns = new HashSet<CheckIn>();
            CustomerSupports = new HashSet<CustomerSupport>();
            Feedbacks = new HashSet<Feedback>();
            Orders = new HashSet<Order>();
        }

        public int CustomerId { get; set; }
        public int? UserId { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public string? PreferredPaymentMethod { get; set; }
        public int? LoyaltyPoints { get; set; }
        public bool? IsVerified { get; set; }
        public DateTime? LastPurchaseDate { get; set; }
        public decimal? TotalSpent { get; set; }

        public virtual User? User { get; set; }
        public virtual ICollection<CheckIn> CheckIns { get; set; }
        public virtual ICollection<CustomerSupport> CustomerSupports { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
