using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace BlazorApp1.Data.Models
{
    [Table("news")]
    public class News : BaseModel
    {
        [PrimaryKey("id")]
        public Guid Id { get; set; }

        [Column("title")]
        public string Title { get; set; }

        [Column("subtitle")]
        public string Subtitle { get; set; }

        [Column("date")]
        public DateTime Date { get; set; }

        [Column("tag_type")]
        public string TagType { get; set; }

        [Column("tag_text")]
        public string TagText { get; set; }

        [Column("image")]
        public string Image { get; set; }

        [Column("background_class")]
        public string BackgroundClass { get; set; }

        [Column("height")]
        public string Height { get; set; }
    }
}
