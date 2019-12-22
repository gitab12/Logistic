using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using AARMEmail;
using System.Collections;
using System.Configuration;
public partial class TripAssignConfirmationWindow : System.Web.UI.Page
{

 string obj_Authenticated;
    PlaceHolder maPlaceHolder;
    UserControl obj_Tabs;
    UserControl obj_LoginCtrl;
    UserControl obj_WelcomCtrl;
    UserControl obj_Navi;
    UserControl obj_Navihome;
    string qry1;
    DataTable dt_EmailIDs = new DataTable();
        ProjectBased obj_class = new ProjectBased();
        string connStr = ConfigurationManager.ConnectionStrings["BizCon"].ConnectionString;
        TripAssignment Trip_Assign = new TripAssignment();
        AARMEmail.EmailControl mail = new AARMEmail.EmailControl();
        string mailbody = "<center><img  src=http://www.scmbizconnect.com/images/logo.jpg /></center><br /><h3>Dear Sir,</h3><br/><br/>Please arrange to place the vehicles as per below Schedule.  Please confirm with all the particulars of vehicle immediately.";
        string body = "";
        DateTime dtt = new DateTime();
        DataTable dt = new DataTable();
        int AcptID;
        int TrasnpID=0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadDetails();
            ChkAuthentication();
            Session["UserID"] = "411";
            if (Request.QueryString["Confno"].ToString() == "0" && txtprojectNo.Text == "")
            {
                But_Abandoned.Enabled = false;
                But_Submit.Enabled = false;
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Trip Already Confirmed ');</script>");
            }
            
          if (Request.QueryString["Confno"].ToString() == "1")
            {
                But_Abandoned.Visible=false;
                But_Submit.Text="Submit";
            }
            //else if (Request.QueryString["Confno"].ToString() == "2")
            // {
            //    But_Abandoned.Visible=true;
            //    But_Abandoned.Text="Cancel";
            //    But_Submit.Visible=false;
            //}
          else if (Request.QueryString["Confno"].ToString() == "0" && Request.QueryString["VR"].ToString() == "T")
          {
              But_Abandoned.Visible = true;
              But_Abandoned.Text = "Cancel";
              But_Submit.Visible = false;
          }

          else if (Request.QueryString["Confno"].ToString() == "0" && Request.QueryString["VR"].ToString() == "TP")
          {
              But_Abandoned.Visible = false;
              //But_Submit.Text = "Submit";
          }

