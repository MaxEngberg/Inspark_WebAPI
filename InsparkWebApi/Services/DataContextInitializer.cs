using InsparkWebApi.Models;
using InsparkWebApi.Models.GroupItems;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace InsparkWebApi.Services
{
    public class DataContextInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        public UserManager<ApplicationUser> UserManager { get; private set; }
        //Method for inserting example-data into the database
        protected override void Seed(ApplicationDbContext dataContext)
        {

            var store = new UserStore<ApplicationUser>(dataContext);
            var userManager = new ApplicationUserManager(store);
            var Corax = new Section

            {
                Name = "Corax"
            };

            var Sesam = new Section
            {
                Name = "Sesam"
            };

            var Serum = new Section
            {
                Name = "Serum"
            };

            var Sobra = new Section
            {
                Name = "Sobra"
            };

            var Grythyttan = new Section
            {
                Name = "Grythyttan"
            };

            var Qultura = new Section
            {
                Name = "Qultura"
            };

            var Teknat = new Section
            {
                Name = "Teknat"
            };

            var GIH = new Section
            {
                Name = "GIH"
            };

            dataContext.Section.Add(Corax);
            dataContext.Section.Add(Sesam);
            dataContext.Section.Add(Serum);
            dataContext.Section.Add(Sobra);
            dataContext.Section.Add(Grythyttan);
            dataContext.Section.Add(Qultura);
            dataContext.Section.Add(Teknat);
            dataContext.Section.Add(GIH);
            dataContext.SaveChanges();

            var examplePerson1 = new ApplicationUser
            {
                FirstName = "Jesper",
                LastName = "Andersson",
                Email = "jesper@hotmail.com",
                UserName = "jesper@hotmail.com",
                Role = "Admin",
                Section = "Sesam"
            };
            userManager.Create(examplePerson1, "Jesper123");

            var exampleGroup = new Group
            {
                Name = "Gruppen",
                SectionId = 2
            };
            dataContext.Group.Add(exampleGroup);
            dataContext.SaveChanges();

        }
    }
}