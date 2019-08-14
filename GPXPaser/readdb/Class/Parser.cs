using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using System.Xml;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using readdb.Models;
using readdb.Class;


namespace readdb
{
    public class Parser
    {
        private readonly string type = "System.Xml.XmlDocument";

        public Parser()
        {
        }

        ~Parser()
        {

        }

        public void Run(string fileName)
        {
            ReadXml(fileName);
        }


        public List<MobilityData> ReadXml(string fileName)
        {
            List<MobilityData> mobilityDatas = new List<MobilityData>();
            XmlDocument xmlDocument = new XmlDocument();

            try
            {
                xmlDocument.Load(fileName);
                if (xmlDocument.GetType().ToString().Equals(type))
                {
                    foreach (XmlNode node in xmlDocument.DocumentElement.ChildNodes)
                    {
                        foreach (XmlNode trk in node)
                        {
                            // thereare a couple child nodes here so only take data from node named loc 
                            if (trk.Name == "trkseg")
                            {
                                foreach (XmlNode trkseg in trk)
                                {
                                    string[] vs = trkseg.OuterXml.Split(Convert.ToChar("\""));
                                    double Latitude = Convert.ToDouble(vs[1]);
                                    double Longitude = Convert.ToDouble(vs[3]);
                                    if (trkseg.Name == "trkpt")
                                    {
                                        XmlNodeList xmlNodeList = trkseg.ChildNodes;
                                        double Ele = Convert.ToDouble(xmlNodeList[0].InnerText);
                                        DateTime Time = Convert.ToDateTime(xmlNodeList[1].InnerText);

                                        /*Console.WriteLine("time = " + Time);
                                        Console.WriteLine("lat = " + Latitude);
                                        Console.WriteLine("lon = " + Longitude);
                                        Console.WriteLine("ele = " + Ele);
                                        Console.WriteLine();*/

                                        mobilityDatas.Add(new MobilityData(Time, Latitude, Longitude, Ele));
                                    }
                                }
                            }
                        }
                    }
                }
                return mobilityDatas;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return mobilityDatas;
            }
        }
    }
}
