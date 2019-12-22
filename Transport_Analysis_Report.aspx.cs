using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Transport_Analysis_Report : System.Web.UI.Page
{
    BizCon_DB_ConnectionString con = new BizCon_DB_ConnectionString();
    string obj_Authenticated;

    PlaceHolder maPlaceHolder;
    UserControl obj_Tabs;
    UserControl obj_LoginCtrl;
    UserControl obj_WelcomCtrl;
    UserControl obj_Navi;
    UserControl obj_Navihome;
    TransproterAnalistMODEL TransproterAnalistMODELdetails = new TransproterAnalistMODEL();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            List<TransproterAnalistMODEL> TransproterAnalistMODELlist = new List<TransproterAnalistMODEL>();
            int month = System.DateTime.Now.Month;
            int year = System.DateTime.Now.Year;
            ddl_month.SelectedIndex = month;
            monthwise.Visible = true;
            daywise.Visible = false;
            gridview_details.DataSource = null;
            gridview_details.DataBind();
            gridview_details.Columns.Clear();
            gridview_details.EmptyDataText = "No records where found.";
            ChkAuthentication();
            // gridview_details.EmptyDataText = "No Data Found";
            DataTable dt = (DataTable)gridview_details.DataSource;
            if (dt != null)
                dt.Clear();
            if (gridview_details.Rows.Count == 0)
            {
                Label1.Text = "Record is empty";
            }

            //gridview_details.Rows.Clear();
            // gridview_details.DataSource = ds;
            //gridview_details.DataSource = TransproterAnalistMODELlist;
            gridview_details.DataBind();
            gridview_details.Columns.Clear();
            gridview_details.EmptyDataText = "Record not found";
            GridBind();
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

    protected void rdb_monthwise_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            monthwise.Visible = true;
            daywise.Visible = false;
            gridview.Visible = false;
        }
        catch (Exception ex)
        {

        }
    }
    protected void rdb_daywise_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            monthwise.Visible = false;
            daywise.Visible = true;
            gridview.Visible = false;
        }
        catch (Exception ex)
        {

        }
    }
    protected void btn_search1_Click(object sender, EventArgs e)
    {
        try
        {
            if (rdb_monthwise.Checked)
            {

                if (ddl_month.SelectedIndex == 0 && ddl_year.SelectedIndex == 0)
                {
                    Page.ClientScript.RegisterStartupScript(GetType(), "MyKey1", "alert('Please Select fields');", true);
                }

                else
                {
                    GridBind();
                }
            }
            else
            {
                GridBind();
            }

        }
        catch (Exception ex)
        {

        }
    }

    private void GridBind()
    {
        try
        {
            List<TransproterAnalistMODEL> TransproterAnalistMODELlist = new List<TransproterAnalistMODEL>();
            string Userid = Session["UserID"].ToString();
            string month = ddl_month.SelectedValue;
            string year = ddl_year.SelectedValue;

            string[] argsgetc = { "@UserID" };
            string[] argsvalc = { Userid };
            DataSet dsc = new DataSet();
            dsc = con.Sql_GetData("SP_Get_Client_Details_By_User", argsgetc, argsvalc);
            if (dsc.Tables[0].Rows.Count > 0)
            {
                string clientidd = dsc.Tables[0].Rows[0]["ClientID"].ToString();
                string[] args = { "@userid", "@month", "@year", "@ClientID" };
                string[] argsval = { Userid, month, year, clientidd };
                DataSet ds = new DataSet();
                ds = con.Sql_GetData("Bizconnect_Get_MonthwiseDetails_new11_changRakesh", args, argsval);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        TransproterAnalistMODEL TransproterAnalistMODELdetails = new TransproterAnalistMODEL();


                        string myydate = dr["ReceivedDate"].ToString();
                        string deliverdate = dr["DeliveryDate"].ToString();
                        string PlacedDateTime = dr["LoadingDate"].ToString();
                        string DispatchTime = dr["Dispatcheddatetime"].ToString();
                        string unloadingdate = dr["UnloadingDate"].ToString();

                        //  string ExpectedDeliveredDateTime = dr["DeliveryDate"].ToString();

                        // string id = dr["Participant"].ToString();
                        TransproterAnalistMODELdetails.ReceivedDate = Convert.ToDateTime(myydate);
                        //TransproterAnalistMODELdetails.ReceivedDate = dr["ReceivedDate"].ToString();
                        TransproterAnalistMODELdetails.rid = dr["rid"].ToString();
                        TransproterAnalistMODELdetails.Transporter = dr["Transporter"].ToString();
                        TransproterAnalistMODELdetails.NoofADPosted = dr["NoofADPosted"].ToString();
                        TransproterAnalistMODELdetails.Participant = dr["Participant"].ToString();
                        TransproterAnalistMODELdetails.Acceptance = dr["Acceptance"].ToString();
                        TransproterAnalistMODELdetails.L1 = dr["L1"].ToString();
                        TransproterAnalistMODELdetails.L2 = dr["L2"].ToString();
                        TransproterAnalistMODELdetails.L3 = dr["L3"].ToString();
                        TransproterAnalistMODELdetails.L4 = dr["L4"].ToString();
                        TransproterAnalistMODELdetails.L5 = dr["L5"].ToString();
                        TransproterAnalistMODELdetails.Placement = dr["Placement"].ToString();
                        TransproterAnalistMODELdetails.LoadingDate = dr["LoadingDate"].ToString();
                        TransproterAnalistMODELdetails.Dispatcheddatetime = dr["Dispatcheddatetime"].ToString();
                        TransproterAnalistMODELdetails.UnloadingDate = dr["UnloadingDate"].ToString();
                        TransproterAnalistMODELdetails.DeliveryDate = dr["DeliveryDate"].ToString();





                        DateTime startTime = Convert.ToDateTime(PlacedDateTime);
                        DateTime endTime = Convert.ToDateTime(DispatchTime);

                        DateTime startTime1 = Convert.ToDateTime(deliverdate);
                        DateTime endTime1 = Convert.ToDateTime(myydate);


                        TimeSpan span = endTime.Subtract(startTime);
                        TimeSpan span1 = endTime1.Subtract(startTime1);
                        Console.WriteLine("Time Difference (minutes): " + span.TotalMinutes);
                        Console.WriteLine("Delay Date" + span1.TotalMinutes);
                        // string timedifference = string.Format("{0:00}:{1:00}", " Time Difference (hours):", (int)Math.Round(span.TotalHours) , " Time Difference (Minutes):" , (int)Math.Round(span.TotalMinutes) , " Time Difference (second):" , (int)Math.Round(span.TotalSeconds));

                        string timedifference = "Time Difference (Hours): " + (int)Math.Round(span.TotalHours) + " Time Difference (Minutes):" + (int)Math.Round(span.TotalMinutes) + " Time Difference (second):" + (int)Math.Round(span.TotalSeconds);
                        string timedifference1 = "Time Difference (Hours): " + (int)Math.Round(span1.TotalHours) + " Time Difference (Minutes):" + (int)Math.Round(span1.TotalMinutes) + " Time Difference (second):" + (int)Math.Round(span1.TotalSeconds);
                        // string timedifference1 = string.Format("{0:00}:{1:00}", " Time Difference (hours):", (int)Math.Round(span.TotalHours)
                        TransproterAnalistMODELdetails.differenceredate = timedifference;
                        //TransproterAnalistMODELdetails.differenceredate = timedifference1;
                        TransproterAnalistMODELdetails.differenceredate1 = timedifference1;


                        if ((int)Math.Round(span.TotalHours) > 2 && (int)Math.Round(span.TotalHours) <= 4)


                            if ((int)Math.Round(span.TotalHours) <= 2)
                            {
                                TransproterAnalistMODELdetails.delaylesstwo = (int)Math.Round(span.TotalHours);
                            }

                            else if ((int)Math.Round(span.TotalHours) <= 2 && (int)Math.Round(span.TotalHours) >= 4)
                            {
                                TransproterAnalistMODELdetails.delaylesstwo = (int)Math.Round(span.TotalHours);
                            }
                            else if ((int)Math.Round(span.TotalHours) <= 4 && (int)Math.Round(span.TotalHours) >= 6)
                            {
                                TransproterAnalistMODELdetails.delaylessfour = (int)Math.Round(span.TotalHours);
                            }
                            else if ((int)Math.Round(span.TotalHours) <= 6 && (int)Math.Round(span.TotalHours) >= 8)
                            {
                                TransproterAnalistMODELdetails.delaylesseight = (int)Math.Round(span.TotalHours);
                            }

                            else if ((int)Math.Round(span.TotalHours) <= 8 && (int)Math.Round(span.TotalHours) >= 12)
                            {
                                TransproterAnalistMODELdetails.delaylesstwel = (int)Math.Round(span.TotalHours);
                            }
                            else if ((int)Math.Round(span.TotalHours) <= 12 && (int)Math.Round(span.TotalHours) >= 24)
                            {
                                TransproterAnalistMODELdetails.delaylesstwe4 = (int)Math.Round(span.TotalHours);
                            }
                            else
                            {
                            }


                        if ((int)Math.Round(span1.TotalHours) < 24)
                        {
                            TransproterAnalistMODELdetails.delayless24 = (int)Math.Round(span1.TotalHours);
                        }
                        else if ((int)Math.Round(span1.TotalHours) > 24 && (int)Math.Round(span1.TotalHours) < 48)
                        {

                            TransproterAnalistMODELdetails.delayless248 = (int)Math.Round(span1.TotalHours);
                        }

                        else if ((int)Math.Round(span1.TotalHours) > 48)
                        {

                            TransproterAnalistMODELdetails.delaygreater = (int)Math.Round(span1.TotalHours); //0;//(int)Math.Round(span.TotalHours);
                        }
                        else
                        {
                            TransproterAnalistMODELdetails.delaygreater = 0;//(int)Math.Round(span1.TotalHours);
                        }


                        TransproterAnalistMODELlist.Add(TransproterAnalistMODELdetails);
                        gridview_details.DataSource = TransproterAnalistMODELlist;
                        gridview_details.DataBind();


                    }
                }
            }           

        }

        catch (Exception ex)
        {


        }
    }

    protected void btn_search_Click(object sender, EventArgs e)
    {
        try
        {
            string[] DMY = txtFrom.Text.Split('/');
            int year, month, day;

            int.TryParse(DMY[0], out month);
            int.TryParse(DMY[1], out day);
            int.TryParse(DMY[2], out year);
            List<TransproterAnalistMODEL> TransproterAnalistMODELlist = new List<TransproterAnalistMODEL>();
            string Userid = Session["UserID"].ToString();
            day = Convert.ToInt32(day);
            month = Convert.ToInt32(month);
            year = Convert.ToInt32(year);

            string[] argsgetc = { "@UserID" };
            string[] argsvalc = { Userid };
            DataSet dsc = new DataSet();
            dsc = con.Sql_GetData("SP_Get_Client_Details_By_User", argsgetc, argsvalc);
            if (dsc.Tables[0].Rows.Count > 0)
            {
                string clientidd = dsc.Tables[0].Rows[0]["ClientID"].ToString();
                string[] args = { "@userid", "@day", "@month", "@year", "@ClientID" };
                string[] argsval = { Userid, day.ToString(), month.ToString(), year.ToString(), clientidd };
                DataSet ds = new DataSet();
                ds = con.Sql_GetData("Bizconnect_Get_MonthwiseDetails_new11_changRakesh", args, argsval);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        TransproterAnalistMODEL TransproterAnalistMODELdetails = new TransproterAnalistMODEL();


                        string myydate = dr["ReceivedDate"].ToString();
                        string deliverdate = dr["DeliveryDate"].ToString();
                        string PlacedDateTime = dr["LoadingDate"].ToString();
                        string DispatchTime = dr["Dispatcheddatetime"].ToString();
                        string unloadingdate = dr["UnloadingDate"].ToString();

                        //  string ExpectedDeliveredDateTime = dr["DeliveryDate"].ToString();

                        // string id = dr["Participant"].ToString();
                        TransproterAnalistMODELdetails.ReceivedDate = Convert.ToDateTime(myydate);
                        //TransproterAnalistMODELdetails.ReceivedDate = dr["ReceivedDate"].ToString();
                        TransproterAnalistMODELdetails.rid = dr["rid"].ToString();
                        TransproterAnalistMODELdetails.Transporter = dr["Transporter"].ToString();
                        TransproterAnalistMODELdetails.NoofADPosted = dr["NoofADPosted"].ToString();
                        TransproterAnalistMODELdetails.Participant = dr["Participant"].ToString();
                        TransproterAnalistMODELdetails.Acceptance = dr["Acceptance"].ToString();
                        TransproterAnalistMODELdetails.L1 = dr["L1"].ToString();
                        TransproterAnalistMODELdetails.L2 = dr["L2"].ToString();
                        TransproterAnalistMODELdetails.L3 = dr["L3"].ToString();
                        TransproterAnalistMODELdetails.L4 = dr["L4"].ToString();
                        TransproterAnalistMODELdetails.L5 = dr["L5"].ToString();
                        TransproterAnalistMODELdetails.Placement = dr["Placement"].ToString();
                        TransproterAnalistMODELdetails.LoadingDate = dr["LoadingDate"].ToString();
                        TransproterAnalistMODELdetails.Dispatcheddatetime = dr["Dispatcheddatetime"].ToString();
                        TransproterAnalistMODELdetails.UnloadingDate = dr["UnloadingDate"].ToString();
                        TransproterAnalistMODELdetails.DeliveryDate = dr["DeliveryDate"].ToString();





                        DateTime startTime = Convert.ToDateTime(PlacedDateTime);
                        DateTime endTime = Convert.ToDateTime(DispatchTime);

                        DateTime startTime1 = Convert.ToDateTime(deliverdate);
                        DateTime endTime1 = Convert.ToDateTime(myydate);


                        TimeSpan span = endTime.Subtract(startTime);
                        TimeSpan span1 = endTime1.Subtract(startTime1);
                        Console.WriteLine("Time Difference (minutes): " + span.TotalMinutes);
                        Console.WriteLine("Delay Date" + span1.TotalMinutes);
                        // string timedifference = string.Format("{0:00}:{1:00}", " Time Difference (hours):", (int)Math.Round(span.TotalHours) , " Time Difference (Minutes):" , (int)Math.Round(span.TotalMinutes) , " Time Difference (second):" , (int)Math.Round(span.TotalSeconds));

                        string timedifference = "Time Difference (Hours): " + (int)Math.Round(span.TotalHours) + " Time Difference (Minutes):" + (int)Math.Round(span.TotalMinutes) + " Time Difference (second):" + (int)Math.Round(span.TotalSeconds);
                        string timedifference1 = "Time Difference (Hours): " + (int)Math.Round(span1.TotalHours) + " Time Difference (Minutes):" + (int)Math.Round(span1.TotalMinutes) + " Time Difference (second):" + (int)Math.Round(span1.TotalSeconds);
                        // string timedifference1 = string.Format("{0:00}:{1:00}", " Time Difference (hours):", (int)Math.Round(span.TotalHours)
                        TransproterAnalistMODELdetails.differenceredate = timedifference;
                        //TransproterAnalistMODELdetails.differenceredate = timedifference1;
                        TransproterAnalistMODELdetails.differenceredate1 = timedifference1;


                        if ((int)Math.Round(span.TotalHours) > 2 && (int)Math.Round(span.TotalHours) <= 4)


                            if ((int)Math.Round(span.TotalHours) <= 2)
                            {
                                TransproterAnalistMODELdetails.delaylesstwo = (int)Math.Round(span.TotalHours);
                            }

                            else if ((int)Math.Round(span.TotalHours) <= 2 && (int)Math.Round(span.TotalHours) >= 4)
                            {
                                TransproterAnalistMODELdetails.delaylesstwo = (int)Math.Round(span.TotalHours);
                            }
                            else if ((int)Math.Round(span.TotalHours) <= 4 && (int)Math.Round(span.TotalHours) >= 6)
                            {
                                TransproterAnalistMODELdetails.delaylessfour = (int)Math.Round(span.TotalHours);
                            }
                            else if ((int)Math.Round(span.TotalHours) <= 6 && (int)Math.Round(span.TotalHours) >= 8)
                            {
                                TransproterAnalistMODELdetails.delaylesseight = (int)Math.Round(span.TotalHours);
                            }

                            else if ((int)Math.Round(span.TotalHours) <= 8 && (int)Math.Round(span.TotalHours) >= 12)
                            {
                                TransproterAnalistMODELdetails.delaylesstwel = (int)Math.Round(span.TotalHours);
                            }
                            else if ((int)Math.Round(span.TotalHours) <= 12 && (int)Math.Round(span.TotalHours) >= 24)
                            {
                                TransproterAnalistMODELdetails.delaylesstwe4 = (int)Math.Round(span.TotalHours);
                            }
                            else
                            {
                            }


                        if ((int)Math.Round(span1.TotalHours) < 24)
                        {
                            TransproterAnalistMODELdetails.delayless24 = (int)Math.Round(span1.TotalHours);
                        }
                        else if ((int)Math.Round(span1.TotalHours) > 24 && (int)Math.Round(span1.TotalHours) < 48)
                        {

                            TransproterAnalistMODELdetails.delayless248 = (int)Math.Round(span1.TotalHours);
                        }

                        else if ((int)Math.Round(span1.TotalHours) > 48)
                        {

                            TransproterAnalistMODELdetails.delaygreater = (int)Math.Round(span1.TotalHours); //0;//(int)Math.Round(span.TotalHours);
                        }
                        else
                        {
                            TransproterAnalistMODELdetails.delaygreater = 0;//(int)Math.Round(span1.TotalHours);
                        }


                        TransproterAnalistMODELlist.Add(TransproterAnalistMODELdetails);
                        gridview_details.DataSource = TransproterAnalistMODELlist;
                        gridview_details.DataBind();


                    }
                }
            }            

        }

        catch (Exception ex)
        {


        }
    }


    protected void gridview_details_RowDataBound(object sender, GridViewRowEventArgs e)
    {


        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label id = (Label)e.Row.FindControl("lbl_rid");
            Label transporter = (Label)e.Row.FindControl("lbl_transporter");
            Label postad = (Label)e.Row.FindControl("lbl_post");
            Label participant = (Label)e.Row.FindControl("lbl_participant");
            Label acceptance = (Label)e.Row.FindControl("lbl_acceptance");
            Label replyid1 = (Label)e.Row.FindControl("lbl_Replyid1");
            Label replyid2 = (Label)e.Row.FindControl("lbl_Replyid2");
            Label replyid3 = (Label)e.Row.FindControl("lbl_Replyid3");
            Label replyid4 = (Label)e.Row.FindControl("lbl_Replyid4");
            Label replyid5 = (Label)e.Row.FindControl("lbl_Replyid5");
            Label deliverdate = (Label)e.Row.FindControl("lbl_deliverdate");
            Label receiveddate = (Label)e.Row.FindControl("lbl_Receiveddate");
            Label diffdate = (Label)e.Row.FindControl("lbl_difference");
            Label diffdateless = (Label)e.Row.FindControl("lbl_delaylessthen2hours");
            Label diffdateless2 = (Label)e.Row.FindControl("lbl_delaylessthen4hours");
            Label diffdateless4 = (Label)e.Row.FindControl("lbl_delaylessthen6hours");
            Label diffdateless8 = (Label)e.Row.FindControl("lbl_delaylessthen8hours");
            Label diffdateless12 = (Label)e.Row.FindControl("lbl_delaylessthen12hours");
            Label diffdateless24 = (Label)e.Row.FindControl("lbl_delaylessthen24hours");
            Label diff1 = (Label)e.Row.FindControl("lbl_difference1");
            Label deliverlessthen24hours = (Label)e.Row.FindControl("lbl_deliverlessthen24hours");
            Label deliverlessthen48hours = (Label)e.Row.FindControl("lbl_deliverlessthen48hours");
            Label delivergrtthen48hours = (Label)e.Row.FindControl("lbl_delivergrtthen48hours");


            string acceptanceid = acceptance.Text;
            if (acceptanceid == "")
            {
                acceptance.Text = "0";
            }
            else
            {
                Double Percent_acceptance = (Convert.ToDouble(acceptance.Text) / Convert.ToDouble(participant.Text)) * 100;
                string Percent2 = Math.Round(Percent_acceptance, 2).ToString() + "%";
                Label acceptance1 = (Label)e.Row.FindControl("lbl_acceptance1");
                acceptance1.Text = Percent2.ToString();
            }
            Label placement = (Label)e.Row.FindControl("lbl_placement");
            string placementid = placement.Text;
            if (placementid == "")
            {
                placement.Text = "0";
            }
            else
            {
                Double Percent_placement = (Convert.ToDouble(placement.Text) / Convert.ToDouble(acceptance.Text)) * 100;
                string Percent3 = Math.Round(Percent_placement, 2).ToString() + "%";
                Label placement1 = (Label)e.Row.FindControl("lbl_placement1");
                placement1.Text = Percent3.ToString();
            }

            Double Percent_participant = (Convert.ToDouble(participant.Text) / Convert.ToDouble(postad.Text)) * 100;
            string Percent = Math.Round(Percent_participant, 2).ToString() + "%";

            Label participant1 = (Label)e.Row.FindControl("lbl_participant1");
            participant1.Text = Percent.ToString();



        }
    }





    protected void btn_download1_Click(object sender, EventArgs e)
    {
        ExportGrid(gridview_details, "Transporteranalytics Report");

    }

    private void ExportGrid(GridView oGrid, string exportFile)
    {



       

        HttpContext.Current.Response.Clear();
        HttpContext.Current.Response.Buffer = true;
        HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";
        HttpContext.Current.Response.AppendHeader("content-disposition", "attachment;filename=TransporterAnalysis_Report.xls");
        
        HttpContext.Current.Response.Charset = "";

        
        System.IO.StringWriter oStringWriter = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter oHtmlTextWriter = new System.Web.UI.HtmlTextWriter(oStringWriter);

      


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



    private void ShowNoResultFound(DataSet ds, GridView gridview_details)
    {
        
        gridview_details.DataSource = ds;
        gridview_details.DataBind();
        // Get the total number of columns in the GridView to know what the Column Span should be
        int columnsCount = gridview_details.Columns.Count;
        gridview_details.Rows[0].Cells.Clear();// clear all the cells in the row
        gridview_details.Rows[0].Cells.Add(new TableCell()); //add a new blank cell
        gridview_details.Rows[0].Cells[0].ColumnSpan = columnsCount; //set the column span to the new added cell

        //You can set the styles here
        gridview_details.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
        gridview_details.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
        gridview_details.Rows[0].Cells[0].Font.Bold = true;
        //set No Results found to the new added cell
        gridview_details.Rows[0].Cells[0].Text = "NO RESULT FOUND!";
    }
    
}