            else if (Request.QueryString["Confno"].ToString() == "5")
             {
                But_Abandoned.Visible=false;
                But_Submit.Visible=false;
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
    
    
    
    public void LoadDetails()
    {
        try{
        DataSet ds = new DataSet();
        TrasnpID = 0;
        if (Request.QueryString["VR"] == "T")
        {
            But_Abandoned.Visible = false;
            But_Submit.Visible = false;
            lbl_CnGeneratedBy.Visible = false;
        }
        ds = obj_class.Bizconnet_GetCollectionNoteDetails(Convert.ToInt32(Request .QueryString["CollectionNoteID"].ToString()),string .Empty);
        txtprojectNo.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
            txtwbsNo.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
            txtDateofIssue.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
            txtTransporter.Text = ds.Tables[0].Rows[0].ItemArray[16].ToString();
            //Getting Project Name
             SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            string qry = "select Projectname,Transporter,TransporterID,ProjectManager , PMMobileNo from Bizconnect_ProjectMaster where ProjectNo='" + txtprojectNo.Text.Trim() + "' ";

                SqlCommand cmd = new SqlCommand(qry, conn);
                DataTable dt = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);

                adp.Fill(dt);
                //Getting TransporterID

                if (Request.QueryString["VR"] == "TP")
                {
                    //Session["TransporterID"] = dt.Rows[0].ItemArray[2].ToString();
                    TrasnpID = Convert.ToInt32(dt.Rows[0].ItemArray[2].ToString());
                    if (Request.QueryString.ToString().Contains("CnGen"))
                    {
                        lbl_CnGeneratedBy.Visible = true;
                        lbl_CnGeneratedBy.Text = "CNote Generated by :<br/> " + Request.QueryString["CnGen"].ToString();
                    }
                    else
                    {

                    }
                }
                else if (Request.QueryString["VR"] == "ALT")
                {
                    //Session["TransporterID"] = 748;
                    //Session["TransporterID"] = Request.QueryString["TrnspID"];
                    TrasnpID = Convert.ToInt32(Request.QueryString["TrnspID"]);
                    if (Request.QueryString.ToString().Contains("CnGen"))
                    {
                        lbl_CnGeneratedBy.Visible = true;
                        lbl_CnGeneratedBy.Text = "CNote Generated by :<br/> " + Request.QueryString["CnGen"].ToString();
                    }
                    else
                    {

                    }
                }
				txtproject.Text=dt.Rows[0].ItemArray[0].ToString();
                txt_Projectmanagername.Text = dt.Rows[0].ItemArray[3].ToString();
                txt_Projectmanagerno.Text = dt.Rows[0].ItemArray[4].ToString();
            txtautonumber.Text = ds.Tables[0].Rows[0].ItemArray[25].ToString();
           
            txtDescription.Text = ds.Tables[0].Rows[0].ItemArray[6].ToString();
            txttrucktype.Text = ds.Tables[0].Rows[0].ItemArray[7].ToString();
            txttransit.Text = ds.Tables[0].Rows[0].ItemArray[8].ToString();
            txtlength.Text = ds.Tables[0].Rows[0].ItemArray[9].ToString();
            txtwidth.Text = ds.Tables[0].Rows[0].ItemArray[10].ToString();
            txtheight.Text = ds.Tables[0].Rows[0].ItemArray[11].ToString();
            txtweight.Text = ds.Tables[0].Rows[0].ItemArray[12].ToString();
            txtFrom.Text = ds.Tables[0].Rows[0].ItemArray[21].ToString();
            txtTo.Text = ds.Tables[0].Rows[0].ItemArray[22].ToString();
            txtTruckPlanned.Text = ds.Tables[0].Rows[0].ItemArray[23].ToString();

           
            dtt = Convert.ToDateTime(ds.Tables[0].Rows[0].ItemArray[18].ToString());
            txtdate.Text = dtt.ToString();
            //txtdate.Text = ds.Tables[0].Rows[0].ItemArray[18].ToString();
            txtagreedprice.Text =Math.Round (Convert.ToDouble (ds.Tables[0].Rows[0].ItemArray[24]),0).ToString();
            txtBuyer.Text = ds.Tables[0].Rows[0].ItemArray[13].ToString();
            txtContactperson.Text = ds.Tables[0].Rows[0].ItemArray[14].ToString();
            txtcontactno.Text = ds.Tables[0].Rows[0].ItemArray[15].ToString();
            txtremarks.Text = ds.Tables[0].Rows[0].ItemArray[17].ToString();
            txt_Buyername.Text = ds.Tables[0].Rows[0].ItemArray[34].ToString();
            txt_Buyerno.Text = ds.Tables[0].Rows[0].ItemArray[35].ToString();
         
            ds = obj_class.Bizconnet_GetCollectionNoteDetails(Convert.ToInt32(Request.QueryString["CollectionNoteID"].ToString()), txtprojectNo.Text);
            try
            {
                if (ds.Tables[1].Rows.Count > 0)
                {
                    txt_Projectmanagername.Text = ds.Tables[1].Rows[0].ItemArray[0].ToString();
                    txt_Projectmanagerno.Text = ds.Tables[1].Rows[0].ItemArray[1].ToString();
                }
            }
            catch (Exception ex)
            {
            }
        //if(Convert.ToInt16(ds.Tables[0].Rows[0].ItemArray[27].ToString())>0)
        //{
        //But_Abandoned.Enabled  = false;
        //  But_Submit.Enabled = false;
        //  ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Trip Already Confirmed ');</script>");
        //}

            if (Convert.ToInt16(ds.Tables[0].Rows[0].ItemArray[27].ToString()) == 1)
            {
                But_Abandoned.Enabled = false;
                But_Submit.Enabled = false;
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Trip Already Confirmed ');</script>");
            }
            else if (Convert.ToInt16(ds.Tables[0].Rows[0].ItemArray[27].ToString()) == 3)
            {
                But_Abandoned.Enabled = false;
                But_Submit.Enabled = false;
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Collectionnote Cancelled');</script>");
            }

        else
        {
         
        }
        
        }
        catch (Exception ex)
        {
        }
    }

