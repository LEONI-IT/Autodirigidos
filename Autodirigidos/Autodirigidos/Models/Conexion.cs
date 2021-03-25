using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Autodirigidos.Models
{
    public class Conexion
    {
        //string dirbd = "Server=SVMX1APPS01\\SQL2008R2;User id=sa;Password=123;Database=Sistema_Bono_Test; Integrated Security=false;";
        //string dirbd = "Server=SVMX1APPS01\\SQL2008R2;User id=sa;Password=Canelo2013;Database=Sistema_Bono_Test; Integrated Security=false;";
        string dirbd = "Server=localhost;User id=sa;Password=2012;Database=LEONI; Integrated Security=false;";
        // string dirbd = "Server=localhost;User id=sa;Password=123;Database=LEONI; Integrated Security=false;";


        public DataSet Select(string sql)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = dirbd;
            connection.Open();
            SqlCommand comnd = new SqlCommand(sql, connection);
            SqlDataAdapter da;
            da = new SqlDataAdapter(comnd);
            DataSet ds;
            ds = new DataSet();
            da.Fill(ds);
            connection.Close();

            return ds;
        }

        public Boolean Existe(string sql)
        {
            if (Select(sql).Tables[0].Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        //    conect()
        //    rs.Open(sql, con)
        //    Execute()
        //    Dim data As New DataSet, ban As Boolean = False
        //    da.Fill(data, rs, 0)
        //    For Each row In data.Tables(0).Rows
        //        If Not IsDBNull(row(0)) Then ban = True
        //    Next
        //    Return ban
        //End Function

    }
}