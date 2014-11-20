using Logger;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogDAL.DAL
{
    public class ControllerDAL
    {
        internal SqlCommand cmd;
        internal SqlConnection con;
        internal SqlDataAdapter da;
        internal DataSet ds;
        internal string strcon = Connector.ConnectionString;
        internal string loggerUrl = "http://loggerasp.azurewebsites.net/";

        public ControllerDAL()
        {
            if(con == null)
                con = new SqlConnection(strcon);

            ds = new DataSet();
            cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
        }

        public void FillData(string psText, ref DataSet ds, Dictionary<string, object> listParameters = null)
        {
            cmd.CommandText = psText;
            if (listParameters != null)
                for (int i = 0; i < listParameters.Count; i++)
                    cmd.Parameters.AddWithValue(listParameters.ElementAt(i).Key, listParameters.ElementAt(i).Value);
            da = new SqlDataAdapter(cmd);
            con.Open();
            da.Fill(ds);
        }

        public void LogException(Exception ex, string path, string message, int priority)
        {
            new LErreur(ex, path, message, priority).Save(loggerUrl);
        }
    }
}
