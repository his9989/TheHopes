using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PEMServer.Models
{
    public class ClusteredData
    {
        public int ObjName { get; set; }
        public string CluType { get; set; }
        public int CluIndex { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public ClusteredData(int ObjName, string CluType, int CluIndex, double Latitude, double Longitude)
        {
            this.ObjName = ObjName;
            this.CluType = CluType;
            this.CluIndex = CluIndex;
            this.Latitude = Latitude;
            this.Longitude = Longitude;
        }
    }
}
