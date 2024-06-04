﻿using CleanArchitecture.Domain.Products.Entities;
using CleanArchitecture.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using MyTown.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Persistence.Seeds
    {
    public static class DefaultData
        {
        public static async Task SeedAsync(ApplicationDbContext applicationDbContext)
            {
            // return;//if you want to skip then uncomment this return statement;
            bool changedExists = false;
            /*
            if (!await applicationDbContext.Products.AnyAsync())
                {
                List<Product> defaultProducts = [
                    new Product("Product 1",100000,"111111111111"),
                    new Product("Product 2",150000,"222222222222"),
                    new Product("Product 3",200000,"333333333333"),
                    new Product("Product 4",105000,"444444444444"),
                    new Product("Product 5",200000,"555555555555")
                    ];

                await applicationDbContext.Products.AddRangeAsync(defaultProducts);
                changedExists = true;
                }*/
            Console.WriteLine("Seed data loading");

            var existingTowns = await applicationDbContext.Towns.ToListAsync();

            List<Town> townsMasterdata = [
               new Town(){ Name="Bhadravathi",SubTitle="Iron & Steel Rusting Town",Active=true,District="Shivamogga",State="Karnataka"
                      ,GoogleMapAddressUrl="https://www.google.com/maps/place/Bhadravathi,+Karnataka/@13.8425707,75.692868,14.02z/data=!4m6!3m5!1s0x3bbb0004bae5616f:0x5eab5b9250ba013e!8m2!3d13.8275718!4d75.7063783!16zL20vMDh3aGpx?entry=ttu",
                      UrlName1="Bhadravathi.com",UrlName2= "Bdvt.in",OtherReferenceUrl="https://en.wikipedia.org/wiki/Bhadravati,_Karnataka",
                      Id=1},
                    new Town(){Name="Kadur",UrlName1="Kadur.in",Id=2 },
                    new Town(){Name="Birur",UrlName1="Birur.in",Id=3 },
                    new Town(){Name="Tarikere",UrlName1="Tarikere.in",Id=4 },
                    new Town(){Name="Arsikere",UrlName1="Arsikere.in",Id=5 },
                    new Town(){Name="Honnavara",UrlName1="Honnavar.in",Id=6 },
                    ];
            Console.WriteLine($"existingTowns count {existingTowns.Count},towns count {townsMasterdata.Count} Starting");

            if (existingTowns != null)
                {
                townsMasterdata.ForEach(town =>
                {
                    if (!existingTowns.Exists(e => e.Id == town.Id))
                        {
                        applicationDbContext.Towns.Add(town);
                        changedExists = true;
                        }

                });
                }
            else
                {
                await applicationDbContext.Towns.AddRangeAsync(townsMasterdata);
                changedExists = true;
                }
            Console.WriteLine("Town seeds update exists:" + changedExists);

            var existingCardTypes = await applicationDbContext.CardTypes.ToListAsync();
            List<TownCardType> cardTypes = [
            new (1,"Town"),
            new (2,"Priority Message"),//flash message
            new (3,"Event"),
            new (4,"Premium Shops"),
            new (5,"Doctor Clinic Hospital"),
            new (6,"School College Tuition"),

            //business types
            new (7,"Vehicle Garage Bike Car Scooter","Vehicle Garage"),
            new (8,"Hotel Lodge Restaurant"),
            new (9,"Textiles Tailors Designers"),
            new (10,"Beauticians Saloons Hair Cut"),
            new (11,"Electricals Home Appliances"),
            new (12,"Choultry & Convention Hall"),
            new (13,"Shops,Provision Stores,Super Markets"),//Jewellary,saw mills
            new (14,"Gas Agency Petrol Bunks"),
            new (15,"Bank,Govt Offices"),

            new (16,"Real Estate"),
            new (17,"Buy Or sale"),
            new (18,"Open Issue"),
            new (19,"Jobs Available"),
            new (20,"Add Resume"),
            //user complaints
            ];

            Console.WriteLine($"existingCardTypes count {existingCardTypes.Count},cardTypes count {cardTypes.Count}");
            if (existingCardTypes != null)
                {
                cardTypes.ForEach(cardType =>
                {
                    if (!existingCardTypes.Exists(e => e.Id == cardType.Id))
                        {
                        applicationDbContext.CardTypes.Add(cardType);
                        changedExists = true;
                        }

                });
                }
            else
                {
                await applicationDbContext.CardTypes.AddRangeAsync(cardTypes);
                changedExists = true;
                }

            Console.WriteLine("Seeds update exists:" + changedExists);
            if (changedExists)
                {
                Console.WriteLine("Seed Data SavingToDb");
                var resultcount = await applicationDbContext.SaveChangesAsync();
                Console.WriteLine("Seed Data SavedToDb with Result Changes" + resultcount);
                }
            else {
                Console.WriteLine("No Seed Data Updation done");
                }
            }
        }
    }
