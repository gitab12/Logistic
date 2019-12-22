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

public partial class ConfirmQuoted : System.Web.UI.Page
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
       if (Session["UserID"] != string.Empty && Convert.ToInt32(Session["UserID"].ToString()) > 0)
        {
          ChkAuthentication();
         // gridbind();
        }
        
         else
        {
            Response.Redirect("Index.aspx");
        }
    }
    public void gridbind()
    {
        DataTable dt = new DataTable("Data");
        DataRow dr;
        dt.Columns.Add("select");
        dt.Columns.Add("adid");
        dt.Columns.Add("from");
        dt.Columns.Add("to");
        dt.Columns.Add("trucktype");
        dt.Columns.Add("Bcost");
        dt.Columns.Add("cost");
        dt.Columns.Add("trucks");
        dt.Columns.Add("assigned");
        dt.Columns.Add("saving");


        dr = dt.NewRow();
        dr[1] = "26/Dec/2010";
        dt.Rows.Add(dr);

        dr = dt.NewRow();
        dr[0] = "check";
        dr[1] = "1234";
        dr[2] = "Mumbai";
        dr[3] = "Vijayawada";
        dr[4] = "Rigidtruck.50tons";
        dr[5] = "35000";
        dr[6] = "31000";
        dr[7] = "30";
        dr[8] = "30";
        dr[9] = "150000";


        dt.Rows.Add(dr);
        dr = dt.NewRow();
        dr[0] = "check";
        dr[1] = "1235";
        dr[2] = "Mumbai";
        dr[3] = "Hydrabad";
        dr[4] = "Rigidtruck.50tons";
        dr[5] = "25000";
        dr[6] = "21000";
        dr[7] = "20";
        dr[8] = "20";
        dr[9] = "120000";
        dt.Rows.Add(dr);


        dr = dt.NewRow();
        dr[1] = "27/Dec/2010";
        dt.Rows.Add(dr);

        dr = dt.NewRow();
        dr[0] = "check";
        dr[1] = "1236";
        dr[2] = "Delhi";
        dr[3] = "Chennai";
        dr[4] = "Rigidtruck.50tons";
        dr[5] = "35000";
        dr[6] = "31000";
        dr[7] = "30";
        dr[8] = "30";
        dr[9] = "150000";
        dt.Rows.Add(dr);



        GridAssign.DataSource = dt;
        GridAssign.DataBind();
    }

    protected void GridAssign_RowDataBound(Object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label LblAdid = (Label)e.Row.FindControl("lbladid");
            CheckBox check = (CheckBox)e.Row.FindControl("check");
            Label lblassign = (Label)e.Row.FindControl("lblassign");
            Label lblcost = (Label)e.Row.FindControl("lblcost");
            bool validDate = false;
            DateTime result;
            validDate = DateTime.TryParse(LblAdid.Text, out result);
            if (validDate == true)
            {
                e.Row.Cells[1].ForeColor = System.Drawing.Color.Red;
                check.Visible = false;
                lblassign.Visible = false;
                lblcost.Visible = false;
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
    
}
