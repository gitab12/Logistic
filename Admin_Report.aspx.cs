using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

public partial class Admin_Report : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con1"].ConnectionString);
    DataSet ds;
    SqlDataAdapter adp;
    string qry;
    AcceptanceClass obj_class = new AcceptanceClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
            showdata();
        }
    }

    private void showdata()
    {
        String conn = ConfigurationManager.ConnectionStrings["Bizcon"].ConnectionString;
        using (SqlConnection con1 = new SqlConnection(conn))
        {
            using (SqlCommand cmd1 = new SqlCommand("BiZconnect_AdminReport", con1))
            {
                SqlDataAdapter sda = new SqlDataAdapter();
                try
                {
                    cmd1.Connection = con1;
                    con1.Open();
                    sda.SelectCommand = cmd1;

                    DataSet ds = new DataSet();
                    sda.Fill(ds);

                    // BIND DATABASE WITH THE GRIDVIEW.
                    AdminGrid.DataSource = ds;
                    AdminGrid.DataBind();
                    Lblmsg.Text = " No of Registration='" + AdminGrid.Rows.Count + "'";
                }
                catch (Exception ex)
                {
                }
            }
        }
    }

    protected void AdminGrid_RowEditing(object sender, GridViewEditEventArgs e)
    {
        AdminGrid.EditIndex = e.NewEditIndex;
        showdata();
    }

    protected void AdminGrid_RowUpdated(object sender, GridViewUpdatedEventArgs e)
    {
        lblMessage.Text = "Record Updated";
        showdata();
    }

    protected void AdminGrid_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        AdminGrid.EditIndex = -1;
        showdata();
    }

    protected void AdminGrid_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        int res = 0;
        try
        {
            
            GridViewRow row = (GridViewRow)AdminGrid.Rows[e.RowIndex];
            Label lbluserid = (Label)row.FindControl("lbluserid");
            TextBox txt_Email = (TextBox)row.FindControl("txt_Email");
            TextBox txtmobile = (TextBox)row.FindControl("txtmobile");
            TextBox txtphone = (TextBox)row.FindControl("txtphone");
            AdminGrid.EditIndex = -1;
            res = obj_class.Update_ClientAdminReport(Convert.ToInt32(lbluserid.Text.ToString()), txt_Email.Text, txtmobile.Text, txtphone.Text);
            showdata();

        }
        catch(Exception ex)
        {
            res = 0;
            lblMessage.Text = ex.Message;
        }
    }
    protected void btnExportToExcel_Click(object sender, EventArgs e)
    {
        ExportGrid(AdminGrid, "AdminReport.xls");
    }

    private void ExportGrid(GridView oGrid, string exportFile)
    {
        HttpContext.Current.Response.Clear();
        HttpContext.Current.Response.Buffer = true;
        HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";
        HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=\"" + exportFile + "\"");
        HttpContext.Current.Response.Charset = "";
        System.IO.StringWriter oStringWriter = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter oHtmlTextWriter = new System.Web.UI.HtmlTextWriter(oStringWriter);
        oGrid.GridLines = GridLines.Both;
        oGrid.HeaderStyle.BackColor = System.Drawing.Color.LightGray;
        oGrid.RenderControl(oHtmlTextWriter);
        HttpContext.Current.Response.Write(oStringWriter.ToString());
        HttpContext.Current.Response.End();
    }
	public override void VerifyRenderingInServerForm(Control control)
	{
	  /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
		 server control at run time. */
	}
}
                           