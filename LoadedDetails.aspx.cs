using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class LoadedDetails : System.Web.UI.Page
{
    BizCon_DB_ConnectionString con = new BizCon_DB_ConnectionString();
    protected void Page_Load(object sender, EventArgs e)
    {
        Loaded_details();
    }

    private void Loaded_details()
    {
        try
        {
            string cid = Session["ClientID"].ToString();
            string[] args = { "@clientid" };
            string[] argsval = { cid };
            DataSet ds_loaded = new DataSet();
            ds_loaded = con.Sql_GetData("Bizconnect_GetDetailsOfLoaded", args, argsval);
            if (ds_loaded.Tables[0].Rows.Count > 0)
            {
                GridView_Loaded.DataSource = ds_loaded;
                GridView_Loaded.DataBind();
            }
        }
        catch (Exception ex)
        {
            Response.Redirect("Index.html");
        }
    }
}