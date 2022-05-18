using System.ComponentModel.DataAnnotations;

namespace WEB_API.Models.Player
{
    public class Player_Pass_Object
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string nickName { get; set; }
        public int countryId { get; set; }
        public int? teamId { get; set; }

        [Range(1, 100)]
        public int age { get; set; }
        public decimal? prizeMoney { get; set; }
    }
}
