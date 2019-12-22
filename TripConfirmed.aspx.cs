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


public partial class TripConfirmed : System.Web.UI.Page
{

    AarmsUser obj_Class = new AarmsUser();
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadReceivedQuoted();
        }
    }

    public void LoadReceivedQuoted()
    {
        ds.Clear();
        ds = obj_Class.TripConfirmed(Convert.ToInt32(Request.QueryString["CltID"].ToString()));
        Gridwindow.DataSource = ds;
        Gridwindow.DataBind();
    }
}