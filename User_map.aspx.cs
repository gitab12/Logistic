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

public partial class User_map : System.Web.UI.Page
{
    string obj_Authenticated;
    PlaceHolder maPlaceHolder;
    UserControl obj_Tabs;
    UserControl obj_LoginCtrl;
    UserControl obj_WelcomCtrl;
    UserControl obj_Navi;
    UserControl obj_Navihome;


    static SqlDataAdapter da;
    static DataSet ds;


    static SqlDataAdapter dap_desg;
    static DataSet ds_desg;


    //dbcon connection = new dbcon();
    SqlCommand cmd;
    static string data_bind = "";
    SqlDataReader dr;
    string constr = ConfigurationManager.ConnectionStrings["BizCon"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            //drp_fill_email();
            bind_portal();
            ChkAuthentication();

        }
    }

    //Authentication Section
    public void ChkAuthentication()
    {
        obj_LoginCtrl = null;
        obj_WelcomCtrl = null;

        //obj_Navi = null;
        //obj_Navihome = null;

        if (Session["Authenticated"] == null)
        {
            Session["Authenticated"] = "0";
        }
        else
        {
            obj_Authenticated = Session["Authenticated"].ToString();
        }


        maPlaceHolder = (PlaceHolder)Master.FindControl("P1");
        if (maPlaceHolder != null)
        {
            obj_Tabs = (UserControl)maPlaceHolder.FindControl("loginheader1");

            if (obj_Tabs != null)
            {
                obj_LoginCtrl = (UserControl)obj_Tabs.FindControl("login1");
                obj_WelcomCtrl = (UserControl)obj_Tabs.FindControl("welcome1");

                // obj_Navi = (UserControl)obj_Tabs.FindControl("Navii");
                //obj_Navihome = (UserControl)obj_Tabs.FindControl("Navihome1");


                if (obj_LoginCtrl != null & obj_WelcomCtrl != null)
                {
                    if (obj_Authenticated == "1")
                    {
                        SetVisualON();


                    }
                    else
                    {
                        SetVisualOFF();

                    }


                }
            }
            else
            {

            }
        }
        else
        {

        }
    }

    public void SetVisualON()
    {
        obj_LoginCtrl.Visible = false;
        obj_WelcomCtrl.Visible = true;
    }

    public void SetVisualOFF()
    {
        obj_LoginCtrl.Visible = true;
        obj_WelcomCtrl.Visible = false;
    }

    public void bind_portal()
    {

        try
        {



            SqlConnection conn = new SqlConnection(constr);

            conn.Open();
            ds = new DataSet();
            ds_desg = new DataSet();

            string data_portal;
            data_portal = "select ServicePortalName,ServicePortalCategoryName,FeatureName    from BizConnect_ServicePortalFeature  inner join BizConnect_ServicePortalFeatureCategory on  BizConnect_ServicePortalFeatureCategory.ServicePortalID=dbo.BizConnect_ServicePortalFeature.ServicePortalID inner join BizConnect_ServicePortalMaster on BizConnect_ServicePortalMaster.ServicePortalID=dbo.BizConnect_ServicePortalFeature.ServicePortalID group by ServicePortalName,ServicePortalCategoryName,FeatureName";

            SqlCommand cmd = new SqlCommand(data_portal, conn);
            cmd.ExecuteNonQuery();
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            parentRepeater.DataSource = ds;
            //Repeater child=new Repeater ();

            //child = parentRepeater.FindControl(childRepeater);
            parentRepeater.DataBind();


        }



        catch (Exception ex)
        {

        }


    }
    protected void parentRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Repeater r = (Repeater)e.Item.FindControl("childRepeater");
        
        r.DataSource = ds;
        
        r.DataBind();
        
    }



    //Data bound for feature category
    
    protected void parentRepeater_ItemCreated(object sender, RepeaterItemEventArgs e)
    {
        Repeater r = (Repeater)e.Item.FindControl("childRepeater");
        r.ItemDataBound += new  RepeaterItemEventHandler(this.childRepeater_ItemDataBound);

    }
    protected void childRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Repeater r_child2 = (Repeater)e.Item.FindControl("childRepeater2");
        r_child2.DataSource = ds;
        r_child2.DataBind();
    }
}
