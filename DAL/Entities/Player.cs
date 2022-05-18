using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Player
    {
        public int Id { get; set; }
        public int CountryId { get; set; }
        public int? TeamId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NickName { get; set; }

        [Range(1, 100)]
        public int Age { get; set; }

        public Country? Country { get; set; }

        public Team? Team { get; set; }



        public decimal? PrizeMoney { get; set; }
    }
}
