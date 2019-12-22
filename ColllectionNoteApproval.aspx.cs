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

public partial class ColllectionNoteApproval : System.Web.UI.Page
{
    string obj_Authenticated;
    PlaceHolder maPlaceHolder;
    UserControl obj_Tabs;
    UserControl obj_LoginCtrl;
    UserControl obj_WelcomCtrl;
    UserControl obj_Navi;
    UserControl obj_Navihome;
    ProjectBased obj_class = new ProjectBased();
    TripAssignment Trip_Assign = new TripAssignment();
    AARMEmail.EmailControl mail = new AARMEmail.EmailControl();
    UserAuthentication obj_Class1 = new UserAuthentication();
    string connStr = ConfigurationManager.ConnectionStrings["BizCon"].ConnectionString;
    string mailbody = "Dear Sir,<br/><br/>Please arrange to place the vehicles as per below Schedule.  Please confirm with all the particulars of vehicle immediately.";
    string body = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //ChkAuthentication();
            LoadDetails();
            txtUserID.ForeColor = System.Drawing.Color.Red;
            txtPassword.ForeColor = System.Drawing.Color.Red;
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
        try
        {
            DataSet ds = new DataSet();
            ds = obj_class.Bizconnet_GetCollectionNoteDetails(Convert.ToInt32(Request.QueryString["CollectionNoteID"].ToString()), txtprojectNo.Text);
            txtprojectNo.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
            txtwbsNo.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
            txtDateofIssue.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
            txtTransporter.Text = ds.Tables[0].Rows[0].ItemArray[16].ToString();
            if (ds.Tables[0].Rows[0].ItemArray[27].ToString() == "4")
            {
                But_Submit.Text = "Approve";
                But_Submit.Enabled = true;
            }
            else
            {
                But_Submit.Text = "Approved";
                But_Submit.Enabled = false;
            }
            //Getting Project Name
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            string qry = "select Projectname from Bizconnect_ProjectMaster where ProjectNo='" + txtprojectNo.Text + "' ";

            SqlCommand cmd = new SqlCommand(qry, conn);
            DataTable dt = new DataTable();
            SqlDataAdapter adp = new SqlDataAdapter(cmd);

            adp.Fill(dt);
            txtproject.Text = dt.Rows[0].ItemArray[0].ToString();

            txtautonumber.Text = ds.Tables[0].Rows[0].ItemArray[4].ToString();

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
            txtdate.Text = ds.Tables[0].Rows[0].ItemArray[18].ToString();
            txtagreedprice.Text = Math.Round(Convert.ToDouble(ds.Tables[0].Rows[0].ItemArray[24]), 0).ToString();
            txtBuyer.Text = ds.Tables[0].Rows[0].ItemArray[13].ToString();
            txtContactperson.Text = ds.Tables[0].Rows[0].ItemArray[14].ToString();
            txtcontactno.Text = ds.Tables[0].Rows[0].ItemArray[15].ToString();
            txtremarks.Text = ds.Tables[0].Rows[0].ItemArray[17].ToString();
            txtreason.Text = ds.Tables[0].Rows[0].ItemArray[32].ToString();
            txt_CNNo.Text = ds.Tables[0].Rows[0].ItemArray[25].ToString();
        }
        catch (Exception ex)
        {
        }
    }


    protected void But_Submit_Click(object sender, EventArgs e)
    {
        //Sign For Approval
        ArrayList list = new ArrayList();

        //Check weather the user is aarms or client
        list = obj_Class1.Verify_Usertype(txtUserID.Text.Trim(), txtPassword.Text.Trim());
        if (Convert.ToInt32(list[2].ToString()) > 0)
        {
            Session["name"] = list[1];
            Session["Authenticated"] = "1";
            Session["EmailID"] = txtUserID.Text.Trim();
            Session["UserID"] = list[2];


            if (txtdate.Text == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Enter Valid Date');</script>");
            }
            else
            {
                int Autonumber = AutoNumber();

                int resp = Trip_Assign.Bizconnect_ApprovalCollectionNote(Convert.ToInt32(Request.QueryString["CollectionNoteID"].ToString()), Convert.ToDateTime(txtdate.Text), Convert.ToInt32(txtTruckPlanned.Text), txtFrom.Text, txtTo.Text, txtDescription.Text, txttrucktype.Text, Autonumber.ToString(), Convert.ToInt32(Session["SignID"].ToString()), Convert.ToDouble(txtDiffAmt.Text), txtjustification.Text);

                // int resp1 = Trip_Assign.Bizconnect_InsertTripAssignwithIndent(0, txtFrom.Text, txtTo.Text, txttrucktype.Text, "open", "0", Convert.ToInt32(txtagreedprice.Text), 712, Convert.ToInt32(txtTruckPlanned.Text), Convert.ToDateTime(txtdate.Text), "12 PM", 12, Convert.ToInt32(Request.QueryString["CollectionNoteID"].ToString()));
                EmailCompose();
                But_Submit.Enabled = false;

                ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Collection Note Approved');</script>");

            }

        }
        else
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Enter Valid UserID and Password');</script>");
        }

    }

    public int AutoNumber()
    {
        var random = new Random(System.DateTime.Now.Millisecond);
        int randomNumber = random.Next(1, 500000);
        return randomNumber;

    }
    public void EmailCompose()
    {
        //Transporter EmailID
        SqlConnection conn = new SqlConnection(connStr);
        conn.Open();
        string qry2;
        string qry = "select TransporterEmailID,ShippingpersonEmail from Bizconnect_ProjectMaster where ProjectNo='" + txtprojectNo.Text + "' ";

        SqlCommand cmd = new SqlCommand(qry, conn);
        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        adp.Fill(dt);
        string TransporterEmail = dt.Rows[0].ItemArray[0].ToString();
        string ShippingPerson = dt.Rows[0].ItemArray[1].ToString();
        if (TransporterEmail == "" || txtprojectNo.Text.Contains("SPL"))
        {
            if (Request.QueryString.ToString().Contains("TrnspID"))
            {
                // If query string exists
                if (txtprojectNo.Text.Contains("SPL"))
                {// For special projects
                    if (Request.QueryString["TrnspID"].ToString() != "--Select--")
                    {
                        dt.Clear();
                        qry2 = "select EmailID  from Bizconnect_ClientsTransporters where TransporterID =" + Convert.ToInt32(Request.QueryString["TrnspID"]);
                        SqlCommand cmd2 = new SqlCommand(qry2, conn);
                        SqlDataAdapter ad = new SqlDataAdapter(cmd2);
                        ad.Fill(dt);
                        TransporterEmail = dt.Rows[0].ItemArray[2].ToString();
                    }
                }
                else
                {

                }
            }
            else
            {// IF query string not exists

                if (txtprojectNo.Text.Contains("SPL"))
                {
                    dt1.Clear();
                    qry2 = "select EmailID,TransporterID  from Bizconnect_ClientsTransporters where Transporter like '%" + txtTransporter.Text.Substring(0, 6) + "%'";
                    SqlCommand cmd2 = new SqlCommand(qry2, conn);
                    SqlDataAdapter ad = new SqlDataAdapter(cmd2);
                    ad.Fill(dt1);
                    TransporterEmail = dt1.Rows[0].ItemArray[0].ToString();
                }
            }

        }
        string tableheader = "<table bgcolor=White bordercolor=#003366 border=1 style=width: 650px ><tr><td align=center><b>Trip Summary</b></td></tr><tr><td align=center bgcolor=#585858><Font size=2 color=White><strong>From</strong></font></td><td align=center bgcolor=#585858><Font size=2 color=White><strong>To</strong></font></td><td align=center bgcolor=#585858><Font size=2 color=White><strong>TruckType</strong></font></td><td align=center bgcolor=#585858><Font size=2 color=White><strong>Product</strong></font></td><td align=center bgcolor=#585858><Font size=2 color=White><strong>IndentID</strong></font></td><td align=center bgcolor=#585858><Font size=2 color=White><strong>NoofTrucksReq.</strong></font></td><td align=center bgcolor=#585858><Font size=2 color=White><strong>TotalAmount</strong></font></td><td align=center bgcolor=#585858><Font size=2 color=White><strong>TravelDate</strong></font></td></tr>";
        //body += "<tr><td align=center><font size=2>" + txtFrom.Text +  "</font></td><td align=center><font size=2 >" + txtTo.Text + "</font></td><td align=center><font size=2>" + txttrucktype .Text + "</font></td><td align=center><font size=2>" + txtDescription.Text + "</font></td><td align=center><font size=2>" + txtprojectNo.Text + "/" + txtwbsNo.Text + "</font></td><td align=center><font size=2>" + txtTruckPlanned .Text + "</font></td><td align=center><font size=2>" + txtagreedprice.Text + "</font></td><td align=center><font size=2>" + txtdate.Text + "</font></td></tr>";
        //body = mailbody + tableheader + body + "</table>" + "<a href=http://www.scmbizconnect.com/TripAcceptance.aspx?TransID=716&agID=0&ClID=1135 target =_blank>  Click Here to Confirm the Routes\n\n</a></br></br></br>Best Regards</br></br></br>SCMBizconnect Team.";
        //mail.SendEmail(Email.ToString(), "connect@scmjunction.com", "scmjunction", "", "", "connect@scmjunction.com", "bounceback@scmjunction.com", "Trip Assigned", body, System.Web.Mail.MailFormat.Html, System.Web.Mail.MailPriority.High, "smtp.gmail.com", "465", "2", "1", true, "");
        string body;
        if (txtprojectNo.Text.Contains("SPL") && Request.QueryString.ToString().Contains("TrnspID"))
        {
            body = "Dear Transporter,<br/><br/>The following Description of items against the Project No and the WBS No is ready, to be loaded from the following address and delivered to the address mentioned below .  The approval for change in the indent if any has been obtained and the amended Indent details is given below :  <br/><br/><br/><a href=http://www.scmbizconnect.com/TripAssignConfirmationWindow.aspx?Confno=0&VR=ALT&CollectionNoteID=" + Request.QueryString["CollectionNoteID"].ToString() + "&TrnspID=" + Request.QueryString["TrnspID"].ToString() + "   target =_blank>Please click here for confirming the CollectionNote.</a>";
        }
        else if (txtprojectNo.Text.Contains("SPL") && !Request.QueryString.ToString().Contains("TrnspID"))
        {
            body = "Dear Transporter,<br/><br/>The following Description of items against the Project No and the WBS No is ready, to be loaded from the following address and delivered to the address mentioned below .  The approval for change in the indent if any has been obtained and the amended Indent details is given below :  <br/><br/><br/><a href=http://www.scmbizconnect.com/TripAssignConfirmationWindow.aspx?Confno=0&VR=ALT&CollectionNoteID=" + Request.QueryString["CollectionNoteID"].ToString() + "&TrnspID=" + dt1.Rows[0][1].ToString() + "   target =_blank>Please click here for confirming the CollectionNote.</a>";
        }
        else
        {
            body = "Dear Transporter,<br/><br/>The following Description of items against the Project No and the WBS No is ready, to be loaded from the following address and delivered to the address mentioned below .  The approval for change in the indent if any has been obtained and the amended Indent details is given below :  <br/><br/><br/><a href=http://www.scmbizconnect.com/TripAssignConfirmationWindow.aspx?Confno=0&VR=TP&CollectionNoteID=" + Request.QueryString["CollectionNoteID"].ToString() + "   target =_blank>Please click here for confirming the CollectionNote.</a>";
        }
        mail.SendEmail(TransporterEmail.ToString(), "thermax@scmbizconnect.com", "thermax123", "", "", "thermax@scmbizconnect.com", "bounceback@scmjunction.com", "Placement of Vehicle-" + txt_CNNo.Text + "", body, System.Web.Mail.MailFormat.Html, System.Web.Mail.MailPriority.High, "smtp.gmail.com", "465", "2", "1", true, "");

       // string body1 = "Dear Sir/Madam,<br/><br/>The Collection Note has been approved.  \n\n<a href=http://www.scmbizconnect.com/TripAssignConfirmationWindow.aspx?Confno=5&CollectionNoteID=" + Request.QueryString["CollectionNoteID"].ToString() + "> Please click the below link to view the Collection Note</a> ";
        string body1 = "<table style='background-color: #f6f6f6;width: 59%;'> <td  style='width: 650px; display: block !important;max-width: 600px !important;margin: 0 auto !important;clear: both !important;'><div style=' max-width: 600px;margin: 0 auto;display: block;padding: 20px;'><table cellpadding=0 cellspacing=0 style='width:100%;' > <tr> <td> <table  cellpadding=0 cellspacing=0><tr><td><center><img  src=http://www.scmbizconnect.com/images/logo.jpg /></center></td></tr> <tr><td style='padding: 0 0 20px';><h3>Dear Sir/madam,</h3></td></tr><tr><td style=' padding: 0 0 20px;'>The Collection Note has been approved.</td></tr><tr><td style=' padding: 0 0 20px;'><center><a style='text-decoration: none;color: #FFF;background-color: #1a88b3;border: solid #1a88b3;border-width: 0px 1px;line-height: 2;font-weight: bold;text-align: center;cursor: pointer;display: inline-block; border-radius: 5px;text-transform: capitalize;' href=http://www.scmbizconnect.com/TripAssignConfirmationWindow.aspx?Confno=5&CollectionNoteID=" + Request.QueryString["CollectionNoteID"].ToString() + "> Please click the below link to view the Collection Note</a></center> </br><tr><td style=' padding: 0 0 20px;'>Thank You,</td></tr> <tr><td style='width: 656px;' ><a href=http://www.scmbizconnect.com>www.scmbizconnect.com</a></td></tr> </table></td></tr></table></div></td> </table>";
        mail.SendEmail(ShippingPerson.ToString(), "thermax@scmbizconnect.com", "thermax123", "", "", "thermax@scmbizconnect.com", "bounceback@scmjunction.com", "Collection Note-" + txt_CNNo.Text + "", body1, System.Web.Mail.MailFormat.Html, System.Web.Mail.MailPriority.High, "smtp.gmail.com", "465", "2", "1", true, "");
    }
}
