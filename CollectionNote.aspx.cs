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
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using AARMEmail;
public partial class CollectionNote : System.Web.UI.Page
{

 string obj_Authenticated;
    PlaceHolder maPlaceHolder;
    UserControl obj_Tabs;
    UserControl obj_LoginCtrl;
    UserControl obj_WelcomCtrl;
    UserControl obj_Navi;
    UserControl obj_Navihome;
    string connStr = ConfigurationManager.ConnectionStrings["BizCon"].ConnectionString;
    ProjectBased obj_class = new ProjectBased();
       DataTable dt = new DataTable();
       DateTime dtt = new DateTime();
       DataTable CNID = new DataTable();
       DataTable dt_Transporter = new DataTable();
    FileUpload FileCtrl;
    int resp, CNNo,CNNoteID;    
    AARMEmail.EmailControl mail = new AARMEmail.EmailControl();
    string Reasons="0";
    DataTable dt_CheckAccess = new DataTable();
    static string ProjectNo, WBSNo, AutoNo, Club = "0";
    string ProjectManagerEmail;
    string LogisticPersonEmail;
    protected void Page_Load(object sender, EventArgs e)
    {


        if (Session["UserID"] != string.Empty && Convert.ToInt32(Session["UserID"].ToString()) > 0)
        {
            if (!IsPostBack)
            {
                ChkAuthentication();
                txtTransporter.Enabled = true;
                Load_ClientsTransporterEMailIDs();
                SqlConnection conn = new SqlConnection(connStr);
                conn.Open();

                dt_CheckAccess = obj_class.Bizconnect_GetAccessPermitedUsers(Convert.ToInt32(Session["UserID"].ToString()));
                if (dt_CheckAccess.Rows.Count == 0)
                {
                   // ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Access Denied');</script>");
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Access Denied');window.location ='Dashboard.aspx';", true);
                    goto x;
                }
                else if (dt_CheckAccess.Rows.Count > 0)
                {

                    try
                    {
                        int clientid = Convert.ToInt32(Session["ClientID"].ToString());
                        string qry = "select ProjectNo from Bizconnect_ProjectMaster where clientid=" + clientid + "  order by CreateDateTimestamp desc ";

                        SqlCommand cmd = new SqlCommand(qry, conn);
                        DataTable dt = new DataTable();
                        SqlDataAdapter adp = new SqlDataAdapter(cmd);

                        ddl_CnGeneratedNo.Visible = false;

                        adp.Fill(dt);
                        ddlProjectNo.DataSource = dt;
                        ddlProjectNo.DataTextField = "ProjectNo";
                        ddlProjectNo.DataValueField = "";
                        ddlProjectNo.DataBind();
                        ddlProjectNo.Items.Insert(0, new ListItem("--Select--", "0"));



                        dtt = DateTime.Now.Date;
                        txtdate.Text = dtt.ToString("dd-MMM-yyyy");
                        txtCNdate.Text = dtt.ToString("dd-MMM-yyyy");
                        GenerateCollectonNoteNumber();


                        ddl_CnGeneratedNo.Visible = false;
                        lbl_RcNo.Visible = false;
                        txt_RcNo.Visible = false;
                        lbl_Rate.Visible = false;
                        txt_Rate.Visible = false;
                        //lbl_Email.Visible = false;
                        ddl_Transporter.Visible = false;
                        Get_CNGenerated();
                    }
                    catch (Exception ex)
                    {
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
        }
        else
        {
            Response.Redirect("Index.html");
        }
    x: ;
    }

    public void Load_ClientsTransporterEMailIDs()
    {
        dt.Clear();
        dt = obj_class.Bizconnect_GetClientsTransporterEMailIDs(Convert.ToInt32(Session["ClientID"].ToString()));
        ddl_Transporter.DataSource = dt;
        ddl_Transporter.DataTextField = "Transporter";
        ddl_Transporter.DataValueField = "TransporterID";
        ddl_Transporter.DataBind();
        ddl_Transporter.Items.Insert(0, "--Select--");
    }

public void Get_CNGenerated()
    {
        dt = obj_class.Bizconnect_Get_CnGeneratedNO();
        ddl_CnGeneratedNo.DataSource = dt;
        ddl_CnGeneratedNo.DataTextField = "AutoNumber";
        ddl_CnGeneratedNo.DataValueField = "CollectionNoteID";
        ddl_CnGeneratedNo.DataBind();
        ddl_CnGeneratedNo.Items.Insert(0, "--Select--");
    }

 public void GenerateCollectonNoteNumber()
    {
        SqlConnection conn = new SqlConnection(connStr);
        conn.Open();
        string qry = "select MAX(CollectionnoteNumber) from CollectionNote";//clientid="+ clientid +" ";

        SqlCommand cmd = new SqlCommand(qry, conn);
        DataSet ds2 = new DataSet();
        SqlDataAdapter adp = new SqlDataAdapter(cmd);

        adp.Fill(ds2);
        txtCNNumber.Text = (Convert.ToInt32(ds2.Tables[0].Rows[0].ItemArray[0].ToString()) + 1).ToString();
    }
    protected void ddlProjectNo_SelectedIndexChanged(object sender, EventArgs e)
    {
     try
        {
        if (ddlProjectNo.SelectedIndex > 0)
        {

            if (ddlProjectNo.SelectedItem.Text.Contains("SPL"))
            {
                if (NeedApproval.Checked == true)
                {
                    ddl_Transporter.Visible = true;
                    ddl_Transporter.SelectedIndex = -1;
                    lbl_TransEmail.Visible = true;
                    txt_TransporterEmail.Visible = true;
                    txt_TransporterEmail.Text = "";
                    txtTransporter.Visible = false;
                }
            }
            else
            {
                ddl_Transporter.Visible = false;
                lbl_TransEmail.Visible = false;
                txt_TransporterEmail.Visible = false;
                txtTransporter.Visible = true;
            }

            DataSet ds = new DataSet();
            ds = obj_class.Get_WBS(ddlProjectNo.SelectedItem.Text.Trim() );
            DDLWBSno.DataSource = ds;
            DDLWBSno.DataTextField = "WBS";
            DDLWBSno.DataBind();
            DDLWBSno.Items.Insert(0, new ListItem("--Select--", "0"));
            
            //Transporter Name
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
                string qry = "select Transporter,ProjectManager,PMMobileNo,siteincharge,siteinchargeMobileno from Bizconnect_ProjectMaster where ProjectNo='"+ ddlProjectNo.SelectedItem.Text +"' ";

                SqlCommand cmd = new SqlCommand(qry, conn);
                DataTable dt = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);

                adp.Fill(dt);

				txtTransporter.Text=dt.Rows[0].ItemArray[0].ToString();
				txt_ManagerName.Text = dt.Rows[0].ItemArray[1].ToString();
                txt_PmContactno.Text = dt.Rows[0].ItemArray[2].ToString();
                txt_Siteinchargename.Text  = dt.Rows[0].ItemArray[3].ToString();
                txt_Inchargecontactno.Text  = dt.Rows[0].ItemArray[4].ToString();
            
        }
        }
        catch (Exception ex)
        {

        }
    }
  
    protected void But_Submit_Click(object sender, EventArgs e)
    {


        try
        {

            if (Convert.ToInt32(txtTruckPlanned.Text) > 0)
            {
                if (rdb_AlterTransporter.Checked == true)
                {
                    //int chk= Checking();
                    int chk = 1;
                    if (chk == 1)
                    {

                        if (ddl_Transporter.SelectedItem.Text != "--Select--")
                        {
                            SendingAltenateTransporterMail();
                            resp = obj_class.InsertBizconnect_CollectionNote(lbl_ProjectNo.Text, lbl_WbsNo.Text, Convert.ToDateTime(txtdate.Text), txtautonumber.Text, txtproject.Text, txtDescription.Text, txttrucktype.Text, Convert.ToInt32(txttransit.Text), Convert.ToDouble(txtlength.Text), Convert.ToDouble(txtwidth.Text), Convert.ToDouble(txtheight.Text), Convert.ToDouble(txtweight.Text), txtbuyer.Text, txtcontactperson.Text, txtcontactnumber.Text, "ALT-" + ddl_Transporter.SelectedItem.Text + "-" + txt_RcNo.Text, txtRemarks.Text, txtFrom.Text, txtTo.Text, Convert.ToInt32(txtTruckPlanned.Text), Convert.ToDouble(txt_Rate.Text), Convert.ToInt32(txtCNNumber.Text), Convert.ToDateTime(txtCNdate.Text), 0, Convert.ToInt32(lbl_SerialNo.Text), Convert.ToInt32(Session["SignID"].ToString()), Convert.ToDouble(txt_Rate.Text) - Convert.ToDouble(txtAgreedPrice.Text), Reasons.ToString(), txt_Buyername.Text, txt_Buyercontactno.Text);
                            //Getting Collection note ID
                            CNID = obj_class.Bizconnect_GetMaxCollectionNoteID();
                            Session["CNID"] = CNID.Rows[0][0].ToString();

                            //SendingAltenateTransporterMail();
                            obj_class.Bizconnect_UpdateCNasCancelled(Convert.ToInt32(ddl_CNNo.SelectedValue), Convert.ToInt32(lbl_SerialNo.Text));

                            if (resp == 1)
                            {
                                GenerateCollectonNoteNumber();
                                ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Collection Note Generated Successfully');</script>");
                            }
                        }
                        else
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Please select the transporter');</script>");
                        }
                    }
                    else
                    {

                        NeedApproval.Checked = true;
                        But_NApproval.Enabled = true;
                        But_Submit.Enabled = false;
                        btn_Amendment.Enabled = false;

                        //code for displaying transporters drop down for spl projects
                        if (NeedApproval.Checked = true && ddlProjectNo.SelectedItem.Text.ToUpper().Contains("SPL"))
                        {
                            txtTransporter.Visible = false;
                            ddl_Transporter.Visible = true;
                            lbl_TransEmail.Visible = true;
                            txt_TransporterEmail.Visible = true;
                        }

                        goto NA;
                    }



                }
                else
                {
                    int chk = Checking();
                    if (chk == 1)
                    {
                        if (FileUpload1.HasFile)
                        {
                            Session["FileCtrl"] = (FileUpload)FileUpload1;
                            FileCtrl = (FileUpload)Session["FileCtrl"];
                        }
                        else
                        {
                            FileCtrl = (FileUpload)Session["FileCtrl"];
                        }
                        // Read the file and convert it to Byte Array

                        //  string filePath = FileCtrl.PostedFile.FileName;

                        // string filename = Path.GetFileName(filePath);

                        //string ext = Path.GetExtension(filename);

                        // string contenttype = String.Empty;



                        //Set the contenttype based on File Extension

                        //  switch (ext)
                        //  {

                        //   case ".JPG":

                        //   contenttype = "image/JPG";

                        //   break;
                        //   case ".JPEG":

                        //  contenttype = "image/JPEG";

                        //  break;

                        //  case ".png":

                        // contenttype = "image/png";

                        // break;

                        //  case ".gif":

                        //  contenttype = "image/gif";

                        // break;



                        // }

                        // if (contenttype != String.Empty)
                        // {

                        //  Stream fs = FileCtrl.PostedFile.InputStream;

                        // BinaryReader br = new BinaryReader(fs);

                        // byte[] bytes = br.ReadBytes((Int32)fs.Length);

                        // int resp = obj_class.InsertBizconnect_CollectionNote(ddlProjectNo.SelectedItem.Text, DDLWBSno.SelectedItem.Text, Convert.ToDateTime(txtdate.Text), txtautonumber.Text, txtproject.Text, txtDescription.Text, txttrucktype.Text, Convert.ToInt32(txttransit.Text), Convert.ToDouble(txtlength.Text), Convert.ToDouble(txtwidth.Text), Convert.ToDouble(txtheight.Text), Convert.ToDouble(txtweight.Text), txtbuyer.Text, txtcontactperson.Text, txtcontactnumber.Text, txtTransporter.Text, txtRemarks.Text, bytes, txtFrom.Text, txtTo.Text, Convert.ToInt32(txtTruckPlanned.Text), Convert.ToDouble(txtAgreedPrice.Text));
                        // SendMail();
                        // ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Collection Note Generated Successfully');</script>");
                        // }

                        Panel1.Visible = true;
                        if (Generate.Checked)
                        {
                            CNNo = obj_class.Bizconnect_CheckCNoteNumberExistsorNot(Convert.ToInt32(txtCNNumber.Text));
                            if (CNNo == 0)
                            {
                                resp = obj_class.InsertBizconnect_CollectionNote(ddlProjectNo.SelectedItem.Text.Trim(), DDLWBSno.SelectedItem.Text, Convert.ToDateTime(txtdate.Text), txtautonumber.Text, txtproject.Text, txtDescription.Text, txttrucktype.Text, Convert.ToInt32(txttransit.Text), Convert.ToDouble(txtlength.Text), Convert.ToDouble(txtwidth.Text), Convert.ToDouble(txtheight.Text), Convert.ToDouble(txtweight.Text), txtbuyer.Text, txtcontactperson.Text, txtcontactnumber.Text, txtTransporter.Text, txtRemarks.Text, txtFrom.Text, txtTo.Text, Convert.ToInt32(txtTruckPlanned.Text), Convert.ToDouble(txtAgreedPrice.Text), Convert.ToInt32(txtCNNumber.Text), Convert.ToDateTime(txtCNdate.Text), 0, Convert.ToInt32(DDLserialno.SelectedItem.Text), Convert.ToInt32(Session["SignID"].ToString()), 0, Reasons.ToString(), txt_Buyername.Text, txt_Buyercontactno.Text);
                                SendMail();
                                if (Club == "No" || Club == "0")
                                {
                                    GenerateCollectonNoteNumber();
                                }
                                ProjectNo = ddlProjectNo.SelectedItem.Text;
                                WBSNo = DDLWBSno.SelectedItem.Text;
                                AutoNo = txtautonumber.Text;
                                ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Collection Note Generated Successfully');</script>");
                            }
                            else
                            {
                                if (Club == "No" || Club == "0")
                                {
                                    GenerateCollectonNoteNumber();
                                }
                                resp = obj_class.InsertBizconnect_CollectionNote(ddlProjectNo.SelectedItem.Text.Trim(), DDLWBSno.SelectedItem.Text, Convert.ToDateTime(txtdate.Text), txtautonumber.Text, txtproject.Text, txtDescription.Text, txttrucktype.Text, Convert.ToInt32(txttransit.Text), Convert.ToDouble(txtlength.Text), Convert.ToDouble(txtwidth.Text), Convert.ToDouble(txtheight.Text), Convert.ToDouble(txtweight.Text), txtbuyer.Text, txtcontactperson.Text, txtcontactnumber.Text, txtTransporter.Text, txtRemarks.Text, txtFrom.Text, txtTo.Text, Convert.ToInt32(txtTruckPlanned.Text), Convert.ToDouble(txtAgreedPrice.Text), Convert.ToInt32(txtCNNumber.Text), Convert.ToDateTime(txtCNdate.Text), 0, Convert.ToInt32(DDLserialno.SelectedItem.Text), Convert.ToInt32(Session["SignID"].ToString()), 0, Reasons.ToString(), txt_Buyername.Text, txt_Buyercontactno.Text);
                                SendMail();
                                if (Club == "No" || Club == "0")
                                {
                                    GenerateCollectonNoteNumber();
                                }
                                ProjectNo = ddlProjectNo.SelectedItem.Text;
                                WBSNo = DDLWBSno.SelectedItem.Text;
                                AutoNo = txtautonumber.Text;
                                ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Collection Note Generated Successfully');</script>");
                            }
                        }
                        else if (rdb_SPLRC.Checked)
                        {
                            CNNo = obj_class.Bizconnect_CheckCNoteNumberExistsorNot(Convert.ToInt32(txtCNNumber.Text));
                            if (CNNo == 0)
                            {
                                resp = obj_class.InsertBizconnect_CollectionNote(ddlProjectNo.SelectedItem.Text.Trim(), DDLWBSno.SelectedItem.Text, Convert.ToDateTime(txtdate.Text), txtautonumber.Text, txtproject.Text, txtDescription.Text, txttrucktype.Text, Convert.ToInt32(txttransit.Text), Convert.ToDouble(txtlength.Text), Convert.ToDouble(txtwidth.Text), Convert.ToDouble(txtheight.Text), Convert.ToDouble(txtweight.Text), txtbuyer.Text, txtcontactperson.Text, txtcontactnumber.Text, "SPL-" + ddl_Transporter.SelectedItem.Text + "-" + txt_RcNo.Text, txtRemarks.Text, txtFrom.Text, txtTo.Text, Convert.ToInt32(txtTruckPlanned.Text), Convert.ToDouble(txtAgreedPrice.Text), Convert.ToInt32(txtCNNumber.Text), Convert.ToDateTime(txtCNdate.Text), 0, Convert.ToInt32(DDLserialno.SelectedItem.Text), Convert.ToInt32(Session["SignID"].ToString()), 0, Reasons.ToString(), txt_Buyername.Text, txt_Buyercontactno.Text);
                                SendingMailForSPLRC();
                                GenerateCollectonNoteNumber();
                                //ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Collection Note Generated Successfully');</script>");
                                this.Page.ClientScript.RegisterStartupScript(typeof(Page), "notification", "window.alert('Collection Note Generated Successfully');", true);
                            }
                            else
                            {
                                GenerateCollectonNoteNumber();
                                resp = obj_class.InsertBizconnect_CollectionNote(ddlProjectNo.SelectedItem.Text.Trim(), DDLWBSno.SelectedItem.Text, Convert.ToDateTime(txtdate.Text), txtautonumber.Text, txtproject.Text, txtDescription.Text, txttrucktype.Text, Convert.ToInt32(txttransit.Text), Convert.ToDouble(txtlength.Text), Convert.ToDouble(txtwidth.Text), Convert.ToDouble(txtheight.Text), Convert.ToDouble(txtweight.Text), txtbuyer.Text, txtcontactperson.Text, txtcontactnumber.Text, "SPL-" + ddl_Transporter.SelectedItem.Text + "-" + txt_RcNo.Text, txtRemarks.Text, txtFrom.Text, txtTo.Text, Convert.ToInt32(txtTruckPlanned.Text), Convert.ToDouble(txtAgreedPrice.Text), Convert.ToInt32(txtCNNumber.Text), Convert.ToDateTime(txtCNdate.Text), 0, Convert.ToInt32(DDLserialno.SelectedItem.Text), Convert.ToInt32(Session["SignID"].ToString()), 0, Reasons.ToString(), txt_Buyername.Text, txt_Buyercontactno.Text);
                                SendingMailForSPLRC();
                                GenerateCollectonNoteNumber();
                                //ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Collection Note Generated Successfully');</script>");
                                this.Page.ClientScript.RegisterStartupScript(typeof(Page), "notification", "window.alert('Collection Note Generated Successfully');", true);
                            }
                        }
                        But_Submit.Enabled = false;

                        Clear();
                    }

                    else
                    {
                        NeedApproval.Checked = true;
                        But_NApproval.Enabled = true;
                        But_Submit.Enabled = false;
                        btn_Amendment.Enabled = false;


                        //code for displaying transporters drop down for spl projects
                        if (NeedApproval.Checked = true && ddlProjectNo.SelectedItem.Text.ToUpper().Contains("SPL"))
                        {
                            txtTransporter.Visible = false;
                            ddl_Transporter.Visible = true;
                            lbl_TransEmail.Visible = true;
                            txt_TransporterEmail.Visible = true;
                        }

                        goto NA;
                    }
                }
            NA: ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('There is a deviation in Collection note Please send for Approval');</script>");
            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(typeof(Page), "notification", "window.alert('Collection note cannot be generated because trucks required should be greater than 0');", true);
            }
        }
        catch (Exception ex)
        {
        }

    }
    
    public void SendingAltenateTransporterMail()
 {
     //Transporter EmailID
     SqlConnection conn = new SqlConnection(connStr);
     conn.Open();
     DataTable dt = new DataTable();
     if (lbl_ProjectNo.Text.Contains("SPL"))
     {
         //string qry1 = "select Transporter   from CollectionNote where CollectionNoteNumber ='" + ddl_CNNo.SelectedItem.Text + "' ";
         dt = obj_class.Bizconnect_GetEmailForAlternateTransporter(Convert.ToInt32(ddl_CNNo.SelectedItem.Text), 1, "");
         string Transporter = dt.Rows[0].ItemArray[0].ToString();
         dt.Clear();
         dt = obj_class.Bizconnect_GetEmailForAlternateTransporter(Convert.ToInt32(ddl_CNNo.SelectedItem.Text), 2, Transporter);
     }

     else
     {
         string qry = "select TransporterEmailID,ProjectManagerEmailID,shippingpersonEmail from Bizconnect_ProjectMaster where ProjectNo='" + lbl_ProjectNo.Text + "' ";
         SqlCommand cmd = new SqlCommand(qry, conn);
         SqlDataAdapter adp = new SqlDataAdapter(cmd);
         adp.Fill(dt);
         ProjectManagerEmail = dt.Rows[0].ItemArray[1].ToString();
         LogisticPersonEmail = dt.Rows[0].ItemArray[2].ToString();
     }

     string TransporterEmail = dt.Rows[0].ItemArray[0].ToString();
     // To Actual Transporter
     string body = " <table style='background-color: #f6f6f6;width: 59%;'> <td  style='width: 650px; display: block !important;max-width: 600px !important;margin: 0 auto !important;clear: both !important;'><div style=' max-width: 600px;margin: 0 auto;display: block;padding: 20px;'><table cellpadding=0 cellspacing=0 style='width:100%;' > <tr> <td> <table  cellpadding=0 cellspacing=0><tr><td><center><img  src=http://www.scmbizconnect.com/images/logo.jpg /></center></td></tr> <tr><td style='padding: 0 0 20px';><h3>Dear Sir,</h3></td></tr><tr><td style=' padding: 0 0 20px;'>The below mention Collection Note number has not been  confirmed and Placed by you,so Thermax Ltd, will cancel the below mention collection note and place the vehicle from alternate source,The differntial amount will be debited from you.Collection Note No :" + ddl_CNNo.SelectedItem.Text + "</td></tr><tr><td style=' padding: 0 0 20px;'><center></center> </br><tr><td style='padding: 0 0 20px;'>Thank You,</td></tr> <tr><td style='width: 656px;' ><a href=http://www.scmbizconnect.com>www.scmbizconnect.com</a></td></tr> </table></td></tr></table></div></td> </table>";
     mail.SendEmail(TransporterEmail.ToString(), "thermax@scmbizconnect.com", "thermax123", ProjectManagerEmail.ToString()+","+ LogisticPersonEmail.ToString (), "", "connect@scmjunction.com", "thermax@scmbizconnect.com", "Collection Note- " + txtCNNumber.Text + "", body, System.Web.Mail.MailFormat.Html, System.Web.Mail.MailPriority.High, "smtp.gmail.com", "465", "2", "1", true, "");
     //mail.SendEmail(TransporterEmail.ToString(), "tripschedule@scmbizconnect.com", "tripschedule123", ProjectManagerEmail.ToString() + "," + LogisticPersonEmail.ToString(), "", "connect@scmjunction.com", "thermax@scmbizconnect.com", "Collection Note- " + txtCNNumber.Text + "", body, System.Web.Mail.MailFormat.Html, System.Web.Mail.MailPriority.High, "smtp.gmail.com", "465", "2", "1", true, "");

     //To Alternate transporter
     string ClientMailbody = "<table style='background-color: #f6f6f6;width: 59%;'> <td  style='width: 650px; display: block !important;max-width: 600px !important;margin: 0 auto !important;clear: both !important;'><div style=' max-width: 600px;margin: 0 auto;display: block;padding: 20px;'><table cellpadding=0 cellspacing=0 style='width:100%;' > <tr> <td> <table  cellpadding=0 cellspacing=0><tr><td><center><img  src=http://www.scmbizconnect.com/images/logo.jpg /></center></td></tr> <tr><td style='padding: 0 0 20px';><h3>Dear Sir,</h3></td></tr><tr><td style=' padding: 0 0 20px;'>The following Description of items against the Project No and the WBS No is ready, to be loaded from the following address and delivered to the address and the indent details is given below : </td></tr><tr><td style=' padding: 0 0 20px;'><center><a style='text-decoration: none;color: #FFF;background-color: #1a88b3;border: solid #1a88b3;border-width: 0px 1px;line-height: 2;font-weight: bold;text-align: center;cursor: pointer;display: inline-block; border-radius: 5px;text-transform: capitalize;'href=http://www.scmbizconnect.com/TripAssignConfirmationWindow.aspx?Confno=0&VR=ALT&CollectionNoteID=" + Session["CNID"].ToString() + "&TrnspID=" + ddl_Transporter.SelectedValue.ToString() + "&CnGen=" + Session["name"].ToString() + " target =_blank>please click here for viewing the CollectionNote details</a></center> <br/><tr><td style='padding: 0 0 20px;'>Thank You,</td></tr> <tr><td style='width: 656px;' ><a href=http://www.scmbizconnect.com>www.scmbizconnect.com</a></td></tr> </table></td></tr></table></div></td> </table>";

     mail.SendEmail(txt_TransporterEmail.Text, "thermax@scmbizconnect.com", "thermax123", "", "", "connect@scmjunction.com", "thermax@scmbizconnect.com", "Collection Note- " + txtautonumber.Text + "", ClientMailbody, System.Web.Mail.MailFormat.Html, System.Web.Mail.MailPriority.High, "smtp.gmail.com", "465", "2", "1", true, "");
     //mail.SendEmail(txt_TransporterEmail.Text, "tripschedule@scmbizconnect.com", "tripschedule123", "", "", "connect@scmjunction.com", "tripschedule@scmbizconnect.com", "Collection Note- " + txtautonumber.Text + "", ClientMailbody, System.Web.Mail.MailFormat.Html, System.Web.Mail.MailPriority.High, "smtp.gmail.com", "465", "2", "1", true, "");
    }
    public void SendingMailForSPLRC()
    {
        //Transporter EmailID
        SqlConnection conn = new SqlConnection(connStr);
        conn.Open();
        string qry = "select TransporterEmailID,ProjectManagerEmailID,shippingpersonEmail from Bizconnect_ProjectMaster where ProjectNo='" + ddlProjectNo.SelectedItem .Text .ToString () + "' ";
        SqlCommand cmd = new SqlCommand(qry, conn);
        DataTable dt = new DataTable();
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        adp.Fill(dt);
        string TransporterEmail = dt.Rows[0].ItemArray[0].ToString();
        string ProjectManagerEmail = dt.Rows[0].ItemArray[1].ToString();
        string LogisticPersonEmail = dt.Rows[0].ItemArray[2].ToString();
        //Collection Note ID
        GetMaxCollectionNoteIDToSendMailID();

        string body = "<table style='background-color: #f6f6f6;width: 59%;'> <td  style='width: 650px; display: block !important;max-width: 600px !important;margin: 0 auto !important;clear: both !important;'><div style=' max-width: 600px;margin: 0 auto;display: block;padding: 20px;'><table cellpadding=0 cellspacing=0 style='width:100%;' > <tr> <td> <table  cellpadding=0 cellspacing=0><tr><td><center><img  src=http://www.scmbizconnect.com/images/logo.jpg /></center></td></tr> <tr><td style='padding: 0 0 20px';><h3>Dear Transporter,</h3></td></tr><tr><td style=' padding: 0 0 20px;'>The following Description of items against the Project No and the WBS No is ready, to be loaded from the following address and delivered to the address mentioned below . </td></tr><tr><td style=' padding: 0 0 20px;'><center><a style='text-decoration: none;color: #FFF;background-color: #1a88b3;border: solid #1a88b3;border-width: 0px 1px;line-height: 2;font-weight: bold;text-align: center;cursor: pointer;display: inline-block; border-radius: 5px;text-transform: capitalize;' href=http://www.scmbizconnect.com/TripAssignConfirmationWindow.aspx?Confno=0&VR=ALT&CollectionNoteID=" + Session["AID"].ToString() + "&TrnspID=" + ddl_Transporter.SelectedValue.ToString() + "&CnGen=" + Session["name"].ToString() + " target =_blank>Please click here for confirming the CollectionNote</a></center> </br><tr><td style='padding: 0 0 20px;'>Thank You,</td></tr> <tr><td style='width: 656px;' ><a href=http://www.scmbizconnect.com>www.scmbizconnect.com</a></td></tr> </table></td></tr></table></div></td> </table>";
        //mail.SendEmail(TransporterEmail.ToString(), "thermax@scmbizconnect.com", "thermax123", ProjectManagerEmail.ToString()+";"+ LogisticPersonEmail.ToString (), "", "connect@scmjunction.com", "thermax@scmbizconnect.com", "Collection Note- " + txtautonumber.Text + "", body, System.Web.Mail.MailFormat.Html, System.Web.Mail.MailPriority.High, "smtp.gmail.com", "465", "2", "1", true, "");
        mail.SendEmail(txt_TransporterEmail.Text, "thermax@scmbizconnect.com", "thermax123", "", "", "connect@scmjunction.com", "thermax@scmbizconnect.com", "Collection Note- " + txtautonumber.Text + "", body, System.Web.Mail.MailFormat.Html, System.Web.Mail.MailPriority.High, "smtp.gmail.com", "465", "2", "1", true, "");
        string ClientMailbody = "<table style='background-color: #f6f6f6;width: 59%;'> <td  style='width: 650px; display: block !important;max-width: 600px !important;margin: 0 auto !important;clear: both !important;'><div style=' max-width: 600px;margin: 0 auto;display: block;padding: 20px;'><table cellpadding=0 cellspacing=0 style='width:100%;' > <tr> <td> <table  cellpadding=0 cellspacing=0><tr><td><center><img  src=http://www.scmbizconnect.com/images/logo.jpg /></center></td></tr> <tr><td style='padding: 0 0 20px';><h3>Dear Sir,</h3></td></tr><tr><td style=' padding: 0 0 20px;'>The following Description of items against the Project No and the WBS No is ready, to be loaded from the following address and delivered to the address and the indent details is given below : </td></tr><tr><td style=' padding: 0 0 20px;'><center><a style='text-decoration: none;color: #FFF;background-color: #1a88b3;border: solid #1a88b3;border-width: 0px 1px;line-height: 2;font-weight: bold;text-align: center;cursor: pointer;display: inline-block; border-radius: 5px;text-transform: capitalize;'href=http://www.scmbizconnect.com/TripAssignConfirmationWindow.aspx?Confno=0&VR=T&CollectionNoteID=" + Session["AID"].ToString() + " target =_blank>Please click here for confirming the CollectionNote</a></center> </br><tr><td style='padding: 0 0 20px;'>Thank You,</td></tr> <tr><td style='width: 656px;' ><a href=http://www.scmbizconnect.com>www.scmbizconnect.com</a></td></tr> </table></td></tr></table></div></td> </table>";
        // string ClientMailbody = "Dear Transporter,<br/><br/>The following Description of items against the Project No and the WBS No is ready, to be loaded from the following address and delivered to the address and the indent details is given below :  <br/><br/><br/><a href=http://www.scmbizconnect.com/TripAssignConfirmationWindow.aspx?Confno=0&VR=ALT&CollectionNoteID=" + Session["CNID"].ToString() + "   target =_blank>please click here for viewing the CollectionNote details.</a><br/>";
        mail.SendEmail(ProjectManagerEmail.ToString(), "thermax@scmbizconnect.com", "thermax123", LogisticPersonEmail.ToString(), "", "connect@scmjunction.com", "thermax@scmbizconnect.com", "Collection Note- " + txtautonumber.Text + "", ClientMailbody, System.Web.Mail.MailFormat.Html, System.Web.Mail.MailPriority.High, "smtp.gmail.com", "465", "2", "1", true, "");
    }


    public void SendMail()
    {
//Transporter EmailID
  SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
string qry = "select TransporterEmailID,ProjectManagerEmailID,ShippingpersonEmail from Bizconnect_ProjectMaster where ProjectNo='"+ ddlProjectNo.SelectedItem.Text +"' ";

                SqlCommand cmd = new SqlCommand(qry, conn);
                DataTable dt = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);




                string TransporterEmail = dt.Rows[0]["TransporterEmailID"].ToString();
                string ProjectManagerEmail = dt.Rows[0]["ProjectManagerEmailID"].ToString();
                string LogisticPersonEmail = dt.Rows[0]["ShippingpersonEmail"].ToString();
//Collection Note ID
GetMaxCollectionNoteIDToSendMailID();

//string body = "Dear Transporter,<br/><br/>The following Description of items against the Project No and the WBS No is ready, to be loaded from the following address and delivered to the address mentioned below .  The approval for change in the indent if any has been obtained and the amended Indent details is given below :  <br/><br/><br/><a href=http://www.scmbizconnect.com/TripAssignConfirmationWindow.aspx?Confno=0&VR=TP&CollectionNoteID=" + Session["AID"].ToString() + "   target =_blank>Please click here for confirming the CollectionNote.</a><br/><a href=<a href=http://www.scmbizconnect.com/CollectionNotePrint.aspx?ImageID=" + Session["AID"].ToString() + " target =_blank  >Please click here for downloading the Collection Note.</a> ";
string body = "<table style='background-color: #f6f6f6;width: 59%;'> <td  style='width: 650px; display: block !important;max-width: 600px !important;margin: 0 auto !important;clear: both !important;'><div style=' max-width: 600px;margin: 0 auto;display: block;padding: 20px;'><table cellpadding=0 cellspacing=0 style='width:100%;' > <tr> <td> <table  cellpadding=0 cellspacing=0><tr><td><center><img  src=http://www.scmbizconnect.com/images/logo.jpg /></center></td></tr> <tr><td style='padding: 0 0 20px';><h3>Dear Transporter,</h3></td></tr><tr><td style=' padding: 0 0 20px;'>The following Description of items against the Project No and the WBS No is ready, to be loaded from the following address and delivered to the address mentioned below .  The approval for change in the indent if any has been obtained and the amended Indent details is given below :  </td></tr><tr><td style=' padding: 0 0 20px;'><center><a style='text-decoration: none;color: #FFF;background-color: #1a88b3;border: solid #1a88b3;border-width: 0px 1px;line-height: 2;font-weight: bold;text-align: center;cursor: pointer;display: inline-block; border-radius: 5px;text-transform: capitalize;'href=http://www.scmbizconnect.com/TripAssignConfirmationWindow.aspx?Confno=0&VR=TP&CollectionNoteID=" + Session["AID"].ToString() + "&CnGen=" + Session["name"].ToString() + " target =_blank> Please click here for confirming the CollectionNote</a></center> </br></tr><tr><td style='padding: 0 0 20px;'>Thank You,</td></tr> <tr><td style='width: 656px;' ><a href=http://www.scmbizconnect.com>www.scmbizconnect.com</a></td></tr> </table></td></tr></table></div></td> </table>";
string ClientMailbody = "<table style='background-color: #f6f6f6;width: 59%;'> <td  style='width: 650px; display: block !important;max-width: 600px !important;margin: 0 auto !important;clear: both !important;'><div style=' max-width: 600px;margin: 0 auto;display: block;padding: 20px;'><table cellpadding=0 cellspacing=0 style='width:100%;' > <tr> <td> <table  cellpadding=0 cellspacing=0><tr><td><center><img  src=http://www.scmbizconnect.com/images/logo.jpg /></center></td></tr> <tr><td style='padding: 0 0 20px';><h3>Dear Sir/Madam,</h3></td></tr><tr><td style=' padding: 0 0 20px;'>The following Description of items against the Project No and the WBS No is ready, to be loaded from the following address and delivered to the address and the indent details is given below :  </td></tr><tr><td style=' padding: 0 0 20px;'><center><a style='text-decoration: none;color: #FFF;background-color: #1a88b3;border: solid #1a88b3;border-width: 0px 1px;line-height: 2;font-weight: bold;text-align: center;cursor: pointer;display: inline-block; border-radius: 5px;text-transform: capitalize;' href=http://www.scmbizconnect.com/TripAssignConfirmationWindow.aspx?Confno=0&VR=T&CollectionNoteID=" + Session["AID"].ToString() + " target =_blank>please click here for viewing the CollectionNote details.</a></center> </br></tr><tr><td style='padding: 0 0 20px;'>Thank You,</td></tr> <tr><td style='width: 656px;' ><a href=http://www.scmbizconnect.com>www.scmbizconnect.com</a></td></tr> </table></td></tr></table></div></td> </table>";
      mail.SendEmail(TransporterEmail.ToString(), "thermax@scmbizconnect.com", "thermax123", "", "", "connect@scmjunction.com", "thermax@scmbizconnect.com", "Collection Note- " + txtCNNumber.Text + "", body, System.Web.Mail.MailFormat.Html, System.Web.Mail.MailPriority.High, "smtp.gmail.com", "465", "2", "1", true, "");
      mail.SendEmail(ProjectManagerEmail.ToString() + ";" + LogisticPersonEmail.ToString(), "thermax@scmbizconnect.com", "thermax123", "", "", "connect@scmjunction.com", "thermax@scmbizconnect.com", "Collection Note- " + txtautonumber.Text + "", ClientMailbody, System.Web.Mail.MailFormat.Html, System.Web.Mail.MailPriority.High, "smtp.gmail.com", "465", "2", "1", true, "");
//mail.SendEmail(TransporterEmail.ToString(), "tripschedule@scmbizconnect.com", "tripschedule123", "", "", "connect@scmjunction.com", "thermax@scmbizconnect.com", "Collection Note- " + txtCNNumber.Text + "", body, System.Web.Mail.MailFormat.Html, System.Web.Mail.MailPriority.High, "smtp.gmail.com", "465", "2", "1", true, "");
//mail.SendEmail(ProjectManagerEmail.ToString() + ";" + LogisticPersonEmail.ToString(), "tripschedule@scmbizconnect.com", "tripschedule123", "", "", "connect@scmjunction.com", "thermax@scmbizconnect.com", "Collection Note- " + txtautonumber.Text + "", ClientMailbody, System.Web.Mail.MailFormat.Html, System.Web.Mail.MailPriority.High, "smtp.gmail.com", "465", "2", "1", true, "");
       //mail.SendEmail("aarms_logistics@aarmscmsolutions.com", "thermax@scmbizconnect.com", "thermax123", "", "", "connect@scmjunction.com", "thermax@scmbizconnect.com", "Collection Note- " + txtautonumber.Text + "", body, System.Web.Mail.MailFormat.Html, System.Web.Mail.MailPriority.High, "smtp.gmail.com", "465", "2", "1", true, "");

    }

