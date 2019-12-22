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
using System.Net;
using System.IO;

public partial class TripRequestAssignment : System.Web.UI.Page
{
    string obj_Authenticated;
    PlaceHolder maPlaceHolder;
    UserControl obj_Tabs;
    UserControl obj_LoginCtrl;
    UserControl obj_WelcomCtrl;
    UserControl obj_Navi;
    UserControl obj_Navihome;
    TripAssignment Trip_Assign = new TripAssignment();
    BizConnectClass obj_class = new BizConnectClass();
    TripAcceptance obj_class1 = new TripAcceptance();
    DataSet ds;
    DataTable dt = new DataTable();
    string body = "";
    string mailbody = "<pre>Dear Sir,<br/><br/>Please arrange to place the vehicles as per below Schedule.  Please confirm with all the particulars of vehicle immediately.";
    string Email = "";
    string Transid = "0";
    AARMEmail.EmailControl mail = new AARMEmail.EmailControl();
    string Conn = ConfigurationManager.ConnectionStrings["BizCon"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ChkAuthentication();
            FillProject();
            Bizconnect_LoadTrucksRequirement();
        }
    }

    public void Bizconnect_LoadTrucksRequirement()
    {
        dt = Trip_Assign.Bizconnect_LoadTrucksRequirement(Convert.ToInt32(Session["ClientID"]));
        grd_TrucksRequired.DataSource = dt;
        grd_TrucksRequired.DataBind();
    }

    public void FillProject()
    {
        DataSet ds = new DataSet();
        ds = Trip_Assign.FillProject(Convert.ToInt32(Session["ClientID"].ToString()));
        if (ds.Tables[0].Rows.Count > 0)
        {
            DrpProject.DataSource = ds;
            DrpProject.DataTextField = "ProjectName";
            DrpProject.DataValueField = "ProjectID";
            DrpProject.DataBind();
        }
        else
        {
            DrpProject.Items.Add("No Project");
            DrpProject.Items[0].Value = "1";
            DrpProject.DataBind();
        }
    }


    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        DateTime dtt = new DateTime();
        dtt = Calendar1.SelectedDate.Date;
        txtDate.Text = dtt.ToString("dd-MMM-yyyy");
        ButAssign.Enabled = true;
        lblmsg.Visible = false;
        DataTable dt = new DataTable();
        dt = Trip_Assign.Bizconnect_TripRequestAssignment(Convert.ToInt32(Session["ClientID"].ToString()), Convert.ToDateTime(txtDate.Text));
        Gridwindow.DataSource = dt;
        Gridwindow.DataBind();


    }
    protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
    {

        if (e.Day.Date < DateTime.Now.Date)
        {

            e.Day.IsSelectable = false;

            e.Cell.ForeColor = System.Drawing.Color.Gray;

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
    protected void ButAssign_Click(object sender, EventArgs e)
    {
        try
        {
            SqlConnection conn = new SqlConnection();
            SqlCommand cmd;
            conn.ConnectionString = Conn;
            conn.Open();
            SqlDataReader mydatareader;
            string qry;


            Session["AgreementID"] = "0";
            string tableheader = "";
            String cc = "";
            //Insert into Tripassign table
            for (int j = 0; j <= Gridwindow.Rows.Count - 1; j++)
            {
                CheckBox check = (CheckBox)Gridwindow.Rows[j].FindControl("ChkSelect");
                if (check.Checked)
                {
                    Label lblplanID = (Label)Gridwindow.Rows[j].FindControl("lblplanID");
                    Label lblFrom = (Label)Gridwindow.Rows[j].FindControl("lblFromLoc");
                    Label lblTo = (Label)Gridwindow.Rows[j].FindControl("lbltoloc");
                    Label lblTruckType = (Label)Gridwindow.Rows[j].FindControl("lblTrucktype");
                    Label lblEnclType = (Label)Gridwindow.Rows[j].FindControl("lblEncltype");
                    Label lblCapacity = (Label)Gridwindow.Rows[j].FindControl("lblcapacity");
                    Label lblprice = (Label)Gridwindow.Rows[j].FindControl("lblDecidePrice");
                    TextBox txttruckreq = (TextBox)Gridwindow.Rows[j].FindControl("txtTruckreq");
                    TextBox txttime = (TextBox)Gridwindow.Rows[j].FindControl("txttime");
                    Label lblTransporterID = (Label)Gridwindow.Rows[j].FindControl("lblTransID");
                    Label LogPlanID = (Label)Gridwindow.Rows[j].FindControl("lblLogPlanID");
                    Label lblMobile = (Label)Gridwindow.Rows[j].FindControl("lblMobile");
                    for (int k = 0; k < Convert.ToInt16(txttruckreq.Text); k++)
                    {
                        Trip_Assign.Bizconnect_InsertTripAssign(Convert.ToInt32(lblplanID.Text), lblFrom.Text, lblTo.Text, lblTruckType.Text, lblEnclType.Text, lblCapacity.Text, Convert.ToInt32(lblprice.Text), Convert.ToInt32(lblTransporterID.Text), Convert.ToInt32(txttruckreq.Text), Convert.ToDateTime(txtDate.Text), txttime.Text, Convert.ToInt32(Session["UserID"].ToString()), Convert.ToInt32(LogPlanID.Text));
                    }
                    //SMS  ALERT
                    sendsms(lblFrom.Text, lblTo.Text, lblTruckType.Text, lblCapacity.Text, lblMobile.Text);
                }
            }

            //Email Portion
            DataSet dsce = new DataSet();
            tableheader = "<table bgcolor=White bordercolor=#003366 border=1 style=width: 650px ><tr><td align=center><b>Trip Summary</b></td></tr><tr><td align=center bgcolor=#585858><Font size=2 color=White><strong>From</strong></font></td><td align=center bgcolor=#585858><Font size=2 color=White><strong>To</strong></font></td><td align=center bgcolor=#585858><Font size=2 color=White><strong>TruckType</strong></font></td><td align=center bgcolor=#585858><Font size=2 color=White><strong>Encl.Type</strong></font></td><td align=center bgcolor=#585858><Font size=2 color=White><strong>Capacity</strong></font></td><td align=center bgcolor=#585858><Font size=2 color=White><strong>NoofTrucksReq.</strong></font></td><td align=center bgcolor=#585858><Font size=2 color=White><strong>Time</strong></font></td><td align=center bgcolor=#585858><Font size=2 color=White><strong>TravelDate</strong></font></td> <td align=center bgcolor=#585858><Font size=2 color=White><strong>ClientName</strong></font></td> </tr>";

            for (int j = 0; j <= Gridwindow.Rows.Count - 1; j++)
            {
                CheckBox check = (CheckBox)Gridwindow.Rows[j].FindControl("ChkSelect");
                if (check.Checked)
                {
                    Label lblplanID = (Label)Gridwindow.Rows[j].FindControl("lblplanID");
                    Label lblEmail = (Label)Gridwindow.Rows[j].FindControl("lblEmail");
                    Label lblTransid = (Label)Gridwindow.Rows[j].FindControl("lblTransID");
                    Transid = lblTransid.Text;
                    Session["AgreementID"] = Session["AgreementID"] + "," + lblplanID.Text;
                    if ((Email.ToString() != "" && Email.ToString() != lblEmail.Text))
                    {


                        Label lblTransid1 = (Label)Gridwindow.Rows[j - 1].FindControl("lblTransID");
                        DataSet dsc = new DataSet();
                        dsc = obj_class.get_CCsByRID(Convert.ToInt32(lblTransid1.Text));
                        if (dsc.Tables[0].Rows.Count > 0)
                        {
                            for (int i = 0; i <= dsc.Tables[0].Rows.Count - 1; i++)
                            {

                                cc = dsc.Tables[0].Rows[i].ItemArray[1].ToString() + "," + cc;
                            }
                        }
                        cc = cc.TrimEnd(',');
                        //-------------------------CC To Client-----------------------------------------------

                        dsce = obj_class1.get_EmailIDCCstoClient(Convert.ToInt32(Session["ClientID"].ToString()));
                        cc = cc + "," + dsce.Tables[0].Rows[0].ItemArray[0].ToString();
                        //----------------------------------------------------------------------

                        body = mailbody + tableheader + body + "</table>" + "<a href=http://www.scmbizconnect.com/TripAcceptance.aspx?TransID=" + lblTransid1.Text + "&ClID=" + Session["ClientID"].ToString() + "&agID=" + Session["AgreementID"] + ">Click Here to Confirm the Routes</a><br/><br/>Best Regards<br/><br/><br/>SCMBizconnect Team.";

                        //From EmailID

                        qry = "select Emailid,password from Bizconnect.dbo.Clients_EmailID where clientID='" + Session["ClientID"].ToString() + " ' ";
                        cmd = new SqlCommand(qry, conn);
                        mydatareader = cmd.ExecuteReader();

                        mydatareader.Read();
                        if (mydatareader.HasRows)
                        {

                            mail.SendEmail(Email.ToString(), mydatareader.GetValue(0).ToString(), mydatareader.GetValue(1).ToString(), cc, "shashidhar@aarmsvaluechain.com", "tripschedule@scmbizconnect.com", "bounceback@scmjunction.com", "Placement of Vehicle", body, System.Web.Mail.MailFormat.Html, System.Web.Mail.MailPriority.High, "smtp.gmail.com", "465", "2", "1", true, "");


                        }

                        else
                        {

                            mail.SendEmail(Email.ToString(), "tripschedule@scmbizconnect.com", "tripschedule123", cc, "shashidhar@aarmsvaluechain.com", "tripschedule@scmbizconnect.com", "bounceback@scmjunction.com", "Placement of Vehicle", body, System.Web.Mail.MailFormat.Html, System.Web.Mail.MailPriority.High, "smtp.gmail.com", "465", "2", "1", true, "");
                        }


                        cc = "";
                        //demo
                        // mail.SendEmail("tripschedule@scmbizconnect.com", "tripschedule@scmbizconnect.com", "tripschedule123", "g.jagan@aarmscmsolutions.com", "", "tripschedule@scmbizconnect.com", "bounceback@scmjunction.com", "Placement of Vehicle", body, System.Web.Mail.MailFormat.Html, System.Web.Mail.MailPriority.High, "smtp.gmail.com", "465", "2", "1", true, "");

                        j -= 1;
                        Email = "";
                        body = "";
                        Session["AgreementID"] = "";
                    }

                    else
                    {

                        ComposeMail(j);

                    }

                }
            }

            ButAssign.Enabled = false;
            DataSet dsc1 = new DataSet();
            dsc1 = obj_class.get_CCsByRID(Convert.ToInt32(Transid.ToString()));
            if (dsc1.Tables[0].Rows.Count > 0)
            {
                for (int j = 0; j <= dsc1.Tables[0].Rows.Count - 1; j++)
                {

                    cc = dsc1.Tables[0].Rows[j].ItemArray[1].ToString() + "," + cc;
                }
            }
            cc = cc.TrimEnd(',');

            //-------------------------CC To Client-----------------------------------------------

            dsce = obj_class1.get_EmailIDCCstoClient(Convert.ToInt32(Session["ClientID"].ToString()));
            cc = cc + "," + dsce.Tables[0].Rows[0].ItemArray[0].ToString();
            cc = cc.Replace(';', ',');

            //----------------------------------------------------------------------
            body = mailbody + tableheader + body + "</table>" + "<a href=http://www.scmbizconnect.com/TripAcceptance.aspx?TransID=" + Transid.ToString() + "&ClID=" + Session["ClientID"].ToString() + "&agID=" + Session["AgreementID"] + ">Click Here to Confirm the Routes</a><br/><br/>Best Regards<br/><br/><br/>SCMBizconnect Team.";

            //From EmailID

            qry = "select Emailid,password from Bizconnect.dbo.Clients_EmailID where clientID='" + Session["ClientID"].ToString() + " ' ";
            cmd = new SqlCommand(qry, conn);
            mydatareader = cmd.ExecuteReader();

            mydatareader.Read();
            if (mydatareader.HasRows)
            {

                //   int resm = mail.SendEmail(Email.ToString(), mydatareader.GetValue(0).ToString(), mydatareader.GetValue(1).ToString(), cc, "g.jagan@aarmscmsolutions.com,shashidhar@aarmsvaluechain.com", "tripschedule@scmbizconnect.com", "bounceback@scmjunction.com", "Placement of Vehicle", body, System.Web.Mail.MailFormat.Html, System.Web.Mail.MailPriority.High, "smtp.gmail.com", "465", "2", "1", true, "");
                try
                {
                    //Create Mail Message Object with content that you want to send with mail.
                    System.Net.Mail.MailMessage MyMailMessage = new System.Net.Mail.MailMessage(mydatareader.GetValue(0).ToString(), Email.ToString(), "Placement of Vehicle", body);
                    //CC
                    //  MyMailMessage.CC.Add(cc);
                    MyMailMessage.Bcc.Add("shashidhar@aarmsvaluechain.com");
                    MyMailMessage.IsBodyHtml = true;

                    //Proper Authentication Details need to be passed when sending email from gmail
                    System.Net.NetworkCredential mailAuthentication = new System.Net.NetworkCredential(mydatareader.GetValue(0).ToString(), mydatareader.GetValue(1).ToString());

                    //Smtp Mail server of Gmail is "smpt.gmail.com" and it uses port no. 587
                    //For different server like yahoo this details changes and you can
                    //get it from respective server.
                    System.Net.Mail.SmtpClient mailClient = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587);

                    //Enable SSL

                    mailClient.EnableSsl = true;

                    mailClient.UseDefaultCredentials = false;

                    mailClient.Credentials = mailAuthentication;

                    mailClient.Send(MyMailMessage);
                    string msz = "Email sent successfully";
                    Session["AgreementID"] = "";

                    Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "alert('" + msz + "')", true);
                }
                catch (Exception ex)
                {



                }

            }

            else
            {

                //  mail.SendEmail(Email.ToString(), "tripschedule@scmbizconnect.com", "tripschedule123",cc, "g.jagan@aarmscmsolutions.com,vinaysingh@scmjunction.com",  "tripschedule@scmbizconnect.com", "bounceback@scmjunction.com", "Placement of Vehicle", body, System.Web.Mail.MailFormat.Html, System.Web.Mail.MailPriority.High, "smtp.gmail.com", "465", "2", "1", true, "");
                try
                {
                    //Create Mail Message Object with content that you want to send with mail.
                    System.Net.Mail.MailMessage MyMailMessage = new System.Net.Mail.MailMessage("tripschedule@scmbizconnect.com", Email.ToString(), "Placement of Vehicle", body);
                    //CC
                    //MyMailMessage.CC.Add(cc);
                    //MyMailMessage.BCC.Add("g.jagan@aarmscmsolutions.com");
                    MyMailMessage.IsBodyHtml = true;

                    //Proper Authentication Details need to be passed when sending email from gmail
                    System.Net.NetworkCredential mailAuthentication = new System.Net.NetworkCredential("tripschedule@scmbizconnect.com", "tripschedule123");

                    //Smtp Mail server of Gmail is "smpt.gmail.com" and it uses port no. 587
                    //For different server like yahoo this details changes and you can
                    //get it from respective server.
                    System.Net.Mail.SmtpClient mailClient = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587);

                    //Enable SSL

                    mailClient.EnableSsl = true;

                    mailClient.UseDefaultCredentials = false;

                    mailClient.Credentials = mailAuthentication;

                    mailClient.Send(MyMailMessage);
                    string msz = "Email sent successfully";
                    Session["AgreementID"] = "";

                    Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "alert('" + msz + "')", true);
                }
                catch (Exception ex)
                {



                }

            }
            //demo
            //	 mail.SendEmail("tripschedule@scmbizconnect.com", "tripschedule@scmbizconnect.com", "tripschedule123", "g.jagan@aarmscmsolutions.com", "", "tripschedule@scmbizconnect.com", "bounceback@scmjunction.com", "Placement of Vehicle", body, System.Web.Mail.MailFormat.Html, System.Web.Mail.MailPriority.High, "smtp.gmail.com", "465", "2", "1", true, "");

            Email = "";
            body = "";
            cc = "";
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Trip Assigned Successfully');</script>");
            // lblmsg.Visible = true;
        }
        catch (Exception ex)
        {
        }
    }

    public void ComposeMail(int j)
    {
        Label lblEmail = (Label)Gridwindow.Rows[j].FindControl("lblEmail");
        Label lblFrom = (Label)Gridwindow.Rows[j].FindControl("lblFromLoc");
        Label lblTo = (Label)Gridwindow.Rows[j].FindControl("lbltoloc");
        Label lblTruckType = (Label)Gridwindow.Rows[j].FindControl("lblTrucktype");
        Label lblEncltype = (Label)Gridwindow.Rows[j].FindControl("lblEncltype");
        Label lblCapacity = (Label)Gridwindow.Rows[j].FindControl("lblcapacity");
        TextBox txtnooftruks = (TextBox)Gridwindow.Rows[j].FindControl("txtTruckreq");
        TextBox txttime = (TextBox)Gridwindow.Rows[j].FindControl("txttime");
        Email = lblEmail.Text;

        body += "<tr><td align=center><font size=2>" + lblFrom.Text + "</font></td><td align=center><font size=2 >" + lblTo.Text + "</font></td><td align=center><font size=2>" + lblTruckType.Text + "</font></td><td align=center><font size=2>" + lblEncltype.Text + "</font></td><td align=center><font size=2>" + lblCapacity.Text + "</font></td><td align=center><font size=2>" + txtnooftruks.Text + "</font></td><td align=center><font size=2>" + txttime.Text + "</font></td><td align=center><font size=2>" + txtDate.Text + "</font></td>  <td align=center><font size=2>" + Session["ClientName"].ToString() + "</font></td></tr>";
    }

    public void sendsms(string frm, string to, string truck, string capacity, string mobile)
    {
        try
        {
            string mobile1 = mobile.ToString();
            string message1 = "Trip Assigned for " + frm + " to " + to + " " + truck + " " + capacity + " ton";
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

    protected void ChkSelect_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox b = (CheckBox)sender;
        GridViewRow row = (GridViewRow)b.NamingContainer;
        if (row != null)
        {
            TextBox Trucks = (TextBox)Gridwindow.Rows[row.RowIndex].FindControl("txtTruckreq");
            TextBox Time = (TextBox)Gridwindow.Rows[row.RowIndex].FindControl("txttime");
            if (b.Checked)
            {
                Trucks.Text = "";
                Time.Text = "";
                Trucks.Enabled = true;
                Time.Enabled = true;
            }
            else
            {
                Trucks.Text = "";
                Time.Text = "";
                Trucks.Enabled = false;
                Time.Enabled = false;
            }
        }
    }
}