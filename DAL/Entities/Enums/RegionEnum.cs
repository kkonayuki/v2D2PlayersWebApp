using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities.Enums
{
    public enum Region
    {
        [Display(Name = "North America")]
        NA,
        [Display(Name = "South America")]
        SA,
        [Display(Name = "Western Europe")]
        WEU,
        [Display(Name = "Eastern Europe")]
        EEU,
        [Display(Name = "China")]
        CN,
        [Display(Name = "Southeast Asia")]
        SEA
    }
}
