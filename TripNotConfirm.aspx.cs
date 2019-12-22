using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TripNotConfirm : System.Web.UI.Page
{

    BizCon_DB_ConnectionString con = new BizCon_DB_ConnectionString();

    protected void Page_Load(object sender, EventArgs e)
    {
        TripNot_Confirm();
    }

    private void TripNot_Confirm()
    {
        try
        {
            string userid = Session["UserID"].ToString();
            string[] args = { "@userid" };
            string[] argsval = { userid };
            DataSet ds_tripnotconfirm = new DataSet();
            ds_tripnotconfirm = con.Sql_GetData("Bizconnect_Get_DetailsOfTripNotConfirm", args, argsval);
            if (ds_tripnotconfirm.Tables[0].Rows.Count > 0)
            {
                GridView_TripNotConfirm.DataSource = ds_tripnotconfirm;
                GridView_TripNotConfirm.DataBind();
             
            }
        }
        catch (Exception ex)
        {
            Response.Redirect("Index.html");
        }
    }
}