    public int GetTransporterID()
    {
        int TrnspID = 0;
        SqlConnection conn = new SqlConnection(connStr);
        conn.Open();
        string qry = "select Projectname,Transporter,TransporterID,ProjectManager ,PMMobileNo from Bizconnect_ProjectMaster where ProjectNo='" + txtprojectNo.Text.Trim() + "' ";
        SqlCommand cmd = new SqlCommand(qry, conn);
        DataTable dt = new DataTable();
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        adp.Fill(dt);
        //Getting TransporterID

        if (Request.QueryString["VR"] == "TP")
        {
            TrnspID = Convert.ToInt32(dt.Rows[0].ItemArray[2].ToString());
        }
        else if (Request.QueryString["VR"] == "ALT")
        {
            TrnspID = Convert.ToInt32(Request.QueryString["TrnspID"]);
        }
        return TrnspID;
    }

    protected void But_Submit_Click(object sender, EventArgs e)
    {
       
        if (txtdate.Text == "")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Enter Valid Date');</script>");
        }
        else
        {
            dt = Trip_Assign.Bizconnect_CheckTripIndentIDExistance(Convert.ToInt32(Request.QueryString["CollectionNoteID"].ToString()));
            if (dt.Rows .Count >0)
            {
                AcptID = Convert.ToInt32(dt.Rows[0][0]);
            }
            if (AcptID == 0)
            {
            if (Request.QueryString["Confno"].ToString() == "0")
            {
                TrasnpID = GetTransporterID();
                int resp = Trip_Assign.Bizconnect_ConfirmCollectionNote(Convert.ToInt32(Request.QueryString["CollectionNoteID"].ToString()), Convert.ToDateTime(txtdate.Text));
               // SendMailForTripAssign();
                  //ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Collection Note Confirmed');</script>");
                dtt = Convert.ToDateTime(txtdate.Text);
                    for (int k = 0; k < Convert.ToInt16(txtTruckPlanned.Text); k++)
                    {
                        Double  agreedprice = Math.Round (Convert.ToSingle  (txtagreedprice.Text),0);

                        //int resp1 = Trip_Assign.Bizconnect_InsertTripAssignwithIndent(0, txtFrom.Text, txtTo.Text, txttrucktype.Text, "open", "0", Convert.ToInt32(agreedprice), Convert.ToInt32(Session["TransporterID"].ToString()), 1, Convert .ToDateTime(txtdate.Text ), "12 PM", Convert.ToInt32(Session["UserID"].ToString()), Convert.ToInt32(Request.QueryString["CollectionNoteID"].ToString()));
                        int resp1 = Trip_Assign.Bizconnect_InsertTripAssignwithIndent(0, txtFrom.Text, txtTo.Text, txttrucktype.Text, "open", "0", Convert.ToInt32(agreedprice), TrasnpID, 1, Convert.ToDateTime(txtdate.Text), "12 PM", Convert.ToInt32(Session["UserID"].ToString()), Convert.ToInt32(Request.QueryString["CollectionNoteID"].ToString()));
                        But_Submit.Enabled = false;
                        EmailCompose();
                }
                             ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Collection Note Confirmed.Please check the mail and enter vehicle details');</script>");
            }
                    else
                    {
               
                    }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Trip Already Confirmed');</script>");
            }
          
        }
    }

    public void SendMailForTripAssign()
    {

dt_EmailIDs = GetEmailIDs();
        //string TransporterEmail = dt_EmailIDs.Rows[0].ItemArray[0].ToString();
        string ProjectManagerEmail = dt_EmailIDs.Rows[0].ItemArray[1].ToString();
        string LogisticPersonEmail = dt_EmailIDs.Rows[0].ItemArray[2].ToString();
        string body = "<table style='background-color: #f6f6f6;width: 59%;'> <td  style='display: block;max-width: 600px;margin: 0 auto;clear: both;width: 650px;height: 427px;' ><div style=' max-width: 1200px;margin: 0 auto;display: block;padding: 20px;'><table cellpadding=0 cellspacing=0 style='width:100%;' > <tr> <td> <table  cellpadding=0 cellspacing=0><tr><td></td></tr> <tr><td style='padding: 0 0 20px';><center><img  src=http://www.scmbizconnect.com/images/logo.jpg /></center><br /><h3>Dear Sir/Madam,</h3></td></tr><tr><td style=' padding: 0 0 20px;'>We confirm that the below collection note can be placed immediately.  Kindly send a Request for Vehicle placement.</td></tr><tr><td style=' padding: 0 0 20px;'>  <br /></table><a  style='text-decoration: none; color: #FFF;background-color: #1a88b3;border: solid #1a88b3;border-width: 0px 1px;line-height: 2;font-weight: bold;text-align: center;cursor: pointer;display: inline-block;border-radius: 5px;text-transform: capitalize;'href=http://www.scmbizconnect.com/TripAssignConfirmationWindow.aspx?Confno=1&CollectionNoteID=" + Request.QueryString["CollectionNoteID"].ToString() + " target =_blank>Please click this link for Assigning the Vehicle</a><br/><br /><tr><td style='padding: 0 0 20px;'>Thank You,</td></tr> <tr><td style='width: 656px;' ><a href=http://www.scmbizconnect.com>www.scmbizconnect.com</a></td></tr> </table></td></tr></table></div></td> </table>";
        mail.SendEmail( ProjectManagerEmail + "," + LogisticPersonEmail, "thermax@scmbizconnect.com", "thermax123", "", "", "connect@scmjunction.com", "bounceback@scmjunction.com", "Collection Note Confimation-" + txtautonumber.Text + "", body, System.Web.Mail.MailFormat.Html, System.Web.Mail.MailPriority.High, "smtp.gmail.com", "465", "2", "1", true, "");

    }

    public void EmailCompose()
    {
    
    //Transporter EmailID
  SqlConnection conn = new SqlConnection(connStr);
            conn.Open();

            TrasnpID = GetTransporterID();
            if (Request.QueryString["VR"] == "ALT")
            {
                qry1 = " select EmailID  from Bizconnect_ClientsTransporters where TransporterID='" + TrasnpID.ToString() + "' ";
            }
            else
            {
              qry1  = "select TransporterEmailID from Bizconnect_ProjectMaster where ProjectNo='" + txtprojectNo.Text + "' ";
            }

                SqlCommand cmd = new SqlCommand(qry1, conn);
                DataTable dt = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);

                adp.Fill(dt);

