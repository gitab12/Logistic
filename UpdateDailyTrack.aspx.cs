using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

public partial class UpdateDailyTrack : System.Web.UI.Page
{
    BizCon_DB_ConnectionString con = new BizCon_DB_ConnectionString();
    AARMEmail.EmailControl mail = new AARMEmail.EmailControl();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            div2.Visible = false;
            div4.Visible = false;
            divloc.Visible = false;
            divrem.Visible = false;
            Label1.Text = HttpUtility.UrlDecode(Request.QueryString["PostID"]);
            Label2.Text = HttpUtility.UrlDecode(Request.QueryString["LRNumber"]);
            Label3.Text = HttpUtility.UrlDecode(Request.QueryString["TripAssignID"]);
            Label4.Text = HttpUtility.UrlDecode(Request.QueryString["AcceptanceID"]);
            Label5.Text = HttpUtility.UrlDecode(Request.QueryString["mobileNo"]);
        }
    }

    protected void btn_insert_Click(object sender, EventArgs e)
    {
        try
        {
            string userid = Session["UserID"].ToString();
            DateTime createddatetimestamp = DateTime.Now;
            string _cutt = createddatetimestamp.ToString("MM/dd/yyyy h:mm:ss tt");
            string postid = Request.QueryString["PostID"];
            string LRNumber = Request.QueryString["LRNumber"];

            string Acceptanceid = Request.QueryString["AcceptanceID"];
            string tripassignid = Request.QueryString["TripAssignID"];
            string location = txt_location.Text;
            Session["Location"] = location;
            string status = ddl_status.SelectedItem.Text;
           
                string remarks = txt_remarks.Text;
                string date = txt_date.Text;
                DateTime _Datetime = Convert.ToDateTime(date);
                string date_time = _Datetime.ToString("dd-MMM-yyyy  h:mm:ss tt");


                string[] args = { "@postid", "@acceptanceid", "@tripassignid", "@lrnumber", "@location", "@status", "@remarks", "@date", "@createddatetimestamp", "@updateddatetimestamp", "@userid", "@res" };
                string[] argsval = { postid, Acceptanceid, tripassignid, LRNumber, location, status, remarks, date_time.ToString(), _cutt, _cutt, userid,"0" };
                int res = con.Sql_ExecuteNonQuery("Bizconnect_Insert_Trackdetails", args, argsval);
                if (res > 0)
                {
                    string[] args1 = { "@postid", "@userid", "@TrackID" };
                    string[] argsval1 = { postid, userid,res.ToString() };
                    DataSet ds = new DataSet();
                    ds = con.Sql_GetData("Bizconnect_GetStatus_New1", args1, argsval1);//Bizconnect_GetStatus
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        string _status = ds.Tables[0].Rows[0]["Status"].ToString();
                        if (_status == "Delivered")
                        {
                            string cid = Session["ClientID"].ToString();
                            string[] args2 = { "@clientid", "@lrnumber", "@acceptanceid" };
                            string[] argsval2 = { cid, LRNumber, Acceptanceid };
                            DataSet ds_status = new DataSet();
                            ds_status = con.Sql_GetData("Bizconnect_Get_Receiving_details", args2, argsval2);
                            if (ds_status.Tables[0].Rows.Count > 0)
                            {
                                div2.Visible = true;
                                gridview_details.DataSource = ds_status;
                                gridview_details.DataBind();
                                //lbl_msg.Text = Resources.Resource.alert_success.Replace("{@message}", "Data Inserted Successfully!!");
                            }
                            else
                            {
                                lbl_msg.Text = Resources.Resource.alert_error.Replace("{@message}", "Data Already Exist!!");
                            }
                        }
                        else if (_status == "In Transit")
                        {
                            DateTime currentdatetime = DateTime.Now;
                            string current_datetime = currentdatetime.ToString("MM/dd/yyyy  h:mm:ss tt");
                            string[] argsc = { "@PostID" };
                            string[] argcvall = { postid };
                            DataSet dssc = new DataSet();
                            dssc = con.Sql_GetData("SP_Get_UpdateDetails", argsc, argcvall);
                            if (dssc.Tables[0].Rows.Count > 0)
                            {
                                string[] argsup = { "@PostID", "@status_id", "@user_id", "@updating_datetime", "@res" };
                                string[] argsvalup = { postid, "1", userid, current_datetime,"0" };
                                int resupd = con.Sql_ExecuteNonQuery("SP_UpdateTimedate_tbl_updatedtaBlock", argsup, argsvalup);
                            }
                            else
                            {
                                string[] argsu = { "@PostID", "@status_id", "@user_id", "@updating_datetime", "@res" };
                                string[] argsvall = { postid, "1", userid, current_datetime, "0" };
                                int resu = con.Sql_ExecuteNonQuery("SP_Insert_UpdateDetailsPostID", argsu, argsvall);
                            }                           

                            lbl_msg.Text = Resources.Resource.alert_success.Replace("{@message}", "Data Inserted Successfully!!");
                            //lbl_msg.Text = Resources.Resource.alert_info.Replace("{@message}", "Something Went wrong!");
                            //SendMail_For_transit();
                            div4.Visible = true;
                        }
                        else
                        {
                            lbl_msg.Text = " ";
                        }

                    }
                }
                else
                {
                    lbl_msg.Text = Resources.Resource.alert_info.Replace("{@message}", "Something Went wrong!");
                    div4.Visible = true;
                }
        }
        catch(Exception ex)
        {
            //lbl_msg.Text = Resources.Resource.alert_info.Replace("{@message}", "Something Went wrong! "+ ex.Message);
        }

    }

   

    protected void gridview_details_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Details")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = gridview_details.Rows[index];
            Label Accepid = (Label)gridview_details.Rows[row.RowIndex].FindControl("lblplanID");
            string Accepidid = Accepid.Text;

            Label lblplid = (Label)gridview_details.Rows[row.RowIndex].FindControl("lblplid");
            string lblplidid = lblplid.Text;

            Label LRNumber = (Label)gridview_details.Rows[row.RowIndex].FindControl("lblLRno");

            string LRNumberr = LRNumber.Text;

            Session["LRNumber"]=LRNumber.Text;
            TextBox txt_date = (TextBox)gridview_details.Rows[row.RowIndex].FindControl("txt_date");
            string ttdate = txt_date.Text;

            Session["ReceivedDate"] = txt_date.Text;
            Label lbltoloc = (Label)gridview_details.Rows[row.RowIndex].FindControl("lbltoloc");
            Session["lbltoloc"] = lbltoloc.Text;
            TextBox Remarks = (TextBox)gridview_details.Rows[row.RowIndex].FindControl("txtRemarks");
            string rremarks = Remarks.Text;

            Session["Remarks"] = Remarks.Text;
            TextBox txt_date1 = (TextBox)gridview_details.Rows[row.RowIndex].FindControl("txt_date1");
            string txt_date11 = txt_date1.Text;

            TextBox txtvehicleNo = (TextBox)gridview_details.Rows[row.RowIndex].FindControl("txtvehicleNo");

            string txtvehicleNo1 = txtvehicleNo.Text;

            string[] _args = {"@plid", "@acceptanceid", "@lrnumber", "@receiveddate", "@remarks", "@unloadingdate", "@Vehicleno","@speedometer"};
            string[] _argsval = { lblplidid, Accepidid, LRNumberr, Convert.ToDateTime(ttdate).ToString(), rremarks, Convert.ToDateTime(txt_date11).ToString(), txtvehicleNo1, "0" };
            int res = con.Sql_ExecuteNonQuery("Bizconnect_Insert_Receiving_Details", _args, _argsval);
            if (res > 0)
            {
                lbl_msg.Text = Resources.Resource.alert_success.Replace("{@message}", "Data Uploaded Succesfully!!");
                div2.Visible = false;
                div4.Visible = true;
                SendMail();
            }
            else
            {
                lbl_msg.Text = Resources.Resource.alert_error.Replace("{@message}", "Data not Uploaded Succesfully please try again!!");
                div4.Visible = true;
            }
        }
    }

    private void SendMail()
    {
        string cid = Session["ClientID"].ToString();
        string[] args_mail = { "@clientid" };
        string[] argsval_mail={ cid };

        DataSet ds_mails = new DataSet();
        ds_mails = con.Sql_GetData("Bizconnect_Get_ClientEmail", args_mail, argsval_mail);
        if (ds_mails.Tables[0].Rows.Count > 0)
        {
            //string obj_Message = "This is to inform that the vehicle has  reached the destination:- " + Session["lbltoloc"].ToString() + " ]on " + Session["ReceivedDate"].ToString() + " <br>\nRemarks:" + Session["Remarks"].ToString() + " ";
            string obj_Message = "<table style='background-color: #f6f6f6;width: 59%;'> <td  style='width: 650px; display: block !important;max-width: 600px !important;margin: 0 auto !important;clear: both !important;'><div style=' max-width: 600px;margin: 0 auto;display: block;padding: 20px;'><table cellpadding=0 cellspacing=0 style='width:100%;' > <tr> <td> <table  cellpadding=0 cellspacing=0><tr><td><center><img src=http://www.scmbizconnect.com/images/logo.jpg /></center></td></tr> <tr><td style='padding: 0 0 20px';><h3>Dear Sir/madam,</h3></td></tr><tr><td style=' padding: 0 0 20px;'>This is to inform that the vehicle has  reached the destination:- " + Session["lbltoloc"].ToString() + " on " + Session["ReceivedDate"].ToString() + " <br>\nRemarks:" + Session["Remarks"].ToString() + "</td></tr> <tr><td style=' padding: 0 0 20px;'>Thank You,</td></tr> <tr><td > AARMS VALUE CHAIN PRIVATE LIMITED</td></tr><tr><td>#211, Temple Street,9th Main Road,BEML 3rd stage,</td></tr> <tr><td >RajarajeshwariNagar,Bangalore - 560098</td></tr><tr><td >Ph:080-66270268;09739870001</td></tr><tr><td >www.scmbizconnect.com</td></tr> </table></td></tr></table></div></td> </table>";
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

            string toemail = ds_mails.Tables[0].Rows[0]["CorporateEmail"].ToString();

            if (mydatareader.HasRows)
            {
                // mail.SendEmail(toemail, mydatareader.GetValue(0).ToString(), mydatareader.GetValue(1).ToString(), "", "", "tripschedule@scmbizconnect.com", "bounceback@scmjunction.com", "Receiving Information-LRNumber : " + Session["LRNumber"].ToString() + "", obj_Message.ToString().Trim(), System.Web.Mail.MailFormat.Html, System.Web.Mail.MailPriority.High, "smtp.gmail.com", "465", "2", "1", true, "");
                mail.SendEmail(toemail, mydatareader.GetValue(0).ToString(), mydatareader.GetValue(1).ToString(), "", "", "tripschedule@scmbizconnect.com", "bounceback@scmjunction.com", "Receiving Information-LRNumber : " + Session["LRNumber"].ToString() + "", obj_Message.ToString().Trim(), System.Web.Mail.MailFormat.Html, System.Web.Mail.MailPriority.High, "smtp.gmail.com", "465", "2", "1", true, "");
            }

            else
            {
                //mail.SendEmail(toemail, "tripschedule@scmbizconnect.com", "tripschedule123", "", "", "tripschedule@scmbizconnect.com", "bounceback@scmjunction.com", "Receiving Information-LRNumber : " + Session["LRNumber"].ToString() + "", obj_Message.ToString().Trim(), System.Web.Mail.MailFormat.Html, System.Web.Mail.MailPriority.High, "smtp.gmail.com", "465", "2", "1", true, "");
                mail.SendEmail(toemail, "tripschedule@scmbizconnect.com", "tripschedule123", "", "", "tripschedule@scmbizconnect.com", "bounceback@scmjunction.com", "Receiving Information-LRNumber : " + Session["LRNumber"].ToString() + "", obj_Message.ToString().Trim(), System.Web.Mail.MailFormat.Html, System.Web.Mail.MailPriority.High, "smtp.gmail.com", "465", "2", "1", true, "");
            }
        }
    }
    protected void btn_dash_Click(object sender, EventArgs e)
    {
        string cid = Session["ClientID"].ToString();
        if (cid != "")
        {
            Response.Redirect("DetailedTrack.aspx");
        }
        else
        {
            Response.Redirect("Index.html");
        }
    }
    protected void ddl_status_SelectedIndexChanged(object sender, EventArgs e)
    {
        string status = ddl_status.SelectedItem.Text;
        if (status == "In Transit")
        {
            divloc.Visible = true;
            divrem.Visible = true;
        }
        else
        {
            divloc.Visible = false;
            divrem.Visible = false;

        }
    }
}