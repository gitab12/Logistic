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

public partial class PostedAdByClient : System.Web.UI.Page
{
    AarmsUser obj_Class = new AarmsUser();
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadPostedADs();
        }
    }

    public void LoadPostedADs()
    {
        ds.Clear();
        ds = obj_Class.Get_ClientsPostedADs(Convert.ToInt32(Request.QueryString["CltID"].ToString()));
        Gridwindow.DataSource = ds;
        Gridwindow.DataBind();
    }


    protected void ButDownload_Click(object sender, EventArgs e)
    {


        ExportGrid(Gridwindow, "ADsPosted.xls");

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
    
    protected void btn_Update_Click(object sender, EventArgs e)
    {
         for (int i=0;i<Gridwindow .Rows.Count;i++)
         {
             int LogisticPlanID = (Convert .ToInt32 ( Gridwindow.DataKeys [i].Values[0]));
             TextBox txtprice = (TextBox)Gridwindow.Rows[i].FindControl("txt_DecidePrice");
             TextBox txtcostpertruck = (TextBox)Gridwindow.Rows[i].FindControl("txt_CostPerTruck");
             float ClientPrice = Convert.ToSingle(txtprice.Text);
             float Costpertruck = Convert.ToSingle(txtcostpertruck.Text);
             obj_Class.Update_CostperTruck(Costpertruck,ClientPrice , LogisticPlanID);
             ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('DecidePrice Updated Successfully!');</script>");
         }
    }
}
