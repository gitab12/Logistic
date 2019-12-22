using System;using System;
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

public partial class Log : System.Web.UI.Page
{
BizConnectClass obj_Class = new BizConnectClass();
 DataTable dt;
 EncryptAndDecryot obj_Decrypt = new EncryptAndDecryot();
    protected void Page_Load(object sender, EventArgs e)
    {

 try
        {
            string  a = obj_Decrypt.Decrypt(Request.QueryString["Lid"].ToString());
      int Replyid= Convert.ToInt32(a.ToString());
      int postid = Convert.ToInt32(Request.QueryString["pid"].ToString()); 
       dt = new DataTable();
        dt=obj_Class.ScmJunction_DisplayLog(Replyid,postid );
        
        GridViewlog.DataSource = dt;
            GridViewlog.DataBind();
          }
        catch (Exception ex)
        {
        }


    }
}
