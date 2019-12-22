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

public partial class BiddingStatus : System.Web.UI.Page
{
    string obj_Authenticated;
    PlaceHolder maPlaceHolder;
    UserControl obj_Tabs;
    UserControl obj_LoginCtrl;
    UserControl obj_WelcomCtrl;
    UserControl obj_Navi;
    UserControl obj_Navihome;
    DataTable dt;
    DataTable dt_Bid = new DataTable();
    BizConnectClient obj_Class = new BizConnectClient();
    double TotalTrucks, TotalValue, TotalPreBidValue, TotalDecremental,TotalDiff,TotalPercent;
    protected void Page_Load(object sender, EventArgs e)
    {
if(!IsPostBack )
{
     ChkAuthentication();
    Bind();
     //BindSummary();
    BindRouteWiseLevelStatus();
     Bind_BiddingDetails();
}
    }

    public void BindRouteWiseLevelStatus()
    {

        DataTable dt_Level = new DataTable();
        dt_Level = BindRouteWiseLevelStatus(111);
        GridRoutewiseLevel.DataSource = dt_Level;
        GridRoutewiseLevel.DataBind();
    }
    public DataTable BindRouteWiseLevelStatus(int UserID)
    {
        DataTable dt = new DataTable();

        string connStr = ConfigurationManager.ConnectionStrings["BizCon"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            using (SqlCommand comm = new SqlCommand("SELECT * FROM (select  FromLocation,ToLocation ,TruckType ,negotiablecost  from aarmjunction .dbo.scmJunction_PostReply pr inner join aarmjunction .dbo.scmJunction_PostAd p on p.PostID=pr.PostID inner join  aarmjunction .dbo.scmJunction_TruckType tt on tt.TruckTypeID=p.TruckTypeID  where p. PostByID=" + UserID + ") as s PIVOT(min(negotiablecost)FOR TruckType IN ([Taurus],[32Ft Container Multi Axle],[Trailer],[19FT LPT]))AS p", conn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);

                ada.SelectCommand.CommandType = CommandType.Text;
                try
                {
                    conn.Open();

                    ada.Fill(dt);
                }
                catch (Exception err)
                {

                }
                finally
                {
                    conn.Close();
                }

            }

        }
        return dt;
       
    }
      public void BindSummary()
    {
        try
        {
            dt = new DataTable();
            DataRow dr ;
            DataSet ds = new DataSet();
        ds = obj_Class.ClientSummaryView();

          //  dt.Columns.Add("Transporter");
          //  dt.Columns.Add("FinalValue");
          //  dt.Columns.Add("Level");
          //  dt.Columns.Add("Difference");
          // dt.Columns.Add("OriginalValue");
           
          //    dt.Columns.Add("Decrement");
          //     dt.Columns.Add("Percentage");
          //     dt.Columns.Add("CurrentStatus");
          //      dt.Columns.Add("ReplyByID");
          //       dt.Columns.Add("Log");
          //for (int i = 0; i <=  ds.Tables[0].Rows.Count - 1 ; i++)
          //{
          //int j=i;
          //      dr = dt.NewRow();
          //      dr[0]=ds.Tables[0].Rows[i].ItemArray[1].ToString();
          //      dr[1]=ds.Tables[0].Rows[i].ItemArray[0].ToString();
          //      dr[2]="Level-"+(j+1);
          //      dr[3]= Convert.ToDouble(Decimal.Parse(ds.Tables[0].Rows[i].ItemArray[0].ToString()))-Convert.ToDouble(Decimal.Parse(ds.Tables[0].Rows[0].ItemArray[0].ToString()));
          //       dr[4]=ds.Tables[0].Rows[i].ItemArray[2].ToString();
          //        dr[5]=ds.Tables[0].Rows[i].ItemArray[3].ToString();
          //         dr[6]=ds.Tables[0].Rows[i].ItemArray[4].ToString();
          //          dr[7]=ds.Tables[0].Rows[i].ItemArray[5].ToString();
          //          dr[8]=ds.Tables[0].Rows[i].ItemArray[6].ToString();
          //          dr[9]=ds.Tables[0].Rows[i].ItemArray[7].ToString();
          //      dt.Rows.Add(dr);
//}
            //GridViewSummary.DataSource = dt;
            GridViewSummary.DataSource = ds;
            GridViewSummary.DataBind();
        }
        catch (Exception ex)
        {
        }
    }

    
    
    
public void Bind()
{
    try
    {
        dt = new DataTable();
        dt = obj_Class.Get_BiddingStatus(0, "111");
        GridQuotingLevel.DataSource = dt;
        GridQuotingLevel.DataBind();
    }
    catch (Exception ex)
    {
    }
}

public void Bind_BiddingDetails()
{
    try
    {
        dt_Bid = obj_Class.Get_DisplayBiddingDetails();
        grd_Display.DataSource = dt_Bid;
        grd_Display.DataBind();
        lbltotaltransporter.Text = grd_Display.Rows.Count.ToString();
    }
    catch (Exception ex)
    {
    }
}


protected void GridQuotingLevel_RowDataBound(Object sender, GridViewRowEventArgs e)
{
    if (e.Row.RowType == DataControlRowType.DataRow)
    {
        Label LblPostID = (Label)e.Row.FindControl("lblPostID");
        dt = new DataTable();
        dt = obj_Class.Get_Level(Convert.ToInt32(LblPostID.Text));
        for (int i = 0; i <= dt.Rows.Count - 1; i++)
        {
            e.Row.Cells[6 + i].Text = dt.Rows[i][1].ToString() + "-" + dt.Rows[i][0].ToString();
          e.Row.Cells[6].ForeColor =System.Drawing.Color.Green;
            e.Row.Cells[7].ForeColor = System.Drawing.Color.Navy;
            e.Row.Cells[8].ForeColor = System.Drawing.Color.Black ;
            e.Row.Cells[9].ForeColor = System.Drawing.Color.Red;
            
        }

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
    protected void Butsearch_Click(object sender, EventArgs e)
    {
        try
        {
            dt = new DataTable();
            dt = obj_Class.Get_BiddingStatus(1, txtfrom.Text );
            GridQuotingLevel.DataSource = dt;
            GridQuotingLevel.DataBind();
        }
        catch (Exception ex)
        {
        }
    }
    
        protected void Button1_Click(object sender, EventArgs e)
    {
        ExportGrid(GridQuotingLevel, "QuotingLevel.xls");

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

    protected void GridViewSummary_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            TotalTrucks += Convert.ToDouble(e.Row.Cells[2].Text);
            TotalValue +=Convert.ToDouble(e.Row.Cells[3].Text);
            TotalPreBidValue+=Convert.ToDouble(e.Row.Cells[4].Text);
            TotalDecremental +=Convert.ToDouble(e.Row.Cells[5].Text);
            TotalDiff+=Convert.ToDouble(e.Row.Cells[6].Text);
           // TotalPercent += Convert.ToDouble((TotalDiff / TotalValue) * 100);
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[1].Text = "Total";
            e.Row.Cells[1].ForeColor = System.Drawing.Color.Red;
            e.Row.Cells[1].Font.Bold = true;
            e.Row.Cells[2].Text = TotalTrucks.ToString ();
            e.Row.Cells[2].ForeColor = System.Drawing.Color.Green;
            e.Row.Cells[2].Font.Bold = true;
            e.Row.Cells[3].Text = TotalValue.ToString();
            e.Row.Cells[3].ForeColor = System.Drawing.Color.Green;
            e.Row.Cells[3].Font.Bold = true;
            e.Row.Cells[4].Text = TotalPreBidValue.ToString();
            e.Row.Cells[4].ForeColor = System.Drawing.Color.Green;
            e.Row.Cells[4].Font.Bold = true;
            e.Row.Cells[5].Text = TotalDecremental.ToString();
            e.Row.Cells[5].ForeColor = System.Drawing.Color.Green;
            e.Row.Cells[5].Font.Bold = true;
            e.Row.Cells[6].Text = TotalDiff.ToString();
            e.Row.Cells[6].ForeColor = System.Drawing.Color.Green;
            e.Row.Cells[6].Font.Bold = true;
            e.Row.Cells[7].Text = Math.Round(((TotalDiff/TotalValue)*100),3).ToString();
            e.Row.Cells[7].ForeColor = System.Drawing.Color.Green;
            e.Row.Cells[7].Font.Bold = true;
        }
    }
}
