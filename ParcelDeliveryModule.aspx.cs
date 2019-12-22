using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System .Data;
using System.Data.SqlClient;
using System.Configuration;
public partial class ParcelDeliveryModule : System.Web.UI.Page
{

    string obj_Authenticated;
    PlaceHolder maPlaceHolder;
    UserControl obj_Tabs;
    UserControl obj_LoginCtrl;
    UserControl obj_WelcomCtrl;
    UserControl obj_Navi;
    UserControl obj_Navihome;

    DataTable dt = new DataTable();
    ParcelModule obj_Class = new ParcelModule();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            ShowDetails();
            ChkAuthentication();
            
            DateTime dtt = new DateTime();
                dtt = DateTime.Now.Date;
                txtBillDate.Text = dtt.ToString("dd-MMM-yyyy");
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
    public void ShowDetails()
    {
        dt = obj_Class.Get_TransportforParcel(Convert.ToInt32(Session["ClientID"].ToString()),"0","0",0,1);
        DDLTransporter.Items.Clear();
        DDLTransporter.DataSource = dt;
        DDLTransporter.DataTextField = "Transporter";
        DDLTransporter.DataValueField = "rid";
        DDLTransporter.DataBind();
        DDLTransporter.Items.Insert(0, new ListItem("--- Select Transporter ---", "0"));


        DDLFrom.Items.Clear();
        DDLFrom.DataSource = dt;
        DDLFrom.DataTextField = "FromLocation";
        DDLFrom.DataValueField = "FromLocation";
        DDLFrom.DataBind();
        DDLFrom.Items.Insert(0, new ListItem("--- Select From ---", "0"));

        DDLTo.Items.Clear();
        DDLTo.DataSource = dt;
        DDLTo.DataTextField = "ToLocation";
        DDLTo.DataValueField = "ToLocation";
        DDLTo.DataBind();
        DDLTo.Items.Insert(0, new ListItem("--- Select To ---", "0"));

    }
    protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
    {

        ShowGridview();
    }
    
     protected void butGetDetails_Click(object sender, EventArgs e)
    {
     ShowGridview();
    }
    
    
    

