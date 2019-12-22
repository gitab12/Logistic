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

public partial class ListProduct : System.Web.UI.Page
{
    string obj_Authenticated;
    PlaceHolder maPlaceHolder;
    UserControl obj_Tabs;
    UserControl obj_LoginCtrl;
    UserControl obj_WelcomCtrl;
    UserControl obj_Navi;
    UserControl obj_Navihome;
    BizConnectClass bizconnect = new BizConnectClass();
    protected void Page_Load(object sender, EventArgs e)
    {
     if (Session["UserID"] != string.Empty && Convert.ToInt32(Session["UserID"].ToString()) > 0)
        {
        if (IsPostBack == false)
        {
            ChkAuthentication();
            binddata();
        }
       }
          else
        {
            Response.Redirect("Index.aspx");
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
        //   obj_Navihome.Visible = true;

    }
    public void SetVisualOFF()
    {
        obj_LoginCtrl.Visible = true;
        obj_WelcomCtrl.Visible = false;
        //obj_Navi.Visible = true;
        //  obj_Navihome.Visible = false;
    }
    void binddata()
    {
        DataSet ds = new DataSet();
        ds = bizconnect.get_product(Session["ClientID"].ToString());
        GridView1.DataSource = ds;
        GridView1.DataBind();
      

    }
    void binddatadeactive()
    {
        DataSet ds = new DataSet();
        ds = bizconnect.get_productdeactive(Session["ClientID"].ToString());
        GridView1.DataSource = ds;
        GridView1.DataBind();
      


    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        if (ddlstatus.SelectedIndex == 0)
        {
            string del = "update BizConnect_ProductMaster set IsActive='false' where ProductID='" + GridView1.Rows[e.RowIndex].Cells[0].Text.ToString() + "'";
            int res = (int)bizconnect.connection_nonquery(del);
            GridView1.EditIndex = -1;
            binddata();
            Label1.Visible=true;
            Label1.Text = "Record has been deactivated.";
        }
        else
        {
            string del = "update BizConnect_ProductMaster set IsActive='true' where ProductID='" + GridView1.Rows[e.RowIndex].Cells[0].Text.ToString() + "'";
            int res = (int)bizconnect.connection_nonquery(del);
            GridView1.EditIndex = -1;
            binddatadeactive();
            Label1.Visible=true;
            Label1.Text = "Record has been activated.";
 
        }
        
    }
    protected void GridView1_RowDataBound(Object sender, GridViewRowEventArgs e)
    {

        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{

        GridView gv = sender as GridView;
        CommandField cf = gv.Columns[7] as CommandField;
        if (ddlstatus.SelectedIndex == 0)
        {
            cf.DeleteText = "Deactivate";
        }
        else
        {
            cf.DeleteText = "Activate";
        }
        // }

    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        LinkButton btn = sender as LinkButton;
        string id = btn.ID;
        int referralid = Convert.ToInt32(btn.CommandArgument.ToString());
        Response.Redirect("EditProduct.aspx?value=" + referralid);

    }

    protected void ddlstatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlstatus.SelectedIndex == 0)
        {
            binddata();
            Label1.Visible=false;
        }
        else
        {
            binddatadeactive();
            Label1.Visible=false;
        }
    }
}
