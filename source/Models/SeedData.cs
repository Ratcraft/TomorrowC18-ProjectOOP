using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new Context(
                serviceProvider.GetRequiredService<
                    DbContextOptions<Context>>()))
            {
                // Look for any station.
                if (context.Profile.Any())
                {
                    return;   // DB has been seeded
                }
                context.Profile.AddRange(
                    new Profile
                    {
                        firstName = "Alexis",
                        lastName = "DUCHET",
                        birthDate = "22/06/2001",
                        sex = "man",
                        group = "TS4",
                        subjectList = "Math, Bio"
                    }

                );
            }
        }
    }
}
