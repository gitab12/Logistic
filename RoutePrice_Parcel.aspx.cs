using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;

public partial class RoutePrice_Parcel : System.Web.UI.Page
{
    BizConnectClass obj_class = new BizConnectClass();
    BizConnectLogisticsPlan obj = new BizConnectLogisticsPlan();
    string obj_Authenticated;
    PlaceHolder maPlaceHolder;
    UserControl obj_Tabs;
    UserControl obj_LoginCtrl;
    UserControl obj_WelcomCtrl;
    UserControl obj_Navi;
    UserControl obj_Navihome;
    int obj_res = 0;
    string Logid = "0";
    string client_id = "";
    BizCon_DB_ConnectionString con=new BizCon_DB_ConnectionString();
    Aumjunction_DB_ConnectionString conaarms = new Aumjunction_DB_ConnectionString();
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (Session["UserID"] != string.Empty && Convert.ToInt32(Session["UserID"].ToString()) > 0)
        {
            if (IsPostBack != true)
            {
                client_id = Convert.ToString(Session["ClientID"]);//Request.QueryString["ClientID"].ToString();
                txtsearch.Text = Session["FromDate"].ToString();
                if (Request.QueryString["ID"] != "Inv")
                {
                    //  BindData();
                    SearchBindData();
                    ChkAuthentication();
                }
                else
                {
                    BindData();
                    ChkAuthentication();
                    string tid = Request.QueryString["transid"].ToString();
                    string from = Request.QueryString["from"].ToString();
                    string to = Request.QueryString["to"].ToString();
                    string trucktype = Request.QueryString["trucktype"].ToString();
                    string capacity = Request.QueryString["capacity"].ToString();
                    string price = Request.QueryString["price"].ToString();
                    string clientid = Request.QueryString["ClientID"].ToString();
                    Response.Redirect("PostReBid.aspx?TID=" + tid.ToString() + "&from=" + from.ToString() + " &to=" + to.ToString() + "&trucktype=" + trucktype.ToString() + "&capacity=" + capacity.ToString() + " &price=" + price.ToString() + " &clientid=" + clientid.ToString() + "");
                    //OpenNewWindow(tid, from, to, trucktype, capacity, price, clientid);
                }
            }

        }

