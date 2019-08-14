using System;
using MySql.Data.MySqlClient;
using readdb.Models;



namespace readdb.Class
{
    public class Upload
    {
        
        private readonly string masterTable = "objMaster";
        private readonly string success = "Success";
        private readonly string fail = "Fail";
        private readonly string strConn = "Server=223.194.70.34; Port=3307; Database=mysql; Uid=officium; Pwd=library@1989; CharSet=utf8";
        private MySqlConnection conn;
        private string sql = "";
        public MySqlCommand cmd;



        public Upload()
        {
            conn = new MySqlConnection(strConn);
            cmd = new MySqlCommand(sql, conn);
            conn.Open();
        }

        ~Upload()
        {
            conn.Close();
            GC.Collect();
        }

        public string CreateTable(string objName)
        {
            try
            {
                cmd.CommandText = @"CREATE TABLE `" + objName +
                                    "`( `Time` DATETIME NOT NULL ," +
                                    "`Latitude` DOUBLE NOT NULL ," +
                                    " `Longitude` DOUBLE NOT NULL ," +
                                    " `Altitude` DOUBLE NULL DEFAULT NULL," +
                                    " `Ele` DOUBLE NOT NULL ," +
                                    " PRIMARY KEY(`Time`)) ENGINE = InnoDB";
                
                _ = cmd.ExecuteNonQuery();
                return success;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return fail;
            }
        }




        public void InsertData(string objName, MobilityData mobilityData)
        {
            try
            {
                cmd.CommandText = @"INSERT INTO " +
                                    objName + " " +
                                    "VALUES(@Time, @Latitude, @Longitude, NULL, @Ele)";
                cmd.Parameters.AddWithValue("@Time", mobilityData.Time);
                cmd.Parameters.AddWithValue("@Latitude", mobilityData.Latitude);
                cmd.Parameters.AddWithValue("@Longitude", mobilityData.Longitude);
                cmd.Parameters.AddWithValue("@Ele", mobilityData.Ele);
                _ = cmd.ExecuteNonQuery();
                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return;
            }

        }


        public bool Exists(string objName)
        {

            try
            {
                cmd.CommandText = @"SELECT COUNT(*) FROM " + masterTable + " WHERE objName = '" + objName + "'";
                MySqlDataReader reader = cmd.ExecuteReader();
                _ = reader.Read();
                if (reader[0].ToString().Equals("1"))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        public void InsertObjName(string objName, string objKorName)
        {
            if(Exists(objName))
            {
                return;
            }
            else
            {
                try
                {
                   
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return;
                }

        }





        
    }

}
