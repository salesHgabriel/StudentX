using Bogus;
using Companyx.Companyx.Studentx.Domain.Courses;
using Companyx.Companyx.Studentx.Domain.Users;
using Companyx.Companyx.Studentx.Infrastructure.DataContexts;
using Microsoft.AspNetCore.Identity;

namespace Companyx.Studentx.API.Extensions
{
    public static class SeedDataExtension
    {
        public static async void SeedFakeData(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();

            using var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            if (db.Users.Count() == 0)
            {
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();

                var fakerUsers = new Faker<User>()
                    .RuleFor(u => u.UserName, f => f.Internet.UserName())
                    .RuleFor(u => u.Email, f => f.Internet.Email());

                for (int i = 0; i < 10; i++)
                {
                    var fUser = fakerUsers.Generate();
                    string fakePass = "FakePassWord123!!";

                    await userManager.CreateAsync(fUser, fakePass);
                }
            }

            if (db.Courses.Count() == 0)
            {
                var fakerCourse = new Faker<Course>()
                    .RuleFor(u => u.Name, f => f.Name.FirstName())
                    .RuleFor(u => u.Description, f => f.Lorem.Text())
                    .Generate(10);

                await db.Courses.AddRangeAsync(fakerCourse);
                await db.SaveChangesAsync();
            }
        }
    }
}