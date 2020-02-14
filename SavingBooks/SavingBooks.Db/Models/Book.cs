using System;
using System.ComponentModel.DataAnnotations;

namespace DB.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        public string Name { get; set; }
        public DateTime PublicationDate { get; set; }
        public string Description { get; set; }
        public int PageAmount { get; set; }
    }
}
