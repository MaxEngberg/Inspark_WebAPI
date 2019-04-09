using InsparkWebApi.Repositories.Base;
using InsparkWebApi.Services;
using InsparkWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq.Expressions;

namespace InsparkWebApi.Repositories
{
    public class UserRepository : Repository<ApplicationUser>
    {
        private readonly ApplicationDbContext context;

        public UserRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }
        //Method for getting a user with a specific id in the database.
        public ApplicationUser GetByIdUser(string id)
        {
            return Items.Find(id);
        }

        public ApplicationUser FindByUserName(string userName)
        {
            var username = Items.FirstOrDefault(u => u.UserName == userName);
            return username;
        }

        //Method for removing a user with a specific id in the database.
        public void RemoveUser(string id)
        {
            var entity = GetByIdUser(id);
            Items.Remove(entity);
        }
    }   
}