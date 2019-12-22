using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data ;
public partial class DetailReport : System.Web.UI.Page
{

    string obj_Authenticated;
    PlaceHolder maPlaceHolder;
    UserControl obj_Tabs;
    UserControl obj_LoginCtrl;
    UserControl obj_WelcomCtrl;
    UserControl obj_Navi;
    UserControl obj_Navihome;
     BizCon_DB_ConnectionString con = new BizCon_DB_ConnectionString();



    Report obj_Class=new Report ();
    DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {

        ChkAuthentication();
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




    protected void btn_Search_Click(object sender, EventArgs e)
    {
        try
        {
            
            if (txt_From.Text != "" && txt_To.Text != "")
            {
                //dt = obj_Class.Bizconnect_GetDetailReport(Convert.ToInt32(Session["ClientID"]), Convert.ToInt32(Session["UserID"]), Convert.ToDateTime(txt_From.Text), Convert.ToDateTime(txt_To.Text));
                string cid = Session["ClientID"].ToString();
                string userid = Session["UserID"].ToString();
                string from = txt_From.Text;
                string to = txt_To.Text;

                string[] args = { "@clientid", "@userid", "@fromdate", "@todate" };
                string[] argsval = { cid,userid,from,to };
                DataSet ds = new DataSet();
                ds = con.Sql_GetData("Bizconnect_GetDetails_Report", args, argsval);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    grd_DetailReport.DataSource = ds;
                    grd_DetailReport.DataBind();
                    pnl_Delivery.Visible = true;
                }
                else
                {

                    // showing no record found with headers
                    //dt.Rows.Add(dt.NewRow());
                    //grd_DetailReport.DataSource = dt;
                    //grd_DetailReport.DataBind();
                    //int columncount = grd_DetailReport.Columns.Count;
                    //grd_DetailReport.Rows[0].Cells.Clear();
                    //grd_DetailReport.Rows[0].Cells.Add(new TableCell());
                    //grd_DetailReport.Rows[0].Cells[0].ColumnSpan = 3;
                    ////You can set the styles here
                    //grd_DetailReport.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
                    //grd_DetailReport.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
                    //grd_DetailReport.Rows[0].Cells[0].Font.Bold = true;
                    //grd_DetailReport.Rows[0].Cells[0].Text = "No Records Found";

                    // showing no record found without headers
                    grd_DetailReport.DataSource = null;
                    grd_DetailReport.DataBind();
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Select fromdate and todate to search');</script>");
            }
      }
        catch (Exception ex)
        {

        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {

        ExportGrid(grd_DetailReport, "DetailedMISReport.xls");

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
    protected void grd_DetailReport_RowDataBound(object sender, GridViewRowEventArgs e)
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
            e.Row.Cells[7].Width = 60;
            e.Row.Cells[8].Width = 70;
            e.Row.Cells[9].Width = 80;
            e.Row.Cells[10].Width = 30;
            e.Row.Cells[11].Width = 40;

        }
    }
}