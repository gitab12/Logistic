using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;

using System.Text;

public partial class RcVsActual : System.Web.UI.Page
{


    string obj_Authenticated;
    PlaceHolder maPlaceHolder;
    UserControl obj_Tabs;
    UserControl obj_LoginCtrl;
    UserControl obj_WelcomCtrl;
    UserControl obj_Navi;
    UserControl obj_Navihome;




    Report obj_Class = new Report();
    DataTable dt = new DataTable();
    DataTable dt_Details = new DataTable();
    DataTable dt_Pjt = new DataTable();
    DataTable dt_Wbs = new DataTable();
    DataTable dt_Transporter = new DataTable();
    DataTable dt_RcActual = new DataTable();

    string Project, WbsNo;
    int SNo,Diff;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadGrid();
            LoadProjectNo();
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




    public void LoadGrid()
    {
        dt = obj_Class.Bizconnect_RcVsActual(Convert.ToInt32(Session["ClientID"].ToString()));
        grd_RcVsActual.DataSource = dt;
        grd_RcVsActual.DataBind();
    }

    public void LoadProjectNo()
    {
        try
        {
            dt_Pjt = obj_Class.Bizconnect_LoadProectNoForRcVsActual(Convert.ToInt32(Session["ClientID"].ToString()));
            ddl_ProjectNo.DataSource = dt_Pjt;
            ddl_ProjectNo.DataTextField = "ProjectNo";
            ddl_ProjectNo.DataBind();
            ddl_ProjectNo.Items.Insert(0, new ListItem("--Select--", "0"));
        }
        catch (Exception ex)
        {

        }
    }