string TransporterEmail=dt.Rows[0].ItemArray[0].ToString();


string tableheader = "<table bgcolor=White bordercolor=#003366 border=1 style=width: 650px ><tr><td align=center><b>Trip Summary</b></td></tr><tr><td align=center bgcolor=#585858><Font size=2 color=White><strong>ProjectNo</strong></font></td><td align=center bgcolor=#585858><Font size=2 color=White><strong>WBSNo</strong></font></td><td align=center bgcolor=#585858><Font size=2 color=White><strong>From</strong></font></td><td align=center bgcolor=#585858><Font size=2 color=White><strong>To</strong></font></td><td align=center bgcolor=#585858><Font size=2 color=White><strong>TruckType</strong></font></td><td align=center bgcolor=#585858><Font size=2 color=White><strong>Product</strong></font></td><td align=center bgcolor=#585858><Font size=2 color=White><strong>IndentID</strong></font></td><td align=center bgcolor=#585858><Font size=2 color=White><strong>NoofTrucksReq.</strong></font></td><td align=center bgcolor=#585858><Font size=2 color=White><strong>TotalAmount</strong></font></td><td align=center bgcolor=#585858><Font size=2 color=White><strong>TravelDate</strong></font></td></tr>";


body += "<tr><td align=center><font size=2>" + txtprojectNo.Text + "</font></td><td align=center><font size=2>" + txtwbsNo.Text + "</font></td><td align=center><font size=2>" + txtFrom.Text + "</font></td><td align=center><font size=2 >" + txtTo.Text + "</font></td><td align=center><font size=2>" + txttrucktype.Text + "</font></td><td align=center><font size=2>" + txtDescription.Text + "</font></td><td align=center><font size=2>" + txtprojectNo.Text + "/" + txtwbsNo.Text + "</font></td><td align=center><font size=2>" + txtTruckPlanned.Text + "</font></td><td align=center><font size=2>" + txtagreedprice.Text + "</font></td><td align=center><font size=2>" + txtdate.Text + "</font></td></tr>";

