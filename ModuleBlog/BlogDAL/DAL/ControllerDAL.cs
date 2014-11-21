using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace BlogDAL.DAL
{
    /// <summary>
    /// Controller Dal
    /// </summary>
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

        /// <summary>
        /// Remplissage de la dataset à partir de procédure stockée
        /// </summary>
        /// <param name="psText">nom de la procédure stockée</param>
        /// <param name="ds">dataset</param>
        /// <param name="listParameters">liste des paramètres</param>       
        /// <returns></returns>
        public void FillData(string psText, ref DataSet ds, Dictionary<string, object> listParameters = null)
        {
          
            cmd.Parameters.Clear();
            ds.Clear();
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
            //new LErreur(ex, path, message, priority).Save(loggerUrl);
        }
    }
}
