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

public partial class AuditTrial : System.Web.UI.Page
{
   BizConnectClass obj_Class = new BizConnectClass();
 DataTable dt;
    protected void Page_Load(object sender, EventArgs e)
    {

 try
        {
      int Replyid= Convert.ToInt32(Request.QueryString["logID"].ToString()); 
       dt = new DataTable();
        dt=obj_Class.ScmJunction_DisplayAudit(Replyid);
        
        GridView.DataSource = dt;
            GridView.DataBind();
          }
        catch (Exception ex)
        {
        }


    }
}
