using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSHB.TsetmcReader.DTO.DataModel
{
    public class Type1StockDto
    {
        public long ID { get; set; }
        public string Symbol { get; set; }
        public long? InsCode { get; set; }

        public decimal? LastPrice { get; set; }

        public decimal? SupportPrice { get; set; }

        public decimal? TargetPrice1 { get; set; }

        public decimal? TargetPrice2 { get; set; }

        public decimal? TargetPrice3 { get; set; }
        public DateTime tmst { get; set; }
    }
}
