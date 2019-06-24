using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnimalFarm.Models
{
    public class AnimalFarmItem
    {
        public long Id { get; set; }
        [ForeignKey("UserId")]
        public long UserId { get; set; }

        [Display(Name = "Animal Name")]
        [DataType(DataType.Text)]
        public string Name { get; set; }
        [Display(Name = "Animal Type")]
        [DataType(DataType.Text)]
        public string Type { get; set; }

        public DateTime BirthDate { get; set; }
        public DateTime StartDate { get; set; }
        public int Hunger { get; set; }
        public int Happiness { get; set; }

        public readonly int HappinessDecreaseRate;
        public readonly int HungerDecreaseRate;

        public bool IsAlive { get; set; }


    }
}
