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

public partial class AarmsTripplan : System.Web.UI.Page
{
    string obj_Authenticated;
    PlaceHolder maPlaceHolder;
    UserControl obj_Tabs;
    UserControl obj_LoginCtrl;
    UserControl obj_WelcomCtrl;
    UserControl obj_Navi;
    UserControl obj_Navihome;
    BizConnectClass obj_class = new BizConnectClass();
    string qry;
    string obj_userid;
    DataTable dt = new DataTable();
    DataSet ds = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
      if (Session["UserID"] != string.Empty && Convert.ToInt32(Session["UserID"].ToString()) > 0)
        {
        if (!IsPostBack)
        {
            ChkAuthentication();
            gridbind();
        }
        }
        
          else
        {
            Response.Redirect("Index.html");
        }
    }
    public void gridbind()
    {
        string traveldate = "";
        DataTable dt = new DataTable("ClientsTripplan");
        DataRow dr;
        dt.Columns.Add("client");
        dt.Columns.Add("source");
        dt.Columns.Add("designation");
        dt.Columns.Add("truckcapacity");
        dt.Columns.Add("traveltype");
        dt.Columns.Add("truckreq");
        dt.Columns.Add("budget");
        //Calling the Class
        ds = obj_class.GetClientTripplan();

        for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
        {

            if (traveldate != ds.Tables[0].Rows[i].ItemArray[0].ToString())
            {
                traveldate = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                dr = dt.NewRow();
                dr[0] = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                dt.Rows.Add(dr);
                //goto x;
            }

            dr = dt.NewRow();
            dr[0] = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            dr[1] = ds.Tables[0].Rows[i].ItemArray[2].ToString();
            dr[2] = ds.Tables[0].Rows[i].ItemArray[3].ToString();
            dr[3] = ds.Tables[0].Rows[i].ItemArray[5].ToString();
            dr[4] = ds.Tables[0].Rows[i].ItemArray[6].ToString();
            dr[5] = ds.Tables[0].Rows[i].ItemArray[4].ToString();
            dr[6] = ds.Tables[0].Rows[i].ItemArray[8].ToString();
            dt.Rows.Add(dr);



            // goto y;
            //  x: i--;
            // y: i = i;

        }



        Gridclientplan.DataSource = dt;
        Gridclientplan.DataBind();

    }
    public void gridbindsearch(DataSet ds)
    {
        string traveldate = "";
        DataTable dt = new DataTable("ClientsTripplan");
        DataRow dr;
        dt.Columns.Add("client");
        dt.Columns.Add("source");
        dt.Columns.Add("designation");
        dt.Columns.Add("truckcapacity");
        dt.Columns.Add("traveltype");
        dt.Columns.Add("truckreq");
        dt.Columns.Add("budget");
        //Calling the Class


        for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
        {

            if (traveldate != ds.Tables[0].Rows[i].ItemArray[0].ToString())
            {
                traveldate = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                dr = dt.NewRow();
                dr[0] = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                dt.Rows.Add(dr);
                //goto x;
            }

            dr = dt.NewRow();
            dr[0] = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            dr[1] = ds.Tables[0].Rows[i].ItemArray[2].ToString();
            dr[2] = ds.Tables[0].Rows[i].ItemArray[3].ToString();
            dr[3] = ds.Tables[0].Rows[i].ItemArray[5].ToString();
            dr[4] = ds.Tables[0].Rows[i].ItemArray[6].ToString();
            dr[5] = ds.Tables[0].Rows[i].ItemArray[4].ToString();
            dr[6] = ds.Tables[0].Rows[i].ItemArray[8].ToString();
            dt.Rows.Add(dr);



            // goto y;
            //  x: i--;
            // y: i = i;

        }



        Gridclientplan.DataSource = dt;
        Gridclientplan.DataBind();

    }




    protected void Gridclientplan_RowDataBound(Object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label Lblclient = (Label)e.Row.FindControl("Lblclient");

            bool validDate = false;
            DateTime result;
            validDate = DateTime.TryParse(Lblclient.Text, out result);


            if (validDate == true)
            {
                e.Row.Cells[0].ForeColor = System.Drawing.Color.Red;
            }

        }
    }


    protected void DDLShow_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DDLShow.SelectedIndex == 1)
        {
            LoadClient();
        }
    }
    public void LoadClient()
    {
        DDLCategory.Items.Clear();
        DDLCategory.DataSource = obj_class.FillClient();
        DDLCategory.DataTextField = "CompanyName";
        DDLCategory.DataValueField = "ClientID";
        DDLCategory.DataBind();
        DDLCategory.Items.Insert(0, new ListItem("--Select Client--", "0"));

    }
    protected void DDLCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ds = obj_class.searchtripplanByClient(DDLCategory.SelectedItem.Text);
            gridbindsearch(ds);
        }
        catch (Exception ex)
        {
        }
    }
    protected void DownLoad_Click(object sender, EventArgs e)
    {
        ExportGrid(Gridclientplan, "ClientTripplan.xls");

    }

    public override void VerifyRenderingInServerForm(Control control)
    {
    }

    public void ExportGrid(GridView oGrid, string exportFile)
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
        //   obj_Navihome.Visible = true;

    }
    public void SetVisualOFF()
    {
        obj_LoginCtrl.Visible = true;
        obj_WelcomCtrl.Visible = false;
        //obj_Navi.Visible = true;
        //  obj_Navihome.Visible = false;
    }





   
}
