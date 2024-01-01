using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSHB.TsetmcReader.DTO.DataModel
{
    public class InstrumentHistoryDto
    {
        public long ID { get; set; }

        public string Symbol { get; set; }

        public long? InsCode { get; set; }

        public decimal? LastPrice { get; set; }

        public DateTime Tmst { get; set; }
    }
}
