namespace GlobalRestService.Models
{
	using System;
	using System.Data.Entity;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Linq;

	public partial class GlobalAssetRestServiceModel : DbContext
	{
		public GlobalAssetRestServiceModel()
			: base("name=GlobalAssetRestServiceModel")
		{
		}

		public virtual DbSet<AssetCounter> AssetCounters { get; set; }
		public virtual DbSet<GlobalAsset> GlobalAssets { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
		}
	}
}
