using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class LogoutAdmin : System.Web.UI.Page
{
    BizCon_DB_ConnectionString con = new BizCon_DB_ConnectionString();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {

            string user = Session["user_name"].ToString();
            string[] arg = { "@username" };
            string[] argval = { user };
            DataSet ds = new DataSet();
            ds = con.Sql_GetData("SP_Login", arg, argval);
            if (ds.Tables[0].Rows.Count > 0)
            {
                //string logout_time = DateTime.Now.ToString();
                //string sid = Session["userunique_id"].ToString();
                //string[] _arg = { "@logout_time", "@sid" };
                //string[] _argval = { logout_time, sid };
                //int log_details = con.Sql_ExecuteNonQuery("SP_Logout", _arg, _argval);
                Session.RemoveAll();
                Session.Clear();
                Response.Redirect("LoginAdmin.aspx?logout=1");


            }


        }//end of try
        catch (Exception ex)
        {
            Response.Redirect("LoginAdmin.aspx?logout=1");
        }
    }
}