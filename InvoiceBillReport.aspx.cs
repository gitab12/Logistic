using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;

public partial class InvoiceBillReport : System.Web.UI.Page
{
    InvoiceClass obj_Class = new InvoiceClass();
    DataTable dt = new DataTable();
    static string BillNo;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            dt = obj_Class.Bizconnect_InvoiceBillingReport();
            grd_BillReport.DataSource = dt;
            grd_BillReport.DataBind();
        }
    }

    protected void btn_Download_Click(object sender, EventArgs e)
    {

        ExportGrid(grd_BillReport, "Report.xls");

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

    //protected void grd_BillReport_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    if (e.Row.RowType == DataControlRowType.DataRow)
    //    {
    //        if (e.Row.RowIndex != 0)
    //        {
    //            GridViewRow prevRow = this.grd_BillReport.Rows[e.Row.RowIndex - 1];

    //            if (prevRow.Cells[0].Text == e.Row.Cells[0].Text)
    //            {
    //                BillNo = prevRow.Cells[0].Text;
    //                if (BillNo == e.Row.Cells[0].Text)
    //                {
    //                    e.Row.Cells[0].Text = "";
    //                    e.Row.Cells[1].Text = "";
    //                    e.Row.Cells[2].Text = "";
    //                    e.Row.Cells[3].Text = "";
    //                    e.Row.Cells[4].Text = "";
    //                    e.Row.Cells[5].Text = "";
    //                    e.Row.Cells[6].Text = "";
    //                }
                    
    //            }
    //            else
    //            {
    //                if (BillNo == e.Row.Cells[0].Text)
    //                {
    //                    e.Row.Cells[0].Text = "";
    //                    e.Row.Cells[1].Text = "";
    //                    e.Row.Cells[2].Text = "";
    //                    e.Row.Cells[3].Text = "";
    //                    e.Row.Cells[4].Text = "";
    //                    e.Row.Cells[5].Text = "";
    //                    e.Row.Cells[6].Text = "";
    //                }
    //                else
    //                {
    //                    BillNo = "";

    //                }

    //            }
    //        }
    //    }
    //}



    protected void grd_BillReport_RowDataBound(object sender, EventArgs e)
    {
        for (int rowIndex = grd_BillReport.Rows.Count - 2;rowIndex >= 0; rowIndex--)
        {
            GridViewRow gvRow = grd_BillReport.Rows[rowIndex];
            GridViewRow gvPreviousRow = grd_BillReport.Rows[rowIndex + 1];
            for (int cellCount = 0; cellCount < gvRow.Cells.Count; cellCount++)
            {
                if (gvRow.Cells[cellCount].Text == gvPreviousRow.Cells[cellCount].Text)
                {
                    if (gvPreviousRow.Cells[cellCount].RowSpan < 2)
                    {
                        gvRow.Cells[cellCount].RowSpan = 2;

                    }
                    else
                    {
                        gvRow.Cells[cellCount].RowSpan =
                        gvPreviousRow.Cells[cellCount].RowSpan + 1;
                    }
                    gvPreviousRow.Cells[cellCount].Visible =
                    false;
                }
            }
        }
    }

}