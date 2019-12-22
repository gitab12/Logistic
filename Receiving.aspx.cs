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

public partial class Receiving : System.Web.UI.Page
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
    TripAcceptance obj_class = new TripAcceptance();
DataTable dt_ProjectNo = new DataTable();
    DataTable dt_WBSNo = new DataTable();
ClientsReport obj_Class2 = new ClientsReport();
int ClientID;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            ChkAuthentication();
            ClientID = Convert.ToInt32(Session["ClientID"]);

            if (ClientID == 1135)
            {
                Response.Redirect("Error.aspx");
            }
            else
            {
                LoadDetails();
                Load_ProjectNo();
            }
        }
    }




    public void LoadDetails()
    {
        try
        {
            ds = new DataSet();
            ds.Clear();
            ds = obj_class.Bizconnect_Received(Convert.ToInt32(Session["ClientID"].ToString()), Convert.ToInt32(Session["ClientAdrID"].ToString()));
            Gridwindow.DataSource = ds;
            Gridwindow.DataBind();
        }
        catch (Exception ex)
        {
        }
    }
    public void Load_ProjectNo()
    {
        dt_ProjectNo = obj_Class2.BizConnect_Get_ThermaxProjectNO(Convert.ToInt32(Session["ClientID"].ToString()));
        ddl_ProjectNo.DataSource = dt_ProjectNo;
        ddl_ProjectNo.DataTextField = "ProjectNo";
        ddl_ProjectNo.DataValueField = "ProjectID";
        ddl_ProjectNo.DataBind();
        ddl_ProjectNo.Items.Insert(0, "--Select--");
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
                Label lblplid = (Label)Gridwindow.Rows[row.RowIndex].FindControl("lblplid");
                Label LRNumber = (Label)Gridwindow.Rows[row.RowIndex].FindControl("lblLRno");
                Session["LRNumber"]=LRNumber.Text;
                TextBox txtReceivedDate = (TextBox)Gridwindow.Rows[row.RowIndex].FindControl("txtReceivedDate");
                 Session["ReceivedDate"]=txtReceivedDate.Text;
                 Label lblFromloc = (Label)Gridwindow.Rows[row.RowIndex].FindControl("lblFromLoc");
                 Session["FromLoc"] = lblFromloc.Text;

                   Label lbltoloc=(Label)Gridwindow.Rows[row.RowIndex].FindControl("lbltoloc");
                Session["lbltoloc"]=lbltoloc.Text;
                Label ReleaseDateTime = (Label)Gridwindow.Rows[row.RowIndex].FindControl("lblReleaseDateTime");
                Session["ReleaseDateTime"] = ReleaseDateTime.Text;

                TextBox Remarks = (TextBox)Gridwindow.Rows[row.RowIndex].FindControl("txtRemarks");
                TextBox speedometer = (TextBox)Gridwindow.Rows[row.RowIndex].FindControl("txt_SpeedoMeter");
                Session["Remarks"]=Remarks.Text;
                 TextBox txtUnloadingDate = (TextBox)Gridwindow.Rows[row.RowIndex].FindControl("dt1");
                  TextBox txtvehicleNo = (TextBox)Gridwindow.Rows[row.RowIndex].FindControl("txtvehicleNo");
                  Session["Vehcleno"] = txtvehicleNo.Text;
                int resp = obj_class.Bizconnect_InsertReceivingDetails(Convert.ToInt32(lblplid.Text), Convert.ToInt32(Accepid.Text), LRNumber.Text, Convert.ToDateTime(txtReceivedDate.Text), Remarks.Text,Convert.ToDateTime(txtUnloadingDate.Text),txtvehicleNo.Text,Convert .ToInt32 (speedometer .Text));
              ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Data Saved Successfully');</script>");
                Sendmail();
                LoadDetails();
                
            }
        }
        catch (Exception ex)
        {
        }
    }

  public void Sendmail()
    {
        DataTable dt = new DataTable();
        dt = obj_class.Bizconnect_GetUniqueClientEmail(Convert.ToInt32(Session["ClientID"].ToString()));
       // string obj_Message = "This is to inform that the vehicle has  reached the destination["+ Session["lbltoloc"].ToString() +" ]on " + Session["ReceivedDate"].ToString() + " <br>\nRemarks:" + Session["Remarks"].ToString() + " ";
        string obj_Message = "Dear Sir/Madam <br/><br/> This is to inform that the vehicle no [" + Session["Vehcleno"].ToString() + "] had left the source [" + Session["FromLoc"].ToString() + "] on ' " + Session["ReleaseDateTime"].ToString() + " ' and reached the destination [" + Session["lbltoloc"].ToString() + " ] on ' " + Session["ReceivedDate"].ToString() + " ' <br/><br/>\nRemarks:" + Session["Remarks"].ToString() + " <br/><br/> Regards <br/>ScmBizconnect Team. ";
         string Conn = ConfigurationManager.ConnectionStrings["BizCon"].ConnectionString;
          SqlConnection conn = new SqlConnection();
        conn.ConnectionString = Conn;
        conn.Open();
       
        SqlCommand cmd = new SqlCommand();
        string qry = "select Emailid,password from Clients_EmailID where clientID='" + Session["ClientID"].ToString() + " ' ";
        cmd = new SqlCommand(qry, conn);
        SqlDataReader mydatareader;
        mydatareader = cmd.ExecuteReader();
        mydatareader.Read();
        
           string toemail = dt.Rows[0].ItemArray[0].ToString() ;
        
        if (mydatareader.HasRows)
        {
            mail.SendEmail(toemail, mydatareader.GetValue(0).ToString(), mydatareader.GetValue(1).ToString(), "", "", "tripschedule@scmbizconnect.com", "bounceback@scmjunction.com", "Receiving Information-LRNumber: " + Session["LRNumber"].ToString() + "", obj_Message.ToString().Trim(), System.Web.Mail.MailFormat.Html, System.Web.Mail.MailPriority.High, "smtp.gmail.com", "465", "2", "1", true, "");
        }

        else
        {
            mail.SendEmail(toemail, "tripschedule@scmbizconnect.com", "tripschedule123", "", "", "tripschedule@scmbizconnect.com", "bounceback@scmjunction.com", "Receiving Info", obj_Message.ToString().Trim(), System.Web.Mail.MailFormat.Html, System.Web.Mail.MailPriority.High, "smtp.gmail.com", "465", "2", "1", true, "");
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
        
               Session["ClientID"] = Request.QueryString["CLID"].ToString();
          Session["ClientAdrID"]= Request.QueryString["CLAID"].ToString();
        
    }
    public void SetOFF()
    {
      try
      {
        
               Session["ClientID"] = Request.QueryString["CLID"].ToString();
          Session["ClientAdrID"]= Request.QueryString["CLAID"].ToString();
          }
         catch (Exception ex)
        {
        }
    }

 protected void Image1_Click(object sender, ImageClickEventArgs e)
    {
        //Session["ImageID"]
        ImageButton b = (ImageButton)sender;
        GridViewRow row = (GridViewRow)b.NamingContainer;
        if (row != null)
        {
            Label imgid = (Label)Gridwindow.Rows[row.RowIndex].FindControl("lblplanID");
            Session["ImageID"] = imgid.Text;
            OpenNewWindow();
        }
    }

    public void OpenNewWindow()
    {


        ClientScript.RegisterStartupScript(this.GetType(), "OpenWin", "<script>window.open('TruckImage.aspx?imgID=" + Session["ImageID"] .ToString()+ "', 'mynewwin', 'width=900,height=1000,scrollbars=yes,toolbar=1')</script>");
    }

protected void ddl_ProjectNo_SelectedIndexChanged(object sender, EventArgs e)
    {

        dt_WBSNo = obj_Class2.Bizconnect_LoadReceivedWbsnoByProjectNo(Convert.ToInt32(Session["ClientID"].ToString()), Convert.ToInt32(Session["ClientAdrID"].ToString()),ddl_ProjectNo.SelectedItem.Text);
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
         if (ddl_ProjectNo.SelectedValue != "--Select--" && ddl_Wbsno.SelectedValue != "--Select--")
            {
                txt_Lrno.Text = "";
            }
            if (txt_Lrno.Text!= "")
            {
                ddl_ProjectNo.SelectedIndex = -1;
                ddl_Wbsno.SelectedIndex = -1;
            }
        dt_ProjectNo.Clear();
        dt_ProjectNo = obj_Class2.Bizconnect_Search_ReceivedDetailsByWbsAndProjectNo(Convert.ToInt32(Session["ClientID"].ToString()), Convert.ToInt32(Session["ClientAdrID"].ToString()), ddl_ProjectNo.SelectedItem.Text, ddl_Wbsno.SelectedItem.Text,txt_Lrno .Text);
        Gridwindow.DataSource = dt_ProjectNo;
        Gridwindow.DataBind();
        }
        catch (Exception ex)
        {
        }
    }

}
