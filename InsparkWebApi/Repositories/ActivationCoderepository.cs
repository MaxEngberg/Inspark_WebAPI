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
    public class ActivationCodeRepository : Repository<ActivationCode>
    {
        private readonly ApplicationDbContext context;

        public ActivationCodeRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }

        public int Count(int groupId)
        {
            return context.ActivationCode.Count(c => c.GroupId == groupId);
        }

        public ActivationCode GetGroupByCode(string code)
        {
            var codeInfo = Items.FirstOrDefault(u => u.Code == code);
            if (codeInfo == null)
            {
                return null;
            }
            else
            {
                return codeInfo;
            }
        }
    }
}