using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TrackVehicleStatus : System.Web.UI.Page
{
    AAUMConnect_DB_ConnectionString con1 = new AAUMConnect_DB_ConnectionString();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string Vehicle_no = Request.QueryString["VehicleNo"];
            if (Vehicle_no != null)
            {
                
                string[] args = { "@vehicleno" };
                string[] argsval = { Vehicle_no };
                DataSet ds_trackdetails = new DataSet();
                ds_trackdetails = con1.Sql_GetData("AAUMConnect_TrackDetails", args, argsval);
                if (ds_trackdetails.Tables[0].Rows.Count > 0)
                {
                    string Source = ds_trackdetails.Tables[0].Rows[0]["source"].ToString();
                    string dest_latlong = ds_trackdetails.Tables[0].Rows[0]["DestinationLatLng"].ToString();
                    string sim_no = ds_trackdetails.Tables[0].Rows[0]["sim_no"].ToString();
                    string mysim_no="91" + sim_no;
                    string[] _args = { "@sender" };
                    string[] _argsval = { mysim_no };
                    DataSet _ds_trackdetails = new DataSet();
                    _ds_trackdetails = con1.Sql_GetData("AAUMConnect_GetCurrentLocation", _args, _argsval);
                    string currentlocation = _ds_trackdetails.Tables[0].Rows[0]["LAT"].ToString() + "," + _ds_trackdetails.Tables[0].Rows[0]["LONG"].ToString();
                    string current_address = _ds_trackdetails.Tables[0].Rows[0]["address"].ToString();
                    string current_time = Convert.ToDateTime(_ds_trackdetails.Tables[0].Rows[0]["datetimestamp"]).ToString("dd/MMM/yyyy  hh:mm tt");

                    hf_startvalue.Value = Source;// "13.012728, 77.674841";
                    hf_endvalue.Value = dest_latlong;//"18.614389, 73.805963";
                    hf_waypoints.Value = currentlocation;//"13.012728, 77.674841";

                    lbl_Live_Tracking_of.Text = "Live Tracking of " + " " + mysim_no;
                         string[] _args1 = { "@vehicleno" };
                         string[] _argsval1 = { Vehicle_no };
                         DataSet _dstrackdetails = new DataSet();
                         _dstrackdetails = con1.Sql_GetData("AAUMConnect_GetPlanActiveDetail", _args1, _argsval1);
                        if (_dstrackdetails.Tables[0].Rows.Count > 0)
                        {
                            string IsPlanActive = _dstrackdetails.Tables[0].Rows[0]["IsPlanactive"].ToString();
                            
                            if (IsPlanActive == "0")
                            {
                                string UnloadingPoint_date = Convert.ToDateTime(_dstrackdetails.Tables[0].Rows[0]["UnloadingDateTime"]).ToString("dd/MMM/yyyy  hh:mm tt");
                                lbl_address.Text = "The Vehicle has reached on " + " " + UnloadingPoint_date;

                            }
                            else
                            {
                                lbl_address.Text = "Current Location : " + " " + current_address + " ," + current_time;
                            }

                        }
                    
                    gv_details.DataSource = ds_trackdetails;
                    gv_details.DataBind();

                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "PopupScript", "alert('Device is not pushing the Data!!')", true);
                    //Response.Redirect("LoadingStatus.aspx");
                }
            }
            else
            {
                // ClientScript.RegisterStartupScript(this.GetType(), "PopupScript", "alert('Oops!! Something Went Wrong!')", true);
            }
        }
        catch (Exception ex)
        {

        }
    }
}