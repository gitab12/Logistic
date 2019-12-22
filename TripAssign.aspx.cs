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
using System.Data.SqlClient ;
using System.Net;
using System.IO;
using System.Data.OleDb;
public partial class TripAssign : System.Web.UI.Page
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
    TripAcceptance obj_class2 = new TripAcceptance();
    BizCon_DB_ConnectionString con = new BizCon_DB_ConnectionString();
    DataSet ds;
    DataTable dt = new DataTable();
    string body = "";
    string mailbody = "<center><img  src=http://www.scmbizconnect.com/images/logo.jpg /></center><br /><pre>Dear Sir,<br/><br/>Please arrange to place the vehicles as per below Schedule.  Please confirm with all the particulars of vehicle immediately.";
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
            btn_assignparcel.Visible = false;
            ButAssign.Visible = true;
            Bizconnect_LoadTrucksRequirement();
            txt_source.Visible = false;
            txt_destination.Visible = false;
            txt_transporter.Visible = false;
            txt_trucktype.Visible = false;

			
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
        btn_assignparcel.Visible = false;
        lblmsg.Visible = false;
        DataSet ds = new DataSet();
        ds = Trip_Assign.Bizconnect_TruckAssign(Convert.ToInt32(Session["ClientID"].ToString()));
        txt_source.Visible = true;
        txt_destination.Visible = true;
        txt_transporter.Visible = true;
        txt_trucktype.Visible = true;
        Gridwindow.DataSource = ds;
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
                    TextBox Remarks = (TextBox)Gridwindow.Rows[j].FindControl("txtremarks");
                    Label lblTransporterID = (Label)Gridwindow.Rows[j].FindControl("lblTransID");
                    Label lblMobile = (Label)Gridwindow.Rows[j].FindControl("lblMobile");
				    for (int k = 0; k < Convert.ToInt16(txttruckreq.Text); k++)
				    {
                   Trip_Assign.Bizconnect_InsertTripAssign(Convert.ToInt32(lblplanID.Text), lblFrom.Text, lblTo.Text, lblTruckType.Text, lblEnclType.Text, lblCapacity.Text, Convert.ToInt32(lblprice.Text), Convert.ToInt32(lblTransporterID.Text), Convert.ToInt32(txttruckreq.Text), Convert.ToDateTime(txtDate.Text), txttime.Text, Convert.ToInt32(Session["UserID"].ToString()),Remarks.Text);
				     }
                    //SMS  ALERT
                    sendsms(lblFrom.Text, lblTo.Text, lblTruckType.Text, lblCapacity.Text, lblMobile.Text);
                }

               

            }

            //Email Portion
             DataSet dsce = new DataSet();
             tableheader = "<table bgcolor=White bordercolor=#003366 border=1 style=width: 650px ><tr><td align=center><b>Trip Summary</b></td></tr><tr><td align=center bgcolor=#585858><Font size=2 color=White><strong>From</strong></font></td><td align=center bgcolor=#585858><Font size=2 color=White><strong>To</strong></font></td><td align=center bgcolor=#585858><Font size=2 color=White><strong>TruckType</strong></font></td><td align=center bgcolor=#585858><Font size=2 color=White><strong>Encl.Type</strong></font></td><td align=center bgcolor=#585858><Font size=2 color=White><strong>Capacity</strong></font></td><td align=center bgcolor=#585858><Font size=2 color=White><strong>NoofTrucksReq.</strong></font></td><td align=center bgcolor=#585858><Font size=2 color=White><strong>Time</strong></font></td><td align=center bgcolor=#585858><Font size=2 color=White><strong>TravelDate</strong></font></td> <td align=center bgcolor=#585858><Font size=2 color=White><strong>Remarks</strong></font></td><td align=center bgcolor=#585858><Font size=2 color=White><strong>ClientName</strong></font></td> </tr>";

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

                  //  dsce = obj_class2.get_EmailIDCCstoClient(Convert.ToInt32(Session["ClientID"].ToString()));
         //  cc =cc+","+dsce.Tables[0].Rows[0].ItemArray[0].ToString();
        //----------------------------------------------------------------------
                    
                        body = mailbody + tableheader + body + "</table>" + "<a href=http://www.scmbizconnect.com/TripAcceptance.aspx?TransID=" + lblTransid1.Text + "&ClID="+ Session["ClientID"].ToString() +"&agID=" + Session["AgreementID"] + ">Click Here to Confirm the Routes</a><br/><br/>Best Regards<br/><br/><br/>SCMBizconnect Team.";
                       
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
                       
                       
						cc="";
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

            ButAssign.Enabled = true;
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

                   // dsce = obj_class2.get_EmailIDCCstoClient(Convert.ToInt32(Session["ClientID"].ToString()));
     //  cc =cc+","+dsce.Tables[0].Rows[0].ItemArray[0].ToString();
   //cc=cc.Replace(';',',');
           
        //----------------------------------------------------------------------
            body = mailbody + tableheader + body + "</table>" + "<a href=http://www.scmbizconnect.com/TripAcceptance.aspx?TransID=" + Transid.ToString() + "&ClID="+ Session["ClientID"].ToString() +"&agID=" + Session["AgreementID"] + ">Click Here to Confirm the Routes</a><br/><br/>Best Regards<br/><br/><br/>SCMBizconnect Team.";
      
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
                                   System.Net.Mail.MailMessage MyMailMessage = new System.Net.Mail.MailMessage(mydatareader.GetValue(0).ToString(),Email.ToString(), "Placement of Vehicle", body);
									//CC
                                 //  MyMailMessage.CC.Add(cc);
                                   MyMailMessage.Bcc.Add("shashidhar@aarmsvaluechain.com");
                                   MyMailMessage.IsBodyHtml = true;

                                    //Proper Authentication Details need to be passed when sending email from gmail
                                  System.Net.NetworkCredential mailAuthentication = new System.Net.NetworkCredential(mydatareader.GetValue(0).ToString(),mydatareader.GetValue(1).ToString());

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
		MyMailMessage.Bcc.Add("shashidhar@aarmsvaluechain.com");
        MyMailMessage.IsBodyHtml = true;

        //Proper Authentication Details need to be passed when sending email from gmail
        System.Net.NetworkCredential mailAuthentication = new System.Net.NetworkCredential("tripschedule@scmbizconnect.com","tripschedule123");

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
            cc="";
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
        TextBox Remarks = (TextBox)Gridwindow.Rows[j].FindControl("txtremarks");
        string remarks = Remarks.Text;
        Email = lblEmail.Text;

        body += "<tr><td align=center><font size=2>" + lblFrom.Text + "</font></td><td align=center><font size=2 >" + lblTo.Text + "</font></td><td align=center><font size=2>" + lblTruckType.Text + "</font></td><td align=center><font size=2>" + lblEncltype.Text + "</font></td><td align=center><font size=2>" + lblCapacity.Text + "</font></td><td align=center><font size=2>" + txtnooftruks.Text + "</font></td><td align=center><font size=2>" + txttime.Text + "</font></td><td align=center><font size=2>" + txtDate.Text + "</font></td><td align=center><font size=2>" + remarks + "</font></td>  <td align=center><font size=2>" + Session["ClientName"].ToString() + "</font></td></tr>";
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
            TextBox Remarks = (TextBox)Gridwindow.Rows[row.RowIndex].FindControl("txtremarks");
            if (b.Checked)
            {
                Trucks.Text = "";
                Time.Text = "";
                Remarks.Text = "";
                Trucks.Enabled = true;
                Time.Enabled = true;
                Remarks.Enabled = true;

            }
            else
            {
                Trucks.Text = "";
                Time.Text = "";
                Remarks.Text = "";
                Trucks.Enabled = false;
                Time.Enabled = false;
                Remarks.Enabled = false;
            }
        }
    }
    protected void txt_source_TextChanged1(object sender, EventArgs e)
    {
        try
        {
            string text = txt_source.Text;
            string clientid = Session["ClientID"].ToString();

            if (clientid != "")
            {
                string[] args = { "@clientid", "@fromlocation" };
                string[] argsval = { clientid, "%" + text + "%" };

                DataSet ds = new DataSet();
                ds = con.Sql_GetData("SP_Get_Source", args, argsval);
                if (ds.Tables[0].Rows.Count > 0)
                {
					 ButAssign.Enabled = true;
                    Gridwindow.DataSource = ds;
                    Gridwindow.DataBind();
                    Gridwindow.Visible = true;
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('No Date Found!!');</script>");
                    Gridwindow.Visible = false;
                }


            }
            else
            {
                Response.Redirect("Index.html");
            }

        }

        catch (Exception ex)
        {

        }
        finally
        {

        }
    }
    protected void txt_destination_TextChanged(object sender, EventArgs e)
    {
        try
        {
            string tolocation = txt_destination.Text;
            string cid = Session["ClientID"].ToString();
            if (cid != "")
            {
                string[] args1 = { "@clientid", "@tolocation" };
                string[] argsval = { cid, "%"+tolocation+ "%" };
                DataSet ds = new DataSet();
                ds = con.Sql_GetData("SP_Get_ToLocation", args1, argsval);
                if (ds.Tables[0].Rows.Count > 0)
                {
					 ButAssign.Enabled = true;
                    Gridwindow.DataSource = ds;
                    Gridwindow.DataBind();
                    Gridwindow.Visible = true;
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('No Date Found!!');</script>");
                    Gridwindow.Visible = false;
                }
            }
            else
            {
                Response.Redirect("Index.html");
            }


        }
        catch (Exception ex)
        {


        }
        finally
        {


        }
    }
    protected void txt_transporter_TextChanged(object sender, EventArgs e)
    {
        try
        {
            string cid = Session["ClientID"].ToString();
            string transporter = txt_transporter.Text;
            if (cid != "")
            {
                string[] args2 = { "@clientid", "@transporter" };
                string[] argsval2 = { cid, "%"+transporter+"%" };
                DataSet ds = new DataSet();
                ds = con.Sql_GetData("SP_Get_Transporter", args2, argsval2);
                if (ds.Tables[0].Rows.Count > 0)
                {
					 ButAssign.Enabled = true;
                    Gridwindow.DataSource = ds;
                    Gridwindow.DataBind();
                    Gridwindow.Visible = true;
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('No Date Found!!');</script>");
                    Gridwindow.Visible = false;
                }
            }
            else
            {
                Response.Redirect("Index.html");
            }
        }
        catch (Exception ex)
        {


        }
        finally
        {

        }
    }
    protected void txt_trucktype_TextChanged(object sender, EventArgs e)
    {
        try
        {
            string cid = Session["ClientID"].ToString();
            string trucktype = txt_trucktype.Text;
            if (cid != "")
            {
                string[] args = { "@clientid", "@trucktype" };
                string[] argsval = { cid, "%" + trucktype +"%" };

                DataSet ds = new DataSet();
                ds = con.Sql_GetData("SP_Get_TruckType_New", args, argsval);
                if (ds.Tables[0].Rows.Count > 0)
                {
					ButAssign.Enabled = true;
                    Gridwindow.DataSource = ds;
                    Gridwindow.DataBind();
                    Gridwindow.Visible = true;
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('No Date Found!!');</script>");
                    Gridwindow.Visible = false;
                }
            }

            else
            {
                Response.Redirect("Index.html");
            }
        }

        catch
        {

        }

        finally
        {

        }
    }
    protected void rdb_ftl_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            ButAssign.Visible = true;
            btn_assignparcel.Visible = false;
            DataSet ds = new DataSet();
            ds = Trip_Assign.Bizconnect_TruckAssign(Convert.ToInt32(Session["ClientID"].ToString()));
            if (ds.Tables[0].Rows.Count > 0)
            {
                grid_parcel.Visible = false;
                Gridwindow.Visible = true;
                Gridwindow.DataSource = ds;
                Gridwindow.DataBind();
            }
            else
            {
                grid_parcel.Visible = false;
            }

        }
        catch (Exception ex)
        {

        }
    }
    protected void rdb_parcel_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            btn_assignparcel.Enabled = true;
            btn_assignparcel.Visible = true;
            ButAssign.Visible = false;
            string cid = Session["ClientID"].ToString();
            if (cid != "")
            {
                string[] args = { "@clientid" };
                string[] argsval = { cid };
                DataSet ds = new DataSet();
                ds = con.Sql_GetData("Bizconnect_TruckAssignment_Parcel", args, argsval);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Gridwindow.Visible = false;
                    grid_parcel.Visible = true;
                    grid_parcel.DataSource = ds;
                    grid_parcel.DataBind();
                }
                else
                {
                    Gridwindow.Visible = false;
                }

            }
            else
            {
                Response.Redirect("Index.html");
            }
        }
        catch (Exception ex)
        {

        }



    }


    protected void checkall_CheckedChanged(object sender, EventArgs e)
    {
        try
        {

            CheckBox b = (CheckBox)sender;
            GridViewRow row = (GridViewRow)b.NamingContainer;
            if (row != null)
            {
                TextBox Trucks = (TextBox)grid_parcel.Rows[row.RowIndex].FindControl("txt_truckreq");
                TextBox Time = (TextBox)grid_parcel.Rows[row.RowIndex].FindControl("txt_time");
                TextBox Remarks = (TextBox)grid_parcel.Rows[row.RowIndex].FindControl("txt_remarks");
                if (b.Checked)
                {
                    Trucks.Text = "";
                    Time.Text = "";
                    Remarks.Text = "";
                    Trucks.Enabled = true;
                    Time.Enabled = true;
                    Remarks.Enabled = true;
                }
                else
                {
                    Trucks.Text = "";
                    Time.Text = "";
                    Remarks.Text = "";
                    Trucks.Enabled = false;
                    Time.Enabled = false;
                    Remarks.Enabled = false;
                }
            }
        }
        catch (Exception ex)
        {


        }
    }
    protected void btn_assignparcel_Click(object sender, EventArgs e)
    {
        try
        {
            btn_assignparcel.Visible = true;
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
            foreach (GridViewRow GVRow in grid_parcel.Rows)
            {
                CheckBox check = (CheckBox)GVRow.FindControl("ChkSelect");
                if (check.Checked)
                {                    
                    string AgreementRouteID = Convert.ToString((GVRow.FindControl("lblplanID") as Label).Text.Trim());
                    string FromLocation = Convert.ToString((GVRow.FindControl("lblFromLoc") as Label).Text.Trim());
                    string ToLocation = Convert.ToString((GVRow.FindControl("lbltoloc") as Label).Text.Trim());
                    string TruckType = Convert.ToString((GVRow.FindControl("lbldeliverytype") as Label).Text.Trim());//lbldeliverytype

                    string EnclType = Convert.ToString((GVRow.FindControl("lblpckingtype") as Label).Text.Trim());

                    string Capacity = Convert.ToString((GVRow.FindControl("lblcapacity") as Label).Text.Trim());
                    int QuotedPrice = 0;//
                    string _DecidePrice = Convert.ToString((GVRow.FindControl("lblDecidePrice") as Label).Text.Trim());
                    int DecidePrice = Convert.ToInt32(_DecidePrice);
                    string _TransporterID = Convert.ToString((GVRow.FindControl("lblTransID") as Label).Text.Trim());
                    int TransporterID = Convert.ToInt32(_TransporterID);
                    string _NoofTrucksReq = Convert.ToString((GVRow.FindControl("txt_truckreq") as TextBox).Text.Trim());
                    int NoofTrucksReq = Convert.ToInt32(_NoofTrucksReq);
                    string _TravelDate = txtDate.Text.Trim();
                    DateTime TravelDate = Convert.ToDateTime(_TravelDate);
                    string TravelTime = Convert.ToString((GVRow.FindControl("txt_time") as TextBox).Text.Trim());
                    string Remarks = Convert.ToString((GVRow.FindControl("txt_remarks") as TextBox).Text.Trim());
                    //string AssignedDated="";
                    DateTime AssignedDated = DateTime.Now;
                    int UserID = Convert.ToInt32(Session["UserID"].ToString());
                    int Assigned = 0;//
                    int IndentID = 0;//

                    string[] aregs = { "@AgreementRouteID", "@FromLocation", "@ToLocation", "@TruckType", "@EnclType", "@Capacity", "@QuotedPrice", "@DecidePrice", "@TransporterID", "@NoofTrucksReq", "@TravelDate", "@TravelTime", "@AssignedDated", "@UserID", "@Assigned", "@IndentID", "@remarks", "@res" };
                    string[] argsval = { AgreementRouteID, FromLocation, ToLocation, TruckType, EnclType, Capacity, QuotedPrice.ToString(), DecidePrice.ToString(), TransporterID.ToString(), NoofTrucksReq.ToString(), TravelDate.ToString(), TravelTime, AssignedDated.ToString(), UserID.ToString(), Assigned.ToString(), IndentID.ToString(),Remarks.ToString(), "0" };
                    int res = con.Sql_ExecuteNonQuery("SP_Insert_Biz_Trip_assign", aregs, argsval);

                    //sendsms(lblFrom.Text, lblTo.Text, lblTruckType.Text, lblCapacity.Text, lblMobile.Text);
                }
            }




            //for (int j = 0; j <= grid_parcel.Rows.Count - 1; j++)
            //{
            //    CheckBox check = (CheckBox)grid_parcel.Rows[j].FindControl("ChkSelect");
            //    if (check.Checked)
            //    {
            //        Label lblplanID = (Label)grid_parcel.Rows[j].FindControl("lblplanID");
            //        Label lblFrom = (Label)grid_parcel.Rows[j].FindControl("lblFromLoc");
            //        Label lblTo = (Label)grid_parcel.Rows[j].FindControl("lbltoloc");
            //        Label lblTruckType = (Label)grid_parcel.Rows[j].FindControl("lblTrucktype");
            //        Label lblEnclType = (Label)grid_parcel.Rows[j].FindControl("lblEncltype");
            //        Label lblCapacity = (Label)grid_parcel.Rows[j].FindControl("lblcapacity");
            //        Label lblprice = (Label)grid_parcel.Rows[j].FindControl("lblDecidePrice");
            //        TextBox txttruckreq = (TextBox)grid_parcel.Rows[j].FindControl("txt_truckreq");
            //        TextBox txttime = (TextBox)grid_parcel.Rows[j].FindControl("txt_time");
            //        Label lblTransporterID = (Label)grid_parcel.Rows[j].FindControl("lblTransID");
            //        Label lblMobile = (Label)grid_parcel.Rows[j].FindControl("lblMobile");
            //        //----Start--//
            //        //----end---//
            //        for (int k = 0; k < Convert.ToInt16(txttruckreq.Text); k++)
            //        {
            //            Trip_Assign.Bizconnect_InsertTripAssign(Convert.ToInt32(lblplanID.Text), lblFrom.Text, lblTo.Text, lblTruckType.Text, lblEnclType.Text, lblCapacity.Text, Convert.ToInt32(lblprice.Text), Convert.ToInt32(lblTransporterID.Text), Convert.ToInt32(txttruckreq.Text), Convert.ToDateTime(txtDate.Text), txttime.Text, Convert.ToInt32(Session["UserID"].ToString()));
            //        }
            //        //SMS  ALERT
            //        sendsms(lblFrom.Text, lblTo.Text, lblTruckType.Text, lblCapacity.Text, lblMobile.Text);
            //    }



            //}

            //Email Portion
            DataSet dsce = new DataSet();
            tableheader = "<table bgcolor=White bordercolor=#003366 border=1 style=width: 650px ><tr><td align=center><b>Trip Summary</b></td></tr><tr><td align=center bgcolor=#585858><Font size=2 color=White><strong>From</strong></font></td><td align=center bgcolor=#585858><Font size=2 color=White><strong>To</strong></font></td><td align=center bgcolor=#585858><Font size=2 color=White><strong>PackingType</strong></font></td><td align=center bgcolor=#585858><Font size=2 color=White><strong>DeliveryType</strong></font></td><td align=center bgcolor=#585858><Font size=2 color=White><strong>Capacity</strong></font></td><td align=center bgcolor=#585858><Font size=2 color=White><strong>NoofUnits</strong></font></td><td align=center bgcolor=#585858><Font size=2 color=White><strong>Time</strong></font></td><td align=center bgcolor=#585858><Font size=2 color=White><strong>TravelDate</strong></font></td><td align=center bgcolor=#585858><Font size=2 color=White><strong>Remarks</strong></font></td> <td align=center bgcolor=#585858><Font size=2 color=White><strong>ClientName</strong></font></td> </tr>";

            for (int j = 0; j <= grid_parcel.Rows.Count - 1; j++)
            {
                CheckBox check = (CheckBox)grid_parcel.Rows[j].FindControl("ChkSelect");
                if (check.Checked)
                {
                    Label lblplanID = (Label)grid_parcel.Rows[j].FindControl("lblplanID");
                    Label lblEmail = (Label)grid_parcel.Rows[j].FindControl("lblEmail");
                    Label lblTransid = (Label)grid_parcel.Rows[j].FindControl("lblTransID");
                    Transid = lblTransid.Text;
                    Session["AgreementID"] = Session["AgreementID"] + "," + lblplanID.Text;
                    if ((Email.ToString() != "" && Email.ToString() != lblEmail.Text))
                    {


                        Label lblTransid1 = (Label)grid_parcel.Rows[j - 1].FindControl("lblTransID");
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

                        //dsce = obj_class2.get_EmailIDCCstoClient(Convert.ToInt32(Session["ClientID"].ToString()));
                       // cc = cc + "," + dsce.Tables[0].Rows[0].ItemArray[0].ToString();
                        //----------------------------------------------------------------------

                        body = mailbody + tableheader + body + "</table>" + "<a href=http://www.scmbizconnect.com/TripAcceptance.aspx?TransID=" + Transid.ToString() + "&ClID=" + Session["ClientID"].ToString() + "&agID=" + Session["AgreementID"] + ">Click Here to Confirm the Routes</a><br/><br/>Best Regards<br/><br/><br/>SCMBizconnect Team.";

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

                        //ComposeMail(j);
                        ComposeParcelMail(j);

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

           // dsce = obj_class2.get_EmailIDCCstoClient(Convert.ToInt32(Session["ClientID"].ToString()));
           // cc = cc + "," + dsce.Tables[0].Rows[0].ItemArray[0].ToString();
           // cc = cc.Replace(';', ',');

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
                    MyMailMessage.Bcc.Add("shashidhar@aarmsvaluechain.com");
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
    private void ComposeParcelMail(int j)
    {
        Label lblEmail = (Label)grid_parcel.Rows[j].FindControl("lblEmail");
        Label lblFrom = (Label)grid_parcel.Rows[j].FindControl("lblFromLoc");
        Label lblTo = (Label)grid_parcel.Rows[j].FindControl("lbltoloc");
        Label lblTruckType = (Label)grid_parcel.Rows[j].FindControl("lbldeliverytype");
        Label lblEncltype = (Label)grid_parcel.Rows[j].FindControl("lblpckingtype");
        Label lblCapacity = (Label)grid_parcel.Rows[j].FindControl("lblcapacity");
        TextBox txtnooftruks = (TextBox)grid_parcel.Rows[j].FindControl("txt_truckreq");
        TextBox txttime = (TextBox)grid_parcel.Rows[j].FindControl("txt_time");
        TextBox txtremarks = (TextBox)grid_parcel.Rows[j].FindControl("txt_remarks");
        string remarks = txtremarks.Text;
        Email = lblEmail.Text;

        body += "<tr><td align=center><font size=2>" + lblFrom.Text + "</font></td><td align=center><font size=2 >" + lblTo.Text + "</font></td><td align=center><font size=2>" + lblEncltype.Text + "</font></td><td align=center><font size=2>" + lblTruckType.Text + "</font></td><td align=center><font size=2>" + lblCapacity.Text + "</font></td><td align=center><font size=2>" + txtnooftruks.Text + "</font></td><td align=center><font size=2>" + txttime.Text + "</font></td><td align=center><font size=2>" + txtDate.Text + "</font></td><td align=center><font size=2>" + remarks + "</font></td>  <td align=center><font size=2>" + Session["ClientName"].ToString() + "</font></td></tr>";
    }


    //protected void btn_show_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        if (FileUpload1.HasFile)
    //        {
    //            string FileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
    //            string Extension = Path.GetExtension(FileUpload1.PostedFile.FileName);
    //            string FolderPath = Server.MapPath("Excel/");//ConfigurationManager.AppSettings["FolderPath"];

    //            string FilePath = Server.MapPath("Excel/" + FileName);
    //            Session["FilePath"] = Server.MapPath("Excel/" + FileName);
    //            FileUpload1.SaveAs(FilePath);
    //            Import_To_Grid(FilePath, Extension);
    //            File.Delete(FilePath);
    //        }


    //    }
    //    catch (Exception ex)
    //    {


    //    }
    //}

    //private void Import_To_Grid(string FilePath, string Extension)
    //{
    //    try
    //    {
    //        string conStr = "";
    //        switch (Extension)
    //        {
    //            case ".xls": //Excel 97-03
    //                conStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Session["FilePath"].ToString() + ";Extended Properties='Excel 8.0;HDR={1}'";
    //                break;
    //            case ".xlsx": //Excel 07
    //                conStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source= " + Session["FilePath"].ToString() + ";Extended Properties='Excel 8.0;HDR={1}'";
    //                break;
    //        }
    //        conStr = String.Format(conStr, FilePath, "Yes");
    //        OleDbConnection connExcel = new OleDbConnection(conStr);
    //        OleDbCommand cmdExcel = new OleDbCommand();
    //        OleDbDataAdapter oda = new OleDbDataAdapter();
    //        DataTable dt = new DataTable();
    //        cmdExcel.Connection = connExcel;

    //        //Get the name of First Sheet
    //        connExcel.Open();
    //        DataTable dtExcelSchema;
    //        dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
    //        string SheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
    //        connExcel.Close();

    //        //Read Data from First Sheet
    //        connExcel.Open();
    //        cmdExcel.CommandText = "SELECT * From [" + SheetName + "]";
    //        oda.SelectCommand = cmdExcel;
    //        oda.Fill(dt);
    //        connExcel.Close();
    //        try
    //        {
    //            foreach (DataRow dr in dt.Rows)
    //            {
    //                string cid = Session["ClientID"].ToString();
    //                string source = dr["FromLocation"].ToString().Trim();
    //                string destination = dr["ToLocation"].ToString().Trim();
    //                string[] args = { "@clientid", "@desti" };
    //                string[] argsval = { cid, "%" + destination + "%" };
    //                DataSet ds = new DataSet();
    //                ds = con.Sql_GetData("SP_Get_AgreementRouteID", args, argsval);
    //                if (ds.Tables[0].Rows.Count > 0)
    //                {
    //                    dr["AgreementRouteID"] = ds.Tables[0].Rows[0]["AgreementRouteID"].ToString();
    //                    dr["TransporterID"] = ds.Tables[0].Rows[0]["TransporterID"].ToString();

    //                }
    //                string transporter = dr["Transporter"].ToString().Trim();
    //                string PackingType = dr["PackingType"].ToString().Trim();
    //                string DeliveryType = dr["DeliveryType"].ToString().Trim();
    //                string Capacity = dr["Capacity"].ToString().Trim();
    //                string DecidePrice = dr["DecidePrice"].ToString().Trim();
    //                string NoOfUnits = dr["NoOfUnits"].ToString().Trim();
    //                string TravelDate = dr["TravelDate"].ToString().Trim();
    //                string TravelTime = dr["TravelTime"].ToString().Trim();
    //                string Remarks = dr["Remarks"].ToString().Trim();
    //            }
    //            GridView1.DataSource = dt;
    //            GridView1.DataBind();

    //        }
    //        catch (Exception ex)
    //        {


    //        }

    //    }
    //    catch (Exception ex)
    //    {



    //    }
    //}
    //protected void btn_upload_Click(object sender, EventArgs e)
    //{

    //}

}
