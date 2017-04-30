using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TournamentTracker.Models;
using TournamentTracker.Models.GameModels;
using TournamentTracker.Models.TournamentModels;

namespace TournamentTracker.Data
{
    public class DataSeed
    {
        public async void Seed()
        {
            using (var context = new ApplicationDbContext())
            {
                if (!context.Users.Any())
                {
                    await seedUsers();
                }
                if (!context.Location.Any())
                {
                    SeedLocations();
                }
                if (!context.Rules.Any())
                {
                    SeedRules();
                }
                if (!context.Event.Any())
                {
                    SeedEvents();
                    Games();

                }

            }
        }
        private DateTime GenererateRandomDate()
        {
            Random rnd = new Random();
            int year = rnd.Next(2017, 2018);
            int month = rnd.Next(1, 12);
            int day = DateTime.DaysInMonth(year, month);
            int hour = rnd.Next(1, 24);
            int minute = rnd.Next(1, 60);
            int second = rnd.Next(1, 60);
            int Day = rnd.Next(1, day);

            DateTime dt = new DateTime(year, month, Day, hour, minute, second);
            return dt;
        }

        private void SeedEvents()
        {
            using (var context = new ApplicationDbContext())
            {
                var LocationIDs = context.Location.ToList();
                Random rnd = new Random();
                Event[] events =
                {
                    new Event
                    {
                        EventName = "TestName1",
                        EventPackURL = "https://www.youtube.com/watch?v=-0oZNWif_jk",
                        LocationID = LocationIDs[rnd.Next(LocationIDs.Count)].LocationID,
                        Description = "This is a test description",
                        FoodDescription = "Loads and loads of pizza for everyone!",
                        StartTime = GenererateRandomDate(),
                        EndTime = GenererateRandomDate(),
                        NumberOfTables = rnd.Next(1,30),
                        EventRestrictions = "No restrictions here.",
                    },
                    new Event
                    {
                        EventName = "TestName2",
                        EventPackURL = "https://www.youtube.com/watch?v=-0oZNWif_jk",
                        LocationID = LocationIDs[rnd.Next(LocationIDs.Count)].LocationID,
                        Description = "This is a test description",
                        FoodDescription = "Loads and loads of pizza for everyone!",
                        StartTime = GenererateRandomDate(),
                        EndTime = GenererateRandomDate(),
                        NumberOfTables = rnd.Next(1,30),
                        EventRestrictions = "No restrictions here.",
                    },
                    new Event
                    {
                        EventName = "TestName3",
                        EventPackURL = "https://www.youtube.com/watch?v=-0oZNWif_jk",
                        LocationID = LocationIDs[rnd.Next(LocationIDs.Count)].LocationID,
                        Description = "This is a test description",
                        FoodDescription = "Loads and loads of pizza for everyone!",
                        StartTime = GenererateRandomDate(),
                        EndTime = GenererateRandomDate(),
                        NumberOfTables = rnd.Next(1,30),
                        EventRestrictions = "No restrictions here.",
                    },
                    new Event
                    {
                        EventName = "TestName4",
                        EventPackURL = "https://www.youtube.com/watch?v=-0oZNWif_jk",
                        LocationID = LocationIDs[rnd.Next(LocationIDs.Count)].LocationID,
                        Description = "This is a test description",
                        FoodDescription = "Loads and loads of pizza for everyone!",
                        StartTime = GenererateRandomDate(),
                        EndTime = GenererateRandomDate(),
                        NumberOfTables = rnd.Next(1,30),
                        EventRestrictions = "No restrictions here.",
                    },
                    new Event
                    {
                        EventName = "TestName5",
                        EventPackURL = "https://www.youtube.com/watch?v=-0oZNWif_jk",
                        LocationID = LocationIDs[rnd.Next(LocationIDs.Count)].LocationID,
                        Description = "This is a test description",
                        FoodDescription = "Loads and loads of pizza for everyone!",
                        StartTime = GenererateRandomDate(),
                        EndTime = GenererateRandomDate(),
                        NumberOfTables = rnd.Next(1,30),
                        EventRestrictions = "No restrictions here.",
                    },
                    new Event
                    {
                        EventName = "TestName6",
                        EventPackURL = "https://www.youtube.com/watch?v=-0oZNWif_jk",
                        LocationID = LocationIDs[rnd.Next(LocationIDs.Count)].LocationID,
                        Description = "This is a test description",
                        FoodDescription = "Loads and loads of pizza for everyone!",
                        StartTime = GenererateRandomDate(),
                        EndTime = GenererateRandomDate(),
                        NumberOfTables = rnd.Next(1,30),
                        EventRestrictions = "No restrictions here.",
                    },
                    new Event
                    {
                        EventName = "TestName7",
                        EventPackURL = "https://www.youtube.com/watch?v=-0oZNWif_jk",
                        LocationID = LocationIDs[rnd.Next(LocationIDs.Count)].LocationID,
                        Description = "This is a test description",
                        FoodDescription = "Loads and loads of pizza for everyone!",
                        StartTime = GenererateRandomDate(),
                        EndTime = GenererateRandomDate(),
                        NumberOfTables = rnd.Next(1,30),
                        EventRestrictions = "No restrictions here.",
                    },
                    new Event
                    {
                        EventName = "TestName8",
                        EventPackURL = "https://www.youtube.com/watch?v=-0oZNWif_jk",
                        LocationID = LocationIDs[rnd.Next(LocationIDs.Count)].LocationID,
                        Description = "This is a test description",
                        FoodDescription = "Loads and loads of pizza for everyone!",
                        StartTime = GenererateRandomDate(),
                        EndTime = GenererateRandomDate(),
                        NumberOfTables = rnd.Next(1,30),
                        EventRestrictions = "No restrictions here.",
                    },
                    new Event
                    {
                        EventName = "TestName9",
                        EventPackURL = "https://www.youtube.com/watch?v=-0oZNWif_jk",
                        LocationID = LocationIDs[rnd.Next(LocationIDs.Count)].LocationID,
                        Description = "This is a test description",
                        FoodDescription = "Loads and loads of pizza for everyone!",
                        StartTime = GenererateRandomDate(),
                        EndTime = GenererateRandomDate(),
                        NumberOfTables = rnd.Next(1,30),
                        EventRestrictions = "No restrictions here.",
                    },
                    new Event
                    {
                        EventName = "TestName10",
                        EventPackURL = "https://www.youtube.com/watch?v=-0oZNWif_jk",
                        LocationID = LocationIDs[rnd.Next(LocationIDs.Count)].LocationID,
                        Description = "This is a test description",
                        FoodDescription = "Loads and loads of pizza for everyone!",
                        StartTime = GenererateRandomDate(),
                        EndTime = GenererateRandomDate(),
                        NumberOfTables = rnd.Next(1,30),
                        EventRestrictions = "No restrictions here.",
                    },
                    new Event
                    {
                        EventName = "TestName11",
                        EventPackURL = "https://www.youtube.com/watch?v=-0oZNWif_jk",
                        LocationID = LocationIDs[rnd.Next(LocationIDs.Count)].LocationID,
                        Description = "This is a test description",
                        FoodDescription = "Loads and loads of pizza for everyone!",
                        StartTime = GenererateRandomDate(),
                        EndTime = GenererateRandomDate(),
                        NumberOfTables = rnd.Next(1,30),
                        EventRestrictions = "No restrictions here.",
                    },
                    new Event
                    {
                        EventName = "TestName12",
                        EventPackURL = "https://www.youtube.com/watch?v=-0oZNWif_jk",
                        LocationID = LocationIDs[rnd.Next(LocationIDs.Count)].LocationID,
                        Description = "This is a test description",
                        FoodDescription = "Loads and loads of pizza for everyone!",
                        StartTime = GenererateRandomDate(),
                        EndTime = GenererateRandomDate(),
                        NumberOfTables = rnd.Next(1,30),
                        EventRestrictions = "No restrictions here.",
                    }
                };
                var allUsers = context.Users.ToList();
                foreach (Event e in events)
                {
                    int i = rnd.Next(allUsers.Count);
                    context.Add(e);
                    EventOrganiser EO = new EventOrganiser();
                    EO.EventID = e.EventID;
                    EO.UserID = allUsers[i].Id;
                    context.Add(EO);
                    context.SaveChanges();
                }
            }
        }

