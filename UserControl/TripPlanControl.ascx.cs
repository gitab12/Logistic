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

public partial class UserControl_TripPlanControl : System.Web.UI.UserControl
{
    BizConnectClass obj_class = new BizConnectClass();

    DataTable obj_DataSource = new DataTable();

    string qry;
    string obj_userid;
    DataTable obj_dt = new DataTable();
    DataSet obj_ds = new DataSet();


    PagedDataSource pgitems = new PagedDataSource();


    //Methods and Property section


    public string userid
    {
        get
        {
            return obj_userid;
        }
        set
        {
            obj_userid = value;
        }
    }



    public DataTable DataSource
    {
        get
        {
            return DataSource;
        }
        set
        {
            obj_DataSource = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack == false)
        {
            Cache.Insert("flag", 0);
            Bind();

        }
        else
        {

        }
    }
    public void Bind()
    {


        obj_ds = obj_class.GetMyTripplan(obj_userid);




        rptItems.DataSource = obj_ds;
        rptItems.DataBind();
    }

    protected void rptItems_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

    }
}