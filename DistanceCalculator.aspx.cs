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

public partial class DistanceCalculator : System.Web.UI.Page
{
    Class_City cls = new Class_City();
    protected void Page_Load(object sender, EventArgs e)
    {
        lbldist.Visible = false;
        if (!IsPostBack)
        {
            DataSet dsf = new DataSet();
            dsf = cls.get_SourceCities();
            ddlfrom.DataSource = dsf;
            ddlfrom.DataTextField = "CityName";
            ddlfrom.DataValueField = "MasterCityID";
            ddlfrom.DataBind();
            ddlfrom.Items.Insert(0, new ListItem("--- Select From Location ---", "0"));

            DataSet dst = new DataSet();
            dst = cls.get_SourceCities();
            ddlto.DataSource = dst;
            ddlto.DataTextField = "CityName";
            ddlto.DataValueField = "MasterCityID";
            ddlto.DataBind();
            ddlto.Items.Insert(0, new ListItem("--- Select To Location ---", "0"));


            
        }

    }
    protected void imggo_Click(object sender, ImageClickEventArgs e)
    {
        ArrayList arr = new ArrayList();
        arr = cls.get_citydistance(Convert.ToInt32(ddlfrom.SelectedValue.ToString()), Convert.ToInt32(ddlto.SelectedValue.ToString()));
        if (arr[0].ToString() == "1")
        {
            lbldist.Visible = true;
            lbldist.Text = "The Distance Between Locations " + arr[1].ToString() + " and " + arr[2].ToString() + " is " + arr[3].ToString() + " kms";


        }
        else
        {
            lbldist.Visible = true;
            lbldist.Text = "Data Not Available";
        }

    }
}
