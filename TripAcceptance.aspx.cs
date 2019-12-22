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
using AARMEmail;
using System.Data.SqlClient ;
using System.Globalization;

using System.IO;
using System.Net;

public partial class TripAcceptance : System.Web.UI.Page
{
    TripAssignment obj_Class = new TripAssignment();
     BizConnectClient obj_client = new BizConnectClient();
      BizConnectClass obj_class = new BizConnectClass();
    DataSet ds;
    DataTable dt_ThermaxMailIDs;
    string PMLogpersonmails;
    SqlCommand Command;
     int mailflg = 0;
    AARMEmail.EmailControl mail = new AARMEmail.EmailControl();
    string obj_Authenticated;
    PlaceHolder maPlaceHolder;
    UserControl obj_Tabs;
    UserControl obj_LoginCtrl;
    UserControl obj_WelcomCtrl;
    UserControl obj_Navi;
    UserControl obj_Navihome;
    
     string Conn = ConfigurationManager.ConnectionStrings["BizCon"].ConnectionString;
    int resp=0;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                Session["Tid"] = Request.QueryString["TransID"].ToString();
                //Session["CltID"] = Request.QueryString["ClID"].ToString();
                LoadTripPlan(Convert.ToInt32(Request.QueryString["TransID"].ToString()));
                ChkAuthentication();
            }
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

    public void LoadTripPlan(int TransporterID)
    {
        try
        {

            if (Request.QueryString["agID"].ToString() == "0")
            {
                ds = obj_Class.Bizconnect_TripAcceptancewithoutAgreement(TransporterID);
            }
            else
            {
                ds = obj_Class.Bizconnect_TripAcceptance(TransporterID, Request.QueryString["agID"].ToString());
            }
            Gridwindow.DataSource = ds;
            Gridwindow.DataBind();

            lbl_Transporter.Text = "Transporter :" + ds.Tables[0].Rows[0][7].ToString();
        }
        catch (Exception ex)
        {
        }
    }
    protected void ButAcceptance_Click(object sender, EventArgs e)
    {
        try
        {

            Session["TripAssignID"] = "0";
            for (int j = 0; j <= Gridwindow.Rows.Count - 1; j++)
            {
                CheckBox check = (CheckBox)Gridwindow.Rows[j].FindControl("ChkSelect");
                if (check.Checked)
                {
                    Label lblplanID = (Label)Gridwindow.Rows[j].FindControl("lblplanID");
                    Label lblClientID = (Label)Gridwindow.Rows[j].FindControl("lblClientID");
                    Session["lblClientID"]=lblClientID.Text;
                    Label lblClientadrID = (Label)Gridwindow.Rows[j].FindControl("lblClientadrID");
                     Session["lblClientadrID"]=lblClientadrID.Text;
                    TextBox txtvehicleno = (TextBox)Gridwindow.Rows[j].FindControl("txtvehicleno");
                    TextBox txtDriver = (TextBox)Gridwindow.Rows[j].FindControl("txtDriver");
                    TextBox txtmobileno = (TextBox)Gridwindow.Rows[j].FindControl("txtmobileno");
                     Label lblTransporterEmail = (Label)Gridwindow.Rows[j].FindControl("lblTEmail");
                     TextBox Vehicleplacementdatetime = (TextBox)Gridwindow.Rows[j].FindControl("txtTripTime");

                  Session["TransporterEmail"] = lblTransporterEmail.Text;

                  Label lblMobile = (Label)Gridwindow.Rows[j].FindControl("lblMobile");
                  Label lbltoloc = (Label)Gridwindow.Rows[j].FindControl("lbltoloc");
                  Label lblFromLoc = (Label)Gridwindow.Rows[j].FindControl("lblFromLoc");
                   if (lblClientID.Text == "0")
                    {
                       ds=obj_client.Fillclientcity (Convert.ToInt32(Request.QueryString["ClID"].ToString()));
                      
                         lblClientID.Text =ds.Tables[0].Rows[0].ItemArray[2].ToString();
                         Session["lblClientID"] = lblClientID.Text;
                         lblClientadrID.Text =ds.Tables[0].Rows[0].ItemArray[1].ToString();
                           Session["lblClientadrID"]=    lblClientadrID.Text;
                        Session["ClientEmail"] =ds.Tables[0].Rows[0]["CorporateEmail"].ToString();
//For Thermax



                         if (txtvehicleno.Text == ""|| txtmobileno.Text=="")
                        {

                            ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Enter valid Vehicle No/Mobile No');</script>");

                        }
                        else
                       {
                           resp = obj_Class.Bizconnect_InsertTripAcceptanceDetails(Convert.ToInt32(Request.QueryString["TransID"].ToString()), Convert.ToInt32(lblClientID.Text), Convert.ToInt32(lblClientadrID.Text), Convert.ToInt32(lblplanID.Text), txtvehicleno.Text, txtDriver.Text, txtmobileno.Text, DateTime.ParseExact(Vehicleplacementdatetime.Text, "dd/MM/yyyy hh:mm tt", CultureInfo.InvariantCulture));
                      
                         
                         }
                    }
                    else
                    {
                     if (txtvehicleno.Text == ""|| txtmobileno.Text=="")
                        {

                            ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Enter valid Vehicle No/Mobile No');</script>");

                        }
                        else
                        {
                            resp = obj_Class.Bizconnect_InsertTripAcceptanceDetails(Convert.ToInt32(Request.QueryString["TransID"].ToString()), Convert.ToInt32(lblClientID.Text), Convert.ToInt32(lblClientadrID.Text), Convert.ToInt32(lblplanID.Text), txtvehicleno.Text, txtDriver.Text, txtmobileno.Text, DateTime.ParseExact(Vehicleplacementdatetime.Text, "dd/MM/yyyy hh:mm tt", CultureInfo.InvariantCulture));
                    sendsms(lblFromLoc.Text, lbltoloc.Text, txtvehicleno.Text, txtDriver.Text, lblMobile.Text);	
                     }
                   }
                    Session["TripAssignID"] = Session["TripAssignID"] + "," + lblplanID.Text;
                    if (resp == 0 || resp != 0)
                    {
                        mailflg = 1;
                       
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Trip Confirmed');</script>");
						
                    }

                }
                
                
            }

            if (mailflg == 1)
            {
                SendMail();
                 LoadTripPlan(Convert.ToInt32(Request.QueryString["TransID"].ToString()));
                ButAcceptance.Enabled =true;
            }
        }
        catch (Exception ex)
        {
        }
    }

    public void sendsms(string frm, string to, string Vehno, string Driver, string mobile)
    {
        try
        {
            string mobile1 = mobile.ToString();
            string message1 = "Vehicle Confirmed for " + frm + " to " + to + "Vehicle No " + Vehno + "Driver " + Driver + " Mob:" + mobile + " ";
            string username1 = "aarmscm";
            string password1 = "demo1234";
            string senderid = "AARMS";
            string domian1 = "sms.cannyinfotech.com";
            string result = apicall("http://" + domian1 + "/sendsms.jsp?user=" + username1 + "&password=" + password1 + "&mobiles=91" + mobile1 + "&sms=" + message1 + "&unicode=0&senderid=" + senderid + "&version=3");
            //string result = apicall("http://" + domian1 + "/pushsms.php?username=" + username1 + "&password=" + password1 + "&sender=" + sender1 + "&to=" + mobile1 + "&message=" + message1);
            if (!result.StartsWith("Wrong Username or Password"))
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "success", "alert('Message Sent')", true);
            }
            else
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "success", "alert('Message Sending Failed')", true);
            }

        }
        catch
        {
        }
    }

    public string apicall(string url)
    {
        HttpWebRequest httpreq = (HttpWebRequest)WebRequest.Create(url);

        try
        {

            HttpWebResponse httpres = (HttpWebResponse)httpreq.GetResponse();

            StreamReader sr = new StreamReader(httpres.GetResponseStream());

            string results = sr.ReadToEnd();

            sr.Close();
            return results;
        }
        catch
        {
            return "0";
        }
    }



 public void SendMail()
    {
        Label lblIndent1;
     SqlConnection conn = new SqlConnection();
            SqlCommand cmd;
            conn.ConnectionString = Conn;
            conn.Open();
            SqlDataReader mydatareader;
            string qry, qry2;
            string content = "<center><img  src=http://www.scmbizconnect.com/images/logo.jpg /></center><br /><h3>Dear Sir/Madam,</h3><br/><br/>The Details for Trip Confirmation with Confirmation No. is given below";
            string tableheader = "<table bgcolor=White bordercolor=#003366 border=1 style=width: 650px ><tr><td align=center><b>Trip Confirmation Details</b></td></tr><tr><td align=center bgcolor=#585858><Font size=2 color=White><strong>From</strong></font></td><td align=center bgcolor=#585858><Font size=2 color=White><strong>To</strong></font></td><td align=center bgcolor=#585858><Font size=2 color=White><strong>TravelDate</strong></font></td><td align=center bgcolor=#585858><Font size=2 color=White><strong>Truck Type</strong></font></td><td align=center bgcolor=#585858><Font size=2 color=White><strong>Vehicle No</strong></font></td><td align=center bgcolor=#585858><Font size=2 color=White><strong>Driver</strong></font></td><td align=center bgcolor=#585858><Font size=2 color=White><strong>MobileNo</strong></font></td><td align=center bgcolor=#585858><Font size=2 color=White><strong>Confirmation No.</strong></font></td> <td align=center bgcolor=#585858><Font size=2 color=White><strong>Client Name</strong></font></td> <td align=center bgcolor=#585858><Font size=2 color=White><strong>Transporter</strong></font></td><td align=center bgcolor=#585858><Font size=2 color=White><strong>TruckPlacementDateTime</strong></font></td></tr>";
     string body = "";
     ds = obj_Class.TripAcceptance(Session["TripAssignID"].ToString());

     for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
     {
         body += "<tr><td align=center><font size=2>" + ds.Tables[0].Rows[i].ItemArray[0].ToString() + "</font></td><td align=center><font size=2 >" + ds.Tables[0].Rows[i].ItemArray[1].ToString() + "</font></td><td align=center><font size=2>" + ds.Tables[0].Rows[i].ItemArray[2].ToString() + "</font></td><td align=center><font size=2>" + ds.Tables[0].Rows[i].ItemArray[3].ToString() + "</font></td><td align=center><font size=2>" + ds.Tables[0].Rows[i].ItemArray[4].ToString() + "</font></td><td align=center><font size=2>" + ds.Tables[0].Rows[i].ItemArray[5].ToString() + "</font></td><td align=center><font size=2>" + ds.Tables[0].Rows[i].ItemArray[6].ToString() + "</font></td><td align=center><font size=2>" + ds.Tables[0].Rows[i].ItemArray[7].ToString() + "/ SSG PlanID:-" + ds.Tables[0].Rows[i].ItemArray[14].ToString() + "<br/>" + ds.Tables[0].Rows[i].ItemArray[10].ToString() + "/" + ds.Tables[0].Rows[i].ItemArray[11].ToString() + "</font></td><td align=center><font size=2>" + ds.Tables[0].Rows[i].ItemArray[8].ToString() + "</font></td><td align=center><font size=2>" + ds.Tables[0].Rows[i].ItemArray[9].ToString() + "</font></td><td align=center><font size=2 >" + ds.Tables[0].Rows[i].ItemArray[13].ToString() + "</font></td></tr>";

     }

     body = content + tableheader + body; 
     string body1 = body + "</table>\n<a  style='text-decoration: none; color: #FFF;background-color: #1a88b3;border: solid #1a88b3;border-width: 0px 1px;line-height: 2;font-weight: bold;text-align: center;cursor: pointer;display: inline-block;border-radius: 5px;text-transform: capitalize;'href=www.scmbizconnect.com/Loading_info.aspx?CltID=" + Session["lblClientID"] + "&CltadrID=" + Session["lblClientadrID"].ToString() + "&TransID=" + Request.QueryString["TransID"].ToString() + ">Click the Link to Enter Loading Details</a><a  style='text-decoration: none; color: #FFF;background-color: #1a88b3;border: solid #1a88b3;border-width: 0px 1px;line-height: 2;font-weight: bold;text-align: center;cursor: pointer;display: inline-block;border-radius: 5px;text-transform: capitalize;'href=www.scmbizconnect.com/Loading_info.aspx?CltID=" + Session["lblClientID"] + "&CltadrID=" + Session["lblClientadrID"].ToString() + "&TransID=" + Request.QueryString["TransID"].ToString() + ">Click the Link to Enter Loading Details</a><br/>Thank You,<br/><a href=http://www.scmbizconnect.com>www.scmbizconnect.com</a>";
  
                         
      //From EmailID
                    
                         qry = "select Emailid,password from Clients_EmailID where clientID='" + Session["lblClientID"].ToString() + " ' ";
                        cmd = new SqlCommand(qry, conn);
                        mydatareader = cmd.ExecuteReader();

                        mydatareader.Read();
                        if (mydatareader.HasRows)
                        {
                            //Mail to Thermax Client
                            if (Convert.ToInt32(Request.QueryString["ClID"].ToString()) == 1135)
                            {

                                foreach (GridViewRow row in Gridwindow.Rows)
                                {
                                    CheckBox check = (CheckBox)row.FindControl("ChkSelect");
                                    if (check.Checked)
                                    {
                                        lblIndent1 = row.FindControl("lbl_IndentID") as Label;
                                        string Indentid1 = lblIndent1.Text;
                                        qry2 = "select pm.ProjectManagerEmailID ,pm.ShippingPersonEmail , cn.CollectionNoteID ,ta.IndentID  from BizConnect_TripAssign TA inner join CollectionNote CN on ta.IndentID =cn.CollectionNoteID inner join Bizconnect_ProjectMaster PM on pm.ProjectNo =cn.ProjectNo where pm.ClientID =" + Convert.ToInt32(Request.QueryString["ClID"].ToString()) + " and ta.IndentID =" + Indentid1 + "";
                                        Command = new SqlCommand(qry2, conn);
                                        SqlDataAdapter Adapter = new SqlDataAdapter(Command);
                                        Adapter.SelectCommand.CommandType = CommandType.Text;
                                        dt_ThermaxMailIDs = new DataTable();
                                        Adapter.Fill(dt_ThermaxMailIDs);
                                        if (dt_ThermaxMailIDs.Rows.Count > 0)
                                        {
                                            PMLogpersonmails = dt_ThermaxMailIDs.Rows[0][0].ToString() + ";" + dt_ThermaxMailIDs.Rows[0][1].ToString();
                                            mail.SendEmail(PMLogpersonmails,mydatareader.GetValue(0).ToString(), mydatareader.GetValue(1).ToString(), "connect@scmjunction.com", "", "tripschedule@scmbizconnect.com", "bounceback@scmjunction.com", "Trip Confirmation -CollectionNoteNo :" + ds.Tables[0].Rows[0].ItemArray[12].ToString(), body, System.Web.Mail.MailFormat.Html, System.Web.Mail.MailPriority.High, "smtp.gmail.com", "465", "2", "1", true, "");
                                        }
                                    }
                                }

                            }
                            else if (Convert.ToInt32(Request.QueryString["ClID"].ToString()) == 1440)
                            {
                                //Mail To Client
                                string myccmail = "geethamiisky@gmail.com,connect@scmjunction.com";
                                mail.SendEmail(Session["ClientEmail"].ToString(), mydatareader.GetValue(0).ToString(), mydatareader.GetValue(1).ToString(), myccmail, "", "tripschedule@scmbizconnect.com", "bounceback@scmjunction.com", "Trip Confirmation -CollectionNoteNo :" + ds.Tables[0].Rows[0].ItemArray[12].ToString(), body1, System.Web.Mail.MailFormat.Html, System.Web.Mail.MailPriority.High, "smtp.gmail.com", "465", "2", "1", true, "");
                            }
                            else if (Convert.ToInt32(Request.QueryString["ClID"].ToString()) == 1132)
                            {
                                //Mail To Client
                                string myccmail = "geethamiisky@gmail.com,connect@scmjunction.com,canoop@godrej.com,vkarthi@godrej.com,asu@godrej.com,vijayakrishna@scmjunction.com";
                                mail.SendEmail(Session["ClientEmail"].ToString(), mydatareader.GetValue(0).ToString(), mydatareader.GetValue(1).ToString(), myccmail, "", "tripschedule@scmbizconnect.com", "bounceback@scmjunction.com", "Trip Confirmation -CollectionNoteNo :" + ds.Tables[0].Rows[0].ItemArray[12].ToString(), body1, System.Web.Mail.MailFormat.Html, System.Web.Mail.MailPriority.High, "smtp.gmail.com", "465", "2", "1", true, "");
                            }
                            else
                            {
                                mail.SendEmail(Session["ClientEmail"].ToString(), mydatareader.GetValue(0).ToString(), mydatareader.GetValue(1).ToString(), "connect@scmjunction.com", "", "tripschedule@scmbizconnect.com", "bounceback@scmjunction.com", "Trip Confirmation -CollectionNoteNo :" + ds.Tables[0].Rows[0].ItemArray[12].ToString(), body1, System.Web.Mail.MailFormat.Html, System.Web.Mail.MailPriority.High, "smtp.gmail.com", "465", "2", "1", true, "");
                            }
     //Mail To Transporter
     
     mail.SendEmail(Session["TransporterEmail"].ToString(),  mydatareader.GetValue(0).ToString(), mydatareader.GetValue(1).ToString(), "vijayakrishna@scmjunction.com", "", "tripschedule@scmbizconnect.com", "bounceback@scmjunction.com", "Trip Confirmation -CollectionNoteNo :" + ds.Tables[0].Rows[0].ItemArray[12].ToString(), body, System.Web.Mail.MailFormat.Html, System.Web.Mail.MailPriority.High, "smtp.gmail.com", "465", "2", "1", true, "");
        // mail.SendEmail("vijayakrishna@scmjunction.com", "maricotripschedule@scmbizconnect.com", "tripschedule", "", "", "maricotripschedule@scmbizconnect.com", "bounceback@scmjunction.com", "Trip Confirmation", body, System.Web.Mail.MailFormat.Html, System.Web.Mail.MailPriority.High, "smtp.gmail.com", "465", "2", "1", true, "");            
     }

else
{
     
      //Mail To Client
    if (Convert.ToInt32(Request.QueryString["ClID"].ToString()) == 1440)
    {
        //Mail To Client //manasa
        string myccmail = "geethamiisky@gmail.com,connect@scmjunction.com";
        mail.SendEmail(Session["ClientEmail"].ToString(), "tripschedule@scmbizconnect.com", "tripschedule123", myccmail, "", "tripschedule@scmbizconnect.com", "bounceback@scmjunction.com", "Trip Confirmation -CollectionNoteNo :" + ds.Tables[0].Rows[0].ItemArray[12].ToString(), body, System.Web.Mail.MailFormat.Html, System.Web.Mail.MailPriority.High, "smtp.gmail.com", "465", "2", "1", true, "");
    }
    else if (Convert.ToInt32(Request.QueryString["ClID"].ToString()) == 1132)
    {
        //Mail To Client //godrej
        string myccmail = "geethamiisky@gmail.com,connect@scmjunction.com,canoop@godrej.com,vkarthi@godrej.com,asu@godrej.com,vijayakrishna@scmjunction.com";
        mail.SendEmail(Session["ClientEmail"].ToString(), "tripschedule@scmbizconnect.com", "tripschedule123", myccmail, "", "tripschedule@scmbizconnect.com", "bounceback@scmjunction.com", "Trip Confirmation -CollectionNoteNo :" + ds.Tables[0].Rows[0].ItemArray[12].ToString(), body, System.Web.Mail.MailFormat.Html, System.Web.Mail.MailPriority.High, "smtp.gmail.com", "465", "2", "1", true, "");
    }

    else
    {
        mail.SendEmail(Session["ClientEmail"].ToString(), "tripschedule@scmbizconnect.com", "tripschedule123", "connect@scmjunction.com", "", "tripschedule@scmbizconnect.com", "bounceback@scmjunction.com", "Trip Confirmation -CollectionNoteNo :" + ds.Tables[0].Rows[0].ItemArray[12].ToString(), body, System.Web.Mail.MailFormat.Html, System.Web.Mail.MailPriority.High, "smtp.gmail.com", "465", "2", "1", true, "");
    }
    
     //Mail To Transporter
     
     mail.SendEmail(Session["TransporterEmail"].ToString(), "tripschedule@scmbizconnect.com", "tripschedule123", "vinaysingh@scmjunction.com", "", "tripschedule@scmbizconnect.com", "bounceback@scmjunction.com", "Trip Confirmation -CollectionNoteNo :" + ds.Tables[0].Rows[0].ItemArray[12].ToString(), body1, System.Web.Mail.MailFormat.Html, System.Web.Mail.MailPriority.High, "smtp.gmail.com", "465", "2", "1", true, "");
  
   }
   
    // mail.SendEmail("connect@scmjunction.com", "tripschedule@scmbizconnect.com", "tripschedule123", "g.jagan@aarmscmsolutions.com", "", "tripschedule@scmbizconnect.com", "bounceback@scmjunction.com", "Trip Confirmation", body, System.Web.Mail.MailFormat.Html, System.Web.Mail.MailPriority.High, "smtp.gmail.com", "465", "2", "1", true, "");
    // mail.SendEmail("nandha@aarmscmsolutions.com", "tripschedule@scmbizconnect.com", "tripschedule123", "", "", "tripschedule@scmbizconnect.com", "bounceback@scmjunction.com", "Trip Confirmation", body, System.Web.Mail.MailFormat.Html, System.Web.Mail.MailPriority.High, "smtp.gmail.com", "465", "2", "1", true, "");
     Session["ClientEmail"] = "";
     Session["TransporterEmail"] = "";
Session["TripAssignID"] = "0";
    }



 protected void Gridwindow_RowDataBound(object sender, GridViewRowEventArgs e)
 {
      if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblStatus = (Label)e.Row.FindControl("lblStatus");
            Label lblClientEmail = (Label)e.Row.FindControl("lblCEmail");
            Label lblTransporterEmail = (Label)e.Row.FindControl("lblTEmail");
            HyperLink lnkIndent = (HyperLink)e.Row.FindControl("lnkIndent");
            CheckBox check = (CheckBox)e.Row.FindControl("ChkSelect");
            Session["ClientEmail"] = lblClientEmail.Text;
            Session["TransporterEmail"] = lblTransporterEmail.Text;

            TextBox VehiclePlacementTime = (TextBox)e.Row.FindControl("txtTripTime");


            VehiclePlacementTime.Text = DateTime.Now.ToString("dd/MM/yyyy hh:mm tt");
            
             if (Convert.ToInt32(Request.QueryString["ClID"].ToString()) == 1135)
            {
                lnkIndent.Visible = true;
            }
            else
            {
                lnkIndent.Visible = false;
            }

            if (lblStatus.Text == "Already Confirmed")
            {
                check.Enabled = false;
                lblStatus.ForeColor = System.Drawing.Color.Green;
            }

        }
    }

 }



