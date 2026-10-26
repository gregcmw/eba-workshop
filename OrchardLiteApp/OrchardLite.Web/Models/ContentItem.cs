using System;

namespace OrchardLite.Web.Models
{
    public class ContentItem
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Summary { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        public string ContentType { get; set; } = string.Empty;
        public int AuthorId { get; set; }
        public DateTime PublishedDate { get; set; }
        public int ViewCount { get; set; }
        public bool IsPublished { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
