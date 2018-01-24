using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GlobalRestService.Models;

namespace AssetDBWebApi.Controllers
{
    public class ClientsController : ApiController
    {
        private GlobalAssetRestServiceModel Db = new GlobalAssetRestServiceModel();

        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            var cientIds = Db.GlobalAssets.Select(asset => asset.ClientID).Distinct();

            return cientIds;
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}