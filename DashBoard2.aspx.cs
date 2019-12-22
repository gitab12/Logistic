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
using System.Data.SqlClient;


public partial class DashBoard2 : System.Web.UI.Page
{
    string obj_Authenticated;
    PlaceHolder maPlaceHolder;
    PlaceHolder maPlaceHolder2;
    UserControl obj_Tabs;
    UserControl obj_LoginCtrl;
    UserControl obj_WelcomCtrl;
    UserControl obj_Navi;
    UserControl obj_Navihome;
    ContentPlaceHolder contp;
    decimal total = 0;
    int VehicleTot = 0;
    Double TonsTotal = 0;
    Double CostperTon = 0;
    string qry;
    Double Percent_CnConfirm;
    Double Percent_CnNotConfirm;
    Double Percent_NeedApp;
    Double Percent_CnCancel;
    Double Percent_Amend;
    Double Percent_Placed;
    Double Percent_LoadOntime;
    Double Percent_Delayed;


    string Percent;
    string Percent2;
    string Percent3;
    string Percent4;
    string Percent5;

    string Per_placed;
    string per_Loadontime;
    string Per_Delayer;

    DataSet ds_TotalBill = new DataSet();
    DataTable dt_BillSubmit = new DataTable();
    DataTable dt_BillValidated = new DataTable();
    DataTable dt_BillDiscrepancy = new DataTable();

    DataTable dt_Project = new DataTable();
    DataTable dt_Indent = new DataTable();
    DataTable dt_CollectionNote = new DataTable();
    DataTable dt_Vehplacement = new DataTable();


