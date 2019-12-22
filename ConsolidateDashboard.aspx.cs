﻿using System;
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

public partial class ConsolidateDashboard : System.Web.UI.Page
{

    string obj_Authenticated;
    PlaceHolder maPlaceHolder;
    UserControl obj_Tabs;
    UserControl obj_LoginCtrl;
    UserControl obj_WelcomCtrl;
    UserControl obj_Navi;
    UserControl obj_Navihome;
    UserControl obj_left;


    AarmsUser obj_class = new AarmsUser();
    DataSet ds;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ds = new DataSet();
                ds=obj_class.Bizconnect_ShowLogisticsplan();
                LogisticsPlanGrid.DataSource=ds;
                LogisticsPlanGrid.DataBind();
                ds = new DataSet();
                ds = obj_class.Bizconnect_ShowQuotedRates();
               QuoteReceivedGrid.DataSource = ds;
               QuoteReceivedGrid.DataBind();

               ChkAuthentication();
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


    protected void But_Trip_Click(object sender, EventArgs e)
    {

        ExportGrid(LogisticsPlanGrid  , "TripPlan.xls");

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
    protected void But_RoutePrice_Click(object sender, EventArgs e)
    {
        ExportGrid(QuoteReceivedGrid , "RoutePrice.xls");
    }
}
