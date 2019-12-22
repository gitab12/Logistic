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

public partial class IndentDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {


            LoadDetails();

        }
    }


    public void LoadDetails()
    {


        DataSet ds = new DataSet();
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["BizCon"].ConnectionString);
        conn.Open();
        string qry = "select ProjectNo ,WBSNo,DESCRIPTION as Description,LoadingPoint ,ToLocation as PlaceofDelivery,TotalWeight,Length,Width,Height from CollectionNote where CollectionNoteID=" + Request.QueryString["IndentID"].ToString() + " ";

        SqlCommand cmd = new SqlCommand(qry, conn);
        cmd.ExecuteNonQuery();
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        ds = new DataSet();
        adp.Fill(ds);
        GridIndent.DataSource = ds;
        GridIndent.DataBind();
    }

}
