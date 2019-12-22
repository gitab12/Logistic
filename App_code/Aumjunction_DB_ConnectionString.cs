using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Aumjunction_DB_ConnectionString
/// </summary>
public class Aumjunction_DB_ConnectionString
{
    SqlConnection mcon;
    SqlCommand mcmd;
    static DataSet mds;
    static SqlDataReader mreader;

    string str = ConfigurationManager.ConnectionStrings["SCMCon"].ConnectionString;

    public bool Sql_OpenCon()
    {
        try
        {
            mcon = new SqlConnection(str);
            mcon.Open();
            return true;
        }
        catch
        {
            return false;
        }

    }
    public bool Sql_CloseCon()
    {

        try
        {
            mcon.Close();
            return true;
        }
        catch
        {
            return false;
        }
    }
    public int Sql_ExecuteNonQuery(string str, string[] Args, string[] ArgVal)
    {
        int res = 0, flag = 0;
        try
        {
            Sql_OpenCon();
            mcmd = mcon.CreateCommand();

            mcmd.CommandText = str;
            mcmd.CommandType = CommandType.StoredProcedure;
            SqlParameter pram = new SqlParameter();
            //mcmd.Parameters.Size = 256;

            for (int i = 0; i < Args.Length; i++)
            {
                if (Args[i] == "@res")
                {

                    pram = new SqlParameter(Args[i], SqlDbType.Int);
                    pram.Direction = ParameterDirection.Output;
                    pram.Value = int.Parse(ArgVal[i]);
                    mcmd.Parameters.Add(pram);
                    flag = 1;
                }
                else
                {

                    pram = new SqlParameter(Args[i], SqlDbType.Text);
                    pram.Direction = ParameterDirection.Input;
                    pram.Value = ArgVal[i];
                    mcmd.Parameters.Add(pram);
                }



            }
            res = Convert.ToInt32(mcmd.ExecuteNonQuery());
            if (flag == 1)
            {
                res = int.Parse(pram.Value.ToString());
            }


        }
        catch (Exception ex)
        {
            //string  ErrMsg = string.Empty;
            //  ErrMsg = ex.Message;
        }
        Sql_CloseCon();
        return res;

    }

    public DataSet Sql_GetData(string str, string[] Args, string[] ArgVal)
    {
        Sql_OpenCon();
        try
        {
            SqlDataAdapter da = new SqlDataAdapter(str, mcon);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            SqlParameter pram = new SqlParameter();
            for (int i = 0; i < Args.Length; i++)
            {
                pram = new SqlParameter(Args[i], SqlDbType.VarChar, 100);
                pram.Value = ArgVal[i];
                da.SelectCommand.Parameters.Add(pram);

            }
            mds = new DataSet();
            da.Fill(mds);

        }
        catch
        {

        }
        Sql_CloseCon();
        return mds;
    }


    public object Sql_ExecuteScalar(string str, string[] Args, string[] ArgVal)
    {
        object res;
        Sql_OpenCon();
        try
        {

            SqlDataAdapter da = new SqlDataAdapter(str, mcon);
            mcmd = mcon.CreateCommand();
            mcmd.CommandText = str;
            mcmd.CommandType = CommandType.StoredProcedure;
            SqlParameter pram = new SqlParameter();
            for (int i = 0; i < Args.Length; i++)
            {
                pram = new SqlParameter(Args[i], SqlDbType.VarChar, 100);
                pram.Value = ArgVal[i];
                mcmd.Parameters.Add(pram);

            }



            res = mcmd.ExecuteScalar();

        }
        catch
        {
            res = 0;
        }
        Sql_CloseCon();
        return res;
    }

    public void Sql_Init_DS()
    {

        mds = new DataSet();
    }

    public DataSet Sql_GetData(string str, string TableName, string[] Args, string[] ArgVal)
    {
        Sql_OpenCon();
        try
        {
            SqlDataAdapter da = new SqlDataAdapter(str, mcon);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            SqlParameter pram = new SqlParameter();
            for (int i = 0; i < Args.Length; i++)
            {
                pram = new SqlParameter(Args[i], SqlDbType.VarChar, 100);
                pram.Value = ArgVal[i];
                da.SelectCommand.Parameters.Add(pram);

            }
            //mds = new DataSet();
            da.Fill(mds, TableName);

        }
        catch
        {

        }
        Sql_CloseCon();
        return mds;
    }
    public DataSet Sql_GetData(string str)
    {
        Sql_OpenCon();
        try
        {
            SqlDataAdapter da = new SqlDataAdapter(str, mcon);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            mds = new DataSet();
            da.Fill(mds);

        }
        catch
        {

        }
        Sql_CloseCon();
        return mds;
    }
}