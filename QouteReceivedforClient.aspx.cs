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
using System.Drawing;

public partial class QouteReceivedforClient : System.Web.UI.Page
{
    AarmsUser obj_Class = new AarmsUser();
    DataSet ds = new DataSet();
    DateTime From_dt = new DateTime();
    DateTime To_dt = new DateTime();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DateTime today = DateTime.Now;
            DateTime answer = today.AddDays(-1);
            To_dt = answer;
            txt_Fromdate.Text = To_dt.ToString("MM/dd/yyyy");
            txt_Todate.Text = DateTime.Now.ToString("MM/dd/yyyy");
            
            LoadReceivedQuoted();
        }
    }

    public void LoadReceivedQuoted()
    {
        ds.Clear();
        From_dt = Convert.ToDateTime(DateTime.Now.ToString());
        try
        {
            ds = obj_Class.Get_ReceivedQuoted(Convert.ToInt32(Request.QueryString["CltID"].ToString()), DateTime.ParseExact(txt_Fromdate.Text, "MM/dd/yyyy", CultureInfo.InvariantCulture), DateTime.ParseExact(txt_Todate.Text, "MM/dd/yyyy", CultureInfo.InvariantCulture));
        }
        catch (Exception ex)
        {
            ds = obj_Class.Get_ReceivedQuoted(Convert.ToInt32(Session["ClientID"].ToString()), DateTime.ParseExact(txt_Fromdate.Text, "MM/dd/yyyy", CultureInfo.InvariantCulture), DateTime.ParseExact(txt_Todate.Text, "MM/dd/yyyy", CultureInfo.InvariantCulture));
        }
            grd_Clientquotereceived.DataSource = ds;
        grd_Clientquotereceived.DataBind();
        lblCount.Text="No of Quotes Received :"+grd_Clientquotereceived.Rows.Count.ToString();
    }
    protected void ButDownload_Click(object sender, EventArgs e)
    {

        ExportGrid(grd_Clientquotereceived, "QuoteReceived.xls");

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
    
    protected void grd_Clientquotereceived_RowEditing(object sender, GridViewEditEventArgs e)
    {


        grd_Clientquotereceived.EditIndex = e.NewEditIndex;
        LoadReceivedQuoted();
    }
    protected void grd_Clientquotereceived_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
      
       
        Label lbldate = (Label)grd_Clientquotereceived.Rows[e.RowIndex].FindControl("Labeldate");

       
        string date = lbldate.Text;

        var travelDate = DateTime.ParseExact(lbldate.Text, "MM/dd/yyyy", CultureInfo.InvariantCulture);
        var todaysDate = DateTime.Today;
        TextBox txt_Quoteprice = (TextBox)grd_Clientquotereceived.Rows[e.RowIndex].Cells[12].Controls[0];
        string QuotePrice = txt_Quoteprice.Text;
         TextBox txt_Type = (TextBox)grd_Clientquotereceived.Rows[e.RowIndex].Cells[15].Controls[0];
        string Type = txt_Type.Text;
        int Replyid = Convert .ToInt32 (grd_Clientquotereceived.DataKeys[e.RowIndex].Values ["replyid"].ToString());
        Label lblstatus = (Label)grd_Clientquotereceived.Rows[e.RowIndex].FindControl("lblstatus");

        if (lblstatus.Text == "Confirmed")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('QuotePrice Not Updated! Already Trip is Confirmed!');</script>");
            grd_Clientquotereceived.EditIndex = -1;
            LoadReceivedQuoted();
        }

        else if (travelDate >= todaysDate)
        {
            obj_Class.ScmJunPostReply_UpdateQuoteprice(Replyid, Convert.ToSingle(QuotePrice), Type);
            grd_Clientquotereceived.EditIndex = -1;
            LoadReceivedQuoted();
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('QuotePrice Updated Successfully!');</script>");
        }
        else
        {
           
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('QuotePrice Not Updated! traval date is less then current Date!');</script>");
            grd_Clientquotereceived.EditIndex = -1;
            LoadReceivedQuoted();
        }


        
    }
    protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            System.Data.DataRow row = ((System.Data.DataRowView)e.Row.DataItem).Row;
            if (row["Status"].ToString() == "Confirmed")
                e.Row.BackColor = System.Drawing.Color.FromName("rgba(59, 183, 8, 0.35)"); 
           
        }
    }
    protected void grd_Clientquotereceived_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        grd_Clientquotereceived.EditIndex = -1;
        LoadReceivedQuoted();
    }
 ///////////////////////////

    protected void btn_Search_Click(object sender, EventArgs e)
    {

        ds.Clear();
        try
        { 
            //ds = obj_Class.Get_ReceivedQuoted(Convert.ToInt32(Request.QueryString["CltID"].ToString()), DateTime.ParseExact(txt_Fromdate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture), DateTime.ParseExact(txt_Todate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture));
            ds = obj_Class.Get_ReceivedQuoted(Convert.ToInt32(Request.QueryString["CltID"].ToString()), Convert.ToDateTime(txt_Fromdate.Text), Convert.ToDateTime(txt_Todate.Text));
            
        }
        catch (Exception ex)
        {
            ds = obj_Class.Get_ReceivedQuoted(Convert.ToInt32(Session["ClientID"].ToString()), Convert.ToDateTime(txt_Fromdate.Text), Convert.ToDateTime(txt_Todate.Text));
        }
        grd_Clientquotereceived.DataSource = ds;
        grd_Clientquotereceived.DataBind();
        lblCount.Text = "No of Quotes Received :" + grd_Clientquotereceived.Rows.Count.ToString();
    }
}