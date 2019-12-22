using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage_RakeshMasterPage : System.Web.UI.MasterPage
{
    BizCon_DB_ConnectionString con_biz = new BizCon_DB_ConnectionString();
   // ARFocus_DB_Connectring con_arfoc = new ARFocus_DB_Connectring();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            
            if (Session["UserID"] != null)           
            {
              int mys = Convert.ToInt32(Session["UserID"]);
              string user_name = Session["name"].ToString();
              lbl_username.Text = user_name;
              string clientid = Session["ClientID"].ToString();
           
            }
            else
            {
                Response.Redirect("Index.html");
            }
        }
        catch (Exception ex)
        {
            Response.Redirect("Index.html");
        }
    }
}
