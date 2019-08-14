using System;



namespace readdb.Models
{
    public class MobilityData
    {
        public DateTime Time { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Altitude { get; set; }
        public double Ele { get; set; }

        public MobilityData()
        {
        }

        public MobilityData(DateTime Time, double Latitude, double Longitude, double Ele)
        {
            this.Time = Time;
            this.Latitude = Latitude;
            this.Longitude = Longitude;
            this.Ele = Ele;
        }
        public override string ToString()
        {
            return @"Time is " + this.Time +
                    "\nLatitude is " + this.Latitude +
                    "\nLongitude is " + this.Longitude +
                    "\nEle is " + this.Ele + "\n\n";
        }
    }
}
