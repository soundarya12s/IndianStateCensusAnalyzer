using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndianStateCensusAnalyzer
{
    public class StateCensusData
    {
        public string State { get; set; }
        public int Population { get; set; }
        public int AreaInSqKm { get; set; }
        public int DensityPerSqKm { get; set; }
    }
}