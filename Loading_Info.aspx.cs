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
using System.IO;

public partial class Loading_Info : System.Web.UI.Page
{
    string obj_Authenticated;
    PlaceHolder maPlaceHolder;
    UserControl obj_Tabs;
    UserControl obj_LoginCtrl;
    UserControl obj_WelcomCtrl;
    UserControl obj_Navi;
    UserControl obj_Navihome;
    DataSet ds = new DataSet();

    TripAcceptance obj_class = new TripAcceptance();
    protected void Page_Load(object sender, EventArgs e)
    {
    
        if (!IsPostBack)
        {
            ChkAuthentication();
            LoadDetails();
            //ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Loading Details Already Entered.');</script>");
            Session["FileCtrl"] = "0";
        }
       
        
    }

    public void LoadDetails()
    {
        ds = new DataSet();
        ds.Clear();
        ds = obj_class.Get_LoadingDetails_Info(Convert.ToInt32(Request.QueryString["CltID"]), Convert.ToInt32(Request.QueryString["CltadrID"]),Convert.ToInt32(Request.QueryString["TransID"].ToString()));
        Gridwindow.DataSource = ds;
        Gridwindow.DataBind();
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
    protected void ButSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            Button b = (Button)sender;
            GridViewRow row = (GridViewRow)b.NamingContainer;
            if (row != null)
            {
                Label Accepid = (Label)Gridwindow.Rows[row.RowIndex].FindControl("lblplanID");
                TextBox LoadingTime = (TextBox)Gridwindow.Rows[row.RowIndex].FindControl("txtReportTime");
                TextBox TripTime = (TextBox)Gridwindow.Rows[row.RowIndex].FindControl("txtTripTime");
                TextBox LRNumber = (TextBox)Gridwindow.Rows[row.RowIndex].FindControl("TxtLRno");
                TextBox lblDeliverydate = (TextBox)Gridwindow.Rows[row.RowIndex].FindControl("lblDeliverydate");
                 TextBox lblLoadingDate = (TextBox)Gridwindow.Rows[row.RowIndex].FindControl("lblLoadingDate");
                  TextBox txtweight = (TextBox)Gridwindow.Rows[row.RowIndex].FindControl("txtweight");
                   TextBox TxtEroadNo = (TextBox)Gridwindow.Rows[row.RowIndex].FindControl("TxtEroadNo");
                  int resp = obj_class.Bizconnect_InsertLoadingDetailswithoutimage (Convert.ToInt32(Accepid.Text), Convert.ToDateTime(LoadingTime.Text), Convert.ToDateTime(TripTime.Text), LRNumber.Text, Convert.ToDateTime(lblDeliverydate.Text), Convert.ToDouble(txtweight.Text), Convert.ToDateTime(lblLoadingDate.Text),TxtEroadNo.Text,0);
                LoadDetails();
               
            }
        }
        catch (Exception ex)
        {
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Button b = (Button)sender;
        GridViewRow row = (GridViewRow)b.NamingContainer;
        if (row != null)
        {
            FileUpload FileCtrl = (FileUpload)Gridwindow.Rows[row.RowIndex].FindControl("FileUpload1");
            Session["FileCtrl"] = FileCtrl;
            Image imagebox = (Image)Gridwindow.Rows[row.RowIndex].FindControl("Image1");
            if (FileCtrl.HasFile)
            {
                string path = Server.MapPath("TempImages");

                FileInfo oFileInfo = new FileInfo(

                      FileCtrl.PostedFile.FileName);
                string fileName = oFileInfo.Name;

                string fullFileName = path + "\\" + fileName;
                string imagePath = "TempImages/" + fileName;

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                FileCtrl.PostedFile.SaveAs(fullFileName);
                imagebox.ImageUrl = imagePath;


            }

        }
    }
    protected void link_preview_Click(object sender, EventArgs e)
    {
        LinkButton b = (LinkButton)sender;
        GridViewRow row = (GridViewRow)b.NamingContainer;
        if (row != null)
        {
            FileUpload FileCtrl = (FileUpload)Gridwindow.Rows[row.RowIndex].FindControl("FileUpload1");
            Image imagebox = (Image)Gridwindow.Rows[row.RowIndex].FindControl("Image1");
            Session["FileCtrl"] = FileCtrl;
            if (FileCtrl.HasFile)
            {
                string path = Server.MapPath("TempImages");

                FileInfo oFileInfo = new FileInfo(

                      FileCtrl.PostedFile.FileName);
                string fileName = oFileInfo.Name;

                string fullFileName = path + "\\" + fileName;
                string imagePath = "TempImages/" + fileName;

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                FileCtrl.PostedFile.SaveAs(fullFileName);
                imagebox.ImageUrl = imagePath;
            }
            OpenNewWindow();
        }
    }
    public void OpenNewWindow()
    {
        ClientScript.RegisterStartupScript(this.GetType(), "OpenWin", "<script>window.open('ImagePreview.aspx', 'mynewwin', 'width=950,height=350,scrollbars=yes,toolbar=1')</script>");
    }

}
