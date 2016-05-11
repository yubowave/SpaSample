using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SpaSample.Models
{
    public enum Status
    {
        Opening = 0,
        Closed = 1,
    }

    public class EventModel
    {
        public int Id { get; set; }

        [Required][MinLength(8)]
        public string Title { get; set; }

        public string Description { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public String Owner { get; set; }
        public Status Status { get; set; }
    }
}