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

        public ControllerDAL()
        {
            if(con == null)
                con = new SqlConnection(strcon);

            ds = new DataSet();
            cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
        }
    }
}
