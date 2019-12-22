using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;

public partial class BillingStatusReport : System.Web.UI.Page
{

    string obj_Authenticated;
    PlaceHolder maPlaceHolder;
    UserControl obj_Tabs;
    UserControl obj_LoginCtrl;
    UserControl obj_WelcomCtrl;
    UserControl obj_Navi;
    UserControl obj_Navihome;





    BillingModule obj_Class = new BillingModule();
    DataTable dt = new DataTable();
    DataTable dt_Amount = new DataTable();
    int InvoiceID, Amount;
    string SplitInvoiceID;
    string[] array = new string[1];
    string[] array2;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           // dt = obj_Class.Bizconnect_AarmsBillingStatusReport();
           // grd_BillingReport.DataSource = dt;
           // lbl_Count.Text = "No Of Rows : "+ dt.Rows.Count.ToString();
           // grd_BillingReport.DataBind();
            Load_ClientName();
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

    public void Load_ClientName()
    {
        dt.Clear();
        dt = obj_Class.Bizconnect_GetAarmsBillClient();
        ddl_Client.DataSource = dt;
        ddl_Client.DataTextField = "Client";
        ddl_Client.DataValueField = "Client";
        ddl_Client.DataBind();
        ddl_Client.Items.Insert(0, "--Select--");

    }

    protected void grd_BillingReport_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HyperLink HypInvoicePage = new HyperLink();
                SplitInvoiceID = e.Row.Cells[8].Text;
                string[] array2 = SplitInvoiceID.Split(new char[] { '/' });
                array[0] = array2[2];
                InvoiceID = Convert.ToInt32(array[0]);
                dt_Amount = obj_Class.Bizconnect_GetBillAmount(InvoiceID);
                Amount = Convert.ToInt32(dt_Amount.Rows[0][0]);
                if (e.Row.Cells[11].Text == "Submitted")
                {
                    e.Row.Cells[11].ForeColor = System.Drawing.Color.Green;
                }
                if (dt_Amount.Rows.Count == 4)
                {
                    for (int i = 0; i < dt_Amount.Rows.Count; i++)
                    {
                        if (Amount == Convert.ToInt32(dt_Amount.Rows[i][0]))
                        {
                            e.Row.Cells[10].Text = Amount.ToString();
                        }
                        else
                        {
                            e.Row.Cells[10].Text = dt_Amount.Rows[0][0].ToString();
                        }
                    }

                }
                HypInvoicePage.Text = e.Row.Cells[8].Text;
                HypInvoicePage.NavigateUrl = "http://www.scmbizconnect.com/invoice.aspx?InVID=" + InvoiceID;
                HypInvoicePage.Target = "_blank";
                e.Row.Cells[8].Controls.Add(HypInvoicePage);


            }
        }
        catch (Exception ex)
        {

        }

    }


    protected void Button1_Click(object sender, EventArgs e)
    {

        ExportGrid(grd_BillingReport, "Billing Status Report.xls");

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
    protected void ddl_Client_SelectedIndexChanged(object sender, EventArgs e)
    {
        dt_Amount.Clear();
        dt_Amount = obj_Class.Bizconnect_SearchAarmsBillingStatusReportByClient(ddl_Client.SelectedItem.Text);
        lbl_Count.Text = "No Of Bills : " + dt_Amount.Rows.Count.ToString();
        grd_BillingReport.DataSource = dt_Amount;
        grd_BillingReport.DataBind();
        rdb_NotSubmitted.Checked = false;
        rdb_Submitted.Checked = false;
    }

    protected void rdb_Submitted_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddl_Client.SelectedValue.ToString() != "--Select--")
            {
                dt_Amount.Clear();
                dt_Amount = obj_Class.Bizconnect_SearchAarmsBillingReportByClientAndStatus(ddl_Client.SelectedItem.Text, 1);
                lbl_Count.Text = "No Of Bills : " + dt_Amount.Rows.Count.ToString();
                grd_BillingReport.DataSource = dt_Amount;
                grd_BillingReport.DataBind();
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Select Client also For Searching Bill');</script>");
            }
        }
        catch (Exception ex)
        {
        }
    }
    protected void rdb_NotSubmitted_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddl_Client.SelectedValue.ToString() != "--Select--")
            {
                dt_Amount.Clear();
                dt_Amount = obj_Class.Bizconnect_SearchAarmsBillingReportByClientAndStatus(ddl_Client.SelectedItem.Text, 0);
                lbl_Count.Text = "No Of Bills : " + dt_Amount.Rows.Count.ToString();
                grd_BillingReport.DataSource = dt_Amount;
                grd_BillingReport.DataBind();
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Select Client also For Searching Bill');</script>");
            }
        }
        catch (Exception ex)
        {
        }
    }
}