    DataSet ds, ds1, Vehicle, BillSubmission;
    ProjectBased obj_class = new ProjectBased();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["UserID"] != string.Empty && Convert.ToInt32(Session["UserID"].ToString()) > 0)
            {
                if (!IsPostBack)
                {

                    ChkAuthentication();
                    // PrebidDetails();
                    DateTime dtt = new DateTime();
                    dtt = DateTime.Now.Date;
                    txtFrom.Text = dtt.ToString("dd/MMM/yyyy");
                    Session["FromDate"] = txtFrom.Text;
                    LoadDashboard();
                    Session["pjtno"] = "-Select-";
                    GetPostOperation();
                    LoadProjects();
                    loadIndent();
                    ddl_Indent.Visible = true;
                    lblIndent.Visible = true;
                }
            }
            else
            {
                Response.Redirect("Index.html");
            }
        }
        catch (Exception ex)
        {
            //Response.Redirect("Index.html");
        }
    }

    public void LoadProjects()
    {
        dt_Project = obj_class.Bizconnect_Get_ThermaxProjects(Convert.ToInt32(Session["ClientID"]));
        ddl_Projects.DataSource = dt_Project;
        ddl_Projects.DataTextField = "ProjectNo";
        ddl_Projects.DataValueField = "ProjectID";
        ddl_Projects.DataBind();
        ddl_Projects.Items.Insert(0, "--Select--");
    }

    public void loadIndent()
    {
        dt_Indent = obj_class.Bizconnect_Get_Indent(Convert.ToInt32(Session["UserID"]), Session["FromDate"].ToString());
        ddl_Indent.DataSource = dt_Indent;
        ddl_Indent.DataTextField = "NumofIndent";
        ddl_Indent.DataValueField = "GroupID";
        ddl_Indent.DataBind();
        ddl_Indent.Items.Insert(0, "--Select--");
    }


    public void LoadDashboard()
    {

        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["BizCon"].ConnectionString);
        conn.Open();
        Session["Operation"] = 1;

        qry = "select  ToLocation ,isnull (R.Quotes ,0)as Quotes,P.postid ,P.City,EarlierQuote,TodayL1Quote ,TodayL1Quote-EarlierQuote as Difference from aarmjunction.dbo.scmJunction_PostAd P   left join (select COUNT(distinct ReplyByID )as Quotes,PostID  from aarmjunction .dbo.scmJunction_PostReply   group by PostID  )R on R.PostID =P.PostID   left join (  select MIN(negotiablecost)as EarlierQuote ,Pa.city,TruckTypeID   from aarmjunction .dbo.scmJunction_PostReply PR     inner join  aarmjunction .dbo.scmJunction_PostAd PA on PA.PostID=PR.PostID       where  pa.PostByID ='" + Session["UserID"].ToString() + "'  and RequirementDate != '" + txtFrom.Text + "' and datediff(Day,ReplyDateTimeStamp,getdate()) <=30 group by pa.City,TruckTypeID  )LQ on LQ.City=p.City   and lq.TruckTypeID=p.TruckTypeID   left join (  select MIN(negotiablecost)as TodayL1Quote ,Pa.city,TruckTypeID,pa.postid  from aarmjunction .dbo.scmJunction_PostReply PR inner join  aarmjunction .dbo.scmJunction_PostAd PA on PA.PostID=PR.PostID  where  pa.PostByID ='" + Session["UserID"].ToString() + "'  and RequirementDate  = '" + txtFrom.Text + "'   group by pa.City,TruckTypeID ,pa.postid  )LQt on LQt.City=p.City  and lqt.TruckTypeID=p.TruckTypeID and p.PostID=lqt.PostID  where   RequirementDate  = '" + txtFrom.Text + "' and p.PostByID ='" + Session["UserId"].ToString() + "'  group by ToLocation,Quotes,P.PostID,P.city,EarlierQuote,TodayL1Quote";

        SqlCommand cmd = new SqlCommand(qry, conn);
        cmd.ExecuteNonQuery();
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        ds = new DataSet();
        adp.Fill(ds);

        GridSummary.DataSource = ds;
        GridSummary.DataBind();
    }




    public void LoadIndentDashboard()
    {

        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["BizCon"].ConnectionString);
        conn.Open();
        Session["Operation"] = 1;

        qry = "select  ToLocation ,isnull (R.Quotes ,0)as Quotes,P.postid ,P.City,EarlierQuote,TodayL1Quote ,TodayL1Quote-EarlierQuote as Difference from aarmjunction.dbo.scmJunction_PostAd P   left join (select COUNT(distinct ReplyByID )as Quotes,PostID  from aarmjunction .dbo.scmJunction_PostReply   group by PostID  )R on R.PostID =P.PostID   left join (  select MIN(negotiablecost)as EarlierQuote ,Pa.city,TruckTypeID   from aarmjunction .dbo.scmJunction_PostReply PR     inner join  aarmjunction .dbo.scmJunction_PostAd PA on PA.PostID=PR.PostID       where pa.GroupID = '" + Session["IndentNo"].ToString() + "' and   pa.PostByID ='" + Session["UserID"].ToString() + "'  and RequirementDate != '" + txtFrom.Text + "' and datediff(Day,ReplyDateTimeStamp,getdate()) <=30 group by pa.City,TruckTypeID  )LQ on LQ.City=p.City   and lq.TruckTypeID=p.TruckTypeID   left join (  select MIN(negotiablecost)as TodayL1Quote ,Pa.city,TruckTypeID,pa.postid  from aarmjunction .dbo.scmJunction_PostReply PR inner join  aarmjunction .dbo.scmJunction_PostAd PA on PA.PostID=PR.PostID  where  pa.GroupID = '" + Session["IndentNo"].ToString() + "' and  pa.PostByID ='" + Session["UserID"].ToString() + "'  and RequirementDate  = '" + txtFrom.Text + "'   group by pa.City,TruckTypeID ,pa.postid  )LQt on LQt.City=p.City  and lqt.TruckTypeID=p.TruckTypeID and p.PostID=lqt.PostID  where   RequirementDate  = '" + txtFrom.Text + "' and p.PostByID ='" + Session["UserId"].ToString() + "' and   p.GroupID = '" + Session["IndentNo"].ToString() + "'    group by ToLocation,Quotes,P.PostID,P.city,EarlierQuote,TodayL1Quote";

        SqlCommand cmd = new SqlCommand(qry, conn);
        cmd.ExecuteNonQuery();
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        ds = new DataSet();
        adp.Fill(ds);

        GridSummary.DataSource = ds;
        GridSummary.DataBind();
    }


    public void PrebidDetails()
    {
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["BizCon"].ConnectionString);
            conn.Open();
            qry = "Select count(*) from bizconnect_Logisticsplan where userid='" + Session["UserId"].ToString() + "'";
            SqlCommand cmd = new SqlCommand(qry, conn);
            cmd.ExecuteNonQuery();
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            ds = new DataSet();
            adp.Fill(ds);

            Lbladposted.Text = "No of ADs Posted:  " + ds.Tables[0].Rows[0].ItemArray[0].ToString();

            // qry = "select count(distinct(LogisticsPlanID))  from bizconnect.dbo.BizConnect_LogisticsPlan  LP  inner join aarmjunction.dbo.scmJunction_TruckType TT on LP.TruckTypeID  =TT.TruckTypeid inner join aarmjunction.dbo.scmJunction_EnclosureType ET on LP.EnclosureTypeID =ET.EnclosureTypeid left join (select Transporter_Name,Oneway_Price ,From_loc,To_loc ,Truck_type_ID,Enclosure_type,Capacity ,unit,Transporter_ID  from    bizconnect.dbo.Bizconnect_Route_Price RP inner join aarmjunction.dbo.scmJunction_TruckType TT on RP.Truck_type_ID   =TT.TruckTypeid inner join aarmjunction.dbo.scmJunction_EnclosureType ET on RP.Enclosure_type =ET.EnclosureTypeid)as routeplan on routeplan.From_loc=FromLocation and routeplan.To_loc=ToLocation and Truck_type_ID=Lp.TruckTypeID  and Enclosure_type=LP.EnclosureTypeID  and LP.TruckCapacity =routeplan.Capacity where LP.UserID=" + Session["UserId"].ToString() + "  and Oneway_Price>0 ";
            qry = "select distinct LogisticsPlanID,LogisticsPlanNo,FromLocation ,ToLocation,Trucktype,Enclosuretype,  convert(varchar(20),TruckCapacity)+unit as Capactiy,Oneway_Price,    Transporter_ID,  ClientID , LP.trucktypeid,lp.enclosuretypeid,Transporter_Name      from bizconnect.dbo.BizConnect_LogisticsPlan  LP inner join aarmjunction.dbo.scmJunction_TruckType TT on LP.TruckTypeID  =TT.TruckTypeid  inner join aarmjunction.dbo.scmJunction_EnclosureType ET on LP.EnclosureTypeID =ET.EnclosureTypeid left join (select Transporter_Name,Oneway_Price ,From_loc,To_loc ,Truck_type_ID,Enclosure_type,Capacity ,unit,Transporter_ID  from    bizconnect.dbo.Bizconnect_Route_Price RP inner join aarmjunction.dbo.scmJunction_TruckType TT on RP.Truck_type_ID   =TT.TruckTypeid  inner join aarmjunction.dbo.scmJunction_EnclosureType ET on RP.Enclosure_type =ET.EnclosureTypeid)as routeplan on routeplan.From_loc=FromLocation and routeplan.To_loc=ToLocation  and Truck_type_ID=Lp.TruckTypeID  and Enclosure_type=LP.EnclosureTypeID  and  LP.TruckCapacity =routeplan.Capacity where LP.UserID=  " + Session["UserId"].ToString() + "  and Oneway_Price>0 union   (select distinct PA.PostID as LogisticsPlanID ,AdID as LogisticsPlanNo,pa.FromLocation,pa.ToLocation,  TruckType,EnclosureType,pa.TruckCapacity as Capacity,PR.negotiablecost as Oneway_Price,ReplyByID as Transporter_ID ,ReplyByID ,  pa.TruckTypeID , Pa.EnclosureTypeID,'T1'as Transporter_Name   from aarmjunction.dbo.scmJunction_PostAd PA inner join aarmjunction.dbo.scmJunction_PostReply PR   on PA.PostID=PR.PostID      inner join aarmjunction.dbo.scmJunction_TruckType TT on pa.TruckTypeID  =TT.TruckTypeid  inner join aarmjunction.dbo.scmJunction_EnclosureType ET on pa.EnclosureTypeID =ET.EnclosureTypeid  inner join BizConnect_LogisticsPlan Lp on Lp.JunctionAdID=PA.AdID   and lp.FromLocation =pa.FromLocation and lp.ToLocation =pa.ToLocation  and PA.TruckTypeID =Lp.TruckTypeID  and pa.EnclosureTypeID =LP.EnclosureTypeID  where LP.UserID=  " + Session["UserId"].ToString() + "  )  order by FromLocation ,ToLocation,Capactiy,Oneway_Price  ";

            SqlCommand cmd1 = new SqlCommand(qry, conn);
            cmd.ExecuteNonQuery();
            SqlDataAdapter adp1 = new SqlDataAdapter(cmd1);
            ds = new DataSet();
            adp1.Fill(ds);

            lblQuotesReceived.Text = "No of Quotes Received:  " + ds.Tables[0].Rows.Count.ToString();


            //qry = "select MIN(ReBidPrice) from Bizconnect_ClientsReBid where UserID =" + Session["UserId"].ToString() + " ";
            //SqlCommand cmd2 = new SqlCommand(qry, conn);
            //cmd2.ExecuteNonQuery();
            //SqlDataAdapter adp2 = new SqlDataAdapter(cmd2);
            //ds = new DataSet();
            //adp2.Fill(ds);

            lblLowestQuote.Text = "Lowest Quote:  36000";//+ ds.Tables[0].Rows[0].ItemArray[0].ToString();

            //qry = " select (convert(int,RoutePrice) - convert(int,ReBidPrice ))*CONVERT (int,trucksreq)  from Bizconnect_ClientsReBid where UserID =" + Session["UserId"].ToString() + " ";
            //SqlCommand cmd3 = new SqlCommand(qry, conn);
            //cmd3.ExecuteNonQuery();
            //SqlDataAdapter adp3 = new SqlDataAdapter(cmd3);
            //ds = new DataSet();
            //adp3.Fill(ds);

            // lblsaving.Text = "Estimated Savings:  " + ds.Tables[0].Rows[0].ItemArray[0].ToString();

            qry = "select LP.LogisticsPlanID ,count(lp.LogisticsPlanID)as QuoteReceived,From_loc as 'From Location',To_loc as 'To Location',1 as'ADs Posted',MIN(Oneway_Price)as 'Lowest Price', Costpertruck as BidPrice,NoOfTrucks as 'Trucks Req.',(Costpertruck-MIN(Oneway_Price))*NoOfTrucks as Savings   from bizconnect.dbo.BizConnect_LogisticsPlan  LP  inner join aarmjunction.dbo.scmJunction_TruckType TT on LP.TruckTypeID  =TT.TruckTypeid  inner join aarmjunction.dbo.scmJunction_EnclosureType ET on LP.EnclosureTypeID =ET.EnclosureTypeid   left join (select Transporter_Name,Oneway_Price ,From_loc,To_loc ,Truck_type_ID,Enclosure_type,Capacity ,   unit,Transporter_ID  from    bizconnect.dbo.Bizconnect_Route_Price RP    inner join aarmjunction.dbo.scmJunction_TruckType TT on RP.Truck_type_ID  =TT.TruckTypeid    inner join aarmjunction.dbo.scmJunction_EnclosureType ET on RP.Enclosure_type =ET.EnclosureTypeid)as routeplan    on routeplan.From_loc=FromLocation and routeplan.To_loc=ToLocation and Truck_type_ID=Lp.TruckTypeID     and Enclosure_type=LP.EnclosureTypeID  and LP.TruckCapacity =routeplan.Capacity   where LP.UserID=" + Session["UserId"].ToString() + " and From_loc  is not null group by From_loc,To_loc ,LP.LogisticsPlanID,Costpertruck,NoOfTrucks      order by LogisticsPlanID ";
            SqlCommand cmd4 = new SqlCommand(qry, conn);
            cmd4.ExecuteNonQuery();
            SqlDataAdapter adp4 = new SqlDataAdapter(cmd4);

            ds1 = new DataSet();
            adp4.Fill(ds1);

            GridDashboard.DataSource = ds1;
            GridDashboard.DataBind();

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
        //  obj_Navihome.Visible = true;

    }
    public void SetVisualOFF()
    {
        obj_LoginCtrl.Visible = true;
        obj_WelcomCtrl.Visible = false;
        //obj_Navi.Visible = true;
        //  obj_Navihome.Visible = false;
    }

    protected void GridDashboard_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (Convert.ToInt32(e.Row.Cells[8].Text) < 0)
                {
                    e.Row.Cells[8].Text = "0";
                }
            }
        }
        catch (Exception ex)
        {
        }

    }

    protected void Butshow_Click(object sender, EventArgs e)
    {
        DateTime dtt = new DateTime();
        dtt = Convert.ToDateTime(txtFrom.Text);
        txtFrom.Text = dtt.ToString("dd/MMM/yyyy");
        Session["FromDate"] = txtFrom.Text;
        //if (Session["Operation"].ToString()== "1")
        //{

        //    LoadDashboard();
        //}
        //else
        //{
        //    GetPostOperation();
        //}
        if (radPreOperation.Checked)
        {
            LoadDashboard();
            Lbladposted.Visible = true;
            lblQuotesReceived.Visible = true;
            lblsaving.Visible = true;
            ddl_Indent.Visible = true;
            lblIndent.Visible = true ;
            lblHeading.Text = "Pre-Operation Dashboad";
        }
        else
        {
            GetPostOperation();
            Lbladposted.Visible = false;
            lblQuotesReceived.Visible = false;
            lblsaving.Visible = false;
            ddl_Indent.Visible = false;
            lblIndent.Visible = false;
            lblHeading.Text = "Post-Operation Dashboad";
        }
    }

    protected void ButPostOperation_Click(object sender, EventArgs e)
    {
        GridSummary.Visible = false;
        GridViewPostOperation.Visible = true;
        lbl_Project.Visible = true;
        ddl_Projects.Visible = true;
        GetPostOperation();
        Lbladposted.Visible = false;
        lblQuotesReceived.Visible = false;
        lblsaving.Visible = false;
        lblIndent.Visible = false;
        ddl_Indent.Visible = false;

    }
    public void GetPostOperation()
    {
        lblHeading.Text = "Post-Operation DashBoard";
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["BizCon"].ConnectionString);
        conn.Open();
        Session["Operation"] = 0;
        if (Session["ClientID"].ToString() == "1135")
        {
            // ds = new DataSet();
            //ds=obj_class.Bizconnet_ThermaxDashBoard();
            // GridViewPostOperation .DataSource = ds;
            //GridViewPostOperation.DataBind();
            //GridViewPostOperation.Visible = true ;
            // GridView.Visible=false;
            ds = new DataSet();
            Vehicle = new DataSet();
            BillSubmission = new DataSet();
            ds = obj_class.Bizconnet_ThermaxDashBoard1();
            Vehicle = obj_class.Bizconnet_ThermaxDashBoard2();
            BillSubmission = obj_class.Get_ThermaxBilldetails();
            GridViewPostOperation.DataSource = ds;
            GridViewPostOperation.DataBind();
            GridViewPostOperation.Visible = true;
            lbl_Project.Visible = true;
            ddl_Projects.Visible = true;
            GridView.Visible = false;
            grd_dashboard2.DataSource = Vehicle;
            grd_dashboard2.DataBind();
            grd_dashboard2.Visible = true;
            Panel1.Visible = true;
            grd_dashboard3.DataSource = BillSubmission;
            grd_dashboard3.DataBind();
            //grd_dashboard3.Visible = true;
            grd_dashboard4.DataSource = new[] 
    { 
        new { ID = 1, Name = "" },
    };
            grd_dashboard4.DataBind();
        }
        else
        {


            //qry = "select TA.ToLocation as Route,Count(td.AcceptanceID ) as VehiclePlaced ,bp.BasePrice , AR.DecidedPrice as AgreementPrice,sum(pd.TotalWeight ) as TotalTons,ROUND(AR.DecidedPrice*count(td.AcceptanceID)/sum(pd.TotalWeight ),0) as PerTonCost, round(round((bp.BasePrice -(AR.DecidedPrice*count(td.AcceptanceID)/sum(pd.TotalWeight ))),0)* sum(pd.TotalWeight ),0) as Savings from Bizconnect_AgreementRoutes AR inner join BizConnect_TripAssign TA on TA.AgreementRouteID=AR.AgreementRouteID   inner join bizconnect_TripAcceptanceDetails  TD on TD.TripAssignID =TA.TripAssignID   inner join Bizconnect_PreloadDetails PD on PD.AcceptanceID=td.AcceptanceID     inner join Bizconnect_ClientBasePrice BP on BP.ToLocation=TA.ToLocation and TD.ClientID=BP.ClientID where TD.ClientID="+ Session["ClientID"].ToString()+ " and TD.LoadedStatus in(0,1) group by TA.ToLocation,bp.BasePrice,AR.DecidedPrice ";

            //qry = "select lp.FromLocation ,lp.ToLocation ,Convert(varchar(20),TravelDateTimeStamp,106) as TravelDate ,tt.TruckType ,NoOfTrucks  as NoOfTrucks, case Assigned when 0 then 'Assigned/Not Confirmed'  when 1 then 'Confirmed' end  as Status,  case TD.LoadedStatus  when 0 then 'Not Loaded'  when 1 then 'Loaded'  end as Loadingstatus, case pd.ReceivedFlg  when 0 then 'Not Delivered'  when 1 then 'Delivered'  end as DeliveredStatus ,''as Billingstatus  from BizConnect_LogisticsPlan LP inner join Bizconnect .dbo.BizConnect_TruckTypeMaster TT on TT.TruckTypeID=lp.TruckTypeID    left join   (select Assigned ,FromLocation ,ToLocation,TruckType ,TravelDate,TripAssignID   from BizConnect_TripAssign   where UserID=" + Session["UserID"].ToString() + " and TravelDate='" + txtFrom.Text + "' group by Assigned ,FromLocation ,ToLocation,TruckType ,TravelDate,TripAssignID)TA on    TA.FromLocation=lp.FromLocation and ta.ToLocation =lp.ToLocation  and ta.TruckType =TT .TruckType     left join (select Tripassignid,LoadedStatus,AcceptanceID   from bizconnect_TripAcceptanceDetails where ClientID=" + Session["ClientID"].ToString() + ")TD on TA.TripAssignID=TD.TripAssignID left join	  (select receivedflg ,AcceptanceID  from Bizconnect_PreloadDetails) pd on pd.AcceptanceID =TD.AcceptanceID    where ClientID=" + Session["ClientID"].ToString() + " and TravelDateTimeStamp='" + txtFrom.Text + "' order by LogisticsPlanID";
            if (radpending.Checked)
            {
                qry = "select distinct lp.FromLocation ,lp.ToLocation ,Convert(varchar(20),TravelDateTimeStamp,106) as TravelDate ,tt.TruckType , '1' as  NoOfTrucks,case Assigned when 0 then 'Assigned/Not Confirmed'  when 1 then 'Confirmed' when 2 then 'Cancelled' else 'Not Assigned' end  as Status,case TD.LoadedStatus  when 0 then 'Not Loaded'  when 1 then 'Loaded'  end as Loadingstatus,case pd.ReceivedFlg  when 0 then 'Not Delivered'  when 1 then 'Delivered'  end as DeliveredStatus , ''as Billingstatus ,ta.TripAssignID ,LogisticsPlanID  from BizConnect_LogisticsPlan LP inner join Bizconnect .dbo.BizConnect_TruckTypeMaster TT on TT.TruckTypeID=lp.TruckTypeID    left join   (select Assigned ,TripAssignID,IndentID  from BizConnect_TripAssign     where UserID=" + Session["UserID"].ToString() + " and  Assigned=0 )TA on ta.IndentID =lp.LogisticsPlanID 	 left join (select Tripassignid,LoadedStatus,AcceptanceID  	  from bizconnect_TripAcceptanceDetails	  where ClientID=" + Session["ClientID"].ToString() + "    )TD on TA.TripAssignID=TD.TripAssignID 	  left join	  (select receivedflg ,AcceptanceID  from Bizconnect_PreloadDetails) pd on pd.AcceptanceID =TD.AcceptanceID     where ClientID=" + Session["ClientID"].ToString() + " and Assigned=0  order by LogisticsPlanID desc  ";
            }
            else
            {
                qry = "select distinct lp.FromLocation ,lp.ToLocation ,Convert(varchar(20),TravelDateTimeStamp,106) as TravelDate ,tt.TruckType ,  case Assigned when 0 then '1'  when 2 then '1' when 1 then '1'   else CONVERT (varchar(20), lp.NoOfTrucks)   end as NoOfTrucks, case Assigned when 0 then 'Assigned/Not Confirmed'   when 1 then 'Confirmed' when 2 then 'Cancelled'  end  as Status,case TD.LoadedStatus  when 0 then 'Not Loaded'  when 1 then 'Loaded'  end as Loadingstatus,case pd.ReceivedFlg  when 0 then 'Not Delivered'  when 1 then 'Delivered'  end as DeliveredStatus , ''as Billingstatus ,ta.TripAssignID ,LogisticsPlanID  from BizConnect_LogisticsPlan LP inner join Bizconnect .dbo.BizConnect_TruckTypeMaster TT on TT.TruckTypeID=lp.TruckTypeID    left join   (select Assigned ,TripAssignID,IndentID  from BizConnect_TripAssign     where UserID=" + Session["UserID"].ToString() + " and TravelDate='" + txtFrom.Text + "' )TA on ta.IndentID =lp.LogisticsPlanID 	 left join (select Tripassignid,LoadedStatus,AcceptanceID  	  from bizconnect_TripAcceptanceDetails	  where ClientID=" + Session["ClientID"].ToString() + "    )TD on TA.TripAssignID=TD.TripAssignID 	  left join	  (select receivedflg ,AcceptanceID  from Bizconnect_PreloadDetails) pd on pd.AcceptanceID =TD.AcceptanceID     where ClientID=" + Session["ClientID"].ToString() + " and TravelDateTimeStamp='" + txtFrom.Text + "'order by ToLocation  ";
            }
            SqlCommand cmd1 = new SqlCommand(qry, conn);
            cmd1.ExecuteNonQuery();
            SqlDataAdapter adp1 = new SqlDataAdapter(cmd1);
            ds = new DataSet();
            adp1.Fill(ds);
            GridView.DataSource = ds;
            GridView.DataBind();
            GridView.Visible = true;
            Panel1.Visible = false;
            lbl_Project.Visible = false;
            ddl_Projects.Visible = false;

        }
    }
    protected void ButPreOperation_Click(object sender, EventArgs e)
    {
        GridViewPostOperation.Visible = false;
        lbl_Project.Visible = false;
        ddl_Projects.Visible = false;
        GridSummary.Visible = true;
        lblHeading.Text = "Pre-Operation DashBoard";
        LoadDashboard();
        Lbladposted.Visible = true;
        lblQuotesReceived.Visible = true;
        lblsaving.Visible = true;


    }


    protected void GridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[9].Visible = false;
                e.Row.Cells[10].Visible = false;
            }
            else if (e.Row.RowType == DataControlRowType.DataRow)
            {

                e.Row.Cells[9].Visible = false;
                e.Row.Cells[10].Visible = false;
                total += Convert.ToInt32(e.Row.Cells[7].Text);
                VehicleTot += Convert.ToInt32(e.Row.Cells[2].Text);
                TonsTotal += Convert.ToDouble(e.Row.Cells[3].Text);
                CostperTon += Convert.ToDouble(e.Row.Cells[5].Text);
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[6].Text = "Total : ";
                e.Row.Cells[4].Text = "Total : ";
                e.Row.Cells[0].Text = "Total : ";
                e.Row.Cells[0].ForeColor = System.Drawing.Color.Red;
                e.Row.Cells[4].ForeColor = System.Drawing.Color.Red;
                e.Row.Cells[6].ForeColor = System.Drawing.Color.Red;
                e.Row.Cells[2].Text = VehicleTot.ToString();
                e.Row.Cells[3].Text = TonsTotal.ToString();
                e.Row.Cells[7].Text = total.ToString();
                e.Row.Cells[5].Text = CostperTon.ToString();
            }
        }
        catch (Exception ex)
        {
        }
    }
    protected void GridViewPostOperation_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[0].Text = "Collection Note (CN)";
            e.Row.Cells[0].BackColor = System.Drawing.Color.Khaki;

            HyperLink Cngenerated = (HyperLink)e.Row.FindControl("lnk_Cngenerated");
            HyperLink CnCofirm = (HyperLink)e.Row.FindControl("lnk_CnConfirmed");
            HyperLink CnnotConfirmed = (HyperLink)e.Row.FindControl("lnk_CnConfirm");
            HyperLink CnNeedApproval = (HyperLink)e.Row.FindControl("lnk_NeedApproval");
            HyperLink CnCancelled = (HyperLink)e.Row.FindControl("lnk_CnConfirmed1");
            HyperLink CnAmendment = (HyperLink)e.Row.FindControl("lnk_CnConfirmed2");

            int a = Convert.ToInt32(Cngenerated.Text);
            int b = Convert.ToInt32(CnCofirm.Text);

            Label CnCofirmPercent = (Label)e.Row.FindControl("lbl_CnConfirmPercent");
            Label CnnnotConfirmed = (Label)e.Row.FindControl("lbl_Cnnotconfirm");
            Label Cnneedapproval = (Label)e.Row.FindControl("lbl_CnNeedApproval");
            Label Cncancelled = (Label)e.Row.FindControl("lbl_CnCancelled");
            Label Cnamendment = (Label)e.Row.FindControl("lbl_CnAmendment");



            Percent_CnConfirm = (Convert.ToDouble(CnCofirm.Text) / Convert.ToDouble(Cngenerated.Text)) * 100;
            Percent_CnNotConfirm = (Convert.ToDouble(CnnotConfirmed.Text) / Convert.ToDouble(Cngenerated.Text)) * 100;
            Percent_NeedApp = (Convert.ToDouble(CnNeedApproval.Text) / Convert.ToDouble(Cngenerated.Text)) * 100;
            Percent_CnCancel = (Convert.ToDouble(CnCancelled.Text) / Convert.ToDouble(Cngenerated.Text)) * 100;
            Percent_Amend = (Convert.ToDouble(CnAmendment.Text) / Convert.ToDouble(Cngenerated.Text)) * 100;

            Percent = Math.Round(Percent_CnConfirm, 2).ToString() + "%";
            Percent2 = Math.Round(Percent_CnNotConfirm, 2).ToString() + "%";
            Percent3 = Math.Round(Percent_NeedApp, 2).ToString() + "%";
            Percent4 = Math.Round(Percent_CnCancel, 2).ToString() + "%";
            Percent5 = Math.Round(Percent_Amend, 2).ToString() + "%";

            CnCofirmPercent.Text = Percent.ToString();
            CnnnotConfirmed.Text = Percent2.ToString();
            Cnneedapproval.Text = Percent3.ToString();
            Cncancelled.Text = Percent4.ToString();
            Cnamendment.Text = Percent5.ToString();
        }
    }

    protected void grd_dashboard2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            try
            {
                e.Row.Cells[0].Text = "Placement & Loading";
                e.Row.Cells[0].BackColor = System.Drawing.Color.Khaki;

                HyperLink Vehplanned = (HyperLink)e.Row.FindControl("lnk_Vehicleplanned");
                HyperLink Vehplaced = (HyperLink)e.Row.FindControl("lnk_Vehicleplaced");
                HyperLink Loadontime = (HyperLink)e.Row.FindControl("lnk_VehicleLoadontime");
                HyperLink Delayed = (HyperLink)e.Row.FindControl("lnk_VehicleDelayed");

                Label vehplaced = (Label)e.Row.FindControl("lbl_VehPlaced");
                Label loadontime = (Label)e.Row.FindControl("lbl_VehLoadontime");
                Label delayed = (Label)e.Row.FindControl("lbl_VehDelayed");

                Percent_Placed = (Convert.ToDouble(Vehplaced.Text) / Convert.ToDouble(Vehplanned.Text)) * 100;
                Percent_LoadOntime = (Convert.ToDouble(Loadontime.Text) / Convert.ToDouble(Vehplanned.Text)) * 100;
                Percent_Delayed = (Convert.ToDouble(Delayed.Text) / Convert.ToDouble(Vehplanned.Text)) * 100;

                Per_placed = Math.Round(Percent_Placed, 2).ToString() + "%";
                per_Loadontime = Math.Round(Percent_LoadOntime, 2).ToString() + "%";
                Per_Delayer = Math.Round(Percent_Delayed, 2).ToString() + "%";

                vehplaced.Text = Per_placed.ToString();
                loadontime.Text = per_Loadontime.ToString();
                delayed.Text = Per_Delayer.ToString();
            }
            catch (Exception ex)
            {

            }
        }
    }


    protected void grd_dashboard3_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[0].Text = "Bills";
            e.Row.Cells[0].BackColor = System.Drawing.Color.Khaki;
        }
    }
    protected void grd_dashboard4_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[0].Text = "Performance Analysis";
            e.Row.Cells[0].BackColor = System.Drawing.Color.Khaki;
        }
    }


    protected void GridSummary_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {


                Label EarlierQuote = (Label)e.Row.FindControl("EarlierQuote");
                Label lblTodayQuote = (Label)e.Row.FindControl("lblTodayQuote");
                String Postid = DataBinder.Eval(e.Row.DataItem, "PostID").ToString();


                DataTable dt = new DataTable();
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["BizCon"].ConnectionString);
                conn.Open();

                string query1 = "select top 1 ToLocation, P.postid ,P.City,Quote,ReplyByID ,Transporter ,QuoteDate ,TruckType from aarmjunction.dbo.scmJunction_PostAd P inner join aarmjunction .dbo.scmJunction_TruckType tt on tt.TruckTypeID=p.TruckTypeID  left join ( select MIN(negotiablecost)as Quote ,Pa.city ,ReplyByID ,CONVERT(varchar(20),replydatetimestamp,106)as QuoteDate,TruckTypeID from aarmjunction .dbo.scmJunction_PostReply PR inner join aarmjunction .dbo.scmJunction_PostAd PA on PA.PostID=PR.PostID where AdID like '#GDJ%'and pa.PostByID ='" + Session["UserId"].ToString() + "' and RequirementDate != '" + txtFrom.Text + "' and datediff(Day,ReplyDateTimeStamp,getdate()) <=30  and City is not null group by pa.City,TruckTypeID ,ReplyByID ,replydatetimestamp )LQ on LQ.City=p.City and lq.TruckTypeID=p.TruckTypeID left join (select CompanyName as Transporter,rid from aarmjunction .dbo.Scmjunction_Registration SR)R on R.rid =ReplyByID where  AdID like '#GDJ%' and RequirementDate ='" + txtFrom.Text + "' and p.PostByID ='" + Session["UserId"].ToString() + "' and PostID='" + Postid.ToString() + "' group by ToLocation,P.PostID,P.city,Quote,ReplyByID ,Transporter,QuoteDate,TruckType order by Quote";
                SqlCommand sqlCmd1 = new SqlCommand(query1, conn);
                SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCmd1);
                sqlDa.Fill(dt);


                conn.Close();

                string tablestring = "";
                //dt is datatable object which holds DB results.


                foreach (DataRow dr in dt.Rows)
                {

                    tablestring += "Transporter : " + dr[5].ToString();
                    tablestring += " Quoted on : " + dr[6].ToString();
                    tablestring += "\nTruck : " + dr[7].ToString();


                }
                EarlierQuote.ToolTip = tablestring;

                //Todays Quote
                DataTable dt1 = new DataTable();
                SqlConnection conn1 = new SqlConnection(ConfigurationManager.ConnectionStrings["BizCon"].ConnectionString);
                conn1.Open();

                string query2 = "select top 1 PA.PostID as LogisticsPlanID ,AdID as LogisticsPlanNo,pa.FromLocation,pa.ToLocation,TruckType,EnclosureType,pa.TruckCapacity as Capacity,PR.negotiablecost as DecidedPrice,SR.CompanyName as TransporterName ,ReplyByID ,pa.TruckTypeID , Pa.EnclosureTypeID,'T1'as Transporter_Name ,Convert(varchar(20),PR.ReplyDateTimeStamp  ,106)as QuoteDate,PR.negotiabletruck as nooftrucks ,Email ,Convert(varchar(20),PA.RequirementDate,106)as TravelDate  from aarmjunction.dbo.scmJunction_PostAd PA inner join aarmjunction.dbo.scmJunction_PostReply PR on PA.PostID=PR.PostID inner join aarmjunction.dbo.scmJunction_TruckType TT on pa.TruckTypeID  =TT.TruckTypeid inner join aarmjunction.dbo.scmJunction_EnclosureType ET on pa.EnclosureTypeID =ET.EnclosureTypeid inner join aarmjunction .dbo.scmjunction_registration SR on SR.rid=PR.ReplyByID  where PA.PostID ='" + Postid.ToString() + "'  order by DecidedPrice asc";
                SqlCommand sqlCmd2 = new SqlCommand(query2, conn1);
                SqlDataAdapter sqlDa1 = new SqlDataAdapter(sqlCmd2);
                sqlDa1.Fill(dt1);


                conn1.Close();

                string tablestring1 = "";
                //dt is datatable object which holds DB results.


                foreach (DataRow dr in dt1.Rows)
                {

                    tablestring1 += "Transporter : " + dr[8].ToString();
                    tablestring1 += " Truck Type : " + dr[4].ToString();



                }
                lblTodayQuote.ToolTip = tablestring1;
            }
        }
        catch (Exception err)
        {

        }
    }

    protected void ddl_Projects_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_Projects.SelectedValue != "--Select--")
        {
            string ProjectNo, pjtno;

            ProjectNo = ddl_Projects.SelectedItem.Text;
            string[] splitProjectNo = ProjectNo.Split('/');
            pjtno = splitProjectNo[0];
            dt_CollectionNote = obj_class.Bizconnect_Search_ThermaxCollectNoteByProjectNo(pjtno);
            GridViewPostOperation.DataSource = dt_CollectionNote;
            GridViewPostOperation.DataBind();
            dt_Vehplacement = obj_class.Bizconnect_Search_ThermaxVehplacementbyProjectNo(pjtno);
            grd_dashboard2.DataSource = dt_Vehplacement;
            grd_dashboard2.DataBind();
            Session["pjtno"] = pjtno.ToString();
        }
        else
        {
            Session["pjtno"] = "-Select-";
            ds = obj_class.Bizconnet_ThermaxDashBoard1();
            Vehicle = obj_class.Bizconnet_ThermaxDashBoard2();
            GridViewPostOperation.DataSource = ds;
            GridViewPostOperation.DataBind();
            grd_dashboard2.DataSource = Vehicle;
            grd_dashboard2.DataBind();
        }
    }

    //ddl_Indent_SelectedIndexChanged
    protected void ddl_Indent_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_Indent.SelectedValue != "--Select--")
        {
           // string IndentNo;

            Session["IndentNo"] = ddl_Indent.SelectedItem.Value;
            //string[] splitProjectNo = ProjectNo.Split('/');
            //pjtno = splitProjectNo[0];
            //dt_CollectionNote = obj_class.Bizconnect_Search_ThermaxCollectNoteByProjectNo(pjtno);
            //GridViewPostOperation.DataSource = dt_CollectionNote;
            //GridViewPostOperation.DataBind();
            //dt_Vehplacement = obj_class.Bizconnect_Search_ThermaxVehplacementbyProjectNo(pjtno);
            //grd_dashboard2.DataSource = dt_Vehplacement;
            //grd_dashboard2.DataBind();
            //Session["pjtno"] = pjtno.ToString();

            LoadIndentDashboard();



        }
        else
        {
            //Session["pjtno"] = "-Select-";
            //ds = obj_class.Bizconnet_ThermaxDashBoard1();
            //Vehicle = obj_class.Bizconnet_ThermaxDashBoard2();
            //GridViewPostOperation.DataSource = ds;
            //GridViewPostOperation.DataBind();
            //grd_dashboard2.DataSource = Vehicle;
            //grd_dashboard2.DataBind();


            LoadDashboard();

        }
    }
}