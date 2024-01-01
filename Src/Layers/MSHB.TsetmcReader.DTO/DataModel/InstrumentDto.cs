using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSHB.TsetmcReader.DTO.DataModel
{
    public class InstrumentDto
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal? InsCode { get; set; }
        public string Title { get; set; }
        public string GroupName { get; set; }
        public string eps { get; set; }
    }
}
