using DAL.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.Services.Models.Team
{
    public class Team_ResultSet
    {
        public int id { get; set; }
        public string name { get; set; }
        public Region region { get; set; }
    }
}
