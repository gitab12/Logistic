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
using System.Globalization;
using System.Text;
using System.IO;

public partial class TripAssignAcceptanceReport : System.Web.UI.Page
{
    ClientsReport obj_Class = new ClientsReport();
    DataSet ds_Search = new DataSet();
    DataTable dt_Search = new DataTable();
    DataTable dt_ProjectNo = new DataTable();
    DataTable dt;
    string obj_Authenticated;
    PlaceHolder maPlaceHolder;
    UserControl obj_Tabs;
    UserControl obj_LoginCtrl;
    UserControl obj_WelcomCtrl;
    UserControl obj_Navi;
    UserControl obj_Navihome;
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
     if (Session["UserID"] != string.Empty && Convert.ToInt32(Session["UserID"].ToString()) > 0)
      {
        if (!IsPostBack)
        {
            ChkAuthentication();
            LoadTripDetails();
             Load_ProjectNo();
        }
      }
      
        else
        {
            Response.Redirect("Index.html");
        }  

    }
    public void LoadTripDetails()
    {
        try
        {
            ds = obj_Class.BizConnect_UserTripAssignReport(Convert.ToInt32(Session["UserID"].ToString()));
            Gridwindow.DataSource = ds;
            Gridwindow.DataBind();
        }
        catch (Exception ex)
        {
        }

    }
    
    public void Load_ProjectNo()
    {
        dt_ProjectNo = obj_Class.BizConnect_Get_ThermaxProjectNO(Convert.ToInt32(Session["ClientID"].ToString()));
        ddl_ProjectNo.DataSource = dt_ProjectNo;
        ddl_ProjectNo.DataTextField = "ProjectNo";
        ddl_ProjectNo.DataValueField = "ProjectID";
        ddl_ProjectNo.DataBind();
        ddl_ProjectNo.Items.Insert(0, "--Select--");
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
    
    
     protected void Button1_Click(object sender, EventArgs e)
    {
        ds.Clear();
        if (txt_ReqDate.Text == string.Empty && ddl_Status.SelectedItem.Text != "--Select--" && ddl_ProjectNo.SelectedItem.Text != "--Select--")
        {
            DateTime ReqDate = Convert.ToDateTime("5/22/2005 00:00:00 AM");
            //dt_Search = obj_Class.BizConnect_SearchTripAssignByReqDateAndStatus(Convert.ToDateTime(ReqDate), ddl_Status.SelectedValue, ddl_ProjectNo.SelectedItem.Text.ToString());
            ds = obj_Class.BizConnect_SearchTripAssignByReqDateAndStatus(Convert.ToDateTime(ReqDate), ddl_Status.SelectedValue, ddl_ProjectNo.SelectedItem.Text.ToString(), Convert.ToInt32(Session["UserID"].ToString()));
            //ExportData(dt_Search, "TripAssignAcceptance Report.xls");
            ExportDataSetToExcel(ds, "TripAssignAcceptance Report.xls");
        }
        if (txt_ReqDate.Text != string.Empty)
        {
            DateTime ReqDate = Convert.ToDateTime(txt_ReqDate.Text);
            ds = obj_Class.BizConnect_SearchTripAssignByReqDateAndStatus(Convert.ToDateTime(ReqDate), ddl_Status.SelectedValue, ddl_ProjectNo.SelectedItem.Text.ToString(), Convert.ToInt32(Session["UserID"].ToString()));
            //ExportData(dt_Search, "TripAssignAcceptance Report.xls");
            ExportDataSetToExcel(ds, "TripAssignAcceptance Report.xls");
        }
        if (txt_ReqDate.Text == string.Empty && ddl_Status.SelectedItem.Text == "--Select--" && ddl_ProjectNo.SelectedItem.Text == "--Select--" && ddlMonth.SelectedItem.Text == "--Month--")
        {
            //dt = obj_Class.BizConnect_UserTripAssignReport(Convert.ToInt32(Session["UserID"].ToString()));
            ds = obj_Class.BizConnect_UserTripAssignReport(Convert.ToInt32(Session["UserID"].ToString()));
            //ExportData(dt, "TripAssignAcceptanceReport.xls");
            ExportDataSetToExcel(ds, "TripAssignAcceptance Report.xls");
        }

        ds = obj_Class.BizConnect_SearchTripAssignByReqDateAndStatusbyMonth(Convert.ToInt32(Session["UserID"].ToString()), Convert.ToInt32(ddlMonth.SelectedValue.ToString()), Convert.ToInt32(ddlYear.SelectedValue.ToString()));
            ExportDataSetToExcel(ds, "TripAssignAcceptance Report.xls");
        
    }


     public void ExportData(DataTable oGrid, string exportFile)
     {
         try
         {
             Response.ClearContent();
             Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "TripAssignAcceptanceReport"));
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

    public override void VerifyRenderingInServerForm(Control control)
    {

    }
    
    protected void btn_Search_Click(object sender, EventArgs e)
    {
        ds.Clear();
         if (txt_ReqDate.Text == string.Empty)
        {
            DateTime ReqDate = Convert.ToDateTime("5/22/2005 00:00:00 AM");
            //dt_Search = obj_Class.BizConnect_SearchTripAssignByReqDateAndStatus( Convert.ToDateTime(ReqDate), ddl_Status.SelectedValue, ddl_ProjectNo.SelectedItem.Text.ToString());
            ds = obj_Class.BizConnect_SearchTripAssignByReqDateAndStatus(Convert.ToDateTime(ReqDate), ddl_Status.SelectedValue, ddl_ProjectNo.SelectedItem.Text.ToString(), Convert.ToInt32(Session["UserID"].ToString()));
        }
        if (txt_ReqDate.Text != string.Empty)
        {
            DateTime ReqDate = Convert .ToDateTime (txt_ReqDate.Text);
            ds = obj_Class.BizConnect_SearchTripAssignByReqDateAndStatus(Convert.ToDateTime(ReqDate), ddl_Status.SelectedValue, ddl_ProjectNo.SelectedItem.Text.ToString(), Convert.ToInt32(Session["UserID"].ToString()));
        }
       
        Gridwindow.DataSource = ds;
        Gridwindow.DataBind();
    }

   protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
    {

        ds_Search = obj_Class.BizConnect_SearchTripAssignByReqDateAndStatusbyMonth(Convert.ToInt32(Session["UserID"].ToString()), Convert.ToInt32(ddlMonth.SelectedValue.ToString()), Convert.ToInt32(ddlYear.SelectedValue.ToString()));
        if (ds_Search.Tables[0].Rows.Count > 0)
        {
            Gridwindow.DataSource = ds_Search;
            Gridwindow.DataBind();
            lbl_msg.Text = " No of Data='" + Gridwindow.Rows.Count + "'";
        }
        
    }
  

   protected void Gridwindow_RowDataBound(object sender, GridViewRowEventArgs e)
   {
       if (e.Row.RowType == DataControlRowType.Header)
       {
           //e.Row.Cells[3].Width = 10;
       }
       if (e.Row.RowType == DataControlRowType.DataRow)
       {
           e.Row.Cells[0].Width = 30;
           e.Row.Cells[1].Width = 10;
           e.Row.Cells[2].Width = 10;
           e.Row.Cells[3].Width = 7;
           e.Row.Cells[4].Width = 40;
           e.Row.Cells[5].Width = 7;
           e.Row.Cells[6].Width = 7;
           e.Row.Cells[7].Width = 30;
           e.Row.Cells[8].Width = 30;
           e.Row.Cells[9].Width = 30;
           e.Row.Cells[10].Width = 30;
           e.Row.Cells[11].Width = 30;
           e.Row.Cells[12].Width = 30;
           e.Row.Cells[13].Width = 30;

       }
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
