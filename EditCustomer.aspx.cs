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

public partial class EditCustomer : System.Web.UI.Page
{
    string obj_Authenticated;
    PlaceHolder maPlaceHolder;
    UserControl obj_Tabs;
    UserControl obj_LoginCtrl;
    UserControl obj_WelcomCtrl;
    UserControl obj_Navi;
    UserControl obj_Navihome;
    BizConnectCustomer bizcust = new BizConnectCustomer(); 
    string obj_customerid;
    string cmp;
    ArrayList arr = new ArrayList();
    string connStr = ConfigurationManager.ConnectionStrings["BizCon"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack == false)
        {
            string ID = Request.QueryString["value"];
            fill_Customer();
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
    public void fill_Customer()
    {
        obj_customerid = Request.QueryString["value"];
        arr.Clear();
        arr = bizcust.get_customer(Convert.ToInt32(obj_customerid));
        if (arr[0].ToString() != "0")
        {
            lblaid.Text = arr[0].ToString();
            Txt_companyname.Text = arr[1].ToString();
            txt_noE.Text = arr[2].ToString();
            txt_pno.Text = arr[3].ToString();
            txt_tno.Text = arr[4].ToString();
            txt_stax.Text = arr[5].ToString();
            txt_cenvat.Text = arr[6].ToString();
            Txt_YOE.Text = arr[7].ToString();
            txt_Annualturnover.Text = arr[8].ToString();
            txt_url.Text = arr[9].ToString();
            txt_Boardno.Text = arr[15].ToString();
            Txt_fax.Text = arr[17].ToString();
            txt_Email.Text = arr[18].ToString();
            Txt_address.Text = arr[11].ToString();
            Txt_city.Text = arr[10].ToString();
            Txt_state.Text = arr[12].ToString();
            Txt_country.Text = arr[13].ToString();
            txt_pincode.Text = arr[14].ToString();
            txt_Mobile.Text = arr[16].ToString();
            txt_cperson.Text = arr[19].ToString();
            DDLLocation.DataSource = arr[20].ToString();
            //ddldesg.DataSource = arr[21].ToString();
           
            DataSet ds = Desg();
            ddldesg.DataSource = ds;
            ddldesg.DataTextField = "Designation";
            ddldesg.DataValueField= "DesignationID";
            ddldesg.DataBind();
            ddldesg.Items.Add(new ListItem(arr[21].ToString(), arr[22].ToString()));
           
          
            ddldesg.SelectedIndex = ds.Tables[0].Rows.Count ;
          
        }
        else
        {
            lblmsg.ForeColor = System.Drawing.Color.Red;
            lblmsg.Text = "Record not found or Table is Empty...!";
        }

    }
    DataSet Desg()
    {
       
        string sel = "select Designation,DesignationID from BizConnect_DesignationMaster where Designation!='"+arr[21].ToString()+"'";
        SqlConnection conn = new SqlConnection(connStr);
        conn.Open();
        SqlCommand cmd2 = new SqlCommand(sel, conn);
        SqlDataAdapter da2 = new SqlDataAdapter(sel, conn);
        DataSet ds2 = new DataSet();
        da2.Fill(ds2);
        conn.Close();
        return ds2;
    }
    protected void Btn_submit_Click(object sender, EventArgs e)
    {
      
        int res;
        string ID = Request.QueryString["value"];
        
        int i = Convert.ToInt32(ID);
        int noe = Convert.ToInt32(txt_noE.Text);
        int yoe = Convert.ToInt32(Txt_YOE.Text);
        int ato = Convert.ToInt32(txt_Annualturnover.Text);
        int pcode = Convert.ToInt32(txt_pincode.Text);
       
        res = bizcust.Update_Customer(i,lblaid.Text,Txt_companyname.Text, Convert.ToInt32(txt_noE.Text), Convert.ToInt32(Txt_YOE.Text), Convert.ToDouble(txt_Annualturnover.Text), txt_url.Text, txt_pno.Text, txt_tno.Text, txt_cenvat.Text, txt_stax.Text, Convert.ToInt32(DDLLocation.SelectedValue),Txt_address.Text, Txt_city.Text, Txt_state.Text, Convert.ToInt32(txt_pincode.Text), Convert.ToInt32(txt_Boardno.Text), Convert.ToInt32(Txt_fax.Text), txt_Email.Text, Txt_country.Text,txt_cperson.Text,Convert.ToInt32(ddldesg.SelectedValue), txt_Mobile.Text);

        if (res == 1)
        {
            lblmsg.Visible = true;
            lblmsg.ForeColor = System.Drawing.Color.Green;
            lblmsg.Text = "Data Updated...";
            
        }
        else
        {
            lblmsg.Visible = true;
            lblmsg.ForeColor = System.Drawing.Color.Red;
            lblmsg.Text = "Data Not Updated";
        }


    }
}