    public void  GetMaxCollectionNoteIDToSendMailID()
    {
        SqlConnection conn = new SqlConnection(connStr);
        conn.Open();
        int AID = 0;
        string qry = "select MAX(Collectionnoteid) from CollectionNote";//clientid="+ clientid +" ";

        SqlCommand cmd = new SqlCommand(qry, conn);
        DataSet ds1 = new DataSet();
        SqlDataAdapter adp = new SqlDataAdapter(cmd);

        adp.Fill(ds1);

        if (ds1.Tables[0].Rows[0].ItemArray[0].ToString() == "0")
        {
            AID = 1;

        }
        else
        {
            AID = Convert.ToInt32(ds1.Tables[0].Rows[0].ItemArray[0].ToString());
        }

        Session["AID"] = AID.ToString();
    }

    protected void DDLWBSno_SelectedIndexChanged(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(connStr);
        conn.Open();
        int AID = 0;
        string qry = "select MAX(Collectionnoteid) from CollectionNote";//clientid="+ clientid +" ";

        SqlCommand cmd = new SqlCommand(qry, conn);
        DataSet ds1 = new DataSet();
        SqlDataAdapter adp = new SqlDataAdapter(cmd);

        adp.Fill(ds1);

        if (ds1.Tables[0].Rows[0].ItemArray[0].ToString()== "0")
        {
            AID = 1;
            
        }
        else
        {
            AID = Convert.ToInt32(ds1.Tables[0].Rows[0].ItemArray[0].ToString()) + 1;
        }

        Session["AID"] = AID.ToString();
        txtautonumber.Text = ddlProjectNo.SelectedItem.Text + "/" + DDLWBSno.Text + "/" + "00" + AID.ToString();
        DataSet ds = new DataSet();
        ds = obj_class.Get_SerialNo(ddlProjectNo.SelectedItem.Text.Trim(),DDLWBSno.SelectedItem.Text.Trim() );
        DDLserialno.DataSource = ds;
        DDLserialno.DataTextField = "SerialNo";
        DDLserialno.DataBind();
        DDLserialno.Items.Insert(0, new ListItem("--Select--", "0"));

    }
    protected void link_preview_Click(object sender, EventArgs e)
    {
         if (FileUpload1.HasFile)
            {
                Session["FileCtrl"] = (FileUpload)FileUpload1;
                 FileCtrl = (FileUpload)Session["FileCtrl"];
                string path = Server.MapPath("TempImages");

                FileInfo oFileInfo = new FileInfo(FileUpload1.PostedFile.FileName);
                string fileName = oFileInfo.Name;

                string fullFileName = path + "\\" + fileName;
                string imagePath = "TempImages/" + fileName;

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                FileUpload1.PostedFile.SaveAs(fullFileName);
               
            }
      
          
            OpenNewWindow();
        }
    
