using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Data;
using System.IO;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;


public partial class MIS_Report : System.Web.UI.Page
{
    string obj_Authenticated;
    PlaceHolder maPlaceHolder;
    UserControl obj_Tabs;
    UserControl obj_LoginCtrl;
    UserControl obj_WelcomCtrl;
    UserControl obj_Navi;
    UserControl obj_Navihome;
    DataTable dt_ProjectNo = new DataTable();
    ClientsReport obj_Class2 = new ClientsReport();
    ProjectBased Obj_Class3 = new ProjectBased();
    Report obj_Class = new Report();
    DataSet ds_WBSNo = new DataSet();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                if (Session["ClientID"].ToString() == "1135")
                {
                    // Get_MsiReport();
                    ChkAuthentication();
                    Load_ProjectNo();
                    btn_DownloadFullMIS.Visible = true;
                }
                else
                {
                    Get_MISReport();
                    btn_DownloadFullMIS.Visible = false;
                    div_not_permission.Visible = true;
                    div_acess_permission.Visible = false;
                    lbl_permission.Text = Resources.Resource.alert_error.Replace("{@message}", "You Don't Have Permission");
                }
            }
        }
        catch (Exception ex)
        {
            Response.Redirect("http://www.scmbizconnect.com/index.html");
        }
    }
    private void ChkAuthentication()
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

    private void SetVisualOFF()
    {
        obj_LoginCtrl.Visible = true;
        obj_WelcomCtrl.Visible = false;
    }

    private void SetVisualON()
    {
        obj_LoginCtrl.Visible = false;
        obj_WelcomCtrl.Visible = true;
    }

    private void Get_MISReport()
    {
        DataSet ds = new DataSet();
        ds = obj_Class.Bizconnect_MISReport(Convert.ToInt32(Session["ClientID"].ToString()));
        grd_MsiReport.DataSource = ds;
        grd_MsiReport.DataBind();
    }

    private void ExportDataSetToExcel(DataSet ds, string filename)
    {
        HttpResponse response = HttpContext.Current.Response;
        response.Clear();
        response.Charset = "";
        response.ContentType = "application/vnd.ms-excel";
        //response.AddHeader("Content-Disposition", "attachment;filename=\"" + filename + "\"");
        response.AddHeader("content-disposition", "attachment;filename=MISREPORT.xls");
        using (StringWriter sw = new StringWriter())
        {

            using (HtmlTextWriter htw = new HtmlTextWriter(sw))
            {

                // instantiate a datagrid   
                DataGrid dg = new DataGrid();
                dg.DataSource = ds.Tables[0];

                dg.DataBind();
                dg.RenderControl(htw);


                response.Write(sw.ToString());

                response.End();
            }
        }
    }

    private void Load_ProjectNo()
    {
        try
        {
            dt_ProjectNo = obj_Class2.BizConnect_Get_ThermaxProjectNO(Convert.ToInt32(Session["ClientID"].ToString()));
            ddl_ProjectNo.DataSource = dt_ProjectNo;
            ddl_ProjectNo.DataTextField = "ProjectNo";
            ddl_ProjectNo.DataValueField = "ProjectID";
            ddl_ProjectNo.DataBind();
            ddl_ProjectNo.Items.Insert(0, "--Select--");
        }
        catch(Exception ex)
        {

        }
    }
    protected void btn_Search_Click(object sender, EventArgs e)
    {
        dt_ProjectNo.Clear();
        dt_ProjectNo = obj_Class.Bizconnect_Search_MSIReportByPJTNoAndWBSNo(ddl_ProjectNo.SelectedItem.Text.Trim(), ddl_Wbsno.SelectedItem.Text.Trim());
        grd_MsiReport.DataSource = dt_ProjectNo;
        grd_MsiReport.DataBind();
        pnl_MisReport.Visible = true;
    }
    protected void btn_DownloadFullMIS_Click(object sender, EventArgs e)
    {
        Get_MsiReport();
    }

    private void Get_MsiReport()
    {
        DataSet ds = new DataSet();
        ds = obj_Class.Bizconnect_MSIReport();
        ExportDataSetToExcel(ds, "MIS Report");
    }

    protected void btnsearch_Click(object sender, EventArgs e)
    {
        try
        {
            if ("1135" == Session["ClientID"].ToString())
            {
                Session["CNFlag"] = "10";
                Session["TAFlag"] = "10";
                Session["LSFlag"] = "-1";
                for (int l = 0; l < chkCNstatus.Items.Count; l++)
                {
                    if (chkCNstatus.Items[l].Selected)
                    {

                        Session["CNFlag"] = Session["CNFlag"] + "," + chkCNstatus.Items[l].Value;

                    }
                }

                for (int l = 0; l < chkTripconfirm.Items.Count; l++)
                {
                    if (chkTripconfirm.Items[l].Selected)
                    {
                        Session["TAFlag"] = chkTripconfirm.Items[l].Value;

                    }
                }

                for (int l = 0; l < chkloadedstatus.Items.Count; l++)
                {
                    if (chkloadedstatus.Items[l].Selected)
                    {

                        Session["LSFlag"] = Session["LSFlag"] + "," + chkloadedstatus.Items[l].Value;

                    }

                }
                Session["LSFlag"] = Session["LSFlag"].ToString().Replace("-1,", "");

                if (Session["CNFlag"] != "10" && Session["TAFlag"] == "10" && Session["LSFlag"] == "-1")
                {
                    DataTable dt = new DataTable();
                    dt = obj_Class.Bizconnect_MSIReportSearch(1, Session["CNFlag"].ToString(), Convert.ToInt32(Session["TAFlag"].ToString()), Session["LSFlag"].ToString(), ddl_ProjectNo.SelectedItem.Text);
                    grd_MsiReport.DataSource = dt;
                    grd_MsiReport.DataBind();
                    pnl_MisReport.Visible = true;
                }


                if (Session["CNFlag"] == "10" && Session["TAFlag"] != "10" && Session["LSFlag"] == "-1")
                {
                    DataTable dt = new DataTable();
                    dt = obj_Class.Bizconnect_MSIReportSearch(2, Session["CNFlag"].ToString(), Convert.ToInt32(Session["TAFlag"].ToString()), Session["LSFlag"].ToString(), ddl_ProjectNo.SelectedItem.Text);
                    grd_MsiReport.DataSource = dt;
                    grd_MsiReport.DataBind();
                    pnl_MisReport.Visible = true;
                }


                if (Session["CNFlag"] == "10" && Session["TAFlag"] == "10" && Session["LSFlag"] != "-1")
                {
                    DataTable dt = new DataTable();
                    dt = obj_Class.Bizconnect_MSIReportSearch(3, Session["CNFlag"].ToString(), Convert.ToInt32(Session["TAFlag"].ToString()), Session["LSFlag"].ToString(), ddl_ProjectNo.SelectedItem.Text);
                    grd_MsiReport.DataSource = dt;
                    grd_MsiReport.DataBind();
                    pnl_MisReport.Visible = true;
                }


                if (Session["CNFlag"] != "10" && Session["TAFlag"] != "10" && Session["LSFlag"] == "-1")
                {
                    DataTable dt = new DataTable();
                    dt = obj_Class.Bizconnect_MSIReportSearch(4, Session["CNFlag"].ToString(), Convert.ToInt32(Session["TAFlag"].ToString()), Session["LSFlag"].ToString(), ddl_ProjectNo.SelectedItem.Text);
                    grd_MsiReport.DataSource = dt;
                    grd_MsiReport.DataBind();
                    pnl_MisReport.Visible = true;
                }

                if (Session["CNFlag"] != "10" && Session["TAFlag"] != "10" && Session["LSFlag"] != "-1")
                {
                    DataTable dt = new DataTable();
                    dt = obj_Class.Bizconnect_MSIReportSearch(5, Session["CNFlag"].ToString(), Convert.ToInt32(Session["TAFlag"].ToString()), Session["LSFlag"].ToString(), ddl_ProjectNo.SelectedItem.Text);
                    grd_MsiReport.DataSource = dt;
                    grd_MsiReport.DataBind();
                    pnl_MisReport.Visible = true;
                }


                if (Session["CNFlag"] == "10" && Session["TAFlag"] != "10" && Session["LSFlag"] != "-1")
                {
                    DataTable dt = new DataTable();
                    dt = obj_Class.Bizconnect_MSIReportSearch(6, Session["CNFlag"].ToString(), Convert.ToInt32(Session["TAFlag"].ToString()), Session["LSFlag"].ToString(), ddl_ProjectNo.SelectedItem.Text);
                    grd_MsiReport.DataSource = dt;
                    grd_MsiReport.DataBind();
                    pnl_MisReport.Visible = true;
                }

                if (Session["CNFlag"] != "10" && Session["TAFlag"] == "10" && Session["LSFlag"] != "-1")
                {
                    DataTable dt = new DataTable();
                    dt = obj_Class.Bizconnect_MSIReportSearch(7, Session["CNFlag"].ToString(), Convert.ToInt32(Session["TAFlag"].ToString()), Session["LSFlag"].ToString(), ddl_ProjectNo.SelectedItem.Text);
                    grd_MsiReport.DataSource = dt;
                    grd_MsiReport.DataBind();
                    pnl_MisReport.Visible = true;
                }
            }
        }
        catch (Exception ex)
        {
        }

    }

    protected void ddl_ProjectNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        ds_WBSNo = Obj_Class3.Bizconnect_ThermaxCnote_LoadWBSNoBasedOnProject(ddl_ProjectNo.SelectedItem.Text.Trim());
        ddl_Wbsno.Items.Clear();
        ddl_Wbsno.DataSource = ds_WBSNo;
        ddl_Wbsno.DataTextField = "WBSNo";
        ddl_Wbsno.DataValueField = "WBSNo";
        ddl_Wbsno.DataBind();
        ddl_Wbsno.Items.Insert(0, "--Select--");
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        ExportGrid(grd_MsiReport, "MISReport.xls");
    }

    private void ExportGrid(GridView oGrid, string exportFile)
    {
        HttpContext.Current.Response.Clear();
        HttpContext.Current.Response.Buffer = true;
        HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";
        HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=\"" + exportFile + "\"");
        HttpContext.Current.Response.Charset = "";
        System.IO.StringWriter oStringWriter = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter oHtmlTextWriter = new System.Web.UI.HtmlTextWriter(oStringWriter);
        ClearControls(oGrid);
        oGrid.GridLines = GridLines.Both;
        oGrid.HeaderStyle.BackColor = System.Drawing.Color.Yellow;
        oGrid.HeaderStyle.ForeColor = System.Drawing.Color.Black;
        oGrid.RenderControl(oHtmlTextWriter);
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


    protected void btn_downloadsearch_Click(object sender, EventArgs e)
    {
        try
        {
            string ClientID=Session["ClientID"].ToString();
            string year = ddl_year.SelectedItem.ToString();
            if (year != null)
            {
                try
                {
                    String conn = ConfigurationManager.ConnectionStrings["Bizcon"].ConnectionString;
                    using (SqlConnection con1 = new SqlConnection(conn))
                    {
                        using (SqlCommand cmd1 = new SqlCommand("Bizconnect_GetYear_Details", con1))
                        {
                            SqlDataAdapter sda = new SqlDataAdapter(cmd1);
                            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                            sda.SelectCommand.Parameters.AddWithValue("@ClientID", ClientID);
                            sda.SelectCommand.Parameters.AddWithValue("@year", year);
                            try
                            {
                                cmd1.Connection = con1;
                                con1.Open();
                                sda.SelectCommand = cmd1;

                                DataSet ds = new DataSet();
                                sda.Fill(ds);
                                if(ds.Tables[0].Rows.Count>0)
                                {
                                

                                // BIND DATABASE WITH THE GRIDVIEW.
                                grd_MsiReport.DataSource = ds;
                                grd_MsiReport.DataBind();
                                pnl_MisReport.Visible = true;
                               // Lblmsg.Text = " No of Registration='" + AdminGrid.Rows.Count + "'";
                                }
                                else
                                {
                                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Error! No Details Found!');</script>");
                                }
                                
                            }
                            catch (Exception ex)
                            {
                            }
                        }
                    }

                }
                catch(Exception ex)
                {

                }
            }
            else
            {

            }
        }
        catch(Exception ex)
        {
        }

    }
    protected void btn_download_Click(object sender, EventArgs e)
    {
        Get_YearReport();

    }

    private void Get_YearReport()
    {
        string ClientID = Session["ClientID"].ToString();
        string year = ddl_year.SelectedItem.ToString();
        if (year != null)
        {
            try
            {
                String conn = ConfigurationManager.ConnectionStrings["Bizcon"].ConnectionString;
                using (SqlConnection con1 = new SqlConnection(conn))
                {
                    using (SqlCommand cmd1 = new SqlCommand("Bizconnect_GetYear_Details", con1))
                    {
                        SqlDataAdapter sda = new SqlDataAdapter(cmd1);
                        sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                        sda.SelectCommand.Parameters.AddWithValue("@ClientID", ClientID);
                        sda.SelectCommand.Parameters.AddWithValue("@year", year);
                        try
                        {
                            cmd1.Connection = con1;
                            con1.Open();
                            sda.SelectCommand = cmd1;

                            DataSet ds = new DataSet();
                            sda.Fill(ds);
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                ExportDataSetToExcel(ds, "MIS Report");
                            }
                            else
                            {
                                ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Error! No Details Found!');</script>");
                            }
                        }
                        catch (Exception ex)
                        {
                        }
                    }
                }

            }
            catch (Exception ex)
            {

            }
        }
        //ExportDataSetToExcel(ds1, "MIS Report");
    }
    
}