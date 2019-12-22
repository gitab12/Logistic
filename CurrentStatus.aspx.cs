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

public partial class CurrentStatus : System.Web.UI.Page
{

    string obj_Authenticated;
    PlaceHolder maPlaceHolder;
    UserControl obj_Tabs;
    UserControl obj_LoginCtrl;
    UserControl obj_WelcomCtrl;
    UserControl obj_Navi;
    UserControl obj_Navihome;



    BizConnectClass obj_class = new BizConnectClass();
    BizConnectLogisticsPlan obj = new BizConnectLogisticsPlan();
    int Logid = 0;  

    protected void Page_Load(object sender, EventArgs e)
    {
    
      if (Session["UserID"] != string.Empty && Convert.ToInt32(Session["UserID"].ToString()) > 0)
       {
        if (IsPostBack != true)
        {
           
               BindData();
               ChkAuthentication();       
        }
       } 
        else
        {
            Response.Redirect("Index.html");
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
    public void BindData()
    {
        try
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



            DataSet ds = new DataSet();
            ds = obj_class.Get_Bizconnect_RoutePrice(Convert.ToInt32(Request.QueryString["UserID"].ToString()));
            for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                dr = dt.NewRow();
                if (Logid == Convert.ToInt32(ds.Tables[0].Rows[i].ItemArray[0].ToString()))
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
                    // dr[10] = "Routeprice.aspx?ID=Inv&transid=" + ds.Tables[0].Rows[i].ItemArray[8] + " &from=" + ds.Tables[0].Rows[i].ItemArray[2] + "&to=" + ds.Tables[0].Rows[i].ItemArray[3] + "&trucktype=" + ds.Tables[0].Rows[i].ItemArray[4] + "&capacity=" + ds.Tables[0].Rows[i].ItemArray[6] + "&price=" + ds.Tables[0].Rows[i].ItemArray[7] + "&ClientID=" + ds.Tables[0].Rows[i].ItemArray[9];
                    dt.Rows.Add(dr);
                }
                else
                {
                    Logid = Convert.ToInt32(ds.Tables[0].Rows[i].ItemArray[0].ToString());
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
        catch (Exception ex)
        {
        }
    }


    protected void btnsearch_Click(object sender, EventArgs e)
    {
        lblmsg.Text = "";
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

    public void SearchBindData()
    {
        try
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



            DataSet ds = new DataSet();
            ds = obj.Get_Bizconnect_RouteSearch(Convert.ToInt32(Request.QueryString["UserID"].ToString()), txtsearch.Text,1,"");
            for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                dr = dt.NewRow();
                if (Logid == Convert.ToInt32(ds.Tables[0].Rows[i].ItemArray[0].ToString()))
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
                    // dr[10] = "Routeprice.aspx?ID=Inv&transid=" + ds.Tables[0].Rows[i].ItemArray[8] + " &from=" + ds.Tables[0].Rows[i].ItemArray[2] + "&to=" + ds.Tables[0].Rows[i].ItemArray[3] + "&trucktype=" + ds.Tables[0].Rows[i].ItemArray[4] + "&capacity=" + ds.Tables[0].Rows[i].ItemArray[6] + "&price=" + ds.Tables[0].Rows[i].ItemArray[7] + "&ClientID=" + ds.Tables[0].Rows[i].ItemArray[9];
                    dt.Rows.Add(dr);
                }
                else
                {
                    Logid = Convert.ToInt32(ds.Tables[0].Rows[i].ItemArray[0].ToString());
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
            lblcount.Text = "No.of RoutePlans = " + ds.Tables[0].Rows.Count + "";
        }

        catch (Exception ex)
        {
        }
    }
    
    protected void btnexport_Click(object sender, EventArgs e)
    {
        ExportGrid(GridRouteprice, "RoutePrice.xls");
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
