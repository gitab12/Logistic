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

public partial class LoadingStatus : System.Web.UI.Page
{
ClientsReport obj_Class = new ClientsReport();
    string obj_Authenticated;
    PlaceHolder maPlaceHolder;
    UserControl obj_Tabs;
    UserControl obj_LoginCtrl;
    UserControl obj_WelcomCtrl;
    UserControl obj_Navi;
    UserControl obj_Navihome;
    DataSet ds = new DataSet();
DataTable dt_ProjectNo = new DataTable();
    Report  obj_class = new Report ();


    SqlDataReader dr;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            ChkAuthentication();
            LoadingStatusReport();
              Load_ProjectNo();

        }
    }

public void Load_ProjectNo()
    {
        dt_ProjectNo = obj_Class.BizConnect_Get_ThermaxProjectNO(Convert.ToInt32(Session["ClientID"].ToString()));
        ddl_ProjectNo.DataSource = dt_ProjectNo;
        ddl_ProjectNo.DataTextField = "ProjectNo";
        ddl_ProjectNo.DataValueField = "ProjectID";
        ddl_ProjectNo.DataBind();
        ddl_ProjectNo.Items.Insert(0, "--Select--");
    }


    public void LoadingStatusReport()
    {
        try
        {
            //ds = new DataSet();
            //ds.Clear();
            dr = obj_class.Bizconnect_LoadingStatusReport(Convert.ToInt32(Session["ClientID"].ToString()), Convert.ToInt32(Session["ClientAdrID"].ToString()));
           
            Gridwindow.DataSource = dr;
            Gridwindow.DataBind();
        }
        catch (Exception ex)
        {
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

    //protected void Image1_Click(object sender, ImageClickEventArgs e)
    //{
    //    //Session["ImageID"]
    //    ImageButton b = (ImageButton)sender;
    //    GridViewRow row = (GridViewRow)b.NamingContainer;
    //    if (row != null)
    //    {
    //        Label imgid = (Label)Gridwindow.Rows[row.RowIndex].FindControl("lblplanID");
    //        Session["ImageID"] = imgid.Text;
    //        OpenNewWindow();
    //    }
    //}

    public void OpenNewWindow()
    {


        ClientScript.RegisterStartupScript(this.GetType(), "OpenWin", "<script>window.open('TruckImage.aspx?imgID=" + Session["ImageID"].ToString() + "', 'mynewwin', 'width=900,height=1000,scrollbars=yes,toolbar=1')</script>");
    }
protected void link_preview_Click(object sender, EventArgs e)
    {
        LinkButton b = (LinkButton)sender;
        GridViewRow row = (GridViewRow)b.NamingContainer;
        if (row != null)
        {
            Label imgid = (Label)Gridwindow.Rows[row.RowIndex].FindControl("lblplanID");
            Session["ImageID"] = imgid.Text;
             OpenFourViewWindow();
        }
    }
    public void OpenFourViewWindow()
    {


        ClientScript.RegisterStartupScript(this.GetType(), "OpenWin", "<script>window.open('TruckFourView.aspx?imgID=" + Session["ImageID"].ToString() + "', 'mynewwin', 'width=600,height=500,scrollbars=yes,toolbar=1')</script>");
    }

  
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        try
        {
            ds = new DataSet();
            ds.Clear();
            if (txtToDate.Text == string.Empty && txttravelDate.Text == string.Empty)
            {
                DateTime FromDate = Convert.ToDateTime("5/22/2005 00:00:00 AM");
                DateTime ToDate = Convert.ToDateTime("6/22/2005 00:00:00 AM");
                ds = obj_class.Bizconnect_LoadingStatusReportSearch(Convert.ToInt32(Session["ClientID"].ToString()), Convert.ToInt32(Session["ClientAdrID"].ToString()), Convert.ToDateTime(FromDate), Convert.ToDateTime(ToDate), ddl_ProjectNo.SelectedItem.Text);
            }
              if (txttravelDate.Text != string.Empty && txtToDate.Text != string.Empty && ddl_ProjectNo.SelectedItem.Text != "--Select--")
                {
                    DateTime FromDate = Convert.ToDateTime(txttravelDate.Text);
                    DateTime ToDate = Convert.ToDateTime(txtToDate.Text);
                    ds = obj_class.Bizconnect_LoadingStatusReportSearch(Convert.ToInt32(Session["ClientID"].ToString()), Convert.ToInt32(Session["ClientAdrID"].ToString()), Convert.ToDateTime(FromDate), Convert.ToDateTime(ToDate), ddl_ProjectNo.SelectedItem.Text);
                }
                if (txttravelDate.Text != string.Empty && txtToDate.Text != string.Empty && ddl_ProjectNo.SelectedItem.Text== "--Select--")
              {
                  DateTime FromDate = Convert.ToDateTime(txttravelDate.Text);
                  DateTime ToDate = Convert.ToDateTime(txtToDate.Text);
                  ds = obj_class.Bizconnect_LoadingStatusReportSearch(Convert.ToInt32(Session["ClientID"].ToString()), Convert.ToInt32(Session["ClientAdrID"].ToString()), Convert.ToDateTime(FromDate), Convert.ToDateTime(ToDate), ddl_ProjectNo.SelectedItem.Text);
              }
            Gridwindow.DataSource = ds;
            Gridwindow.DataBind();
        }
        catch (Exception ex)
        {
        }
    }

    protected void Gridwindow_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    e.Row.Cells[0].Width = 30;
        //    e.Row.Cells[1].Width = 50;
        //    e.Row.Cells[2].Width = 50;
        //    e.Row.Cells[3].Width = 25;
        //    e.Row.Cells[4].Width = 120;
        //    e.Row.Cells[5].Width = 30;
        //    e.Row.Cells[6].Width = 30;
        //    e.Row.Cells[7].Width = 50;
        //    e.Row.Cells[8].Width = 110;
        //    e.Row.Cells[9].Width = 50;
        //    e.Row.Cells[10].Width = 50;
        //    e.Row.Cells[11].Width = 50;
        //    e.Row.Cells[12].Width = 50;
        //    e.Row.Cells[13].Width = 40;

        //}
    }

    
}
