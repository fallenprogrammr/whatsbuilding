using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace whatsbuilding.Models {
    public class BuildController{
        [Display(Name="Build controller")]
        public string Name { get; set; }
        [Display(Name="Controller status")]
        public string Status { get; set; }
        [Display(Name="Builds")]
        public List<Build> Builds{ get; set; }
    }
}