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

public partial class StatusUpdate : System.Web.UI.Page
{
    string obj_Authenticated;
    PlaceHolder maPlaceHolder;
    UserControl obj_Tabs;
    UserControl obj_LoginCtrl;
    UserControl obj_WelcomCtrl;
    UserControl obj_Navi;
    UserControl obj_Navihome;
    AarmsUser obj_Class = new AarmsUser();

    DataTable dt = new DataTable();
    int Mode;
    string connStr = ConfigurationManager.ConnectionStrings["BizCon"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ChkAuthentication();
           
            Binddata(0);
        }

    }
    public void Binddata(int mode)
    {
       
        DataSet ds = new DataSet();

        if (mode == 0)
        {
            ds = obj_Class.DisplayAppointDetails(Convert.ToDateTime("01/Jan/2012"), mode);
        }
        else
        {
            ds = obj_Class.DisplayAppointDetails(Convert.ToDateTime(txtappdate.Text), mode);
        }

        GridStatus.DataSource = ds;
        GridStatus.DataBind();
    }
    protected void ButShow_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtappdate.Text == "")
            {
                Session["Mode"] = 0;
            }
            else
            {
               Session["Mode"] = 1;  
            }
           
            DateTime dtt = new DateTime();
            dtt = Convert.ToDateTime(txtappdate.Text);
            txtappdate.Text = dtt.ToString("dd-MMM-yyyy");
            Binddata(Convert.ToInt32(Session["Mode"].ToString()));
           
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
        lblwelcome.Text = "Welcome Nanda";
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

    protected void GridStatus_RowEditing(object sender, GridViewEditEventArgs e)
    {
        if (txtappdate.Text == "")
        {
            Session["Mode"] = 0;
        }
        else
        {
            Session["Mode"] = 1;
        }
        //Response.Write("<script>alert('"+e.NewEditIndex+"');</script>");

        GridStatus.EditIndex = e.NewEditIndex;
        

        DataTable dt = new DataTable();
        dt.Columns.Add("ActivityID", typeof(string));
        dt.Columns.Add("ClientName", typeof(string));
        dt.Columns.Add("Location", typeof(string));
        dt.Columns.Add("Industry", typeof(string));
        dt.Columns.Add("ContactPerson", typeof(string));
        dt.Columns.Add("MobileNumber", typeof(string));
        dt.Columns.Add("EmailID", typeof(string));
        dt.Columns.Add("Department", typeof(string));
        dt.Columns.Add("EnteredBy", typeof(string));
        dt.Columns.Add("AppointmentDate", typeof(string));
        dt.Columns.Add("MetBy", typeof(string));
        dt.Columns.Add("Tripplan", typeof(string));
        dt.Columns.Add("Action", typeof(string));
        dt.Columns.Add("Remarks", typeof(string));
        dt.Columns.Add("col", typeof(string));
        dt.Columns.Add("col2", typeof(string));
        //Loop through the GridView and copy rows.
        foreach (GridViewRow row in GridStatus.Rows)
        {
            if (row.RowIndex == e.NewEditIndex)
            {
                dt.Rows.Add();
                //for (int i = 0; i < row.Cells.Count; i++)
                //{
                dt.Rows[0][0] = ((Label)row.Cells[0].FindControl("lblActivityID")).Text;
                dt.Rows[0][1] = ((Label)row.Cells[1].FindControl("lblsource")).Text;
                dt.Rows[0][2] = ((Label)row.Cells[2].FindControl("lbllocation")).Text;
                dt.Rows[0][3] = ((Label)row.Cells[3].FindControl("lblIndustry")).Text;
                dt.Rows[0][4] = ((Label)row.Cells[4].FindControl("lblcontactperson")).Text;
                dt.Rows[0][5] = ((Label)row.Cells[5].FindControl("lblMobileNumber")).Text;
                dt.Rows[0][6] = ((Label)row.Cells[6].FindControl("lblEmailID")).Text;
                dt.Rows[0][7] = ((Label)row.Cells[7].FindControl("lblDept")).Text;
                dt.Rows[0][8] = ((Label)row.Cells[8].FindControl("lblenterby")).Text;
                dt.Rows[0][9] = ((Label)row.Cells[9].FindControl("lblAppdate")).Text;
                dt.Rows[0][10] = ((Label)row.Cells[10].FindControl("lblMetBy")).Text;
                dt.Rows[0][11] = ((Label)row.Cells[11].FindControl("lblTripplan")).Text;               
                dt.Rows[0][12] = ((Label)row.Cells[12].FindControl("lblaction")).Text;
                dt.Rows[0][13] = ((TextBox)row.Cells[13].FindControl("txtRemarks")).Text;

                //dt.Rows[0][4] = ((TextBox)row.FindControl("txtcontactperson")).Text;
                //dt.Rows[0][5] = ((TextBox)row.FindControl("txtMobileNumber")).Text;
                //dt.Rows[0][6] = ((TextBox)row.FindControl("txtEmailId")).Text;
                //dt.Rows[0][7] = ((TextBox)row.FindControl("txtDept")).Text;
                //dt.Rows[0][8] = ((TextBox)row.FindControl("txtenterby")).Text;
                //dt.Rows[0][9] = ((TextBox)row.FindControl("txtAppdate")).Text;
                //dt.Rows[0][10] = ((TextBox)row.FindControl("txtMetBy")).Text;
                //dt.Rows[0][11] = ((TextBox)row.FindControl("txtTripplan")).Text;
                ////dt.Rows[0][12] = ((DropDownList)row.FindControl("ddlaction")).SelectedItem.ToString();                    
                //dt.Rows[0][13] = ((TextBox)row.FindControl("txtRemarks")).Text;
            }
        }
        Session["EDITTBL"]=dt;
        Bindtonewgrid(sender,e);

        Binddata(Convert.ToInt32(Session["Mode"].ToString()));
    }
    protected void GridStatus_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridStatus.EditIndex = -1;
        Binddata(Convert.ToInt32(Session["Mode"].ToString()));       
    }
    protected void GridStatus_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        int res = 0;
        try
        {
            int index = GridStatus.EditIndex;
            GridViewRow row = GridStatus.Rows[index];
            TextBox txtcontactperson = (TextBox)row.FindControl("txtcontactperson");
            TextBox txtMobileNumber = (TextBox)row.FindControl("txtMobileNumber");
            TextBox txtEmailId = (TextBox)row.FindControl("txtEmailId");
            TextBox txtDept = (TextBox)row.FindControl("txtDept");
            TextBox txtenterby = (TextBox)row.FindControl("txtenterby");
            TextBox txtAppdate = (TextBox)row.FindControl("txtAppdate");
            TextBox txtMetBy = (TextBox)row.FindControl("txtMetBy");
            TextBox txtTripplan = (TextBox)row.FindControl("txtTripplan");
            DropDownList ddlaction = (DropDownList)row.FindControl("ddlaction");
            TextBox txtRemarks = (TextBox)row.FindControl("txtRemarks");
            Label lblActivityID = (Label)row.FindControl("lblActivityID");

            int resp = obj_Class.Bizconnect_UpdateStatus(txtcontactperson.Text, txtMobileNumber.Text, txtEmailId.Text, txtDept.Text, txtenterby.Text, Convert.ToDateTime(txtAppdate.Text), txtMetBy.Text, txtTripplan.Text, ddlaction.Text, txtRemarks.Text, Convert.ToInt32(lblActivityID.Text));
            if (resp == 1)
            {
                GridStatus.EditIndex = -1;
                Binddata(Convert.ToInt32(Session["Mode"].ToString()));
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Update Successfully');</script>");
            }



        }
        catch (Exception ex)
        {
        }
    }

    public void Bindtonewgrid(object sender, GridViewEditEventArgs e)
    {
        GridStatus_RowEditing_edit(sender, e);
        DataTable _Dt = (DataTable)Session["EDITTBL"];

        GridStatus2.DataSource = _Dt;
        GridStatus2.DataBind();
        ((DropDownList)(GridStatus2.Rows[0].FindControl("ddlaction"))).SelectedValue = _Dt.Rows[0][12].ToString();

        GridStatus.Visible = false;
        GridStatus2.Visible = true;
        //if (txt_Search.Text != "" && ddl_Search.SelectedIndex != 0) 
        //{
         //   btn_Search_Click(sender, e);
        //}
        //ddl_Search.SelectedIndex = 0;
        //txt_Search.Text = "";
        //GridStatus_RowEditing_edit(sender, e);
    }
    protected void GridStatus_RowEditing_edit(object sender, GridViewEditEventArgs e)
    {
        if (txtappdate.Text == "")
        {
            Session["Mode"] = 0;
        }
        else
        {
            Session["Mode"] = 1;
        }
        GridStatus2.EditIndex = 0;
        
    }
    protected void GridStatus_RowUpdating_edit(object sender, GridViewUpdateEventArgs e)
    {
        int res = 0;
        try
        {
            int index = GridStatus2.EditIndex;
            GridViewRow row = GridStatus2.Rows[index];
            TextBox txtcontactperson = (TextBox)row.FindControl("txtcontactperson");
            TextBox txtMobileNumber = (TextBox)row.FindControl("txtMobileNumber");
            TextBox txtEmailId = (TextBox)row.FindControl("txtEmailId");
            TextBox txtDept = (TextBox)row.FindControl("txtDept");
            TextBox txtenterby = (TextBox)row.FindControl("txtenterby");
            TextBox txtAppdate = (TextBox)row.FindControl("txtAppdate");
            TextBox txtMetBy = (TextBox)row.FindControl("txtMetBy");
            TextBox txtTripplan = (TextBox)row.FindControl("txtTripplan");
            DropDownList ddlaction = (DropDownList)row.FindControl("ddlaction");
            TextBox txtRemarks = (TextBox)row.FindControl("txtRemarks");
            Label lblActivityID = (Label)row.FindControl("lblActivityID");

            int resp = obj_Class.Bizconnect_UpdateStatus(txtcontactperson.Text, txtMobileNumber.Text, txtEmailId.Text, txtDept.Text, txtenterby.Text, Convert.ToDateTime(txtAppdate.Text), txtMetBy.Text, txtTripplan.Text, ddlaction.Text, txtRemarks.Text, Convert.ToInt32(lblActivityID.Text));
            if (resp == 1)
            {
                GridStatus.EditIndex = -1;
                if (txtappdate.Text == "")
                {
                    Session["Mode"] = 0;
                }
                else
                {
                    Session["Mode"] = 1;
                }                
                
                Binddata(Convert.ToInt32(Session["Mode"].ToString()));
                GridStatus.Visible = true;
                GridStatus2.Visible = false;
                if (txt_Search.Text != "" && ddl_Search.SelectedIndex != 0)
                {
                    btn_Search_Click(sender, e);
                }




              
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Update Successfully');</script>");
            }



        }
        catch (Exception ex)
        {
        }
    }
    protected void GridStatus_RowCancelingEdit_edit(object sender, GridViewCancelEditEventArgs e)
    {
        GridStatus.EditIndex = -1;
        Binddata(Convert.ToInt32(Session["Mode"].ToString()));
        GridStatus.Visible = true;
        GridStatus2.Visible = false;
    }

   

    protected void LinkLogout_Click(object sender, EventArgs e)
    {
        Session["UserID"] = 0;
        Session.Abandon();
        Response.Redirect("Index.aspx");
    }
    
    protected void btnexport_Click(object sender, EventArgs e)
    {

        ExportGrid(GridStatus, "Report.xls");

    } 
    
     public static void ExportGrid(GridView oGrid, string exportFile)
    {
        //Clear the response, and set the content type and mark as attachment
        HttpContext.Current.Response.Clear();
        HttpContext.Current.Response.Buffer = true;
        HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";
        HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=\"" + exportFile + "\"");

        //Clear the character set
        HttpContext.Current.Response.Charset = "";

        //Create a string and Html writer needed for output
        System.IO.StringWriter oStringWriter = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter oHtmlTextWriter = new System.Web.UI.HtmlTextWriter(oStringWriter);

        //Clear the controls from the pased grid
        ClearControls(oGrid);

        //Show grid lines
        oGrid.GridLines = GridLines.Both;

        //Color header
        oGrid.HeaderStyle.BackColor = System.Drawing.Color.LightGray;

        //Render the grid to the writer
        oGrid.RenderControl(oHtmlTextWriter);

        //Write out the response (file), then end the response
        HttpContext.Current.Response.Write(oStringWriter.ToString());
        HttpContext.Current.Response.End();
    }
    private static void ClearControls(Control control)
    {
        //Recursively loop through the controls, calling this method
        for (int i = control.Controls.Count - 1; i >= 0; i--)
        {
            ClearControls(control.Controls[i]);
        }

        //If we have a control that is anything other than a table cell
        if (!(control is TableCell))
        {
            if (control.GetType().GetProperty("SelectedItem") != null)
            {
                LiteralControl literal = new LiteralControl();
                control.Parent.Controls.Add(literal);
                try
                {
                    literal.Text = (string)control.GetType().GetProperty("SelectedItem").GetValue(control, null);
                }
                catch
                {
                }
                control.Parent.Controls.Remove(control);
            }
            else
                if (control.GetType().GetProperty("Text") != null)
                {
                    LiteralControl literal = new LiteralControl();
                    control.Parent.Controls.Add(literal);
                    literal.Text = (string)control.GetType().GetProperty("Text").GetValue(control, null);
                    control.Parent.Controls.Remove(control);
                }
        }
        return;
    }
    public override void VerifyRenderingInServerForm(Control control)
    {

    }

    protected void GridStatus_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            //int index = GridStatus.EditIndex;
            //GridViewRow row = GridStatus.Rows[index];
            string id = GridStatus.DataKeys[e.RowIndex].Value.ToString();
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connStr;
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            //Label lblActivityID = (Label)GridStatus.FindControl("lblActivityID");
            string qry = "delete  from Bizconnect_AARMSDailyActivity where ActivityID='" + id + "'";
            cmd = new SqlCommand(qry, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            //GridStatus.EditIndex = -1;
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Status Removed Successfully');</script>");
            Binddata(0);
            
        }
        catch (Exception ex)
        {
        }
    }

    public string MailBody()
    {
        string Body = "";
        StreamReader streamReader;
        streamReader = File.OpenText(Server.MapPath(@"Documents\AARMSCampaign.html"));
        string contents = streamReader.ReadToEnd();
        streamReader.Close();
        Body = contents;
        return Body;
    }

    protected void btn_Sendmail_Click(object sender, EventArgs e)
    {
        EmailTo_ClientForConfirm();
    }

    public void EmailTo_ClientForConfirm()
    {
        try
        {
            foreach (GridViewRow gvrow in GridStatus.Rows)
            {
                CheckBox chk_ID = (CheckBox)gvrow.FindControl("chk_ID");
                if (chk_ID.Checked)
                {
                    Label Emailid = (Label)gvrow.FindControl("lblEmailID");
                    string obj_Body = "";
                    string body = "";
                    obj_Body = MailBody();
                    string Attachment = Server.MapPath(@"Excel/END-TOENDQUESTIONNAIRE.xlsx");
                    string fromgetemailid = "introduction@scmbizconnect.com";
                    string fromgetpwd = "introduction";
                    // string obj_Message = "<pre>" + "<font size=4>" + mailcontent + "<br/>Best Regards,<br/>Bid2sky Team.<br/></pre></font>";
                    //string mailcontent = "&nbsp;&nbsp;&nbsp; Dear Customer,<br/>";
                    //mailcontent = mailcontent + "<br/>&nbsp;&nbsp;&nbsp;One client has created a " + " project in our Bid2sky portal. The details of RFQ are given in the below Table.<br/>";
                    body = body + "<br/><br/>\n\n" + obj_Body + "\r\n\n";
                    AARMEmail.EmailControl Email = new EmailControl();
                    int obj_resp = Email.SendEmail(Emailid.Text, fromgetemailid, fromgetpwd, "satish@aarmsvaluechain.com", "", "satish@aarmsvaluechain.com", "", "SCM SOLUTIONS - DOMESTIC TRANSPORTATION SOLUTIONS", body.ToString().Trim(), System.Web.Mail.MailFormat.Html, System.Web.Mail.MailPriority.High, "smtp.gmail.com", "465", "2", "1", true, Attachment);
                    //int obj_resp = Email.SendEmail("", fromgetemailid, fromgetpwd, Emailid.Text, "", "", "", "Bid2sky new RFQ Posted", body.ToString().Trim(), System.Web.Mail.MailFormat.Html, System.Web.Mail.MailPriority.High, "mail.aarmsvaluechain.com", "25", "2", "1", false, "Excel/END-TO END QUESTIONNAIRE.xlsx");
                    //int obj_resp = Email.SendEmail("", fromgetemailid, fromgetpwd, "krishna.irki@gmail.com,krishnasai.rk@gmail.com", "", "", "", "Bid2sky new RFQ Posted", body.ToString().Trim(), System.Web.Mail.MailFormat.Html, System.Web.Mail.MailPriority.High, "smtp.gmail.com", "465", "2", "1", true, Attachment);
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Mails has been sent successfully');</script>");
                }
            }
        }
        catch (Exception ex)
        {

        }
    }


    protected void btn_Search_Click(object sender, EventArgs e)
    {
        Mode = ddl_Search.SelectedIndex == 1 ? 1 : ddl_Search.SelectedIndex == 2 ? 2 : ddl_Search.SelectedIndex == 3 ? 3 : 0;
        if (Mode != 0)
        {
            if (txt_Search.Text != "")
            {
                dt = new DataTable();
                dt = obj_Class.Search_DisplayAppointDetails(txt_Search.Text, Mode);
                if (dt.Rows.Count > 0)
                {
                    GridStatus.DataSource = dt;
                    GridStatus.DataBind();
                }
                else
                {
                    GridStatus.DataSource = null;
                    GridStatus.DataBind();
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Please enter text to search');</script>");
            }
        }
        else
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Please select any one option to search');</script>");
        }
    }

}
