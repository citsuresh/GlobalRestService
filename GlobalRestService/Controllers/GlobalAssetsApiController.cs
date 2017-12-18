using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using GlobalRestService.Models;
using Newtonsoft.Json;

namespace GlobalRestService.Controllers
{
	public class GlobalAssetsApiController : ApiController
	{

		private GlobalAssetRestServiceDBEntities db = new GlobalAssetRestServiceDBEntities();

		// GET api/<controller>
		public IEnumerable<GlobalAsset> Get()
		{
			try
			{
				return db.GlobalAssets.ToList();
			}
			catch (Exception e)
			{
				Debug.WriteLine(e);
				//throw new HttpResponseException(HttpStatusCode.SeeOther);
				var response = Request.CreateResponse(HttpStatusCode.InternalServerError);
				response.ReasonPhrase = e.Message;
				throw new HttpResponseException(response);
				//return new GlobalAsset[0];
			}
		}

		// GET api/<controller>/5
		public string Get(int id)
		{
			var existingCounter = db.GlobalAssets.FirstOrDefault(counter => counter.AssetID == id);

			if (existingCounter != null)
			{
				return JsonConvert.SerializeObject(existingCounter);
			}

			return string.Empty;
		}

		// POST api/<controller>
		public void Post([FromBody]GlobalAsset asset)
		{
			if (asset == null)
				return;
			using (var tx = db.Database.BeginTransaction())
			{
				try
				{
					db.GlobalAssets.AddOrUpdate(asset);

					db.SaveChanges();
					tx.Commit();
				}
				catch (Exception ex)
				{
					Debug.WriteLine(ex.Message);
					tx.Rollback();
					throw new HttpResponseException(HttpStatusCode.NotFound);
				}
			}
		}

		// PUT api/<controller>/5
		public void Put(int id, [FromBody]GlobalAsset asset)
		{
			if (asset == null)
				return;

			using (var tx = db.Database.BeginTransaction())
			{
				try
				{
					db.GlobalAssets.AddOrUpdate(asset);

					db.SaveChanges();
					tx.Commit();
				}
				catch (Exception ex)
				{
					Debug.WriteLine(ex.Message);
					tx.Rollback();
					throw new HttpResponseException(HttpStatusCode.NotFound);
				}
			}
		}

		// DELETE api/<controller>/5
		public void Delete(int id)
		{
			var existingCounter = db.GlobalAssets.FirstOrDefault(counter => counter.AssetID == id);

			if (existingCounter != null)
			{
				db.GlobalAssets.Remove(existingCounter);
				db.SaveChanges();
			}
		}
	}
}