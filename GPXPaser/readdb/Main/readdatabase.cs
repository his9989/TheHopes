using System;
using System.IO;
using System.Collections.Generic;
using System.Data.SQLite;
using readdb.Class;
using readdb.Models;

namespace readdb
{
    public class readdatabase
    {
        static DirectoryInfo relativePath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent;
        static string path = relativePath + "/MobilityData";

        static PathList pathList = new PathList(path);
        static Parser parser = new Parser();
        static Upload upload = new Upload();

        static List<DirectoryInfo> folders = new List<DirectoryInfo>();
        static List<FileInfo> files = new List<FileInfo>();

        static List<MobilityData> mobilityDatas = new List<MobilityData>();


        public static void Main(string []args)
        {
            Console.WriteLine("---------start---------");
            folders = pathList.GetFolders();
            foreach(var folder in folders)
            {
                //if 문으로 마스터테이블에 있는지 확인
                //없으면 추가
                //있으며 무시

                Console.WriteLine("creating table is " + upload.CreateTable(folder.Name));

                files = pathList.GetFiles(folder.FullName);

                foreach(var file in files)
                {
                    Console.WriteLine(file.FullName + " is starting");
                    mobilityDatas = parser.ReadXml(file.FullName);
                    foreach (var mobilitydata in mobilityDatas)
                    {
                        upload.InsertData(folder.Name, mobilitydata);
                        
                    }
                    Console.WriteLine(file.FullName + " is done!!");
                }
            }
            Console.WriteLine("\n---------everything is done!!---------");





            

        }
    }
}
