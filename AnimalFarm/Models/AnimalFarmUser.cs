using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnimalFarm.Models
{
    public class AnimalFarmUser
    {
        public long Id { get; set; }
        [Display(Name = "User Name")]
        [DataType(DataType.Text)]
        public string NickName { get; set; }
        public string EmailAddr { get; set; }
        public DateTime LastLoginDate { get; set; }
        public int Rank { get; set; }
        public bool IsActiveUser { get; set; }
        public bool IsUserOnline { get; set; }

    }
}
