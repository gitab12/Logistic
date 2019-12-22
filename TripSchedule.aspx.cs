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
public partial class TripSchedule : System.Web.UI.Page
{
    string obj_Authenticated;
    PlaceHolder maPlaceHolder;
    UserControl obj_Tabs;
    UserControl obj_LoginCtrl;
    UserControl obj_WelcomCtrl;
    UserControl obj_Navi;
    UserControl obj_Navihome;
     DropDownList DDLTruckType;
    string connStr = ConfigurationManager.ConnectionStrings["BizCon"].ConnectionString;
    ProjectBased obj_class = new ProjectBased();
    TripAssignment Trip_Assign = new TripAssignment();
    BizConnectLogisticsPlan obj_BizConnectLogisticsPlanClass = new BizConnectLogisticsPlan();
    string body = "";
        string mailbody = "Dear Sir,<br/><br/>Please arrange to place the vehicles as per below Schedule.  Please confirm with all the particulars of vehicle immediately.";
     AARMEmail.EmailControl mail = new AARMEmail.EmailControl();
     DataTable dt_CheckAccess = new DataTable();
     protected void Page_Load(object sender, EventArgs e)
     {
         if (!IsPostBack)
         {
             SqlConnection conn = new SqlConnection(connStr);
             conn.Open();
             ChkAuthentication();
             // FillTruckType();

             dt_CheckAccess = obj_class.Bizconnect_GetAccessPermitedUsers(Convert.ToInt32(Session["UserID"].ToString()));
             if (dt_CheckAccess.Rows.Count == 0)
             {
                 //ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Access Denied');</script>");
                 ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Access Denied');window.location ='Dashboard.aspx';", true);
                 chkWBS.Visible = false;
                 DrpProject.Visible = false;
                 ButDisplay.Visible = false;
                 btn_uploadindent.Visible = false;
                 Checkall.Visible = false;

             }
             else
             {
                 chkWBS.Visible = true;
                 DrpProject.Visible = true;
                 ButDisplay.Visible = true;
                 btn_uploadindent.Visible = true;
                 Checkall.Visible = true;

                 try
                 {
                     int clientid = Convert.ToInt32(Session["ClientID"].ToString());
                     string qry = "select ProjectNo from Bizconnect_ProjectMaster where clientid=" + clientid + " order by projectid ";

                     SqlCommand cmd = new SqlCommand(qry, conn);
                     DataTable dt = new DataTable();
                     SqlDataAdapter adp = new SqlDataAdapter(cmd);

                     adp.Fill(dt);
                     DrpProject.DataSource = dt;
                     DrpProject.DataTextField = "ProjectNo";
                     DrpProject.DataBind();
                     DrpProject.Items.Insert(0, new ListItem("--Select--", "0"));

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
  
 public void FillTruckType()
    {
        DataSet ds1 = new DataSet();
        ds1 = obj_BizConnectLogisticsPlanClass.FillTruckType();
       foreach (GridViewRow grdRow in Gridwindow.Rows)
            {                
               DDLTruckType =(DropDownList)(Gridwindow.Rows[grdRow.RowIndex].Cells[7].FindControl("DDLTruckType"));
               DDLTruckType.DataSource=ds1;
               DDLTruckType.DataTextField = "TruckType";
               DDLTruckType.DataValueField = "TruckTypeID";
               DDLTruckType.DataBind();
               DDLTruckType.Items.Insert(0, new ListItem("--- Truck Type ---", "0"));            
        }

    }


    protected void ButDisplay_Click(object sender, EventArgs e)
    {
        
        Bind();
        panel2.Visible = true;
       
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
    protected void DrpProject_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DrpProject.SelectedIndex > 0)
        {
            DataSet ds = new DataSet();
            ds = obj_class.Get_WBS(DrpProject.SelectedItem.Text);
            chkWBS.DataSource = ds;
            chkWBS.DataTextField = "WBS";
            chkWBS.DataBind();
        }
    }
    public void Bind()
    {
        DataSet ds = new DataSet();
        string wbs = "";
        for (int i = 0; i <= chkWBS.Items.Count - 1; i++)
        {
            if (chkWBS.Items[i].Selected)
            {

                wbs += chkWBS.Items[i].Text.ToString() + ",";

            }

        }

        //ds = obj_class.Get_Tripindent(wbs.ToString());
        if(Session["ClientID"].ToString()=="1135");
        ds= obj_class.Bizconnect_IndentDisplay(DrpProject.SelectedItem.Text,wbs.ToString());
        
        Gridwindow.DataSource = ds;
        Gridwindow.DataBind();
    }

    protected void Gridwindow_RowEditing(object sender, GridViewEditEventArgs e)
    {

        Gridwindow.EditIndex = e.NewEditIndex;
        Bind();
       
    }

    protected void Gridwindow_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        Gridwindow.EditIndex = -1;
        Bind();
      
    }

    protected void Gridwindow_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        int res = 0;
        try
        {
            GridViewRow row = (GridViewRow)Gridwindow.Rows[e.RowIndex];
              CheckBox ChkAll = (CheckBox)row.FindControl("ChkAll");
            Label LblEIndentID = (Label)row.FindControl("LblEIndentID");
            TextBox txtQty = (TextBox)row.FindControl("txtQty");
            TextBox txtFrom = (TextBox)row.FindControl("txtFrom");
            TextBox txtPlannedNoofVehicles = (TextBox)row.FindControl("txtPlannedNoofVehicles");
            DropDownList DDLTruckType = (DropDownList)row.FindControl("DDLTruckType");
            TextBox txtTotalAmount = (TextBox)row.FindControl("txtTotalAmount");
            TextBox txtTransitDays = (TextBox)row.FindControl("txtTransitDays");
            TextBox txtdate = (TextBox)row.FindControl("txtdate");
			TextBox txtaddress = (TextBox)row.FindControl("txtaddress");
            Gridwindow.EditIndex = -1;
     res = obj_class.UpdateBizconnect_TripIndent(Convert.ToInt32(txtQty.Text), txtFrom.Text, Convert.ToInt32(txtPlannedNoofVehicles.Text),DDLTruckType.SelectedItem.Text, Convert.ToDouble(txtTotalAmount .Text), Convert.ToInt32(txtTransitDays.Text),txtaddress.Text,Convert.ToDateTime(txtdate.Text), Convert.ToInt32(ChkAll.Text),Session ["name"].ToString());

            Bind();
         

        }
        catch (Exception ex)
        {
            res = 0;

        }
    }

    protected void Checkall_CheckedChanged(object sender, EventArgs e)
    {
        for (int i = 0; i <= chkWBS.Items.Count - 1; i++)
        {
            if (Checkall.Checked)
            {
                chkWBS.Items[i].Selected = true;

            }
            else
            {
                chkWBS.Items[i].Selected = false;
            }
        }
    }
    protected void ButPostAd_Click(object sender, EventArgs e)
    {
       try
        {

            int resp = 0;
            for (int i = 0; i <= Gridwindow.Rows.Count - 1; i++)
            {
                CheckBox ChkAll = (CheckBox)Gridwindow.Rows[i].FindControl("ChkAll");
                Label txtproduct = (Label)Gridwindow.Rows[i].FindControl("txtproduct");
                Label txtQty = (Label)Gridwindow.Rows[i].FindControl("txtQty");
                 Label txtFrom = (Label)Gridwindow.Rows[i].FindControl("txtFrom");

                 TextBox txtdate = (TextBox)Gridwindow.Rows[i].FindControl("txtdate");
                Label LblTruckPlanned = (Label)Gridwindow.Rows[i].FindControl("LblTruckPlanned");
                Label LblTotalAmount = (Label)Gridwindow.Rows[i].FindControl("LblTotalAmount");
                Label LblTruckType = (Label)Gridwindow.Rows[i].FindControl("LblTypeofVehicle");
                    if (ChkAll.Checked)
                {
                  
                    GenerateRandomString();
                        //IndentID is Stored in ShipmentID column in LogisticsPlan
                    int TruckType = obj_BizConnectLogisticsPlanClass.Get_BizConnect_TruckTypeByName(LblTruckType.Text);
                  //  resp = obj_BizConnectLogisticsPlanClass.Insert_LogisticsPlan(Session["LogisticsPlan"].ToString(), Convert.ToInt32(Session["ClientID"].ToString()), Convert.ToInt32(Session["UserID"].ToString()), 1, 0, Session["LogisticsPlan"].ToString(), 1, txtFrom.Text, "AP", Convert.ToDateTime(txtdate.Text), 1, 1, 1, txtproduct.Text, 0, 1, 0, 0, Convert.ToDouble(LblTotalAmount.Text), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, Convert.ToInt32(LblTruckPlanned.Text), Convert.ToDouble(txtQty.Text), TruckType, 1, 0, 0, Convert.ToInt32(ChkAll.Text), 0, 0, 0, Convert.ToDateTime(txtdate.Text), Convert.ToDateTime(txtdate.Text), Convert.ToDateTime(txtdate.Text), "Posted For Thermax", 0, 0, 1);
                   //TripAssignment
                     Trip_Assign.Bizconnect_InsertTripAssignwithIndent(0, txtFrom.Text, "AP", LblTruckType.Text, "open", "0", Convert.ToInt32(LblTotalAmount.Text), 716, Convert.ToInt32(LblTruckPlanned.Text), Convert.ToDateTime(txtdate.Text), "12 PM",  Convert.ToInt32 (Session ["UserID"].ToString()), Convert.ToInt32(ChkAll.Text));
                   
                    EmailCompose();
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Plan Posted Successfully');</script>");

                }
            }
        }
        catch (Exception ex)
        {
           
        }
    }
////Email Portion
    public void EmailCompose()
    {
           string  tableheader = "<table bgcolor=White bordercolor=#003366 border=1 style=width: 650px ><tr><td align=center><b>Trip Summary</b></td></tr><tr><td align=center bgcolor=#585858><Font size=2 color=White><strong>From</strong></font></td><td align=center bgcolor=#585858><Font size=2 color=White><strong>To</strong></font></td><td align=center bgcolor=#585858><Font size=2 color=White><strong>TruckType</strong></font></td><td align=center bgcolor=#585858><Font size=2 color=White><strong>Product</strong></font></td><td align=center bgcolor=#585858><Font size=2 color=White><strong>IndentID/WBS</strong></font></td><td align=center bgcolor=#585858><Font size=2 color=White><strong>NoofTrucksReq.</strong></font></td><td align=center bgcolor=#585858><Font size=2 color=White><strong>TotalAmount</strong></font></td><td align=center bgcolor=#585858><Font size=2 color=White><strong>TravelDate</strong></font></td></tr>";
            for (int j = 0; j <= Gridwindow.Rows.Count - 1; j++)
            {
                CheckBox check = (CheckBox)Gridwindow.Rows[j].FindControl("ChkAll");
                if (check.Checked)
                {
                    ComposeMail(j);   
                      body = mailbody + tableheader + body + "</table>" + "<a href=http://www.scmbizconnect.com/TripAcceptance.aspx?TransID=716+&ClID=1135+&agID=0>  Click Here to Confirm the Routes</a><br/><br/><br/>Best Regards<br/><br/><br/>SCMBizconnect Team.";
           //mail.SendEmail(Email.ToString(), "connect@scmjunction.com", "scmjunction", "", "", "connect@scmjunction.com", "bounceback@scmjunction.com", "Trip Assigned", body, System.Web.Mail.MailFormat.Html, System.Web.Mail.MailPriority.High, "smtp.gmail.com", "465", "2", "1", true, "");
            mail.SendEmail("enquiry@ntcgroup.in;pune@ntcgroup.in", "tripschedule@scmbizconnect.com", "tripschedule123", "", "connect@scmjunction.com", "tripschedule@scmbizconnect.com", "bounceback@scmjunction.com", "Placement of Vehicle", body, System.Web.Mail.MailFormat.Html, System.Web.Mail.MailPriority.High, "smtp.gmail.com", "465", "2", "1", true, "");
          
                }


                }
            

          
          
          // mail.SendEmail("nandha@aarmscmsolutions.com", "tripschedule@scmbizconnect.com", "tripschedule123", "", "connect@scmjunction.com", "tripschedule@scmbizconnect.com", "bounceback@scmjunction.com", "Placement of Vehicle", body, System.Web.Mail.MailFormat.Html, System.Web.Mail.MailPriority.High, "smtp.gmail.com", "465", "2", "1", true, "");
}
    public void ComposeMail(int j)
    {

        CheckBox ChkAll = (CheckBox)Gridwindow.Rows[j].FindControl("ChkAll");
        Label txtproduct = (Label)Gridwindow.Rows[j].FindControl("txtproduct");
        Label txtQty = (Label)Gridwindow.Rows[j].FindControl("txtQty");
        Label txtFrom = (Label)Gridwindow.Rows[j].FindControl("txtFrom");
        TextBox txtdate = (TextBox)Gridwindow.Rows[j].FindControl("txtdate");
        Label LblTruckPlanned = (Label)Gridwindow.Rows[j].FindControl("LblTruckPlanned");
        Label LblTotalAmount = (Label)Gridwindow.Rows[j].FindControl("LblTotalAmount");
        Label LblTruckType = (Label)Gridwindow.Rows[j].FindControl("LblTypeofVehicle");
           Label lblWbs = (Label)Gridwindow.Rows[j].FindControl("lblWbs");
        Label lblAddress = (Label)Gridwindow.Rows[j].FindControl("lbladdress");
        string Email = "";
        string ToLocation = "AP";
        body += "<tr><td align=center><font size=2>" + txtFrom.Text + "-" +lblAddress.Text + "</font></td><td align=center><font size=2 >" + ToLocation.ToString() + "</font></td><td align=center><font size=2>" + LblTruckType .Text + "</font></td><td align=center><font size=2>" + txtproduct.Text + "</font></td><td align=center><font size=2>" + ChkAll.Text +"/"+lblWbs.Text +  "</font></td><td align=center><font size=2>" + LblTruckPlanned .Text + "</font></td><td align=center><font size=2>" + LblTotalAmount.Text + "</font></td><td align=center><font size=2>" + txtdate.Text + "</font></td></tr>";
    }


    //Generate String Randomly
    public void GenerateRandomString()
    {
        DateTime obj_CurrentDate;
        obj_CurrentDate = DateTime.Now.Date;
        String obj_DateStr;
        obj_DateStr = obj_CurrentDate.ToString("dd/MM/yyyy");
        String obj_LogosticsPlanString = "";
        obj_LogosticsPlanString = RandomString(4, false) + '-';

        int obj_LogisticsPlanID = obj_BizConnectLogisticsPlanClass.get_MaxLogisticsPlanID();
        Session["LogisticsPlanID"] = 0;
        Session["LogisticsPlanID"] = obj_LogisticsPlanID;
        obj_LogosticsPlanString += obj_DateStr + "-" + obj_LogisticsPlanID.ToString();
        Session["LogisticsPlan"] = obj_LogosticsPlanString;

    }

    //Random Generation of String
    private string RandomString(int size, bool lowerCase)
    {
        StringBuilder builder = new StringBuilder();
        Random random = new Random();
        char ch;
        for (int i = 0; i < size; i++)
        {
            ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
            builder.Append(ch);
        }
        if (lowerCase)
            return builder.ToString().ToLower();
        return builder.ToString();
    }


    //


    //protected void Gridwindow_DataBound(object sender, EventArgs e)
    //{
    //    for (int rowIndex = Gridwindow.Rows.Count - 2;
    //                                       rowIndex >= 0; rowIndex--)
    //    {
    //        GridViewRow gvRow = Gridwindow.Rows[rowIndex];
    //        GridViewRow gvPreviousRow = Gridwindow.Rows[rowIndex + 1];
    //        for (int cellCount = 0; cellCount < gvRow.Cells.Count;
    //                                                      cellCount++)
    //        {
    //            if (gvRow.Cells[cellCount].Text ==
    //                                   gvPreviousRow.Cells[cellCount].Text)
    //            {
    //                if (gvPreviousRow.Cells[cellCount].RowSpan < 2)
    //                {
    //                    gvRow.Cells[cellCount].RowSpan = 2;
    //                }
    //                else
    //                {
    //                    gvRow.Cells[cellCount].RowSpan =
    //                        gvPreviousRow.Cells[cellCount].RowSpan + 1;
    //                }
    //                gvPreviousRow.Cells[cellCount].Visible = false;
    //            }
    //        }
    //    }
    //}
    
    protected void Gridwindow_RowDataBound(object sender, GridViewRowEventArgs e)
    {
       
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if ((e.Row.RowState & DataControlRowState.Edit) > 0)
            {

                SqlConnection conn = new SqlConnection(connStr);
                conn.Open();
                DropDownList DDLTruckType = (DropDownList)e.Row.FindControl("DDLTruckType");
                SqlCommand cmd = new SqlCommand("SELECT TruckTypeID,TruckType FROM BizConnect_TruckTypeMaster", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                conn.Close();
                DDLTruckType.DataSource = ds;
                DDLTruckType.DataTextField = "TruckType";
                DDLTruckType.DataValueField = "TruckTypeID";
                DDLTruckType.DataBind();
                DDLTruckType.Items.Insert(0, new ListItem("--Select--", "0"));
            }
        }
        
        }
        
        protected void btn_uploadindent_Click(object sender, EventArgs e)
    {
		Response.Redirect("~/UploadIndent.aspx");
    }

}

