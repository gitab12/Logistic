using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Routeprice_details : System.Web.UI.Page
{
    BizCon_DB_ConnectionString conbiz = new BizCon_DB_ConnectionString();
    Aumjunction_DB_ConnectionString conjunc = new Aumjunction_DB_ConnectionString();
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["UserID"] = "357";
        showdatadetails();
    }
    protected void showdatadetails()
    {
        List<BizConnectModel> BizConnectModellist = new List<BizConnectModel>();
        string _UserID = Session["UserID"].ToString();
        DateTime _currentdatetime = DateTime.Now;
        conbiz.Sql_OpenCon();
        conjunc.Sql_OpenCon();
        try
        {
            if (Session["UserID"] != null)
            {
                string[] Args = { "@TravelDateTimeStamp", "@UserID" };
                string[] Argsval = { _currentdatetime.ToString("MM/dd/yyyy"), _UserID };
                DataSet _dsLogisticsPlan = new DataSet();
                _dsLogisticsPlan = conbiz.Sql_GetData("SP_Get_LogisticsPlan_Deatis", Args, Argsval);
                foreach (DataRow drLogisticsPlan in _dsLogisticsPlan.Tables[0].Rows)
                {
                   
                    string[] args_junction = { "@PostByID", "@RequirementDate" };
                    string[] argsvaljunction = { _UserID, _currentdatetime.ToString("MM/dd/yyyy") };
                    DataSet _dsjunction = new DataSet();
                    _dsjunction = conjunc.Sql_GetData("SP_Get_Postad_Replay", args_junction, argsvaljunction);

                    foreach (DataRow drPostad_Replay in _dsjunction.Tables[0].Rows)
                    {
                        if (Convert.ToString(drLogisticsPlan["UserID"]) == Convert.ToString(drPostad_Replay["PostByID"]))
                        {
                            string _TruckTypeID = Convert.ToString(drPostad_Replay["TruckTypeID"]);
                            string[] ArgsRoute_Price = { "@Truck_type_ID" };
                            string[] ArgsvalRoute_Price = { _TruckTypeID };
                            DataSet _dsRoute_Price = new DataSet();
                            _dsRoute_Price = conbiz.Sql_GetData("SP_Get_Route_Price_Detais", ArgsRoute_Price, ArgsvalRoute_Price);

                            foreach (DataRow drRoute_Price in _dsRoute_Price.Tables[0].Rows)
                            {
                                BizConnectModel BizConnectModeldetails = new BizConnectModel();
                                BizConnectModeldetails.LogisticsPlanID = Convert.ToString(drLogisticsPlan["LogisticsPlanID"]);
                                BizConnectModeldetails.LogisticsPlanNo = Convert.ToString(drLogisticsPlan["LogisticsPlanNo"]);
                                BizConnectModeldetails.FromLocation = Convert.ToString(drPostad_Replay["FromLocation"]);
                                BizConnectModeldetails.ToLocation = Convert.ToString(drPostad_Replay["ToLocation"]);
                                BizConnectModeldetails.TruckType = Convert.ToString(drPostad_Replay["TruckType"]);
                                BizConnectModeldetails.EnclosureType = Convert.ToString(drPostad_Replay["EnclosureType"]);
                                BizConnectModeldetails.Capactiy = Convert.ToString(drRoute_Price["Capacity"]);
                                BizConnectModeldetails.Oneway_Price = Convert.ToString(drRoute_Price["Oneway_Price"]);
                                BizConnectModeldetails.Transporter_ID = Convert.ToString(drRoute_Price["Transporter_ID"]);
                                BizConnectModeldetails.ClientID = Convert.ToString(drLogisticsPlan["ClientID"]);
                                BizConnectModeldetails.TruckTypeID = Convert.ToString(drPostad_Replay["TruckTypeID"]);
                                BizConnectModeldetails.EnclosureTypeID = Convert.ToString(drPostad_Replay["EnclosureTypeID"]);
                                BizConnectModeldetails.Transporter_Name = Convert.ToString(drRoute_Price["Transporter_Name"]);
                                BizConnectModeldetails.QuoteDate = Convert.ToString(drPostad_Replay["PostedDateTimeStamp"]);
                                BizConnectModeldetails.Traveldate = Convert.ToString(drPostad_Replay["RequirementDate"]);
                                BizConnectModeldetails.EarlierQuote = Convert.ToString(drPostad_Replay["negotiablecost"]);
                                BizConnectModeldetails.Remarks = Convert.ToString(drPostad_Replay["message"]);
                                BizConnectModellist.Add(BizConnectModeldetails);
                            }
                          

                      }
                    }
                  
                }

                gv_RoutepriceDetails.DataSource = BizConnectModellist;
                gv_RoutepriceDetails.DataBind();

            }
        }
        catch (Exception ex)
        {

        }
        finally
        {
            conbiz.Sql_CloseCon();
            conjunc.Sql_CloseCon();
        }

    }
}