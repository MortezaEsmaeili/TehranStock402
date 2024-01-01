using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSHB.TsetmcReader.DTO.DataModel
{
    public class InstrumentStockData
    {
        public InstrumentStockData() {
            PricePEList = new List<Price_PE>();
        } 
        public List<Price_PE> PricePEList { get; set; }
        public decimal Support { get; set; }
        public decimal Resistance { get; set; }
    }
}
