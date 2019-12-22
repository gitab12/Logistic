using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class CollectionStatusReport : System.Web.UI.Page
{

    string obj_Authenticated, obj_emailid;
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
           if("1135" == Session["ClientID"].ToString())
           {
           CollectionNoteStatusReport();
            Load_ProjectNo();
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
        //   obj_Navihome.Visible = true;

    }
    public void SetVisualOFF()
    {
        obj_LoginCtrl.Visible = true;
        obj_WelcomCtrl.Visible = false;
        //obj_Navi.Visible = true;
        //  obj_Navihome.Visible = false;
    }



 public void Load_ProjectNo()
    {
        dt_ProjectNo = obj_Class2.BizConnect_Get_ThermaxProjectNO(Convert.ToInt32(Session["ClientID"].ToString()));
        ddl_ProjectNo.DataSource = dt_ProjectNo;
        ddl_ProjectNo.DataTextField = "ProjectNo";
        ddl_ProjectNo.DataValueField = "ProjectID";
        ddl_FromPJTNo.DataSource = dt_ProjectNo;
        ddl_FromPJTNo.DataTextField = "ProjectNo";
        ddl_FromPJTNo.DataValueField = "ProjectID";
        ddl_ToPJTNo.DataSource = dt_ProjectNo;
        ddl_ToPJTNo.DataTextField = "ProjectNo";
        ddl_ToPJTNo.DataValueField = "ProjectID";

        ddl_ProjectNo.DataBind();
        ddl_FromPJTNo.DataBind();
        ddl_ToPJTNo.DataBind();
        ddl_ProjectNo.Items.Insert(0, "--Select--");
        ddl_FromPJTNo.Items.Insert(0, "--Select--");
        ddl_ToPJTNo.Items.Insert(0, "--Select--");
    }

    public void CollectionNoteStatusReport()
    {
        DataSet ds = new DataSet();
        ds = obj_Class.Bizconnect_CollectionNoteStatusReport();
        GridReport.DataSource = ds;
        GridReport.DataBind();

    }
    
     protected void Butexporttoexcel_Click(object sender, EventArgs e)
    {

        ExportGrid(GridReport, "CollectionNoteReport.xls");

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
    
    protected void ddl_ProjectNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        ds_WBSNo = Obj_Class3.Bizconnect_ThermaxCnote_LoadWBSNoBasedOnProject(ddl_ProjectNo.SelectedItem .Text);
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
        dt_ProjectNo = obj_Class.Bizconnect_Search_CNoteStatusReportByPJTNoAndWbsno(ddl_ProjectNo.SelectedItem.Text, ddl_Wbsno.SelectedItem.Text);
        GridReport.DataSource = dt_ProjectNo;
        GridReport.DataBind();
    }

    protected void btn_AdvanceSearch_Click(object sender, EventArgs e)
    {
        dt_ProjectNo.Clear();
        dt_ProjectNo = obj_Class.Bizconnect_CNoteStatusReportAdvancedSearchByPJTNo(ddl_FromPJTNo.SelectedItem.Text, ddl_ToPJTNo.SelectedItem.Text);
        GridReport.DataSource = dt_ProjectNo;
        GridReport.DataBind();
    }
    
}