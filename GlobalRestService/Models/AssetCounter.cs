namespace GlobalRestService.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AssetCounter")]
    public partial class AssetCounter
    {
        public int AssetCounterID { get; set; }

        public int AssetType { get; set; }

        public int AssetSubType { get; set; }

        public int Count { get; set; }

        [StringLength(255)]
        public string ClientID { get; set; }
    }
}
