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
using System.Globalization;
using System.Data.SqlClient;
public partial class TripCancellation : System.Web.UI.Page
{
    ClientsReport obj_Class = new ClientsReport();
    string obj_Authenticated;
    PlaceHolder maPlaceHolder;
    UserControl obj_Tabs;
    UserControl obj_LoginCtrl;
    UserControl obj_WelcomCtrl;
    UserControl obj_Navi;
    UserControl obj_Navihome;
    DataSet ds;
    BizCon_DB_ConnectionString con = new BizCon_DB_ConnectionString();
    
    protected void Page_Load(object sender, EventArgs e)
    {
       
         if (Session["UserID"] != string.Empty && Convert.ToInt32(Session["UserID"].ToString()) > 0)
      {
        if (!IsPostBack)
        {
            ChkAuthentication();
            LoadTripDetails();
            
        }
      }
      
        else
        {
            Response.Redirect("Index.html");
        }  

    }
    



 public void LoadTripDetails()
    {
        try
        {
            
            ds = obj_Class.BizConnect_TripCancellation(Convert.ToInt32(Session["UserID"].ToString()));
            Gridwindow.DataSource = ds;
            Gridwindow.DataBind();

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
 protected void ButSubmit_Click(object sender, EventArgs e)
 {
      Button b = (Button)sender;
            GridViewRow row = (GridViewRow)b.NamingContainer;
            if (row != null)
            {
                Label TripID = (Label)Gridwindow.Rows[row.RowIndex].FindControl("lblTripID");
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["BizCon"].ConnectionString);
                conn.Open();

                string query1 = "Update BizConnect_TripAssign set Assigned=2 where TripAssignID ="+TripID.Text  +"";
                SqlCommand sqlCmd1 = new SqlCommand(query1, conn);
              int resp=  sqlCmd1.ExecuteNonQuery();
              if (resp == 1)
              {
                  //LoadTripDetails();
                 // this.Page.ClientScript.RegisterStartupScript(typeof(Page), "notification", "window.alert('Trip Cancelled');", true);
                  string[] args = { "@tripassignid" };
                  string[] argsval = { TripID.Text };
                  DataSet ds = new DataSet();
                  ds = con.Sql_GetData("Bizconnect_Get_Acceptanceid", args, argsval);
                  if (ds.Tables[0].Rows.Count > 0)
                  {
                      string acceptanceid = ds.Tables[0].Rows[0]["AcceptanceID"].ToString();

                      string[] _args = { "@acceptanceid" };
                      string[] _argsval = { acceptanceid };
                      DataSet _ds = new DataSet();
                      _ds = con.Sql_GetData("Bizconnect_Delete_Acceptanceid", _args, _argsval);
                      LoadTripDetails();
                      this.Page.ClientScript.RegisterStartupScript(typeof(Page), "notification", "window.alert('Trip Cancelled');", true);
                  }
                  else
                  {
                      LoadTripDetails();
                      this.Page.ClientScript.RegisterStartupScript(typeof(Page), "notification", "window.alert('Trip Cancelled');", true);
                  }
              }
            }

 }
    
}