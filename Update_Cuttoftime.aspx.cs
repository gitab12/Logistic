using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Update_Cuttoftime : System.Web.UI.Page
{
    BizCon_DB_ConnectionString conbiz = new BizCon_DB_ConnectionString();
    Aumjunction_DB_ConnectionString conjunction = new Aumjunction_DB_ConnectionString();
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected void btn_getcuttofdata_Click(object sender, EventArgs e)
    {
        try
        {
            PopulateGridView();
        }
        catch(Exception)
        {

        }
        finally
        {

        }
    }
    private void PopulateGridView()
    {
        try
        {
            string dayy = ddl_date.SelectedItem.Value;
            string monthh = ddl_month.SelectedItem.Value;
            string yearr = ddl_year.SelectedItem.Value;


            conjunction.Sql_OpenCon();
            string[] args = { "@mydays", "@mymonth", "@myyear" };
            string[] argsval = { dayy, monthh, yearr };
            DataSet ds_data = new DataSet();
            ds_data = conjunction.Sql_GetData("SP_Get_Data_For_Cuttofftime_change", args, argsval);
            if (ds_data.Tables[0].Rows.Count > 0)
            {
                gv_showdata.DataSource = ds_data;
                gv_showdata.DataBind();



            }
            else
            {
                lbl_msg.Text = Resources.Resource.alert_error.Replace("{@message}", "Please Change Date....!");               
                gv_showdata.DataSource = null;
                gv_showdata.DataBind();

            }
        }
        catch (Exception ex)
        {

        }
        finally
        {
            conjunction.Sql_CloseCon();
        }
    }
    //protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    try
    //    {
    //        if (e.Row.RowType == DataControlRowType.DataRow)
    //        {
    //            //Label lblLAT = (e.Row.FindControl("lbl_LAT") as Label);
    //            //Label lblLONG = (e.Row.FindControl("lbl_LONG") as Label);

    //            //string[] argsg = { "@lat", "@long" };
    //            //string[] argsgval = { lblLAT.Text, lblLONG.Text };
    //            //DataSet _dsgetaddress = new DataSet();
    //            //_dsgetaddress = con.Sql_GetData("SP_Get_Address_By_Latlong", argsg, argsgval);
    //            //if (_dsgetaddress.Tables[0].Rows.Count > 0)
    //            //{
    //            //    (e.Row.FindControl("lbl_address") as Label).Text = _dsgetaddress.Tables[0].Rows[0]["address"].ToString();
    //            //}

    //        }
    //    }
    //    catch (Exception ex)
    //    {

    //    }
    //    finally
    //    {

    //    }
    //}
    protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gv_showdata.PageIndex = e.NewPageIndex;
        PopulateGridView();
    }

    protected void OnRowEditing(object sender, GridViewEditEventArgs e)
    {
        gv_showdata.EditIndex = e.NewEditIndex;
        PopulateGridView();
    }

    protected void OnRowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        GridViewRow row = gv_showdata.Rows[e.RowIndex];
        int postid = Convert.ToInt32(gv_showdata.DataKeys[e.RowIndex].Values[0]);
        //string name = (row.FindControl("txtName") as TextBox).Text;
        //string country = (row.FindControl("txtCountry") as TextBox).Text;
        //string query = "UPDATE Customers SET Name=@Name, Country=@Country WHERE CustomerId=@CustomerId";
        //string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        //using (SqlConnection con = new SqlConnection(constr))
        //{
        //    using (SqlCommand cmd = new SqlCommand(query))
        //    {
        //        cmd.Parameters.AddWithValue("@CustomerId", customerId);
        //        cmd.Parameters.AddWithValue("@Name", name);
        //        cmd.Parameters.AddWithValue("@Country", country);
        //        cmd.Connection = con;
        //        con.Open();
        //        cmd.ExecuteNonQuery();
        //        con.Close();
        //    }
        //}
        lblmsg.Text = Resources.Resource.alert_success.Replace("{@message}", "You have successfully Update."+postid.ToString());
        gv_showdata.EditIndex = -1;
        PopulateGridView();
    }
    protected void OnRowCancelingEdit(object sender, EventArgs e)
    {
        gv_showdata.EditIndex = -1;
        PopulateGridView();
    }
}