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

public partial class AllRoutePrices : System.Web.UI.Page
{
    BizConnectClass obj_class = new BizConnectClass();
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
            LoadClient();
            LoadFromLoc();
            LoadTransporter();
           BindData();
        }
        
        }
        
           else
        {
            Response.Redirect("Index.html");
        }

    }

    public void LoadTransporter()
    {
        DDLTransporter.Items.Clear();
        DDLTransporter.DataSource = obj_class.Get_BizConnect_Transporter();
        DDLTransporter.DataTextField = "Tname";
        DDLTransporter.DataValueField = "TID";
        DDLTransporter.DataBind();
        DDLTransporter.Items.Insert(0, new ListItem("--Select Transporter--", "0"));

    }
    public void LoadClient()
    {
        DDLClient.Items.Clear();
        DDLClient.DataSource = obj_class.FillClient();
        DDLClient.DataTextField = "CompanyName";
        DDLClient.DataValueField = "ClientID";
        DDLClient.DataBind();
        DDLClient.Items.Insert(0, new ListItem("--Select Client--", "0"));

    }

    public void LoadFromLoc()
    {
        DDLFromLoc.Items.Clear();

        DDLFromLoc.DataSource  = obj_class.FillFromLocation();
        DDLFromLoc.DataTextField = "From_loc";
       
        DDLFromLoc.DataBind();
        DDLFromLoc.Items.Insert(0, new ListItem("--Select Location--", "0"));

    }

    public void BindData()
    {
        DataSet ds = new DataSet();
       
            ds = obj_class.Get_Bizconnect_AllRoutePrices();
       

        GridRoutePrice.DataSource = ds;
        GridRoutePrice.DataBind();

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
        //   obj_Navihome.Visible = true;

    }
    public void SetVisualOFF()
    {
        obj_LoginCtrl.Visible = true;
        obj_WelcomCtrl.Visible = false;
        //obj_Navi.Visible = true;
        //  obj_Navihome.Visible = false;
    }
    protected void But_Download_Click(object sender, EventArgs e)
    {
        
        ExportGrid(GridRoutePrice , "Routeprices.xls");
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

    protected void QuoteReceived_Click(object sender, EventArgs e)
    {
        Response.Redirect("QuoteReceived.aspx");
    }
    protected void ButSearch_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet ds = new DataSet();
            if ((DDLFromLoc.SelectedIndex == 0) && (DDLClient.SelectedIndex == 0) && (DDLTransporter.SelectedIndex == 0))
            {
                ds = obj_class.Get_Bizconnect_AllRoutePrices();
            }
            else if ((DDLFromLoc.SelectedIndex > 0) && (DDLClient.SelectedIndex == 0) && (DDLTransporter.SelectedIndex == 0))
            {
                ds = obj_class.Get_Bizconnect_AllRoutePricesSearch(DDLFromLoc.SelectedItem.Text, "0",0, 1);
            }
            else if ((DDLFromLoc.SelectedIndex == 0) && (DDLClient.SelectedIndex > 0) && (DDLTransporter.SelectedIndex == 0))
            {
                ds = obj_class.Get_Bizconnect_AllRoutePricesSearch("0", DDLClient.SelectedItem.Text,0, 2);
            }
            else if ((DDLFromLoc.SelectedIndex > 0) && (DDLClient.SelectedIndex > 0) && (DDLTransporter.SelectedIndex == 0))
            {
                ds = obj_class.Get_Bizconnect_AllRoutePricesSearch(DDLFromLoc.SelectedItem.Text, DDLClient.SelectedItem.Text, 0,3);
            }

            else if ((DDLFromLoc.SelectedIndex == 0) && (DDLClient.SelectedIndex == 0) && (DDLTransporter.SelectedIndex > 0))
            {
                ds = obj_class.Get_Bizconnect_AllRoutePricesSearch("0", "0", Convert.ToInt32(DDLTransporter.SelectedValue), 4);
            }

            else if ((DDLFromLoc.SelectedIndex == 0) && (DDLClient.SelectedIndex > 0) && (DDLTransporter.SelectedIndex> 0))
            {
                ds = obj_class.Get_Bizconnect_AllRoutePricesSearch("0", DDLClient.SelectedItem.Text, Convert.ToInt32(DDLTransporter.SelectedValue), 5);
            }

            else if ((DDLFromLoc.SelectedIndex > 0) && (DDLClient.SelectedIndex > 0) && (DDLTransporter.SelectedIndex > 0))
            {
                ds = obj_class.Get_Bizconnect_AllRoutePricesSearch(DDLFromLoc.SelectedItem.Text , DDLClient.SelectedItem.Text, Convert.ToInt32(DDLTransporter.SelectedValue), 6);
            }

            else if ((DDLFromLoc.SelectedIndex > 0) && (DDLClient.SelectedIndex == 0) && (DDLTransporter.SelectedIndex > 0))
            {
                ds = obj_class.Get_Bizconnect_AllRoutePricesSearch(DDLFromLoc.SelectedItem.Text, "0", Convert.ToInt32(DDLTransporter.SelectedValue), 7);
            }
            GridRoutePrice.DataSource = ds;
            GridRoutePrice.DataBind();

        }
        catch (Exception ex)
        {
        }
    }
}
