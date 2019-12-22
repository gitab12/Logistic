using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Configuration;

public partial class Login : System.Web.UI.Page
{
     UserAuthentication obj_Class = new UserAuthentication();
    //BizConnectClass
    Int32 obj_Response;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    // web  method call for login 

    [System.Web.Services.WebMethod]
    public static String log(string emailid, string Password)
    
    {
        UserAuthentication obj_Class = new UserAuthentication();
        //BizConnectClass
        Int32 obj_Response;
     
        try
        {


            //NEW CODE

            ArrayList list = new ArrayList();
            obj_Response = 0;
            //Check weather the user is aarms or client
            list = obj_Class.Verify_Usertype(emailid, Password);

            HttpContext.Current.Session["name"] = list[1];
            HttpContext.Current.Session["Authenticated"] = "1";
            HttpContext.Current.Session["EmailID"] = emailid;
            HttpContext.Current.Session["UserID"] = list[2];
            HttpContext.Current.Session["AarmsUser"] = list[3];
            HttpContext.Current.Session["IsprimaryUser"] = list[4];
            if (HttpContext.Current.Session["AarmsUser"].ToString() == "True")
            {
               // Response.Redirect("AARMSPage.aspx");
                return "done2";
            }



            if (list[0].ToString() == "1")
            {
                //Check Services
                obj_Response = obj_Class.CheckService(HttpContext.Current.Session["UserID"].ToString(), 1);
                if (obj_Response == 1)
                {
                    //Response.Redirect("Aarmstripplan.aspx");
                    return "done3";
                }
                else
                {
                    //lblmsg.Text = "No permission to access this site!.....";
                    return "0";
                }


            }
            else
            {

                list = obj_Class.Verify_User(emailid, Password);



                if (list[0].ToString() == "1")
                {
                    HttpContext.Current.Session["name"] = list[1];
                    HttpContext.Current.Session["Authenticated"] = "1";
                    HttpContext.Current.Session["EmailID"] = emailid;
                    HttpContext.Current.Session["ClientID"] = list[2];
                    HttpContext.Current.Session["ClientCode"] = list[3];
                    HttpContext.Current.Session["UserID"] = list[4];
                    HttpContext.Current.Session["ClientName"] = list[5];
                    HttpContext.Current.Session["AarmsUser"] = list[6];
                    HttpContext.Current.Session["ClientAdrID"] = list[7];
                    if (Convert.ToInt32(HttpContext.Current.Session["UserID"].ToString()) != 2)
                    {
                        if (Convert.ToInt32(HttpContext.Current.Session["ClientID"].ToString()) == 1139)
                        {
                            //Response.Redirect("Biddingstatus.aspx");
                            return "done4";
                        }
                        else
                        {
                           // Response.Redirect("Dashboard.aspx");
                            return "done";
                        }
                    }
                    else
                    {
                       // Response.Redirect("AArmsDashboard.aspx");
                        return "done1";
                    }

                }

                else
                {
                    //UserIDValidator.ErrorMessage = "Invalid User,Please Try again...!";
                    //UserIDValidator.Width = 200;
                    //UserIDValidator.IsValid = false;
                  //  lblmsg.Visible = true;
                   // lblmsg.Text = "Invalid User Name and Password.....";
                    return "0";
                }

            }

        }
        catch (Exception ex)
        {
           // lblmsg.Visible = true;
            //lblmsg.Text = "Invalid User Name and Password.....";
            return "0";
        }





    }

   


}