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

public partial class UserControl_MyQuotesControl : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        bind();
    }
    public void bind()
    {

        DataTable dt = new DataTable("Personal Database");


        dt.Columns.Add("TripID", typeof(string));

        dt.Rows.Add("ABC-123");
        dt.Rows.Add("ABC-124");
        dt.Rows.Add("ABC-125");
        rptItems.DataSource = dt;
        rptItems.DataBind();
    }
}
