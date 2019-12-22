using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;


public partial class TotalTripAssigned : System.Web.UI.Page
{
    BizCon_DB_ConnectionString con = new BizCon_DB_ConnectionString();
    protected void Page_Load(object sender, EventArgs e)
    {
        Total_TripAssigned();

    }

    private void Total_TripAssigned()
    {
        try
        {
            string userid = Session["UserID"].ToString();
            string[] args = { "@userid" };
            string[] argsval = { userid };
            DataSet ds_totalassigned = new DataSet();
            ds_totalassigned = con.Sql_GetData("Bizconnect_GetDetailsOfTripAssigned", args, argsval);
            if (ds_totalassigned.Tables[0].Rows.Count > 0)
            {
                GridView_TripAssigned.DataSource = ds_totalassigned;
                GridView_TripAssigned.DataBind();
            }
        }
        catch(Exception ex)
        {
            Response.Redirect("Index.html");
        }

    }
}