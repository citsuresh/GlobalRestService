using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GlobalRestService.Models;
using Newtonsoft.Json;

namespace GlobalRestService.Controllers
{
	public class ValuesController : ApiController
	{
		private GlobalAssetRestServiceModel db = new GlobalAssetRestServiceModel();

		// GET api/values
		public IEnumerable<AssetCounter> Get()
		{
			return db.AssetCounters.ToList();
		}

		// GET api/values/5
		public string Get(int id)
		{
			var existingCounter = db.AssetCounters.FirstOrDefault(counter => counter.AssetCounterID == id);

			if (existingCounter != null)
			{
				return JsonConvert.SerializeObject(existingCounter);
			}

			return string.Empty;
		}

		// POST api/values
		public void Post([FromBody]AssetCounter jsonValue)
		{
			if (jsonValue == null)
				return;
			var existingCounter = db.AssetCounters.FirstOrDefault(counter => string.Compare(counter.ClientIdentifier, jsonValue.ClientIdentifier, StringComparison.InvariantCulture) == 0  && counter.AssetType == jsonValue.AssetType && counter.AssetSubType == jsonValue.AssetSubType);

			using (var tx = db.Database.BeginTransaction())
			{
				try
				{
					if (existingCounter != null)
					{
						existingCounter.Count += jsonValue.Count;
					}
					else
					{
						db.AssetCounters.Add(jsonValue);
					}

					db.SaveChanges();
					tx.Commit();
				}
				catch (Exception)
				{
					tx.Rollback();
				}
			}
		}

		// PUT api/values/5
		public void Put(int id, [FromBody] AssetCounter jsonValue)
		{
			if (jsonValue == null)
				return;

			var existingCounter = db.AssetCounters.FirstOrDefault(counter =>
				counter.AssetType == jsonValue.AssetType && counter.AssetSubType == jsonValue.AssetSubType);

			if (existingCounter != null)
			{
				using (var tx = db.Database.BeginTransaction())
				{
					try
					{
						existingCounter.Count += jsonValue.Count;
						db.SaveChanges();
						tx.Commit();
					}
					catch (Exception)
					{
						tx.Rollback();
					}
				}
			}
		}

		// DELETE api/values/5
		public void Delete(int id)
		{
			var existingCounter = db.AssetCounters.FirstOrDefault(counter => counter.AssetCounterID == id);

			if (existingCounter != null)
			{
				db.AssetCounters.Remove(existingCounter);
				db.SaveChanges();
			}
		}
	}
}
