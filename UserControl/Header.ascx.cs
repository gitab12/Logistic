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

public partial class UserControl_Header : System.Web.UI.UserControl
{
    UserAuthentication obj_Class = new UserAuthentication();
    //BizConnectClass
    Int32 obj_Response;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.Cookies["username"] != null && Request.Cookies["password"] != null)
            {
                txtUserID.Text = Request.Cookies["username"].Value;
                txtPassword.Attributes["value"] = Request.Cookies["password"].Value;
            }
        }
    }
    
    protected void login_Click(object sender, EventArgs e)
    {

        if (remember.Checked==true)
        {
            Response.Cookies["username"].Value = txtUserID.Text.Trim();
            Response.Cookies["password"].Value = txtPassword.Text.Trim();

            Response.Cookies["username"].Expires = DateTime.Now.AddDays(30);
            Response.Cookies["password"].Expires = DateTime.Now.AddDays(30);
        }
        else
        {
            Response.Cookies["username"].Value = txtUserID.Text.Trim();
            Response.Cookies["password"].Value = txtPassword.Text.Trim();

            Response.Cookies["username"].Expires = DateTime.Now.AddDays(-1);
            Response.Cookies["password"].Expires = DateTime.Now.AddDays(-1);

        }
        




        
        if (txtUserID.Text.Trim() != "" && txtUserID.Text.Trim() != "Enter Email Id")
        {

            try
            {

                //Int32 smsresp = 3;
                //OLD CODE
                //    ArrayList  list =new ArrayList() ;
                //    obj_Response = 0;
                //    list = obj_Class.Verify_User(txtUserID.Text.Trim(), txtPassword.Text.Trim());
                //    if (list[0].ToString()=="1")
                //    {
                //        Session["name"] = list[1];
                //        Session["Authenticated"] = "1";
                //        Session["EmailID"] = txtUserID.Text.Trim();
                //        Session["ClientID"] = list[2];
                //        Session["ClientCode"] = list[3];
                //        Session["UserID"] = list[4];
                //        Session["ClientName"] = list[5];
                //        Response.Redirect("Dashboard.aspx");
                //    }
                //    else
                //    {
                //        //UserIDValidator.ErrorMessage = "Invalid User,Please Try again...!";
                //        //UserIDValidator.Width = 200;
                //        //UserIDValidator.IsValid = false;
                //        lblmsg.Visible = true;
                //        lblmsg.Text = "Invalid UserName and Password.....";
                //    }
                //}

                //NEW CODE

                ArrayList list = new ArrayList();
                obj_Response = 0;
                //Check weather the user is aarms or client
                list = obj_Class.Verify_Usertype(txtUserID.Text.Trim(), txtPassword.Text.Trim());

                Session["name"] = list[1];
                Session["Authenticated"] = "1";
                Session["EmailID"] = txtUserID.Text.Trim();
                Session["UserID"] = list[2];
                Session["AarmsUser"] = list[3];

                if (Session["AarmsUser"].ToString() == "True")
                {
                    Response.Redirect("AARMSPage.aspx");
                }



                if (list[0].ToString() == "1")
                {
                    //Check Services
                    obj_Response = obj_Class.CheckService(Session["UserID"].ToString(), 1);
                    if (obj_Response == 1)
                    {
                        Response.Redirect("Aarmstripplan.aspx");
                    }
                    else
                    {
                        //lblmsg.Text = "No permission to access this site!.....";
                         Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('No permission to access this site!.....');</script>");
                    }


                }
                else
                {

                    list = obj_Class.Verify_User(txtUserID.Text.Trim(), txtPassword.Text.Trim());



                    if (list[0].ToString() == "1")
                    {
                        Session["name"] = list[1];
                        Session["Authenticated"] = "1";
                        Session["EmailID"] = txtUserID.Text.Trim();
                        Session["ClientID"] = list[2];
                        Session["ClientCode"] = list[3];
                        Session["UserID"] = list[4];
                        Session["ClientName"] = list[5];
                        Session["AarmsUser"] = list[6];
                        Session["ClientAdrID"] = list[7];
                        if (Convert.ToInt32(Session["UserID"].ToString()) != 2)
                        {
                            if (Convert.ToInt32(Session["ClientID"].ToString()) == 1140)
                            {
                                Response.Redirect("Biddingstatus.aspx",false );
                            }
                            else
                            {
                                Response.Redirect("Dashboard.aspx", false);
                                txtUserID.Text = "";
                                txtPassword.Text = "";
                            }
                        }
                        else
                        {
                            Response.Redirect("AArmsDashboard.aspx",false );
                            txtUserID.Text = "";
                            txtPassword.Text = "";
                        }

                    }

                    else
                    {
                        //UserIDValidator.ErrorMessage = "Invalid User,Please Try again...!";
                        //UserIDValidator.Width = 200;
                        //UserIDValidator.IsValid = false;
                       // lblmsg.Visible = true;
                       // lblmsg.Text = "Invalid User Name and Password.....";
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Invalid User Name and Password.....');</script>");
                    }

                }

            }
            catch (Exception ex)
            {
               // lblmsg.Visible = true;
               // lblmsg.Text = "Invalid User Name and Password.....";
               
                Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Invalid User Name and Password.....');</script>");
            }

        }
        else
        {
           // lblmsg.Visible = true;
           // lblmsg.Text = "Enter User Name and Password.....";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Enter User Name and Password.....');</script>");
        }    

   }

    
}