    public void OpenNewWindow()
    {


        ClientScript.RegisterStartupScript(this.GetType(), "OpenWin", "<script>window.open('CollectionNoteImage.aspx', 'mynewwin', 'width=950,height=350,scrollbars=yes,toolbar=1')</script>");
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
    
    
    
     protected void ButYes_Click(object sender, EventArgs e)
    {
         But_Submit.Enabled = true ;
        Panel1.Visible = false;

        GetCNNoForClubbing();
        ClearFields();
        txtautonumber.Text = "";
        Club = "Yes";
       
    }
    protected void ButNo_Click(object sender, EventArgs e)
    {
         But_Submit.Enabled = true ;
        Panel1.Visible = false;
        GenerateCollectonNoteNumber();
        Club = "No";
    }
    
    
       protected void But_NApproval_Click(object sender, EventArgs e)
    {
if(txtjustification .Text !="")
{
 for (int i = 0; i < 4; i++)
        {
            if (Chkjustification.Items[i].Selected == true)
            {
                Reasons=Reasons+"; "+Chkjustification.Items[i].Text ;
            }
        }

 if (ddlProjectNo.SelectedItem.Text.Contains("SPL"))
 {
     if (ddl_Transporter.SelectedItem.Text != "--Select--")
     {
         CNNo = obj_class.Bizconnect_CheckCNoteNumberExistsorNot(Convert.ToInt32(txtCNNumber.Text));
         if (CNNo == 0)
         {
             resp = obj_class.InsertBizconnect_CollectionNote(ddlProjectNo.SelectedItem.Text, DDLWBSno.SelectedItem.Text, Convert.ToDateTime(txtdate.Text), txtautonumber.Text, txtproject.Text, txtDescription.Text, txttrucktype.Text, Convert.ToInt32(txttransit.Text), Convert.ToDouble(txtlength.Text), Convert.ToDouble(txtwidth.Text), Convert.ToDouble(txtheight.Text), Convert.ToDouble(txtweight.Text), txtbuyer.Text, txtcontactperson.Text, txtcontactnumber.Text, ddl_Transporter.SelectedItem.Text, txtRemarks.Text, txtFrom.Text, txtTo.Text, Convert.ToInt32(txtTruckPlanned.Text), Convert.ToDouble(txtAgreedPrice.Text), Convert.ToInt32(txtCNNumber.Text), Convert.ToDateTime(txtCNdate.Text), 4, Convert.ToInt32(DDLserialno.SelectedItem.Text), Convert.ToInt32(Session["SignID"].ToString()), 0, Reasons.ToString(), txt_Buyername.Text, txt_Buyercontactno.Text);
             SendApprovalMail();
             GenerateCollectonNoteNumber();
             ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Collection Note Send for Approval');</script>");
             Clear();
             But_NApproval.Enabled = false;
             btn_Amendment.Enabled = false;
         }
         else
         {
             GenerateCollectonNoteNumber();
             resp = obj_class.InsertBizconnect_CollectionNote(ddlProjectNo.SelectedItem.Text, DDLWBSno.SelectedItem.Text, Convert.ToDateTime(txtdate.Text), txtautonumber.Text, txtproject.Text, txtDescription.Text, txttrucktype.Text, Convert.ToInt32(txttransit.Text), Convert.ToDouble(txtlength.Text), Convert.ToDouble(txtwidth.Text), Convert.ToDouble(txtheight.Text), Convert.ToDouble(txtweight.Text), txtbuyer.Text, txtcontactperson.Text, txtcontactnumber.Text, ddl_Transporter.SelectedItem.Text, txtRemarks.Text, txtFrom.Text, txtTo.Text, Convert.ToInt32(txtTruckPlanned.Text), Convert.ToDouble(txtAgreedPrice.Text), Convert.ToInt32(txtCNNumber.Text), Convert.ToDateTime(txtCNdate.Text), 4, Convert.ToInt32(DDLserialno.SelectedItem.Text), Convert.ToInt32(Session["SignID"].ToString()), 0, Reasons.ToString(), txt_Buyername.Text, txt_Buyercontactno.Text);
             SendApprovalMail();
             GenerateCollectonNoteNumber();
             ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Collection Note Send for Approval');</script>");
             Clear();
             But_NApproval.Enabled = false;
             btn_Amendment.Enabled = false;
         }
     }
     else
     {
         ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Select Transporter');</script>");
     }
 }
 else
 {
     CNNo = obj_class.Bizconnect_CheckCNoteNumberExistsorNot(Convert.ToInt32(txtCNNumber.Text));
     if (CNNo == 0)
     {
         resp = obj_class.InsertBizconnect_CollectionNote(ddlProjectNo.SelectedItem.Text, DDLWBSno.SelectedItem.Text, Convert.ToDateTime(txtdate.Text), txtautonumber.Text, txtproject.Text, txtDescription.Text, txttrucktype.Text, Convert.ToInt32(txttransit.Text), Convert.ToDouble(txtlength.Text), Convert.ToDouble(txtwidth.Text), Convert.ToDouble(txtheight.Text), Convert.ToDouble(txtweight.Text), txtbuyer.Text, txtcontactperson.Text, txtcontactnumber.Text, txtTransporter.Text, txtRemarks.Text, txtFrom.Text, txtTo.Text, Convert.ToInt32(txtTruckPlanned.Text), Convert.ToDouble(txtAgreedPrice.Text), Convert.ToInt32(txtCNNumber.Text), Convert.ToDateTime(txtCNdate.Text), 4, Convert.ToInt32(DDLserialno.SelectedItem.Text), Convert.ToInt32(Session["SignID"].ToString()), 0, Reasons.ToString(), txt_Buyername.Text, txt_Buyercontactno.Text);
         SendApprovalMail();
         GenerateCollectonNoteNumber();
         ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Collection Note Send for Approval');</script>");
         Clear();
         But_NApproval.Enabled = false;
         btn_Amendment.Enabled = false;
     }
     else
     {
         GenerateCollectonNoteNumber();
         resp = obj_class.InsertBizconnect_CollectionNote(ddlProjectNo.SelectedItem.Text, DDLWBSno.SelectedItem.Text, Convert.ToDateTime(txtdate.Text), txtautonumber.Text, txtproject.Text, txtDescription.Text, txttrucktype.Text, Convert.ToInt32(txttransit.Text), Convert.ToDouble(txtlength.Text), Convert.ToDouble(txtwidth.Text), Convert.ToDouble(txtheight.Text), Convert.ToDouble(txtweight.Text), txtbuyer.Text, txtcontactperson.Text, txtcontactnumber.Text, txtTransporter.Text, txtRemarks.Text, txtFrom.Text, txtTo.Text, Convert.ToInt32(txtTruckPlanned.Text), Convert.ToDouble(txtAgreedPrice.Text), Convert.ToInt32(txtCNNumber.Text), Convert.ToDateTime(txtCNdate.Text), 4, Convert.ToInt32(DDLserialno.SelectedItem.Text), Convert.ToInt32(Session["SignID"].ToString()), 0, Reasons.ToString(), txt_Buyername.Text, txt_Buyercontactno.Text);
         SendApprovalMail();
         GenerateCollectonNoteNumber();
         ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Collection Note Send for Approval');</script>");
         Clear();
         But_NApproval.Enabled = false;
         btn_Amendment.Enabled = false;
     }
 }
   }
   else
   {
    ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Enter Justification');</script>");
   }
  
    }


    public void SendApprovalMail()
    {
        SqlConnection conn = new SqlConnection(connStr);
        conn.Open();
        string qry = "select LogisticManagerEmail,approvalpersonemail from Bizconnect_ProjectMaster where ProjectNo='" + ddlProjectNo.SelectedItem.Text + "' ";

        SqlCommand cmd = new SqlCommand(qry, conn);
        DataTable dt = new DataTable();
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        adp.Fill(dt);
        string LogisticsManager = dt.Rows[0].ItemArray[0].ToString();
        string ApprovalPerson = dt.Rows[0].ItemArray[1].ToString();
        //Collection Note ID
        string LogisticsManager1 = LogisticsManager + "," + "thermaxbabu@gmail.com" + "," + "babu.thomas@thermaxglobal.com";
        GetMaxCollectionNoteIDToSendMailID();
        string body;
        if (ddlProjectNo.SelectedItem.Text.Contains("SPL"))
        {
            body = "<table style='background-color: #f6f6f6;width: 59%;'> <td  style='width: 650px; display: block !important;max-width: 600px !important;margin: 0 auto !important;clear: both !important;'><div style=' max-width: 600px;margin: 0 auto;display: block;padding: 20px;'><table cellpadding=0 cellspacing=0 style='width:100%;' > <tr> <td> <table  cellpadding=0 cellspacing=0><tr><td><center><img  src=http://www.scmbizconnect.com/images/logo.jpg /></center></td></tr> <tr><td style='padding: 0 0 20px';><h3>Dear Sir/Madam,</h3></td></tr><tr><td style=' padding: 0 0 20px;'>The below mention collection note required your approval.\n\n Note:" + txtjustification.Text + "  </td></tr><tr><td style=' padding: 0 0 20px;'><center><a style='text-decoration: none;color: #FFF;background-color: #1a88b3;border: solid #1a88b3;border-width: 0px 1px;line-height: 2;font-weight: bold;text-align: center;cursor: pointer;display: inline-block; border-radius: 5px;text-transform: capitalize;' href=http://www.scmbizconnect.com/ColllectionNoteApproval.aspx?Confno=4&CollectionNoteID=" + Session["AID"].ToString() + "&TrnspID=" + ddl_Transporter.SelectedValue.ToString() + ">Please click here for approve the collectionnote</a></center> </br><tr><td style='padding: 0 0 20px;'>Thank You,</td></tr> <tr><td style='width: 656px;' ><a href=http://www.scmbizconnect.com>www.scmbizconnect.com</a></td></tr> </table></td></tr></table></div></td> </table>";
        }
        else
        {
            body = " <table style='background-color: #f6f6f6;width: 59%;'> <td  style='width: 650px; display: block !important;max-width: 600px !important;margin: 0 auto !important;clear: both !important;'><div style=' max-width: 600px;margin: 0 auto;display: block;padding: 20px;'><table cellpadding=0 cellspacing=0 style='width:100%;' > <tr> <td> <table  cellpadding=0 cellspacing=0><tr><td><center><img  src=http://www.scmbizconnect.com/images/logo.jpg /></center></td></tr> <tr><td style='padding: 0 0 20px';><h3>Dear Sir/Madam,</h3></td></tr><tr><td style=' padding: 0 0 20px;'>The below mention collection note required your approval.\n\n Note:" + txtjustification.Text + " </td></tr><tr><td style=' padding: 0 0 20px;'><center><a style='text-decoration: none;color: #FFF;background-color: #1a88b3;border: solid #1a88b3;border-width: 0px 1px;line-height: 2;font-weight: bold;text-align: center;cursor: pointer;display: inline-block; border-radius: 5px;text-transform: capitalize;'href=http://www.scmbizconnect.com/ColllectionNoteApproval.aspx?Confno=4&CollectionNoteID=" + Session["AID"].ToString() + ">Please click here for approve the collectionnote</a></center> </br><tr><td style='padding: 0 0 20px;'>Thank You,</td></tr> <tr><td style='width: 656px;' ><a href=http://www.scmbizconnect.com>www.scmbizconnect.com</a></td></tr> </table></td></tr></table></div></td> </table>";
        }

        mail.SendEmail(LogisticsManager1.ToString(), "thermax@scmbizconnect.com", "thermax123", ApprovalPerson.ToString(), "", "connect@scmjunction.com", "thermax@scmbizconnect.com", "Collection Note- " + txtCNNumber.Text + "", body, System.Web.Mail.MailFormat.Html, System.Web.Mail.MailPriority.High, "smtp.gmail.com", "465", "2", "1", true, "");

        try
        {
            mail.SendEmail(LogisticsManager1.ToString(), "thermax@scmbizconnect.com", "thermax123", ApprovalPerson.ToString(), "", "connect@scmjunction.com", "thermax@scmbizconnect.com", "Collection Note- " + txtCNNumber.Text + "", body, System.Web.Mail.MailFormat.Html, System.Web.Mail.MailPriority.High, "smtp.gmail.com", "465", "2", "1", true, "");
        }
        catch
        {
            //rakesh 587
            mail.SendEmail(LogisticsManager1.ToString(), "thermax@scmbizconnect.com", "thermax123", ApprovalPerson.ToString(), "", "connect@scmjunction.com", "thermax@scmbizconnect.com", "Collection Note- " + txtCNNumber.Text + "", body, System.Web.Mail.MailFormat.Html, System.Web.Mail.MailPriority.High, "smtp.gmail.com", "587", "2", "1", true, "");
        }

    }
     protected void DDLserialno_SelectedIndexChanged(object sender, EventArgs e)
    {
         DataSet ds = new DataSet();
        ds = obj_class.Bizconnet_GetIndentDetails(ddlProjectNo.SelectedItem.Text.Trim(), DDLWBSno.SelectedItem.Text.Trim(),Convert.ToInt32(DDLserialno.SelectedItem.Text.Trim()));
        txtDescription.Text = ds.Tables[0].Rows[0]["DESCRIPTION"].ToString();
        txttrucktype.Text = ds.Tables[0].Rows[0]["TruckType"].ToString();
        txttransit.Text = ds.Tables[0].Rows[0]["TransitDays"].ToString();
        txtlength.Text = ds.Tables[0].Rows[0]["Length_m"].ToString();
       Session["Length"] = Convert.ToSingle(txtlength.Text) + (Convert.ToSingle(txtlength.Text) *10 / 100);
        txtwidth.Text = ds.Tables[0].Rows[0]["Width_m"].ToString();
        Session["Width"] = Convert.ToSingle(txtwidth.Text) + (Convert.ToSingle(txtwidth.Text) * 10 / 100);
        txtheight.Text = ds.Tables[0].Rows[0]["Height_m"].ToString();
        Session["Height"] = Convert.ToSingle(txtheight.Text) + (Convert.ToSingle(txtheight.Text) * 10 / 100);
        txtweight.Text =ds.Tables[0].Rows[0]["totalweightinton"].ToString();
        Session["Weight"] = Convert.ToDouble(txtweight.Text)+0.5;
        //txtproject.Text = ddlProjectNo.SelectedValue.ToString();
        txtproject.Text = ds.Tables[0].Rows[0]["ProjectName"].ToString();
        txtFrom.Text = ds.Tables[0].Rows[0]["LoadingPoint"].ToString();
        txtTo.Text = ds.Tables[0].Rows[0]["PlaceofDelivery"].ToString();
        Session["To"] = txtTo.Text;
        txtAgreedPrice.Text = ds.Tables[0].Rows[0]["TotalAmount"].ToString();
        txtTruckPlanned.Text = ds.Tables[0].Rows[0]["TrucksPlanned"].ToString();
        LblTruckscontructed.Text= txtTruckPlanned.Text;
        int trucksassign = obj_class.Get_Remaining_Trucks(Convert.ToInt32(DDLserialno.SelectedItem.Text), ddlProjectNo.SelectedItem.Text, DDLWBSno.SelectedItem.Text);
        LblTruckAssigned.Text =trucksassign.ToString();
        lblTrucksRemainder.Text =(Convert.ToInt32(LblTruckscontructed.Text)-Convert.ToInt32(trucksassign.ToString())).ToString();
        dtt = DateTime.Now.Date;
        txtdate.Text = dtt.ToString("dd-MMM-yyyy");

    }
    public void Clear()
    {
        ddlProjectNo.SelectedIndex = 0;
        DDLWBSno.SelectedIndex = 0;
        DDLserialno.SelectedIndex = 0;
        txtDescription.Text = "";
        txttrucktype.Text = "";
        txttransit.Text = "";
        txtlength.Text = "";
        txtwidth.Text = "";
        txtheight.Text = "";
        txtweight.Text = "";
        txtTransporter.Text = "NTC";
        txtproject.Text = "GIRIJA ALLOY";
        txtFrom.Text = "";
        txtTo.Text = "AP";
        txtAgreedPrice.Text = "";
        txtTruckPlanned.Text = "";
        txtbuyer.Text = "";
        txtcontactnumber.Text = "";
        txtcontactperson.Text = "";
        txtRemarks.Text = "";
        txtjustification.Text = "";
        
       //txt_ManagerName.Text="";
        //txt_PmContactno.Text="";
        //txt_Siteinchargename.Text="";
        //txt_Inchargecontactno.Text="";
    }
    protected void LinkEdit_Click(object sender, EventArgs e)
    {
      SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
    string qry2 = "select distinct TruckType   from Bizconnect.dbo.Bizconnect_TripIndent  where ProjectNo='"+ ddlProjectNo.SelectedItem.Text +"' ";

               SqlCommand cmd1 = new SqlCommand(qry2, conn);
               DataTable dt1 = new DataTable();
               SqlDataAdapter adp1 = new SqlDataAdapter(cmd1);

               adp1.Fill(dt1);
               DDLTruckType.Items.Clear();
               DDLTruckType.DataSource = dt1;
               DDLTruckType.DataTextField = "TruckType";
               DDLTruckType.DataBind();
               DDLTruckType.Items.Insert(0, new ListItem("--Select--", "0"));
        DDLTruckType.Visible = true;
              DDLTruckType.SelectedIndex = -1; 
        DDLTruckType.ClearSelection();
        NeedApproval.Checked=true;
        Generate.Checked=false;
        rdb_Amendment.Checked=false;
        rdb_AlterTransporter.Checked=false;
        But_NApproval.Enabled=true;
        But_Submit.Enabled=false;
        btn_Amendment.Enabled=false;


        if (NeedApproval.Checked = true && ddlProjectNo.SelectedItem.Text.ToUpper().Contains("SPL"))
        {
            txtTransporter.Visible = false;
            ddl_Transporter.Visible = true;
            lbl_TransEmail.Visible = true;
            txt_TransporterEmail.Visible = true;
        }
        
    }
    protected void DDLTruckType_SelectedIndexChanged(object sender, EventArgs e)
    {
        txttrucktype.Text = DDLTruckType.SelectedItem.Text;
        DDLTruckType.Visible = false;
    }
    
    
     protected void Generate_CheckedChanged(object sender, EventArgs e)
    {
But_NApproval.Enabled=false;
But_Submit.Enabled=true;

LinkEdit.Visible=true;
txtautonumber.Visible = true;
txtautonumber.Text = "";
   btn_Amendment.Enabled = false;
    lbl_RcNo.Visible =false;
                txt_RcNo.Visible =false;
                lbl_Rate.Visible = false;
                txt_Rate.Visible = false;
                ddl_CnGeneratedNo.Visible =false;
   ClearFields();
   dtt = DateTime.Now.Date;
txtCNdate.Text = dtt.ToString("dd-MMM-yyyy");
 ddlProjectNo.Enabled = true;
  DDLWBSno.Enabled = true;
    DDLserialno.Enabled = true;
    DDLTruckType.Visible = false;
    //lbl_Email.Visible = false;
    ddl_Transporter.Visible = false;
     GenerateCollectonNoteNumber();
     txtTransporter.Enabled = true;
     txtTransporter.Visible = true;
     lbl_TransEmail.Visible = false;
     txt_TransporterEmail.Visible = false;
     ddl_CNNo.Visible = false;
     txtCNNumber.Visible = true;
    }
    protected void NeedApproval_CheckedChanged(object sender, EventArgs e)
    {
        ddl_CNNo.Visible = false;
        txtCNNumber.Visible = true;
But_NApproval.Enabled=true;
ddl_CnGeneratedNo.Visible = false;
But_Submit.Enabled=false;
txtFrom.ReadOnly=true;
txtTo.ReadOnly=true;
txtTruckPlanned.ReadOnly=true;
txtlength.ReadOnly=true;
txtwidth.ReadOnly=true;
txtheight.ReadOnly=true;
txtweight.ReadOnly=true;
LinkEdit.Visible=true;
 ddlProjectNo.Enabled = true;
  DDLWBSno.Enabled = true;
    DDLserialno.Enabled = true;
txtautonumber.Visible = true;
txtautonumber.Text = "";
   btn_Amendment.Enabled = false;
    lbl_RcNo.Visible =false;
                txt_RcNo.Visible =false;
                lbl_Rate.Visible = false;
                txt_Rate.Visible = false;
                //lbl_Email.Visible = false;
                ddl_Transporter.Visible = false;
   ClearFields();
   dtt = DateTime.Now.Date;
txtCNdate.Text = dtt.ToString("dd-MMM-yyyy");
DDLTruckType.Visible = false;
             GenerateCollectonNoteNumber();
             txtTransporter.Enabled = true;
             txtTransporter.Visible = true;
             lbl_TransEmail.Visible = false;
             txt_TransporterEmail.Visible = false;
    }

    protected void rdb_Amendment_CheckedChanged(object sender, EventArgs e)
    {
        dt_CheckAccess = obj_class.Bizconnect_GetAccessPermitedUsers(Convert.ToInt32(Session["UserID"].ToString()));
        if (dt_CheckAccess.Rows.Count == 0)
        {

        }
        else
        {
            ddl_CNNo.Visible = true;
            ddl_CnGeneratedNo.SelectedIndex = -1;
            txtautonumber.Visible = true;
            txtCNNumber.Visible = false;
            txtautonumber.Text = "";
            ddl_CnGeneratedNo.Visible = false;
            But_NApproval.Enabled = false;
            But_Submit.Enabled = false;
            btn_Amendment.Enabled = true;
            LinkEdit.Visible = true;
            txtCNdate.Text = "";
            txtCNNumber.Text = "";
            lbl_RcNo.Visible = false;
            txt_RcNo.Visible = false;
            lbl_Rate.Visible = false;
            txt_Rate.Visible = false;
            DDLTruckType.Visible = false;
            //lbl_Email.Visible = false;
            ddl_Transporter.Visible = false;
            ClearFields();
            Get_CNNo();
            txtTransporter.Enabled = true;
            txtTransporter.Visible = true;
            lbl_TransEmail.Visible = false;
            txt_TransporterEmail.Visible = false;
        }
    }

     public void Get_CNNo()
     {
         dt = obj_class.Bizconnect_Get_CNNumber();
         ddl_CNNo.DataSource = dt;
         ddl_CNNo.DataTextField = "CollectionNoteNumber";
         ddl_CNNo.DataValueField = "CollectionNoteID";
         ddl_CNNo.DataBind();
         ddl_CNNo.Items.Insert(0, "--Select--");
     }

    protected void ddl_CnGeneratedNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            dt.Clear();
            dt = obj_class.Bizconnect_Get_CollectionDetails(ddl_CnGeneratedNo.SelectedItem.Text);
            txtCNdate.Text = dt.Rows[0][0].ToString();
            txtCNNumber.Text = dt.Rows[0][1].ToString();
            lbl_ProjectNo.Text = dt.Rows[0][2].ToString();
            ddlProjectNo.Enabled = false;
            lbl_WbsNo .Text  = dt.Rows[0][3].ToString();
            DDLWBSno.Enabled = false;
            lbl_SerialNo .Text = dt.Rows[0][4].ToString();
            DDLserialno.Enabled = false;
            txtdate.Text = dt.Rows[0][5].ToString();
            txtproject.Text = dt.Rows[0][6].ToString();
            txtDescription.Text = dt.Rows[0][7].ToString();
            txttrucktype.Text = dt.Rows[0][8].ToString();
            txttransit.Text = dt.Rows[0][9].ToString();
            txtFrom.Text = dt.Rows[0][10].ToString();
            txtTo.Text = dt.Rows[0][11].ToString();
            txtTruckPlanned.Text = dt.Rows[0][12].ToString();
            txtlength.Text = dt.Rows[0][13].ToString();
            txtwidth.Text = dt.Rows[0][14].ToString();
            txtheight.Text = dt.Rows[0][15].ToString();
            txtweight.Text = dt.Rows[0][16].ToString();
            txtbuyer.Text = dt.Rows[0][17].ToString();
            txtcontactperson.Text = dt.Rows[0][18].ToString();
            txtcontactnumber.Text = dt.Rows[0][19].ToString();
            txtTransporter.Text = dt.Rows[0][20].ToString();
            txtRemarks.Text = dt.Rows[0][21].ToString();
            Get_AgreedPrice();
        }
        catch (Exception ex)
        {

        }
    }
    
     public void Get_AgreedPrice()
     {
         DataSet ds = new DataSet();
         ds = obj_class.Bizconnet_GetIndentDetails(lbl_ProjectNo.Text, lbl_WbsNo.Text, Convert.ToInt32(lbl_SerialNo.Text));
         txtAgreedPrice.Text = ds.Tables[0].Rows[0].ItemArray[8].ToString();
     }

    protected void btn_Amendment_Click(object sender, EventArgs e)
    {
        int res;

        res = obj_class.Bizconnect_UpdateCNAmendment(Convert.ToInt32(ddl_CNNo.SelectedValue));
        if (res == 1)
        {
            this.Page.ClientScript.RegisterStartupScript(typeof(Page), "notification", "window.alert('Amendment Submitted Successfully');", true);
            //ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Amendment Submitted Successfully ');</script>");

            //ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Collection Note Generated Successfully');</script>");
            ClearFields();
        }
    }

    public void ClearFields()
    {
        ddlProjectNo.SelectedIndex = -1;
        ddlProjectNo.ClearSelection();
          DDLserialno.SelectedIndex =-1;
          ddlProjectNo.ClearSelection();
          DDLWBSno.SelectedIndex =-1;
          DDLWBSno.ClearSelection();
        txtDescription.Text = "";
        txttrucktype.Text = "";
        txttransit.Text = "";
        txtlength.Text = "";
        txtwidth.Text = "";
        txtheight.Text = "";
        txtweight.Text = "";
        txtTransporter.Text = "";
        txtproject.Text = "";
        txtdate.Text="";
        lbl_WbsNo.Text = "";
        lbl_ProjectNo.Text="";
        lbl_SerialNo .Text="";
        //txtCNdate.Text = "";
        //txtCNNumber.Text = "";
        txtFrom.Text = "";
        txtTo.Text = "";
        txtAgreedPrice.Text = "";
        txtTruckPlanned.Text = "";
        txtbuyer.Text = "";
        txtcontactnumber.Text = "";
        txtcontactperson.Text = "";
        txtRemarks.Text = "";
        txtjustification.Text = "";
        
         txt_ManagerName.Text="";
        txt_PmContactno.Text="";
        txt_Siteinchargename.Text="";
        txt_Inchargecontactno.Text="";
    }

    protected void rdb_AlterTransporter_CheckedChanged(object sender, EventArgs e)
    {
        dt_CheckAccess = obj_class.Bizconnect_GetAccessPermitedUsers(Convert.ToInt32(Session["UserID"].ToString()));
        if (dt_CheckAccess.Rows.Count == 0)
        {

        }
        else
        {
            ddl_CNNo.Visible = true;
            txtCNNumber.Visible = false;
            //ddl_CNNo.ClearSelection();
            //ddl_CNNo.SelectedIndex = -1;
            txtautonumber.Visible = true;
            txtautonumber.Text = "";
            ddl_CnGeneratedNo.SelectedIndex = -1;
            //txtautonumber.Visible = false;
            ddl_CnGeneratedNo.Visible = false;
            But_NApproval.Enabled = false;
            But_Submit.Enabled = true;
            btn_Amendment.Enabled = false;
            txtCNdate.Text = "";
            LinkEdit.Visible = true;
            txtCNNumber.Text = "";
            lbl_RcNo.Visible = true;
            txt_RcNo.Visible = true;
            lbl_Rate.Visible = true;
            txt_Rate.Visible = true;
            DDLTruckType.Visible = false;
            //lbl_Email.Visible = true;
            ddl_Transporter.Visible = true;
            ddl_Transporter.SelectedIndex = -1;
            ClearFields();
            Get_CNNo();
            txtTransporter.Enabled = false;
            txtTransporter.Visible = false;
            txt_TransporterEmail.Visible = true;
            lbl_TransEmail.Visible = true;
            txt_TransporterEmail.Text = "";

        }
    }

     protected void ddl_CNNo_SelectedIndexChanged(object sender, EventArgs e)
     {
         Load_CNDetailsByCNNo();
     }

     public void Load_CNDetailsByCNNo()
     {
         try
         {

             dt.Clear();
             dt = obj_class.Bizconnect_Get_CollectionDetails(ddl_CNNo.SelectedItem.Text);
             txtCNdate.Text = dt.Rows[0][0].ToString();
             txtCNNumber.Text = dt.Rows[0][1].ToString();
             lbl_ProjectNo.Text = dt.Rows[0][2].ToString();
             ddlProjectNo.Enabled = false;
             lbl_WbsNo.Text = dt.Rows[0][3].ToString();
             DDLWBSno.Enabled = false;
             lbl_SerialNo.Text = dt.Rows[0][4].ToString();
             DDLserialno.Enabled = false;
             txtdate.Text = dt.Rows[0][5].ToString();
             txtproject.Text = dt.Rows[0][6].ToString();
             txtDescription.Text = dt.Rows[0][7].ToString();
             txttrucktype.Text = dt.Rows[0][8].ToString();
             txttransit.Text = dt.Rows[0][9].ToString();
             txtFrom.Text = dt.Rows[0][10].ToString();
             txtTo.Text = dt.Rows[0][11].ToString();
             txtTruckPlanned.Text = dt.Rows[0][12].ToString();
             txtlength.Text = dt.Rows[0][13].ToString();
             txtwidth.Text = dt.Rows[0][14].ToString();
             txtheight.Text = dt.Rows[0][15].ToString();
             txtweight.Text = dt.Rows[0][16].ToString();
             txtbuyer.Text = dt.Rows[0][17].ToString();
             txtcontactperson.Text = dt.Rows[0][18].ToString();
             txtcontactnumber.Text = dt.Rows[0][19].ToString();
             txtTransporter.Text = dt.Rows[0][20].ToString();
             txtRemarks.Text = dt.Rows[0][21].ToString();
             txtautonumber.Text = dt.Rows[0][22].ToString();

             txt_ManagerName.Text = dt.Rows[0][23].ToString();
             txt_PmContactno.Text = dt.Rows[0][24].ToString();
             Get_AgreedPrice();
         }
         catch (Exception ex)
         {

         }
     }


     public int Checking()
    {
        
            int Check = 0;
            if (Convert.ToInt32(txtTruckPlanned.Text) > Convert.ToInt32(lblTrucksRemainder.Text) || txtTo.Text.Trim() != Session["To"].ToString().Trim() || Convert.ToSingle(txtweight.Text) > Convert.ToSingle(Session["Weight"].ToString()) || Convert.ToSingle(txtlength.Text) > Convert.ToSingle(Session["Length"].ToString()) || Convert.ToSingle(txtwidth.Text) > Convert.ToSingle(Session["Width"].ToString()) || Convert.ToSingle(txtheight.Text) > Convert.ToSingle(Session["Height"].ToString()))
            {
                Check = 0;
            }
            else
            {
                Check = 1;
            }
            return Check;
      
    }

     protected void rdb_SPLRC_CheckedChanged(object sender, EventArgs e)
     {
         lbl_RcNo.Visible = true;
         txt_RcNo.Visible = true;
         lbl_Rate.Visible = false;
         txt_Rate.Visible = false;
         //lbl_Email.Visible = true;
         ddl_Transporter.Visible = true;
         ddl_CNNo.Visible = false;
         txtCNNumber.Visible = true;
         ddlProjectNo.Enabled = true;
         DDLWBSno.Enabled = true;
         DDLserialno.Enabled = true;
         ddl_Transporter.SelectedIndex = -1;
         GenerateCollectonNoteNumber();
         dtt = DateTime.Now.Date;
         txtCNdate.Text = dtt.ToString("dd-MMM-yyyy");
         ClearFields();
         txtTransporter.Enabled = false;
         txt_TransporterEmail.Visible = true;
         txtTransporter.Visible = false;
         lbl_TransEmail.Visible = true;
         txt_TransporterEmail.Text = "";
     }
     protected void ddl_Transporter_SelectedIndexChanged(object sender, EventArgs e)
     {
         try
         {
             dt_Transporter = obj_class.Bizconnect_GetTransporterByEMailID(Convert.ToInt32(ddl_Transporter.SelectedValue.ToString()));
             if (dt_Transporter.Rows.Count > 0)
             {
                 txt_TransporterEmail.Text = dt_Transporter.Rows[0][0].ToString();
             }
         }
         catch (Exception ex)
         {

         }
     }

     public void GetCNNoForClubbing()
     {
         SqlConnection conn = new SqlConnection(connStr);
         conn.Open();
         string qry = "select CollectionnoteNumber as CNNO from CollectionNote  where ProjectNo ='" + ProjectNo + "' and WBSNo ='" + WBSNo + "'and AutoNumber='" + AutoNo + "'";//clientid="+ clientid +" ";
         SqlCommand cmd = new SqlCommand(qry, conn);
         DataSet ds2 = new DataSet();
         SqlDataAdapter adp = new SqlDataAdapter(cmd);
         adp.Fill(ds2);
         txtCNNumber.Text = (Convert.ToInt32(ds2.Tables[0].Rows[0].ItemArray[0].ToString())).ToString();
     }

}
