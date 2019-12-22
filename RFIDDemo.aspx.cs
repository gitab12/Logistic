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

public partial class RFIDDemo : System.Web.UI.Page
{
    RFIDClass Obj = new RFIDClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataSet ds = new DataSet();
            ds = Obj.GetRFID();
            GridView1.DataSource = ds;
            GridView1.DataBind();
            DataSet ds1 = new DataSet();
            ds1 = Obj.GetMasterRFID();
            GridView2.DataSource = ds1;
            GridView2.DataBind();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Obj.UpdateRFIDTABLE();
        DataSet ds = new DataSet();
        ds = Obj.GetRFID();
        GridView1.DataSource = ds;
        GridView1.DataBind();
        DataSet ds1 = new DataSet();
        ds1 = Obj.GetMasterRFID();
        GridView2.DataSource = ds1;
        GridView2.DataBind();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Obj.Delete_RFID_MasterTable();
        DataSet ds = new DataSet();
        ds = Obj.GetRFID();
        GridView1.DataSource = ds;
        GridView1.DataBind();
        DataSet ds1 = new DataSet();
        ds1 = Obj.GetMasterRFID();
        GridView2.DataSource = ds1;
        GridView2.DataBind();
    }
}