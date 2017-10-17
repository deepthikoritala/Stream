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
    public class Languages
    {
        public static string LanguagesTblName = "Languages";

        public bool addLanguage(LanguageViewModel language)
        {
            bool res = false;
            string cmd = "Insert into " + LanguagesTblName + "(Language,WelcomeMessage) values('" +
                                                                                      language.Language + "','" +
                                                                                      language.WelcomeMessage + "','" +
                                                                                        "')";
            res = DBCon.UpdateTbl(cmd);
            return res;
        }

        public bool deleteLanguage(LanguageViewModel language)
        {
            bool result = false;
            string cmd = "delete from " + LanguagesTblName + " where";
            cmd += getLangupdatecond(language);
            result = DBCon.UpdateTbl(cmd);
            return result;
        }

        public bool updateLanguage(LanguageViewModel language, LanguageViewModel olddetails)
        {
            bool result = false;
            string cmd = "update " + LanguagesTblName + " set ";
            if (language.Language != null && language.Language.Trim() != "")
            {
                cmd += "Language='" + language.Language + "', ";
            }
            if (language.WelcomeMessage != null && language.WelcomeMessage.Trim() != "")
            {
                cmd += "WelcomeMessage='" + language.WelcomeMessage + "', ";
            }

            cmd += " updatedOn='" + DateTime.Now + "' where ";
            cmd += getLangupdatecond(olddetails);
            result = DBCon.UpdateTbl(cmd);
            return result;
        }

        public LanguageViewModel initialise(DataRow dr)
        {

            LanguageViewModel language = new LanguageViewModel();


            if (dr["Id"] != null)
            {
                language.Id = Convert.ToInt32(dr["Id"]);
            }
            else
                language.Id = -9999;

            if (dr["Language"] != null)
            {
                language.Language = dr["Language"].ToString().Trim(); ;
            }
            else
                language.Language = "";

            if (dr["WelcomeMessage"] != null)
            {
                language.WelcomeMessage = dr["WelcomeMessage"].ToString().Trim();
            }
            else
                language.WelcomeMessage = "";

            if (dr["Video"] != null)
            {
                language.Video = dr["Video"].ToString().Trim();
            }
            else
                language.Video = "";

            if (dr["Audio"] != null)
            {
                language.Audio = dr["Audio"].ToString().Trim();
            }
            else
                language.Audio = "";

            if (dr["Images"] != null)
            {
                language.Images = dr["Images"].ToString().Trim();
            }
            else
                language.Images = "";



            return language;
        }

        public List<LanguageViewModel> getLanguages()
        {
            List<LanguageViewModel> res = new List<LanguageViewModel>();
            DataTable Langtable = new DataTable();
            string cmd = "select * from " + LanguagesTblName + "";

            Langtable = DBCon.GetTbl(cmd);
            foreach (DataRow dr in Langtable.Rows)
            {
                LanguageViewModel obj = initialise(dr);
                res.Add(obj);
            }

            return res;

        }

        public string getLangupdatecond(LanguageViewModel language)
        {
            string res = "";

            if (language.Id != null && language.Id > 0)
            {
                res += "Id='" + language.Id + "' and ";
            }
            if (language.Language != null && language.Language.Trim() != "")
            {
                res += "Language='" + language.Language + "' and ";
            }
            if (language.WelcomeMessage != null && language.WelcomeMessage.Trim() != "")
            {
                res += "WelcomeMessage='" + language.WelcomeMessage + "' and ";
            }


            int andIndex = res.LastIndexOf("and");
            res = res.Substring(0, andIndex);
            return res;
        }
    }
}