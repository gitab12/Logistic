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

public partial class DeliveryReport : System.Web.UI.Page
{
    ClientsReport obj_Class = new ClientsReport();
    ProjectBased Obj_Class3 = new ProjectBased();
    DataSet ds;
     DataTable dt_ProjectNo = new DataTable();
    DataSet ds_WBSNo = new DataSet();
    string obj_Authenticated;
    PlaceHolder maPlaceHolder;
    UserControl obj_Tabs;
    UserControl obj_LoginCtrl;
    UserControl obj_WelcomCtrl;
    UserControl obj_Navi;
    UserControl obj_Navihome;
    protected void Page_Load(object sender, EventArgs e)
    {
        //lbl_msg.Visible = false;
      if (Session["UserID"] != string.Empty && Convert.ToInt32(Session["UserID"].ToString()) > 0)
       {
        if (!IsPostBack)
        {
            ChkAuthentication();
            LoadDeliveryDetails();
            Load_ProjectNo();
        }
       }
       
        else
        {
            Response.Redirect("Index.html");
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
    public void LoadDeliveryDetails()
    {
        try
        {

            ds = obj_Class.Bizconnect_DeliveryReport(Convert.ToInt32(Session["ClientID"].ToString()), Convert.ToInt32(Session["ClientAdrID"].ToString()));
            if (ds.Tables[0].Rows.Count > 0)
            {
                Gridwindow.DataSource = ds;
                Gridwindow.DataBind();
            }
            
        }
        catch (Exception ex)
        {
           lbl_msg.Text = "Data Not Avaliable !";
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
    
     protected void ddl_ProjectNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        ds_WBSNo = Obj_Class3.Bizconnect_ThermaxCnote_LoadWBSNoBasedOnProject(ddl_ProjectNo.SelectedItem.Text);
        ddl_Wbsno.Items.Clear();
        ddl_Wbsno.DataSource = ds_WBSNo;
        ddl_Wbsno.DataTextField = "WBSNo";
        ddl_Wbsno.DataValueField = "WBSNo";
        ddl_Wbsno.DataBind();
        ddl_Wbsno.Items.Insert(0, "--Select--");
    }

    protected void btn_Search_Click(object sender, EventArgs e)
    {
        dt_ProjectNo.Clear();
        dt_ProjectNo = obj_Class.Bizconnect_Search_DeliveryReportByProjectNoAndWbSNo(Convert.ToInt32(Session["ClientID"].ToString()), Convert.ToInt32(Session["ClientAdrID"].ToString()),ddl_ProjectNo .SelectedItem .Text ,ddl_Wbsno.SelectedItem .Text);
        Gridwindow.DataSource = dt_ProjectNo;
        Gridwindow.DataBind();
    }

    protected void link_preview1_Click(object sender, EventArgs e)
    {
      
    }

    protected void link_Unloading_Click(object sender, EventArgs e)
    {
        LinkButton b = (LinkButton)sender;
        GridViewRow row = (GridViewRow)b.NamingContainer;
        if (row != null)
        {
            Label imgid = (Label)Gridwindow.Rows[row.RowIndex].FindControl("lbl_UnloadConfirmNo");
            Session["UnImgID"] = imgid.Text;
            OpenUnloadImageWindow();
        }
    }

    public void OpenUnloadImageWindow()
    {
        ClientScript.RegisterStartupScript(this.GetType(), "OpenWin", "<script>window.open('UnloadingTruckFrontImage.aspx?ImgID=" + Session["UnImgID"].ToString() + "', 'mynewwin', 'width=600,height=500,scrollbars=yes,toolbar=1')</script>");
    }


    protected void Gridwindow_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        Gridwindow.PageIndex = e.NewPageIndex;
        LoadDeliveryDetails();
    }

}
