using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinDTO
{
    public class ClosingPriceInfo
    {
        public InstrumentState instrumentState { get; set; }
        public object instrument { get; set; }
        public int lastHEven { get; set; }
        public int finalLastDate { get; set; }
        public decimal nvt { get; set; }
        public int mop { get; set; }
        public decimal pRedTran { get; set; }
        public object thirtyDayClosingHistory { get; set; }
        public decimal priceChange { get; set; }
        public decimal priceMin { get; set; }
        public decimal priceMax { get; set; }
        public decimal priceYesterday { get; set; }
        public decimal priceFirst { get; set; }
        public bool last { get; set; }
        public int id { get; set; }
        public string insCode { get; set; }
        public int dEven { get; set; }
        public int hEven { get; set; }
        public decimal pClosing { get; set; }
        public bool iClose { get; set; }
        public bool yClose { get; set; }
        public decimal pDrCotVal { get; set; }
        public decimal zTotTran { get; set; }
        public decimal qTotTran5J { get; set; }
        public decimal qTotCap { get; set; }
    }

    public class InstrumentState
    {
        public int idn { get; set; }
        public int dEven { get; set; }
        public int hEven { get; set; }
        public object insCode { get; set; }
        public object lVal18AFC { get; set; }
        public object lVal30 { get; set; }
        public string cEtaval { get; set; }
        public int realHeven { get; set; }
        public int underSupervision { get; set; }
        public string cEtavalTitle { get; set; }
    }

    public class Root
    {
        public ClosingPriceInfo closingPriceInfo { get; set; }
    }

}
