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

public partial class CollectionNoteConfirmed : System.Web.UI.Page
{
    ProjectBased Obj_Class = new ProjectBased();
    DataSet ds = new DataSet();
    DataSet ds_WBSNo = new DataSet();
        DataSet ds_CNote = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
    if (Session["UserID"] != string.Empty && Convert.ToInt32(Session["UserID"].ToString()) > 0)
        {
        if (!IsPostBack)
        {
            CollecNoteConfirmed();
        }
        }
        else
        {
            Response.Redirect("Index.aspx");
        } 
    }
    public void CollecNoteConfirmed()
    {
        ds.Clear();
         string pjtno = Session["pjtno"].ToString();
        if (Session["pjtno"] != string.Empty)
        {
             Session["pjtno"] = pjtno;
        }
        ds = Obj_Class.Get_CollectionNoteConfirmed(Session["pjtno"].ToString ());
        grd_CollectNoteConfirmed.DataSource = ds;
        grd_CollectNoteConfirmed.DataBind();
         //lblcount.Text = "Count: "+grd_CollectNoteConfirmed.Rows.Count.ToString()+"";
    }
    
    protected void ddl_ProjectNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        ds_WBSNo = Obj_Class.Get_LoadWBSNoForCNoteConfirmed(ddl_ProjectNo.SelectedValue.ToString());
        ddl_WBSNo.Items.Clear();
        ddl_WBSNo.DataSource = ds_WBSNo;
        ddl_WBSNo.DataTextField = "WBSNo";
        ddl_WBSNo.DataValueField = "WBSNo";
        ddl_WBSNo.DataBind();
        ddl_WBSNo.Items.Insert(0, "--Select--");
    }

protected void btn_Search_Click(object sender, EventArgs e)
    {
        if (ddl_WBSNo.SelectedValue != "--Select--")
        {
            ds_CNote = Obj_Class.Bizconnect_ThermaxCNote_SearchByProjectNoAndWBSNo(ddl_ProjectNo.SelectedValue.ToString(), ddl_WBSNo.SelectedValue.ToString(), "CNoteConfirmed");
            grd_CollectNoteConfirmed.DataSource = ds_CNote;
            grd_CollectNoteConfirmed.DataBind();
        }
        else
        {
            ds_CNote = Obj_Class.Bizconnect_ThermaxCNote_SearchByProjectNoAndWBSNo(ddl_ProjectNo.SelectedValue.ToString(), string.Empty, "CNoteConfirmed");
            grd_CollectNoteConfirmed.DataSource = ds_CNote;
            grd_CollectNoteConfirmed.DataBind();

        }
    }
    
     protected void Button1_Click(object sender, EventArgs e)
    {

        ExportGrid(grd_CollectNoteConfirmed, "Report.xls");

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
    
}
