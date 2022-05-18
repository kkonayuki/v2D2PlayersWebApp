using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.Services.Models.Player
{
    public class Player_ResultSet
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public int countryId { get; set; }
        public int? teamId { get; set; }
        public string lastName { get; set; }
        public string nickName { get; set; }

        [Range(1, 100)]
        public int age { get; set; }
        public decimal? prizeMoney { get; set; }
    }
}
