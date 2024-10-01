using System;
using System.Collections.Generic;

namespace KoiOrderingSystem_BusinessObject
{
    public partial class OrderProcess
    {
        public int OrderProcessId { get; set; }
        public int? OrderId { get; set; }
        public int? UserId { get; set; }
        public string? ProcessStep { get; set; }
        public DateTime? StepDate { get; set; }
        public string? Notes { get; set; }
        public string? Status { get; set; }
        public bool? IsCompleted { get; set; }
        public string? AssignedTo { get; set; }
        public DateTime? ExpectedCompletionDate { get; set; }
        public DateTime? ActualCompletionDate { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual Order? Order { get; set; }
        public virtual User? User { get; set; }
    }
}
