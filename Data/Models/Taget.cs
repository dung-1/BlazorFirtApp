using Supabase.Postgrest.Models;
using Supabase.Postgrest.Attributes;

namespace BlazorApp1.Data.Models
{
    [Table("okrs")]
    public class Taget : BaseModel
    {
        [PrimaryKey("id")]
        public long Id { get; set; }  // hoặc int nếu là số nguyên 32-bit

        [Column("objective")]
        public string Objective { get; set; } = string.Empty;

        [Column("assignee")]
        public string Assignee { get; set; } = string.Empty;

        [Column("progress_percent")]
        public int ProgressPercent { get; set; }

        [Column("progress_status")]
        public string ProgressStatus { get; set; } = string.Empty;

        [Column("change")]
        public string Change { get; set; } = string.Empty;

        [Column("confidence")]
        public int Confidence { get; set; }

        [Column("checkin")]
        public string Checkin { get; set; } = string.Empty;

        [Column("status")]
        public string Status { get; set; } = string.Empty;
    }
}