    protected void grd_RcVsActual_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try{
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Project = e.Row.Cells[0].Text;
                WbsNo = e.Row.Cells[1].Text;
                SNo = Convert.ToInt32(grd_RcVsActual.DataKeys[e.Row.RowIndex].Values[0].ToString());
                //SNo = Convert.ToInt32(e.Row.Cells[10].Text);
                dt_Details = obj_Class.Bizconnect_RcVsActualDetails(Project, WbsNo, SNo);
                Label Transporter = (Label)e.Row.FindControl("lbl_Transporter");
                Label CnGenerated = (Label)e.Row.FindControl("lbl_CNGenerated");
                Label VehPlanned = (Label)e.Row.FindControl("lbl_VehPlanned");
                Label VehPlaced = (Label)e.Row.FindControl("lbl_VehPlaced");
                Label BalVehicles = (Label)e.Row.FindControl("lbl_BalVehicles");
                if (dt_Details.Rows.Count > 0)
                {
                    Transporter.Text = dt_Details.Rows[0][3].ToString();
                    CnGenerated.Text = dt_Details.Rows[0][4].ToString();
                    //e.Row.Cells[12].Text = dt_Details.Rows[0][];
                    VehPlanned.Text = dt_Details.Rows[0][5].ToString();
                    VehPlaced.Text = dt_Details.Rows[0][6].ToString();
                    Diff = (Convert.ToInt32(e.Row.Cells[6].Text)) - Convert.ToInt32(VehPlaced.Text);
                    BalVehicles.Text = Diff.ToString();
                }
                else
                {
                    BalVehicles.Text = e.Row.Cells[6].Text;
                    dt_Transporter = obj_Class.Bizconnect_LoadTransporterforRcvsActual(Project);
                    if (dt_Transporter.Rows.Count > 0)
                    {
                        Transporter.Text = dt_Transporter.Rows[0][0].ToString();
                    }
                    else
                    {

                    }
                }

            }
        }
            catch (Exception ex)
        {
            }

    }



    protected void btn_Search_Click(object sender, EventArgs e)
    {
        dt.Clear();
        if (ddl_ProjectNo.SelectedItem.Text != "--Select--")
        {
            if (ddl_ProjectNo.SelectedItem.Text != "--Select--" && ddl_WbsNo.SelectedItem.Text == "--Select--")
            {
                dt = obj_Class.Bizconnect_SearchRcVsActualDetailsByProjectAndWbsNo(ddl_ProjectNo.SelectedItem.Text, "--Select--");
                grd_RcVsActual.DataSource = dt;
                grd_RcVsActual.DataBind();
            }
            if (ddl_ProjectNo.SelectedItem.Text != "--Select--" && ddl_WbsNo.SelectedItem.Text != "--Select--")
            {
                dt = obj_Class.Bizconnect_SearchRcVsActualDetailsByProjectAndWbsNo(ddl_ProjectNo.SelectedItem.Text, ddl_WbsNo.SelectedItem.Text);
                grd_RcVsActual.DataSource = dt;
                grd_RcVsActual.DataBind();
            }
        }
        else
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Please select any project no to search');</script>");
            LoadGrid();
        }
    }
    protected void ddl_ProjectNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            dt_Wbs = obj_Class.Bizconnect_LoadWbsNoForRcVsActual(ddl_ProjectNo.SelectedItem.Text);
            ddl_WbsNo.DataSource = dt_Wbs;
            ddl_WbsNo.DataTextField = "WBS";
            ddl_WbsNo.DataBind();
            ddl_WbsNo.Items.Insert(0, new ListItem("--Select--", "0"));
        }
        catch (Exception ex)
        {

        }
    }


    protected void btn_Download_Click(object sender, EventArgs e)
    {

        //ExportGrid(grd_RcVsActual, "RcVsActual.xls");

        if (ddl_ProjectNo.SelectedItem.Text != "--Select--")
        {
            if (ddl_ProjectNo.SelectedItem.Text != "--Select--" && ddl_WbsNo.SelectedItem.Text == "--Select--")
            {
                dt = obj_Class.Bizconnect_SearchRcVsActualDetailsByProjectAndWbsNo(ddl_ProjectNo.SelectedItem.Text, "--Select--");
                grd_RcVsActual.DataSource = dt;
                grd_RcVsActual.DataBind();
                ExportGrid(grd_RcVsActual, "RcVsActual.xls");
            }
            if (ddl_ProjectNo.SelectedItem.Text != "--Select--" && ddl_WbsNo.SelectedItem.Text != "--Select--")
            {
                dt = obj_Class.Bizconnect_SearchRcVsActualDetailsByProjectAndWbsNo(ddl_ProjectNo.SelectedItem.Text, ddl_WbsNo.SelectedItem.Text);
                grd_RcVsActual.DataSource = dt;
                grd_RcVsActual.DataBind();
                ExportGrid(grd_RcVsActual, "RcVsActual.xls");
            }
        }
        else
        {
            LoadGrid();
            //ExportGrid(grd_RcVsActual, "RcVsActual.xls");
            ExportData(dt, "RcVsActual.xls");
        }

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
        //oGrid.HeaderStyle.BackColor = System.Drawing.Color.LightGray;

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


    

    public void ExportData(DataTable oGrid, string exportFile)
    {
        try
        {
            Response.ClearContent();
            Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "MIS Report"));
            HttpContext.Current.Response.ContentType = "text/csv";
            HttpContext.Current.Response.AddHeader("Pragma", "public");
            // oGrid.AllowPaging = false;
            //oGrid.DataBind();
            StringBuilder strbldr = new StringBuilder();
            for (int i = 0; i < oGrid.Columns.Count; i++)
            {
                //separting header columns text with comma operator
                strbldr.Append(oGrid.Columns[i].ColumnName + ',');
            }
            //appending new line for gridview header row
            strbldr.Append("\n");
            for (int j = 0; j < oGrid.Rows.Count; j++)
            {

                for (int k = 0; k < oGrid.Columns.Count; k++)
                {
                    //separating gridview columns with comma

                    //strbldr.Append(oGrid.Rows[j].Cells[k].ToString() + ',');

                    strbldr.Append(oGrid.Rows[j].ItemArray[k].ToString().Replace(",", "").ToString() + ',');
                }
                //appending new line for gridview rows
                strbldr.Append("\n");
            }
            Response.Write(strbldr.ToString());
            Response.End();
        }
        catch (Exception ex)
        {
        }
    }

    protected void grd_RcVsActual_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grd_RcVsActual.PageIndex = e.NewPageIndex;
        LoadGrid();
    }

}