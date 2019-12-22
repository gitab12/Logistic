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


public partial class User_mapping : System.Web.UI.Page
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

    string obj_UserID, obj_portalid, obj_featureid, obj_feature_category_id, obj_Accessid;
    static SqlDataAdapter dap_desg;
    static DataSet ds_desg;
    DataTable dt = new DataTable();
    DataTable TempDataTable = new DataTable();

    DataColumn myDataColumn;
    DataTable myDataTable2 = new DataTable();
    //dbcon connection = new dbcon();
    SqlCommand cmd;
    static string data_bind = "";
    SqlDataReader dr;
    string constr = ConfigurationManager.ConnectionStrings["BizCon"].ConnectionString;
    //string page = ConfigurationManager.AppSettings["Title"];
    BizConnectLogisticsPlan obj_BizConnectLogisticsPlanClass = new BizConnectLogisticsPlan();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            drp_fill_email();
            bind_portal();
           // chk_lst_access();
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


    public void drp_fill_email()
    {

        try
        {

            SqlConnection conn = new SqlConnection(constr);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select distinct EmailID,FirstName,LastName,DesignationID,Department,Phone,Mobile,UserID from bizconnect_userLogDB";

            cmd.Connection = conn;

            conn.Open();

            Drp_email.DataSource = cmd.ExecuteReader();

            Drp_email.DataTextField = "EmailID";

            Drp_email.DataBind();

        }

        catch (Exception ex)
        {

            Response.Write(ex.StackTrace);

        }

    }
    //Access
    public DataSet  chk_lst_access()
    {
        DataSet ds = new DataSet();
        try
        {
            SqlConnection conn = new SqlConnection(constr);
            string qry = "select distinct AccessName  from BizConnect_AccessMaster order by AccessName";
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(qry, conn);
            da.Fill(ds, "AccessName");
            conn.Close();

            //ChkLst_access.DataSource = ds.Tables[0];
            //ChkLst_access.DataValueField = ds.Tables[0].Columns["AccessName"].ColumnName.ToString();
            //ChkLst_access.DataBind();
        }
        catch (Exception ex)
        {
            Response.Write(ex.StackTrace);
        }
        return ds;
    }
   
    protected void Drp_email_SelectedIndexChanged(object sender, EventArgs e)
    {
        binddata();

    }
    public void binddata()
    {

        try
        {



            SqlConnection conn = new SqlConnection(constr);

            conn.Open();
            ds = new DataSet();
            ds_desg = new DataSet();
            if (Drp_email.SelectedIndex<=0)
            {
                //da = new SqlDataAdapter(data_bind, conn);
                //Session["binddata"] = data_bind;
            }
            else
            {
                string data_bind1;
                string desg_bind; ;
                data_bind1 = "select distinct EmailID,FirstName,LastName,DesignationID,Department,Phone,Mobile,UserID from bizconnect_userLogDB where EmailID='" + Drp_email.SelectedValue + "'";
                //desg_bind = "select distinct Designation  from dbo.BizConnect_DesignationMaster inner join BizConnect_UserLogDB on  BizConnect_DesignationMaster.DesignationID=BizConnect_UserLogDB.DesignationID where BizConnect_UserLogDB.UserID= '" + Drp_email.SelectedValue + "'";
                SqlCommand cmd = new SqlCommand(data_bind1, conn);
               // SqlCommand cmd_desg = new SqlCommand(desg_bind, conn);
                cmd.ExecuteNonQuery();
                //cmd_desg.ExecuteNonQuery();
                da = new SqlDataAdapter(cmd);
                //dap_desg = new SqlDataAdapter(cmd_desg); 
                da.Fill(ds);
                //dap_desg.Fill(ds_desg);   

            }
            string Fname = ds.Tables[0].Rows[0]["FirstName"].ToString();
            string Lname = ds.Tables[0].Rows[0]["LastName"].ToString();
            string user=Fname + Lname;
            lbl_user.Text = user.ToString();
            //lbl_desg.Text = ds_desg.Tables[0].Rows[0]["Designation"].ToString();
            lbl_dpt.Text = ds.Tables[0].Rows[0]["Department"].ToString();
            lbl_phone.Text = ds.Tables[0].Rows[0]["Phone"].ToString();

            lbl_mobile.Text =ds.Tables[0].Rows[0]["Mobile"].ToString();
            Session["Email"] = ds.Tables[0].Rows[0]["EmailID"].ToString();
            Session["obj_UserID"] = ds.Tables[0].Rows[0]["UserID"].ToString();

        }
        catch (Exception ex)
        {

        }


    }

   //Copy from Old
    public void bind_portal()
    {

        try
        {

            SqlConnection conn = new SqlConnection(constr);

            conn.Open();
            ds = new DataSet();
            ds_desg = new DataSet();

            string data_portal;
           // data_portal = "select ServicePortalName,ServicePortalCategoryName,FeatureName    from BizConnect_ServicePortalFeature  inner join BizConnect_ServicePortalFeatureCategory on  BizConnect_ServicePortalFeatureCategory.ServicePortalID=dbo.BizConnect_ServicePortalFeature.ServicePortalID inner join BizConnect_ServicePortalMaster on BizConnect_ServicePortalMaster.ServicePortalID=dbo.BizConnect_ServicePortalFeature.ServicePortalID group by ServicePortalName,ServicePortalCategoryName,FeatureName";
            data_portal = "select ServicePortalName,ServicePortalCategoryName,FeatureName,AccessName    from BizConnect_ServicePortalFeature  inner join BizConnect_ServicePortalFeatureCategory on  BizConnect_ServicePortalFeatureCategory.ServicePortalID=dbo.BizConnect_ServicePortalFeature.ServicePortalID inner join BizConnect_ServicePortalMaster on BizConnect_ServicePortalMaster.ServicePortalID=dbo.BizConnect_ServicePortalFeature.ServicePortalID inner join BizConnect_AccessMaster on BizConnect_AccessMaster.AccessID =BizConnect_ServicePortalFeature.AccessID  group by ServicePortalName,ServicePortalCategoryName,FeatureName,AccessName";

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

    //Repeater Click


    protected void parentRepeater_ItemClick(object sender, RepeaterItemEventArgs e)
    {
       
    }


    //Data bound for feature category

    protected void parentRepeater_ItemCreated(object sender, RepeaterItemEventArgs e)
    {
        Repeater r = (Repeater)e.Item.FindControl("childRepeater");
        r.ItemDataBound += new RepeaterItemEventHandler(this.childRepeater_ItemDataBound);
    }

    protected void childRepeater_ItemCreated(object sender, RepeaterItemEventArgs e)
    {
        Repeater r2 = (Repeater)e.Item.FindControl("childRepeater2");
        r2.ItemDataBound += new RepeaterItemEventHandler(this.childRepeater2_ItemDataBound);

    }

    protected void childRepeater2_ItemCreated(object sender, RepeaterItemEventArgs e)
    {
        Repeater r3 = (Repeater)e.Item.FindControl("childRepeater_access");
        r3.ItemDataBound += new RepeaterItemEventHandler(this.childRepeater_access_ItemDataBound);

    }
    
    protected void parentRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Repeater r = (Repeater)e.Item.FindControl("childRepeater");

        r.DataSource = ds;

        r.DataBind();
    }
    protected void childRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Repeater r_child2 = (Repeater)e.Item.FindControl("childRepeater2");
        r_child2.DataSource = ds;
        r_child2.DataBind();
    }

    protected void childRepeater2_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Repeater r = (Repeater)e.Item.FindControl("childRepeater_access");

        //CheckBoxList chkl = (CheckBoxList)r.FindControl("ChkLst_access");
        DataSet ds2 = new DataSet();
        ds2 = chk_lst_access();
        r.DataSource = ds2;
        r.DataBind();
    }
    protected void childRepeater_access_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
       // Repeater r = (Repeater)e.Item.FindControl("childRepeater_access");
        
        //CheckBoxList chk_list = (CheckBoxList)e.Item.FindControl("ChkLst_access");
        //DataSet ds2 = new DataSet();
        //ds2 = chk_lst_access();
        //r.DataSource = ds2;
        //r.DataBind();

        //chk_list.DataSource = ds2;
        //chk_list.DataBind();
        //Repeater r_child = (Repeater)e.Item.FindControl("childRepeater2");
        //r_child2.DataSource = ds;
        //r_child2.DataBind();
    }
    //Getting Portal ID
    public void bind_portalid(String obj_PortalID)
    {
        
        
        try
        {

            SqlConnection conn = new SqlConnection(constr);

            conn.Open();
            ds = new DataSet();
            ds_desg = new DataSet();

            string data_portal;
            // data_portal = "select ServicePortalName,ServicePortalCategoryName,FeatureName    from BizConnect_ServicePortalFeature  inner join BizConnect_ServicePortalFeatureCategory on  BizConnect_ServicePortalFeatureCategory.ServicePortalID=dbo.BizConnect_ServicePortalFeature.ServicePortalID inner join BizConnect_ServicePortalMaster on BizConnect_ServicePortalMaster.ServicePortalID=dbo.BizConnect_ServicePortalFeature.ServicePortalID group by ServicePortalName,ServicePortalCategoryName,FeatureName";
            data_portal = "select ServicePortalID FROM  dbo.BizConnect_ServicePortalMaster where ServicePortalName='" + obj_PortalID + "'";

            SqlCommand cmd = new SqlCommand(data_portal, conn);
            cmd.ExecuteNonQuery();
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
           Session["obj_portalid"] = ds.Tables[0].Rows[0]["ServicePortalID"].ToString(); 

        }

        catch (Exception ex)
        {

        }

    }

    //Feature ID
    public void bind_featureID(String obj_featureID)
    {
        try
        {

            SqlConnection conn = new SqlConnection(constr);

            conn.Open();
            ds = new DataSet();
            ds_desg = new DataSet();

            string data_portal;
            // data_portal = "select ServicePortalName,ServicePortalCategoryName,FeatureName    from BizConnect_ServicePortalFeature  inner join BizConnect_ServicePortalFeatureCategory on  BizConnect_ServicePortalFeatureCategory.ServicePortalID=dbo.BizConnect_ServicePortalFeature.ServicePortalID inner join BizConnect_ServicePortalMaster on BizConnect_ServicePortalMaster.ServicePortalID=dbo.BizConnect_ServicePortalFeature.ServicePortalID group by ServicePortalName,ServicePortalCategoryName,FeatureName";
            data_portal = "select ServicePortalFeatureID from BizConnect_ServicePortalFeature where FeatureName='" + obj_featureID + "'";

            SqlCommand cmd = new SqlCommand(data_portal, conn);
            cmd.ExecuteNonQuery();
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
             Session["obj_featureid"] = ds.Tables[0].Rows[0]["ServicePortalFeatureID"].ToString();

        }

        catch (Exception ex)
        {

        }

    }

   
    protected void lbladid_CheckedChanged(object sender, EventArgs e)
    {
        RepeaterItem ri = (RepeaterItem)((sender) as Control).NamingContainer;
        CheckBox chk = (CheckBox)ri.FindControl("lbladid");// ((sender) as CheckBoxList);
        bind_portalid(chk.Text.Trim());
    }
    protected void lblad_CheckedChanged(object sender, EventArgs e)
    {
        RepeaterItem rpt_feature_categoryID = (RepeaterItem)((sender) as Control).NamingContainer;
        CheckBox chk_categoryID = (CheckBox)rpt_feature_categoryID.FindControl("lblad");// ((sender) as CheckBoxList);
        bind_feature_category_ID(chk_categoryID.Text.Trim());
       
    }

    protected void lblchild2_CheckedChanged(object sender, EventArgs e)
    {
        RepeaterItem rpt_featureID = (RepeaterItem)((sender) as Control).NamingContainer;
        CheckBox chk_featureID = (CheckBox)rpt_featureID.FindControl("lblchild2");// ((sender) as CheckBoxList);
        bind_featureID(chk_featureID.Text.Trim()); 
    }

    //Getting  ServicePortalFeatureCategoryID from  BizConnect_ServicePortalFeatureCategory
    public void bind_feature_category_ID(String obj_feature_category_ID)
    {
        try
        {

            SqlConnection conn = new SqlConnection(constr);

            conn.Open();
            ds = new DataSet();
            ds_desg = new DataSet();

            string data_portal;
            // data_portal = "select ServicePortalName,ServicePortalCategoryName,FeatureName    from BizConnect_ServicePortalFeature  inner join BizConnect_ServicePortalFeatureCategory on  BizConnect_ServicePortalFeatureCategory.ServicePortalID=dbo.BizConnect_ServicePortalFeature.ServicePortalID inner join BizConnect_ServicePortalMaster on BizConnect_ServicePortalMaster.ServicePortalID=dbo.BizConnect_ServicePortalFeature.ServicePortalID group by ServicePortalName,ServicePortalCategoryName,FeatureName";
            data_portal = "select ServicePortalFeatureCategoryID  from BizConnect_ServicePortalFeatureCategory where ServicePortalCategoryName ='" + obj_feature_category_ID + "'";

            SqlCommand cmd = new SqlCommand(data_portal, conn);
            cmd.ExecuteNonQuery();
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
             Session["obj_feature_category_id"] = ds.Tables[0].Rows[0]["ServicePortalFeatureCategoryID"].ToString();

        }

        catch (Exception ex)
        {

        }

    }

   //Passing  selected Access Name to Function 
    protected void ChkLst_access_CheckedChanged(object sender, EventArgs e)
    {

        RepeaterItem rpt_accessID = (RepeaterItem)((sender) as Control).NamingContainer;
        CheckBox chk_accessID = (CheckBox)rpt_accessID.FindControl("ChkLst_access");// ((sender) as CheckBoxList);
        bind_AccessID(chk_accessID.Text.Trim()); 
    }
    //Getting  Access ID From Access Master
    public void bind_AccessID(String obj_AccessID)
    {
        try
        {

            SqlConnection conn = new SqlConnection(constr);

            conn.Open();
            ds = new DataSet();
            ds_desg = new DataSet();

            string data_portal;
            // data_portal = "select ServicePortalName,ServicePortalCategoryName,FeatureName    from BizConnect_ServicePortalFeature  inner join BizConnect_ServicePortalFeatureCategory on  BizConnect_ServicePortalFeatureCategory.ServicePortalID=dbo.BizConnect_ServicePortalFeature.ServicePortalID inner join BizConnect_ServicePortalMaster on BizConnect_ServicePortalMaster.ServicePortalID=dbo.BizConnect_ServicePortalFeature.ServicePortalID group by ServicePortalName,ServicePortalCategoryName,FeatureName";
            data_portal = "select AccessID   from BizConnect_AccessMaster where AccessName ='" + obj_AccessID + "'";

            SqlCommand cmd = new SqlCommand(data_portal, conn);
            cmd.ExecuteNonQuery();
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
             Session["obj_Accessid"] = ds.Tables[0].Rows[0]["AccessID"].ToString();

        }

        catch (Exception ex)
        {

        }

    }

    //Creating Data table for All ID(User_ID,Portal_ID,Feature_ID,FeatureCategory_ID,Access_ID)
    private DataTable CreateTempDataTable()
    {

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "UserID";
        myDataTable2.Columns.Add(myDataColumn);

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "servicePortalID";
        myDataTable2.Columns.Add(myDataColumn);

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "ServicePortalFeatureID";
        myDataTable2.Columns.Add(myDataColumn);


        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "ServicePortalFeature_CategoryID";
        myDataTable2.Columns.Add(myDataColumn);

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "AccessID";
        myDataTable2.Columns.Add(myDataColumn);


        return myDataTable2;
    }

    //Passing Data to Data table

    private DataTable AddDataToTempTable(string UserID, string servicePortalID, string ServicePortalFeatureID, string ServicePortalFeature_CategoryID, string AccessID, DataTable dt)
    {
        DataRow row;
        row = dt.NewRow();
        row["UserID"] = UserID;
        row["servicePortalID"] = servicePortalID;
        row["ServicePortalFeatureID"] = ServicePortalFeatureID;
        row["ServicePortalFeature_CategoryID"] = ServicePortalFeature_CategoryID;
        row["AccessID"] = AccessID;
        dt.Rows.Add(row);
        return dt;
    }



    protected void btn_assign_ID_Click(object sender, EventArgs e)
        
    {
        dt = CreateTempDataTable();
        //obj_UserID = Session["obj_UserID"].ToString();
        //obj_portalid =Session["obj_portalid"].ToString();
        // obj_featureid= Session["obj_featureid"].ToString();
        //obj_feature_category_id = Session["obj_feature_category_id"].ToString();
        //obj_Accessid =Session["obj_Accessid"].ToString();
        TempDataTable = AddDataToTempTable(Session["obj_UserID"].ToString(), Session["obj_portalid"].ToString(), Session["obj_featureid"].ToString(), Session["obj_feature_category_id"].ToString(), Session["obj_Accessid"].ToString(), dt);
        //TempDataTable = AddDataToTempTable(obj_UserID, obj_portalid, obj_featureid, obj_feature_category_id, obj_Accessid, dt);
        Updateprocess(TempDataTable);
    }
    

    public void Updateprocess(DataTable dt)
    {
        int resp = 0;
        for (int i = 0; i <= TempDataTable.Rows.Count - 1; i++)
        {
            resp = obj_BizConnectLogisticsPlanClass.Insert_UserPermission(Convert.ToInt32(Session["obj_UserID"].ToString()), Convert.ToInt32(Session["obj_portalid"].ToString()), Convert.ToInt32(Session["obj_featureid"].ToString()), Convert.ToInt32(Session["obj_feature_category_id"].ToString()), Convert.ToInt32(Session["obj_Accessid"].ToString()));
        }
        lbl_topmessage.Text = "User Mapping done Successfully For :  " + Session["Email"].ToString(); 
    }
}
