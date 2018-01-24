using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GlobalRestService.Models;

namespace GlobalRestService.Controllers
{
    public class AssetsByClientController : ApiController
    {
        private GlobalAssetRestServiceModel Db = new GlobalAssetRestServiceModel();

        // GET api/<controller>
        public IEnumerable<GlobalAsset> Get()
        {
            var clientIdKeyValuePair = Request.GetQueryNameValuePairs().Where(pair => String.Equals(pair.Key, "clientid", StringComparison.OrdinalIgnoreCase));

            if (clientIdKeyValuePair.Any())
            {
                var clientId = clientIdKeyValuePair.First().Value;
                return Db.GlobalAssets.Where(asset => asset.ClientID == clientId);
            }

            return Db.GlobalAssets.ToList();
        }

        // GET api/<controller>/clientId
        public IEnumerable<GlobalAsset> Get(string clientid)
        {
            return Db.GlobalAssets.Where(asset => asset.ClientID == clientid);
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
