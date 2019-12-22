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

public partial class BillStatusReport : System.Web.UI.Page
{
    string obj_Authenticated;
    PlaceHolder maPlaceHolder;
    UserControl obj_Tabs;
    UserControl obj_LoginCtrl;
    UserControl obj_WelcomCtrl;
    UserControl obj_Navi;
    UserControl obj_Navihome;


    BillingModule obj_Class = new BillingModule();
    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
    
     if (Session["UserID"] != string.Empty && Convert.ToInt32(Session["UserID"].ToString()) > 0)
      {
        if (!IsPostBack)
        {
            DataTable dt = new DataTable();
            DataRow dr;
            dt.Columns.Add("ConfirmNo");
            dt.Columns.Add("FromLocation");
            dt.Columns.Add("ToLocation");
            dt.Columns.Add("TruckType");
            dt.Columns.Add("LRNumber");
            dt.Columns.Add("LRDate");
            dt.Columns.Add("BillSubmissionNo");
            dt.Columns.Add("BillNo");
            dt.Columns.Add("BillValue");
            dt.Columns.Add("BillDate");
            dt.Columns.Add("BillStatus");
            dt.Columns.Add("BillImage");
            dt.Columns.Add("TravelDate");
            dt.Columns.Add("Transporter");

            dt.Columns.Add("ProjectNo");
            dt.Columns.Add("CollectionNoteNumber");
            dt.Columns.Add("WBSNo");
            dt.Columns.Add("TransporterPrice");
            dt.Columns.Add("ClientPrice");
            dt.Columns.Add("Difference");
           

            ds = obj_Class.Bizconnect_BillstatusReport(Convert.ToInt32(Session["ClientID"].ToString()));
            for(int i=0;i<=ds.Tables[0].Rows.Count-1;i++)

            {
                dr = dt.NewRow();
               dr[0] = ds.Tables[0].Rows[i].ItemArray[0].ToString();
               dr[1] = ds.Tables[0].Rows[i].ItemArray[1].ToString();
               dr[2] = ds.Tables[0].Rows[i].ItemArray[2].ToString();
               dr[3] = ds.Tables[0].Rows[i].ItemArray[3].ToString();
               dr[4] = ds.Tables[0].Rows[i].ItemArray[4].ToString();
               dr[5] = ds.Tables[0].Rows[i].ItemArray[5].ToString();
               dr[6] = ds.Tables[0].Rows[i].ItemArray[10].ToString();
               dr[7] = ds.Tables[0].Rows[i].ItemArray[7].ToString();
               dr[8] = ds.Tables[0].Rows[i].ItemArray[6].ToString();
               dr[9] = ds.Tables[0].Rows[i].ItemArray[8].ToString();
               dr[10] = ds.Tables[0].Rows[i].ItemArray[11].ToString();
               dr[12] = ds.Tables[0].Rows[i].ItemArray[12].ToString();
               dr[13] = ds.Tables[0].Rows[i].ItemArray[13].ToString();

               dr[14] = ds.Tables[0].Rows[i].ItemArray[15].ToString();
               dr[15] = ds.Tables[0].Rows[i].ItemArray[17].ToString();
               dr[16] = ds.Tables[0].Rows[i].ItemArray[16].ToString();
               dr[17] = ds.Tables[0].Rows[i].ItemArray[18].ToString();
               dr[18] = ds.Tables[0].Rows[i].ItemArray[19].ToString();
               dr[19] = ds.Tables[0].Rows[i].ItemArray[20].ToString();
                //image
             

                dt.Rows.Add(dr);
            }

            GridBillStatusReport.DataSource = dt;
            GridBillStatusReport.DataBind();
            ChkAuthentication();
        }
       }
       
       else
       {
          Response.Redirect("Index.html");
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

     protected void Image1_Click(object sender, ImageClickEventArgs e)
    {
        //Session["ImageID"]
        ImageButton b = (ImageButton)sender;
        GridViewRow row = (GridViewRow)b.NamingContainer;
        if (row != null)
        {
            Label imgid = (Label)GridBillStatusReport.Rows[row.RowIndex].FindControl("imgID");
            Session["ImageID"] = imgid.Text;
            OpenNewWindow();
        }
    }

    public void OpenNewWindow()
    {


        ClientScript.RegisterStartupScript(this.GetType(), "OpenWin", "<script>window.open('BillPreview.aspx?imgID=" + Session["ImageID"] .ToString()+ "', 'mynewwin', 'width=900,height=1000,scrollbars=yes,toolbar=1')</script>");
    }


    protected void btn_Download_Click(object sender, EventArgs e)
    {

        ExportGrid(GridBillStatusReport, "BillStatusReport.xls");

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


    protected void lnk_Image_Click(object sender, EventArgs e)
    {
        //Session["ImageID"]
        LinkButton b = (LinkButton)sender;
        GridViewRow row = (GridViewRow)b.NamingContainer;
        if (row != null)
        {
            Label imgid = (Label)GridBillStatusReport.Rows[row.RowIndex].FindControl("imgID");
            Session["ImageID"] = imgid.Text;
            OpenNewWindow();
        }
    }
}