        private async Task seedUsers()
        {
            using (var context = new ApplicationDbContext())
            {
                var user = new ApplicationUser
                {
                    UserName = "Darkbeno",
                    NormalizedEmail = "KHORNE2009@LIVE.CO.UK",
                    NormalizedUserName = "DARKBENO",
                    Firstname = "Ben",
                    Lastname = "Haigh",
                    Email = "khorne2009@live.co.uk",
                    SecurityStamp = Guid.NewGuid().ToString("D")
                };
                var password = new PasswordHasher<ApplicationUser>();
                var hashed = password.HashPassword(user, "test222");
                user.PasswordHash = hashed;
                var userStore = new UserStore<ApplicationUser>(context);
                await userStore.CreateAsync(user);
                await context.SaveChangesAsync();
            }
            using (var context = new ApplicationDbContext())
            {
                var user = new ApplicationUser
                {
                    UserName = "TestUser",
                    Firstname = "Test",
                    NormalizedEmail = "TESTUSER@LIVE.CO.UK",
                    NormalizedUserName = "TESTUSER",
                    Lastname = "Haigh",
                    Email = "TestUser@live.co.uk",
                    SecurityStamp = Guid.NewGuid().ToString("D")
                };
                var password = new PasswordHasher<ApplicationUser>();
                var hashed = password.HashPassword(user, "Test123456");
                user.PasswordHash = hashed;
                var userStore = new UserStore<ApplicationUser>(context);
                await userStore.CreateAsync(user);
                await context.SaveChangesAsync();
            }
            using (var context = new ApplicationDbContext())
            {
                var user = new ApplicationUser
                {
                    UserName = "TestUser2",
                    Firstname = "TestTheSecond",
                    Lastname = "Haigh",
                    NormalizedEmail = "TESTUSER2@LIVE.CO.UK",
                    NormalizedUserName = "TESTUSER2",
                    Email = "TestUser2@live.co.uk",
                    SecurityStamp = Guid.NewGuid().ToString("D")
                };

                var password = new PasswordHasher<ApplicationUser>();
                var hashed = password.HashPassword(user, "Test123456");
                user.PasswordHash = hashed;
                var userStore = new UserStore<ApplicationUser>(context);
                await userStore.CreateAsync(user);
                await context.SaveChangesAsync();
            }
        }