        else
        {
            Response.Redirect("Index.html");
        }
    }

    private void SearchBindData()
    {
        try
        {
            int j = 0; int mode = 0; string Time = "00:00 AM";
            DataTable dt = new DataTable();
            DataRow dr;
            dt.Columns.Add("Planid");
            dt.Columns.Add("Planno");
            dt.Columns.Add("From");
            dt.Columns.Add("To");
            dt.Columns.Add("Trucktype");
            dt.Columns.Add("Encl.type");
            dt.Columns.Add("Capacity");
            dt.Columns.Add("Routeprice");
            dt.Columns.Add("Transid");
            dt.Columns.Add("TravelDate");
            // dt.Columns.Add("bidlink");
            dt.Columns.Add("QuoteDate");
            dt.Columns.Add("EarlierQuote");
            dt.Columns.Add("Remarks");
            if (ddl_Hours.SelectedIndex > 0)
            {
                mode = 1;
                Time = ddl_Hours.SelectedValue + ":" + ddl_Minutes.SelectedValue + " " + ddl_Ampm.SelectedValue;
            }
            else
            {
                mode = 0;

            }
            //DataSet ds = new DataSet();
            //ds = obj.Get_Bizconnect_RouteSearch(Convert.ToInt32(Session["UserID"].ToString()), txtsearch.Text,mode,Time);
            string userid = Session["UserID"].ToString();
            string search = txtsearch.Text;
            string _mode = mode.ToString();
            string _time = Time.ToString();

            string[] args = { "@userid", "@traveldate", "@mode", "@time" };
            string[] argsval = { userid, search, _mode, _time };
            DataSet _ds = new DataSet();
            _ds = con.Sql_GetData("Bizconnect_RoutePrice_Parcel", args, argsval);
            if (_ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i <= _ds.Tables[0].Rows.Count - 1; i++)
                {
                    dr = dt.NewRow();
                    if (Logid == _ds.Tables[0].Rows[i].ItemArray[0].ToString())
                    {
                        j = j + 1;


                        dr[0] = _ds.Tables[0].Rows[i].ItemArray[0].ToString();
                        dr[1] = _ds.Tables[0].Rows[i].ItemArray[1].ToString();
                        dr[2] = _ds.Tables[0].Rows[i].ItemArray[2].ToString();
                        dr[3] = _ds.Tables[0].Rows[i].ItemArray[3].ToString();
                        dr[4] = _ds.Tables[0].Rows[i].ItemArray[4].ToString();
                        dr[5] = _ds.Tables[0].Rows[i].ItemArray[5].ToString();
                        dr[6] = _ds.Tables[0].Rows[i].ItemArray[6].ToString();
                        dr[7] = _ds.Tables[0].Rows[i].ItemArray[7].ToString();
                        dr[8] = _ds.Tables[0].Rows[i].ItemArray[8].ToString() + "L" + j.ToString();
                        dr[9] = _ds.Tables[0].Rows[i].ItemArray[14].ToString();
                        dr[10] = _ds.Tables[0].Rows[i].ItemArray[13].ToString();
                        dr[11] = _ds.Tables[0].Rows[i].ItemArray[15].ToString();
                        dr[12] = _ds.Tables[0].Rows[i].ItemArray[16].ToString();
                        // dr[10] = "Routeprice.aspx?ID=Inv&transid=" + ds.Tables[0].Rows[i].ItemArray[8] + " &from=" + ds.Tables[0].Rows[i].ItemArray[2] + "&to=" + ds.Tables[0].Rows[i].ItemArray[3] + "&trucktype=" + ds.Tables[0].Rows[i].ItemArray[4] + "&capacity=" + ds.Tables[0].Rows[i].ItemArray[6] + "&price=" + ds.Tables[0].Rows[i].ItemArray[7] + "&ClientID=" + ds.Tables[0].Rows[i].ItemArray[9];
                        dt.Rows.Add(dr);
                    }
                    else
                    {
                        Logid = _ds.Tables[0].Rows[i].ItemArray[0].ToString();
                        j = 0;
                        if (i > 0)
                        {
                            i = i - 1;
                        }
                        else
                        {
                            i = -1;
                        }

                    }
                    GridRouteprice.DataSource = dt;
                    GridRouteprice.DataBind();

                }
            }
            else
            {
                try
                {
                    String sDate = DateTime.Now.ToString();
                    DateTime datevalue = (Convert.ToDateTime(sDate.ToString()));

                    String dy = datevalue.Day.ToString();
                    String mn = datevalue.Month.ToString();
                    String yy = datevalue.Year.ToString();


                    string[] Argsget = { "@userid", "@dy", "@mn", "@yy" };
                    string[] Argsgetval = { userid, dy, mn, yy };
                    DataSet _dsget = new DataSet();
                    _dsget = conaarms.Sql_GetData("SP_Get_Logistic_Plan", Argsget, Argsgetval);
                    if (_dsget.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow myreader in _dsget.Tables[0].Rows)
                        {
                            string[] _argsin = { "@ClientID", "@UserID", "@LogisticsPlanNo", "@JunctionAdID", "@FromLocation", "@ToLocation", "@TravelDateTimeStamp", "@ProductName", "@LastDateTimeStampForReceivingQuote", "@LastDateTimeStampForClosingDeal", "@LastDateTimeStampToModifyPlan", "@AdditionalComments", "@City" };
                            string[] _argsvalin = { client_id, userid, Convert.ToString(myreader["AdID"]), Convert.ToString(myreader["AdID"]), Convert.ToString(myreader["FromLocation"]), Convert.ToString(myreader["ToLocation"]), Convert.ToString(myreader["RequirementDate"]), Convert.ToString(myreader["CapacityUnit"]), Convert.ToString(myreader["RequirementDate"]), Convert.ToString(myreader["RequirementDate"]), Convert.ToString(myreader["RequirementDate"]), Convert.ToString(myreader["AdditionalComments"]), Convert.ToString(myreader["City"]) };
                            int resd = con.Sql_ExecuteNonQuery("SP_Insert_Logistic_Plan_Details", _argsin, _argsvalin);
                            if (resd > 0)
                            {
                                string[] argsa = { "@userid", "@traveldate", "@mode", "@time" };
                                string[] argsvala = { userid, search, _mode, _time };
                                DataSet _dsa = new DataSet();
                                _dsa = con.Sql_GetData("Bizconnect_RoutePrice_Parcel", argsa, argsvala);
                                if (_dsa.Tables[0].Rows.Count > 0)
                                {
                                    for (int i = 0; i <= _dsa.Tables[0].Rows.Count - 1; i++)
                                    {
                                        dr = dt.NewRow();
                                        if (Logid == _dsa.Tables[0].Rows[i].ItemArray[0].ToString())
                                        {
                                            j = j + 1;


                                            dr[0] = _dsa.Tables[0].Rows[i].ItemArray[0].ToString();
                                            dr[1] = _dsa.Tables[0].Rows[i].ItemArray[1].ToString();
                                            dr[2] = _dsa.Tables[0].Rows[i].ItemArray[2].ToString();
                                            dr[3] = _dsa.Tables[0].Rows[i].ItemArray[3].ToString();
                                            dr[4] = _dsa.Tables[0].Rows[i].ItemArray[4].ToString();
                                            dr[5] = _dsa.Tables[0].Rows[i].ItemArray[5].ToString();
                                            dr[6] = _dsa.Tables[0].Rows[i].ItemArray[6].ToString();
                                            dr[7] = _dsa.Tables[0].Rows[i].ItemArray[7].ToString();
                                            dr[8] = _dsa.Tables[0].Rows[i].ItemArray[8].ToString() + "L" + j.ToString();
                                            dr[9] = _dsa.Tables[0].Rows[i].ItemArray[14].ToString();
                                            dr[10] = _dsa.Tables[0].Rows[i].ItemArray[13].ToString();
                                            dr[11] = _dsa.Tables[0].Rows[i].ItemArray[15].ToString();
                                            dr[12] = _dsa.Tables[0].Rows[i].ItemArray[16].ToString();
                                            // dr[10] = "Routeprice.aspx?ID=Inv&transid=" + ds.Tables[0].Rows[i].ItemArray[8] + " &from=" + ds.Tables[0].Rows[i].ItemArray[2] + "&to=" + ds.Tables[0].Rows[i].ItemArray[3] + "&trucktype=" + ds.Tables[0].Rows[i].ItemArray[4] + "&capacity=" + ds.Tables[0].Rows[i].ItemArray[6] + "&price=" + ds.Tables[0].Rows[i].ItemArray[7] + "&ClientID=" + ds.Tables[0].Rows[i].ItemArray[9];
                                            dt.Rows.Add(dr);
                                        }
                                        else
                                        {
                                            Logid = _dsa.Tables[0].Rows[i].ItemArray[0].ToString();
                                            j = 0;
                                            if (i > 0)
                                            {
                                                i = i - 1;
                                            }
                                            else
                                            {
                                                i = -1;
                                            }

                                        }
                                        GridRouteprice.DataSource = dt;
                                        GridRouteprice.DataBind();

                                    }
                                }
                            }
                        }
                    }
                    else
                    {

                    }
                }
                catch(Exception ex)
                {

                }
            }

            
        }
        catch(Exception ex)
        {

        }
        
    }

    private void BindData()
    {

        {
            int j = 0;
            DataTable dt = new DataTable();
            DataRow dr;
            dt.Columns.Add("Planid");
            dt.Columns.Add("Planno");
            dt.Columns.Add("From");
            dt.Columns.Add("To");
            dt.Columns.Add("Trucktype");
            dt.Columns.Add("Encl.type");
            dt.Columns.Add("Capacity");
            dt.Columns.Add("Routeprice");
            dt.Columns.Add("Transid");
            dt.Columns.Add("TravelDate");
            // dt.Columns.Add("bidlink");
            dt.Columns.Add("QuoteDate");
            dt.Columns.Add("Remarks");
            string userid = Session["UserID"].ToString();
            string[] args_ = { "@obj_UserID" };
            string[] _argsval = { userid };
            DataSet ds = new DataSet();
            ds = con.Sql_GetData("Get_Bizconnect_RoutePrice", args_, _argsval);
            //ds = obj_class.Get_Bizconnect_RoutePrice(Convert.ToInt32(Session["UserID"].ToString()));
            for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                dr = dt.NewRow();
                if (Logid.ToString() == ds.Tables[0].Rows[i].ItemArray[1].ToString())
                {
                    j = j + 1;


                    dr[0] = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                    dr[1] = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                    dr[2] = ds.Tables[0].Rows[i].ItemArray[2].ToString();
                    dr[3] = ds.Tables[0].Rows[i].ItemArray[3].ToString();
                    dr[4] = ds.Tables[0].Rows[i].ItemArray[4].ToString();
                    dr[5] = ds.Tables[0].Rows[i].ItemArray[5].ToString();
                    dr[6] = ds.Tables[0].Rows[i].ItemArray[6].ToString();
                    dr[7] = ds.Tables[0].Rows[i].ItemArray[7].ToString();
                    dr[8] = ds.Tables[0].Rows[i].ItemArray[8].ToString() + "L" + j.ToString();
                    dr[9] = ds.Tables[0].Rows[i].ItemArray[14].ToString();
                    dr[10] = ds.Tables[0].Rows[i].ItemArray[13].ToString();
                    // dr[10] = "Routeprice.aspx?ID=Inv&transid=" + ds.Tables[0].Rows[i].ItemArray[8] + " &from=" + ds.Tables[0].Rows[i].ItemArray[2] + "&to=" + ds.Tables[0].Rows[i].ItemArray[3] + "&trucktype=" + ds.Tables[0].Rows[i].ItemArray[4] + "&capacity=" + ds.Tables[0].Rows[i].ItemArray[6] + "&price=" + ds.Tables[0].Rows[i].ItemArray[7] + "&ClientID=" + ds.Tables[0].Rows[i].ItemArray[9];
                    dr[11] = ds.Tables[0].Rows[i].ItemArray[15].ToString();
                    dt.Rows.Add(dr);
                }
                else
                {
                    Logid = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                    j = 0;
                    if (i > 0)
                    {
                        i = i - 1;
                    }
                    else
                    {
                        i = -1;
                    }

                }

            }
            GridRouteprice.DataSource = dt;
            GridRouteprice.DataBind();
        }
    }

    private void ChkAuthentication()
    {

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
    protected void btnsearch_Click(object sender, EventArgs e)
    {
        
        { 
            lblmsg.Text="";
            try
            {
                if (txtsearch.Text == "")
                {
                    BindData();
                }
                else
                {
                    SearchBindData();
                }
            }
            catch (Exception ex)
            {
                lblmsg.Text = ex.Message;
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
      ExportGrid(GridRouteprice, "RoutePrice.xls");
    }

    private void ExportGrid(GridView oGrid,string exportFile)
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
    protected void btn_DownloadtoPDF_Click(object sender, EventArgs e)
    {
        
    {
        try
        {
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=RoutePrice.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            GridRouteprice.AllowPaging = false;
            //GridRouteprice.DataBind();
            if (txtsearch.Text == "")
            {
                BindData();
            }
            else
            {
                SearchBindData();
            }
            GridRouteprice.RenderControl(hw);
            GridRouteprice.HeaderRow.Style.Add("width", "15%");
            GridRouteprice.HeaderRow.Style.Add("font-size", "10px");
            GridRouteprice.Style.Add("text-decoration", "none");
            GridRouteprice.Style.Add("font-family", "Arial, Helvetica, sans-serif;");
            GridRouteprice.Style.Add("font-size", "8px");
            StringReader sr = new StringReader(sw.ToString());
            Document pdfDoc = new Document(PageSize.A2, 7f, 7f, 7f, 0f);
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            htmlparser.Parse(sr);
            pdfDoc.Close();
            Response.Write(pdfDoc);
            Response.End();
        }
        catch (Exception ex)
        {

        }
    }
    }
}