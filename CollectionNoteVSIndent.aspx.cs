using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
public partial class CollectionNoteVSIndent : System.Web.UI.Page
{

    string obj_Authenticated, obj_emailid;
    PlaceHolder maPlaceHolder;
    UserControl obj_Tabs;
    UserControl obj_LoginCtrl;
    UserControl obj_WelcomCtrl;
    UserControl obj_Navi;
    UserControl obj_Navihome;



    Report obj_Class = new Report();
    DataTable dt_ProjectNo = new DataTable();
    ClientsReport obj_Class2 = new ClientsReport();
    ProjectBased Obj_Class3 = new ProjectBased();
    DataSet ds_WBSNo = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
         {
           if("1135" == Session["ClientID"].ToString())
           {
           CollectionNoteStatusReport();
           Load_ProjectNo();
           }
           ChkAuthentication();
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


public void Load_ProjectNo()
    {
        dt_ProjectNo = obj_Class2.BizConnect_Get_ThermaxProjectNO(Convert.ToInt32(Session["ClientID"].ToString()));
        ddl_ProjectNo.DataSource = dt_ProjectNo;
        ddl_ProjectNo.DataTextField = "ProjectNo";
        ddl_ProjectNo.DataValueField = "ProjectID";
        ddl_ProjectNo.DataBind();
        ddl_ProjectNo.Items.Insert(0, "--Select--");
    }

    public void CollectionNoteStatusReport()
    {
        DataSet ds = new DataSet();
        ds = obj_Class.Bizconnect_CollectionNotevsIndent();
        GridReport.DataSource = ds;
        GridReport.DataBind();

    }
     protected void GridReport_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string CNTruckType =  e.Row.Cells[6].Text;
            string IndentTruckType = e.Row.Cells[7].Text;
            string CNLength =  e.Row.Cells[8].Text;
            string IndentLength =  e.Row.Cells[9].Text;
            string CNWidth =  e.Row.Cells[10].Text;
            string IndentWidth =  e.Row.Cells[11].Text;
            string CNHeight =  e.Row.Cells[12].Text;
            string IndentHeight =  e.Row.Cells[13].Text;

            if (CNTruckType != IndentTruckType)
            {
                e.Row.Cells[6].BackColor = System.Drawing.Color.Lavender;
                e.Row.Cells[7].BackColor = System.Drawing.Color.Lavender;
            }
            if(CNLength !=IndentLength)
            {
                e.Row.Cells[8].BackColor = System.Drawing.Color.Khaki;
                e.Row.Cells[9].BackColor = System.Drawing.Color.Khaki;
            }
            if(CNWidth !=IndentWidth)
            {
                e.Row.Cells[10].BackColor = System.Drawing.Color.LightGray;
                e.Row.Cells[11].BackColor = System.Drawing.Color.LightGray;
            }
            if (CNHeight != IndentHeight)
            {
                e.Row.Cells[12].BackColor = System.Drawing.Color.Wheat;
                e.Row.Cells[13].BackColor = System.Drawing.Color.Wheat;
            }
            
        }

    }
    
    protected void ddl_ProjectNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        ds_WBSNo = Obj_Class3.Bizconnect_ThermaxCnote_LoadWBSNoBasedOnProject(ddl_ProjectNo.SelectedItem .Text);
        ddl_Wbsno.Items.Clear();
        ddl_Wbsno.DataSource = ds_WBSNo;
        ddl_Wbsno.DataTextField = "WBSNo";
        ddl_Wbsno.DataValueField = "WBSNo";
        ddl_Wbsno.DataBind();
        ddl_Wbsno.Items.Insert(0, "--Select--");
    }
    protected void btn_Search_Click(object sender, EventArgs e)
    {
        try
        {
            dt_ProjectNo.Clear();
            dt_ProjectNo = obj_Class.Bizconnect_Search_CNotevsRateContractByPJTNoAndWBSNo(ddl_ProjectNo.SelectedItem.Text, ddl_Wbsno.SelectedItem.Text);
            GridReport.DataSource = dt_ProjectNo;
            GridReport.DataBind();
        }
        catch (Exception ex)
        {

        }
    }

    protected void GridReport_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridReport.PageIndex = e.NewPageIndex;

        GridReport.DataBind();
        CollectionNoteStatusReport();
    }
}