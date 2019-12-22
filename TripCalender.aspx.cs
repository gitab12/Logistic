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
public partial class TripCalender : System.Web.UI.Page
{
    string obj_Authenticated;
    PlaceHolder maPlaceHolder;
    UserControl obj_Tabs;
    UserControl obj_LoginCtrl;
    UserControl obj_WelcomCtrl;
    UserControl obj_Navi;
    UserControl obj_Navihome;
    TripAssignment Trip_Assign = new TripAssignment();
    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ChkAuthentication();
        }
    }

    protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
    {
        try
        {
            Session["username"] = "";
            Session["Time"] = "";

            string monthtest = DateTime.Now.Month.ToString();

            ds = new DataSet();
            ds = Trip_Assign.Bizconnect_AssignTrip();
            DataTable dt = new DataTable();

            dt.Columns.Add("TDate");
            dt.Columns.Add("Source");
            dt.Columns.Add("Desination");
            dt.Columns.Add("LID");
            dt.Columns.Add("Day");
            dt.Columns.Add("Month");
            dt.Columns.Add("Year");

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                dr[1] = ds.Tables[0].Rows[i].ItemArray[2].ToString();
                dr[2] = ds.Tables[0].Rows[i].ItemArray[3].ToString();
                dr[3] = ds.Tables[0].Rows[i].ItemArray[8].ToString();
                dr[4] = ds.Tables[0].Rows[i].ItemArray[9].ToString();
                dr[5] = ds.Tables[0].Rows[i].ItemArray[10].ToString();
                dr[6] = ds.Tables[0].Rows[i].ItemArray[11].ToString();
                dt.Rows.Add(dr);
            }
            foreach (DataRow dr in dt.Rows)
            {

                string a = e.Day.Date.Day.ToString();
                if (e.Day.Date.Day == Convert.ToInt32(dr["Day"].ToString()) && e.Day.Date.Month == Convert.ToInt32(dr["Month"].ToString()) && e.Day.Date.Year == Convert.ToInt32(dr["Year"].ToString()))
                {

                    e.Cell.BackColor = System.Drawing.Color.Red;


                }
            }

        }
        catch (Exception ex)
        {
        }
    }



    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        DateTime dtt = new DateTime();
        dtt = Calendar1.SelectedDate.Date;
        txtDate.Text = dtt.ToString("dd-MMM-yyyy");

        DataSet ds = new DataSet();
        ds = Trip_Assign.Bizconnect_TruckAssign(179);
        Gridwindow.DataSource = ds;
        Gridwindow.DataBind();
      


    }
    protected void Gridwindow_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblstatus = (Label)e.Row.Cells[11].FindControl("lblStatus");
                CheckBox chkrow = (CheckBox)e.Row.Cells[11].FindControl("ChkSelect");
                CheckBox hchkrow = (CheckBox)Gridwindow.HeaderRow.FindControl("cbSelectAll");
                {
                    if (lblstatus.Text == "Assigned")
                    {
                        lblstatus.ForeColor = System.Drawing.Color.Green;
                        lblstatus.Font.Bold = true;
                        chkrow.Enabled = false;
                        hchkrow.Enabled = false;
                    }
                    else
                    {
                        if (Convert.ToDateTime(txtDate.Text) < DateTime.Now.Date)
                        {
                            chkrow.Enabled = false;
                            hchkrow.Enabled = false;

                        }
                        
                    }
                }
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
    protected void cbSelectAll_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox chk = (CheckBox)Gridwindow.HeaderRow.FindControl("cbSelectAll");
        if (chk.Checked)
        {
            for (int i = 0; i < Gridwindow.Rows.Count; i++)
            {

                CheckBox chkrow = (CheckBox)Gridwindow.Rows[i].FindControl("ChkSelect");
                chkrow.Checked = true;
                chkrow.DataBind();
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
    protected void ButAssign_Click(object sender, EventArgs e)
    {
        int resp = 0;
        try
        {
            for (int i = 0; i < Gridwindow.Rows.Count; i++)
            {
                CheckBox chkrow = (CheckBox)Gridwindow.Rows[i].FindControl("ChkSelect");
                Label lblplanid = (Label)Gridwindow.Rows[i].FindControl("lblplanID");
                Label lblFromLoc = (Label)Gridwindow.Rows[i].FindControl("lblFromLoc");
                Label lblToLoc = (Label)Gridwindow.Rows[i].FindControl("lblToLoc");
                Label lblTrucktype = (Label)Gridwindow.Rows[i].FindControl("lblTrucktype");
                Label lblQuotedPrice = (Label)Gridwindow.Rows[i].FindControl("lblQuotedPrice");
                Label lblDecidePrice = (Label)Gridwindow.Rows[i].FindControl("lblDecidePrice");
                Label lblSavings = (Label)Gridwindow.Rows[i].FindControl("lblSavings");
                Label lblTransporter = (Label)Gridwindow.Rows[i].FindControl("lblTransporterID");
                Label lblEmail = (Label)Gridwindow.Rows[i].FindControl("lblEmail");

                //insert into TripAssignTable
                if (chkrow.Checked)
                {
                    // resp = Trip_Assign.Bizconnect_InsertTripAssign(Convert.ToInt32(lblplanid.Text), lblFromLoc.Text, lblToLoc.Text, lblTrucktype.Text, Convert.ToInt32(lblQuotedPrice.Text), Convert.ToInt32(lblDecidePrice.Text), Convert.ToInt32(lblTransporter.Text), Convert.ToDateTime(txtDate.Text),204);
                    SendMail(lblEmail.Text);
                }
                if (resp == 1)
                {
                    ds = new DataSet();
                    ds = Trip_Assign.Bizconnect_TruckAssign(204);
                    Gridwindow.DataSource = ds;
                    Gridwindow.DataBind();
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Trip Assigned Successfully');</script>");

                }

            }
        }
        catch (Exception ex)
        {
        }
    }
    public void SendMail(String ToID)
    {
        try
        {
            AARMEmail.EmailControl Mail = new EmailControl();
            //  Mail.SendEmail(ToID.ToString(), "connect@scmjunction.com", "scmjunction1", "", "", ToID.ToString(), ToID.ToString(), "Test", "Testing assignmet", System.Web.Mail.MailFormat.Html, System.Web.Mail.MailPriority.High, "smtp.gmail.com", "465", "2", "1", true, "");
            Mail.SendEmail("nandha@aarmscmsolutions.com", "connect@scmjunction.com", "scmjunction1", "", "", "nandha@aarmscmsolutions.com", "nandha@aarmscmsolutions.com", "Test", "Testing assignmet", System.Web.Mail.MailFormat.Html, System.Web.Mail.MailPriority.High, "smtp.gmail.com", "465", "2", "1", true, "");
        }
        catch (Exception ex)
        {
        }
    }
}
