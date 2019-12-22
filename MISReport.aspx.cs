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
using System.IO;

public partial class MISReport : System.Web.UI.Page
{
    string obj_Authenticated;
    PlaceHolder maPlaceHolder;
    UserControl obj_Tabs;
    UserControl obj_LoginCtrl;
    UserControl obj_WelcomCtrl;
    UserControl obj_Navi;
    UserControl obj_Navihome;


    Report obj_Class = new Report();
    DataTable dt_ProjectNo = new DataTable();
    ClientsReport obj_Class2 = new ClientsReport();
    ProjectBased Obj_Class3 = new ProjectBased();
    DataSet ds_WBSNo = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if ("1135" == Session["ClientID"].ToString())
            {
               // Get_MsiReport();
                 Load_ProjectNo();
                 btn_DownloadFullMIS.Visible = true;
            } 
            else
            {
            Get_MISReport();
            btn_DownloadFullMIS.Visible = false;
            }
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

    
    public void Get_MISReport()
    {
        DataSet ds = new DataSet();
        ds = obj_Class.Bizconnect_MISReport(Convert.ToInt32(Session["ClientID"].ToString()));
        grd_MsiReport.DataSource = ds;
        grd_MsiReport.DataBind();
    }
    
    
    
    public void Get_MsiReport()
    {
        DataSet ds = new DataSet();
        ds = obj_Class.Bizconnect_MSIReport();
        ExportDataSetToExcel(ds, "MIS Report");
        //grd_MsiReport.DataSource = dt;
        //grd_MsiReport.DataBind();
    }
    
    
    protected void btnsearch_Click(object sender, EventArgs e)
    {
try 
{
  if ("1135" == Session["ClientID"].ToString())
            {
	Session["CNFlag"]="10";
		Session["TAFlag"]="10";
			Session["LSFlag"]="-1";
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
 Session["LSFlag"]= Session["LSFlag"].ToString().Replace("-1,", "");
  
if(Session["CNFlag"]!="10" && Session["TAFlag"]=="10" && Session["LSFlag"]=="-1")
{
		DataTable dt = new DataTable();
        dt = obj_Class.Bizconnect_MSIReportSearch(1, Session["CNFlag"].ToString(), Convert.ToInt32(Session["TAFlag"].ToString()), Session["LSFlag"].ToString(),ddl_ProjectNo.SelectedItem.Text);
        grd_MsiReport.DataSource = dt;
        grd_MsiReport.DataBind();
        pnl_MisReport.Visible = true;
        }
        
        
       if(Session["CNFlag"]=="10" && Session["TAFlag"]!="10" && Session["LSFlag"]=="-1")
{
		DataTable dt = new DataTable();
        dt = obj_Class.Bizconnect_MSIReportSearch(2, Session["CNFlag"].ToString(), Convert.ToInt32(Session["TAFlag"].ToString()), Session["LSFlag"].ToString(), ddl_ProjectNo.SelectedItem.Text);
        grd_MsiReport.DataSource = dt;
        grd_MsiReport.DataBind();
        pnl_MisReport.Visible = true;
        } 
        
             
       if(Session["CNFlag"]=="10" && Session["TAFlag"]=="10" && Session["LSFlag"]!="-1")
{
		DataTable dt = new DataTable();
        dt = obj_Class.Bizconnect_MSIReportSearch(3, Session["CNFlag"].ToString(), Convert.ToInt32(Session["TAFlag"].ToString()), Session["LSFlag"].ToString(), ddl_ProjectNo.SelectedItem.Text);
        grd_MsiReport.DataSource = dt;
        grd_MsiReport.DataBind();
        pnl_MisReport.Visible = true;
        } 
        
             
       if(Session["CNFlag"]!="10" && Session["TAFlag"]!="10" && Session["LSFlag"]=="-1")
{
		DataTable dt = new DataTable();
        dt = obj_Class.Bizconnect_MSIReportSearch(4, Session["CNFlag"].ToString(), Convert.ToInt32(Session["TAFlag"].ToString()), Session["LSFlag"].ToString(), ddl_ProjectNo.SelectedItem.Text);
        grd_MsiReport.DataSource = dt;
        grd_MsiReport.DataBind();
        pnl_MisReport.Visible = true;
        }         
     
          if(Session["CNFlag"]!="10" && Session["TAFlag"]!="10" && Session["LSFlag"]!="-1")
{
		DataTable dt = new DataTable();
        dt = obj_Class.Bizconnect_MSIReportSearch(5, Session["CNFlag"].ToString(), Convert.ToInt32(Session["TAFlag"].ToString()), Session["LSFlag"].ToString(), ddl_ProjectNo.SelectedItem.Text);
        grd_MsiReport.DataSource = dt;
        grd_MsiReport.DataBind();
        pnl_MisReport.Visible = true;
        }   
        
        
           if(Session["CNFlag"]=="10" && Session["TAFlag"]!="10" && Session["LSFlag"]!="-1")
{
		DataTable dt = new DataTable();
        dt = obj_Class.Bizconnect_MSIReportSearch(6, Session["CNFlag"].ToString(), Convert.ToInt32(Session["TAFlag"].ToString()), Session["LSFlag"].ToString(), ddl_ProjectNo.SelectedItem.Text);
        grd_MsiReport.DataSource = dt;
        grd_MsiReport.DataBind();
        pnl_MisReport.Visible = true;
        }   
        
           if(Session["CNFlag"]!="10" && Session["TAFlag"]=="10" && Session["LSFlag"]!="-1")
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
    
     protected void Button2_Click(object sender, EventArgs e)
    {

        ExportGrid(grd_MsiReport, "MISReport.xls");

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
        oGrid.HeaderStyle.BackColor = System.Drawing.Color.Yellow;
        oGrid.HeaderStyle.ForeColor = System.Drawing.Color.Black;

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
    protected void ddl_ProjectNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        ds_WBSNo = Obj_Class3.Bizconnect_ThermaxCnote_LoadWBSNoBasedOnProject(ddl_ProjectNo.SelectedItem .Text.Trim());
        ddl_Wbsno.Items.Clear();
        ddl_Wbsno.DataSource = ds_WBSNo;
        ddl_Wbsno.DataTextField = "WBSNo";
        ddl_Wbsno.DataValueField = "WBSNo";
        ddl_Wbsno.DataBind();
        ddl_Wbsno.Items.Insert(0, "--Select--");
    }
    protected void btn_Search_Click(object sender, EventArgs e)
    {
        dt_ProjectNo.Clear();
        dt_ProjectNo = obj_Class.Bizconnect_Search_MSIReportByPJTNoAndWBSNo(ddl_ProjectNo .SelectedItem .Text.Trim () ,ddl_Wbsno .SelectedItem .Text.Trim());
        grd_MsiReport.DataSource = dt_ProjectNo;
        grd_MsiReport.DataBind();
        pnl_MisReport.Visible = true;
       
    }


    protected void btn_DownloadFullMIS_Click(object sender, EventArgs e)
    {
        Get_MsiReport();
    }

    public void ExportDataSetToExcel(DataSet ds, string filename)
    {
        HttpResponse response = HttpContext.Current.Response;

        // first let's clean up the response.object   
        response.Clear();
        response.Charset = "";

        // set the response mime type for excel   
        response.ContentType = "application/vnd.ms-excel";

        response.AddHeader("Content-Disposition", "attachment;filename=\"" + filename + "\"");

        // create a string writer   

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

}
