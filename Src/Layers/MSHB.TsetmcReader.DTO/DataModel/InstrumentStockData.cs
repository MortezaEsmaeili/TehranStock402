﻿using System;
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
        public string insName {  get; set; }

        public decimal PE { get; set; }
        public decimal Price100 { get; set; }
        public decimal Earning100 { get; set; }
        public decimal PE100 { get; set; }
        public decimal Price500 { get; set; }
        public decimal Earning500 { get; set; }
        public decimal PE500 { get; set; }
    }
}
