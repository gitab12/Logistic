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
using System.Data.SqlClient;

public partial class DashboardVehiclePlaced : System.Web.UI.Page
{
  string obj_Authenticated;
    PlaceHolder maPlaceHolder;
    UserControl obj_Tabs;
    UserControl obj_LoginCtrl;
    UserControl obj_WelcomCtrl;
    UserControl obj_Navi;
    UserControl obj_Navihome;
    ProjectBased Obj_Class = new ProjectBased();
    string qry;
    DataSet ds = new DataSet();
    string Qrystring;
    int NoofTrucks,  Optimization, Savings,Decidedprice;
    Double TotalWeight;
    protected void Page_Load(object sender, EventArgs e)
    {
    if (Session["UserID"] != string.Empty && Convert.ToInt32(Session["UserID"].ToString()) > 0)
        {
        Qrystring = Request.QueryString["route"].ToString();
        if (!IsPostBack)
        {
         ChkAuthentication();
            VehiclePlaced();
        }
        
        }
      
        
              else
        {
            Response.Redirect("Index.aspx");
        }
    }
    public void VehiclePlaced()
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["BizCon"].ConnectionString);
        conn.Open();
        qry = "select TA.FromLocation ,TA .ToLocation , PD.LoadingDate,TA .TruckType ,TA .Capacity ,Count(td.AcceptanceID )as VehiclePlaced ,TD.VehicleNo,PD .TotalWeight as 'TotalWeight[A]',bp.BasePrice as 'BasePrice[B]',DecidedPrice as 'DecidedPrice[C]',Round(TotalWeight/LEFT(capacity,2)*100 ,2)as optimizationpercent,round((bp.BasePrice*pd.TotalWeight)-AR.DecidedPrice,0)as  'Savings[A*B]-C' from Bizconnect_AgreementRoutes ar inner join BizConnect_TripAssign TA on TA.AgreementRouteID=AR.AgreementRouteID inner join bizconnect_TripAcceptanceDetails  TD on TD.TripAssignID =TA.TripAssignID inner join Bizconnect_PreloadDetails PD on PD.AcceptanceID=td.AcceptanceID  inner join Bizconnect_ClientBasePrice BP on BP.ToLocation=TA.ToLocation and  TD.ClientID=BP.ClientID  where TD.ClientID= '" + Session["ClientID"].ToString() + "'and TA .ToLocation ='" + Qrystring + "' and TD.LoadedStatus in(0,1)group by  TA.FromLocation ,TA .ToLocation , PD.LoadingDate,TA .TruckType ,TA .Capacity ,TD.VehicleNo,PD .TotalWeight,TotalWeight-LEFT(capacity,2) ,round((bp.BasePrice*pd.TotalWeight)-AR.DecidedPrice,0),BasePrice ,DecidedPrice";
        SqlCommand cmd = new SqlCommand(qry, conn);
        cmd.ExecuteNonQuery();
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        ds = new DataSet();
        adp.Fill(ds);

        grd_DashboardVehicle.DataSource = ds;
        grd_DashboardVehicle.DataBind();
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

    
 protected void grd_DashboardVehicle_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
             if (e.Row.RowType == DataControlRowType.DataRow)
            {
                NoofTrucks += Convert.ToInt32(e.Row.Cells[5].Text);
                TotalWeight += Convert.ToDouble(e.Row.Cells[7].Text);
                //Optimization += Convert.ToInt32(e.Row.Cells[8].Text);
                
                Decidedprice+=Convert.ToInt32(e.Row.Cells[9].Text);
                Savings += Convert.ToInt32(e.Row.Cells[11].Text);
                
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[5].Text = NoofTrucks.ToString();
                e.Row.Cells[7].Text = TotalWeight.ToString();
                //e.Row.Cells[8].Text = Optimization.ToString();
                e.Row.Cells[9].Text = Decidedprice.ToString();
                e.Row.Cells[11].Text = Savings.ToString();
            }
        }
        catch (Exception ex)
        {
        }

    }
    
    protected void btn_Search_Click(object sender, EventArgs e)
 {
     TripAcceptance obj_Class = new TripAcceptance();
     DataSet ds_Search = new DataSet();
     ds_Search = obj_Class.Bizconnect_SearchVehiclePlaced(Convert.ToInt32(Session["ClientID"].ToString()),Qrystring, Convert.ToDateTime(txt_FromDate.Text), Convert.ToDateTime(txt_ToDate.Text));
     if (ds_Search.Tables[0].Rows.Count > 0)
     {
         grd_DashboardVehicle.DataSource = ds_Search;
         grd_DashboardVehicle.DataBind();
     }
     else
     {

     }
 }

    
}
