namespace GlobalRestService.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GlobalAsset")]
    public partial class GlobalAsset
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AssetID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AssetType { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AssetSubType { get; set; }

        [StringLength(255)]
        public string SerialNumber { get; set; }

        [StringLength(255)]
        public string ClientIdentifier { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(50)]
        public string Status { get; set; }

        [Column(TypeName = "date")]
        public DateTime? LastServiceDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NextServiceDate { get; set; }
    }
}
