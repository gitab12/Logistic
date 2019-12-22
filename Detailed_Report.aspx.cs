using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Detailed_Report : System.Web.UI.Page
{
    BizCon_DB_ConnectionString con = new BizCon_DB_ConnectionString();
    string obj_Authenticated;
    PlaceHolder maPlaceHolder;
    UserControl obj_Tabs;
    UserControl obj_LoginCtrl;
    UserControl obj_WelcomCtrl;
    UserControl obj_Navi;
    UserControl obj_Navihome;
    protected void Page_Load(object sender, EventArgs e)
    {
        //string loaddate = Session["LoadDate"].ToString();
       //DateTime dtt = new DateTime();
       // dtt = DateTime.Now.Date;
       // txt_datefrom.Text = dtt.ToString("MM/DD/YYYY");
       // Session["FromDate"] = txt_datefrom.Text;
       // txt_dateto.Text = dtt.ToString("MM/DD/YYYY");
       // Session["ToDate"] = txt_dateto.Text;
        LoadDetails();
        ChkAuthentication();
        LinkButton1.Visible = false;
    }

    private void LoadDetails()
    {
        try
        {
            //string userid = Session["UserID"].ToString();
            //if (userid != "")
            //{
            //    string[] args = { "@userid" };
            //    string[] argsval = { userid };
            //    DataSet ds_details = new DataSet();
            //    ds_details = con.Sql_GetData("Bizconnect_detailed_report", args, argsval);
            //    if (ds_details.Tables[0].Rows.Count > 0)
            //    {
            //        gv_detailed.DataSource = ds_details;
            //        gv_detailed.DataBind();
            //    }
            //}
            //else
            //{
                string userid = Session["UserID"].ToString();
                string fromdate = txt_datefrom.Text;
                 string todate =txt_dateto.Text;
                 string[] _args = { "@userid", "@fromdate", "@todate" };
                string[] _argsval = { userid, fromdate, todate };
                DataSet ds = new DataSet();
                ds = con.Sql_GetData("Bizconnect_detailedforFosroc", _args, _argsval);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    btn_search.Visible = true;
					LinkButton1.Visible = true;
                    gv_detailed.DataSource = ds;
                    gv_detailed.DataBind();
                }
            //}
        }
        catch(Exception ex)

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

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        ExportGrid(gv_detailed, "DetailedReport.xls");
    }

    private void ExportGrid(GridView oGrid, string exportFile)
    {
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
    protected void btn_search_Click(object sender, EventArgs e)
    {
        try
        {
            string userid = Session["UserID"].ToString();
            string fromdate = txt_datefrom.Text;
            string todate = txt_dateto.Text;
            string[] _args = { "@userid", "@fromdate", "@todate" };
            string[] _argsval = { userid, fromdate, todate };
            DataSet ds = new DataSet();
            ds = con.Sql_GetData("Bizconnect_detailedforFosroc", _args, _argsval);
            if (ds.Tables[0].Rows.Count > 0)
            {

                try
                {

                    LinkButton1.Visible = true;
                    gv_detailed.DataSource = ds;
                    gv_detailed.DataBind();
                }
                catch (Exception ex)
                {

                }
            }
        }
        catch (Exception ex)
        {

        }
    }
}