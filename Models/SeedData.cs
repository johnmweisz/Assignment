using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Assignment.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new Context(serviceProvider.GetRequiredService<DbContextOptions<Context>>()))
            {
                if (context.Customers.Any())
                {
                    return;
                }
                context.Customers.AddRange(
                    new Customer
                    {
                        Name = "Willis Thomson",
                        Email = "willisthomson@gmail.com",
                        Gender = "M",
                        Registered = DateTime.Parse("2019-5-28"),
                        DayOne = true,
                        DayTwo = true,
                        DayThree = true,
                        Request = "Alt-rock"
                    },
                    new Customer
                    {
                        Name = "Maria Wong",
                        Email = "mariawong@gmail.com",
                        Gender = "F",
                        Registered = DateTime.Parse("2019-3-14"),
                        DayOne = false,
                        DayTwo = true,
                        DayThree = false,
                        Request = "Extra chardonnay"
                    },
                    new Customer
                    {
                        Name = "Oisin Feeney",
                        Email = "oisinfeeny@gmail.com",
                        Gender = "M",
                        Registered = DateTime.Parse("2019-1-4"),
                        DayOne = false,
                        DayTwo = false,
                        DayThree = true,
                        Request = "Fluffy pillows"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}