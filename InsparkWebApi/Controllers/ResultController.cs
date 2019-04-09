using InsparkWebApi.Models;
using InsparkWebApi.Repositories;
using InsparkWebApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace InsparkWebApi.Controllers
{
    public class ResultController : ApiController
    {
        private ApplicationDbContext dataContext = new ApplicationDbContext();
        private ResultRepository resultRepository;

        public ResultController()
        {
            resultRepository = new ResultRepository(dataContext);
        }

        [HttpGet]
        // GET: oruinsparkwebapi.azurewebsites.net/api/Result
        public IEnumerable<Result> Get()
        {
            var allResults = resultRepository.ShowAll().ToList();

            return allResults;
        }

        [HttpPost]
        // POST: oruinsparkwebapi.azurewebsites.net/api/Result
        public void Post([FromBody]Result result)
        {
            resultRepository.Add(result);
            resultRepository.SaveChanges(result);
        }

        [HttpPost]
        // POST: oruinsparkwebapi.azurewebsites.net/api/Result/EditResult
        public HttpResponseMessage EditResult([FromBody]EditResultModel editResultModel)
        {
            Result result = resultRepository.GetById(editResultModel.Id);

            if (result == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Not found");
            }
            else
            {
                result.TotalPoints = editResultModel.TotalPoints;

                resultRepository.SaveChanges(result);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
        }

    }
}
