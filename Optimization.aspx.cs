using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Optimization : System.Web.UI.Page
{

    string obj_Authenticated;
    PlaceHolder maPlaceHolder;
    UserControl obj_Tabs;
    UserControl obj_LoginCtrl;
    UserControl obj_WelcomCtrl;
    UserControl obj_Navi;
    UserControl obj_Navihome;

    BizConnectDealProcess obj_Class=new BizConnectDealProcess ();
    DataSet ds = new DataSet();
     DataSet ds_Cfeet = new DataSet();
     DataSet ds_Transporter = new DataSet();
    int Capacity,FConversion;
    double Length, Breadth, Height, CubicFeet, NfBoxes;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
       // Session["ClientID"]="1150";
            Load_TruckType();
            GridBind();
             Load_FromLoc();
             ChkAuthentication();
                Load_ToLoc();
                if (Convert.ToInt32(Session["ClientID"]) == 1284)
                {
                    hyp_OptDispatchplan.Visible = true;
                }
                else
                {
                    hyp_OptDispatchplan.Visible = false;
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
    public void Load_TruckType()
    {
        ds = obj_Class.Get_TruckType_ForOptimization();
        ddl_TruckType.DataSource  = ds;
        ddl_TruckType.DataTextField = "TruckName";
        ddl_TruckType.DataValueField = "Capacity";
        ddl_TruckType.DataBind();
        ddl_TruckType.Items.Insert(0, new ListItem("--Select--", "0"));
    }
    public void Load_FromLoc()
    {
        ds = obj_Class.bizconnect_Get_Fromlocation(Convert.ToInt32(Session["ClientID"].ToString()),"");
        ddl_FromLoc .DataSource = ds;
        ddl_FromLoc.DataTextField = "FromLocation";
        ddl_FromLoc.DataBind();
        ddl_FromLoc.Items.Insert(0, new ListItem("--Select--", "0"));
    }
    public void Load_ToLoc()
    {
        ds = obj_Class.bizconnect_Get_ToLocation(Convert.ToInt32(Session["ClientID"].ToString()));
        ddl_ToLoc.DataSource = ds;
        ddl_ToLoc.DataTextField = "ToLocation";
        ddl_ToLoc.DataBind();
        ddl_ToLoc.Items.Insert(0, new ListItem("--Select--", "0"));
    }
    
    public void GridBind()
    {
        ds = obj_Class.Get_OptimizationDetails(Convert .ToInt32 (Session["ClientID"].ToString()));
        grd_Optimization.DataSource = ds;
        grd_Optimization.DataBind();
        
    }
   public void Get_Transporter()
   {
        ds_Transporter = obj_Class.bizconnect_Get_TransporterandLowQuote(ddl_FromLoc.SelectedValue.ToString(), ddl_ToLoc.SelectedValue.ToString(), Convert.ToInt32(Session["TruckID"]));
            if (ds_Transporter.Tables[0].Rows.Count == 0)
            {
                txt_LowestQuote.Text = "0";
                lbl_TransporterName.Text = "";
            }
            else
            {
                txt_LowestQuote.Text = ds_Transporter.Tables[0].Rows[0][0].ToString();
                lbl_TransporterName.Text = ds_Transporter.Tables[0].Rows[0][1].ToString();
            }
   }
   protected void ddl_ToLoc_SelectedIndexChanged(object sender, EventArgs e)
    {
        Get_Transporter();
    } 
    protected void ddl_TruckType_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridBind();
        if (ddl_TruckType.SelectedValue == "0")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Please Select The Truck Type To Calculate!');</script>");
        }
        else
        {
        lbl_Capacity.Text = "Truck Capacity :" +ddl_TruckType.SelectedValue.ToString()+" Kgs";
         ds_Cfeet=obj_Class .Bizconnet_Get_CubicFeet (Convert .ToInt32 (ddl_TruckType.SelectedValue.ToString()));
        Session["CFeet"] = ds_Cfeet.Tables[0].Rows[0][0];
        Session["TruckID"] = ds_Cfeet.Tables[0].Rows[0][1];
        Get_Transporter();
        }
    } 
    
    protected void btn_Search_Click(object sender, EventArgs e)
    {
        if (ddl_TruckType.SelectedValue == "0")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Please Select The Truck Type To Calculate!');</script>");
        }
        else
        {
            for (int i = 0; i < grd_Optimization.Rows.Count; i++)
            {
                Capacity = Convert.ToInt32(ddl_TruckType.SelectedValue);
                TextBox l1 = (TextBox) grd_Optimization .Rows [i].FindControl("txt_Length");
                TextBox B1 = (TextBox)grd_Optimization.Rows[i].FindControl("txt_Breadth");
                TextBox H1 = (TextBox)grd_Optimization.Rows[i].FindControl("txt_Height");
                 TextBox W1 = (TextBox)grd_Optimization.Rows[i].FindControl("txt_Weight");
                  TextBox Cost = (TextBox)grd_Optimization.Rows[i].FindControl("txt_Cost");
                 
                
                Label FeetConv = (Label)grd_Optimization.Rows[i].FindControl("lbl_FeetCon");

                FConversion = Convert.ToInt32(FeetConv.Text);
                Label length1 = (Label)grd_Optimization.Rows[i].FindControl("lbl_OPTLength");
                Label Breadth1 = (Label)grd_Optimization.Rows[i].FindControl("lbl_OPTBreadth");
                Label Height1 = (Label)grd_Optimization.Rows[i].FindControl("lbl_OPTHeight");
                Label Cft1 = (Label)grd_Optimization.Rows[i].FindControl("lbl_OPTCFT");
                Label NoOfBoxes = (Label)grd_Optimization.Rows[i].FindControl("lbl_OPTNoOfBoxes");
                Label LoadingBoxes = (Label)grd_Optimization.Rows[i].FindControl("lbl_OPTLoadBoxes");
                Label Trucks = (Label)grd_Optimization.Rows[i].FindControl("lbl_Trucks");
                Label CostPerBox = (Label)grd_Optimization.Rows[i].FindControl("lbl_Cost");
                
                

                Length = Math.Round(Convert.ToDouble(l1.Text) / FConversion, 2);
                Breadth = Math.Round(Convert.ToDouble(B1.Text) / FConversion, 2);
                Height = Math.Round(Convert.ToDouble(H1.Text) / FConversion, 2);
                CubicFeet = Math.Round(Convert.ToDouble(Length) * Convert.ToDouble(Breadth) * Convert.ToDouble(Height), 2);
                NfBoxes = Math.Round(Convert.ToInt32 (Session["CFeet"]) / CubicFeet, 0);

                length1.Text = Length.ToString();
                Breadth1.Text = Breadth.ToString();
                Height1.Text = Height.ToString();
                Cft1.Text = CubicFeet.ToString();
                NoOfBoxes.Text = NfBoxes.ToString();
                LoadingBoxes.Text= Math.Round(Convert.ToDouble(Capacity)/Convert.ToDouble(W1.Text),0).ToString();
                if(Convert.ToDouble(LoadingBoxes.Text)<Convert.ToDouble(NoOfBoxes.Text))
                {
                CostPerBox.Text= Math.Round(Convert.ToDouble(txt_LowestQuote.Text)/Convert.ToDouble(LoadingBoxes.Text),2).ToString();
                }
                else
                {
                 CostPerBox.Text= Math.Round(Convert.ToDouble(txt_LowestQuote.Text)/Convert.ToDouble(NoOfBoxes.Text),2).ToString();
                }
              
            }
        }
    }
    
    
    protected void btn_ExportToExcel_Click(object sender, EventArgs e)
    {
        ExportGrid(grd_Optimization, "Optimization.xls");
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