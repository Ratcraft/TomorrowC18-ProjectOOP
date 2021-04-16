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
                if (context.Student.Any())
                {
                    return;   // DB has been seeded
                }
                context.Student.AddRange(
                    new Student
                    {
                        firstName = "Alexis",
                        lastName = "DUCHET",
                        birthDate = "22/06/2001",
                        sex = "man",
                        emailAdress = "ouioui@oui.fr",
                        password = "bonjour",
                        passwordHash = "ntm",
                        group = "TS4",
                        progress = 12,
                        subjectList = "Math, Bio"
                    }

                );
            }
        }
    }
}
