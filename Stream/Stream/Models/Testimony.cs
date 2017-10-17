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
    public class Testimony
    {
        public static string TestimonyTblName = "Testimonies";

        public bool addTestimony(TestimonyViewModel testimony)
        {
            bool res = false;
            string cmd = "Insert into " + TestimonyTblName + "(filePath,Description,Language,Title,FileType) values('" +
                                                                                      testimony.filePath + "','" +
                                                                                      testimony.Description + "','" +
                                                                                       testimony.Language + "','" +
                                                                                       testimony.Title + "','" +
                                                                                       testimony.FileType + "','" +
                                                                                        "')";
            res = DBCon.UpdateTbl(cmd);
            return res;
        }

        public bool deleteTestimony(TestimonyViewModel testimony)
        {
            bool result = false;
            string cmd = "delete from " + TestimonyTblName + " where";
            cmd += getTestimonyupdatecond(testimony);
            result = DBCon.UpdateTbl(cmd);
            return result;
        }

        public bool updateTestimony(TestimonyViewModel testimony, TestimonyViewModel olddetails)
        {
            bool result = false;
            string cmd = "update " + TestimonyTblName + " set ";
            if (testimony.Language != null && testimony.Language.Trim() != "")
            {
                cmd += "Language='" + testimony.Language + "', ";
            }
            if (testimony.filePath != null && testimony.filePath.Trim() != "")
            {
                cmd += "filePath='" + testimony.filePath + "', ";
            }
            if (testimony.Description != null && testimony.Description.Trim() != "")
            {
                cmd += "Description='" + testimony.Description + "', ";
            }
            if (testimony.Title != null && testimony.Title.Trim() != "")
            {
                cmd += "Title='" + testimony.Title + "', ";
            }
            
                cmd += "FileType='" + testimony.FileType + "', ";
            


            cmd += getTestimonyupdatecond(olddetails);
            result = DBCon.UpdateTbl(cmd);
            return result;
        }

        public TestimonyViewModel initialise(DataRow dr)
        {

            TestimonyViewModel testimony = new TestimonyViewModel();


            if (dr["ID"] != null)
            {
                testimony.ID = Convert.ToInt32(dr["ID"]);
            }
            else
                testimony.ID = -9999;

            if (dr["Language"] != null)
            {
                testimony.Language = dr["Language"].ToString().Trim(); ;
            }
            else
                testimony.Language = "";

            if (dr["filePath"] != null)
            {
                testimony.filePath = dr["filePath"].ToString().Trim(); ;
            }
            else
                testimony.filePath = "";

            if (dr["Description"] != null)
            {
                testimony.Description = dr["Description"].ToString().Trim(); ;
            }
            else
                testimony.Description = "";

            if (dr["Title"] != null)
            {
                testimony.Title = dr["Title"].ToString().Trim(); ;
            }
            else
                testimony.Title = "";

            if (dr["FileType"] != null)
            {
                testimony.FileType = (StreamEnums.FileTypes)(dr["FileType"]); ;
            }
            else
                testimony.FileType = StreamEnums.FileTypes.Text;



            return testimony;
        }

        public List<TestimonyViewModel> getTestimonies()
        {
            List<TestimonyViewModel> res = new List<TestimonyViewModel>();
            DataTable Testimonytable = new DataTable();
            string cmd = "select * from " + TestimonyTblName + "";

            Testimonytable = DBCon.GetTbl(cmd);
            foreach (DataRow dr in Testimonytable.Rows)
            {
                TestimonyViewModel obj = initialise(dr);
                res.Add(obj);
            }

            return res;

        }

        public string getTestimonyupdatecond(TestimonyViewModel testimony)
        {
            string res = "";

            if (testimony.ID != null && testimony.ID > 0)
            {
                res += "Id='" + testimony.ID + "' and ";
            }
            if (testimony.Language != null && testimony.Language.Trim() != "")
            {
                res += "Language='" + testimony.Language + "' and ";
            }
            if (testimony.filePath != null && testimony.filePath.Trim() != "")
            {
                res += "filePath='" + testimony.filePath + "', ";
            }
            if (testimony.Description != null && testimony.Description.Trim() != "")
            {
                res += "Description='" + testimony.Description + "', ";
            }
            if (testimony.Title != null && testimony.Title.Trim() != "")
            {
                res += "Title='" + testimony.Title + "', ";
            }

            res += "FileType='" + testimony.FileType + "', ";

            int andIndex = res.LastIndexOf("and");
            res = res.Substring(0, andIndex);
            return res;
        }

    }
}