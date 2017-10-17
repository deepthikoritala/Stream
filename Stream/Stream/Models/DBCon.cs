using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace Stream.Models
{
    public class DBCon
    {
        public static string UNCFilePath = @"C:\dev\Stream\LocalDB\Stream.mdf";

        public static string SQLConnectionStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename="+UNCFilePath+";Integrated Security=True;Connect Timeout=30";

      

        public DBCon()
        {

        }
     

        public static bool UpdateTbl(string CmdTxt)
        {

            SqlConnection DC = new SqlConnection();
            SqlCommand SelCmd = new SqlCommand();
            bool MyDef = false;
            try
            {
                DC.ConnectionString = SQLConnectionStr;
                SelCmd.CommandText = CmdTxt;
                SelCmd.Connection = DC;
                DC.Open();

                int Result = SelCmd.ExecuteNonQuery();

                MyDef = (Result > 0) ? true : false;
            }
            catch (Exception ex)
            {


            }
            finally
            {
                DC.Close();
            }

            return MyDef;

        }

      

        public static DataTable GetTbl(string CmdTxt)
        {

            SqlConnection DC = new SqlConnection();

            SqlCommand SelCmd = new SqlCommand();
            SqlDataAdapter MyCEDB = new SqlDataAdapter();
            DataTable MyDef = new DataTable();
            DC.ConnectionString = SQLConnectionStr;
            SelCmd.CommandText = CmdTxt;

            SelCmd.Connection = DC;
            MyCEDB.SelectCommand = SelCmd;

            try
            {
                MyCEDB.Fill(MyDef);
            }
            catch (Exception e)
            {


            }

            return MyDef;

        }
    }
}