using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TotalLoadedDetails : System.Web.UI.Page
{
    BizCon_DB_ConnectionString con = new BizCon_DB_ConnectionString();
    protected void Page_Load(object sender, EventArgs e)
    {
        Total_LoadedDetails();
    }

    private void Total_LoadedDetails()
    {
        try
        {
        string cid = Session["ClientID"].ToString();
        string[] args = { "@clientid" };
            string[] argsval = { cid };
            DataSet ds_triploaded = new DataSet();
            ds_triploaded = con.Sql_GetData("Bizconnect_GetDetailsOfTotalLoaded", args, argsval);
            if (ds_triploaded.Tables[0].Rows.Count > 0)
            {
                GridView_TripLoaded.DataSource = ds_triploaded;
                GridView_TripLoaded.DataBind();
            }
        }
        catch(Exception ex)
        {
            Response.Redirect("Index.html");
        }
    }
}