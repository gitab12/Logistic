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
using ExponantAARMSMS;
using System.Text.RegularExpressions;
using System.Data.SqlClient;

public partial class UserControl_RoutepriceReport : System.Web.UI.Page
{
    string obj_Authenticated;
    PlaceHolder maPlaceHolder;
    UserControl obj_Tabs;
    UserControl obj_LoginCtrl;
    UserControl obj_WelcomCtrl;
    UserControl obj_Navi;
    UserControl obj_Navihome;
    int obj_res = 0;
    string obj_From, obj_To, obj_username, obj_pwd;
    BizConnectClass obj_class = new BizConnectClass();
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
      if (Session["UserID"] != string.Empty && Convert.ToInt32(Session["UserID"].ToString()) > 0)
        {
        if (!IsPostBack)
        {
            ChkAuthentication();
            gridbind();
            //GetTransporters();
        }
        }
           else
        {
            Response.Redirect("Index.html");
        }
    }

    public void GetTransporters()
    {
        ds = new DataSet();

        ds = obj_class.Get_BizConnect_Transporter();
        GridViewRow header = GridRouteprice.HeaderRow;

        DropDownList ddlTransporter = (DropDownList)header.FindControl("DDLTransporter");
        ddlTransporter.DataTextField = "Tname";
        ddlTransporter.DataValueField = "TID";
        ddlTransporter.DataSource = ds;
        ddlTransporter.DataBind();
        ddlTransporter.Items.Insert(0, "-ALL-");
    }


    public void ChkAuthentication()
    {
        obj_LoginCtrl = null;
        obj_WelcomCtrl = null;

        obj_Navi = null;
        obj_Navihome = null;

        if (Session["Authenticated"] == null)
        {
            Session["Authenticated"] = "0";
        }
        else
        {
            obj_Authenticated = Session["Authenticated"].ToString();
        }


        maPlaceHolder = (PlaceHolder)Master.FindControl("P1");
        if (maPlaceHolder != null)
        {
            obj_Tabs = (UserControl)maPlaceHolder.FindControl("loginheader1");

            if (obj_Tabs != null)
            {
                obj_LoginCtrl = (UserControl)obj_Tabs.FindControl("login1");
                obj_WelcomCtrl = (UserControl)obj_Tabs.FindControl("welcome1");

                // obj_Navi = (UserControl)obj_Tabs.FindControl("Navii");
                //obj_Navihome = (UserControl)obj_Tabs.FindControl("Navihome1");


                if (obj_LoginCtrl != null & obj_WelcomCtrl != null)
                {
                    if (obj_Authenticated == "1")
                    {
                        SetVisualON();


                    }
                    else
                    {
                        SetVisualOFF();

                    }


                }
            }
            else
            {

            }
        }
        else
        {

        }
    }
    public void SetVisualON()
    {
        obj_LoginCtrl.Visible = false;
        obj_WelcomCtrl.Visible = true;
        //obj_Navi.Visible = true;
        //obj_Navihome.Visible = true;

    }
    public void SetVisualOFF()
    {
        obj_LoginCtrl.Visible = true;
        obj_WelcomCtrl.Visible = false;
        // obj_Navi.Visible = true;
        //obj_Navihome.Visible = false;
    }




    public void gridbind()
    {
        string Transporter = "";
        DataTable dt = new DataTable();
        DataRow dr;

        dt.Columns.Add("transporter");
        dt.Columns.Add("From");
        dt.Columns.Add("To");
        dt.Columns.Add("Trucktype");
        dt.Columns.Add("Encltype");
        dt.Columns.Add("Capacity");
        dt.Columns.Add("Oneway");
        dt.Columns.Add("Twoway");
        dt.Columns.Add("Client");
      
        if (RadOptionTransport.Checked)
        {
            ds = obj_class.get_RoutePriceReport();
        }
        else
        {
            ds = obj_class.Get_BizConnect_ClientLogisticsPlan();
        }
        for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
        {

            if (Transporter != ds.Tables[0].Rows[i].ItemArray[0].ToString())
            {
                Transporter = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                dr = dt.NewRow();
                dr[0] = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                dt.Rows.Add(dr);
                //goto x;
            }

            dr = dt.NewRow();

           
            dr[1] = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            dr[2] = ds.Tables[0].Rows[i].ItemArray[2].ToString();
            dr[3] = ds.Tables[0].Rows[i].ItemArray[3].ToString();
            dr[4] = ds.Tables[0].Rows[i].ItemArray[4].ToString();
            dr[5] = ds.Tables[0].Rows[i].ItemArray[5].ToString();
            dr[6] = ds.Tables[0].Rows[i].ItemArray[6].ToString();
            dr[7] = ds.Tables[0].Rows[i].ItemArray[7].ToString();
            dr[8] = ds.Tables[0].Rows[i].ItemArray[0].ToString();
           
            dt.Rows.Add(dr);
        }

        GridRouteprice.DataSource = dt;
        GridRouteprice.Columns[8].Visible = false;
      
        GridRouteprice.DataBind();
         if (RadOptionTransport.Checked)
        {
            GridRouteprice.HeaderRow.Cells[0].Text = "Transporter";
            GridRouteprice.HeaderRow.Cells[1].Text = "FromLocation";
            GridRouteprice.HeaderRow.Cells[2].Text = "ToLocation";
            GridRouteprice.HeaderRow.Cells[3].Text = "TruckType";
            GridRouteprice.HeaderRow.Cells[4].Text = "Encl.Type";
            GridRouteprice.HeaderRow.Cells[5].Text = "Capacity";
            GridRouteprice.HeaderRow.Cells[6].Text = "Quote Price";
        }
        else
        {
            GridRouteprice.HeaderRow.Cells[0].Text = "Client";
            GridRouteprice.HeaderRow.Cells[1].Text = "FromLocation";
            GridRouteprice.HeaderRow.Cells[2].Text = "ToLocation";
            GridRouteprice.HeaderRow.Cells[3].Text = "TruckType";
            GridRouteprice.HeaderRow.Cells[4].Text = "Encl.Type";
            GridRouteprice.HeaderRow.Cells[5].Text = "Capacity";
            GridRouteprice.HeaderRow.Cells[6].Text = "Quote Price";
        }

    }
    protected void GridRouteprice_RowDataBound(Object sender, GridViewRowEventArgs e)
    {



        if (e.Row.RowType == DataControlRowType.DataRow)
        {


            {
                e.Row.Cells[0].ForeColor = System.Drawing.Color.Red;
                e.Row.Cells[0].Font.Bold = true;

            }



        }

    }
    protected void ButExcel_Click(object sender, EventArgs e)
    {
        GridRouteprice.Columns[8].Visible = true ;
       
        ExportGrid(GridRouteprice, "Rpt_route_price.xls");
    }


    public static void ExportGrid(GridView oGrid, string exportFile)
    {
        //Clear the response, and set the content type and mark as attachment
        HttpContext.Current.Response.Clear();
        HttpContext.Current.Response.Buffer = true;
        HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";
        HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=\"" + exportFile + "\"");

        //Clear the character set
        HttpContext.Current.Response.Charset = "";

        //Create a string and Html writer needed for output
        System.IO.StringWriter oStringWriter = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter oHtmlTextWriter = new System.Web.UI.HtmlTextWriter(oStringWriter);

        //Clear the controls from the pased grid


        //Show grid lines
        oGrid.GridLines = GridLines.Both;

        //Color header
        oGrid.HeaderStyle.BackColor = System.Drawing.Color.LightGray;

        //Render the grid to the writer
        oGrid.RenderControl(oHtmlTextWriter);

        //Write out the response (file), then end the response
        HttpContext.Current.Response.Write(oStringWriter.ToString());
        HttpContext.Current.Response.End();
    }
    public override void VerifyRenderingInServerForm(Control control)
    {



    }
    protected void ButShow_Click(object sender, EventArgs e)
    {

        gridbind();

    }
    protected void DDLTransporter_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow header = GridRouteprice.HeaderRow;

        DropDownList ddlTransporter = (DropDownList)header.FindControl("DDLTransporter");

        gridbind2(Convert.ToInt32(ddlTransporter.SelectedValue));



    }



    public void gridbind2(int tid)
    {
        string Transporter = "";
        DataTable dt = new DataTable();
        DataRow dr;

        dt.Columns.Add("transporter");
        dt.Columns.Add("From");
        dt.Columns.Add("To");
        dt.Columns.Add("Trucktype");
        dt.Columns.Add("Encltype");
        dt.Columns.Add("Capacity");
        dt.Columns.Add("Oneway");
        dt.Columns.Add("Twoway");
        if (RadOptionTransport.Checked)
        {
            ds = obj_class.Get_BizConnect_RoutePriceReportByTransporter(tid);
        }
        else
        {
            ds = obj_class.Get_BizConnect_ClientLogisticsPlan();
        }
        for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
        {

            if (Transporter != ds.Tables[0].Rows[i].ItemArray[0].ToString())
            {
                Transporter = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                dr = dt.NewRow();
                dr[0] = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                dt.Rows.Add(dr);
                //goto x;
            }

            dr = dt.NewRow();


            dr[1] = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            dr[2] = ds.Tables[0].Rows[i].ItemArray[2].ToString();
            dr[3] = ds.Tables[0].Rows[i].ItemArray[3].ToString();
            dr[4] = ds.Tables[0].Rows[i].ItemArray[4].ToString();
            dr[5] = ds.Tables[0].Rows[i].ItemArray[5].ToString();
            dr[6] = ds.Tables[0].Rows[i].ItemArray[6].ToString();
            dr[7] = ds.Tables[0].Rows[i].ItemArray[7].ToString();

            dt.Rows.Add(dr);
        }

        GridRouteprice.DataSource = dt;
        GridRouteprice.DataBind();
    }
}