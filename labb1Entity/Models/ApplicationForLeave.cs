using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace labb1Entity.Models
{
    public class ApplicationForLeave
    {
        public ApplicationForLeave()
        {
            TimeOfApplication = DateTime.Now.TimeOfDay.ToString();
            DateOfApplication = DateTime.Now.Date.ToString();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public string EmployeeName { get; set; }
        [Required]
        public string EployeePhone { get; set; }
        [Required]
        public string TypeOFLeave { get; set; }
        [Required]
        public DateTime DateStartForLeave { get; set; }
        [Required]
        public DateTime DateEndForLeave { get; set; }
        public string DateOfApplication { get; set; }
        public string TimeOfApplication { get; set; } 

    }
}
