using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class ParcelTrackReport : System.Web.UI.Page
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
        div1.Visible = false;
        div2.Visible = false;
        div3.Visible = false;
        div4.Visible = false;
    }
    protected void btn_insert_Click(object sender, EventArgs e)
    {
        try
        {
           
            string userid = Session["UserID"].ToString();
            string postid = txt_id.Text;
            if (userid == "0")
            {
                Response.Redirect("Index.html");
            }
            else
            {

                string[] args = { "@postid", "@userid" };
                string[] argsval = { postid, userid };
                DataSet ds_details = new DataSet();
                ds_details = con.Sql_GetData("Bizconnect_GetTrackDetails", args, argsval);
                if (ds_details.Tables[0].Rows.Count > 0)
                {
                    div1.Visible = true;
                    gridview_details.DataSource = ds_details;
                    gridview_details.DataBind();

                }
            }
        }
        catch(Exception ex)
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
  
    protected void gridview_details_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Details")
        {
            // Retrieve the row index stored in the 
            // CommandArgument property.
            int index = Convert.ToInt32(e.CommandArgument);

            // Retrieve the row that contains the button 
            // from the Rows collection.
            GridViewRow row = gridview_details.Rows[index];
            string postid = txt_id.Text;
            string userid = Session["UserID"].ToString();
            string[] args1 = { "@postid", "@userid" };
            string[] argsval1 = { postid, userid };
            DataSet ds = new DataSet();
            ds = con.Sql_GetData("Bizconnect_GetTrackreport", args1, argsval1);
            if (ds.Tables[0].Rows.Count > 0)
            {
                div1.Visible = true;
                div2.Visible = true;
                gv_trackdetails.DataSource = ds;
                gv_trackdetails.DataBind();
            }

            // Add code here 
        }
    }

    protected void btn_delivery_Click(object sender, EventArgs e)
    {
        string userid = Session["UserID"].ToString();
        string[] args_del = { "@userid" };
        string[] argsval_del = { userid };
        DataSet ds_delivery = new DataSet();
        ds_delivery = con.Sql_GetData("Bizconnect_All_Delivery_Status", args_del, argsval_del);
        if (ds_delivery.Tables[0].Rows.Count > 0)
        {
            div3.Visible = true;
            gv_deliverydetails.DataSource = ds_delivery;
            gv_deliverydetails.DataBind();
        }
    }

    protected void btn_transit_Click(object sender, EventArgs e)
    {
        string userid = Session["UserID"].ToString();
        string[] args_del = { "@userid" };
        string[] argsval_del = { userid };
        DataSet ds_intransit = new DataSet();
        ds_intransit = con.Sql_GetData("Bizconnect_All_Intransit_Status", args_del, argsval_del);
        if (ds_intransit.Tables[0].Rows.Count > 0)
        {
            div4.Visible = true;
            gv_intransit.DataSource = ds_intransit;
            gv_intransit.DataBind();
        }

    }
    protected void Btn_delrep_Click(object sender, EventArgs e)
    {
       try
        {
            string userid = Session["UserID"].ToString();
            string from = txt_delfrom.Text;
            DateTime _Datetime = Convert.ToDateTime(from);
            string date_time = _Datetime.ToString("dd-MMM-yyyy");
            string to = txt_delto.Text;
            DateTime _Datetimeto = Convert.ToDateTime(to);
            string date_timeto = _Datetimeto.ToString("dd-MMM-yyyy");
           

                string[] _argsdel = { "@userid", "@datefrom", "@dateto" };
                string[] _argsvaldel = { userid, date_time, date_timeto };
                DataSet _ds_del = new DataSet();
                _ds_del = con.Sql_GetData("Bizconnect_DeliveryReport_datewise", _argsdel, _argsvaldel);
                if (_ds_del.Tables[0].Rows.Count > 0)
                {
                    div3.Visible = true;
                    gv_deliverydetails.DataSource = _ds_del;
                    gv_deliverydetails.DataBind();
                }
                else
                {
                    lbl_msg.Text = Resources.Resource.alert_error.Replace("{@message}", "Data Not Found!!");
                }
            
        }
        catch(Exception ex)
        {

        }
    }

    protected void btn_inrep_Click(object sender, EventArgs e)
    {
         try
        {
            string userid = Session["UserID"].ToString();
            string from = txt_infrom.Text;
            DateTime _Datetime = Convert.ToDateTime(from);
            string date_time = _Datetime.ToString("dd-MMM-yyyy");
            string to = txt_into.Text;
            DateTime _Datetimeto = Convert.ToDateTime(to);
            string date_timeto = _Datetimeto.ToString("dd-MMM-yyyy");
             string[] _argsintransit = { "@userid", "@datefrom", "@dateto" };
                string[] _argsvalintransit = { userid, date_time, date_timeto };
                DataSet _ds_in = new DataSet();
                _ds_in = con.Sql_GetData("Bizconnect_IntransitReport_datewise", _argsintransit, _argsvalintransit);
                if (_ds_in.Tables[0].Rows.Count > 0)
                {
                    div4.Visible = true;
                    gv_intransit.DataSource = _ds_in;
                    gv_intransit.DataBind();
                }
                else
                {
                    lbl_msg.Text = Resources.Resource.alert_error.Replace("{@message}", "Data Not Found!!");
                }
            
        }
        catch(Exception ex)
        {


        }
    }
}