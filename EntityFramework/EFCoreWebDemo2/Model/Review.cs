    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    namespace EFCoreWebDemo
    { 
        public class Review
        {
            public int ReviewId { get; set; }
            
            [StringLength(50)]
            public string ReviewerName { get; set; }
            
            public int BookId { get; set; }
            public Book Book { get; set; }

            [StringLength(225)]
            public string ReviewDescription { get; set; }
       
        }
    }