        private List<int> SeedLocations()
        {
            List<int> LocationIDs = new List<int>();
            using (var context = new ApplicationDbContext())
            {
                var allUsers = context.Users.ToList();
                if (!context.Location.Any())
                {
                    Location[] locations =
                    {
                        new Location {
                            LocationName = "Holmfirth",
                            AddressLine1 = "Test1234",
                            AddressLine2 = "TestAddressLine2",
                            City = "TestCity",
                            County = "TestCounty",
                            PostCode = "HD96DZ",
                            PhoneNumber = "01484859567",
                            FacebookURL = "2",
                            WebsiteURL ="2",
                            TwitterURL = "2",
                            Email = "userlol@test.com"
                        },
                        new Location {
                            LocationName = "Warhammer World",
                            AddressLine1 = "Test1234",
                            AddressLine2 = "TestAddressLine2",
                            City = "TestCity",
                            County = "TestCounty",
                            PostCode = "HD96DZ",
                            PhoneNumber = "01484859567",
                            FacebookURL = "https://www.youtube.com/watch?v=lexLAjh8fPA",
                            WebsiteURL ="https://www.youtube.com/watch?v=lexLAjh8fPA",
                            TwitterURL = "https://www.youtube.com/watch?v=lexLAjh8fPA",
                            Email = "userlol@test.com"
                        },
                        new Location {
                            LocationName = "Cellar Dwellers",
                            AddressLine1 = "Test1234",
                            AddressLine2 = "TestAddressLine2",
                            City = "TestCity",
                            County = "TestCounty",
                            PostCode = "HD96DZ",
                            PhoneNumber = "01484859567",
                            FacebookURL = "https://www.youtube.com/watch?v=lexLAjh8fPA",
                            WebsiteURL ="https://www.youtube.com/watch?v=lexLAjh8fPA",
                            TwitterURL = "https://www.youtube.com/watch?v=lexLAjh8fPA",
                            Email = "userlol@test.com"
                        }
                    };
                    Random rnd = new Random();
                    foreach (Location l in locations)
                    {
                        int i = rnd.Next(allUsers.Count);
                        context.Add(l);
                        LocationAdmin admin = new LocationAdmin();
                        admin.UserID = allUsers[i].Id;
                        admin.LocationID = l.LocationID;
                        context.Add(admin);
                        context.SaveChanges();
                        LocationIDs.Add(l.LocationID);
                    }
                }
            }
            return LocationIDs;
        }
        private void SeedRules()
        {
            using (var context = new ApplicationDbContext())
            {
                if (!context.Rules.Any())
                {
                    Rules[] rules =
                    {
                       new Rules
                       {
                           RuleName = "Slay The Warlord",
                           Rule = "Kill the enemies commander"
                       },
                       new Rules
                       {
                           RuleName = "First Blood",
                           Rule = "Kill the first unit"
                       },
                       new Rules
                       {
                           RuleName = "First Blood test",
                           Rule = "Kill the first unit"
                       },
                       new Rules
                       {
                           RuleName = "First Blood test2",
                           Rule = "Kill the first unit"
                       },
                       new Rules
                       {
                           RuleName = "First Blood test3",
                           Rule = "Kill the first unit"
                       },
                       new Rules
                       {
                           RuleName = "First Blood test4",
                           Rule = "Kill the first unit"
                       },
                       new Rules
                       {
                           RuleName = "First Blood test5",
                           Rule = "Kill the first unit"
                       },
                       new Rules
                       {
                           RuleName = "First Blood test6",
                           Rule = "Kill the first unit"
                       }
                    };
                    foreach (Rules rule in rules)
                    {

                        context.Add(rule);
                        context.SaveChanges();
                    }
                }
            }
        }

        private void Games()
        {
            using (var context = new ApplicationDbContext())
            {
               
            }
        }

    }
}


