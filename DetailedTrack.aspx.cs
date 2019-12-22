using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class DetailedTrack : System.Web.UI.Page
{
    string obj_Authenticated;
    PlaceHolder maPlaceHolder;
    UserControl obj_Tabs;
    UserControl obj_LoginCtrl;
    UserControl obj_WelcomCtrl;
    UserControl obj_Navi;
    UserControl obj_Navihome;
    BizConnectClient bizcl = new BizConnectClient();
    TripAgreementClass Trip_Agreement = new TripAgreementClass();
    BizConnectLogisticsPlan obj_BizConnectLogisticsPlanClass = new BizConnectLogisticsPlan();

    BizCon_DB_ConnectionString con = new BizCon_DB_ConnectionString();

    protected void Page_Load(object sender, EventArgs e)
    {
           ChkAuthentication();
           option.Visible = true;
           rfqoption.Visible = false;
           agreementoption.Visible = false;
        
        
    }
    private void LoadData()
    {
        try
        {
            string userid = Session["UserID"].ToString();
           // string userid = "3178";
            if (userid == "3198")
            {
                string[] args = { "@userid" };
                string[] argsval = { userid };
                DataSet ds = new DataSet();
                ds = con.Sql_GetData("Bizconnect_Details_Forsoc_NEW1", args, argsval);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gridview_details.DataSource = ds;
                    gridview_details.DataBind();
                }
                else
                {
                    lbl_msg.Text = Resources.Resource.alert_warning.Replace("{@message}", "Data Not Found!!");
                }

            }
            else
            {
                string[] args = { "@userid" };
                string[] argsval = { userid };
                DataSet ds_details = new DataSet();
                ds_details = con.Sql_GetData("Bizconnect_detailedtrack_NEW", args, argsval);
                if (ds_details.Tables[0].Rows.Count > 0)
                {
                    gridview_details.DataSource = ds_details;
                    gridview_details.DataBind();
                    //lbl_msg.Visible = false;
                }
                else
                {
                    lbl_msg.Text = Resources.Resource.alert_error.Replace("{@message}", "Data Not Found!!");

                }
            }
        }

        catch (Exception ex)
        {

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

                obj_Navi = (UserControl)obj_Tabs.FindControl("Navii");
                obj_Navihome = (UserControl)obj_Tabs.FindControl("Navihome1");


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
    protected void rdb_normal_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
           rfqoption.Visible = true;
           agreementoption.Visible = false;
           LoadData();
        }
        catch(Exception ex)
        {


        }
    }
    protected void rdb_agreement_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            rfqoption.Visible = false;
            
            LoadAgreementtrack();
            
        }
        catch (Exception ex)
        {


        }
    }
    private void LoadAgreementtrack()
    {
        try
        {
            string userid = Session["UserID"].ToString();
            if (userid != "")
            {
                string[] args = { "@userid" };
                string[] argsval = { userid };
                DataSet ds_track = new DataSet();
                ds_track = con.Sql_GetData("Bizconnect_Get_AgreementRoute_Details_NEW", args, argsval);
                if (ds_track.Tables[0].Rows.Count > 0)
                {
                    agreementoption.Visible = true;
                    grid_agreement.DataSource = ds_track;
                    grid_agreement.DataBind();
                    //lbl_msg.Visible = false;

                }
                else
                {
                    lbl_msg.Text = Resources.Resource.alert_error.Replace("{@message}", "Data Not Found!!");
                }
            }
            else
            {
                Response.Redirect("Index.html");
            }
        }
        catch(Exception ex)
        {

        }
    }
    protected void gridview_details_RowDataBound(object sender, GridViewRowEventArgs e)
    {
       
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataSet dss = new DataSet();
                Label lblpostid = (Label)e.Row.FindControl("lblid");
                string mypostid = lblpostid.Text;
                string[] args = { "@PostID" };
                string[] argsvall = { mypostid };
                dss = con.Sql_GetData("SP_Get_UpdateDetails", args, argsvall);
                if (dss.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drr in dss.Tables[0].Rows)
                    {
                        string postid=drr["PostID"].ToString();
                        if (postid == mypostid)
                        {

                            string updated_datetime = drr["updating_datetime"].ToString();
                            DateTime updateddatetime = Convert.ToDateTime(updated_datetime);
                            DateTime dTCurrent = DateTime.Now;

                            TimeSpan diff = dTCurrent - updateddatetime;
                            double hours = diff.TotalHours;

                            int myupdatehrs = Convert.ToInt32(hours);


                            //string yourString= string.Format("{0} days, {1} hours, {2} minutes, {3} seconds",diff.Days, diff.Hours, diff.Minutes, diff.Seconds);
                            if (myupdatehrs > 12)
                            {
                                ((Label)e.Row.FindControl("lblid")).Attributes["class"] = "label label-success";
                                ((Image)e.Row.FindControl("Image1")).ImageUrl = "~/img/iconsinfoa.png";
                                ((Image)e.Row.FindControl("Image1")).ToolTip = "You can again Update";
                            }
                            else
                            {
                                ((Label)e.Row.FindControl("lblid")).Attributes["class"] = "label label-primary";
                                ((Image)e.Row.FindControl("Image1")).ImageUrl = "~/img/iconsok.png";
                                ((Image)e.Row.FindControl("Image1")).ToolTip = "Allready Updated";
                            }
                        }
                        else
                        {
                            ((Label)e.Row.FindControl("lblid")).Attributes["class"] = "label label-warning";
                            ((Image)e.Row.FindControl("Image1")).ImageUrl = "~/img/iconscance.png";
                            ((Image)e.Row.FindControl("Image1")).ToolTip = "Ready For Updated";
                        }
                    }                    
                }
                else
                {
                    ((Label)e.Row.FindControl("lblid")).Attributes["class"] = "label label-warning";
                    ((Image)e.Row.FindControl("Image1")).ImageUrl = "~/img/iconscance.png";
                    ((Image)e.Row.FindControl("Image1")).ToolTip = "Ready For Updated";
                }
            }
           
            
        }
        catch(Exception ex)
        {

        }
    }
    protected void grid_agreement_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataSet dss = new DataSet();
                Label lblpostid = (Label)e.Row.FindControl("lblid");
                string mypostid = lblpostid.Text;
                string[] args = { "@PostID" };
                string[] argsvall = { mypostid };
                dss = con.Sql_GetData("SP_Get_UpdateDetails", args, argsvall);
                if (dss.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drr in dss.Tables[0].Rows)
                    {
                        string postid = drr["PostID"].ToString();
                        if (postid == mypostid)
                        {
                            string updated_datetime = drr["updating_datetime"].ToString();
                            DateTime updateddatetime = Convert.ToDateTime(updated_datetime);
                            DateTime dTCurrent = DateTime.Now;

                            TimeSpan diff = dTCurrent - updateddatetime;
                            double hours = diff.TotalHours;

                            int myupdatehrs = Convert.ToInt32(hours);
                            if (myupdatehrs > 12)
                            {

                                ((Label)e.Row.FindControl("lblid")).Attributes["class"] = "label label-success";
                                ((Image)e.Row.FindControl("Image1")).ImageUrl = "~/img/iconsinfoa.png";
                                ((Image)e.Row.FindControl("Image1")).ToolTip = "You can again Update";
                            }
                            else
                            {
                                ((Label)e.Row.FindControl("lblid")).Attributes["class"] = "label label-primary";
                                ((Image)e.Row.FindControl("Image1")).ImageUrl = "~/img/iconsok.png";
                                ((Image)e.Row.FindControl("Image1")).ToolTip = "Allready Updated";
                            }

                        }
                        else
                        {
                            ((Label)e.Row.FindControl("lblid")).Attributes["class"] = "label label-warning";
                            ((Image)e.Row.FindControl("Image1")).ImageUrl = "~/img/iconscance.png";
                            ((Image)e.Row.FindControl("Image1")).ToolTip = "Ready For Updated";
                        }
                    }
                }
                else
                {
                    ((Label)e.Row.FindControl("lblid")).Attributes["class"] = "label label-warning";
                    ((Image)e.Row.FindControl("Image1")).ImageUrl = "~/img/iconscance.png";
                    ((Image)e.Row.FindControl("Image1")).ToolTip = "Ready For Updated";
                }
            }


        }
        catch (Exception ex)
        {

        }
    }
}