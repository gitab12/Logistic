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

public partial class LevelwiseReport : System.Web.UI.Page
{
	int incre = 1;
    string obj_Authenticated;
    PlaceHolder maPlaceHolder;
    UserControl obj_Tabs;
    UserControl obj_LoginCtrl;
    UserControl obj_WelcomCtrl;
    UserControl obj_Navi;
    UserControl obj_Navihome;
    string FromLoc1, ToLoc1, TruckType1;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadDetails();
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

    public void LoadDetails()
    {
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add("FromLocation");
        dt.Columns.Add("ToLocation");
        dt.Columns.Add("TruckType");
        dt.Columns.Add("QuoteDate");
        dt.Columns.Add("QuotePrice");
        dt.Columns.Add("Transporter");
        dt.Columns.Add("level");
        
        DataSet ds = new DataSet();
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["BizCon"].ConnectionString);
        conn.Open();
        string qry = "select distinct Fromlocation,Tolocation,TruckType ,convert(varchar(20),replydateTimeStamp ,106) as QuoteDate ,negotiablecost as QuotePrice,CompanyName as Transporter ,ROW_NUMBER ()over (partition by FromLocation,Tolocation,TruckType order by FromLocation,Tolocation,TruckType,negotiablecost )as level from aarmjunction .dbo. scmJunction_PostAd PA inner join aarmjunction .dbo.scmJunction_TruckType TT on PA.TruckTypeID=TT.TruckTypeID inner join aarmjunction .dbo. scmJunction_PostReply PR on pa.PostID=pr.PostID inner join aarmjunction .dbo.scmjunction_registration SR on sr.rid=pr.ReplyByID order by FromLocation,Tolocation,TruckType ,negotiablecost ,level";

        SqlCommand cmd = new SqlCommand(qry, conn);
        cmd.ExecuteNonQuery();
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        ds = new DataSet();
        adp.Fill(ds);

        for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
        {
            dr = dt.NewRow();

            dr[0] = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            dr[1] = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            dr[2] = ds.Tables[0].Rows[i].ItemArray[2].ToString();
            dr[3] = ds.Tables[0].Rows[i].ItemArray[3].ToString();
            dr[4] = ds.Tables[0].Rows[i].ItemArray[4].ToString();
            dr[5] = ds.Tables[0].Rows[i].ItemArray[5].ToString();
            dr[6] = "Level-"+ds.Tables[0].Rows[i].ItemArray[6].ToString();
            dt.Rows.Add(dr);
        }

        grd_LevelWiseReport.DataSource = dt;
        grd_LevelWiseReport.DataBind();
    }

    protected void ButExcel_Click(object sender, EventArgs e)
    {
        grd_LevelWiseReport.Columns[8].Visible = true;

        ExportGrid(grd_LevelWiseReport, "Rpt_route_price.xls");
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

}