using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class NotLoadedDetails : System.Web.UI.Page
{
    BizCon_DB_ConnectionString con = new BizCon_DB_ConnectionString();
    protected void Page_Load(object sender, EventArgs e)
    {
        Notloaded_details();
    }

    private void Notloaded_details()
    {
        try
        {
            string cid = Session["ClientID"].ToString();
            string[] args = { "@clientid" };
            string[] argsval = { cid };
            DataSet ds_notloaded = new DataSet();
            ds_notloaded = con.Sql_GetData("Bizconnect_GetDetailsOfNotLoaded", args, argsval);
            if (ds_notloaded.Tables[0].Rows.Count > 0)
            {
                GridView_NotLoaded.DataSource = ds_notloaded;
                GridView_NotLoaded.DataBind();
            }
        }
        catch (Exception ex)
        {
            Response.Redirect("Index.html");
        }
    }
}