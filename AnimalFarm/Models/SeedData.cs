using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace AnimalFarm.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new AnimalFarmContext(
                serviceProvider.GetRequiredService<DbContextOptions<AnimalFarmContext>>()))
            {
                // Look for any animals
                if (!context.AFUsers.Any())
                {
                    context.AFUsers.AddRange(
                    new AnimalFarmUser
                    {
                        NickName = "Player1test",
                        EmailAddr = "user@domain.com"
                    }

                );
                }

                

                // Look for any animals
                if (context.AFItems.Any())
                {
                    return;   // DB has been seeded
                }

                context.AFItems.AddRange(
                    new AnimalFarmItem
                    {
                        Name = "Sally",
                        BirthDate = DateTime.Parse("2018-2-12"),
                        StartDate = DateTime.Parse("2019-2-4"),
                        UserId = 1,
                        IsAlive = true,
                        Type = "Dog"
                    },

                    new AnimalFarmItem
                    {
                        Name = "Penny",
                        BirthDate = DateTime.Parse("2018-2-12"),
                        StartDate = DateTime.Parse("2019-2-4"),
                        UserId = 1,
                        IsAlive = true,
                        Type = "Dog"
                    },

                    new AnimalFarmItem
                    {
                        Name = "Catty",
                        BirthDate = DateTime.Parse("2018-2-12"),
                        StartDate = DateTime.Parse("2019-2-4"),
                        UserId = 1,
                        IsAlive = true,
                        Type = "Cat"
                    },

                    new AnimalFarmItem
                    {
                        Name = "Stroby",
                        BirthDate = DateTime.Parse("2018-2-12"),
                        StartDate = DateTime.Parse("2019-2-4"),
                        UserId = 1,
                        IsAlive = true,
                        Type = "Mouse"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}