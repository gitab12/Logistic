using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class DelayStatusReport : System.Web.UI.Page
{
    string obj_Authenticated;
    PlaceHolder maPlaceHolder;
    UserControl obj_Tabs;
    UserControl obj_LoginCtrl;
    UserControl obj_WelcomCtrl;
    UserControl obj_Navi;
    UserControl obj_Navihome;

    Report obj_Class = new Report();
    ClientsReport obj_Class2 = new ClientsReport();
      DataTable dt_ProjectNo = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            CollectionNoteStatusReport();
            Load_ProjectNo();
            ChkAuthentication();

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

public void Load_ProjectNo()
    {
        dt_ProjectNo = obj_Class2.BizConnect_Get_ThermaxProjectNO(Convert.ToInt32(Session["ClientID"].ToString()));
        ddl_ProjectNo.DataSource = dt_ProjectNo;
        ddl_ProjectNo.DataTextField = "ProjectNo";
        ddl_ProjectNo.DataValueField = "ProjectID";
        ddl_ProjectNo.DataBind();
        ddl_ProjectNo.Items.Insert(0, "--Select--");
    }

    public void CollectionNoteStatusReport()
    {
        DataSet ds = new DataSet();
        ds = obj_Class.Bizconnect_DelayStatusReport(Convert.ToInt32(Session["ClientID"].ToString()));
        GridReport.DataSource = ds;
        GridReport.DataBind();

    }
     protected void btnsearch_Click(object sender, EventArgs e)
    {
    try
        {
            DataSet ds = new DataSet();
            ds.Clear();
            if (txtFromdate.Text == string.Empty && txtTodate.Text == string.Empty)
            {
                DateTime FromDate = Convert.ToDateTime("5/22/2005 00:00:00 AM");
                DateTime ToDate = Convert.ToDateTime("6/22/2005 00:00:00 AM");
                ds = obj_Class.Bizconnect_DelayStatusReportSearch(Convert.ToInt32(Session["ClientID"].ToString()), Convert.ToDateTime(FromDate), Convert.ToDateTime(ToDate), ddl_ProjectNo.SelectedItem.Text);
            }
            if (txtFromdate.Text != string.Empty && txtTodate.Text != string.Empty && ddl_ProjectNo.SelectedItem.Text != "--Select--")
            {
                DateTime FromDate = Convert.ToDateTime(txtFromdate.Text);
                DateTime ToDate = Convert.ToDateTime(txtTodate.Text);
                ds = obj_Class.Bizconnect_DelayStatusReportSearch(Convert.ToInt32(Session["ClientID"].ToString()), Convert.ToDateTime(FromDate), Convert.ToDateTime(ToDate), ddl_ProjectNo.SelectedItem.Text);

            }
            if (txtFromdate.Text != string.Empty && txtTodate.Text != string.Empty && ddl_ProjectNo.SelectedItem.Text == "--Select--")
            {
                DateTime FromDate = Convert.ToDateTime(txtFromdate.Text);
                DateTime ToDate = Convert.ToDateTime(txtTodate.Text);
                ds = obj_Class.Bizconnect_DelayStatusReportSearch(Convert.ToInt32(Session["ClientID"].ToString()), Convert.ToDateTime(FromDate), Convert.ToDateTime(ToDate), "");
            }
            GridReport.DataSource = ds;
            GridReport.DataBind();
        }
        catch (Exception ex)
        {
        }
    }
     protected void Button1_Click(object sender, EventArgs e)
    {

        ExportGrid(GridReport, "DelayStatusReport.xls");

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

    protected void GridReport_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[0].Width = 30;
            e.Row.Cells[1].Width = 50;
            e.Row.Cells[2].Width = 50;
            e.Row.Cells[3].Width = 25;
            e.Row.Cells[4].Width = 30;
            e.Row.Cells[5].Width = 30;
            e.Row.Cells[6].Width = 30;
            e.Row.Cells[7].Width = 50;
            e.Row.Cells[8].Width = 40;
            e.Row.Cells[9].Width = 50;
            e.Row.Cells[10].Width = 50;
            e.Row.Cells[11].Width = 50;
            e.Row.Cells[12].Width = 50;
            e.Row.Cells[13].Width = 40;

        }
    }

}
