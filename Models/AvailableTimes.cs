using System;
using System.ComponentModel.DataAnnotations;

namespace LaytonTemple.Models
{
    public class AvailableTimes
    {
        [Key]
        public String TimeSlot { get; set; }
        public int GroupID { get; set; }
    }
}
