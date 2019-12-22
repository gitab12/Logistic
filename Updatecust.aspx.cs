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
using System.Data.SqlClient;

public partial class Updatecust : System.Web.UI.Page
{
    string constr = ConfigurationManager.ConnectionStrings["BizCon"].ConnectionString;
    string page = ConfigurationManager.AppSettings["Title"];
    int routeid = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        routeid = Convert.ToInt32(Request.QueryString["Route_ID"].ToString());
        if (!IsPostBack)
        {      
            BindControlvalues();
        }
    }

    private void BindControlvalues()
    {
        SqlConnection conn = new SqlConnection(constr);
        SqlCommand cmd = new SqlCommand("select Route_ID,Transporter_Name,From_loc as Source,To_loc as Destination,Capacity,Unit,Oneway_Price,Twoway_price,Post_date from bizconnect.dbo.Bizconnect_Route_Price where Route_ID=" + routeid, conn);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        conn.Close();
        DataSet ds = new DataSet();
        da.Fill(ds);
        UpdTransporter.Text = ds.Tables[0].Rows[0][1].ToString();
        UpdSource.Text = ds.Tables[0].Rows[0][2].ToString();
        UpdDestination.Text = ds.Tables[0].Rows[0][3].ToString();
        UpdCapacity.Text = ds.Tables[0].Rows[0][4].ToString();
        Updunit.Text = ds.Tables[0].Rows[0][5].ToString();
        Updtxtone.Text = ds.Tables[0].Rows[0][6].ToString();
        Updtxttwo.Text = ds.Tables[0].Rows[0][7].ToString();
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(constr);
        conn.Open();
        SqlCommand cmd = new SqlCommand("update Bizconnect.dbo.Bizconnect_Route_Price set Oneway_Price=" + Updtxtone.Text + ",Twoway_price=" + Updtxttwo.Text + " where Route_ID=" + Convert.ToInt32(Request.QueryString["Route_ID"].ToString()), conn);
        int result = cmd.ExecuteNonQuery();
        conn.Close();
        if (result == 1)
        {
      //   ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Data Edit Successfully !');</script>");
        Response.Write("<script>window.close();</script>");
         
        }     
        
                 

    }
    protected void btncancel_Click(object sender, EventArgs e)
    {
      
    }
}
