using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace E_Tickets.Models
{
    public class Cinema
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Logo of Cinema")]
        public string Logo { get; set; }
        [Display(Name = "Name ")]
        public string Name { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }
        //Realtionships
        public List<Movie> Movies { get; set; }
    }
}
