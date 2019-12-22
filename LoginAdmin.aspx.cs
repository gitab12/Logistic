using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;

public partial class LoginAdmin : System.Web.UI.Page
{
    BizCon_DB_ConnectionString con = new BizCon_DB_ConnectionString();
    string current_time = (DateTime.Now.AddHours(2)).ToString();
    string ip;
    string user_id;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Request.QueryString.Get("logout") == "1")
            {

                lbl_msg.Text = Resources.Resource.alert_success.Replace("{@message}", "You have successfully logout.");
            }
            else if (Request.QueryString.Get("expire") == "1")
            {

                lbl_msg.Text = Resources.Resource.alert_error.Replace("{@message}", "Your login session expired, Please login again !");
            }
        }
        catch
        {

        }
    }
    protected void btn_login_Click(object sender, EventArgs e)
    {
        int count = 0;
        try
        {
            string userunique_id = "";
            string mobile = "";
            string email = "";
            string db_username = "";
            string role_id = "";
            string passworddb = "";
            string passPhrase = "";
            string saltValue = "";
            string status_id = "0";
            string name = "";
            string dp_image = "";
            string username = txt_username.Text.Trim();
            string password = txt_password.Text.Trim();
            string department_id = "";
            if (username != "" && password != "")
            {
                string[] Args = { "@username" };
                string[] ArgsVal = { username };
                try
                {
                    DataSet ds_login = con.Sql_GetData("SP_Login", Args, ArgsVal);
                    if (ds_login.Tables[0].Rows.Count > 0)
                    {
                        db_username = ds_login.Tables[0].Rows[0]["username"].ToString();
                        status_id = ds_login.Tables[0].Rows[0]["status_id"].ToString();
                        userunique_id = ds_login.Tables[0].Rows[0]["userunique_id"].ToString();
                        role_id = ds_login.Tables[0].Rows[0]["role_id"].ToString();
                        passworddb = ds_login.Tables[0].Rows[0]["password"].ToString();     // original plaintext password
                        passPhrase = ds_login.Tables[0].Rows[0]["pass_phrase"].ToString();         // can be any string
                        saltValue = ds_login.Tables[0].Rows[0]["pass_salt"].ToString();       // can be any string
                        name = ds_login.Tables[0].Rows[0]["name"].ToString();
                        department_id = ds_login.Tables[0].Rows[0]["department_id"].ToString();
                        user_id = ds_login.Tables[0].Rows[0]["user_id"].ToString();
                        email = ds_login.Tables[0].Rows[0]["email"].ToString();
                        dp_image = ds_login.Tables[0].Rows[0]["image"].ToString();
                        mobile = ds_login.Tables[0].Rows[0]["mobile"].ToString();
                        count++;
                    }
                }
                catch (Exception ex)
                {
                    count = 0;
                }
                if (count == 0)
                {
                    lbl_msg.Text = Resources.Resource.alert_error.Replace("{@message}", "Invalid Username or Password");

                }
                else if (status_id == "0")
                {
                    lbl_msg.Text = Resources.Resource.alert_error.Replace("{@message}", Resources.Resource.login_disable);

                }
                else if (status_id == "1")
                {
                    string hashAlgorithm = ConfigurationManager.AppSettings["hashAlgorithm"];   // can be "MD5"
                    int passwordIterations = Int32.Parse(ConfigurationManager.AppSettings["passwordIterations"]);  // can be any number
                    string initVector = ConfigurationManager.AppSettings["initVector"];  // must be 16 bytes
                    int keySize = Int32.Parse(ConfigurationManager.AppSettings["keySize"]);  // can be 192 or 128
                    string passwordencrypt = EncryptionController.Decrypt(passworddb, passPhrase, saltValue, hashAlgorithm, passwordIterations, initVector, keySize);

                    if (password == passwordencrypt)
                    {

                        DateTime Expires = DateTime.Now.AddDays(365);
                        ip = HttpContext.Current.Request.UserHostAddress;
                        string login_time = (DateTime.Now).ToString();
                        string validupto = (DateTime.Now.AddHours(2)).ToString();

                        Session["UserID"] = userunique_id;
                        Session["EmailID"] = username;
                        Session["role_id"] = role_id;

                        //string[] _arg = { "@user_id", "@ip", "@sid", "@validupto", "@status_id" };
                        //string[] _argval = { user_id, ip, userunique_id, validupto, "7" };
                        try
                        {
                            //int log_details = con.Sql_ExecuteNonQuery("SP_Insert_Log", _arg, _argval);
                            if (role_id == "1")
                            {
                                Response.Redirect("DashboardAdmin.aspx");
                            }
                            else
                            {
                                Response.Redirect("DashboardUser.aspx");
                            }


                        }
                        catch (Exception ex)
                        {

                        }

                    }
                    else
                    {

                        lbl_msg.Text = Resources.Resource.alert_error.Replace("{@message}", Resources.Resource.login_error);

                    }

                }
            }

        }

        catch
        {

            lbl_msg.Text = Resources.Resource.alert_error.Replace("{@message}", Resources.Resource.login_error);

        }
    }
}