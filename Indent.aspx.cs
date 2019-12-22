using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class Indent : System.Web.UI.Page
{
    string obj_Authenticated;
    PlaceHolder maPlaceHolder;
    UserControl obj_Tabs;
    UserControl obj_LoginCtrl;
    UserControl obj_WelcomCtrl;
    UserControl obj_Navi;
    UserControl obj_Navihome;
    string connStr = ConfigurationManager.ConnectionStrings["BizCon"].ConnectionString;
    ProjectBased obj_class = new ProjectBased();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            ChkAuthentication();

            try
            {
                int clientid = Convert.ToInt32(Session["ClientID"].ToString());
                string qry = "select ProjectNo from Bizconnect_ProjectMaster where clientid="+ clientid +" ";

                SqlCommand cmd = new SqlCommand(qry, conn);
                DataTable dt = new DataTable();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);

                adp.Fill(dt);
                ChkProject.DataSource = dt;
                ChkProject.DataTextField = "ProjectNo";
                ChkProject.DataBind();
               
            }
            catch (Exception ex)
            {
            }
            finally
            {
                conn.Close();
            }
        }
    }
    protected void ButDisplay_Click(object sender, EventArgs e)
    {
        Bind();
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
  
    public void Bind()
    {
        DataSet ds = new DataSet();
        string wbs = "";
        for (int i = 0; i <= chkWBS.Items.Count - 1; i++)
        {
            if (chkWBS.Items[i].Selected)
            {

                wbs += chkWBS.Items[i].Text.ToString() + ",";

            }

        }

        ds = obj_class.Get_Tripindent(wbs.ToString());
        Gridwindow.DataSource = ds;
        Gridwindow.DataBind();
    }

    protected void Gridwindow_RowEditing(object sender, GridViewEditEventArgs e)
    {

        Gridwindow.EditIndex = e.NewEditIndex;
        Bind();
    }

    protected void Gridwindow_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        Gridwindow.EditIndex = -1;
        Bind();
    }

    protected void Gridwindow_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        int res = 0;
        try
        {
            GridViewRow row = (GridViewRow)Gridwindow.Rows[e.RowIndex];
            Label LblEIndentID = (Label)row.FindControl("LblEIndentID");
            TextBox txtproduct = (TextBox)row.FindControl("txtproduct");
            TextBox txtQty = (TextBox)row.FindControl("txtQty");
            TextBox txtunit = (TextBox)row.FindControl("txtunit");
            TextBox txtFrom = (TextBox)row.FindControl("txtFrom");
            TextBox txtTo = (TextBox)row.FindControl("txtTo");
            TextBox txtTotalWeight = (TextBox)row.FindControl("txtTotalWeight");
            TextBox txtlength = (TextBox)row.FindControl("txtlength");
            TextBox txtwidth = (TextBox)row.FindControl("txtwidth");
            TextBox txtheight = (TextBox)row.FindControl("txtheight");
            TextBox txtdate = (TextBox)row.FindControl("txtdate");
            Gridwindow.EditIndex = -1;
            //res = obj_class.UpdateBizconnect_TripIndent(txtproduct.Text, Convert.ToInt32(txtQty.Text), txtunit.Text, txtFrom.Text, txtTo.Text,Convert.ToDouble(txtTotalWeight.Text),Convert.ToDouble(txtlength.Text),Convert.ToDouble(txtwidth.Text) ,Convert.ToDouble(txtheight.Text),Convert.ToInt32(LblEIndentID.Text),Convert.ToDateTime(txtdate.Text),Session["name"].ToString());
           
            Bind();

        }
        catch (Exception ex)
        {
            res = 0;
            
        }
    }

    protected void Checkall_CheckedChanged(object sender, EventArgs e)
    {
        for (int i = 0; i <= chkWBS .Items.Count - 1; i++)
        {
            if (Checkall.Checked)
            {
                chkWBS.Items[i].Selected = true;

            }
            else
            {
                chkWBS.Items[i].Selected = false;
            }
        }
    }
    
    protected void Buttripschedule_Click(object sender, EventArgs e)
    {
        Response.Redirect("Tripschedule.aspx");

    }
    
    protected void ButWbs_Click(object sender, EventArgs e)
    {
         string projectNo = "";
        for (int i = 0; i <= ChkProject.Items.Count - 1; i++)
        {
            if (ChkProject.Items[i].Selected)
            {

                projectNo += ChkProject.Items[i].Text.ToString() + ",";

            }

        }

        DataSet ds = new DataSet();
        ds = obj_class.Get_WBS(projectNo.ToString());
        chkWBS.DataSource = ds;
        chkWBS.DataTextField = "WBS";
        chkWBS.DataBind();
    }
}
