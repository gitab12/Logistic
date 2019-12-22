using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
public partial class ProjectMaster : System.Web.UI.Page
{
    string obj_Authenticated;
    PlaceHolder maPlaceHolder;
    UserControl obj_Tabs;
    UserControl obj_LoginCtrl;
    UserControl obj_WelcomCtrl;
    UserControl obj_Navi;
    UserControl obj_Navihome;
    string connStr = ConfigurationManager.ConnectionStrings["BizCon"].ConnectionString;
    DataTable dt_PjtNo = new DataTable();
    DataTable dt = new DataTable();
    DataTable dt_PjtDetails = new DataTable();
    ProjectBased obj_class = new ProjectBased();
    int resp;
    DataTable dt_CheckAccess = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ChkAuthentication();
            dt_CheckAccess = obj_class.Bizconnect_GetAccessPermitedUsers(Convert.ToInt32(Session["UserID"].ToString()));
            if (dt_CheckAccess.Rows.Count == 0)
            {
                //ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Access Denied');</script>");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Access Denied');window.location ='Dashboard.aspx';", true);
                pnl_Project.Visible = false;
               
               
            }
            else
            {
                pnl_Project.Visible = true;
                Load_ClientsTransporterEMailIDs();

            }
        }

    }

    public void Load_ClientsTransporterEMailIDs()
    {
        dt.Clear();
        dt = obj_class.Bizconnect_GetClientsTransporterEMailIDs(Convert.ToInt32(Session["ClientID"].ToString()));
        ddl_Transporter.DataSource = dt;
        ddl_Transporter.DataTextField = "Transporter";
        ddl_Transporter.DataValueField = "TransporterID";
        ddl_Transporter.DataBind();
        ddl_Transporter.Items.Insert(0, "--Select Transporter--");
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
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (rdb_AddProject.Checked == true)
        {
        SqlConnection conn = new SqlConnection(connStr);
        conn.Open();

        try
        {
            int clientid = Convert.ToInt32(Session["ClientID"].ToString());
            string qry = "insert into Bizconnect_ProjectMaster (ClientID, ProjectNo,ProjectName ,ProjectLocation  ,WorkOrderNo,Transporter,TransporterEmailID,ProjectManager,ProjectManagerEmailID,PMMobileNo,TransporterID,SiteIncharge,SiteInchargeEmailID,SiteInchargeMobileNo,LogisticManager,LogisticmanagerEmail,shippingperson,shippingpersonEmail,Approvalperson,ApprovalpersonEmail )values(" + Convert.ToInt32(Session["ClientID"].ToString()) + ",'" + txtProjNo.Text.Trim() + "','" + txtProjName.Text + "','" + txtProjLocation.Text + "','" + txtProjWorkOrder.Text + "','" + ddl_Transporter.SelectedItem.Text + "','" + txt_TransporterEmail.Text + "','" + txt_ProjectManager.Text + "','" + txt_ProjectManagerEmail.Text + "','" + txt_PMMobileNo.Text + "','" + ddl_Transporter.SelectedValue.ToString() + "','" + txt_Siteincharge.Text + "','" + txt_InchargeEmailid.Text + "','" + txt_InchargeMobileNo.Text + "','" + txt_LogisticPerson.Text + "','" + txt_LogisticPersonEmail.Text + "','" + txt_ShippingPerson.Text + "','" + txt_ShippingpersonEmail.Text + "','" + txt_ApprovalPerson.Text + "','" + txt_ApprovalPersonEmail.Text + "')";

            SqlCommand cmd = new SqlCommand(qry, conn);
            resp=cmd.ExecuteNonQuery();
            if (resp == 1)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Project Created Successfully');</script>");
                SendMail();
                ClearALL();
            }
        }
        catch (Exception ex)
        {
        }
        finally
        {
            conn.Close();
        }
        }
        else
        {
            try
            {
                //update code
                resp = obj_class.Bizconnect_UpdateProjectDetailsByPjtno(ddl_Projectno.SelectedItem.Text, Convert.ToInt32(Session["ClientID"].ToString()), txtProjName.Text, txtProjLocation.Text, txtProjWorkOrder.Text, txt_Transporter.Text, txt_TransporterEmail.Text, txt_ProjectManager.Text, txt_ProjectManagerEmail.Text, txt_PMMobileNo.Text, txt_Siteincharge.Text, txt_InchargeEmailid.Text, txt_InchargeMobileNo.Text, txt_LogisticPerson.Text, txt_LogisticPersonEmail.Text, txt_ShippingPerson.Text, txt_ShippingpersonEmail.Text, txt_ApprovalPerson.Text, txt_ApprovalPersonEmail.Text);
                if (resp == 1)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Project Updated Successfully');</script>");
                    ClearALL();
                    ddl_Projectno.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
            }
        }
    }


    public void SendMail()
    {
        //Email Settings from Web Config
        string obj_BounceBakEmail = ConfigurationManager.AppSettings.Get("bouncebakemailid").ToString();
        string obj_ServerName = ConfigurationManager.AppSettings.Get("Server").ToString();
        string obj_Password = ConfigurationManager.AppSettings.Get("Password").ToString();
        string obj_PortNo = ConfigurationManager.AppSettings.Get("PortNo").ToString();
        string obj_AuthenticateMode = ConfigurationManager.AppSettings.Get("AuthenticateMode").ToString();
        string obj_SendUsingPort = ConfigurationManager.AppSettings.Get("SendUsingPort").ToString();
        string obj_SMTPUseSSL = ConfigurationManager.AppSettings.Get("SMTPUseSSL").ToString();
        Boolean SMTPUseSSL;
        string obj_AttachmentPath = ConfigurationManager.AppSettings.Get("AttachmentPath").ToString();

        AARMEmail.EmailControl em = new AARMEmail.EmailControl();
        string CorbonCopy = txt_ProjectManagerEmail.Text + ";" + txt_LogisticPersonEmail.Text;
        //string obj_Message = "Dear Sir/madam,<br/>Please Quote your competative price for various trips</br> <b><a href=http://www.scmjunction.com/GQuotePrice.aspx?Lid=" + Server.UrlEncode(Encrypt(obj_Rid)) + "&TDate=" + txttravelDate.Text + "> Click the link to Quote your Price</a> </b> <br/><b>NOTE: Please quote your price before  " + CutoffTime.ToString() + ", System will close the bidding at " + CutoffTime.ToString() + "</b><br/>Thank You,<br/>AARMSCM SOLUTIONS PRIVATE LIMITED<br>307, 2nd floor, 100 ft ring road,<br>(7th block, BSK III STAGE<br> BANGALORE-560085<br>Ph:08147016714;09845497950<br><a href=http://www.scmjunction.com>www.scmjunction.com</a>";
        //body += "<tr><td align=center><font size=2>" + dt_TripDetails.Rows[j][0] + "</font></td><td align=center><font size=2 >" + dt_TripDetails.Rows[j][1] + "</font></td><td align=center><font size=2 >" + dt_TripDetails.Rows[j][2] + "</font></td><td align=center><font size=2>" + dt_TripDetails.Rows[j][3] + "</font></td><td align=center><font size=2 >" + dt_TripDetails.Rows[j][4] + "</font></td><td align=center><font size=2>" + dt_TripDetails.Rows[j][5] + " </font></td></tr>";
        int resp = em.SendEmail("nanda@aarmsvaluechain.com", "thermax@scmbizconnect.com", "thermax123", CorbonCopy, "", "connect@scmjunction.com", obj_BounceBakEmail, "Alert-New project has been Created by Thermax", "Dear Sir,<br/>New project has been Created by Thermax.<br/>The project details are as below.<br/>Project No :" + txtProjNo.Text + "<br/>Project Name :" + txtProjName.Text + "<br/>Created Date :" + System.DateTime.Now.ToString() + "", System.Web.Mail.MailFormat.Html, System.Web.Mail.MailPriority.Normal, obj_ServerName.ToString().Trim(), obj_PortNo.ToString().Trim(), obj_SendUsingPort.ToString().Trim(), obj_AuthenticateMode.ToString().Trim(), true, obj_AttachmentPath.ToString().Trim());

    }

    public void ClearALL()
    {
        txtProjNo.Text = "";
        txtProjName.Text = "";
        txtProjLocation.Text = "";
        txtProjWorkOrder.Text = "";
        
        txt_Transporter.Text = "";
        txt_TransporterEmail .Text = "";
        txt_ProjectManager.Text = "";
        txt_ProjectManagerEmail.Text = "";
        txt_PMMobileNo.Text = "";
        txt_Siteincharge.Text = "";
        txt_InchargeEmailid.Text = "";
        txt_InchargeMobileNo.Text = "";
        txt_LogisticPerson.Text = "";
        txt_LogisticPersonEmail.Text = "";

        txt_ApprovalPerson.Text = "";
        txt_ApprovalPersonEmail.Text = "";
        txt_ShippingPerson.Text = "";
        txt_ShippingpersonEmail.Text = "";

    }

    protected void rdb_EditProject_CheckedChanged(object sender, EventArgs e)
    {
        txtProjNo.Visible = false;
        txt_Transporter.Visible = true;
        ddl_Projectno.Visible = true;
        ddl_Transporter.Visible = false;
        ddl_Projectno.DataSource = Get_ProjectNOs();
        ddl_Projectno.DataTextField = "ProjectNo";
        ddl_Projectno.DataValueField = "ProjectID";
        ddl_Projectno.DataBind();
        ddl_Projectno.Items.Insert(0, "--Select--");
        Button1.Text = "Update";
    }

    public DataTable Get_ProjectNOs()
    {
        SqlConnection conn = new SqlConnection(connStr);
        conn.Open();
        try
        {
            int clientid = Convert.ToInt32(Session["ClientID"].ToString());
            string qry = "select ProjectID ,ProjectNo ,ProjectName  from Bizconnect_ProjectMaster where ClientID =" + Convert.ToInt32(Session["ClientID"].ToString());
            SqlCommand cmd = new SqlCommand(qry, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt_PjtNo);
        }
        catch (Exception ex)
        {
        }
        finally
        {
            conn.Close();
        }
        return dt_PjtNo;
    }

    public DataTable Get_ProjectDetailsbyProjectNo()
    {
        SqlConnection conn = new SqlConnection(connStr);
        conn.Open();
        dt_PjtNo.Clear();
        try
        {
            int clientid = Convert.ToInt32(Session["ClientID"].ToString());
            string qry = "select ProjectName,ProjectLocation ,WorkOrderNo ,Transporter ,TransporterEmailID ,ProjectManager ,ProjectManagerEmailID ,PMMobileNo ,SiteIncharge ,SiteInchargeEmailID ,SiteInchargeMobileNo ,LogisticManager ,LogisticManagerEmail,shippingperson,shippingpersonEmail,Approvalperson,ApprovalpersonEmail from Bizconnect_ProjectMaster where ProjectNo ='" + ddl_Projectno.SelectedItem.Text + "' and  ClientID =" + Convert.ToInt32(Session["ClientID"].ToString());
            SqlCommand cmd = new SqlCommand(qry, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt_PjtNo);
        }
        catch (Exception ex)
        {
        }
        finally
        {
            conn.Close();
        }
        return dt_PjtNo;
    }

    protected void ddl_Projectno_SelectedIndexChanged(object sender, EventArgs e)
    {
        dt_PjtDetails = Get_ProjectDetailsbyProjectNo();
        if (dt_PjtDetails.Rows.Count > 0)
        {
            txtProjName.Text = dt_PjtDetails.Rows[0][0].ToString();
            txtProjLocation.Text = dt_PjtDetails.Rows[0][1].ToString();
            txtProjWorkOrder.Text = dt_PjtDetails.Rows[0][2].ToString();
            txt_Transporter.Text = dt_PjtDetails.Rows[0][3].ToString();
            txt_TransporterEmail.Text = dt_PjtDetails.Rows[0][4].ToString();
            txt_ProjectManager.Text = dt_PjtDetails.Rows[0][5].ToString();
            txt_ProjectManagerEmail.Text = dt_PjtDetails.Rows[0][6].ToString();
            txt_PMMobileNo.Text = dt_PjtDetails.Rows[0][7].ToString();
            txt_Siteincharge.Text = dt_PjtDetails.Rows[0][8].ToString();
            txt_InchargeEmailid.Text = dt_PjtDetails.Rows[0][9].ToString();
            txt_InchargeMobileNo.Text = dt_PjtDetails.Rows[0][10].ToString();
            txt_LogisticPerson.Text = dt_PjtDetails.Rows[0][11].ToString();
            txt_LogisticPersonEmail.Text = dt_PjtDetails.Rows[0][12].ToString();

            txt_ShippingPerson.Text = dt_PjtDetails.Rows[0][13].ToString();
            txt_ShippingpersonEmail.Text = dt_PjtDetails.Rows[0][14].ToString();
            txt_ApprovalPerson.Text = dt_PjtDetails.Rows[0][15].ToString();
            txt_ApprovalPersonEmail.Text = dt_PjtDetails.Rows[0][16].ToString();
        }
    }
    protected void rdb_AddProject_CheckedChanged(object sender, EventArgs e)
    {
        txtProjNo.Visible = true;
        ddl_Projectno.Visible = false ;
        txt_Transporter.Visible = false;
        ddl_Transporter.Visible = true;
    }
}
