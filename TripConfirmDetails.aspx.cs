using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TripConfirmDetails : System.Web.UI.Page
{
    BizCon_DB_ConnectionString con = new BizCon_DB_ConnectionString();
    protected void Page_Load(object sender, EventArgs e)
    {
        TripConfirm_Details();
    }

    private void TripConfirm_Details()
    {
        try
        {
            string userid = Session["UserID"].ToString();
            string[] args = { "@userid" };
            string[] argsval = { userid };
            DataSet ds_tripconfirm = new DataSet();
            ds_tripconfirm = con.Sql_GetData("Bizconnect_GetDetailsOfTripConfirm", args, argsval);
            if (ds_tripconfirm.Tables[0].Rows.Count > 0)
            {
                GridView_TripConfirm.DataSource = ds_tripconfirm;
                GridView_TripConfirm.DataBind();
            }
        }
        catch (Exception ex)
        {
            Response.Redirect("Index.html");
        }


    }
}