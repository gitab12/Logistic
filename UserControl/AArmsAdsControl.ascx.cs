using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Text.RegularExpressions;

using ExponantAARMSMS;

public partial class UserControl_AArmsAdsControl : System.Web.UI.UserControl
{
    BizConnectClass obj_Class= new BizConnectClass();
  

    protected void Page_Load(object sender, EventArgs e)
    {
        //bind();
        gridbind();
    }
    public void bind()
    {

        DataTable dt = new DataTable("Personal Database");
       
        dt.Columns.Add("TravelDate", typeof(string));

        dt.Rows.Add("30-Dec-2010");
        dt.Rows.Add("24-Jan-2011");
        dt.Rows.Add("12-Feb-2011");
       // rptItems.DataSource = dt;
        //rptItems.DataBind();
    }

    public void gridbind()
    {
        Session["UserId"] = 2;

        DataSet ds=new DataSet();

        DataTable dt = new DataTable("Personal Database");
        DataRow dr;
        dt.Columns.Add("Adid");
        dt.Columns.Add("FromLocation");
        dt.Columns.Add("ToLocation");
        dt.Columns.Add("Capacity");
        dt.Columns.Add("TravelType");
        dt.Columns.Add("TruckCount");

        ds = obj_Class.GetMyAds(Session["UserId"].ToString());
        for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
        {
            dr = dt.NewRow();
            dr[0] = ds.Tables[0].Rows[i].ItemArray[6].ToString();
            dt.Rows.Add(dr);
            dr = dt.NewRow();

            dr[0] = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            dr[1] = ds.Tables[0].Rows[i].ItemArray[11].ToString();
            dr[2] = ds.Tables[0].Rows[i].ItemArray[12].ToString();
            dr[3] = ds.Tables[0].Rows[i].ItemArray[2].ToString() + "/" + ds.Tables[0].Rows[i].ItemArray[9].ToString(); ;
            dr[4] = ds.Tables[0].Rows[i].ItemArray[20].ToString();
            dr[5] = ds.Tables[0].Rows[i].ItemArray[7].ToString();

            dt.Rows.Add(dr);
        }
     

        Gridclientplan.DataSource = dt;
        Gridclientplan.DataBind();

    }





    protected void Gridclientplan_RowDataBound(Object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label LblAdid = (Label)e.Row.FindControl("lblAdID");

            bool validDate = false;
            DateTime result;
            validDate = DateTime.TryParse(LblAdid.Text, out result);


            if (validDate == true)
            {
                e.Row.Cells[0].ForeColor = System.Drawing.Color.Red;
            }

        }
    }


   
}
