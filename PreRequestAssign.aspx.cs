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

public partial class PreRequestAssgn : System.Web.UI.Page
{
    string obj_Authenticated;
    PlaceHolder maPlaceHolder;
      UserControl obj_Tabs;
    UserControl obj_LoginCtrl;
    UserControl obj_WelcomCtrl;
    UserControl obj_Navi;
    UserControl obj_Navihome;
   

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ChkAuthentication();
            gridbind();
            bindwindow();
        }
      
    }
    public void gridbind()
    {
        DataTable dt = new DataTable("Data");
        DataRow dr;
        dt.Columns.Add("adid");
        dt.Columns.Add("client");
        dt.Columns.Add("trucks");
        dt.Columns.Add("Bcost");
        dt.Columns.Add("assign");
        dt.Columns.Add("assigned");
        dt.Columns.Add("cost");
        dt.Columns.Add("saving");

        dr = dt.NewRow();
        dr[0] = "26/Dec/2010";
        dt.Rows.Add(dr);
      
dr = dt.NewRow();
        dr[0] = "AARMS-MUM-VWD-1234";
        dr[1] = "Saint Gobain";
        dr[2] = "50";
        dr[3] = "35000";
        dr[4] = "1/3";
        dr[5] = "30";
        dr[6] = "25000";
        dr[7] = "250000";
        dt.Rows.Add(dr);


        dr = dt.NewRow();
        dr[0] = "AARMS-MUM-VWD-1234";
        dr[1] = "LG Electronics";
        dr[2] = "30";
        dr[3] = "30000";
        dr[4] = "1/3";
        dr[5] = "30";
        dr[6] = "25000";
        dr[7] = "150000";

        dt.Rows.Add(dr);
        

        dr = dt.NewRow();
        dr[0] = "27/Dec/2010";
        dt.Rows.Add(dr);
      
        dr = dt.NewRow();
        dr[0] = "AARMS-MUM-Hyd-1234";
        dr[1] = "Tyco Electronics";
        dr[2] = "50";
        dr[3] = "40000";
        dr[4] = "1/3";
        dr[5] = "30";
        dr[6] = "30000";
        dr[7] = "200000";
        dt.Rows.Add(dr);

        GridAssign.DataSource = dt;
        GridAssign.DataBind();
    }
    public void bindwindow()
    {
        DataTable dt = new DataTable();
        DataRow dr;


        dt.Columns.Add("Select");
        dt.Columns.Add("quoteid");
        dt.Columns.Add("trucks");
        dt.Columns.Add("cost");
        dt.Columns.Add("assign");

        dr = dt.NewRow();

        dr[0] = "Saint Gobain";
        dr[1] = "2001";
        dr[2] = "26";
        dr[3] = "27000";
        dt.Rows.Add(dr);


        dr = dt.NewRow();
        dr[0] = "LG Electronics";
        dr[1] = "2002";
        dr[2] = "27";
        dr[3] = "30000";
        dt.Rows.Add(dr);



        dr = dt.NewRow();
        dr[0] = "Tyco Electronics";
        dr[1] = "2003";
        dr[2] = "28";
        dr[3] = "32000";
        dt.Rows.Add(dr);

        Gridwindow.DataSource = dt;
        Gridwindow.DataBind();
    }
    protected void GridAssign_RowDataBound(Object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label LblAdid = (Label)e.Row.FindControl("lbladid");
            Label Lblstatus = (Label)e.Row.FindControl("Lblstatus");

            bool validDate = false;
            DateTime result;
            validDate = DateTime.TryParse(LblAdid.Text, out result);


            if (validDate == true)
            {
                e.Row.Cells[0].ForeColor = System.Drawing.Color.Red;
                Lblstatus.Visible = false;
            }

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
        //  obj_Navihome.Visible = true;

    }
    public void SetVisualOFF()
    {
        obj_LoginCtrl.Visible = true;
        obj_WelcomCtrl.Visible = false;
        //obj_Navi.Visible = true;
        //  obj_Navihome.Visible = false;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        bindwindow();
    }
}
