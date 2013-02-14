using System;
using System.ComponentModel.DataAnnotations;

namespace whatsbuilding.Models {
    public class Build {
        [DataType(DataType.Text)]
        [Display(Name="Current status")]
        public string Status { get; set; }
        [DataType(DataType.Text)]
        [Display(Name="Team project")]
        public string TeamProject { get; set; }
        [DataType(DataType.Text)]
        [Display(Name="Build definition name")]
        public string BuildDefinition { get; set; }
        [DataType(DataType.Text)]
        [Display(Name="Name")]
        public string Priority { get; set; }
        [DataType(DataType.DateTime)]
        [Display(Name="Build queued at")]
        public DateTime QueuedAt { get; set; }
        [DataType(DataType.Text)]
        [Display(Name="Build requested by")]
        public string RequestedBy { get; set; }
        [Display(Name="Build position")]
        public int Position { get; set; }
    }
}