    using Microsoft.AspNetCore.Identity;
    using BlogTravel.Models;

//namespace BlogTravel.Data
//{
//    public class Seed
//    {
//        public static void SeedData(IApplicationBuilder applicationBuilder)
//        {
//            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
//            {
//                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

//                context.Database.EnsureCreated();

//                if (!context.Holidays.Any())
//                {
//                    context.Holidays.AddRange(new List<Holiday>()
//                {
//                    new Holiday()
//                    {
//                        Title = "Running Holiday 1",
//                        Image = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
//                        Description = "This is the description of the first cinema",
//                        HolidayCategory = HolidayCategory.Africa,
//                        Address = new Address()
//                        {
//                            Street = "123 Main St",
//                            City = "Charlotte"
//                        }
//                     },
//                    new Holiday()
//                    {
//                        Title = "Running Holiday 2",
//                        Image = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
//                        Description = "This is the description of the first cinema",
//                        HolidayCategory = HolidayCategory.Europe,
//                        Address = new Address()
//                        {
//                            Street = "123 Main St",
//                            City = "Charlotte"
//                        }
//                    },
//                    new Holiday()
//                    {
//                        Title = "Running Holiday 3",
//                        Image = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
//                        Description = "This is the description of the first holiday",
//                        HolidayCategory = HolidayCategory.Europe,
//                        Address = new Address()
//                        {
//                            Street = "123 Main St",
//                            City = "Charlotte"
//                        }
//                    },
//                    new Holiday()
//                    {
//                        Title = "Running Holiday 3",
//                        Image = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
//                        Description = "This is the description of the first holiday",
//                        HolidayCategory = HolidayCategory.Europe,
//                        Address = new Address()
//                        {
//                            Street = "123 Main St",
//                            City = "Michigan"
//                        }
//                    }
//                });
//                    context.SaveChanges();
//                }
//                //Adventures
//                if (!context.Adventures.Any())
//                {
//                    context.Adventures.AddRange(new List<Adventure>()
//                {
//                    new Adventure()
//                    {
//                        Title = "Running Adventure 1",
//                        Image = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
//                        Description = "This is the description of the first adventure",
//                        AdventureCategory = AdventureCategory.Africa,
//                        Address = new Address()
//                        {
//                            Street = "123 Main St",
//                            City = "Charlotte"
//                        }
//                    },
//                    new Adventure()
//                    {
//                        Title = "Running Adventure 2",
//                        Image = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
//                        Description = "This is the description of the first adventure",
//                        AdventureCategory = AdventureCategory.America,
//                        AddressId = 5,
//                        Address = new Address()
//                        {
//                            Street = "123 Main St",
//                            City = "Charlotte"
//                        }
//                    }
//                });
//                    context.SaveChanges();
//                }
//            }
//        }

//    public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
//    {
//        using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
//        {
//            //Roles
//            var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

//            if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
//                await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
//            if (!await roleManager.RoleExistsAsync(UserRoles.User))
//                await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

//            //Users
//            var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
//            string adminUserEmail = "teddysmithdeveloper@gmail.com";

//            var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
//            if (adminUser == null)
//            {
//                var newAdminUser = new AppUser()
//                {
//                    UserName = "nadya",
//                    Email = nadya@gmail.com,
//                    EmailConfirmed = true,
//                    Address = new Address()
//                    {
//                        Street = "123 Main St",
//                        City = "Charlotte"
//                    }
//                };
//                await userManager.CreateAsync(newAdminUser, "Nadya@1234");
//                await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
//            }

//            string appUserEmail = "user@etickets.com";

//            var appUser = await userManager.FindByEmailAsync(appUserEmail);
//            if (appUser == null)
//            {
//                var newAppUser = new AppUser()
//                {
//                    UserName = "app-user",
//                    Email = appUserEmail,
//                    EmailConfirmed = true,
//                    Address = new Address()
//                    {
//                        Street = "123 Main St",
//                        City = "Charlotte"
//                    }
//                };
//                await userManager.CreateAsync(newAppUser, "Coding@1234?");
//                await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
//            }
//        }
//    }
//}
//}



namespace BlogTravel.Data
{
    public class Seed
    {
           
        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
                string adminUserEmail = "topcho@admin.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new AppUser()
                    {
                        UserName = "Topcho",
                        Email = adminUserEmail,
                        EmailConfirmed = true,
                        Address = new Address()
                        {
                            Street = "topchoStreet",
                            City = "TopchoCity"
                        }
                    };
                    await userManager.CreateAsync(newAdminUser, "Topcho@123");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }
            }
        }
    }
}