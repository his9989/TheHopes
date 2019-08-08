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
        private readonly string TableName = "mobilityData";
        private readonly string success = "Success";
        private readonly string fail = "Fail";
        static private readonly string strconn = "Server = 223.194.70.34; Port=3307; Database = mysql; Uid = officium; Pwd = library@1989; CharSet=utf8";
        MySqlConnection conn = new MySqlConnection(strconn);


        public RawDataRepository(IConfiguration config)                                             // db 설정하는 메소드     
        {
            _config = config;

            // IConfiguration 개체를 통해서 
            // appsettings.json의 데이터베이스 연결 문자열을 읽어온다. 
            /*db = new SqlConnection(
                _config.GetSection("ConnectionStrings").GetSection(
                    "DefaultConnection").Value);
              */ 
        }

        public List<RawData> GetRawDatas()// 모든 raw data 검색
        {
            List<RawData> result = new List<RawData>();
            try
            {
                conn.Open();
                string sql = "SELECT * FROM " + TableName;
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    DateTime time = Convert.ToDateTime(rdr[0]);
                    string objName = Convert.ToString(rdr[1]);
                    double latitude = Convert.ToDouble(rdr[2]);
                    double longitude = Convert.ToDouble(rdr[3]);
                    double ele = Convert.ToDouble(rdr[5]);
                    result.Add(new RawData(time, objName, latitude, longitude, ele));
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
        public List<RawData> GetRawDatas(string ObjName)  //objNo로 검색
        {

            List<RawData> result = new List<RawData>();
            try
            {
                conn.Open();
                string sql = "SELECT * FROM " + TableName  + " WHERE ObjName = '" + ObjName + "'";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    DateTime time = Convert.ToDateTime(rdr[0]);
                    string objName = Convert.ToString(rdr[1]);
                    double latitude = Convert.ToDouble(rdr[2]);
                    double longitude = Convert.ToDouble(rdr[3]);
                    double ele = Convert.ToDouble(rdr[5]);
                    result.Add(new RawData(time, objName, latitude, longitude, ele));
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
                string sql = "SELECT * FROM " + TableName + " WHERE ObjName = '" + ObjName + "' AND Time = '" + Time + "'";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    DateTime time = Convert.ToDateTime(rdr[0]);
                    string objName = Convert.ToString(rdr[1]);
                    double latitude = Convert.ToDouble(rdr[2]);
                    double longitude = Convert.ToDouble(rdr[3]);
                    double ele = Convert.ToDouble(rdr[5]);
                    result.Add(new RawData(time, objName, latitude, longitude, ele));
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

        public int GetRawDatasCount() //row의 갯수를 볼 때
        {
            int result = -1;
            try
            {
                conn.Open();
                string sql = "SELECT COUNT(*) FROM " + TableName;
                MySqlCommand cmd = new MySqlCommand(sql, conn);
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

        public string InsertRawDatas(RawData rawData)       // 경수형의 Insert
            //삽입하는 구문, rawData의 attribute들을 잘 이용해야함
        {
            try
            {
                conn.Open();    //connection 열고
                string sql = ""; //<Insert 하는 구문>
                MySqlCommand cmd = new MySqlCommand(sql, conn); //cmd 생성
                //<실행하는 구문 작성>
                
                


                conn.Close();   //connection 닫고
                return success; //성공하면 success return 
            }
            catch(Exception ex)
            {
                return fail;    //실패시 fail을 return
            }
        }

    }
}