body = mailbody + tableheader + body + "</table>" + "<br/><a  style='text-decoration: none; color: #FFF;background-color: #1a88b3;border: solid #1a88b3;border-width: 0px 1px;line-height: 2;font-weight: bold;text-align: center;cursor: pointer;display: inline-block;border-radius: 5px;text-transform: capitalize;'href=http://www.scmbizconnect.com/TripAcceptance.aspx?TransID=" + TrasnpID.ToString() + "&agID=0&ClID=1135 target =_blank>  Click Here to Confirm the Routes</a><br/>Thank you<br /><a href=http://www.scmbizconnect.com>www.scmbizconnect.com</a></br></br>";
        //mail.SendEmail(Email.ToString(), "connect@scmjunction.com", "scmjunction", "", "", "connect@scmjunction.com", "bounceback@scmjunction.com", "Trip Assigned", body, System.Web.Mail.MailFormat.Html, System.Web.Mail.MailPriority.High, "smtp.gmail.com", "465", "2", "1", true, "");
 mail.SendEmail(TransporterEmail.ToString(), "thermax@scmbizconnect.com", "thermax123", "", "", "thermax@scmbizconnect.com", "bounceback@scmjunction.com", "Placement of Vehicle for '"+ txtautonumber.Text +"' ", body, System.Web.Mail.MailFormat.Html, System.Web.Mail.MailPriority.High, "smtp.gmail.com", "465", "2", "1", true, "");
    
     //mail.SendEmail("aarms_logistics@aarmscmsolutions.com", "thermax@scmbizconnect.com", "thermax123", "", "", "thermax@scmbizconnect.com", "bounceback@scmjunction.com", "Placement of Vehicle for '"+ txtautonumber.Text +"'", body, System.Web.Mail.MailFormat.Html, System.Web.Mail.MailPriority.High, "smtp.gmail.com", "465", "2", "1", true, "");
    }
    
    
    
    protected void But_Abandoned_Click(object sender, EventArgs e)
    {
        AbandonCollectionNote();
        But_Abandoned.Enabled=false;
    }


    public void SendMailForAbandon()
    {
		dt_EmailIDs = GetEmailIDs();
        
        string ProjectManagerEmail = dt_EmailIDs.Rows[0].ItemArray[1].ToString();
        string LogisticPersonEmail = dt_EmailIDs.Rows[0].ItemArray[2].ToString();
        string LogisticManager = dt_EmailIDs.Rows[0].ItemArray[3].ToString();
        string body = "<table style='background-color: #f6f6f6;width: 59%;'> <td  style='display: block;max-width: 600px;margin: 0 auto;clear: both;width: 650px;height: 427px;' ><div style=' max-width: 1200px;margin: 0 auto;display: block;padding: 20px;'><table cellpadding=0 cellspacing=0 style='width:100%;' > <tr> <td> <table  cellpadding=0 cellspacing=0><tr><td style='width: 655px;'></td></tr> <tr><td style='padding: 0 0 20px;width: 655px;';><center><img  src=http://www.scmbizconnect.com/images/logo.jpg /></center><br /><h3>Dear Sir/Madam,</h3></td></tr><tr><td style=' padding: 0 0 20px;width: 655px;' >The below collection note has been amendment. Kindly cancel the collection note.</td></tr><tr><td style=' padding: 0 0 20px;width: 655px;'>  <br /></table><a  style='text-decoration: none; color: #FFF;background-color: #1a88b3;border: solid #1a88b3;border-width: 0px 1px;line-height: 2;font-weight: bold;text-align: center;cursor: pointer;display: inline-block;border-radius: 5px;text-transform: capitalize;'href=http://www.scmbizconnect.com/TripAssignConfirmationWindow.aspx?Confno=2&CollectionNoteID=" + Request.QueryString["CollectionNoteID"].ToString() + ">Please click this link for cancellation of CollectionNote</a><br/><br /><tr><td style='padding: 0 0 20px;'>Thank You,</td></tr> <tr><td style='width: 656px;' ><a href=http://www.scmbizconnect.com>www.scmbizconnect.com</a></td></tr> </table></td></tr></table></div></td> </table>";
        mail.SendEmail(LogisticManager.ToString(), "thermax@scmbizconnect.com", "thermax123", ProjectManagerEmail + "," + LogisticPersonEmail, "", "connect@scmjunction.com", "bounceback@scmjunction.com", "Collection Note", body, System.Web.Mail.MailFormat.Html, System.Web.Mail.MailPriority.High, "smtp.gmail.com", "465", "2", "1", true, "");
    }

    public void AbandonCollectionNote()
    {

        if (Request.QueryString["Confno"].ToString() == "0")
        {
            dt.Clear();
            dt = Trip_Assign.Bizconnect_CheckCnNoteAcceptacneFlag(Convert.ToInt32(Request.QueryString["CollectionNoteID"].ToString()));
            if (Convert.ToInt32(dt.Rows[0][0]) == 0)
            {
                int resp1 = Trip_Assign.Bizconnect_AbandonCollectionNote(Convert.ToInt32(Request.QueryString["CollectionNoteID"].ToString()), 3, txtremarks.Text);
                //SendMailForAbandon();
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('CollectionNote Cancelled');</script>");
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('This CollectionNote can't be Cancelled because it is already confirmed');</script>");
            }
        }

        //if (Request.QueryString["Confno"].ToString() == "2")
        //{
        //    int resp1 = Trip_Assign.Bizconnect_AbandonCollectionNote(Convert.ToInt32(Request.QueryString["CollectionNoteID"].ToString()), 3, txtremarks.Text);
        //    SendMailForAbandon();
        //    ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('CollectionNote Cancelled');</script>");
        //}
        //else if ((Request.QueryString["Confno"].ToString() == "1")||(Request.QueryString["Confno"].ToString() == "0"))
        //{
        //    int resp1 = Trip_Assign.Bizconnect_AbandonCollectionNote(Convert.ToInt32(Request.QueryString["CollectionNoteID"].ToString()), 2, txtremarks.Text);
        //    SendMailForAbandon();
        //    ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('CollectionNote amendment');</script>");
        //}
    
    }
    
    public DataTable  GetEmailIDs()
    {
        SqlConnection conn = new SqlConnection(connStr);
        conn.Open();
        string qry = "select TransporterEmailID,ProjectManagerEmailID,ShippingpersonEmail,LogisticManagerEmail from Bizconnect_ProjectMaster where ProjectNo='" + txtprojectNo.Text + "' ";

        SqlCommand cmd = new SqlCommand(qry, conn);
        DataTable dt = new DataTable();
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        adp.Fill(dt);
        return dt;
    }
    
}
