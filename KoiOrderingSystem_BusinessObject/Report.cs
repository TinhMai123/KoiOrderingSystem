using System;
using System.Collections.Generic;

namespace KoiOrderingSystem_BusinessObject
{
    public partial class Report
    {
        public int ReportId { get; set; }
        public string? ReportName { get; set; }
        public string? ReportType { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? ReportData { get; set; }
        public string? Description { get; set; }
        public bool? IsArchived { get; set; }
        public DateTime? LastAccessed { get; set; }
        public int? TotalViews { get; set; }
        public string? ReportStatus { get; set; }
        public decimal? TotalSales { get; set; }
        public int? TotalFeedbacks { get; set; }

        public virtual User? CreatedByNavigation { get; set; }
    }
}
