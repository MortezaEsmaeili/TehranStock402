﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSHB.TsetmcReader.DTO.ViewModels
{
    public class VpeRecordViewModel
    {
        public long InstrumentId { get; set; }
        public DateTime InsertDate { get; set; }                 
        public double Qpcd { get; set; }
    }
}