    public void ShowGridview()
    {
         DataTable dtt = new DataTable();
        dtt = obj_Class.Get_parcelAgreementDetailsofTransporter(Convert.ToInt32(Session["ClientID"].ToString()), DDLFrom.SelectedValue, DDLTo.SelectedValue, Convert.ToInt32(DDLTransporter.SelectedValue));
        Gridwindow.DataSource = dtt;
        Gridwindow.DataBind();
    }
    protected void DDLTransporter_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataTable dtt = new DataTable();
        dtt = obj_Class.Get_parcelAgreementDetailsofTransporter(Convert.ToInt32(Session["ClientID"].ToString()), DDLFrom.SelectedValue, DDLTo.SelectedValue, Convert.ToInt32(DDLTransporter.SelectedValue));
        Gridwindow.DataSource = dtt;
        Gridwindow.DataBind();
    }
    protected void ChkSelect_CheckedChanged(object sender, EventArgs e)
    {
         CheckBox  b = (CheckBox)sender;
        GridViewRow row = (GridViewRow)b.NamingContainer;
        if (row != null)
        {
            TextBox txtWeight = (TextBox)Gridwindow.Rows[row.RowIndex].FindControl("txtWeight");
            TextBox txtqty = (TextBox)Gridwindow.Rows[row.RowIndex].FindControl("txtqty");
            if (b.Checked)
            {
                txtWeight.Text = "";
                txtqty.Text = "";
                txtWeight.Enabled = true;
                txtqty.Enabled = true;
            }
            else
            {
                txtWeight.Text = "";
                txtqty.Text = "";
                txtWeight.Enabled = false ;
                txtqty.Enabled = false ;
            }
        }
    }
    
    
    
    protected void butcal_Click(object sender, EventArgs e)
    {
        int ddcharges = 0;
        for (int j = 0; j <= Gridwindow.Rows.Count - 1; j++)
        {
            CheckBox check = (CheckBox)Gridwindow.Rows[j].FindControl("ChkSelect");
            if (check.Checked)
            {
                TextBox txtqty = (TextBox)Gridwindow.Rows[j].FindControl("txtqty");
                TextBox txtkm=(TextBox)Gridwindow.Rows[j].FindControl("txtkm");
                Label lblRateperKG = (Label)Gridwindow.Rows[j].FindControl("lblRateperKG");
                TextBox txtweight=(TextBox)Gridwindow.Rows[j].FindControl("txtweight");
                TextBox txtbasic = (TextBox)Gridwindow.Rows[j].FindControl("txtbasic");
                txtbasic.Text = (Convert.ToSingle(txtkm.Text) * Convert.ToDouble(lblRateperKG.Text)*Convert.ToSingle(txtweight.Text)/100).ToString();
                TextBox txtfsv = (TextBox)Gridwindow.Rows[j].FindControl("txtfsv");
                Label lblFsv = (Label)Gridwindow.Rows[j].FindControl("lblFsv");
             
                txtfsv.Text= ((Convert.ToSingle( txtbasic.Text) *Convert.ToSingle(lblFsv.Text))/100).ToString();
                Label lblvsc = (Label)Gridwindow.Rows[j].FindControl("lblvsc");
                TextBox txtvsc = (TextBox)Gridwindow.Rows[j].FindControl("txtvsc");

                TextBox txtdhc = (TextBox)Gridwindow.Rows[j].FindControl("txtdhc");
                Label lbldhc = (Label)Gridwindow.Rows[j].FindControl("lbldhc");
                txtdhc.Text = ((Convert.ToSingle(txtfsv.Text) + Convert.ToSingle(txtbasic.Text)) * (Convert.ToSingle(lbldhc.Text)) / 100).ToString();
                    
                 //VSC Calculation
                TextBox txtinvvalue = (TextBox)Gridwindow.Rows[j].FindControl("txtinvvalue");
                txtvsc.Text = (Convert.ToSingle(txtinvvalue.Text)  *(Convert.ToSingle(lblvsc.Text)) / 100).ToString();

                //Handling Charges              

                TextBox txthandlingcharges = (TextBox)Gridwindow.Rows[j].FindControl("txthandlingcharges");
                txthandlingcharges.Text = (Convert.ToSingle(txtqty.Text) * 1).ToString();

                //DoorDelivery
                TextBox txtddcharges = (TextBox)Gridwindow.Rows[j].FindControl("txtddcharges");
                if (Convert.ToInt32(txtqty.Text) == 1)
                {
                   ddcharges= slap(1);
                }
                else if (Convert.ToInt32(txtqty.Text) == 2)
                  
                {
                    ddcharges = slap(2);
                }
				else if (Convert.ToInt32(txtqty.Text) == 3)
                  
                {
                    ddcharges = slap(3);
                }
                 else if (Convert.ToInt32(txtqty.Text) == 4)
                  
                {
                    ddcharges = slap(4);
                }
                 else if ((Convert.ToInt32(txtqty.Text) >= 5 )|| (Convert.ToInt32(txtqty.Text) <=10 ) )
                  
                {
                    ddcharges = slap(5);
                    int BoxesCount=Convert.ToInt32(txtqty.Text)-10;
                    ddcharges=ddcharges+(BoxesCount*5);
                    
                }
                else
                {
                ddcharges = slap(5);
                
                }
                txtddcharges.Text = ddcharges.ToString();


				//LRCharges
TextBox txtLRcharges = (TextBox)Gridwindow.Rows[j].FindControl("txtLRcharges");
                //Total
                TextBox txtTotal = (TextBox)Gridwindow.Rows[j].FindControl("txtTotal");
                txtTotal.Text = (Convert.ToSingle(txtbasic.Text) + Convert.ToSingle(txtfsv.Text) + Convert.ToSingle(txtdhc.Text) + Convert.ToSingle(txtvsc.Text) + Convert.ToSingle(txthandlingcharges.Text) + Convert.ToSingle(txtddcharges.Text)+Convert.ToSingle(txtLRcharges.Text)).ToString();
          //Transporter Detail Calculation
          
                 TextBox txtTbasic = (TextBox)Gridwindow.Rows[j].FindControl("txtTbasic");
                TextBox txtTOtherCharges = (TextBox)Gridwindow.Rows[j].FindControl("txtTOtherCharges");
                TextBox txtTTotal = (TextBox)Gridwindow.Rows[j].FindControl("txtTTotal");
                 txtTTotal.Text = (Convert.ToSingle(txtTbasic.Text) + Convert.ToSingle(txtTOtherCharges.Text)).ToString();
          
           butsave.Enabled=true;
            }
        }
    }

    public int slap(int slap)
    {
        DataSet ds = new DataSet();
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["BizCon"].ConnectionString);
        conn.Open();
        string qry = "select Charge   from DoorDeliverySlap where NoofBoxs=" + slap + " and ClientID=" + Session["ClientID"] + " and TransporterID="+Convert.ToInt32(DDLTransporter.SelectedValue) +"";

        SqlCommand cmd = new SqlCommand(qry, conn);
        cmd.ExecuteNonQuery();
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        ds = new DataSet();
        adp.Fill(ds);
     
        int val = Convert.ToInt32(ds.Tables[0].Rows[0].ItemArray[0].ToString());
        return val;
    }
    
    
     protected void butsave_Click(object sender, EventArgs e)
    {

for (int j = 0; j <= Gridwindow.Rows.Count - 1; j++)
        {
            CheckBox check = (CheckBox)Gridwindow.Rows[j].FindControl("ChkSelect");
            if (check.Checked)
            {

                Label lblFromLoc= (Label)Gridwindow.Rows[j].FindControl("lblFromLoc");
                Label lbltoloc= (Label)Gridwindow.Rows[j].FindControl("lbltoloc");
                Label lblTransporter=(Label)Gridwindow.Rows[j].FindControl("lblTransporter");

                TextBox txtqty = (TextBox)Gridwindow.Rows[j].FindControl("txtqty");
                TextBox txtkm=(TextBox)Gridwindow.Rows[j].FindControl("txtkm");
                TextBox txtweight =(TextBox)Gridwindow.Rows[j].FindControl("txtweight");
                Label lblRateperKG = (Label)Gridwindow.Rows[j].FindControl("lblRateperKG");
                TextBox txtbasic = (TextBox)Gridwindow.Rows[j].FindControl("txtbasic");
               
                TextBox txtfsv = (TextBox)Gridwindow.Rows[j].FindControl("txtfsv");
                Label lblFsv = (Label)Gridwindow.Rows[j].FindControl("lblFsv");
                            
                Label lblvsc = (Label)Gridwindow.Rows[j].FindControl("lblvsc");
                TextBox txtvsc = (TextBox)Gridwindow.Rows[j].FindControl("txtvsc");

                TextBox txtdhc = (TextBox)Gridwindow.Rows[j].FindControl("txtdhc");
                Label lbldhc = (Label)Gridwindow.Rows[j].FindControl("lbldhc");
                    
                    
                  TextBox  txtinvvalue=(TextBox)Gridwindow.Rows[j].FindControl("txtinvvalue");    
                //Handling Charges              
                 TextBox txthandlingcharges = (TextBox)Gridwindow.Rows[j].FindControl("txthandlingcharges");
                 //DoorDelivery
                TextBox txtddcharges = (TextBox)Gridwindow.Rows[j].FindControl("txtddcharges");
                  //Total
                TextBox txtTotal = (TextBox)Gridwindow.Rows[j].FindControl("txtTotal");
                TextBox txtLRNumber = (TextBox)Gridwindow.Rows[j].FindControl("txtLRNumber");
                TextBox txtLRDate = (TextBox)Gridwindow.Rows[j].FindControl("txtLRdate");
                
                TextBox txtTbasic = (TextBox)Gridwindow.Rows[j].FindControl("txtTbasic");
                TextBox txtTOtherCharges = (TextBox)Gridwindow.Rows[j].FindControl("txtTOtherCharges");
                TextBox txtTTotal = (TextBox)Gridwindow.Rows[j].FindControl("txtTTotal");            
            
        

        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["BizCon"].ConnectionString);
        conn.Open();
        string qry = "insert into Bizconnect_ParcelBillEntry (FromLoc ,ToLoc ,TransporterName ,RatePerKgorKm ,KM ,Weight ,Quantity ,BasicFreight ,FSC ,DHC ,InvoiceValue ,VSC ,DoordeliveryCharges , HandlingCharges ,Total,LRDate  ,LRNumber , BillDate ,BillNumber,TransporterBasicFreight,TransporterOtherCharges,TransporterTotalAmount) values('" + lblFromLoc.Text + "','" + lbltoloc.Text + "','" + lblTransporter.Text + "'," + Convert.ToSingle(lblRateperKG.Text) + "," + Convert.ToInt32(txtkm.Text) + "," + Convert.ToInt32(txtweight.Text) + "," + Convert.ToInt32(txtqty.Text) + "," + Convert.ToSingle(txtbasic.Text) + "," + Convert.ToSingle(txtfsv.Text) + "," + Convert.ToSingle(txtdhc.Text) + ", " + Convert.ToSingle(txtinvvalue.Text) + "," + Convert.ToSingle(txtvsc.Text) + "," + Convert.ToSingle(txtddcharges.Text) + "," + Convert.ToSingle(txthandlingcharges.Text) + "," + Convert.ToSingle(txtTotal.Text) + ",'" + Convert.ToDateTime(txtLRDate.Text) + "','" + txtLRNumber.Text + "','" + Convert.ToDateTime(txtBillDate.Text) + "','" + txtBillNo.Text + "'," + Convert.ToSingle(txtTbasic.Text) + "," + Convert.ToSingle(txtTOtherCharges.Text) + "," + Convert.ToSingle(txtTTotal.Text) + ")";
      SqlCommand cmd = new SqlCommand(qry, conn);
        cmd.ExecuteNonQuery();
        ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Data Saved Successfully');</script>");
            }
    }
    }
    
    protected void btn_View_Click(object sender, EventArgs e)
    {
        ProjectBased obj = new ProjectBased();
        DataSet ds_BillEntry = new DataSet();
        ds_BillEntry=obj.Bizconnect_GetParcekBillEntryDetails();
        grd_BillEntry.DataSource = ds_BillEntry;
        grd_BillEntry.DataBind();  
    }
    
}