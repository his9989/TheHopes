using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using PEMServer.IRepository;
using PEMServer.Models;

namespace PEMServer.Repository
{
    public class UserRepositorycs : IUserRepository
    {
        private IConfiguration _config;
        private SqlConnection db;
        private readonly string tableName = "objMaster";
        private readonly string success = "Success";
        private readonly string fail = "Fail";
        static public string strconn = "Server = 223.194.70.34; Port=3307; Database = mysql; Uid = officium; Pwd = library@1989; CharSet=utf8";
        private readonly MySqlConnection conn = new MySqlConnection(strconn);

        public List<User> GetUsers()                    //모든 유저 반환
        {
            List<User> result = new List<User>();
            string strconn = "Server = 223.194.70.34; Port=3307; Database = mysql; Uid = officium; Pwd = library@1989; CharSet=utf8";
            MySqlConnection conn = new MySqlConnection(strconn);

            try
            {
                conn.Open();
                string sql = "SELECT * FROM objMaster";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    string ObjName = Convert.ToString(rdr[0]);
                    string ObjEnName = Convert.ToString(rdr[1]);
                    int Edit = Convert.ToInt32(rdr[2]);
                    int ClusNo = Convert.ToInt32(rdr[3]);
                    result.Add(new User(ObjName, ObjEnName, Edit, ClusNo));
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
        
        public User GetUsers(string objName)           //이니셜로 유저 찾기
        {
            try
            {
                conn.Open();
                string sql = "SELECT * FROM " + tableName + " WHERE objName = '" + objName + "'";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    string ObjName = Convert.ToString(rdr[0]);
                    string ObjKorName = Convert.ToString(rdr[1]);
                    int Edit = Convert.ToInt32(rdr[2]);
                    int ClusNo = Convert.ToInt32(rdr[3]);
                    User result = new User(ObjName, ObjKorName, Edit, ClusNo);
                    return result;
                }
                conn.Close();
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
        public string UpdateEdit(string ObjName, int Edit)     //이니셜로 유저 edit column update
        {
            try
            {
                conn.Open();
                string sql = "UPDATE " + tableName + " SET Edit = " + Edit + " WHERE ObjName = '" + ObjName + "'";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                _ = cmd.ExecuteReader();
                conn.Close();
                return success;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return fail;
            }
        }
    }
}
