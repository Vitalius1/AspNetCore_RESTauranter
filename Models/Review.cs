using System;
using System.ComponentModel.DataAnnotations;

namespace RESTauranter.Models
{
    public class Review
    {
        [Required]
        public int ReviewId { get; set; }
        
        [Required]
        [Display(Name = "Restaurant Name:")]
        public string ResName { get; set; }
        
        [Required]
        [Display(Name = "Reviewer Name:")]
        public string RevName { get; set; }
        
        [Required]
        [MinLength(10)]
        [Display(Name = "Review:")]
        public string Content { get; set; }
        
        [Required]
        [Display(Name = "Stars:")]
        public string Stars { get; set; }
        
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date of visit:")]
        public DateTime DateVisited { get; set; }
    }
}