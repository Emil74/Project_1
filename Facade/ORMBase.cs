using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
namespace Facade
{
    public class ORMBase<T> : IORM<T>
    {
        Type t
        {

            get { return typeof(T); }
        }



        public DataTable Select()
        {
            SqlDataAdapter adp = new SqlDataAdapter(string.Format("prc_{0}_Select", t.Name), Tools.Baglanti);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;

        }

        public bool Insert(T entity)
        {
            return Tools.InsertUpdate<T>("Insert", entity);
        }

        public bool Update(T entity)
        {
            return Tools.InsertUpdate<T>("Update", entity);
        }

        public bool Delete(int Id)
        {
            T ent = Activator.CreateInstance<T>();

            SqlCommand cmd = new SqlCommand(string.Format("prc_{0}_Delete", t.Name), Tools.Baglanti);
            cmd.CommandType = CommandType.StoredProcedure;
            PropertyInfo primarycolumn = t.GetProperty("PrimaryColumn");

            string prmAdi = "@" + primarycolumn.GetValue(ent);//primarycolumn.GetValue(ent);
            cmd.Parameters.AddWithValue(prmAdi, Id);
            return Tools.ExecuteNonQuery(cmd);
        }
    }
}
