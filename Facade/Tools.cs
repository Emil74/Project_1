using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Reflection;
namespace Facade
{
    public class Tools
    {
        private static SqlConnection baglanti;

        public static SqlConnection Baglanti
        {
            get { return baglanti = new SqlConnection(ConfigurationManager.ConnectionStrings["Baglanti"].ConnectionString); }

        }

        public static bool ExecuteNonQuery(SqlCommand cmd)
        {
            try
            {
                if (cmd.Connection.State != ConnectionState.Open)
                    cmd.Connection.Open();

                int etk = cmd.ExecuteNonQuery();
                
                return etk > 0 ? true : false;
            }
            
            catch (Exception)
            {

                return false;
            }

            finally
            {
                if (cmd.Connection.State == ConnectionState.Open)
                    cmd.Connection.Close();
            }


        }

        public static bool InsertUpdate<T>(string prcTyp,T entity)
        {
            Type t = typeof(T);
            PropertyInfo[] info;
            info = t.GetProperties();
            SqlCommand cmd = new SqlCommand(string.Format("prc_{0}_{1}", t.Name,prcTyp), Tools.Baglanti);
            cmd.CommandType = CommandType.StoredProcedure;
            foreach (PropertyInfo pi in info)
            {
                string ad = "@" + pi.Name;
                object obj = pi.GetValue(entity);
                cmd.Parameters.AddWithValue(ad, obj);
            }


            return Tools.ExecuteNonQuery(cmd);

        }


    }
}
