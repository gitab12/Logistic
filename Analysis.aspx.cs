using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Analysis : System.Web.UI.Page
{

    string obj_Authenticated;
    PlaceHolder maPlaceHolder;
    UserControl obj_Tabs;
    UserControl obj_LoginCtrl;
    UserControl obj_WelcomCtrl;
    UserControl obj_Navi;
    UserControl obj_Navihome;

    BizConnectDealProcess obj_Class = new BizConnectDealProcess();
    DataSet ds = new DataSet();
    DataSet ds_capacity = new DataSet();
    DataSet ds_Lowquote = new DataSet();
    DataTable dt = new DataTable();
    DataTable dt_Bind = new DataTable();
    DataSet ds_Analysis = new DataSet();
    DataTable dt_AnaSearh = new DataTable();
   

    int Capacity, FConversion;
    double Length, Breadth, Height, CubicFeet, NfBoxes, Loadingboxes;
    double VolLength, VolBreadth, VolHeight, VolCubicFeet, VolNfBoxes, VolLoadingboxes;
    double NoofCartons, TotalCFTs, TotalFTL, TotalTarus, Total32saTot, Total32maTot,TotalWeight;
    double Len=0,bred=0,hei=0;
    int FTLSop, TaurusSop, SaSop, MaSop;
    double FTLDesWei, TaurusDesWei, SaDesWei, MaDesWei;
    double FTLNoOFTrucks, TaurusNoOFTrucks, SaNoOFTrucks, MaNoOFTrucks, NoOfFTLCartons, NoOfTaurusCartons, NoOfSaCartons, NoOfMaCartons, FtlCost, TaurusCost, SaCost, MaCost;
    string TravelDate;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //GridBind();
            BindAnalysisGrid();
           // Load_FromLoc();
            Load_ToLoc();
            Session["TaurusQuote"] = 0;
            Session["32ftsaQuote"] = 0;
            Session["32ftmaQuote"] = 0;
            Session["FTlQuote"] = 0;

            ChkAuthentication();   
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


    //public void Load_FromLoc()
    //{
    //    ds = obj_Class.bizconnect_Get_Fromlocation(Convert.ToInt32(Session["ClientID"].ToString()));
    //    ddl_FromLoc.DataSource = ds;
    //    ddl_FromLoc.DataTextField = "FromLocation";
    //    ddl_FromLoc.DataBind();
    //    ddl_FromLoc.Items.Insert(0, new ListItem("--Select--", "0"));
    //}
    public void Load_ToLoc()
    {
        ds = obj_Class.bizconnect_Get_ToLocation(Convert.ToInt32(Session["ClientID"].ToString()));
        ddl_ToLoc.DataSource = ds;
        ddl_ToLoc.DataTextField = "ToLocation";
        ddl_ToLoc.DataBind();
        ddl_ToLoc.Items.Insert(0, new ListItem("--Select--", "0"));
    }

    public void GridBind()
    {

        ds = obj_Class.Get_OptimizationDetails(Convert.ToInt32(Session["ClientID"].ToString()));
        grd_Analysis.DataSource = ds;
        grd_Analysis.DataBind();
    }

    public void BindAnalysisGrid()
    {
        //load weight Analysis
        ds_Analysis = obj_Class.Bizconnect_Get_OptimizationAnalysis(Convert.ToInt32(Session["ClientID"].ToString()));
        grd_WeightAnalysis.DataSource = ds_Analysis;
        grd_WeightAnalysis.DataBind();
        //load space Analysis
       // ds_Analysis = obj_Class.Bizconnect_Get_OptimizationAnalysis(Convert.ToInt32(Session["ClientID"].ToString()));
        grd_VolumeAnalysis.DataSource = ds_Analysis;
        grd_VolumeAnalysis.DataBind();
    }

    protected void btn_Analysis_Click(object sender, EventArgs e)
    {
        
        if (ddl_FromLoc.SelectedValue.ToString() == "0" || ddl_ToLoc.SelectedValue.ToString() == "0")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Please Select Both From and To Location For Analysis!');</script>");
        }
        else
        {
            ds_capacity = obj_Class.Bizconnet_Get_CapacityCubicfeet();
            try
            {

                TextBox FTLCost = (TextBox)grd_Analysis.HeaderRow.FindControl("txt_Ftl");
                TextBox TaurusCost = (TextBox)grd_Analysis.HeaderRow.FindControl("txt_Tauras");
                TextBox SingleAxleCost = (TextBox)grd_Analysis.HeaderRow.FindControl("txt_32ftsa");
                TextBox MultiAxleCost = (TextBox)grd_Analysis.HeaderRow.FindControl("txt_32ftma");

                for (int i = 0; i < grd_Analysis.Rows.Count; i++)
                {
                    Label lblL1 = (Label)grd_Analysis.Rows[i].FindControl("lbl_Length");
                    Label lblB1 = (Label)grd_Analysis.Rows[i].FindControl("lbl_Breadth");
                    Label lblH1 = (Label)grd_Analysis.Rows[i].FindControl("lbl_Height");

                    TextBox l1 = (TextBox)grd_Analysis.Rows[i].FindControl("txt_Length");
                    TextBox B1 = (TextBox)grd_Analysis.Rows[i].FindControl("txt_Breadth");
                    TextBox H1 = (TextBox)grd_Analysis.Rows[i].FindControl("txt_Height");
                    TextBox W1 = (TextBox)grd_Analysis.Rows[i].FindControl("txt_Weight");

                    Label FeetConv = (Label)grd_Analysis.Rows[i].FindControl("lbl_FeetCon");
                    Label costforFTL = (Label)grd_Analysis.Rows[i].FindControl("lbl_CostforFTL");
                    Label costforTaurus = (Label)grd_Analysis.Rows[i].FindControl("lbl_CostforTaurus");
                    Label costfor32ftsa = (Label)grd_Analysis.Rows[i].FindControl("lbl_Costfor32ftsa");
                    Label costfor32ftma = (Label)grd_Analysis.Rows[i].FindControl("lbl_Costfor32ftma");

                    FConversion = Convert.ToInt32(FeetConv.Text);
                    Label length1 = (Label)grd_Analysis.Rows[i].FindControl("lbl_OPTLength");
                    Label Breadth1 = (Label)grd_Analysis.Rows[i].FindControl("lbl_OPTBreadth");
                    Label Height1 = (Label)grd_Analysis.Rows[i].FindControl("lbl_OPTHeight");
                    Label Cft1 = (Label)grd_Analysis.Rows[i].FindControl("lbl_OPTCFT");
                    Label LoadBoxes = (Label)grd_Analysis.Rows[i].FindControl("lbl_OPTLoadBoxes");
                    Label NoOfBoxesInFtl = (Label)grd_Analysis.Rows[i].FindControl("lbl_NoofBoxesFtl");
                    Label NoOfBoxesInTaurus = (Label)grd_Analysis.Rows[i].FindControl("lbl_NoofBoxesTaurus");
                    Label NoOfBoxesIn32ftsa = (Label)grd_Analysis.Rows[i].FindControl("lbl_NoofBoxes32sa");
                    Label NoOfBoxesIn32ftma = (Label)grd_Analysis.Rows[i].FindControl("lbl_NoofBoxes32ma");
                    Label LoadBoxesInFTL = (Label)grd_Analysis.Rows[i].FindControl("lbl_LoadBoxesFTL");
                    Label LoadBoxesInTaurus = (Label)grd_Analysis.Rows[i].FindControl("lbl_LoadBoxesTaurus");
                    Label LoadBoxesIn32ftsa = (Label)grd_Analysis.Rows[i].FindControl("lbl_LoadBoxes32ftsa");
                    Label LoadBoxesIn32ftma = (Label)grd_Analysis.Rows[i].FindControl("lbl_LoadBoxes32ftma");


                    Length = Math.Round(Convert.ToDouble(lblL1.Text) / FConversion, 2);
                    Breadth = Math.Round(Convert.ToDouble(lblB1.Text) / FConversion, 2);
                    Height = Math.Round(Convert.ToDouble(lblH1.Text) / FConversion, 2);
                    CubicFeet = Math.Round(Convert.ToDouble(Length) * Convert.ToDouble(Breadth) * Convert.ToDouble(Height), 2);

                    length1.Text = Length.ToString();
                    Breadth1.Text = Breadth.ToString();
                    Height1.Text = Height.ToString();
                    Cft1.Text = CubicFeet.ToString();
                    NoOfBoxesInFtl.Text = Math.Round(Convert.ToInt32(ds_capacity.Tables[0].Rows[3][2].ToString()) / CubicFeet, 0).ToString();
                    NoOfBoxesInTaurus.Text = Math.Round(Convert.ToInt32(ds_capacity.Tables[0].Rows[0][2].ToString()) / CubicFeet, 0).ToString();
                    NoOfBoxesIn32ftsa.Text = Math.Round(Convert.ToInt32(ds_capacity.Tables[0].Rows[1][2].ToString()) / CubicFeet, 0).ToString();
                    NoOfBoxesIn32ftma.Text = Math.Round(Convert.ToInt32(ds_capacity.Tables[0].Rows[2][2].ToString()) / CubicFeet, 0).ToString();
                    LoadBoxesInFTL.Text = Math.Round(Convert.ToInt32(ds_capacity.Tables[0].Rows[3][3].ToString()) / Convert.ToDouble(W1.Text), 0).ToString();
                    LoadBoxesInTaurus.Text = Math.Round(Convert.ToInt32(ds_capacity.Tables[0].Rows[0][3].ToString()) / Convert.ToDouble(W1.Text), 0).ToString();
                    LoadBoxesIn32ftsa.Text = Math.Round(Convert.ToInt32(ds_capacity.Tables[0].Rows[1][3].ToString()) / Convert.ToDouble(W1.Text), 0).ToString();
                    LoadBoxesIn32ftma.Text = Math.Round(Convert.ToInt32(ds_capacity.Tables[0].Rows[2][3].ToString()) / Convert.ToDouble(W1.Text), 0).ToString();
                    if (Convert.ToDouble(NoOfBoxesInFtl.Text) < Convert.ToDouble(LoadBoxesInFTL.Text))
                    {
                        costforFTL.Text = Math.Round(Convert.ToDouble(FTLCost.Text) / Convert.ToDouble(NoOfBoxesInFtl.Text), 2).ToString();
                    }
                    else
                    {
                        costforFTL.Text = Math.Round(Convert.ToDouble(FTLCost.Text) / Convert.ToDouble(LoadBoxesInFTL.Text), 2).ToString();
                    }
                    if (Convert.ToDouble(NoOfBoxesInTaurus.Text) < Convert.ToDouble(LoadBoxesInTaurus.Text))
                    {
                        costforTaurus.Text = Math.Round(Convert.ToDouble(TaurusCost.Text) / Convert.ToDouble(NoOfBoxesInTaurus.Text), 2).ToString();
                    }
                    else
                    {
                        costforTaurus.Text = Math.Round(Convert.ToDouble(TaurusCost.Text) / Convert.ToDouble(LoadBoxesInTaurus.Text), 2).ToString();
                    }
                    if (Convert.ToDouble(NoOfBoxesIn32ftsa.Text) < Convert.ToDouble(LoadBoxesIn32ftsa.Text))
                    {
                        costfor32ftsa.Text = Math.Round(Convert.ToDouble(SingleAxleCost.Text) / Convert.ToDouble(NoOfBoxesIn32ftsa.Text), 2).ToString();
                    }
                    else
                    {
                        costfor32ftsa.Text = Math.Round(Convert.ToDouble(SingleAxleCost.Text) / Convert.ToDouble(LoadBoxesIn32ftsa.Text), 2).ToString();
                    }
                    if (Convert.ToDouble(NoOfBoxesIn32ftma.Text) < Convert.ToDouble(LoadBoxesIn32ftma.Text))
                    {
                        costfor32ftma.Text = Math.Round(Convert.ToDouble(MultiAxleCost.Text) / Convert.ToDouble(NoOfBoxesIn32ftma.Text), 2).ToString();
                    }
                    else
                    {
                        costfor32ftma.Text = Math.Round(Convert.ToDouble(MultiAxleCost.Text) / Convert.ToDouble(LoadBoxesIn32ftma.Text), 2).ToString();
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }
    }

    protected void ddl_ToLoc_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            grd_Summary.Visible = false;
            grd_WeightAnalysis.Visible = false;
            grd_VolumeAnalysis.Visible = false;

            //ds_Lowquote = obj_Class.Bizconnect_Get_LowestQuoteBasedOnTruck(ddl_FromLoc.SelectedValue.ToString(), ddl_ToLoc.SelectedValue.ToString());
            //if (ds_Lowquote.Tables[0].Rows.Count > 0)
            //{
            //    Session["TaurusQuote"] = ds_Lowquote.Tables[0].Rows[0][0];
            //}
            //else
            //{
            //    Session["TaurusQuote"] = 0;
            //}
            //if (ds_Lowquote.Tables[1].Rows.Count > 0)
            //{
            //    Session["32ftsaQuote"] = ds_Lowquote.Tables[1].Rows[0][0];
            //}
            //else
            //{
            //    Session["32ftsaQuote"] = 0;
            //}
            //if (ds_Lowquote.Tables[2].Rows.Count > 0)
            //{
            //    Session["32ftmaQuote"] = ds_Lowquote.Tables[2].Rows[0][0];
            //}
            //else
            //{
            //    Session["32ftmaQuote"] = 0;
            //}
            //if (ds_Lowquote.Tables[3].Rows.Count > 0)
            //{
            //    Session["FTlQuote"] = ds_Lowquote.Tables[3].Rows[0][0];
            //}
            //else
            //{
            //    Session["FTlQuote"] = 0;
            //}
            //TextBox FtlQuote = (TextBox)grd_Analysis.HeaderRow.FindControl("txt_Ftl");
            //TextBox TaurusQuote = (TextBox)grd_Analysis.HeaderRow.FindControl("txt_Tauras");
            //TextBox SaQuote = (TextBox)grd_Analysis.HeaderRow.FindControl("txt_32ftsa");
            //TextBox MaQuote = (TextBox)grd_Analysis.HeaderRow.FindControl("txt_32ftma");
            //FtlQuote.Text = Session["FTlQuote"].ToString();
            //TaurusQuote.Text = Session["TaurusQuote"].ToString();
            //SaQuote.Text = Session["32ftsaQuote"].ToString();
            //MaQuote.Text = Session["32ftmaQuote"].ToString();


            ds = obj_Class.bizconnect_Get_Fromlocation(Convert.ToInt32(Session["ClientID"].ToString()), ddl_ToLoc.SelectedItem.Text);
            ddl_FromLoc.DataSource = ds;
            ddl_FromLoc.DataTextField = "FromLocation";
            ddl_FromLoc.DataBind();
            ddl_FromLoc.Items.Insert(0, new ListItem("--Select--", "0"));


            dt = obj_Class.Bizconnet_Get_DespatchPlanNoByTolocation(Convert.ToInt32(Session["ClientID"].ToString()), ddl_ToLoc.SelectedItem.Text);
            ddl_PlanNo.DataSource = dt;
            ddl_PlanNo.DataTextField = "PlanNo";
            ddl_PlanNo.DataBind();
            ddl_PlanNo.Items.Insert(0, new ListItem("--Select--", "0"));

            //dt_Bind = obj_Class.Bizconnect_SearchDespatchplanByPlannoAndTolocation(Convert.ToInt32(Session["ClientID"].ToString()), ddl_ToLoc.SelectedItem.Text, string.Empty);
            //grd_Analysis.DataSource = dt_Bind;
            //grd_Analysis.DataBind();


            //dt_AnaSearh = obj_Class.Bizconnect_SearchDespatchplanAnalysisByPlannoAndTolocation(Convert.ToInt32(Session["ClientID"].ToString()), ddl_ToLoc.SelectedItem.Text, string.Empty);
            dt_AnaSearh = obj_Class.Bizconnect_SearchDespatchVolumeAnalysisbyTolocationandPlanno(Convert.ToInt32(Session["ClientID"].ToString()), ddl_ToLoc.SelectedItem.Text, string.Empty);
            grd_WeightAnalysis.DataSource = dt_AnaSearh;
            grd_WeightAnalysis.DataBind();

            dt_Bind.Clear();
            dt_Bind = obj_Class.Bizconnect_SearchDespatchVolumeAnalysisbyTolocationandPlanno(Convert.ToInt32(Session["ClientID"].ToString()), ddl_ToLoc.SelectedItem.Text, string.Empty);
            grd_VolumeAnalysis.DataSource = dt_Bind;
            grd_VolumeAnalysis.DataBind();



        }
        catch (Exception ex)
        {

        }

    }
    
    protected void btn_ExportToExcel_Click(object sender, EventArgs e)
    {
        ExportGrid(grd_Analysis, "Analysis.xls");
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

    public override void VerifyRenderingInServerForm(Control control)
    {

    }
    
    protected void btn_Despatchplan_Click(object sender, EventArgs e)
    {
    Response.Redirect("~/OptDispatchPlan.aspx");
    }


    protected void ddl_PlanNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            grd_Summary.Visible = false;
            grd_WeightAnalysis.Visible = false;
            grd_VolumeAnalysis.Visible = false;
            if (ddl_PlanNo.SelectedItem.Text != "--Select--")
            {
                //dt_Bind.Clear();
                //dt_Bind = obj_Class.Bizconnect_SearchDespatchplanByPlannoAndTolocation(Convert.ToInt32(Session["ClientID"].ToString()), ddl_ToLoc.SelectedItem.Text, ddl_PlanNo.SelectedItem.Text);
                //grd_Analysis.DataSource = dt_Bind;
                //grd_Analysis.DataBind();


                dt_AnaSearh.Clear();
                //dt_AnaSearh = obj_Class.Bizconnect_SearchDespatchplanAnalysisByPlannoAndTolocation(Convert.ToInt32(Session["ClientID"].ToString()), ddl_ToLoc.SelectedItem.Text, ddl_PlanNo.SelectedItem.Text);
                dt_AnaSearh = obj_Class.Bizconnect_SearchDespatchVolumeAnalysisbyTolocationandPlanno(Convert.ToInt32(Session["ClientID"].ToString()), ddl_ToLoc.SelectedItem.Text, ddl_PlanNo.SelectedItem.Text);
                grd_WeightAnalysis.DataSource = dt_AnaSearh;
                grd_WeightAnalysis.DataBind();

                dt_Bind.Clear();
                dt_Bind = obj_Class.Bizconnect_SearchDespatchVolumeAnalysisbyTolocationandPlanno(Convert.ToInt32(Session["ClientID"].ToString()), ddl_ToLoc.SelectedItem.Text, ddl_PlanNo.SelectedItem.Text);
                grd_VolumeAnalysis.DataSource = dt_Bind;
                grd_VolumeAnalysis.DataBind();

            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Please Select Plan No  For search despatch plan details!');</script>");
            }
        }
        catch (Exception ex)
        {

        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        grd_Summary.Visible = false;
        pnl_Summary.Visible = false ;
        pnl_OptSummary.Visible = false;
        
        if (ddl_FromLoc.SelectedValue.ToString() == "0" || ddl_ToLoc.SelectedValue.ToString() == "0")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Please Select Both From and To Location For Analysis!');</script>");
        }
        else
        {

            dt_AnaSearh.Clear();
            dt_AnaSearh = obj_Class.Bizconnect_SearchDespatchVolumeAnalysisbyTolocationandPlanno(Convert.ToInt32(Session["ClientID"].ToString()), ddl_ToLoc.SelectedItem.Text, string.Empty);
            grd_WeightAnalysis.DataSource = dt_AnaSearh;
            grd_WeightAnalysis.DataBind();

            //dt_Bind = obj_Class.Bizconnect_SearchDespatchVolumeAnalysisbyTolocationandPlanno(Convert.ToInt32(Session["ClientID"].ToString()), ddl_ToLoc.SelectedItem.Text, string.Empty);
            grd_VolumeAnalysis.DataSource = dt_AnaSearh;
            grd_VolumeAnalysis.DataBind();

            if (ddl_PlanNo.SelectedItem.Text != "--Select--")
            {
                dt_AnaSearh.Clear();
                //dt_AnaSearh = obj_Class.Bizconnect_SearchDespatchplanAnalysisByPlannoAndTolocation(Convert.ToInt32(Session["ClientID"].ToString()), ddl_ToLoc.SelectedItem.Text, ddl_PlanNo.SelectedItem.Text);
                dt_AnaSearh = obj_Class.Bizconnect_SearchDespatchVolumeAnalysisbyTolocationandPlanno(Convert.ToInt32(Session["ClientID"].ToString()), ddl_ToLoc.SelectedItem.Text, ddl_PlanNo.SelectedItem.Text);
                grd_WeightAnalysis.DataSource = dt_AnaSearh;
                grd_WeightAnalysis.DataBind();

                dt_Bind.Clear();
                dt_Bind = obj_Class.Bizconnect_SearchDespatchVolumeAnalysisbyTolocationandPlanno(Convert.ToInt32(Session["ClientID"].ToString()), ddl_ToLoc.SelectedItem.Text, ddl_PlanNo.SelectedItem.Text);
                grd_VolumeAnalysis.DataSource = dt_Bind;
                grd_VolumeAnalysis.DataBind();
            }



            if (rdb_Weight.Checked == true)
            {
                grd_WeightAnalysis.Visible = true ;
                grd_VolumeAnalysis.Visible = false ;
                //pnl_OptSummary.Visible = true ;
                ds_capacity = obj_Class.Bizconnet_Get_CapacityCubicfeet();
                try
                {

                    TextBox FTLCost = (TextBox)grd_WeightAnalysis.HeaderRow.FindControl("txt_Ftl");
                    TextBox TaurusCost = (TextBox)grd_WeightAnalysis.HeaderRow.FindControl("txt_Tauras");
                    TextBox SingleAxleCost = (TextBox)grd_WeightAnalysis.HeaderRow.FindControl("txt_32ftsa");
                    TextBox MultiAxleCost = (TextBox)grd_WeightAnalysis.HeaderRow.FindControl("txt_32ftma");

                    for (int i = 0; i < grd_WeightAnalysis.Rows.Count; i++)
                    {
                        Label lblL1 = (Label)grd_WeightAnalysis.Rows[i].FindControl("lbl_Length");
                        Label lblB1 = (Label)grd_WeightAnalysis.Rows[i].FindControl("lbl_Breadth");
                        Label lblH1 = (Label)grd_WeightAnalysis.Rows[i].FindControl("lbl_Height");


                        Label lblWei = (Label)grd_WeightAnalysis.Rows[i].FindControl("lbl_Weight");
                        Label lblCode = (Label)grd_WeightAnalysis.Rows[i].FindControl("lbl_Code");

                        Label TotalCFT = (Label)grd_WeightAnalysis.Rows[i].FindControl("lbl_TotalCFT");

                        TextBox l1 = (TextBox)grd_WeightAnalysis.Rows[i].FindControl("txt_Length");
                        TextBox B1 = (TextBox)grd_WeightAnalysis.Rows[i].FindControl("txt_Breadth");
                        TextBox H1 = (TextBox)grd_WeightAnalysis.Rows[i].FindControl("txt_Height");
                        TextBox W1 = (TextBox)grd_WeightAnalysis.Rows[i].FindControl("txt_TotalWeight");

                        Label FeetConv = (Label)grd_WeightAnalysis.Rows[i].FindControl("lbl_FeetCon");
                        Label costforFTL = (Label)grd_WeightAnalysis.Rows[i].FindControl("lbl_CostforFTL");
                        Label costforTaurus = (Label)grd_WeightAnalysis.Rows[i].FindControl("lbl_CostforTaurus");
                        Label costfor32ftsa = (Label)grd_WeightAnalysis.Rows[i].FindControl("lbl_Costfor32ftsa");
                        Label costfor32ftma = (Label)grd_WeightAnalysis.Rows[i].FindControl("lbl_Costfor32ftma");
                        Label Product = (Label)grd_WeightAnalysis.Rows[i].FindControl("lbl_Product");


                        Label NumberofCartons = (Label)grd_WeightAnalysis.Rows[i].FindControl("lbl_NumberofCartons");

                        FConversion = Convert.ToInt32(FeetConv.Text);
                        Label length1 = (Label)grd_WeightAnalysis.Rows[i].FindControl("lbl_OPTLength");
                        Label Breadth1 = (Label)grd_WeightAnalysis.Rows[i].FindControl("lbl_OPTBreadth");
                        Label Height1 = (Label)grd_WeightAnalysis.Rows[i].FindControl("lbl_OPTHeight");
                        Label Cft1 = (Label)grd_WeightAnalysis.Rows[i].FindControl("lbl_OPTCFT");
                        Label LoadBoxes = (Label)grd_WeightAnalysis.Rows[i].FindControl("lbl_OPTLoadBoxes");


                        Label LoadBoxesInFTL = (Label)grd_WeightAnalysis.Rows[i].FindControl("lbl_LoadBoxesFTL");
                        Label LoadBoxesInTaurus = (Label)grd_WeightAnalysis.Rows[i].FindControl("lbl_LoadBoxesTaurus");
                        Label LoadBoxesIn32ftsa = (Label)grd_WeightAnalysis.Rows[i].FindControl("lbl_LoadBoxes32ftsa");
                        Label LoadBoxesIn32ftma = (Label)grd_WeightAnalysis.Rows[i].FindControl("lbl_LoadBoxes32ftma");


                        Length = Math.Round(Convert.ToDouble(lblL1.Text) / FConversion, 2);
                        Breadth = Math.Round(Convert.ToDouble(lblB1.Text) / FConversion, 2);
                        Height = Math.Round(Convert.ToDouble(lblH1.Text) / FConversion, 2);
                        CubicFeet = Math.Round(Convert.ToDouble(Length) * Convert.ToDouble(Breadth) * Convert.ToDouble(Height) * Convert.ToDouble(NumberofCartons.Text), 2);

                        //assigned 1000 as CubicFeet
                        // CubicFeet1 = 1000;
                        //
                        length1.Text = Length.ToString();
                        Breadth1.Text = Breadth.ToString();
                        Height1.Text = Height.ToString();
                        Cft1.Text = CubicFeet.ToString();
                        Session["WeiProduct"] = Product.Text;
                        Product.Text = Session["WeiProduct"] + "(Code :" + lblCode.Text + ")" + "<br />" + "( L :" + Length + " )" + "<br /> " + " ( B :" + Breadth + " )" + " <br />" + "( H :" + Height + ")" + " <br />" + "( W :" + lblWei.Text + ")";
                        // Product .Text +=Product.Text +"B :"+ Breadth ;
                        //Product.Text = Product.Text + "H :" + Height;

                        /////start calculating weight constraint
                        double BoxesInFTL = Math.Round(Convert.ToDouble(ds_capacity.Tables[0].Rows[3][3].ToString()), 0);
                        LoadBoxesInTaurus.Text = Math.Round(Convert.ToDouble(ds_capacity.Tables[0].Rows[0][3].ToString()), 0).ToString();
                        LoadBoxesIn32ftsa.Text = Math.Round(Convert.ToDouble(ds_capacity.Tables[0].Rows[1][3].ToString()), 0).ToString();
                        LoadBoxesIn32ftma.Text = Math.Round(Convert.ToDouble(ds_capacity.Tables[0].Rows[2][3].ToString()), 0).ToString();

                        TotalCFT.Text = CubicFeet.ToString();

                        LoadBoxesInFTL.Text = Math.Round((Convert.ToDouble(W1.Text) / Convert.ToDouble(BoxesInFTL)), 2).ToString();
                        LoadBoxesInTaurus.Text = Math.Round((Convert.ToDouble(W1.Text) / Convert.ToDouble(LoadBoxesInTaurus.Text)), 2).ToString();
                        LoadBoxesIn32ftsa.Text = Math.Round((Convert.ToDouble(W1.Text) / Convert.ToDouble(LoadBoxesIn32ftsa.Text)), 2).ToString();
                        LoadBoxesIn32ftma.Text = Math.Round((Convert.ToDouble(W1.Text) / Convert.ToDouble(LoadBoxesIn32ftma.Text)), 2).ToString();
                        //end



                        Label NoofCartonstotal = (Label)grd_WeightAnalysis.FooterRow.FindControl("lbl_NoofCartonsTotal");
                        Label Totalweight = (Label)grd_WeightAnalysis.FooterRow.FindControl("lbl_TotalWeight");
                        Label FtlTotal = (Label)grd_WeightAnalysis.FooterRow.FindControl("lbl_FtlTotal");
                        Label TarusTotal = (Label)grd_WeightAnalysis.FooterRow.FindControl("lbl_TarusTotal");
                        Label Total32sa = (Label)grd_WeightAnalysis.FooterRow.FindControl("lbl_32saTotal");
                        Label Total32ma = (Label)grd_WeightAnalysis.FooterRow.FindControl("lbl_32MaTotal");


                        NoofCartons += Convert.ToDouble(NumberofCartons.Text);
                        TotalCFTs += Convert.ToDouble(W1.Text);
                        TotalFTL += Convert.ToDouble(LoadBoxesInFTL.Text);
                        TotalTarus += Convert.ToDouble(LoadBoxesInTaurus.Text);
                        Total32saTot += Convert.ToDouble(LoadBoxesIn32ftsa.Text);
                        Total32maTot += Convert.ToDouble(LoadBoxesIn32ftma.Text);

                        //Session["TotalCFT"] = Convert.ToDouble(TotalCFTs);

                        NoofCartonstotal.Text = NoofCartons.ToString();
                        Totalweight.Text = TotalCFTs.ToString();
                        FtlTotal.Text = TotalFTL.ToString();
                        TarusTotal.Text = TotalTarus.ToString();
                        Total32sa.Text = Total32saTot.ToString();
                        Total32ma.Text = Total32maTot.ToString();

                    }
                }
                catch (Exception ex)
                {
                }
            }

            if (rdb_Volume.Checked == true)
            {
                grd_VolumeAnalysis.Visible = true;
                grd_WeightAnalysis .Visible = false;
                pnl_OptSummary.Visible = false;
                Session["Productname"] = "";
                ds_capacity = obj_Class.Bizconnet_Get_CapacityCubicfeet();
                try
                {

                    TextBox FTLCost = (TextBox)grd_VolumeAnalysis.HeaderRow.FindControl("txt_Ftl");
                    TextBox TaurusCost = (TextBox)grd_VolumeAnalysis.HeaderRow.FindControl("txt_Tauras");
                    TextBox SingleAxleCost = (TextBox)grd_VolumeAnalysis.HeaderRow.FindControl("txt_32ftsa");
                    TextBox MultiAxleCost = (TextBox)grd_VolumeAnalysis.HeaderRow.FindControl("txt_32ftma");
                    Session["Product"] = "";
                    Session["Productname"] = "";
                    Len = 0;
                    bred = 0;
                    hei = 0;
                    for (int i = 0; i < grd_VolumeAnalysis.Rows.Count; i++)
                    {
                        Label VollblL1 = (Label)grd_VolumeAnalysis.Rows[i].FindControl("lbl_Length");
                        Label VollblB1 = (Label)grd_VolumeAnalysis.Rows[i].FindControl("lbl_Breadth");
                        Label VollblH1 = (Label)grd_VolumeAnalysis.Rows[i].FindControl("lbl_Height");

                        Label lblWei = (Label)grd_VolumeAnalysis.Rows[i].FindControl("lbl_Weight");
                        Label lblCode = (Label)grd_VolumeAnalysis.Rows[i].FindControl("lbl_Code");

                        Label TotalCFT = (Label)grd_VolumeAnalysis.Rows[i].FindControl("lbl_TotalCFT");

                        TextBox l1 = (TextBox)grd_VolumeAnalysis.Rows[i].FindControl("txt_Length");
                        TextBox B1 = (TextBox)grd_VolumeAnalysis.Rows[i].FindControl("txt_Breadth");
                        TextBox H1 = (TextBox)grd_VolumeAnalysis.Rows[i].FindControl("txt_Height");

                        Label FeetConv = (Label)grd_VolumeAnalysis.Rows[i].FindControl("lbl_FeetCon");
                        Label costforFTL = (Label)grd_VolumeAnalysis.Rows[i].FindControl("lbl_CostforFTL");
                        Label costforTaurus = (Label)grd_VolumeAnalysis.Rows[i].FindControl("lbl_CostforTaurus");
                        Label costfor32ftsa = (Label)grd_VolumeAnalysis.Rows[i].FindControl("lbl_Costfor32ftsa");
                        Label costfor32ftma = (Label)grd_VolumeAnalysis.Rows[i].FindControl("lbl_Costfor32ftma");
                        Label Productname = (Label)grd_VolumeAnalysis.Rows[i].FindControl("lbl_Product");


                        Label NumberofCartons = (Label)grd_VolumeAnalysis.Rows[i].FindControl("lbl_NumberofCartons");

                        FConversion = Convert.ToInt32(FeetConv.Text);
                        Label length1 = (Label)grd_VolumeAnalysis.Rows[i].FindControl("lbl_OPTLength");
                        Label Breadth1 = (Label)grd_VolumeAnalysis.Rows[i].FindControl("lbl_OPTBreadth");
                        Label Height1 = (Label)grd_VolumeAnalysis.Rows[i].FindControl("lbl_OPTHeight");
                        Label Cft1 = (Label)grd_VolumeAnalysis.Rows[i].FindControl("lbl_OPTCFT");
                        Label LoadBoxes = (Label)grd_VolumeAnalysis.Rows[i].FindControl("lbl_OPTLoadBoxes");

                        Label NoOfBoxesInFtl = (Label)grd_VolumeAnalysis.Rows[i].FindControl("lbl_NoofBoxesFtl");
                        Label NoOfBoxesInTaurus = (Label)grd_VolumeAnalysis.Rows[i].FindControl("lbl_NoofBoxesTaurus");
                        Label NoOfBoxesIn32ftsa = (Label)grd_VolumeAnalysis.Rows[i].FindControl("lbl_NoofBoxes32sa");
                        Label NoOfBoxesIn32ftma = (Label)grd_VolumeAnalysis.Rows[i].FindControl("lbl_NoofBoxes32ma");

                        Label LoadBoxesInFTL = (Label)grd_VolumeAnalysis.Rows[i].FindControl("lbl_LoadBoxesFTL");
                        Label LoadBoxesInTaurus = (Label)grd_VolumeAnalysis.Rows[i].FindControl("lbl_LoadBoxesTaurus");
                        Label LoadBoxesIn32ftsa = (Label)grd_VolumeAnalysis.Rows[i].FindControl("lbl_LoadBoxes32ftsa");
                        Label LoadBoxesIn32ftma = (Label)grd_VolumeAnalysis.Rows[i].FindControl("lbl_LoadBoxes32ftma");


                        VolLength = Math.Round(Convert.ToDouble(VollblL1.Text) / FConversion, 2);
                        VolBreadth = Math.Round(Convert.ToDouble(VollblB1.Text) / FConversion, 2);
                        VolHeight = Math.Round(Convert.ToDouble(VollblH1.Text) / FConversion, 2);
                        VolCubicFeet = Math.Round(Convert.ToDouble(VolLength) * Convert.ToDouble(VolBreadth) * Convert.ToDouble(VolHeight) * Convert.ToDouble(NumberofCartons.Text), 2);

                        Len  = VolLength;
                        bred = VolBreadth;
                        hei = VolHeight;

                        //assigned 1000 as CubicFeet
                        // CubicFeet1 = 1000;
                        //
                        //Productname.Text = "";
                        Session["Product"] = Productname.Text;
                        length1.Text = VolLength.ToString();
                        Breadth1.Text = VolBreadth.ToString();
                        Height1.Text = VolHeight.ToString();
                        Cft1.Text = CubicFeet.ToString();
                        Session["Productname"] = Session["Product"] + "(Code :" + lblCode.Text + ")" + "<br />" + "( L :" + Len + " )" + "<br /> " + " ( B :" + bred + " )" + " <br />" + "( H :" + hei + ")" + " <br />" + "( W :" + lblWei.Text + ")";
                        Productname.Text = Session["Productname"].ToString ();
                       // Productname.Text = Productname.Text + "--" + "(" + Math.Round(Convert.ToDouble(Length) * Convert.ToDouble(Breadth) * Convert.ToDouble(Height), 2) + ")".ToString(); ;
                        // Product .Text +=Product.Text +"B :"+ Breadth ;
                        //Product.Text = Product.Text + "H :" + Height;
                        TotalCFT.Text = VolCubicFeet.ToString();

                        ///start calculating space constraint
                        NoOfBoxesInFtl.Text = Math.Round(VolCubicFeet / Convert.ToInt32(ds_capacity.Tables[0].Rows[3][2].ToString()), 2).ToString();
                        NoOfBoxesInTaurus.Text = Math.Round(VolCubicFeet / Convert.ToInt32(ds_capacity.Tables[0].Rows[0][2].ToString()), 2).ToString();
                        NoOfBoxesIn32ftsa.Text = Math.Round(VolCubicFeet / Convert.ToInt32(ds_capacity.Tables[0].Rows[1][2].ToString()), 2).ToString();
                        NoOfBoxesIn32ftma.Text = Math.Round(VolCubicFeet / Convert.ToInt32(ds_capacity.Tables[0].Rows[2][2].ToString()), 2).ToString();

                        double NoofFTL = (Convert.ToDouble(NoOfBoxesInFtl.Text));
                        NoOfBoxesInFtl.Text = NoofFTL.ToString();
                        NoOfBoxesInTaurus.Text = Convert.ToDouble(NoOfBoxesInTaurus.Text).ToString();
                        NoOfBoxesIn32ftsa.Text = Convert.ToDouble(NoOfBoxesIn32ftsa.Text).ToString();
                        NoOfBoxesIn32ftma.Text = Convert.ToDouble(NoOfBoxesIn32ftma.Text).ToString();
                        ////end


                        Label NoofCartonstotal = (Label)grd_VolumeAnalysis.FooterRow.FindControl("lbl_NoofCartonsTotal");
                        Label TotalCFTtotal = (Label)grd_VolumeAnalysis.FooterRow.FindControl("lbl_TotalCFTtotal");
                        Label FtlTotal = (Label)grd_VolumeAnalysis.FooterRow.FindControl("lbl_FtlTotal");
                        Label TarusTotal = (Label)grd_VolumeAnalysis.FooterRow.FindControl("lbl_TarusTotal");
                        Label Total32sa = (Label)grd_VolumeAnalysis.FooterRow.FindControl("lbl_32saTotal");
                        Label Total32ma = (Label)grd_VolumeAnalysis.FooterRow.FindControl("lbl_32MaTotal");


                        NoofCartons += Convert.ToDouble(NumberofCartons.Text);
                        TotalCFTs += Convert.ToDouble(TotalCFT.Text);
                        TotalFTL += Convert.ToDouble(NoOfBoxesInFtl.Text);
                        TotalTarus += Convert.ToDouble(NoOfBoxesInTaurus.Text);
                        Total32saTot += Convert.ToDouble(NoOfBoxesIn32ftsa.Text);
                        Total32maTot += Convert.ToDouble(NoOfBoxesIn32ftma.Text);

                        NoofCartonstotal.Text = NoofCartons.ToString();
                        TotalCFTtotal.Text = TotalCFTs.ToString();
                        FtlTotal.Text = TotalFTL.ToString();
                        TarusTotal.Text = TotalTarus.ToString();
                        Total32sa.Text = Total32saTot.ToString();
                        Total32ma.Text = Total32maTot.ToString();
                        Len = 0;
                        bred = 0;
                        hei = 0;
                    }
                }
                catch (Exception ex)
                {
                }
            }
        }
    }


    protected void btn_Summary_Click(object sender, EventArgs e)
    {
        try
        {
            rdb_Volume.Checked = false;
            rdb_Weight.Checked = false;
            pnl_Summary.Visible = true;
            grd_Summary.Visible = true;
            grd_VolumeAnalysis.Visible = false;
            grd_WeightAnalysis.Visible = false;
            for (int i = 0; i < grd_WeightAnalysis .Rows.Count; i++)
            {
                //Total weight
                TextBox MaxWeight = (TextBox)grd_WeightAnalysis.Rows[i].FindControl("txt_TotalWeight");
                TotalWeight += Convert.ToDouble(MaxWeight.Text);
                //Session["MaxWeight"] = Convert.ToDouble(MaxWeight.Text);
            }

            Session["MaxWeight"] = TotalWeight;
            for (int i = 0; i < grd_VolumeAnalysis.Rows.Count; i++)
            {
                Label TotalCFT = (Label)grd_VolumeAnalysis.Rows[i].FindControl("lbl_TotalCFT");

                Label lblL1 = (Label)grd_VolumeAnalysis.Rows[i].FindControl("lbl_Length");
                Label lblB1 = (Label)grd_VolumeAnalysis.Rows[i].FindControl("lbl_Breadth");
                Label lblH1 = (Label)grd_VolumeAnalysis.Rows[i].FindControl("lbl_Height");
                Label NumberofCartons = (Label)grd_VolumeAnalysis.Rows[i].FindControl("lbl_NumberofCartons");

                Length = Math.Round(Convert.ToDouble(lblL1.Text) / 328, 2);
                Breadth = Math.Round(Convert.ToDouble(lblB1.Text) / 328, 2);
                Height = Math.Round(Convert.ToDouble(lblH1.Text) / 328, 2);
                CubicFeet = Math.Round(Convert.ToDouble(Length) * Convert.ToDouble(Breadth) * Convert.ToDouble(Height) * Convert.ToDouble(NumberofCartons.Text), 2);

                TotalCFT.Text = CubicFeet.ToString();

                TotalCFTs += Convert.ToDouble(TotalCFT.Text);
                //TotalCFTtotal.Text = TotalCFTs.ToString();
            }

            //Label TotalCFTtotal = (Label)grd_VolumeAnalysis.FooterRow.FindControl("lbl_TotalCFTtotal");
            Session["TotalCFT"] = Convert.ToDouble(TotalCFTs);

            DataTable dt = new DataTable();

            DataRow dr;
            dt.Columns.Add("Optimization");
            dt.Columns.Add("FTL");
            dt.Columns.Add("Taurus");
            dt.Columns.Add("32Ft Single Axle");
            dt.Columns.Add("32Ft Double Axle");
            dr = dt.NewRow();
            dr[0] = "Maxium volume";
            dr[1] = 882;
            dr[2] = 1078;
            dr[3] = 2048;
            dr[4] = 2048;
            dt.Rows.Add(dr);
            //2nd row
            dr = dt.NewRow();
            dr[0] = "Despatch volume";
            //dr[1] = FTLAnalysisTotal.ToString ();
            dr[1] = Session["TotalCFT"];
            dr[2] = Session["TotalCFT"];
            dr[3] = Session["TotalCFT"];
            dr[4] = Session["TotalCFT"];

            dt.Rows.Add(dr);
            //2nd row

            FTLSop = txt_FTLSop.Text == "" ? 0 : Convert.ToInt32(txt_FTLSop.Text);
            double volFtlTrucksReq = FTLSop != 0 ? Math.Round((Convert.ToDouble(Session["TotalCFT"])) / (18 * 7 * FTLSop), 3) : Math.Round(Convert.ToDouble(Session["TotalCFT"]) / 882, 3);

            TaurusSop = txt_TaurusSop.Text == "" ? 0 : Convert.ToInt32(txt_TaurusSop.Text);
            double volTaurusTrucksReq = TaurusSop != 0 ? Math.Round((Convert.ToDouble(Session["TotalCFT"])) / (22 * 7 * TaurusSop), 3) : Math.Round(Convert.ToDouble(Session["TotalCFT"]) / 1078, 3);

            SaSop = txt_32ftsaSop.Text == "" ? 0 : Convert.ToInt32(txt_32ftsaSop.Text);
            double vol32ftsaTrucksReq = SaSop != 0 ? Math.Round((Convert.ToDouble(Session["TotalCFT"])) / (32 * 8 * SaSop), 3) : Math.Round(Convert.ToDouble(Session["TotalCFT"]) / 2048, 3);

            MaSop = txt_32ftmaSop.Text == "" ? 0 : Convert.ToInt32(txt_32ftmaSop.Text);
            double vol32ftmaTrucksReq = MaSop != 0 ? Math.Round((Convert.ToDouble(Session["TotalCFT"])) / (32 * 8 * MaSop), 3) : Math.Round(Convert.ToDouble(Session["TotalCFT"]) / 2048, 3);


            dr = dt.NewRow();
            dr[0] = "Trucks required";
            //dr[1] = FTLAnalysisTotal.ToString ();
            dr[1] = volFtlTrucksReq;
            dr[2] = volTaurusTrucksReq;
            dr[3] =vol32ftsaTrucksReq;
            dr[4] = vol32ftmaTrucksReq;

            dt.Rows.Add(dr);

            

            dr = dt.NewRow();
            dr[0] = "Total cost";
            txt_FTL.Text = txt_FTL.Text == "" ? "0" : txt_FTL.Text;
            dr[1] = Math.Round(volFtlTrucksReq * Convert.ToDouble(txt_FTL.Text), 2);
            txt_Taurus.Text = txt_Taurus.Text == "" ? "0" : txt_Taurus.Text;
            dr[2] = Math.Round(volTaurusTrucksReq * Convert.ToDouble(txt_Taurus.Text), 2);
            txt_32ftsa.Text = txt_32ftsa.Text == "" ? "0" : txt_32ftsa.Text;
            dr[3] = Math.Round(vol32ftsaTrucksReq * Convert.ToDouble(txt_32ftsa.Text), 2);
            txt_32ftma.Text = txt_32ftma.Text == "" ? "0" : txt_32ftma.Text;
            dr[4] = Math.Round(vol32ftsaTrucksReq * Convert.ToDouble(txt_32ftma.Text), 2);

            dt.Rows.Add(dr);

            // 3rd row
            dr = dt.NewRow();
            dr[0] = "Maximum weight";
            dr[1] = 9000 +" "+ "(KGS)";
            dr[2] = 15000 + " " + "(KGS)";
            dr[3] = 7000 + " " + "(KGS)";
            dr[4] = 15000 + " " + "(KGS)";

            dt.Rows.Add(dr);

            // 4th row

            dr = dt.NewRow();
            dr[0] = "Despatch weight";
            dr[1] = Session["MaxWeight"] + " " + "(KGS)";
            dr[2] = Session["MaxWeight"] + " " + "(KGS)";
            dr[3] = Session["MaxWeight"] + " " + "(KGS)";
            dr[4] = Session["MaxWeight"] + " " + "(KGS)";
            dt.Rows.Add(dr);
            //5th row

            double WeiFtlTrucksReq = Math.Round(Convert.ToDouble(Session["MaxWeight"]) / 9000, 3);
            double WeiTaurusTrucksReq = Math.Round(Convert.ToDouble(Session["MaxWeight"]) / 16000, 3);
            double Wei32ftsaTrucksReq = Math.Round(Convert.ToDouble(Session["MaxWeight"]) / 7000, 3);
            double Wei32ftmaTrucksReq = Math.Round(Convert.ToDouble(Session["MaxWeight"]) / 15000, 3);

            dr = dt.NewRow();
            dr[0] = "Trucks required";
            dr[1] = WeiFtlTrucksReq;
            dr[2] = WeiTaurusTrucksReq;
            dr[3] = Wei32ftsaTrucksReq;
            dr[4] = Wei32ftmaTrucksReq;
            dt.Rows.Add(dr);
            // 6th row 

            dr = dt.NewRow();
            dr[0] = "Total cost";
            dr[1] = Math.Round(WeiFtlTrucksReq * Convert.ToDouble(txt_FTL.Text), 2);
            dr[2] = Math.Round(WeiTaurusTrucksReq * Convert.ToDouble(txt_Taurus.Text), 2);
            dr[3] = Math.Round(Wei32ftsaTrucksReq * Convert.ToDouble(txt_32ftsa.Text), 2);
            dr[4] = Math.Round(Wei32ftmaTrucksReq * Convert.ToDouble(txt_32ftma.Text), 2);

            dt.Rows.Add(dr);
            // 6th row 

            grd_Summary.DataSource = dt;
            grd_Summary.DataBind();

        }

        catch (Exception ex)
        {
        }
    }


    protected void btn_TrucksSummary_Click(object sender, EventArgs e)
    {
        try
        {
            for (int i = 0; i < grd_WeightAnalysis.Rows.Count; i++)
            {
                TextBox MaxWeight = (TextBox)grd_WeightAnalysis.Rows[i].FindControl("txt_TotalWeight");
                TextBox NoofCartons = (TextBox)grd_WeightAnalysis.Rows[i].FindControl("txt_Lotsize");

                Label Traveldate = (Label)grd_WeightAnalysis.Rows[i].FindControl("lbl_TravelDate");

                DropDownList ddlTruck = (DropDownList)grd_WeightAnalysis.Rows[i].FindControl("ddl_Truck");

                FTLDesWei += ddlTruck.SelectedItem.Text == "FTL" ? Convert.ToDouble(MaxWeight.Text) : 0;
                TaurusDesWei += ddlTruck.SelectedItem.Text == "Taurus" ? Convert.ToDouble(MaxWeight.Text) : 0;
                SaDesWei += ddlTruck.SelectedItem.Text == "32ftsa" ? Convert.ToDouble(MaxWeight.Text) : 0;
                MaDesWei += ddlTruck.SelectedItem.Text == "32ftma" ? Convert.ToDouble(MaxWeight.Text) : 0;
                TravelDate = Traveldate.Text;

                NoOfFTLCartons += ddlTruck.SelectedItem.Text == "FTL" ? Convert.ToDouble(NoofCartons.Text) : 0;
                NoOfTaurusCartons += ddlTruck.SelectedItem.Text == "Taurus" ? Convert.ToDouble(NoofCartons.Text) : 0;
                NoOfSaCartons += ddlTruck.SelectedItem.Text == "32ftsa" ? Convert.ToDouble(NoofCartons.Text) : 0;
                NoOfMaCartons += ddlTruck.SelectedItem.Text == "32ftma" ? Convert.ToDouble(NoofCartons.Text) : 0;

            }

            //despatch weight
            lbl_FtlWeight.Text = FTLDesWei.ToString();
            lbl_TaurusWeight.Text = TaurusDesWei.ToString();
            lbl_32saWeight.Text = SaDesWei.ToString();
            lbl_32maWeight.Text = MaDesWei.ToString();

            lbl_FTLNoofCartons.Text = NoOfFTLCartons.ToString();
            lbl_TaurusNoofCartons.Text = NoOfTaurusCartons.ToString();
            lbl_SaNoofCartons.Text = NoOfSaCartons.ToString();
            lbl_MaNoofCartons.Text = NoOfMaCartons.ToString();

            FTLNoOFTrucks = Math.Round((FTLDesWei / 9000), 2);
            TaurusNoOFTrucks = Math.Round((TaurusDesWei / 15000), 2);
            SaNoOFTrucks = Math.Round((SaDesWei / 7000), 2);
            MaNoOFTrucks = Math.Round((MaDesWei / 15000), 2);

            //noof trucks

            lbl_FtlTrucksReq.Text = FTLNoOFTrucks.ToString();
            lbl_TaurusTrucksReq.Text = TaurusNoOFTrucks.ToString();
            lbl_32saTrucksReq.Text = SaNoOFTrucks.ToString();
            lbl_32maTrucksReq.Text = MaNoOFTrucks.ToString();

            FtlCost = txt_FtlCost.Text == "" ? 0 : Convert.ToDouble(txt_FtlCost.Text);
            TaurusCost = txt_TaurusCost.Text == "" ? 0 : Convert.ToDouble(txt_TaurusCost.Text);
            SaCost = txt_SaCost.Text == "" ? 0 : Convert.ToDouble(txt_SaCost.Text);
            MaCost = txt_MaCost.Text == "" ? 0 : Convert.ToDouble(txt_MaCost.Text);

            lbl_FtlTotCost.Text = Math.Round((FTLNoOFTrucks * FtlCost), 2).ToString();
            lbl_TaurusTotCost.Text = Math.Round((TaurusNoOFTrucks * TaurusCost), 2).ToString();
            lbl_SaTotCost.Text = Math.Round((SaNoOFTrucks * SaCost), 2).ToString();
            lbl_MaTotCost.Text = Math.Round((MaNoOFTrucks * MaCost), 2).ToString();

            lbl_PlanID.Text = ddl_PlanNo.SelectedItem.Text;
            lbl_FroLoc.Text = ddl_FromLoc.SelectedItem.Text;
            lbl_ToLoc.Text = ddl_ToLoc.SelectedItem.Text;
            lbl_Traveldate.Text = TravelDate;
            pnl_OptSummary.Visible = true ;


            lbl_FTLCostPerCarton.Text = Math.Round((Convert.ToDouble(lbl_FtlTotCost.Text) / NoOfFTLCartons), 2).ToString();
            lbl_TaurusCostPerCarton.Text = Math.Round((Convert.ToDouble(lbl_TaurusTotCost.Text) / NoOfTaurusCartons), 2).ToString();
            lbl_SaCostPerCarton.Text = Math.Round((Convert.ToDouble(lbl_SaTotCost.Text) / NoOfSaCartons), 2).ToString();
            lbl_MaCostPerCarton.Text = Math.Round((Convert.ToDouble(lbl_MaTotCost.Text) / NoOfMaCartons), 2).ToString();

            lbl_FTLCostPerton.Text = Math.Round((Convert.ToDouble(lbl_FtlTotCost.Text) / FTLDesWei), 2).ToString();
            lbl_TaurusCostPerton.Text = Math.Round((Convert.ToDouble(lbl_TaurusTotCost.Text) / TaurusDesWei), 2).ToString();
            lbl_SaCostPerton.Text = Math.Round((Convert.ToDouble(lbl_SaTotCost.Text) / SaDesWei), 2).ToString();
            lbl_MaCostPerton.Text = Math.Round((Convert.ToDouble(lbl_MaTotCost.Text) / MaDesWei), 2).ToString();

        }
        catch (Exception ex)
        {

        }
    }
    protected void btn_GtnOptimization_Click(object sender, EventArgs e)
    {
        Response.Redirect("OptDispatchPlan.aspx");
    }
}