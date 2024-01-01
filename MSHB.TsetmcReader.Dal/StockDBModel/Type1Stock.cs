namespace MSHB.TsetmcReader.Dal
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Type1Stock
    {
        [Key]
        [Column(Order = 0)]
        public long ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string Symbol { get; set; }

        public long? InsCode { get; set; }

        public decimal? LastPrice { get; set; }

        public decimal? SupportPrice { get; set; }

        public decimal? TargetPrice1 { get; set; }

        public decimal? TargetPrice2 { get; set; }

        public decimal? TargetPrice3 { get; set; }

        [Key]
        [Column(Order = 2)]
        public DateTime tmst { get; set; }
    }
}
