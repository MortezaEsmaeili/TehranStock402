using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITester
{
    public class ClosingPriceInfo
    {
        public InstrumentState instrumentState { get; set; }
        public object instrument { get; set; }
        public int lastHEven { get; set; }
        public int finalLastDate { get; set; }
        public double nvt { get; set; }
        public int mop { get; set; }
        public double pRedTran { get; set; }
        public object thirtyDayClosingHistory { get; set; }
        public double priceChange { get; set; }
        public double priceMin { get; set; }
        public double priceMax { get; set; }
        public double priceYesterday { get; set; }
        public double priceFirst { get; set; }
        public bool last { get; set; }
        public int id { get; set; }
        public string insCode { get; set; }
        public int dEven { get; set; }
        public int hEven { get; set; }
        public double pClosing { get; set; }
        public bool iClose { get; set; }
        public bool yClose { get; set; }
        public double pDrCotVal { get; set; }
        public double zTotTran { get; set; }
        public double qTotTran5J { get; set; }
        public double qTotCap { get; set; }
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
