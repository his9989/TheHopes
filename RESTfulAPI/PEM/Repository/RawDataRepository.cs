using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using PEMServer.Models;
using Dapper;
using PEMServer.IRepository;
using MySql.Data.Common;
using MySql.Data.MySqlClient;


namespace PEMServer.Repository
{
    public class RawDataRepository : IRawDataRepository
    {

        private IConfiguration _config;
        private SqlConnection db;
        private readonly string success = "Success";
        private readonly string fail = "Fail";
        static private readonly string strconn = "Server = 223.194.70.34; Port=3307; Database = mysql; Uid = officium; Pwd = library@1989; CharSet=utf8";
        private MySqlConnection conn = new MySqlConnection(strconn);
        private string sql = "";
        private MySqlCommand cmd;

        public RawDataRepository(IConfiguration config)                                             // db 설정하는 메소드     
        {
            _config = config;
            cmd = new MySqlCommand(sql, conn);
            // IConfiguration 개체를 통해서 
            // appsettings.json의 데이터베이스 연결 문자열을 읽어온다. 
            /*db = new SqlConnection(
                _config.GetSection("ConnectionStrings").GetSection(
                    "DefaultConnection").Value);
              */
        }

        ~RawDataRepository()
        {
            GC.Collect();
        }

        public List<RawData> GetRawDatas(string ObjName)  //objNo로 검색
        {

            List<RawData> result = new List<RawData>();
            try
            {
                conn.Open();
                cmd.CommandText = "SELECT * FROM " + ObjName;
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    DateTime time = Convert.ToDateTime(rdr[0]);
                    double latitude = Convert.ToDouble(rdr[1]);
                    double longitude = Convert.ToDouble(rdr[2]);
                    double ele = Convert.ToDouble(rdr[4]);
                    result.Add(new RawData(time, latitude, longitude, ele));
                }
                conn.Close();
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return result;
            }

        }


        public List<RawData> GetRawDatas(string ObjName, string Time) //objNO, Time 으로 검색
        {
            List<RawData> result = new List<RawData>();
            try
            {
                conn.Open();
                Time = Time.Replace("%20", " ");
                cmd.CommandText = "SELECT * FROM " + ObjName + " WHERE Time = '" + Time + "'";
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    DateTime time = Convert.ToDateTime(rdr[0]);
                    double latitude = Convert.ToDouble(rdr[1]);
                    double longitude = Convert.ToDouble(rdr[2]);
                    double ele = Convert.ToDouble(rdr[4]);
                    result.Add(new RawData(time, latitude, longitude, ele));
                }
                conn.Close();
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return result;
            }
        }

        public int GetRawDatasCount(string ObjName) //row의 갯수를 볼 때
        {
            int result = -1;
            try
            {
                conn.Open();
                cmd.CommandText = "SELECT COUNT(*) FROM " + ObjName;
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    result = Convert.ToInt32(rdr[0]);
                }
                conn.Close();
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return result;
            }
        }

        public string InsertRawDatas(string ObjName, RawData rawData)       // 경수형의 Insert
            //삽입하는 구문, rawData의 attribute들을 잘 이용해야함
        {
            try
            {
                conn.Open();    //connection 열고
                cmd.CommandText = "INSERT INTO " + ObjName + " VALUES(@Time, @Latitude, @Longitude, NULL, @Ele)"; //<Insert 하는 구문>
                cmd.Parameters.AddWithValue("@Time", rawData.Time);
                cmd.Parameters.AddWithValue("@Latitude", rawData.Latitude);
                cmd.Parameters.AddWithValue("@Longitude", rawData.Longitude);
                cmd.Parameters.AddWithValue("@Ele", rawData.Ele);
                 _ = cmd.ExecuteNonQuery();
                conn.Close();   //connection 닫고
                return success; //성공하면 success return 
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return fail;    //실패시 fail을 return
            }
        }

    }
}
