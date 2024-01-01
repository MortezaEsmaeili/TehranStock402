namespace MSHB.TsetmcReader.Dal
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("InstrumentHistory")]
    public partial class InstrumentHistory
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

        [Column(Order = 2)]
        public DateTime Tmst { get; set; }
    }
}
