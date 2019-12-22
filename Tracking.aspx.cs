using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using ExponantAARMSMS;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.IO;
using System.Configuration;
using System.Collections;


public partial class Tracking : System.Web.UI.Page
{


    string obj_Authenticated;
    PlaceHolder maPlaceHolder;
    UserControl obj_Tabs;
    UserControl obj_LoginCtrl;
    UserControl obj_WelcomCtrl;
    UserControl obj_Navi;
    UserControl obj_Navihome;


    AarmsUser obj_class = new AarmsUser();
    DataTable dt = new DataTable();
    DataSet ds = new DataSet();
    TripAcceptance obj_class1 = new TripAcceptance();
    string constr = ConfigurationManager.ConnectionStrings["BizCon"].ConnectionString;
           
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
          
            ShowDetails();
            ds = obj_class.Get_PrelaodClients();
            ddlClient.Items.Clear();
            ddlClient.DataSource = ds;
            ddlClient.DataTextField = "Client";
            ddlClient.DataValueField = "ClientID";
            ddlClient.DataBind();
            ddlClient.Items.Insert(0, new ListItem("--- Select Client ---", "0"));
            ChkAuthentication();

        }
    }

    //Authentication Section
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
    
    public void ShowDetails()
    {
        try
        {
            dt = obj_class.Bizconnect_TrackingUpdates();
            Gridwindow.DataSource = dt;
            Gridwindow.DataBind();

        }

        catch (Exception ex)
        {
        }
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
                TextBox Remarks = (TextBox)Gridwindow.Rows[row.RowIndex].FindControl("txtRemarks");

                int resp = obj_class.Bizconnect_InsertTrackingLog(Convert.ToInt32(Accepid.Text), Remarks.Text);
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Data Updated Successfully');</script>");
            }
        }
        catch (Exception ex)
        {
        }
    }
    
      protected void btnreport_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet ds = new DataSet();
            ds = obj_class.Get_PrelaodClientsReport(Convert.ToInt32(ddlClient.SelectedValue.ToString()),Convert.ToInt32(ddlMonth.SelectedValue.ToString()));
            Gridwindow.DataSource = ds;
            Gridwindow.DataBind();           
            
        }
        catch (Exception ex)
        {
           
        }
    }
    
     protected void ButDelivered_Click(object sender, EventArgs e)
    {
      try
        {

            Button b = (Button)sender;
            GridViewRow row = (GridViewRow)b.NamingContainer;
            if (row != null)
            {
        Label Accepid = (Label)Gridwindow.Rows[row.RowIndex].FindControl("lblplanID");
        TextBox Remarks = (TextBox)Gridwindow.Rows[row.RowIndex].FindControl("txtRemarks");
        Label lblPLid = (Label)Gridwindow.Rows[row.RowIndex].FindControl("lblPLid");
        Label lblVehicleno = (Label)Gridwindow.Rows[row.RowIndex].FindControl("lblVehicleno");
        int resp = obj_class1.Bizconnect_InsertReceivingDetails(Convert.ToInt32(lblPLid.Text), Convert.ToInt32(Accepid.Text), "0", Convert.ToDateTime(DateTime.Now.ToString()), Remarks.Text, Convert.ToDateTime(DateTime.Now.ToString()), lblVehicleno.Text,1);
        ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Data Saved Successfully');</script>");
			}
        }
        catch (Exception ex)
        {
        }
    }
    
      protected void btnDelay_Click(object sender, EventArgs e)
     {
         try
         {

             SqlConnection conn = new SqlConnection(constr);
             SqlCommand cmd = new SqlCommand();
             conn.ConnectionString = constr;
             conn.Open();             
             SqlDataReader mydatareader;
             string qry;

             qry = "select CorporateEmail from BizConnect_ClientAddressLocation where ClientID=" + ddlClient.SelectedValue.ToString();
             cmd = new SqlCommand(qry, conn);
             mydatareader = cmd.ExecuteReader();
             mydatareader.Read();

             Button b = (Button)sender;
             GridViewRow row = (GridViewRow)b.NamingContainer;
             if (row != null)
             {
                 Label TransporterEmail = (Label)Gridwindow.Rows[row.RowIndex].FindControl("lbltransporteremail");
                 string toemail = TransporterEmail.Text;
                 TextBox Remarks = (TextBox)Gridwindow.Rows[row.RowIndex].FindControl("txtRemarks");
                 string mailbody = "<pre>" + "<font size=4>" + Remarks.Text+ "<br/>Thank You,<br/>AARMSCM SOLUTIONS PRIVATE LIMITED<br>307, 2nd floor, 100 ft ring road,<br>7th block, BSK III STAGE<br>BANGALORE-560085<br></font><br/><br/>";
                 AARMEmail.EmailControl mail = new AARMEmail.EmailControl();
                 int Resp = mail.SendEmail(toemail, "tripschedule@scmbizconnect.com", "tripschedule123", mydatareader.GetValue(0).ToString(), "", "tripschedule@scmbizconnect.com", "tripschedule@scmbizconnect.com", "Delay In Consignment",mailbody, System.Web.Mail.MailFormat.Html, System.Web.Mail.MailPriority.High, "smtp.gmail.com", "465", "2", "1", true, "");
                 ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Delay Mail Sent Successfully');</script>");
             }
         }
         catch (Exception ex)
         {
         }
     }
     protected void Gridwindow_RowDataBound(object sender, GridViewRowEventArgs e)
     {
         try
         {           
     
             if (e.Row.RowType == DataControlRowType.DataRow)
             {
                 DateTime current = DateTime.Now;
                 Label TransitDay = (Label)e.Row.FindControl("lblTransitDay");
                 Label DelayDay = (Label)e.Row.FindControl("lbldelayday");
                 if (Convert.ToInt32(DelayDay.Text) > Convert.ToInt32(TransitDay.Text))
                 {
                     Button Delay = (Button)e.Row.FindControl("btnDelay");
                     Delay.Enabled = true;
                 }

             }
         }
         catch (Exception ex)
         {
         }

     }
}