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
using System.Data.SqlClient;
public partial class TransporterReport : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    BizConnectTransporter obj_class = new BizConnectTransporter();
    string obj_Authenticated;
    PlaceHolder maPlaceHolder;
    UserControl obj_Tabs;
    UserControl obj_LoginCtrl;
    UserControl obj_WelcomCtrl;
    UserControl obj_Navi;
    UserControl obj_Navihome;
    protected void Page_Load(object sender, EventArgs e)
    {
       if (Session["UserID"] != string.Empty && Convert.ToInt32(Session["UserID"].ToString()) > 0)
        {
        if (!IsPostBack)
        {
            ChkAuthentication();
            GetTruckType();
            GetUnits();
            gridbind(0, 0, 0, 0);
        }
        }
        
           else
        {
            Response.Redirect("Index.html");
        }
    }

    public void GetTruckType()
    {
        ds = new DataSet();

        ds = obj_class.Get_TruckType();

        DDLTruckType.DataTextField = "TruckType";
        DDLTruckType.DataValueField = "TruckTypeID";
        DDLTruckType.DataSource = ds;
        DDLTruckType.DataBind();
        DDLTruckType.Items.Insert(0, "-All Trucks-");
    }
    public void GetUnits()
    {
        ds = new DataSet();

        ds = obj_class.Get_Units();

        DDLCapacity.DataTextField = "Capacity";
        DDLCapacity.DataValueField = "TruckCapacity";
        DDLCapacity.DataSource = ds;
        DDLCapacity.DataBind();
        DDLCapacity.Items.Insert(0, "-All Units-");
    }


    public void gridbind(int Type, int EnclType, int TruckType, int Capacity)
    {
        try
        {
            string FromLoc = "";
            string ToLoc = "";
            string Distance = "";
            DataTable dt = new DataTable();
            DataRow dr;

            dt.Columns.Add("transporter");
            dt.Columns.Add("trucktype");
            dt.Columns.Add("encltype");
            dt.Columns.Add("capacity");
            dt.Columns.Add("quotedprice");
            dt.Columns.Add("decideprice");
            dt.Columns.Add("savings");
            dt.Columns.Add("client");
            dt.Columns.Add("Tcode");
            dt.Columns.Add("Fromloc");
            dt.Columns.Add("Toloc");
            dt.Columns.Add("Distance");
            ds = obj_class.get_RoutePriceReport(Type, EnclType, TruckType, Capacity);

            for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {

                if (FromLoc != ds.Tables[0].Rows[i].ItemArray[0].ToString() || ToLoc != ds.Tables[0].Rows[i].ItemArray[1].ToString())
                {
                    FromLoc = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                    ToLoc = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                    Distance = ds.Tables[0].Rows[i].ItemArray[11].ToString();
                    dr = dt.NewRow();
                    dr[0] = ds.Tables[0].Rows[i].ItemArray[0].ToString() + " - " + ds.Tables[0].Rows[i].ItemArray[1].ToString() + "-" + ds.Tables[0].Rows[i].ItemArray[11].ToString() + " Km";
                    dt.Rows.Add(dr);
                    //goto x;
                }

                dr = dt.NewRow();


                dr[0] = ds.Tables[0].Rows[i].ItemArray[2].ToString();
                dr[1] = ds.Tables[0].Rows[i].ItemArray[3].ToString();
                dr[2] = ds.Tables[0].Rows[i].ItemArray[4].ToString();
                dr[3] = ds.Tables[0].Rows[i].ItemArray[5].ToString();
                dr[4] = ds.Tables[0].Rows[i].ItemArray[6].ToString();
                dr[5] = ds.Tables[0].Rows[i].ItemArray[7].ToString();
                dr[6] = ds.Tables[0].Rows[i].ItemArray[8].ToString();
                dr[7] = ds.Tables[0].Rows[i].ItemArray[9].ToString();
                dr[8] = ds.Tables[0].Rows[i].ItemArray[10].ToString();
                dr[9] = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                dr[10] = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                dr[11] = ds.Tables[0].Rows[i].ItemArray[11].ToString();
                dt.Rows.Add(dr);
            }

            GridRouteprice.DataSource = dt;
            GridRouteprice.Columns[9].Visible = false;
            GridRouteprice.Columns[10].Visible = false;
            GridRouteprice.Columns[11].Visible = false;
            GridRouteprice.DataBind();
        }
        catch (Exception ex)
        {
        }
    }

    protected void GridRouteprice_RowDataBound(Object sender, GridViewRowEventArgs e)
    {



        if (e.Row.RowType == DataControlRowType.DataRow)
        {


            {
                if (e.Row.Cells[2].Text == "&nbsp;")
                {
                    e.Row.Cells[1].ForeColor = System.Drawing.Color.Red;
                    e.Row.Cells[1].Font.Bold = true;
                }

            }



        }

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

    protected void ButSearch_Click(object sender, EventArgs e)
    {
        if ((DDLEnclType.SelectedIndex == 0) && (DDLTruckType.SelectedIndex == 0) && (DDLCapacity.SelectedIndex == 0))
        {
            gridbind(0, 0, 0, 0);
        }
        else if ((DDLEnclType.SelectedIndex > 0) && (DDLTruckType.SelectedIndex == 0) && (DDLCapacity.SelectedIndex == 0))
        {
            gridbind(1, Convert.ToInt32(DDLEnclType.SelectedValue), 0, 0);
        }
        else if ((DDLEnclType.SelectedIndex == 0) && (DDLTruckType.SelectedIndex > 0) && (DDLCapacity.SelectedIndex == 0))
        {
            gridbind(2, 0, Convert.ToInt32(DDLTruckType.SelectedValue), 0);
        }
        else if ((DDLEnclType.SelectedIndex == 0) && (DDLTruckType.SelectedIndex == 0) && (DDLCapacity.SelectedIndex > 0))
        {
            gridbind(3, 0, 0, Convert.ToInt32(DDLCapacity.SelectedValue));
        }
        else if ((DDLEnclType.SelectedIndex > 0) && (DDLTruckType.SelectedIndex > 0) && (DDLCapacity.SelectedIndex == 0))
        {
            gridbind(4, Convert.ToInt32(DDLEnclType.SelectedValue), Convert.ToInt32(DDLTruckType.SelectedValue), 0);
        }
        else if ((DDLEnclType.SelectedIndex == 0) && (DDLTruckType.SelectedIndex > 0) && (DDLCapacity.SelectedIndex > 0))
        {
            gridbind(5, 0, Convert.ToInt32(DDLTruckType.SelectedValue), Convert.ToInt32(DDLCapacity.SelectedValue));
        }
        else if ((DDLEnclType.SelectedIndex > 0) && (DDLTruckType.SelectedIndex > 0) && (DDLCapacity.SelectedIndex > 0))
        {
            gridbind(6, Convert.ToInt32(DDLEnclType.SelectedValue), Convert.ToInt32(DDLTruckType.SelectedValue), Convert.ToInt32(DDLCapacity.SelectedValue));
        }
    }
    protected void ButDownload_Click(object sender, EventArgs e)
    {
        GridRouteprice.Columns[9].Visible = true;
        GridRouteprice.Columns[10].Visible = true;
        GridRouteprice.Columns[11].Visible = true;
        ExportGrid(GridRouteprice, "Report.xls");
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
}
