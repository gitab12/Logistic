using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Collections;
using System.Data;
using System.Text;
using System.IO;

public partial class Transporteranalytics : System.Web.UI.Page
{

    string obj_Authenticated;
    PlaceHolder maPlaceHolder;
    UserControl obj_Tabs;
    UserControl obj_LoginCtrl;
    UserControl obj_WelcomCtrl;
    UserControl obj_Navi;
    UserControl obj_Navihome;


    DataSet ds = new DataSet();


    Report obj_Report = new Report();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int month = System.DateTime.Now.Month;
          int uear = System.DateTime.Now.Year;
            SelectMonth.SelectedIndex = month;
            GridBind();
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



    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (rad_monthwise.Checked)
        {

            if (SelectMonth.SelectedIndex == 0 && SelectYear.SelectedIndex == 0)
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey1", "alert('Please Select fields');", true);
            }

            else
            {
                GridBind();
            }
        }
        else
        {
            GridBind();
        }
    }
    public void GridBind()
    {
        string Userid = Session["UserID"].ToString();
        DataSet ds ;
        if (rad_monthwise.Checked)
        {
             ds = obj_Report.Get_TransportAnalysisReport(Userid, SelectMonth.SelectedValue, SelectYear.SelectedValue, "0", 1);
        }
        else
        {
            string[] DMY = txtFrom.Text.Split('/');
            int year, month, day;

            int.TryParse(DMY[0], out month);
            int.TryParse(DMY[1], out day  );
            int.TryParse(DMY[2], out year);
             ds= obj_Report.Get_TransportAnalysisReport(Userid, Convert.ToString(month), Convert.ToString(year), Convert.ToString(day), 2);
        }

        if (ds.Tables[0].Rows.Count > 0)
        {
            grd_TransportAnalysis.DataSource = ds.Tables[0];
            grd_TransportAnalysis.DataBind();
        }
        else
        {

            Page.ClientScript.RegisterStartupScript(GetType(), "MyKey2", "alert('Data Not Found');", true);
        }
    }
    protected void rad_monthwise_CheckedChanged(object sender, EventArgs e)
    {
        SelectMonth.Visible = true;
        SelectYear.Visible = true;
        txtFrom.Visible = false ;
        imgdate1.Visible = false;
    }
    protected void rad_Daywise_CheckedChanged(object sender, EventArgs e)
    {
        SelectMonth.Visible = false ;
        SelectYear.Visible = false;
        txtFrom.Visible = true;
        imgdate1.Visible = true;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        ExportGrid(grd_TransportAnalysis, "Transporteranalytics Report");

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

    public override void VerifyRenderingInServerForm(Control control)
    {

    }
    
}