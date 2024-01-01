using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSHB.TsetmcReader.DTO.DataModel
{
    public class Instrument10DaysHistoryDto
    {

        public string Symbol { get; set; }

        public long? InsCode { get; set; }

        public List<Tuple<decimal?, DateTime>> PriceDate { get; set; }
    }
}
