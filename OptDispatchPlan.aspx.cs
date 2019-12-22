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

public partial class OptDispatchPlan : System.Web.UI.Page
{

    string obj_Authenticated;
    PlaceHolder maPlaceHolder;
    UserControl obj_Tabs;
    UserControl obj_LoginCtrl;
    UserControl obj_WelcomCtrl;
    UserControl obj_Navi;
    UserControl obj_Navihome;





string Conn = ConfigurationManager.ConnectionStrings["BizCon"].ConnectionString;
    BizConnectDealProcess obj_Class2 = new BizConnectDealProcess();
    InvoiceClass obj_Class = new InvoiceClass();
    DataTable dt = new DataTable();
    DataSet ds_capacity = new DataSet();
    DataSet ds_DespOpt=new DataSet();
     int Capacity, FConversion;
    double Length, Breadth, Height, CubicFeet, NfBoxes, Loadingboxes,FTL_Total,Taurus_Total,Ft32sa_Total,
    Ft32ma_Total,TotalFTL,TotalTaurus,Total32ftsa,Total32ftma,FTLAnalysis, FTLAnalysisTotal, CFTused, TotalCFTused, Len, Bredth, Weit,TotalQuantity,TotWeight,TotWeight1;
    Double SpaceTotalFTL, SpaceTotalTaurus, SpaceTotal32ftsa, SpaceTotal32ftma, SpaceTotalQuantity, SpaceFTL_Total, SpaceTaurus_Total, SpaceFt32sa_Total, SpaceFt32ma_Total;
    //DataTable dt_GTNNo = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Load_Grid();
            Load_GTNNo();
            Load_FromLocation();
            Load_OptimizationGrid();
            Load_SpaceConstraintGrid();
            ChkAuthentication();
            grd_Optimization.Visible = false;
            grd_SpaceConstraint.Visible = false;
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


    }
    public void SetVisualOFF()
    {
        obj_LoginCtrl.Visible = true;
        obj_WelcomCtrl.Visible = false;

    }
    public void Load_Grid()
    {
        dt = obj_Class.Bizconnect_Get_OptDispatchplanDetails();
        grd_DispatchPlan.DataSource = dt;
        grd_DispatchPlan.DataBind();
    }
    
    public void Load_FromLocation()
    {
        dt.Clear();
        dt = obj_Class.Bizconnect_Get_FromLocation();
        ddl_FromLocation .DataSource = dt;
        ddl_FromLocation.DataTextField = "PlantName";
        ddl_FromLocation.DataBind();
        ddl_FromLocation.Items.Insert(0, "--Select--");
    }
    
    public void Load_GTNNo()
    {
        dt.Clear();
        dt = obj_Class.Bizconnect_Get_GTNNo(ddl_FromLocation .SelectedValue .ToString ());
        ddl_GTNNo.DataSource = dt;
        ddl_GTNNo.DataTextField = "GTNNo";
        ddl_GTNNo.DataBind();
        ddl_GTNNo.Items.Insert(0, "--Select--");
    }

    protected void btn_Search_Click(object sender, EventArgs e)
    {
     grd_DispatchPlan.Visible = true;
        grd_Optimization.Visible = false;
        if (ddl_GTNNo.SelectedValue != "--Select--")
        {
            dt.Clear();
            dt = obj_Class.Bizconnect_Search_OptDispatchplanDetails(ddl_GTNNo.SelectedItem.Text);
            grd_DispatchPlan.DataSource = dt;
            grd_DispatchPlan.DataBind();
        }
        else
        {
            Load_Grid();
        }
    }
    
     public void Load_SpaceConstraintGrid()
    {
        ds_DespOpt = obj_Class.Bizconnect_Get_DespatchOptimizDetails(ddl_GTNNo.SelectedItem.Text);
        grd_SpaceConstraint .DataSource = ds_DespOpt;
        grd_SpaceConstraint.DataBind();

        TextBox FTLCost = (TextBox)grd_SpaceConstraint.HeaderRow.FindControl("txt_Ftl");
        TextBox TaurusCost = (TextBox)grd_SpaceConstraint.HeaderRow.FindControl("txt_Tauras");
        TextBox SingleAxleCost = (TextBox)grd_SpaceConstraint.HeaderRow.FindControl("txt_32ftsa");
        TextBox MultiAxleCost = (TextBox)grd_SpaceConstraint.HeaderRow.FindControl("txt_32ftma");
        FTLCost.Text = FTLTruckCost.Value;
        TaurusCost.Text = TaurusTruckCost.Value;
        SingleAxleCost.Text = Ft32SaTruckCost.Value;
        MultiAxleCost.Text = Ft32MaTruckCost.Value;
    }
    
    public void Load_OptimizationGrid()
    {
     ds_DespOpt= obj_Class.Bizconnect_Get_DespatchOptimizDetails(ddl_GTNNo .SelectedItem .Text);
        grd_Optimization.DataSource=ds_DespOpt;
        grd_Optimization.DataBind();
        
        TextBox FTLCost = (TextBox)grd_Optimization.HeaderRow.FindControl("txt_Ftl");
        TextBox TaurusCost = (TextBox)grd_Optimization.HeaderRow.FindControl("txt_Tauras");
        TextBox SingleAxleCost = (TextBox)grd_Optimization.HeaderRow.FindControl("txt_32ftsa");
        TextBox MultiAxleCost = (TextBox)grd_Optimization.HeaderRow.FindControl("txt_32ftma");
        FTLCost.Text = FTLTruckCost.Value;
        TaurusCost.Text = TaurusTruckCost.Value;
        SingleAxleCost.Text = Ft32SaTruckCost.Value;
        MultiAxleCost.Text = Ft32MaTruckCost.Value;
    }

    protected void btn_Optimization_Click(object sender, EventArgs e)
    {
        grd_DispatchPlan.Visible = false;
               grd_SpaceConstraint.Visible = false;
        grd_Optimization.Visible = true;
          btn_Search.Enabled = false;
        ds_capacity = obj_Class2.Bizconnet_Get_CapacityCubicfeet();

        try
            {

                TextBox FTLCost = (TextBox)grd_Optimization.HeaderRow.FindControl("txt_Ftl");
                TextBox TaurusCost = (TextBox)grd_Optimization.HeaderRow.FindControl("txt_Tauras");
                TextBox SingleAxleCost = (TextBox)grd_Optimization.HeaderRow.FindControl("txt_32ftsa");
                TextBox MultiAxleCost = (TextBox)grd_Optimization.HeaderRow.FindControl("txt_32ftma");
                if (FTLCost.Text == string.Empty)
                {
                    
                    FTLTruckCost.Value = "0";
                }
            else
                {
                    FTLTruckCost.Value = FTLCost.Text;
                }
           if (TaurusCost.Text == string.Empty)
           {
               TaurusTruckCost .Value = "0";
           }else
           {
               TaurusTruckCost .Value =TaurusCost.Text;
           }
            if (SingleAxleCost.Text == string.Empty)
            {
                        Ft32SaTruckCost.Value = "0";
            }
            else{
                      Ft32SaTruckCost.Value =SingleAxleCost.Text;
            }
            if (MultiAxleCost.Text == string.Empty)
            {
                Ft32MaTruckCost.Value  = "0";
            }
            else{
                Ft32MaTruckCost.Value = MultiAxleCost.Text;
            }
                 Load_OptimizationGrid();

            for (int i = 0; i < grd_Optimization.Rows.Count; i++)
                {
                    TextBox W1 = (TextBox)grd_Optimization.Rows[i].FindControl("txt_Weight");

                    Label costforFTL = (Label)grd_Optimization.Rows[i].FindControl("lbl_CostforFTL");
                    Label costforTaurus = (Label)grd_Optimization.Rows[i].FindControl("lbl_CostforTaurus");
                    Label costfor32ftsa = (Label)grd_Optimization.Rows[i].FindControl("lbl_Costfor32ftsa");
                    Label costfor32ftma = (Label)grd_Optimization.Rows[i].FindControl("lbl_Costfor32ftma");
               
                    Label LoadBoxes = (Label)grd_Optimization.Rows[i].FindControl("lbl_OPTLoadBoxes");
                    
                    Label LoadBoxesInFTL = (Label)grd_Optimization.Rows[i].FindControl("lbl_LoadBoxesFTL");
                    Label LoadBoxesInTaurus = (Label)grd_Optimization.Rows[i].FindControl("lbl_LoadBoxesTaurus");
                    Label LoadBoxesIn32ftsa = (Label)grd_Optimization.Rows[i].FindControl("lbl_LoadBoxes32ftsa");
                    Label LoadBoxesIn32ftma = (Label)grd_Optimization.Rows[i].FindControl("lbl_LoadBoxes32ftma");
                    
                    Label Qunatity=(Label)grd_Optimization.Rows[i].FindControl("lbl_Quantity");
                    
                    Label FTLTruckTotalCost = (Label)grd_Optimization.Rows[i].FindControl("lbl_FTLCost");
                    Label TaurusTruckTotalCost = (Label)grd_Optimization.Rows[i].FindControl("lbl_TaurusCost");
                    Label Feet32saTruckTotalCost = (Label)grd_Optimization.Rows[i].FindControl("lbl_FT32saCost");
                    Label Feet32maTruckTotalCost = (Label)grd_Optimization.Rows[i].FindControl("lbl_FT32maCost");
                    Label TotalWeight = (Label)grd_Optimization.Rows[i].FindControl("lbl_TotalWeight");


                    //CubicFeet = Math.Round(Convert.ToDouble(Length) * Convert.ToDouble(Breadth) * Convert.ToDouble(Height), 2);

                  
                    
                    LoadBoxesInFTL.Text = Math.Round(Convert.ToInt32(ds_capacity.Tables[0].Rows[3][3].ToString()) / Convert.ToDouble(W1.Text), 0).ToString();
                    LoadBoxesInTaurus.Text = Math.Round(Convert.ToInt32(ds_capacity.Tables[0].Rows[0][3].ToString()) / Convert.ToDouble(W1.Text), 0).ToString();
                    LoadBoxesIn32ftsa.Text = Math.Round(Convert.ToInt32(ds_capacity.Tables[0].Rows[1][3].ToString()) / Convert.ToDouble(W1.Text), 0).ToString();
                    LoadBoxesIn32ftma.Text = Math.Round(Convert.ToInt32(ds_capacity.Tables[0].Rows[2][3].ToString()) / Convert.ToDouble(W1.Text), 0).ToString();
                   
                    
                        costforFTL.Text = Math.Round(Convert.ToDouble(FTLCost.Text) / Convert.ToDouble(LoadBoxesInFTL.Text), 2).ToString();
                    
                        costforTaurus.Text = Math.Round(Convert.ToDouble(TaurusCost.Text) / Convert.ToDouble(LoadBoxesInTaurus.Text), 2).ToString();
                    
                   
                        costfor32ftsa.Text = Math.Round(Convert.ToDouble(SingleAxleCost.Text) / Convert.ToDouble(LoadBoxesIn32ftsa.Text), 2).ToString();
                    
                    
                        costfor32ftma.Text = Math.Round(Convert.ToDouble(MultiAxleCost.Text) / Convert.ToDouble(LoadBoxesIn32ftma.Text), 2).ToString();
                        
                     //FTL_Total += Convert.ToDouble(costforFTL.Text);
                    //Taurus_Total += Convert.ToDouble(costforTaurus.Text);
                    //Ft32sa_Total += Convert.ToDouble(costfor32ftsa.Text);
                    //Ft32ma_Total += Convert.ToDouble(costfor32ftma.Text);
                    
                    TotalFTL=Convert.ToDouble(Qunatity.Text) * Convert.ToDouble(costforFTL.Text);
                    TotalTaurus=Convert.ToDouble(Qunatity.Text) * Convert.ToDouble(costforTaurus.Text);
                    Total32ftsa=Convert.ToDouble(Qunatity.Text) * Convert.ToDouble(costfor32ftsa.Text);
                    Total32ftma=Convert.ToDouble(Qunatity.Text) * Convert.ToDouble(costfor32ftma.Text);
                    TotWeight = Convert.ToDouble(Qunatity.Text) * Convert.ToDouble(W1.Text);
                    
                    
                    FTLTruckTotalCost.Text= TotalFTL.ToString();
                    TaurusTruckTotalCost.Text= TotalTaurus.ToString();
                        Feet32saTruckTotalCost.Text= Total32ftsa.ToString();
                        Feet32maTruckTotalCost.Text= Total32ftma.ToString();
                        
                         TotalWeight.Text = TotWeight.ToString();
                        
                         TotalQuantity += Convert.ToDouble(Qunatity.Text);
                        FTL_Total += Convert.ToDouble(FTLTruckTotalCost.Text);
                         Session["FTLWeightCost"] = FTL_Total.ToString();
                        Taurus_Total+=Convert.ToDouble(TaurusTruckTotalCost.Text);
                         Session["TaurusWeightCost"] = Taurus_Total;
                        Ft32sa_Total += Convert.ToDouble(Feet32saTruckTotalCost.Text);
                        Session["32ftsaWeightCost"] = Ft32sa_Total;
                        Ft32ma_Total += Convert.ToDouble(Feet32maTruckTotalCost.Text);
                           Session["32ftmaWeightCost"] = Ft32ma_Total;
                        TotWeight1 += Convert.ToDouble(TotalWeight.Text);
                        
                        
                         FTLAnalysis = Convert.ToDouble(Qunatity.Text) * Convert.ToDouble(W1.Text);
                        FTLAnalysisTotal += FTLAnalysis;
                        Session["FTLAnalsis"] = FTLAnalysisTotal.ToString();
                }
                
                 Label FTLtotal = (Label)grd_Optimization.FooterRow.FindControl("lbl_FTLtotal");
            Label Taurustotal = (Label)grd_Optimization.FooterRow.FindControl("lbl_Taurustotal");
            Label FT32satotal = (Label)grd_Optimization.FooterRow.FindControl("lbl_FT32satotal");
            Label FT32matotal = (Label)grd_Optimization.FooterRow.FindControl("lbl_FT32matotal");
                Label TotalQty = (Label)grd_Optimization.FooterRow.FindControl("lbl_TotalQty");
                         Label TotalWeight2 = (Label)grd_Optimization.FooterRow.FindControl("lbl_TotWeight");
            
            FTLtotal.Text = FTL_Total.ToString();
            TotalQty.Text = TotalQuantity.ToString();
            Taurustotal.Text = Taurus_Total.ToString();
            FT32satotal.Text = Ft32sa_Total.ToString();
            FT32matotal.Text = Ft32ma_Total.ToString();
               TotalWeight2.Text = TotWeight1.ToString();
              Count_CFT_Used();
            
                
            }
            catch (Exception ex)
            {
            }
            
            
            if (rdb_SpaceCon.Checked == true)
        {
            grd_Optimization.Visible = false;
            grd_SpaceConstraint.Visible = true;
            
            
            try
            {
                Session["CFTForSpace"] = "0";
                TextBox FTLCost = (TextBox)grd_SpaceConstraint.HeaderRow.FindControl("txt_Ftl");
                TextBox TaurusCost = (TextBox)grd_SpaceConstraint.HeaderRow.FindControl("txt_Tauras");
                TextBox SingleAxleCost = (TextBox)grd_SpaceConstraint.HeaderRow.FindControl("txt_32ftsa");
                TextBox MultiAxleCost = (TextBox)grd_SpaceConstraint.HeaderRow.FindControl("txt_32ftma");
                if (FTLCost.Text == string.Empty)
                {

                    FTLTruckCost.Value = "0";
                }
                else
                {
                    FTLTruckCost.Value = FTLCost.Text;
                }
                if (TaurusCost.Text == string.Empty)
                {
                    TaurusTruckCost.Value = "0";
                }
                else
                {
                    TaurusTruckCost.Value = TaurusCost.Text;
                }
                if (SingleAxleCost.Text == string.Empty)
                {
                    Ft32SaTruckCost.Value = "0";
                }
                else
                {
                    Ft32SaTruckCost.Value = SingleAxleCost.Text;
                }
                if (MultiAxleCost.Text == string.Empty)
                {
                    Ft32MaTruckCost.Value = "0";
                }
                else
                {
                    Ft32MaTruckCost.Value = MultiAxleCost.Text;
                }
                //Load_OptimizationGrid();
                Load_SpaceConstraintGrid();


                for (int i = 0; i < grd_SpaceConstraint.Rows.Count; i++)
                {
                    TextBox W1 = (TextBox)grd_SpaceConstraint.Rows[i].FindControl("txt_Weight");

                    Label costforFTL = (Label)grd_SpaceConstraint.Rows[i].FindControl("lbl_CostforFTL");
                    Label costforTaurus = (Label)grd_SpaceConstraint.Rows[i].FindControl("lbl_CostforTaurus");
                    Label costfor32ftsa = (Label)grd_SpaceConstraint.Rows[i].FindControl("lbl_Costfor32ftsa");
                    Label costfor32ftma = (Label)grd_SpaceConstraint.Rows[i].FindControl("lbl_Costfor32ftma");

                    Label LoadBoxes = (Label)grd_SpaceConstraint.Rows[i].FindControl("lbl_OPTLoadBoxes");

                    Label LoadBoxesInFTL = (Label)grd_SpaceConstraint.Rows[i].FindControl("lbl_LoadBoxesFTL");
                    Label LoadBoxesInTaurus = (Label)grd_SpaceConstraint.Rows[i].FindControl("lbl_LoadBoxesTaurus");
                    Label LoadBoxesIn32ftsa = (Label)grd_SpaceConstraint.Rows[i].FindControl("lbl_LoadBoxes32ftsa");
                    Label LoadBoxesIn32ftma = (Label)grd_SpaceConstraint.Rows[i].FindControl("lbl_LoadBoxes32ftma");

                Label MatCode = (Label)grd_SpaceConstraint.Rows[i].FindControl("lbl_Materialcode");


                Label Qunatity = (Label)grd_SpaceConstraint.Rows[i].FindControl("lbl_Quantity");


                dt.Clear();
                dt = obj_Class.Bizconnect_Get_OptimizationLBH(MatCode.Text);
                if (dt.Rows.Count > 0)
                {
                    Len = Convert.ToDouble(Convert.ToDouble(dt.Rows[0][1]) / 328);
                    Bredth = Convert.ToDouble(Convert.ToDouble(dt.Rows[0][2]) / 328);
                    Weit = Convert.ToDouble(Convert.ToDouble(dt.Rows[0][3]) / 328);
                    CFTused = Math.Round(Convert.ToDouble(Len * Bredth * Weit), 2);
                    TotalCFTused = CFTused;
                    Session["CFTForSpace"] = TotalCFTused;
                }

                    Label FTLTruckTotalCost = (Label)grd_SpaceConstraint.Rows[i].FindControl("lbl_FTLCost");
                    Label TaurusTruckTotalCost = (Label)grd_SpaceConstraint.Rows[i].FindControl("lbl_TaurusCost");
                    Label Feet32saTruckTotalCost = (Label)grd_SpaceConstraint.Rows[i].FindControl("lbl_FT32saCost");
                    Label Feet32maTruckTotalCost = (Label)grd_SpaceConstraint.Rows[i].FindControl("lbl_FT32maCost");
                    //Label TotalWeight = (Label)grd_SpaceConstraint.Rows[i].FindControl("lbl_TotalWeight");




                    //CubicFeet = Math.Round(Convert.ToDouble(Length) * Convert.ToDouble(Breadth) * Convert.ToDouble(Height), 2);



                    LoadBoxesInFTL.Text = Math.Round(Convert.ToInt32(ds_capacity.Tables[0].Rows[3][2].ToString()) / Convert.ToDouble(Session["CFTForSpace"]), 0).ToString();
                    LoadBoxesInTaurus.Text = Math.Round(Convert.ToInt32(ds_capacity.Tables[0].Rows[0][2].ToString()) / Convert.ToDouble(Session["CFTForSpace"]), 0).ToString();
                    LoadBoxesIn32ftsa.Text = Math.Round(Convert.ToInt32(ds_capacity.Tables[0].Rows[1][2].ToString()) / Convert.ToDouble(Session["CFTForSpace"]), 0).ToString();
                    LoadBoxesIn32ftma.Text = Math.Round(Convert.ToInt32(ds_capacity.Tables[0].Rows[2][2].ToString()) / Convert.ToDouble(Session["CFTForSpace"]), 0).ToString();


                    costforFTL.Text = Math.Round(Convert.ToDouble(FTLCost.Text) / Convert.ToDouble(LoadBoxesInFTL.Text), 2).ToString();

                    costforTaurus.Text = Math.Round(Convert.ToDouble(TaurusCost.Text) / Convert.ToDouble(LoadBoxesInTaurus.Text), 2).ToString();


                    costfor32ftsa.Text = Math.Round(Convert.ToDouble(SingleAxleCost.Text) / Convert.ToDouble(LoadBoxesIn32ftsa.Text), 2).ToString();


                    costfor32ftma.Text = Math.Round(Convert.ToDouble(MultiAxleCost.Text) / Convert.ToDouble(LoadBoxesIn32ftma.Text), 2).ToString();

                    // FTL_Total += Convert.ToDouble(costforFTL.Text);
                    //Taurus_Total += Convert.ToDouble(costforTaurus.Text);
                    //Ft32sa_Total += Convert.ToDouble(costfor32ftsa.Text);
                    //Ft32ma_Total += Convert.ToDouble(costfor32ftma.Text);

                    SpaceTotalFTL = Math.Round( Convert.ToDouble(FTLCost.Text) / 795 * Convert.ToDouble(Qunatity.Text),2);
                    SpaceTotalTaurus = Math.Round(Convert.ToDouble(TaurusCost.Text) / 1237 * Convert.ToDouble(Qunatity.Text), 2);
                    SpaceTotal32ftsa = Math.Round(Convert.ToDouble(SingleAxleCost.Text) / 2048 * Convert.ToDouble(Qunatity.Text), 2);
                    SpaceTotal32ftma = Math.Round(Convert.ToDouble(MultiAxleCost.Text) / 2048 * Convert.ToDouble(Qunatity.Text), 2);
                    TotWeight = Convert.ToDouble(Qunatity.Text) * Convert.ToDouble(W1.Text);


                    FTLTruckTotalCost.Text = SpaceTotalFTL.ToString();
                    TaurusTruckTotalCost.Text = SpaceTotalTaurus.ToString();
                    Feet32saTruckTotalCost.Text = SpaceTotal32ftsa.ToString();
                    Feet32maTruckTotalCost.Text = SpaceTotal32ftma.ToString();

                    //TotalWeight.Text = TotWeight.ToString();

                    SpaceTotalQuantity += Convert.ToDouble(Qunatity.Text);
                    SpaceFTL_Total += Convert.ToDouble(FTLTruckTotalCost.Text);
                       Session["FTLSpaceCost"] = SpaceFTL_Total;
                    SpaceTaurus_Total += Convert.ToDouble(TaurusTruckTotalCost.Text);
                    Session["TaurusSpaceCost"] = SpaceTaurus_Total;
                    SpaceFt32sa_Total += Convert.ToDouble(Feet32saTruckTotalCost.Text);
                    Session["32ftsaSpaceCost"] = SpaceFt32sa_Total;
                    SpaceFt32ma_Total += Convert.ToDouble(Feet32maTruckTotalCost.Text);
                     Session["32ftmaSpaceCost"] = SpaceFt32ma_Total;
                    //TotWeight1 += Convert.ToDouble(TotalWeight.Text);

                    FTLAnalysis = Convert.ToDouble(Qunatity.Text) * Convert.ToDouble(W1.Text);
                    FTLAnalysisTotal += FTLAnalysis;
                    Session["FTLAnalsis"] = FTLAnalysisTotal.ToString();

                }

                Label FTLtotal = (Label)grd_SpaceConstraint.FooterRow.FindControl("lbl_FTLtotal");
                Label Taurustotal = (Label)grd_SpaceConstraint.FooterRow.FindControl("lbl_Taurustotal");
                Label FT32satotal = (Label)grd_SpaceConstraint.FooterRow.FindControl("lbl_FT32satotal");
                Label FT32matotal = (Label)grd_SpaceConstraint.FooterRow.FindControl("lbl_FT32matotal");
                Label TotalQty = (Label)grd_SpaceConstraint.FooterRow.FindControl("lbl_TotalQty");
                Label TotalWeight2 = (Label)grd_SpaceConstraint.FooterRow.FindControl("lbl_TotWeight");


                FTLtotal.Text = SpaceFTL_Total.ToString();
                TotalQty.Text = SpaceTotalQuantity.ToString();
                Taurustotal.Text = SpaceTaurus_Total.ToString();
                FT32satotal.Text = SpaceFt32sa_Total.ToString();
                FT32matotal.Text = SpaceFt32ma_Total.ToString();
                //TotalWeight2.Text = TotWeight1.ToString();
                Count_CFT_Used();


            }
            catch (Exception ex)
            {
            }

        }
            
    }
    
    protected void ddl_GTNN0_SelectedIndexChanged(object sender, EventArgs e)
    {
    try
    {
    Session["FTlQuote"] = 0;
        Session["32ftmaQuote"] = 0;
        Session["TaurusQuote"] = 0;
        Session["32ftsaQuote"] = 0;
    
     lbl_FromLocName.Visible =true ;
            lbl_FromLoc.Visible =true ;
            lbl_ToLocName.Visible =true ;
            lbl_ToLoc.Visible = true;
    
    Load_OptimizationGrid();
      Load_SpaceConstraintGrid();
    SqlConnection conn = new SqlConnection();
     SqlCommand cmd;
            conn.ConnectionString = Conn;
            conn.Open();
            SqlDataReader mydatareader;
            string qry;
        TextBox FTLCost = (TextBox)grd_Optimization.HeaderRow.FindControl("txt_Ftl");
        TextBox TaurusCost = (TextBox)grd_Optimization.HeaderRow.FindControl("txt_Tauras");
        TextBox SingleAxleCost = (TextBox)grd_Optimization.HeaderRow.FindControl("txt_32ftsa");
        TextBox MultiAxleCost = (TextBox)grd_Optimization.HeaderRow.FindControl("txt_32ftma");
       
       TextBox FTLCostForSpace = (TextBox)grd_SpaceConstraint.HeaderRow.FindControl("txt_Ftl");
        TextBox TaurusCostForSpace = (TextBox)grd_SpaceConstraint.HeaderRow.FindControl("txt_Tauras");
        TextBox SingleAxleCostForSpace = (TextBox)grd_SpaceConstraint.HeaderRow.FindControl("txt_32ftsa");
        TextBox MultiAxleCostForSpace = (TextBox)grd_SpaceConstraint.HeaderRow.FindControl("txt_32ftma");
       
        DataSet ds_Lowquote = new DataSet();
        qry = "select distinct PlantName,ReceivingPlantName  from Bizconnect .dbo.Bizconnect_OptDispatchPlan where GTNNo='" + ddl_GTNNo .SelectedItem .Text + " ' ";
                        cmd = new SqlCommand(qry, conn);
                        mydatareader = cmd.ExecuteReader();
						  mydatareader.Read();
						  
				lbl_FromLoc.Text = mydatareader.GetValue(0).ToString();
                lbl_ToLoc.Text = mydatareader.GetValue(1).ToString();
     
        ds_Lowquote = obj_Class2.Bizconnect_Get_LowestQuoteBasedOnTruck(mydatareader.GetValue(0).ToString(), mydatareader.GetValue(1).ToString());
        if(ds_Lowquote .Tables [0].Rows .Count >0)
        {
        Session ["TaurusQuote"]=ds_Lowquote .Tables [0].Rows [0][0];
        }
        else{
             Session ["TaurusQuote"]=0;
        }
         if(ds_Lowquote .Tables [1].Rows .Count >0)
        {
              Session ["32ftsaQuote"]=ds_Lowquote .Tables [1].Rows [0][0];
         }
        else{
              Session ["32ftsaQuote"]=0;
        }
         if(ds_Lowquote .Tables [2].Rows .Count >0)
        {
              Session ["32ftmaQuote"]=ds_Lowquote .Tables [2].Rows [0][0];
         }
        else{
              Session ["32ftmaQuote"]=0;
        }
         if(ds_Lowquote .Tables [3].Rows .Count >0)
        {
            Session["FTlQuote"] = ds_Lowquote.Tables[3].Rows[0][0];
         }
        else{
            Session["FTlQuote"] = 0;
        }
        
         FTLCost.Text = Session["FTlQuote"].ToString();
         TaurusCost.Text = Session["TaurusQuote"].ToString();
         SingleAxleCost.Text = Session["32ftsaQuote"].ToString();
         MultiAxleCost.Text = Session["32ftmaQuote"].ToString();
         
         FTLCostForSpace.Text = Session["FTlQuote"].ToString();
         TaurusCostForSpace.Text = Session["TaurusQuote"].ToString();
         SingleAxleCostForSpace.Text = Session["32ftsaQuote"].ToString();
         MultiAxleCostForSpace.Text = Session["32ftmaQuote"].ToString();
         
}

 catch (Exception ex)
        {
        }


    }
    
     protected void btn_Summary_Click(object sender, EventArgs e)
    {
    try
    {
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add("Category");
        dt.Columns.Add("FTL");
        dt.Columns.Add("Taurus");
        dt.Columns.Add("32Ft Single Axle");
        dt.Columns.Add("32Ft Double Axle");
        dr = dt.NewRow();
        dr[0] = "Maxium weight in tons";
        dr[1] = 9000;
        dr[2] = 16000;
        dr[3] = 7000;
        dr[4] = 15000;
        dt.Rows.Add(dr);
        //2nd row
        dr = dt.NewRow();
        dr[0] = "Weight Loaded";
        //dr[1] = FTLAnalysisTotal.ToString ();
        dr[1] = Session["FTLAnalsis"].ToString();
        dr[2] = Session["FTLAnalsis"].ToString();
        dr[3] = Session["FTLAnalsis"].ToString();
        dr[4] = Session["FTLAnalsis"].ToString();

        dt.Rows.Add(dr);
        //2nd row
        dr = dt.NewRow();
        dr[0] = "Gap";
        //dr[1] = FTLAnalysisTotal.ToString ();
        dr[1] =  Math.Round(9000-Convert .ToDouble (Session["FTLAnalsis"].ToString()),2);
        dr[2] = Math.Round(16000-Convert .ToDouble (Session["FTLAnalsis"].ToString()),2);;
        dr[3] = Math.Round(7000-Convert .ToDouble (Session["FTLAnalsis"].ToString()),2);;
        dr[4] = Math.Round(15000 - Convert.ToDouble(Session["FTLAnalsis"].ToString()), 2); ;
        
        dt.Rows.Add(dr);
        // 3rd row
        dr = dt.NewRow();
        dr[0] = "Weight(%)";
        dr[1]=Math.Round((Convert .ToDouble (Session["FTLAnalsis"].ToString())/9000)*100,2);
        dr[2] = Math.Round((Convert.ToDouble(Session["FTLAnalsis"].ToString()) / 16000) * 100, 2);
        dr[3] = Math.Round((Convert.ToDouble(Session["FTLAnalsis"].ToString()) / 7000) * 100, 2);
        dr[4] = Math.Round((Convert.ToDouble(Session["FTLAnalsis"].ToString()) / 15000) * 100, 2);

        dt.Rows.Add(dr);
        
        dr = dt.NewRow();
            dr[0] = "Cost based on weight";

            dr[1] = Session["FTLWeightCost"].ToString();
            dr[2] = Session["TaurusWeightCost"];
            dr[3] = Session["32ftsaWeightCost"];
            dr[4] = Session["32ftmaWeightCost"];

            dt.Rows.Add(dr);

        // 4th row

        dr = dt.NewRow();
        dr[0] = "Maximum CFT";
        dr[1] = 795;
        dr[2] =1237 ;
        dr[3] = 2048;
        dr[4] = 2048;
        dt.Rows.Add(dr);
        //5th row

        dr = dt.NewRow();
        dr[0] = "CFT Used";
        dr[1] = Session["CFTTotal"].ToString ();
        dr[2] = Session["CFTTotal"].ToString();
        dr[3] = Session["CFTTotal"].ToString();
        dr[4] = Session["CFTTotal"].ToString();
        dt.Rows.Add(dr);
        // 6th row 

        dr = dt.NewRow();
        dr[0] = "Gap";
        //dr[1] = FTLAnalysisTotal.ToString ();
        dr[1] = Math.Round(795 - Convert.ToDouble(Session["CFTTotal"].ToString()), 2);
        dr[2] = Math.Round(1257 - Convert.ToDouble(Session["CFTTotal"].ToString()), 2); ;
        dr[3] = Math.Round(2048 - Convert.ToDouble(Session["CFTTotal"].ToString()), 2); ;
        dr[4] = Math.Round(2048 - Convert.ToDouble(Session["CFTTotal"].ToString()), 2); ;

        dt.Rows.Add(dr);
        //7th row

        dr = dt.NewRow();
        dr[0] = "CFT(%)";
        dr[1] = Math.Round((Convert.ToDouble(Session["CFTTotal"].ToString()) / 795) * 100, 2);
        dr[2] = Math.Round((Convert.ToDouble(Session["CFTTotal"].ToString()) / 1257) * 100, 2);
        dr[3] = Math.Round((Convert.ToDouble(Session["CFTTotal"].ToString()) / 2048) * 100, 2);
        dr[4] = Math.Round((Convert.ToDouble(Session["CFTTotal"].ToString()) / 2048) * 100, 2);

        dt.Rows.Add(dr);
        
        dr = dt.NewRow();
            dr[0] = "Cost based on space";
            dr[1] = Session["FTLSpaceCost"];
            dr[2] = Session["TaurusSpaceCost"];
            dr[3] = Session["32ftsaSpaceCost"];
            dr[4] = Session["32ftmaSpaceCost"];

            dt.Rows.Add(dr);

        grd_Analysis.DataSource = dt;
        grd_Analysis.DataBind();
        
      }
      
      catch(Exception ex)
      {
      }  

    }
    
    
     public void Count_CFT_Used()
    {
        try
        {
            Session["CFTTotal"] = "0";
            for (int i = 0; i < grd_Optimization.Rows.Count; i++)
            {
                Label MatCode = (Label)grd_Optimization.Rows[i].FindControl("lbl_Materialcode");
                Label Quantity = (Label)grd_Optimization.Rows[i].FindControl("lbl_Quantity");

                dt.Clear();
                dt = obj_Class.Bizconnect_Get_OptimizationLBH(MatCode.Text);
                if (dt.Rows.Count > 0)
                {
                    Len = Convert.ToDouble(Convert.ToDouble(dt.Rows[0][1]) / 328);
                    Bredth = Convert.ToDouble(Convert.ToDouble(dt.Rows[0][2]) / 328);
                    Weit = Convert.ToDouble(Convert.ToDouble(dt.Rows[0][3]) / 328);
                    CFTused = Math.Round(Convert.ToDouble(Len * Bredth * Weit * Convert.ToDouble(Quantity.Text)), 2);
                    TotalCFTused += CFTused;
                    Session["CFTTotal"] = TotalCFTused;
                }
            }

        }
        catch (Exception ex)
        {
        }
    }
    
     protected void ddl_FromLocation_SelectedIndexChanged(object sender, EventArgs e)
    {

        try
        {
            Load_GTNNo();
        }
        catch(Exception ex)
            {

            }
    }


     protected void Button1_Click(object sender, EventArgs e)
     {

         ExportGrid(grd_DispatchPlan, "GTNOptimization.xls");

     }
     public static void ExportGrid(GridView oGrid, string exportFile)
     {
         //Clear the response, and set the content type and mark as attachment
         HttpContext.Current.Response.Clear();
         HttpContext.Current.Response.Buffer = true;
         HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";
         HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=\"" + exportFile + "\"");

         //Clear the character set
         HttpContext.Current.Response.Charset = "";

         //Create a string and Html writer needed for output
         System.IO.StringWriter oStringWriter = new System.IO.StringWriter();
         System.Web.UI.HtmlTextWriter oHtmlTextWriter = new System.Web.UI.HtmlTextWriter(oStringWriter);

         //Clear the controls from the pased grid
         ClearControls(oGrid);

         //Show grid lines
         oGrid.GridLines = GridLines.Both;

         //Color header
         oGrid.HeaderStyle.BackColor = System.Drawing.Color.LightGray;

         //Render the grid to the writer
         oGrid.RenderControl(oHtmlTextWriter);

         //Write out the response (file), then end the response
         HttpContext.Current.Response.Write(oStringWriter.ToString());
         HttpContext.Current.Response.End();
     }
     private static void ClearControls(Control control)
     {
         //Recursively loop through the controls, calling this method
         for (int i = control.Controls.Count - 1; i >= 0; i--)
         {
             ClearControls(control.Controls[i]);
         }

         //If we have a control that is anything other than a table cell
         if (!(control is TableCell))
         {
             if (control.GetType().GetProperty("SelectedItem") != null)
             {
                 LiteralControl literal = new LiteralControl();
                 control.Parent.Controls.Add(literal);
                 try
                 {
                     literal.Text = (string)control.GetType().GetProperty("SelectedItem").GetValue(control, null);
                 }
                 catch
                 {
                 }
                 control.Parent.Controls.Remove(control);
             }
             else
                 if (control.GetType().GetProperty("Text") != null)
                 {
                     LiteralControl literal = new LiteralControl();
                     control.Parent.Controls.Add(literal);
                     literal.Text = (string)control.GetType().GetProperty("Text").GetValue(control, null);
                     control.Parent.Controls.Remove(control);
                 }
         }
         return;
     }
     public override void VerifyRenderingInServerForm(Control control)
     {

     }
    
    
}