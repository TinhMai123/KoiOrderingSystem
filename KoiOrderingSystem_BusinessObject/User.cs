using System;
using System.Collections.Generic;

namespace KoiOrderingSystem_BusinessObject
{
    public partial class User
    {
        public User()
        {
            CheckIns = new HashSet<CheckIn>();
            OrderProcesses = new HashSet<OrderProcess>();
            Reports = new HashSet<Report>();
        }

        public int UserId { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public DateTime? HireDate { get; set; }
        public int? RoleId { get; set; }
        public string? PasswordHash { get; set; }
        public string? PasswordSalt { get; set; }
        public DateTime? LastLogin { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual Role? Role { get; set; }
        public virtual Customer? Customer { get; set; }
        public virtual ICollection<CheckIn> CheckIns { get; set; }
        public virtual ICollection<OrderProcess> OrderProcesses { get; set; }
        public virtual ICollection<Report> Reports { get; set; }
    }
}
