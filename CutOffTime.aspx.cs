using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CutOffTime : System.Web.UI.Page
{
 string obj_Authenticated;
    PlaceHolder maPlaceHolder;
    UserControl obj_Tabs;
    UserControl obj_LoginCtrl;
    UserControl obj_WelcomCtrl;
    UserControl obj_Navi;
    UserControl obj_Navihome;
    UserControl obj_left;
    ProjectBased Obj_Class = new ProjectBased();
    Aumjunction_DB_ConnectionString con = new Aumjunction_DB_ConnectionString();

    protected void Page_Load(object sender, EventArgs e)
    {
         ChkAuthentication();
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
    protected void btn_Submit_Click(object sender, EventArgs e)
    {
        int res;
        //DateTime dtt = Convert.ToDateTime(txt_Traveldate.Text);
        //txt_Traveldate.Text = dtt.ToString("dd/MMM/yyyy");
        ////res = Obj_Class.scmjunction_UpdateCuttOffTime(Convert.ToInt32(Session["UserID"]), Convert.ToDateTime(txt_Traveldate.Text), "Cutoff Time is " + txt_Cuttofftime.Text);
        
        //res = Obj_Class.scmjunction_UpdateCuttOffTime(Convert.ToInt32(Session["UserID"]), txt_Traveldate.Text, "- Cutoff Time is " + ddl_Hours.SelectedValue + ":" + ddl_Minutes.SelectedValue + " " + ddl_Ampm.SelectedValue, Eddl_Hours.SelectedValue + ":" + Eddl_Minutes.SelectedValue + " " + Eddl_AMPM.SelectedValue);
        //if (res == 1)
        //{
        //    ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert(' CuttOff Time Updated Successfully!');</script>");
        //    txt_Traveldate.Text="";
        //    //txt_Cuttofftime.Text="";
        //}
        showdata();
    }

    private void showdata()
    {
        try
        {
            DateTime dtt = Convert.ToDateTime(txt_Traveldate.Text);
            txt_Traveldate.Text = dtt.ToString("MM/dd/yyyy");
            string userid = Session["UserID"].ToString();
            string[] args = { "@userid", "@date" };
            string[] argsval = { userid, txt_Traveldate.Text };
            DataSet ds = new DataSet();
            ds = con.Sql_GetData("SP_Get_TodaysData", args, argsval);
            if (ds.Tables[0].Rows.Count > 0)
            {
                AdminGrid.DataSource = ds;
                AdminGrid.DataBind();

            }

        }
        catch (Exception ex)
        {


        }
        finally
        {


        }
    }
    protected void AdminGrid_RowEditing(object sender, GridViewEditEventArgs e)
    {
        AdminGrid.EditIndex = e.NewEditIndex;
        showdata();
    }
    protected void AdminGrid_RowUpdated(object sender, GridViewUpdatedEventArgs e)
    {
        showdata();
    }
    protected void AdminGrid_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        AdminGrid.EditIndex = -1;
        showdata();
    }
    protected void AdminGrid_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {

            GridViewRow row = (GridViewRow)AdminGrid.Rows[e.RowIndex];
            Label lblpostid = (Label)row.FindControl("lblpostid");
            int id = Convert.ToInt32(lblpostid.Text);
            TextBox txt_cutoff = (TextBox)row.FindControl("txt_cutoff");//txt_bidstart
            TextBox txt_bidstart = (TextBox)row.FindControl("txt_bidstart");
            AdminGrid.EditIndex = -1;
            string[] args = { "@postid", "@cutoff", "@bidstart" };
            string[] argsval = { id.ToString(), txt_cutoff.Text, txt_bidstart.Text };

            int res = con.Sql_ExecuteNonQuery("SP_Update_Cutofftime", args, argsval);
            if (res > 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Cutoff Time Updated Successfully');</script>");
                showdata();
            }


        }
        catch (Exception ex)
        {


        }

        finally
        {

        }
    }
}