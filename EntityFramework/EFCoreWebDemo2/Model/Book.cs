    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    namespace EFCoreWebDemo
    { 
        public class Book
        {
            public int BookId { get; set; }
            
            [StringLength(255)]
            public string Title { get; set; }
            public int AuthorId { get; set; }
            public Author Author { get; set; }

            public ICollection<Review> Reviews { get; set; } = new List<Review>();
        }
    }