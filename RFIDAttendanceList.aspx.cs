using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web.UI.WebControls.WebParts;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Configuration;
using System.Web.Configuration;
using System.Web.UI.HtmlControls;
using System.Web.Util;
using System.Net;
using System.Text;
using System.Xml;
using System.IO;
using System.Xml.XPath;

public partial class RFIDAttendanceList : System.Web.UI.Page
{
    RFIDClass Obj = new RFIDClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataSet ds = new DataSet();
            ds = Obj.GetRFIDAttendanceList();
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
    }
}