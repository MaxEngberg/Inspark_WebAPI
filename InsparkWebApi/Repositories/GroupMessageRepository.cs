using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InsparkWebApi.Models;
using InsparkWebApi.Models.GroupItems;
using InsparkWebApi.Repositories.Base;
using InsparkWebApi.Services;

namespace InsparkWebApi.Repositories
{
    
     public class GroupMessageRepository : Repository<GroupMessage>
     {
         public GroupMessageRepository(ApplicationDbContext context) : base(context)
         {

         }

     }
    
}