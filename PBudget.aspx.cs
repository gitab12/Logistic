using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PBudget : System.Web.UI.Page
{
    string obj_Authenticated;
    PlaceHolder maPlaceHolder;
    UserControl obj_Tabs;
    UserControl obj_LoginCtrl;
    UserControl obj_WelcomCtrl;
    UserControl obj_Navi;
    UserControl obj_Navihome;
    BizCon_DB_ConnectionString con_biz = new BizCon_DB_ConnectionString();
    Aumjunction_DB_ConnectionString con_arfoc = new Aumjunction_DB_ConnectionString();
    string clientidd = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        
        div_not_permission.Visible = false;   
        try
        {
           clientidd = Session["ClientID"].ToString();
           hfclientid.Value = Session["ClientID"].ToString();

           if (clientidd == "1135")
           {
               div_acess_permission.Visible = true;
               ChkAuthentication();
               if (!IsPostBack)
               {
                   string[] args = { "@clientid" };
                   string[] argsval = { clientidd };
                   DataSet ds_Cmp = con_biz.Sql_GetData("SP_Get_ProjectName_By_ClientID", args, argsval);
                   ddl_project_name.DataTextField = "ProjectName";
                   ddl_project_name.DataValueField = "ProjectID";
                   ddl_project_name.DataSource = ds_Cmp;
                   ddl_project_name.DataBind();
                   ddl_project_name.Items.Insert(0, new ListItem("Select Project Name", ""));
               }

           }
           else
           {
               div_not_permission.Visible = true;
               div_acess_permission.Visible = false;
               lbl_permission.Text = Resources.Resource.alert_error.Replace("{@message}","You Don't Have Permission");
           }
        }
        catch(Exception ex)
        {
            Response.Redirect("http://www.scmbizconnect.com/index.html");
        }
    }
    public void ChkAuthentication()
    {
        obj_LoginCtrl = null;
        obj_WelcomCtrl = null;

        obj_Navi = null;
        obj_Navihome = null;

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
        //obj_Navi.Visible = true;
        //obj_Navihome.Visible = true;

    }
    public void SetVisualOFF()
    {
        obj_LoginCtrl.Visible = true;
        obj_WelcomCtrl.Visible = false;
        // obj_Navi.Visible = true;
        //obj_Navihome.Visible = false;
    }
    protected void ddl_project_name_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            con_biz.Sql_OpenCon();
            string projectname = ddl_project_name.SelectedItem.Text;
            string[] args = { "@ProjectName" };
            string[] argsval = { projectname };
            DataSet ds_projectno = con_biz.Sql_GetData("SP_Get_Projectumber_By_projectname", args, argsval);
            ddl_projectno.DataTextField = "ProjectNo";
            ddl_projectno.DataValueField = "ProjectName";
            ddl_projectno.DataSource = ds_projectno;
            ddl_projectno.DataBind();
            ddl_projectno.Items.Insert(0, new ListItem("Select Project Number", ""));
        }
        catch (Exception ex)
        {

        }
        finally
        {
            con_biz.Sql_CloseCon();
        }
    }
    protected void ddl_projectno_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            con_biz.Sql_OpenCon();
            string ProjectNo = ddl_projectno.SelectedItem.Text;
            string[] args = { "@ProjectNo" };
            string[] argsval = { ProjectNo };
            DataSet ds_collectionnoteno = con_biz.Sql_GetData("SP_Get_collectionnoteno_By_projectnumber", args, argsval);
            ddl_collectionnoteno.DataTextField = "CollectionNoteNumber";
            ddl_collectionnoteno.DataValueField = "CollectionNoteID";
            ddl_collectionnoteno.DataSource = ds_collectionnoteno;
            ddl_collectionnoteno.DataBind();
            ddl_collectionnoteno.Items.Insert(0, new ListItem("Select Collection Note Number", ""));
        }
        catch (Exception ex)
        {

        }
        finally
        {
            con_biz.Sql_CloseCon();
        }
    }
    protected void ddl_collectionnoteno_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            con_biz.Sql_OpenCon();
            string collectionnoteno = ddl_collectionnoteno.SelectedItem.Value;
            string[] args = { "@IndentID" };
            string[] argsval = { collectionnoteno };
            DataSet ds_amount = con_biz.Sql_GetData("SP_Get_Amount_By_collectionnoteno", args, argsval);
            if (ds_amount.Tables[0].Rows.Count > 0)
            {
                txt_assignamt.Text = ds_amount.Tables[0].Rows[0]["DecidePrice"].ToString();
            }

        }
        catch (Exception ex)
        {

        }
        finally
        {
            con_biz.Sql_CloseCon();
        }
    }
}