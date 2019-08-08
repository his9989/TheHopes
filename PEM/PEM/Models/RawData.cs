using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PEMServer.Models
{
    public class RawData
    {
        public DateTime Time { get; set; }
        public string ObjName  { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        //public double Altitude { get; set; }
        public double Ele { get; set; }
        public RawData(DateTime Time, string ObjName, double Latitude, double Longitude, double Ele)
        {
            this.Time = Time;
            this.ObjName = ObjName;
            this.Latitude = Latitude;
            this.Longitude = Longitude;
            this.Ele = Ele;
        }
        /*public RawData(DateTime Time, int ObjName, double Latitude, double Longitude, double Altitude, double Ele)
        {
            this.Time = Time;
            this.ObjName = ObjName;
            this.Latitude = Latitude;
            this.Longitude = Longitude;
            this.Altitude = Altitude;
            this.Ele = Ele;
        }*/
    }
}
