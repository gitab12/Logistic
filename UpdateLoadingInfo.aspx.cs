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
using AjaxControlToolkit;
using System.Threading;
using System.Globalization;

public partial class UploadMultiple_UpdateLoadingInfo : System.Web.UI.Page
{
    string obj_Authenticated;
    PlaceHolder maPlaceHolder;
    UserControl obj_Tabs;
    UserControl obj_LoginCtrl;
    UserControl obj_WelcomCtrl;
    UserControl obj_Navi;
    UserControl obj_Navihome;
    DataSet ds = new DataSet();
    AARMEmail.EmailControl mail = new AARMEmail.EmailControl();
    string Email = "";
    string toemail;
    string Conn = ConfigurationManager.ConnectionStrings["BizCon"].ConnectionString;
    TripAcceptance obj_class = new TripAcceptance();
    ClientsReport obj_Class2 = new ClientsReport();
    byte[] bytes1, bytes2, bytes3, bytes4;
    string ext, filename;
    EncryptAndDecryot obj = new EncryptAndDecryot();
    string imagePath = "";

    DataTable dt_ProjectNo = new DataTable();
    DataTable dt_WBSNo = new DataTable();
    DataTable dt = new DataTable();

    SqlDataReader dr;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            MultipleUploadClass.staticvar = "";
            ChkAuthentication();
            LoadingDetails();
            Load_ProjectNo();

        }
    }

    public void Load_ProjectNo()
    {
        try
        {
            dt_ProjectNo = obj_Class2.BizConnect_LoadPjtNoForUpdateloadinginfo(Convert.ToInt32(Session["ClientID"].ToString()), Convert.ToInt32(Session["ClientAdrID"].ToString()));
            ddl_ProjectNo.DataSource = dt_ProjectNo;
            ddl_ProjectNo.DataTextField = "ProjectNo";
            ddl_ProjectNo.DataValueField = "ProjectNo";
            ddl_ProjectNo.DataBind();
            ddl_ProjectNo.Items.Insert(0, "--Select--");
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
    }

    public void LoadingDetails()
    {
        try
        {
            //ds = new DataSet();
            //ds.Clear();
            //DataTable dt_grid = new DataTable();
            dr = obj_class.Update_PreloadingDetails(Convert.ToInt32(Session["ClientID"].ToString()), Convert.ToInt32(Session["ClientAdrID"].ToString()));
            Gridwindow.DataSource = dr;
            Gridwindow.DataBind();
            Session["FileCtrl"] = "0";
        }
        catch (Exception ex)
        {
        }
    }


    protected void Btnupdate_Click(object sender, EventArgs e)
    {
        try
        {

            Button b = (Button)sender;
            GridViewRow row = (GridViewRow)b.NamingContainer;
            if (row != null)
            {
                Label PLid = (Label)Gridwindow.Rows[row.RowIndex].FindControl("lblPLid");
                Label Accepid = (Label)Gridwindow.Rows[row.RowIndex].FindControl("lblplanID");
                TextBox VehicleNo = (TextBox)Gridwindow.Rows[row.RowIndex].FindControl("lblVehicleno");
                TextBox DriverName = (TextBox)Gridwindow.Rows[row.RowIndex].FindControl("lblDriver");
                TextBox MobileNo = (TextBox)Gridwindow.Rows[row.RowIndex].FindControl("lblMobile");
                TextBox ReportTime = (TextBox)Gridwindow.Rows[row.RowIndex].FindControl("txtReportTime");
                TextBox LoadingDate = (TextBox)Gridwindow.Rows[row.RowIndex].FindControl("lblLoadingDate");
                Session["LoadDate"] = LoadingDate.Text;
                TextBox ReleaseTime = (TextBox)Gridwindow.Rows[row.RowIndex].FindControl("txtTripTime");               
                TextBox Deliverydate = (TextBox)Gridwindow.Rows[row.RowIndex].FindControl("lblDeliverydate");
                Session["Deliverydate"] = Deliverydate.Text;               
                TextBox txtweight = (TextBox)Gridwindow.Rows[row.RowIndex].FindControl("txtweight");
                TextBox TxtEroadNo = (TextBox)Gridwindow.Rows[row.RowIndex].FindControl("TxtEroadNo");
                TextBox txtLRNo = (TextBox)Gridwindow.Rows[row.RowIndex].FindControl("txt_LRNo");               
                if (Session["FileCtrl"] == "0")
                {
                    FileUpload FileCtrl1 = (FileUpload)Gridwindow.Rows[row.RowIndex].FindControl("FileUpload1");
                    Session["FileCtrl"] = (FileUpload)FileCtrl1;

                }


                FileUpload FileCtrl = (FileUpload)Session["FileCtrl"];
                // Read the file and convert it to Byte Array

                string[] arr = new string[5];
                string[] patharray = new string[5];
                patharray = MultipleUploadClass.staticvar.Split('@');
                string[] filenamearray = new string[5];
                if (patharray.Length == 5)
                    {
                        for (int i = 1; i <= 4; i++)
                        {
                            string filePath = patharray[i];
                            filename = Path.GetFileName(filePath);
                            filenamearray[i] = filename;
                            ext = Path.GetExtension(filename);
                            string contenttype = String.Empty;
                            //Set the contenttype based on File Extension

                            switch (ext)
                            {

                                case ".JPG":

                                    contenttype = "image/jpg";

                                    break;
                                case ".jpg":

                                    contenttype = "image/jpg";

                                    break;
                                case ".png":

                                    contenttype = "image/png";

                                    break;

                                case ".gif":

                                    contenttype = "image/gif";

                                    break;
                            }

                            if (contenttype != String.Empty)
                            {
                                arr[i] = "1";
                                if (patharray[1] != null && i == 1)
                                {
                                    FileStream fs1 = new FileStream(patharray[1], FileMode.Open, FileAccess.Read);
                                    BinaryReader br1 = new BinaryReader(fs1);


                                    bytes1 = br1.ReadBytes((Int32)fs1.Length);
                                }
                                else
                                {
                                    //bytes1 = null;
                                }
                                if (patharray[2] != null && i == 2)
                                {
                                    FileStream fs2 = new FileStream(patharray[2], FileMode.Open, FileAccess.Read);
                                    BinaryReader br2 = new BinaryReader(fs2);

                                    bytes2 = br2.ReadBytes((Int32)fs2.Length);
                                }
                                else
                                {
                                    //bytes2 = null;
                                }
                                if (patharray[3] != null && i == 3)
                                {
                                    FileStream fs3 = new FileStream(patharray[3], FileMode.Open, FileAccess.Read);
                                    BinaryReader br3 = new BinaryReader(fs3);

                                    bytes3 = br3.ReadBytes((Int32)fs3.Length);
                                }
                                else
                                {
                                    //bytes3 = null;
                                }
                                if (patharray[4] != null && i == 4)
                                {
                                    FileStream fs4 = new FileStream(patharray[4], FileMode.Open, FileAccess.Read);
                                    BinaryReader br4 = new BinaryReader(fs4);

                                    bytes4 = br4.ReadBytes((Int32)fs4.Length);
                                }
                                else
                                {
                                    //bytes4 = null;
                                }

                            }
                            else
                            {
                                arr[i] = "0";                              

                            }

                        }

                        int resp = obj_class.Bizconnect_Update_Preloaddetails(Convert.ToInt32(PLid.Text), Convert.ToInt32(Accepid.Text), VehicleNo.Text, DriverName.Text, MobileNo.Text, Convert.ToDateTime(ReportTime.Text), Convert.ToDateTime(LoadingDate.Text), Convert.ToDateTime(ReleaseTime.Text), Convert.ToDouble(txtweight.Text), TxtEroadNo.Text,txtLRNo .Text, bytes1, ext, filename, bytes2, bytes3, bytes4, Convert.ToDateTime(Deliverydate.Text));
                    }
                    else
                    {

                        int resp = obj_class.Bizconnect_Update_PreloaddetailsWithoutImages(Convert.ToInt32(PLid.Text), Convert.ToInt32(Accepid.Text), VehicleNo.Text, DriverName.Text, MobileNo.Text, Convert.ToDateTime(ReportTime.Text), Convert.ToDateTime(LoadingDate.Text), Convert.ToDateTime(ReleaseTime.Text), Convert.ToDouble(txtweight.Text), TxtEroadNo.Text,txtLRNo .Text,Convert.ToDateTime(Deliverydate.Text));
                        this.Page.ClientScript.RegisterStartupScript(typeof(Page), "notification", "window.alert('Details Updated Successfully');", true);
                    }
                }
                MultipleUploadClass.staticvar = "";
                this.Page.ClientScript.RegisterStartupScript(typeof(Page), "notification", "window.alert('Details Updated Successfully');", true);
                LoadingDetails();      

            }

       
        catch (Exception ex)
        {
            MultipleUploadClass.staticvar = "";
        }
    }

    protected void ddl_ProjectNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        dt_WBSNo = obj_Class2.BizConnect_LoadWBSNoForUpdateloadinginfo(Convert.ToInt32(Session["ClientID"].ToString()), Convert.ToInt32(Session["ClientAdrID"].ToString()), ddl_ProjectNo.SelectedItem.Text);
        ddl_Wbsno.Items.Clear();
        ddl_Wbsno.DataSource = dt_WBSNo;
        ddl_Wbsno.DataTextField = "WBSNo";
        ddl_Wbsno.DataValueField = "WBSNo";
        ddl_Wbsno.DataBind();
        ddl_Wbsno.Items.Insert(0, "--Select--");
    }

    protected void btn_Search_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddl_ProjectNo.SelectedItem.Text != "--Select--" && ddl_Wbsno.SelectedItem.Text != "--Select--")
            {
                dt = obj_class.Search_UpdateBizconnectPreloadDetailsByprojectAndWbsno(Convert.ToInt32(Session["ClientID"].ToString()), Convert.ToInt32(Session["ClientAdrID"].ToString()), ddl_ProjectNo.SelectedItem.Text, ddl_Wbsno.SelectedItem.Text);
            }
            if (ddl_ProjectNo.SelectedItem.Text != "--Select--" && ddl_Wbsno.SelectedItem.Text == "--Select--")
            {
                dt = obj_class.Search_UpdateBizconnectPreloadDetailsByprojectAndWbsno(Convert.ToInt32(Session["ClientID"].ToString()), Convert.ToInt32(Session["ClientAdrID"].ToString()), ddl_ProjectNo.SelectedItem.Text, string.Empty);
            }
            if (dt.Rows.Count > 0)
            {
                Gridwindow.DataSource = dt;
                Gridwindow.DataBind();
            }
        }
        catch (Exception ex)
        {

        }
    }

    protected void Gridwindow_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (Convert.ToInt32(Session["ClientID"].ToString()) == 1135)
        {
            ((DataControlField)Gridwindow.Columns
                .Cast<DataControlField>()
                .Where(obj => obj.HeaderText == "TotalWt in Tons")
                .SingleOrDefault()).Visible = false;

            ((DataControlField)Gridwindow.Columns
                .Cast<DataControlField>()
                .Where(obj => obj.HeaderText == "ERoad Permit No./Way Bill No")
                .SingleOrDefault()).Visible = false;

            ((DataControlField)Gridwindow.Columns
              .Cast<DataControlField>()
              .Where(obj => obj.HeaderText == "DeliveryDate")
              .SingleOrDefault()).Visible = false;

            ((DataControlField)Gridwindow.Columns
             .Cast<DataControlField>()
             .Where(obj => obj.HeaderText == "CN No")
             .SingleOrDefault()).Visible = true;


            ((DataControlField)Gridwindow.Columns
             .Cast<DataControlField>()
             .Where(obj => obj.HeaderText == "WBSNo")
             .SingleOrDefault()).Visible = true;

            ((DataControlField)Gridwindow.Columns
          .Cast<DataControlField>()
          .Where(obj => obj.HeaderText == "ProjectNo")
          .SingleOrDefault()).Visible = true;
        }
        else
        {
            ((DataControlField)Gridwindow.Columns
             .Cast<DataControlField>()
             .Where(obj => obj.HeaderText == "CN No")
             .SingleOrDefault()).Visible = false;

            ((DataControlField)Gridwindow.Columns
            .Cast<DataControlField>()
            .Where(obj => obj.HeaderText == "WBSNo")
            .SingleOrDefault()).Visible = false;

            ((DataControlField)Gridwindow.Columns
          .Cast<DataControlField>()
          .Where(obj => obj.HeaderText == "ProjectNo")
          .SingleOrDefault()).Visible = false;
        }
    }
   

}