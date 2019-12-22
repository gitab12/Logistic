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

public partial class EditProduct : System.Web.UI.Page
{
    string obj_Authenticated;
    PlaceHolder maPlaceHolder;
    UserControl obj_Tabs;
    UserControl obj_LoginCtrl;
    UserControl obj_WelcomCtrl;
    UserControl obj_Navi;
    UserControl obj_Navihome;
    BizConnectClass bizconnect = new BizConnectClass();
    string obj_productid;
    string cmp;
    ArrayList arr = new ArrayList();
    string connStr = ConfigurationManager.ConnectionStrings["BizCon"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack == false)
        {
            string ID = Request.QueryString["value"];
            fill_Product();
            fillProductType();
            fillProductCategory();
            FillPackingtype();
             fillUnitWeight();
            fillUnitVolume();
            fillUnitLH();
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
        //   obj_Navihome.Visible = true;

    }
    public void SetVisualOFF()
    {
        obj_LoginCtrl.Visible = true;
        obj_WelcomCtrl.Visible = false;
        //obj_Navi.Visible = true;
        //  obj_Navihome.Visible = false;
    }
     public void fillProductType()
     {
        DataSet ds =new DataSet();
        ds = bizconnect.get_ProductType();

        DDLproducttype.DataSource = ds;
        DDLproducttype.DataTextField = "ProductType";
        DDLproducttype.DataValueField = "ProductTypeID";
        DDLproducttype.DataBind();
     }
     public void fillProductCategory()
     {
        DataSet ds=new DataSet();
        ds = bizconnect.get_ProductCategory(Convert.ToInt32(DDLproducttype.SelectedValue));

        DDLproductcategory.DataSource = ds;
        DDLproductcategory.DataTextField = "CategoryName";
        DDLproductcategory.DataValueField = "ProductCategoryID";
        DDLproductcategory.DataBind();
     }
     public void FillPackingtype()
     {
        DataSet ds= new DataSet();
        ds=bizconnect.get_PackingType(Convert.ToInt32(DDLproducttype.SelectedValue));
        DDLpackingType.DataSource = ds;
        DDLpackingType.DataTextField = "PackingMethod";
        DDLpackingType.DataValueField = "PackingMethodID";
        DDLpackingType.DataBind();
     }
     public void fillUnitWeight()
     {
       DataSet ds=new DataSet();
        ds = bizconnect.get_unit(2);

        DDLWeightUnit.DataSource = ds;
        DDLWeightUnit.DataTextField = "unit";
        DDLWeightUnit.DataValueField = "unitid";
        DDLWeightUnit.DataBind();
     }
    public void fillUnitVolume()
    {
        DataSet ds=new DataSet();
        ds = bizconnect.get_unit(3);

        DDlvolumeunit.DataSource = ds;
        DDlvolumeunit.DataTextField = "unit";
        DDlvolumeunit.DataValueField = "unitid";
        DDlvolumeunit.DataBind();
    }
    public void fillUnitLH()
    {
        DataSet ds = new DataSet();
        ds = bizconnect.get_unit(1);
        //Length
        DDLLengthUnit.DataSource = ds;
        DDLLengthUnit.DataTextField = "unit";
        DDLLengthUnit.DataValueField = "unitid";
        DDLLengthUnit.DataBind();
        //Width
        DDLwidthunit.DataSource = ds;
        DDLwidthunit.DataTextField = "unit";
        DDLwidthunit.DataValueField = "unitid";
        DDLwidthunit.DataBind();
        //Height
        DDLHeightUnit.DataSource = ds;
        DDLHeightUnit.DataTextField = "unit";
        DDLHeightUnit.DataValueField = "unitid";
        DDLHeightUnit.DataBind();
    }
     public void fill_Product()
     {
         obj_productid = Request.QueryString["value"];
         arr.Clear();
         arr = bizconnect.get_product(obj_productid);
         if (arr[0].ToString() != "0")
         {
             Txt_productname.Text = arr[3].ToString();
             txt_productDescription.Text = arr[4].ToString();
             Txt_sku.Text = arr[6].ToString();
             txt_weight.Text = arr[7].ToString();
             txt_length.Text = arr[9].ToString();
             Txt_width.Text = arr[10].ToString();
             txt_height.Text = arr[11].ToString();
             txt_volume.Text = arr[12].ToString();
            
             txt_transcostperunit.Text = arr[14].ToString();


         }
         else
         {
             lblmsg.ForeColor = System.Drawing.Color.Red;
             lblmsg.Text = "Record not found or Table is Empty...!";
         }

     }

