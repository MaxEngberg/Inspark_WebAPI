﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InsparkWebApi.Models;
using InsparkWebApi.Repositories.Base;
using InsparkWebApi.Services;

namespace InsparkWebApi.Repositories
{
    public class ChallengesRepository : Repository<Challenges>
    {
        public ChallengesRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}