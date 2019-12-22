using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.Security;

using System.Web.UI.WebControls;

public partial class AddUser : System.Web.UI.Page
{

    string obj_Authenticated;
    PlaceHolder maPlaceHolder;

    UserControl obj_Tabs;
    UserControl obj_LoginCtrl;
    UserControl obj_WelcomCtrl;
    UserControl obj_Navi;
    UserControl obj_Navihome;

    protected void Page_Load(object sender, EventArgs e)
    {
        //Checking Login Detail start Here//
        if (!IsPostBack)
        {
       
        if (Session["ClientID"] != string.Empty && Convert.ToInt32(Session["ClientID"].ToString()) > 0)
      //if(1==1)  
        {
            ChkAuthentication();
            //Populate Dgination//
            PopulateDesigDropDownList();
            
        }

        else
        {
            Response.Redirect("Index.aspx");
        }
        //checking Login Detail End Here//


                
           
                
         }
    }

    private void PopulateDesigDropDownList()
    {
        ddlDesignation.DataSource = GetData("Get_BizConnect_DesignationMasterAll");
        ddlDesignation.DataBind();

        ListItem lidesignation = new ListItem("Select", "-1");
        ddlDesignation.Items.Insert(0, lidesignation);

        }

    private DataSet GetData(string SPName)
    {
        string CSD = ConfigurationManager.ConnectionStrings["BizCon"].ConnectionString;
        SqlConnection cone = new SqlConnection(CSD);
        SqlDataAdapter da = new SqlDataAdapter(SPName, cone);
        da.SelectCommand.CommandType = CommandType.StoredProcedure;
        
        DataSet DS = new DataSet();
        da.Fill(DS);
        return DS;
    }

    protected void RegisterUser(object sender, EventArgs e)
    {

        try
        {
            string CST = ConfigurationManager.ConnectionStrings["BizCon"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(CST))
            {
                SqlCommand cmda = new SqlCommand("Insert_BizConnect_UserLogDB", conn);
                cmda.CommandType = CommandType.StoredProcedure;
                SqlParameter paramFN = new SqlParameter("obj_FirstName", txtFname.Text);
                SqlParameter paramMN = new SqlParameter("obj_MiddleName", Label4.Text);
                SqlParameter paramLN = new SqlParameter("obj_LastName", txtLname.Text);
                SqlParameter paramGE = new SqlParameter("obj_GenderID", ddlGender.SelectedValue);
                SqlParameter paramDP = new SqlParameter("obj_Department", ddlDepartment.SelectedItem.Text);
                SqlParameter paramDG = new SqlParameter("obj_DesignationID", ddlDesignation.SelectedItem.Value);
                SqlParameter paramEM = new SqlParameter("obj_EmailID", txtEmail.Text);
                SqlParameter paramPW = new SqlParameter("obj_Password", txtPassword.Text);
                SqlParameter paramMO = new SqlParameter("obj_Mobile", txtMobile.Text);
                SqlParameter paramPH = new SqlParameter("obj_Phone", txtPhone.Text);
                SqlParameter paramAG = new SqlParameter("obj_Age", Label2.Text);
                SqlParameter paramAA = new SqlParameter("@obj_Aarmsrep", Label2.Text);
                cmda.Parameters.Add(paramFN);
                cmda.Parameters.Add(paramMN);
                cmda.Parameters.Add(paramLN);
                cmda.Parameters.Add(paramGE);
                cmda.Parameters.Add(paramDP);
                cmda.Parameters.Add(paramDG);
                cmda.Parameters.Add(paramEM);
                cmda.Parameters.Add(paramPW);
                cmda.Parameters.Add(paramMO);
                cmda.Parameters.Add(paramPH);
                cmda.Parameters.Add(paramAG);
                cmda.Parameters.Add(paramAA);
                cmda.Parameters.Add("@UserId", SqlDbType.Int).Direction = ParameterDirection.Output;
                conn.Open();
                int success = cmda.ExecuteNonQuery();
                string userid = cmda.Parameters["@UserId"].Value.ToString();
                
                Label3.Text = userid;
                if (success == 0)
                {
                    Label1.Text = "Something Went Wrong Try again";
                }
                else
                {
                    string ClientId = Session["ClientID"].ToString();
                    string CSTR = ConfigurationManager.ConnectionStrings["BizCon"].ConnectionString;
                    using (SqlConnection conec = new SqlConnection(CSTR))
                    {
                        SqlCommand cmds = new SqlCommand("Insert_BizConnect_UserClientCustomerMapping", conec);
                        cmds.CommandType = CommandType.StoredProcedure;
                        SqlParameter paramUID = new SqlParameter("obj_UserID", Label3.Text);
                        SqlParameter paramCID = new SqlParameter("obj_ClientID", ClientId);
                        cmds.Parameters.Add(paramUID);
                        cmds.Parameters.Add(paramCID);
                        conec.Open();
                        cmds.ExecuteNonQuery();
                        
                    }

                }
            }
            Label1.Text = "Added Successfully";

        }
        catch (Exception ex)
        {
            throw ex;
        }

      
    }


    // test//
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
        //  obj_Navihome.Visible = true;

    }
    public void SetVisualOFF()
    {
        obj_LoginCtrl.Visible = true;
        obj_WelcomCtrl.Visible = false;
        //obj_Navi.Visible = true;
        //  obj_Navihome.Visible = false;
    }
    
}