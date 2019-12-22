using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class AARMSPage : System.Web.UI.Page
{
    string obj_Authenticated;
    PlaceHolder maPlaceHolder;
    UserControl obj_Tabs;
    UserControl obj_LoginCtrl;
    UserControl obj_WelcomCtrl;
    UserControl obj_Navi;
    UserControl obj_Navihome;
    AarmsUser obj_Class = new AarmsUser();
    BizConnectClass obj = new BizConnectClass();
    string Transporter;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] != string.Empty && Convert.ToInt32(Session["UserID"].ToString()) > 0)
        {
            if (!IsPostBack)
            {           
            ChkAuthentication();
            txtappdate.Text=DateTime.Now.ToString();            
            pnloperate.Visible = false;
            txtcalendar.Text = DateTime.Now.ToString("MM/dd/yyyy");
            txtactiondate.Text = DateTime.Now.ToString("MM/dd/yyyy");
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
    }
    public void SetVisualOFF()
    {
        obj_LoginCtrl.Visible = true;
        obj_WelcomCtrl.Visible = false;
    }

  protected void Button1_Click(object sender, EventArgs e)
  {
   
    if (Session["UserID"] != string.Empty && Convert.ToInt32(Session["UserID"].ToString()) > 0)
    {
     try
     {
      int resp = obj_Class.Bizconnect_InsertActivity(txtclient.Text, txtlocation.Text, txtindustry.Text, txtcontactperson.Text, txtMobile.Text, txtDept.Text, Session["name"].ToString(), Convert.ToDateTime(txtappdate.Text),txtemail.Text,ddlActionList.SelectedItem.Text,txtremarks.Text);
      if(resp==1)
     {
      txtclient.Text=""; 
      txtlocation.Text="";  
      txtindustry.Text="";  
      txtcontactperson.Text=""; 
      txtMobile.Text=""; 
      txtDept.Text=""; 
      txtemail.Text=""; 
      txtremarks.Text=""; 
      ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Insert Successfully');</script>");
     }
    }   
              
   catch(Exception ex)
   {
   
   }
  } 
   else
    {
       ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Session Expired! Please Login again');</script>");
    }  
    
}
   protected void Butstatus_Click(object sender, EventArgs e)
    {
        Response.Redirect("statusUpdate.aspx");
    }
   protected void radoperations_CheckedChanged(object sender, EventArgs e)
   {
       Get_transporter();
       pnlmarket.Visible = false;
       pnloperate.Visible = true;
   }
   protected void radmarketing_CheckedChanged(object sender, EventArgs e)
   {
       pnloperate.Visible = false;
       pnlmarket.Visible = true;
   }

   public void Get_transporter()
   { 
       DataSet ds = new DataSet();
       ds = obj.Get_BizConnect_Transporter();
       chkbl_Transporter.DataSource = ds;
       chkbl_Transporter.DataValueField = "TID";
       chkbl_Transporter.DataTextField = "Tname";       
       chkbl_Transporter.DataBind();
   }
   protected void btnsave_Click(object sender, EventArgs e)
   {
       try
       {
         int rebid=0;

           if(radYes.Checked == true)
        {
           rebid = 1;
        }
        else if(radYes.Checked== true)
        {
           rebid =2;
        }
           int resp = obj_Class.Bizconnect_InsertAARMSOperation(Convert.ToDateTime(txtcalendar.Text), txtclientname.Text, Convert.ToDateTime(txttripdate.Text),save_Transporter(), Convert.ToInt32(txtquotereceived.Text), Convert.ToDateTime(txtactiondate.Text), rebid, txtaction.Text,Session["name"].ToString());
           if (resp == 1)
           {
               ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Insert Successfully');</script>");
               clearfields();
           }
       }

       catch (Exception ex)
       {

       }
   }
   
   public string save_Transporter()
   {
       for (int i = 0; i < chkbl_Transporter.Items.Count; i++)
       {
           if (chkbl_Transporter.Items[i].Selected)
           {
               Transporter = Transporter + chkbl_Transporter.Items[i].Text + ",";
           }
       }
       int j = Transporter.Length;
       Transporter = Transporter.Remove(j - 1);
       return Transporter;
   }
   protected void btn_Report_Click(object sender, EventArgs e)
   {
       Response.Redirect("~/AARMSPageReport.aspx");
   }
   public void clearfields()
   {
       txtcalendar.Text = "";
       txtclientname.Text = "";
       txttripdate.Text = "";
       chkbl_Transporter.SelectedIndex = -1;
       chkbl_Transporter.ClearSelection();
       txtquotereceived.Text = "";
       txtaction.Text = "";
   }
}
