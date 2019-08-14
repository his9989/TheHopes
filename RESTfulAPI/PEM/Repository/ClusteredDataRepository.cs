using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PEMServer.Models;
using PEMServer.IRepository;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace PEMServer.Repository
{
    public class ClusteredDataRepository: IClusteredDataRepository
    {
        private IConfiguration _config;
        private SqlConnection db;
        private readonly string TableName = "clusteredData";
        private readonly string success = "Success";
        private readonly string fail = "Fail";
        static private readonly string strconn = "Server = 223.194.70.34; Port=3307; Database = mysql; Uid = officium; Pwd = library@1989; CharSet=utf8";
        private MySqlConnection conn = new MySqlConnection(strconn);
        private string sql = "";
        private MySqlCommand cmd;


        public ClusteredDataRepository(IConfiguration config)                                             // db 설정하는 메소드     
        {
            _config = config;
            cmd = new MySqlCommand(sql, conn);
        }

        public List<ClusteredData> GetClusteredDatas()
        {
            List<ClusteredData> result = new List<ClusteredData>();
            try
            {
                conn.Open();
                cmd.CommandText = "SELECT * FROM " + TableName;
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    int objNo = Convert.ToInt32(rdr[0]);
                    string CluType = Convert.ToString(rdr[1]);
                    int CluIndex = Convert.ToInt32(rdr[2]);
                    double latitude = Convert.ToDouble(rdr[3]);
                    double longitude = Convert.ToDouble(rdr[4]);
                    result.Add(new ClusteredData(objNo, CluType, CluIndex, latitude, longitude));
                }
                conn.Close();
                return result;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return result;
            }
        }
        public string InsertClusteredData(ClusteredData clusteredData)      //성용이의 Insert
        {
            try
            {
                conn.Open();    //열어주기
                cmd.CommandText = "INSERT INTO " + TableName + " VALUES(@ObjName, @CluType, @CluIndex, @Latitude, @Longitude"; //<이걸로 하면 되지 않을까 사실 나도 안 해봄 걍 느낌>
                cmd.Parameters.AddWithValue("@ObjName", clusteredData.ObjName);
                cmd.Parameters.AddWithValue("@CluType", clusteredData.CluType);
                cmd.Parameters.AddWithValue("@CluIndex", clusteredData.CluIndex);
                cmd.Parameters.AddWithValue("@Latitude", clusteredData.Latitude);
                cmd.Parameters.AddWithValue("@Longitude", clusteredData.Longitude);
                _ = cmd.ExecuteNonQuery();
                conn.Close();   //닫아주기
                return success;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return fail;
            }
        }
        public string DeleteClusteredData(ClusteredData clusteredData)      //은석이의 Delete
        {
            try
            {
                conn.Open();
                cmd.CommandText =  "DELETE FROM " + TableName + " WHERE ObjName = '" + clusteredData.ObjName + "' AND CluType = '" + clusteredData.CluType + "'"; // <Delete 하는 sql인데 clusterData의 objName, cluType을 이용해 WHERE = 을 해서 지우는 sql>
                _ = cmd.ExecuteNonQuery();
                conn.Close();
                return success; //성공이라고 리턴
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return fail;    //실패라고 리턴
            }
        }
    }
}
