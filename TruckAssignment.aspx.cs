using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using System.Collections;
using System.Configuration;
using System.Text.RegularExpressions;

public partial class TruckAssignment : System.Web.UI.Page
{
    String obj_Authenticated;
    PlaceHolder maPlaceHolder = new PlaceHolder();
    UserControl obj_Tabs;
    UserControl obj_LoginCtrl;
    UserControl obj_WelcomCtrl;
    UserControl obj_bannerCtrl;
    String obj_ClientID, obj_ClientCode, obj_ClientName;

    Int32 obj_Resp = 0;


    BizConnectDealProcess obj_BizConnectDealProcessClass = new BizConnectDealProcess();
    DataSet ds = new DataSet();

    String obj_AdID,obj_LogisticsPlanNo;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack == false)
        {
            
            Bind();
            Butclose.Attributes.Add("onclick", "window.close();");

        }
    }

    public void Bind()
    {
        //CheckAuthentication();
        //Session["UserID"] = 1;
        try
        {
            //Get AdID from Session
            obj_AdID = Session["AdID"].ToString();
            obj_LogisticsPlanNo = Session["LogisticsPlanNo"].ToString();
            String Obj_PostReplyID = "";
            if (obj_AdID != "")
            {
                ds.Clear();
                ds = obj_BizConnectDealProcessClass.get_QuoteDetails(obj_AdID);
                Gridwindow.DataSource = ds;
                Gridwindow.DataMember = "QuoteDetails";
                Gridwindow.DataBind();
                lblAdIDw.Text = obj_AdID;
                lblFrom.Text = ds.Tables["QuoteDetails"].Rows[0][1].ToString();
                lblLogisticPlanNo.Text = obj_LogisticsPlanNo; //ds.Tables["QuoteDetails"].Rows[0][0].ToString();
                lblTo.Text = ds.Tables["QuoteDetails"].Rows[0][2].ToString();
                lblTruckRequired.Text = ds.Tables["QuoteDetails"].Rows[0][3].ToString();
                lblTraveldate.Text = ds.Tables["QuoteDetails"].Rows[0][0].ToString();
                foreach (GridViewRow row in Gridwindow.Rows)
                {
                    Label lblQuoteID = (Label)row.FindControl("lblQuoteID");
                    TextBox txtNoOfTrucks = (TextBox)row.FindControl("txtTruckRequired");
                    Label lblQuotedCost = (Label)row.FindControl("lblQuoteCost");
                    TextBox txtAssignedTrucks = (TextBox)row.FindControl("txtAssignedTrucks");
                    Label lblPostReplyID = (Label)row.FindControl("lblPostReplyID");
                    Obj_PostReplyID = lblPostReplyID.Text.Trim();
                    Label lblPostID = (Label)row.FindControl("lblPostID");
                    ValidateExistOrNot(Obj_PostReplyID, lblLogisticPlanNo.Text.Trim());
                }
            }

        }

        catch (Exception err)
        {
        }
    }
    //Validate whether records exist or not
    public void ValidateExistOrNot(String Obj_PostRplyID, String Obj_LogisticPlanNumber)
    {
        DataSet ds=new DataSet();
        ds = obj_BizConnectDealProcessClass.Get_scmJunction_PreAssignmentByPostReplyIDAndLogisticsPlanNo(Obj_PostRplyID, Obj_LogisticPlanNumber);
        if (ds.Tables["PreAssignment"].Rows.Count>0)
        {
            foreach (GridViewRow row in Gridwindow.Rows)
            {
                CheckBox chkrow = (CheckBox)row.FindControl("ChkSelect");
                Label lblQuoteID = (Label)row.FindControl("lblQuoteID");
                TextBox txtNoOfTrucks = (TextBox)row.FindControl("txtTruckRequired");
                Label lblQuotedCost = (Label)row.FindControl("lblQuoteCost");
                TextBox txtAssignedTrucks = (TextBox)row.FindControl("txtAssignedTrucks");
                Label lblPostReplyID = (Label)row.FindControl("lblPostReplyID");
                Label lblPostID = (Label)row.FindControl("lblPostID");
                Label lblStatus = (Label)row.FindControl("lblStatus");
                if (Obj_PostRplyID == lblPostReplyID.Text.Trim())
                {
                    txtAssignedTrucks.Text = ds.Tables["PreAssignment"].Rows[0][4].ToString();
                    lblStatus.Visible = true;
                    lblStatus.Text = "Waiting for Approval...!";
                    txtAssignedTrucks.Enabled = false;
                    //ButAssign.Enabled = false;
                    chkrow.Enabled = false;
                    chkrow.Checked = false;
                    chkrow.DataBind();
                }
            }
        }
    }

    //Authentication Section
    public void ChkAuthentication()
    {
        obj_LoginCtrl = null;
        obj_WelcomCtrl = null;

        //obj_Navi = null;
        //obj_Navihome = null;

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
    }

    public void SetVisualOFF()
    {
        obj_LoginCtrl.Visible = true;
        obj_WelcomCtrl.Visible = false;
    }

    ////CheckBox Select All function
    protected void cbSelectAll_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox chk = (CheckBox)Gridwindow.HeaderRow.FindControl("cbSelectAll");
        if (chk.Checked)
        {
            for (int i = 0; i < Gridwindow.Rows.Count; i++)
            {
                Label lblStatus = (Label)Gridwindow.Rows[i].FindControl("lblStatus");
                    if (lblStatus.Text != "Waiting for Approval...!")
                    {
                        CheckBox chkrow = (CheckBox)Gridwindow.Rows[i].FindControl("ChkSelect");
                        chkrow.Checked = true;
                        chkrow.DataBind();
                    }
                    else if (lblStatus.Text == "Waiting for Approval...!")
                    {
                        CheckBox chkrow = (CheckBox)Gridwindow.Rows[i].FindControl("ChkSelect");
                        chkrow.Checked = false;
                        chkrow.DataBind();
                    }
            }

        }
        else
        {
            for (int i = 0; i < Gridwindow.Rows.Count; i++)
            {
                CheckBox chkrow = (CheckBox)Gridwindow.Rows[i].FindControl("ChkSelect");
                chkrow.Checked = false;
            }
        }
    }

    //Assign Section when user Click the Button
    protected void ButAssign_Click(object sender, EventArgs e)
    {            
        int count = 0;
        Int32 obj_PostedBy, obj_UpdatedBy,obj_AssignedTrucks=0,obj_NoOfTrucks=0;
        foreach (GridViewRow row in Gridwindow.Rows)
        {
            CheckBox chkrow = (CheckBox)row.FindControl("ChkSelect");
            if (chkrow.Checked == true)
            {
                Label lblQuoteID = (Label)row.FindControl("lblQuoteID");
                TextBox txtNoOfTrucks = (TextBox)row.FindControl("txtTruckRequired");
                Label lblQuotedCost = (Label)row.FindControl("lblQuoteCost");
                TextBox txtAssignedTrucks = (TextBox)row.FindControl("txtAssignedTrucks");
                Label lblPostReplyID = (Label)row.FindControl("lblPostReplyID");
                Label lblPostID = (Label)row.FindControl("lblPostID");
                Label lblStatus = (Label)row.FindControl("lblStatus");

                obj_PostedBy =Convert.ToInt32(Session["UserID"].ToString());
                obj_UpdatedBy = Convert.ToInt32(Session["UserID"].ToString());
                
                obj_AssignedTrucks = Convert.ToInt32(txtAssignedTrucks.Text);
                obj_NoOfTrucks=Convert.ToInt32(txtNoOfTrucks.Text.Trim());

                obj_LogisticsPlanNo = lblLogisticPlanNo.Text.Trim();
                if (lblStatus.Text != "Waiting for Approval...!")
                {
                    count = count + 1;
                    obj_Resp = obj_BizConnectDealProcessClass.Insert_SCMJunctionPreAssignment(Convert.ToInt32(lblPostReplyID.Text.Trim()), Convert.ToInt32(lblPostID.Text.Trim()), Convert.ToDouble(lblQuotedCost.Text.Trim()), Convert.ToInt32(txtAssignedTrucks.Text.Trim()), obj_LogisticsPlanNo, "True", "False", obj_PostedBy, obj_UpdatedBy, 1);
                    obj_Resp = obj_BizConnectDealProcessClass.Update_SCMJunctionPostReply(Convert.ToInt32(lblPostReplyID.Text.Trim()));


                    lblStatus.Text = "Waiting for Approval...!";
                    lblStatus.Visible = true;
                    txtAssignedTrucks.ReadOnly = true;
                    chkrow.Checked = false;
                }
                chkrow.Checked = false;
                //String obj_MsgforRepliedByUser;
                //obj_MsgforRepliedByUser = "Your assigned bid is accepted successfully in SCMJunction,Your Acceptance ID is " + obj_AcceptanceID;
                //String obj_EmailMsgforRepliedByUser;
                //obj_EmailMsgforRepliedByUser = "Your assigned bid is accepted successfully in SCMJunction.com....";

                //if (obj_Resp == 1)
                //{
                //    smsresp = SendSMSReplyByID(obj_AdID, obj_MsgforRepliedByUser, lblReplyByID.Text.Trim());
                //    Emailresp = SendEmail(obj_AdID, obj_AcceptanceID, obj_EmailMsgforRepliedByUser);

                //}
            }
            if (count < 1)
            {
                lblMessage.Text = "Sorry,Quote is wiaitng for approval...!";
            }
            else
            {
                lblMessage.Text = "";
            }
        }
        if (obj_Resp == 1)
        {
            obj_Resp = SendSMS(lblLogisticPlanNo.Text.Trim(), obj_AssignedTrucks);
           // obj_Resp = SendEmail(lblLogisticPlanNo.Text.Trim(),lblFrom.Text.Trim(),lblTo.Text.Trim(),obj_NoOfTrucks.ToString(),lblTraveldate.Text.Trim(),obj_AssignedTrucks.ToString());
        }
        
    }

    //Sending SMS after successfully Posting Ad 
    public Int32 SendSMS(String obj_LogisticsPlanNumber,Int32 obj_AssignedTruck)
    {
        String obj_UserId;
        Int32 obj_resp = 3;
        String obj_Message;
        String obj_UID;
        String obj_Password;
        String obj_MobileNo;
        ArrayList arr = new ArrayList();

        obj_UserId = Session["UserID"].ToString();

        obj_MobileNo = "0";
        obj_Message = "2 Trucks are assigned against your Ad in bizconnect,Pls accept the approval";// obj_AssignedTruck.ToString() + " Trucks are assigned against your Ad ['" + obj_LogisticsPlanNumber + "'] in www.bizconnect.com,So Please accept the approval";
        obj_UID = ConfigurationManager.AppSettings.Get("Way2SMSUID").ToString();
        obj_Password = ConfigurationManager.AppSettings.Get("Way2SMSPassword").ToString();
        try
        {
            arr.Clear();
            arr = obj_BizConnectDealProcessClass.get_MobileNoAndEmailByLogisticsPlanNo(obj_LogisticsPlanNumber);
            if (arr[0].ToString() != "1")
            {
                //lblMessage.ForeColor = System.Drawing.Color.Red;
                //lblMessage.Text = "Sending SMS Failed,because Mobile No does not exist in the table...!";
                //obj_resp = 0;
            }
            else
            {
                obj_MobileNo = arr[1].ToString();
                //Declaration Section for AARMSMS Control
                ExponantAARMSMS.SendSMS sms= new ExponantAARMSMS.SendSMS();
                String Message = Regex.Replace(obj_Message, "#", "");
                sms.ExponantSendSMS(obj_UID, obj_Password, obj_MobileNo, Message,"N");
                obj_resp = 1;
            }
        }
        catch (Exception err)
        {
            obj_resp = 3;
        }
        return obj_resp;
    }

    //Sending Email after successfully Posting Ad 
    public Int32 SendEmail(String obj_LogisticsPlanNumber, String obj_From, String obj_To, String obj_NoOfTrucks, String obj_TravelDate, String obj_AssignedTrucks)
    {
        Int32 obj_resp = 3;
        String obj_Message;
        String obj_EmailID;
        ArrayList arr = new ArrayList();
        //Email Settings from Web Config
        string obj_FromEmail = ConfigurationManager.AppSettings.Get("fromemailid").ToString();
        string obj_BounceBakEmail = ConfigurationManager.AppSettings.Get("bouncebakemailid").ToString();
        string obj_ServerName = ConfigurationManager.AppSettings.Get("Server").ToString();
        string obj_Password = ConfigurationManager.AppSettings.Get("Password").ToString();
        string obj_PortNo = ConfigurationManager.AppSettings.Get("PortNo").ToString();
        string obj_AuthenticateMode = ConfigurationManager.AppSettings.Get("AuthenticateMode").ToString();
        string obj_SendUsingPort = ConfigurationManager.AppSettings.Get("SendUsingPort").ToString();
        string obj_SMTPUseSSL = ConfigurationManager.AppSettings.Get("SMTPUseSSL").ToString();
        Boolean SMTPUseSSL;
        string obj_AttachmentPath = ConfigurationManager.AppSettings.Get("AttachmentPath").ToString();
        //

        String x_LogisticsPlanNo = Regex.Replace(obj_LogisticsPlanNumber, "#", "");
        arr.Clear();
        arr = obj_BizConnectDealProcessClass.get_MobileNoAndEmailByLogisticsPlanNo(obj_LogisticsPlanNumber);
        if (arr[0].ToString() != "1")
        {
            //lblMessage.ForeColor = System.Drawing.Color.Red;
            //lblMessage.Text = "Sending Email Failed,because Mobile No does not exist in the table...!";
            //obj_resp = 0;
        }
        else
        {
            obj_EmailID = "sharmilp@yahoo.com"; //arr[2].ToString();
            String obj_ContactPerson = arr[3].ToString();
            String obj_ClientID = Session["ClientID"].ToString();
            String obj_ClientName = arr[5].ToString();
           

            DateTime obj_CurrentDate = new DateTime();
            obj_CurrentDate = DateTime.Now.Date;
            String dt;
            dt = obj_CurrentDate.ToString("dd-MMM-yyyy");

            String Body = "<table bgcolor=White bordercolor=#003366 border=1 style=width: 650px ><tr><td bgcolor=#585858 align=center colspan=1 ><font size=2 color=yellow><strong>Client ID - " + obj_ClientID + "<strong></font></td><td bgcolor=#585858 align=center colspan=4><font color=White><strong>Name - " + obj_ClientName + "</strong></font</td><td bgcolor=#585858 align=center colspan=2><font size=2 color=yellow><strong>Date - " + obj_CurrentDate + "<strong><font></td></tr><tr><td align=center></td><td align=center colspan=4><font size=3 color=#003366><strong><a href=http://www.scmbizconnect.com title=www.scmbizconnect.com target=_Blank>www.scmbizconnect.com<a></strong></font></td><td a<strong><font size=2 color=#003366></font></td></strong></font></tr><tr><td align=center bgcolor=#585858><Font size=2 color=White><strong>Logistics Plan No </strong></font></td><td align=center bgcolor=#585858><Font size=2 color=White><strong>From Location</strong></font></td><td align=center bgcolor=#585858><Font size=2 color=White><strong>To Location</strong></font></td><td align=center bgcolor=#585858><Font size=2 color=White><strong>No of Trucks</strong></font></td><td align=center bgcolor=#585858><Font size=2 color=White><strong>Assigned Trucks</strong></font></td><td align=center bgcolor=#585858><Font size=2 color=White><strong>Travel Date</strong></font></td></tr><tr><td align=center><a href=http://www.scmjunction.com/Viewnew.aspx?Adid=" + obj_LogisticsPlanNumber + " title=Click for View this Ad target=_Blank ><strong>" + x_LogisticsPlanNo + "</strong></a></td><td align=center><font size=2>" + obj_From + "</font></td><td align=center><font size=2>" + obj_To  + "</font></td><td align=center><font size=2>2</font></td><td align=center><font size=2>" + obj_AssignedTrucks + "</font></td><td align=center><font size=2>" + obj_TravelDate + "</font></td></tr><tr bgcolor=#585858><td align=center>&nbsp;</td><td align=center colspan=4><Font size=2 color=White><strong><font size=2>Total no of  Posted Logistics Plan : 01</font></strong></font></td><td align=center>&nbsp;</td></tr></table>";
            obj_Message = "Dear " + obj_ContactPerson + ",<br/>We would like to inform you that '"+ obj_AssignedTrucks  +"' Trucks are assigned against your Logistics Plan Ad in <a href=http://www.scmbizconnect.com>www.scmbizconnect.com.</a>,so kindly request you please login your account and accept the approval.<br/><br/>The details of the Posted Ad are listed below:<br/>Please use this Logistics Plan No -"+ obj_LogisticsPlanNumber  +" for any enquery.<br/><br/>" + Body + "<br/><br/>Thank You,<br/>Web Master,<br> SCM BizConnect<br/><a href=http://www.scmbizconnect.com>www.scmbizconnect.com</a>";
            try
            {
                //Declaration Section for AARMEmail Control
                AARMEmail.EmailControl em = new AARMEmail.EmailControl();
                em.SendEmail(obj_EmailID, obj_FromEmail, obj_Password, "", "", obj_FromEmail, obj_BounceBakEmail, "Your have received new updates against your Ad in www.scmbizconnect.com", obj_Message.ToString().Trim(), System.Web.Mail.MailFormat.Html, System.Web.Mail.MailPriority.Normal, obj_ServerName.ToString().Trim(), obj_PortNo.ToString().Trim(), obj_SendUsingPort.ToString().Trim(), obj_AuthenticateMode.ToString().Trim(), false, obj_AttachmentPath.ToString().Trim());
                obj_resp = 1;
            }
            catch (Exception err)
            {
                obj_resp = 3;
            }
        }
        return obj_resp;
    }
    protected void Butclose_Click(object sender, EventArgs e)
    {
        Butclose.Attributes.Add("onclick", "javascript:window.close();");
    }

}