     protected void Btn_submit_Click(object sender, EventArgs e)
     {
         int res;
         string ID = Request.QueryString["value"];
         int id=Convert.ToInt32(ID);
         int sku=Convert.ToInt32(Txt_sku.Text);
         int pdttyp=Convert.ToInt32(DDLproducttype.SelectedValue);
         int pdtcat=Convert.ToInt32(DDLproductcategory.SelectedValue);
         int pcktyp=Convert.ToInt32(DDLpackingType.SelectedValue);
         double wgt=Convert.ToDouble(txt_weight.Text);
         int wgtunit=Convert.ToInt32(DDLWeightUnit.SelectedValue);
         double len=Convert.ToDouble(txt_length.Text);
         int lenunit= Convert.ToInt32(DDLLengthUnit.SelectedValue);
         double wid=Convert.ToDouble(Txt_width.Text);
         int widunit = Convert.ToInt32(DDLwidthunit.SelectedValue);
         double hght=Convert.ToDouble(txt_height.Text);
         int hghtunit = Convert.ToInt32(DDLHeightUnit.SelectedValue);
         double vol = Convert.ToDouble(txt_volume.Text);
         int volunit = Convert.ToInt32(DDlvolumeunit.SelectedValue);
         int pcksp = Convert.ToInt32(DDLpckngsp.SelectedValue);
         double cost = Convert.ToDouble(txt_transcostperunit.Text);
         res =  bizconnect.Update_Product(id, sku, Txt_productname.Text, txt_productDescription.Text,pdttyp , pdtcat,pcktyp ,wgt , wgtunit,len ,lenunit,wid,widunit,hght,hghtunit, vol, volunit, pcksp, cost);
        if (res == 1)
        {
            lblmsg.ForeColor = System.Drawing.Color.Red;
            lblmsg.Text = "Updation of Customer details is Success...";
            
        }
        else
        {
            lblmsg.ForeColor = System.Drawing.Color.Red;
            lblmsg.Text = "Error Occured in Updation of Posted Ad...";
        }


    }
    
    public void EnableSolid()
       {
        DDLLengthUnit.Enabled =true;
        DDLwidthunit.Enabled =true;
        DDLHeightUnit.Enabled = true;
        DDlvolumeunit.Enabled = false;
        txt_length.Enabled = true;
        Txt_width.Enabled = true;
        txt_height.Enabled = true;
        txt_volume.Enabled = false;
       }
    public void  EnableLiquid()
    {
        DDLLengthUnit.Enabled = false;
        DDLwidthunit.Enabled = false;
        DDLHeightUnit.Enabled = false;
        DDlvolumeunit.Enabled = true;
        txt_length.Enabled = true;
        Txt_width.Enabled = false;
        txt_height.Enabled = false;
        txt_volume.Enabled = true;
    }

    
protected void  DDLproducttype_SelectedIndexChanged(object sender, EventArgs e)
{
    fillProductCategory();
        FillPackingtype();
}
protected void  DDLpackingType_SelectedIndexChanged(object sender, EventArgs e)
{
     if (Convert.ToInt32(DDLpackingType.SelectedValue) == 6)
     {
                     EnableLiquid();
     }
     else
     {
            EnableSolid();
     }
       
}
}
