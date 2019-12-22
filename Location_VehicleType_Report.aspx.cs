using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Location_VehicleType_Report : System.Web.UI.Page
{
    BizCon_DB_ConnectionString con = new BizCon_DB_ConnectionString();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {

                string userid = Session["UserID"].ToString();
                if (userid != "")
                {
                    
                    con.Sql_OpenCon();
                    string[] args_location = { };
                    string[] argsval_location = { };
                    DataSet _dstruck = new DataSet();
                    _dstruck = con.Sql_GetData("SP_Get_TruckType");
                    if (_dstruck.Tables[0].Rows.Count > 0)
                    {
                        ddl_vehicletype.DataSource = _dstruck;
                        ddl_vehicletype.DataBind();
                        ddl_vehicletype.DataTextField = "TruckType";
                        ddl_vehicletype.DataValueField = "TruckTypeID";
                        ddl_vehicletype.DataBind();
                        ddl_vehicletype.Items.Insert(0, new ListItem("--Select--", "0"));
                    }
                }
                else
                {
                    Response.Redirect("Index.html");
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                con.Sql_CloseCon();
            }
        }
    }
    //protected void txt_todate_TextChanged(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        string userid = Session["UserID"].ToString();
    //        DateTime _dt = new DateTime();
    //        _dt = Convert.ToDateTime(txt_startdate.Text);
    //        string _startdate = _dt.ToString("MM/dd/yyyy");
    //        string startdate = Convert.ToString(_startdate);

    //        DateTime _dtt = new DateTime();
    //        _dtt = Convert.ToDateTime(txt_todate.Text);
    //        string _todate = _dtt.ToString("MM/dd/yyyy");
    //        string todate = Convert.ToString(_todate);

    //        string[] args = { "@userid", "@fromdate", "@todate" };
    //        string[] argsval = { userid, startdate, todate };
    //        DataSet _ds = new DataSet();
    //        _ds = con.Sql_GetData("Bizconnect_Get_Locationdetails", args, argsval);
    //        if (_ds.Tables[0].Rows.Count > 0)
    //        {
    //            ddl_location.DataSource = _ds;
    //            ddl_location.DataBind();
    //            ddl_location.DataTextField = "ToLocation";
    //            ddl_location.DataValueField = "";
    //            ddl_location.DataBind();
    //        }
    //    }
    //    catch(Exception ex)
    //    {

    //    }
        

    //}
    //protected void ddl_location_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        string userid = Session["UserID"].ToString();
    //        string location = ddl_location.SelectedItem.Text.Trim(); 
    //        string[] _location= new string[2];
    //        _location = location.ToString().Split(',');
    //        string mys = _location[0].ToString();
    //        string[] args_location = { "@userid", "@location" };
    //        string[] argsval_location = { userid, "%" + mys + "%" };
    //        DataSet _dslocation = new DataSet();
    //        _dslocation = con.Sql_GetData("Bizconnect_Get_Traveltype", args_location, argsval_location);
    //        if (_dslocation.Tables[0].Rows.Count > 0)
    //        {
    //            ddl_vehicletype.DataSource = _dslocation;
    //            ddl_vehicletype.DataBind();
    //            ddl_vehicletype.DataTextField = "TruckType";
    //            ddl_vehicletype.DataValueField = "TruckTypeID";
    //            ddl_vehicletype.DataBind();
    //            ddl_vehicletype.Items.Insert(0, new ListItem("--Select--", "0"));
    //        }
    //    }
    //    catch(Exception ex)
    //    {
    //    }
    //}
    protected void btn_search_Click(object sender, EventArgs e)
    {
        try
        {
            con.Sql_OpenCon();
            
            string userid = Session["UserID"].ToString();
            string fromdate = txt_startdate.Text;
            string todate = txt_todate.Text;
            string trucktype = ddl_vehicletype.SelectedItem.Text;
            string[] args_data = { "@userid", "@fromdate", "@todate", "@trucktype" };
            string[] argsval_data = { userid, fromdate, todate, trucktype };
            DataSet _dsdata = new DataSet();
            _dsdata = con.Sql_GetData("SP_Get_Vehicle_Location_Details", args_data, argsval_data);
            if (_dsdata.Tables[0].Rows.Count > 0)
            {
                gridview_details.DataSource = _dsdata;
                gridview_details.DataBind();
            }
            else
            {

            }
        }
        catch(Exception ex)
        {

        }
        finally
        {
            con.Sql_CloseCon();
        }


        
    }

    protected void btn_download_Click(object sender, EventArgs e)
    {
        ExportGrid(gridview_details, "Report.xls");
    }

    private void ExportGrid(GridView oGrid, string exportFile)
    {

        {
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