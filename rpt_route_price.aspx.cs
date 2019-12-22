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

public partial class rpt_route_price : System.Web.UI.Page
{
    static DataSet ds;
    static SqlDataAdapter da;
    string constr = ConfigurationManager.ConnectionStrings["BizCon"].ConnectionString;
    string page = ConfigurationManager.AppSettings["Title"];
    string obj_Authenticated;
    PlaceHolder maPlaceHolder;
    UserControl obj_Tabs;
    UserControl obj_LoginCtrl;
    UserControl obj_WelcomCtrl;
    UserControl obj_Navi;
    UserControl obj_Navihome;
BizConnectTransporter obj = new BizConnectTransporter();

    BizConnectClass obj_class = new BizConnectClass();

    protected void Page_Load(object sender, EventArgs e)
    {
            if (!IsPostBack)
        {
            try
            {
                bind();
                ChkAuthentication();
                
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
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
       

    }
    public void SetVisualOFF()
    {
        obj_LoginCtrl.Visible = true;
        obj_WelcomCtrl.Visible = false;
       
    }


    public void bind()
    {
        try
        {
            DataSet ds = new DataSet();
            ds = obj.Get_Report_Routeprice();
            Grid_cform.DataSource = ds;
            Grid_cform.DataBind();
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }


    protected void btn_export_Click(object sender, EventArgs e)
    {
        ExportGrid(Grid_cform, "Rpt_route_price.xls");
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

    protected void Grid_cform_RowEditing(object sender, GridViewEditEventArgs e)
    {       

       Grid_cform.EditIndex = e.NewEditIndex;
       bind();    
    }

    protected void Grid_cform_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        Grid_cform.EditIndex = -1;
        bind();
    }

    protected void Grid_cform_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
       int res = 0;
        try
        {
            GridViewRow row = (GridViewRow)Grid_cform.Rows[e.RowIndex];
            Label lblRuteID = (Label)row.FindControl("lblRoute_ID");
            TextBox txtCapacity = (TextBox)row.FindControl("txtCapacity");
            TextBox txtUnit = (TextBox)row.FindControl("txtUnit");
            TextBox txtOneway_Price = (TextBox)row.FindControl("txtOneway_Price");
            TextBox txtTwoway_price = (TextBox)row.FindControl("txtTwoway_price");
            Grid_cform.EditIndex = -1;
            res = obj_class.Update_Bizconnect_Route_Price(Convert.ToInt32(lblRuteID.Text.ToString()), Convert.ToDouble(txtCapacity.Text.ToString()), txtUnit.Text, Convert.ToDouble(txtOneway_Price.Text.ToString()), Convert.ToDouble(txtTwoway_price.Text.ToString()));
            bind();
          
        }
        catch (Exception ex)
        {
            res = 0;
            lblMessage.Text = ex.Message;
        }
    }

    protected void Grid_cform_RowUpdated(object sender, GridViewUpdatedEventArgs e)
    {
        lblMessage.Text = "Record Updated";
        bind();
    }
    protected void Grid_cform_SelectedIndexChanged(object sender, EventArgs e)
    {
       
    }
    protected void txtsearch_TextChanged(object sender, EventArgs e)
    {
          
    }

    protected void btnsearch_Click(object sender, EventArgs e)
    {
       DataSet ds = new DataSet();
       ds = Transportername(txtsearch.Text);
       Grid_cform.DataSource = ds;
       Grid_cform.DataBind();

    }

    public DataSet Transportername(string Transporter_Name)
    {
        SqlConnection conn = new SqlConnection(constr);
        DataSet ds = new DataSet();
        ds.Clear();
        conn.Open();
        using (SqlCommand cmd = new SqlCommand("TransporterSearch", conn))
        {
            try
            {
                SqlDataAdapter ada = new SqlDataAdapter(cmd);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                ada.SelectCommand.Parameters.AddWithValue("@Transporter_Name", Transporter_Name);               
                ada.SelectCommand.ExecuteNonQuery();
                ada.Fill(ds, "Route_Price");
            }

            catch (Exception err)
            {

            }
            finally
            {
                conn.Close();
            }
        }
        return ds;
    }
   
}
   

