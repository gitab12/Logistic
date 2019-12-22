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
using System.Data.SqlClient ;
using System.IO;
using AjaxControlToolkit;
using System.Threading;
using System.Security.Cryptography;
using System.Text;


public partial class ReceivingInfo : System.Web.UI.Page
{

    string obj_Authenticated;
    PlaceHolder maPlaceHolder;
    UserControl obj_Tabs;
    UserControl obj_LoginCtrl;
    UserControl obj_WelcomCtrl;
    UserControl obj_Navi;
    UserControl obj_Navihome;
    DataSet ds = new DataSet();
    AARMEmail.EmailControl mail = new AARMEmail.EmailControl();
    BizCon_DB_ConnectionString con = new BizCon_DB_ConnectionString();
    string Email = "";
    string toemail;
    int clientid;
    int ConfID;
    string imagePath="";
    byte[] bytes1, bytes2, bytes3, bytes4;
    string ext, filename;

    private static string EncryptionKey = "!#853g`de";
    private static byte[] key = { };
    private static byte[] IV = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
    
    EncryptAndDecryot obj = new EncryptAndDecryot();

    TripAcceptance obj_class = new TripAcceptance();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
			try
			{
            ChkAuthentication();
            // clientid = Convert.ToInt32(obj.Decrypt(Request.QueryString["Cid"].ToString()));
             //ConfID = Convert.ToInt32(obj.Decrypt(Request.QueryString["ConfID"].ToString()));
            demo.Visible = false;
            btn_Upload.Visible = false;
            btn_show.Visible = false;
            clientid = Convert.ToInt32(obj.Decrypt(Request.QueryString["Cid"].ToString()));
            ConfID = Convert.ToInt32(obj.Decrypt(Request.QueryString["ConfID"].ToString()));
             Session["ClientID"]=clientid;
             Session["ConfID"] = ConfID;
            LoadDetails();
           Session["FileCtrl"] = "0";
			}
			catch(Exception ex)
			{
			}


        }
    }

    public void LoadDetails()
    {
        try
        {
            ds = new DataSet();
            ds.Clear();
            ds = obj_class.Bizconnect_Receivedinfo(clientid, 0,ConfID );//Convert.ToInt32( Request.QueryString["CLAID"].ToString()), Convert.ToInt32( Request.QueryString["COFID"].ToString()));
            Gridwindow.DataSource = ds;
            Gridwindow.DataBind();
        }
        catch (Exception ex)
        {
        }
    }

    protected void ButSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            Button b = (Button)sender;
            GridViewRow row = (GridViewRow)b.NamingContainer;
            if (row != null)
            {
                Label Accepid = (Label)Gridwindow.Rows[row.RowIndex].FindControl("lblplanID");
                Label lblplid = (Label)Gridwindow.Rows[row.RowIndex].FindControl("lblplid");
                Label LRNumber = (Label)Gridwindow.Rows[row.RowIndex].FindControl("lblLRno");
                Session["LRNumber"]=LRNumber.Text;
                TextBox txtReceivedDate = (TextBox)Gridwindow.Rows[row.RowIndex].FindControl("txtReceivedDate");
                Session["ReceivedDate"]=txtReceivedDate.Text;
                Label lbltoloc=(Label)Gridwindow.Rows[row.RowIndex].FindControl("lbltoloc");
                Session["lbltoloc"]=lbltoloc.Text;
                TextBox Remarks = (TextBox)Gridwindow.Rows[row.RowIndex].FindControl("txtRemarks");
                Session["Remarks"]=Remarks.Text;
                TextBox txtUnloadingDate = (TextBox)Gridwindow.Rows[row.RowIndex].FindControl("dt1");
                TextBox txtvehicleNo = (TextBox)Gridwindow.Rows[row.RowIndex].FindControl("txtvehicleNo");
                Button ButSubmit = (Button)Gridwindow.Rows[row.RowIndex].FindControl("ButSubmit");
                
                 if (Session["FileCtrl"] == "0")
                {
                    FileUpload FileCtrl1 = (FileUpload)Gridwindow.Rows[row.RowIndex].FindControl("FileUpload1");
                    Session["FileCtrl"] = (FileUpload)FileCtrl1;
                }

                FileUpload FileCtrl = (FileUpload)Session["FileCtrl"];
                
                string[] arr = new string[5];
                string[] patharray = new string[5];
                patharray = MultipleUploadClass.staticvar.Split('@');
                string[] filenamearray = new string[5];

                if (patharray.Length == 1)
                {
                    int resp = obj_class.Bizconnect_InsertReceivingDetails(Convert.ToInt32(lblplid.Text), Convert.ToInt32(Accepid.Text), LRNumber.Text, Convert.ToDateTime(txtReceivedDate.Text), Remarks.Text, Convert.ToDateTime(txtUnloadingDate.Text), txtvehicleNo.Text,0);
                }

                else
                {
                    if (patharray.Length == 5)
                    {
                        for (int i = 1; i <= 4; i++)
                        {
                            string filePath = patharray[i];
                            filename = Path.GetFileName(filePath);
                            filenamearray[i] = filename;
                            ext = Path.GetExtension(filename);
                            string contenttype = String.Empty;
                            //Set the contenttype based on File Extension

                            switch (ext)
                            {

                                case ".JPG":

                                    contenttype = "image/jpg";

                                    break;
                                case ".jpg":

                                    contenttype = "image/jpg";

                                    break;
                                case ".png":

                                    contenttype = "image/png";

                                    break;

                                case ".gif":

                                    contenttype = "image/gif";

                                    break;
                            }

                            if (contenttype != String.Empty)
                            {
                                arr[i] = "1";
                                if (patharray[1] != null && i == 1)
                                {
                                    FileStream fs1 = new FileStream(patharray[1], FileMode.Open, FileAccess.Read);
                                    BinaryReader br1 = new BinaryReader(fs1);


                                    bytes1 = br1.ReadBytes((Int32)fs1.Length);
                                }
                                else
                                {
                                    //bytes1 = null;
                                }
                                if (patharray[2] != null && i == 2)
                                {
                                    FileStream fs2 = new FileStream(patharray[2], FileMode.Open, FileAccess.Read);
                                    BinaryReader br2 = new BinaryReader(fs2);

                                    bytes2 = br2.ReadBytes((Int32)fs2.Length);
                                }
                                else
                                {
                                    //bytes2 = null;
                                }
                                if (patharray[3] != null && i == 3)
                                {
                                    FileStream fs3 = new FileStream(patharray[3], FileMode.Open, FileAccess.Read);
                                    BinaryReader br3 = new BinaryReader(fs3);

                                    bytes3 = br3.ReadBytes((Int32)fs3.Length);
                                }
                                else
                                {
                                    //bytes3 = null;
                                }
                                if (patharray[4] != null && i == 4)
                                {
                                    FileStream fs4 = new FileStream(patharray[4], FileMode.Open, FileAccess.Read);
                                    BinaryReader br4 = new BinaryReader(fs4);

                                    bytes4 = br4.ReadBytes((Int32)fs4.Length);
                                }
                                else
                                {
                                    //bytes4 = null;
                                }

                            }
                            else
                            {
                                arr[i] = "0";                             

                            }


                        }

                        int resp = obj_class.Bizconnect_InsertReceivingDetailsWithImage(Convert.ToInt32(lblplid.Text), Convert.ToInt32(Accepid.Text), LRNumber.Text, Convert.ToDateTime(txtReceivedDate.Text), Remarks.Text, Convert.ToDateTime(txtUnloadingDate.Text), txtvehicleNo.Text, bytes1, bytes2, bytes3, bytes4);
                       
                    }
                    else
                    {
                        this.Page.ClientScript.RegisterStartupScript(typeof(Page), "notification", "window.alert('Please Select 4 Images');", true);
                    }
                }
                MultipleUploadClass.staticvar = "";
                this.Page.ClientScript.RegisterStartupScript(typeof(Page), "notification", "window.alert('Data Stored Successfully');", true);
                LoadDetails();
                Sendmail();         

            }

        }
        catch (Exception ex)
        {
            MultipleUploadClass.staticvar = "";
        }

        
       
    }
protected void link_preview_Click(object sender, EventArgs e)
    {
        LinkButton b = (LinkButton)sender;
        GridViewRow row = (GridViewRow)b.NamingContainer;
        if (row != null)
        {
         FileUpload FileCtrl = (FileUpload)Gridwindow.Rows[row.RowIndex].FindControl("FileUpload1");
         FileUpload FileCtrlRear = (FileUpload)Gridwindow.Rows[row.RowIndex].FindControl("FileUpload2");
         FileUpload FileCtrlSideL = (FileUpload)Gridwindow.Rows[row.RowIndex].FindControl("FileUpload3");
         FileUpload FileCtrlSideR = (FileUpload)Gridwindow.Rows[row.RowIndex].FindControl("FileUpload4");
         Image imagebox = (Image)Gridwindow.Rows[row.RowIndex].FindControl("Image1");
            Session["FileCtrl"] = FileCtrl;
            Session["FileCtrlRear"] = FileCtrlRear;
            Session["FileCtrlSideL"] = FileCtrlSideL;
            Session["FileCtrlSideR"] = FileCtrlSideR;
            if (FileCtrl.HasFile)
            {
                string path = Server.MapPath("TempImages");

                FileInfo oFileInfo = new FileInfo(

                      FileCtrl.PostedFile.FileName);
                string fileName = oFileInfo.Name;

                string fullFileName = path + "\\" + fileName;
                string imagePath = "TempImages/" + fileName;

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                FileCtrl.PostedFile.SaveAs(fullFileName);
                imagebox.ImageUrl = imagePath;
            }
      
          
            //OpenNewWindow1();
        }
    }
    public void OpenNewWindow1()
    {


        ClientScript.RegisterStartupScript(this.GetType(), "OpenWin", "<script>window.open('ImagePreview.aspx', 'mynewwin', 'width=950,height=350,scrollbars=yes,toolbar=1')</script>");
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
        //obj_Navihome.Visible = true;

    }
    public void SetVisualOFF()
    {
        obj_LoginCtrl.Visible = true;
        obj_WelcomCtrl.Visible = false;
        // obj_Navi.Visible = true;
        //obj_Navihome.Visible = false;

        //Session["ClientID"] = Request.QueryString["CLID"].ToString();
       // Session["ClientAdrID"] = Request.QueryString["CLAID"].ToString();

    }
    public void SetOFF()
    {
        try
        {

            //Session["ClientID"] = Request.QueryString["CLID"].ToString();
           // Session["ClientAdrID"] = Request.QueryString["CLAID"].ToString();
        }
        catch (Exception ex)
        {
        }
    }

    protected void Image1_Click(object sender, ImageClickEventArgs e)
    {
        //Session["ImageID"]
        ImageButton b = (ImageButton)sender;
        GridViewRow row = (GridViewRow)b.NamingContainer;
        if (row != null)
        {
            Label imgid = (Label)Gridwindow.Rows[row.RowIndex].FindControl("lblplanID");
            Session["ImageID"] = imgid.Text;
            OpenNewWindow();
        }
    }

    public void OpenNewWindow()
    {


        ClientScript.RegisterStartupScript(this.GetType(), "OpenWin", "<script>window.open('TruckImage.aspx?imgID=" + Session["ImageID"].ToString() + "', 'mynewwin', 'width=900,height=1000,scrollbars=yes,toolbar=1')</script>");
    }
    
     protected void btnSearch_Click(object sender, EventArgs e)
    {
       try
        {
            DataSet ds = new DataSet();
            ds = obj_class.Bizconnect_SearchReceivedinfobyLRNumber(Convert.ToInt32(Session["clientid"].ToString()), txtSearch.Text);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Gridwindow.DataSource = ds;
                Gridwindow.DataBind();
            }
            else
            {
                demo.Visible = true;
                btn_Upload.Visible = true;
                btn_show.Visible = true;

            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = "No Records Matching with LRNumber";
        }
    }
    
    

   public void Sendmail()
    {
        DataTable dt = new DataTable();
        dt = obj_class.Bizconnect_GetUniqueClientEmail(Convert.ToInt32(Session["ClientID"].ToString()));
        string obj_Message = "This is to inform that the vehicle has  reached the destination["+ Session["lbltoloc"].ToString() +" ]on " + Session["ReceivedDate"].ToString() + " <br>\nRemarks:" + Session["Remarks"].ToString() + " ";
         string Conn = ConfigurationManager.ConnectionStrings["BizCon"].ConnectionString;
          SqlConnection conn = new SqlConnection();
        conn.ConnectionString = Conn;
        conn.Open();
       
        SqlCommand cmd = new SqlCommand();
        string qry = "select Emailid,password from Clients_EmailID where clientID='" + Session["ClientID"].ToString() + " ' ";
        cmd = new SqlCommand(qry, conn);
        SqlDataReader mydatareader;
        mydatareader = cmd.ExecuteReader();
        mydatareader.Read();
        
            toemail = dt.Rows[0].ItemArray[0].ToString() ;
        
        if (mydatareader.HasRows)
        {
            mail.SendEmail(toemail, mydatareader.GetValue(0).ToString(), mydatareader.GetValue(1).ToString(), "", "", "tripschedule@scmbizconnect.com", "bounceback@scmjunction.com", "Receiving Information-LRNumber : " + Session["LRNumber"].ToString() + "", obj_Message.ToString().Trim(), System.Web.Mail.MailFormat.Html, System.Web.Mail.MailPriority.High, "smtp.gmail.com", "465", "2", "1", true, "");
        }

        else
        {
            mail.SendEmail(toemail, "tripschedule@scmbizconnect.com", "tripschedule123", "", "", "tripschedule@scmbizconnect.com", "bounceback@scmjunction.com", "Receiving Information-LRNumber : " + Session["LRNumber"].ToString() + "", obj_Message.ToString().Trim(), System.Web.Mail.MailFormat.Html, System.Web.Mail.MailPriority.High, "smtp.gmail.com", "465", "2", "1", true, "");
        }

    }
   protected void btn_Upload_Click(object sender, EventArgs e)
   {
       try
       {
           FileInfo fi = new FileInfo(FileUpload1.FileName);
           byte[] documentcontent = FileUpload1.FileBytes;

           string name = fi.Name;
           string extn = fi.Extension;


           string lrnumber = txtSearch.Text;
           string[] args = { "@lrnumber" };
           string[] argsval = { lrnumber };
           DataSet ds = new DataSet();
           ds = con.Sql_GetData("SP_Get_Plid", args, argsval);
           string plid = ds.Tables[0].Rows[0]["PLid"].ToString();
           string Conn = ConfigurationManager.ConnectionStrings["BizCon"].ConnectionString;
           using (SqlConnection cn = new SqlConnection(Conn))
           {
               SqlCommand cmd = new SqlCommand("SP_Update_POD_in_Preloaddetails", cn);
               cmd.CommandType = CommandType.StoredProcedure;

               cmd.Parameters.AddWithValue("@name", name);
               cmd.Parameters.AddWithValue("@documentcontent", documentcontent);
               cmd.Parameters.AddWithValue("@extn", extn);
               cmd.Parameters.AddWithValue("@plid", plid);

               cn.Open();
               cmd.ExecuteNonQuery();
               lbl_msg.ForeColor = System.Drawing.Color.Green;
               lbl_msg.Text = "File Uploaded Successfully";


           }

              

           

       }
       catch (Exception ex)
       {


       }
       finally
       {


       }
   }
   protected void btn_show_Click(object sender, EventArgs e)
   {
       try
       {
           SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["BizCon"].ConnectionString);
           conn.Open();
           string lrnumber = txtSearch.Text;
           string qrye = "select PLid FROM Bizconnect_PreloadDetails WHERE  LRNumber='" + lrnumber + "' and ReceivedFlg=1 ";
           SqlCommand cmde = new SqlCommand(qrye, conn);
           cmde.ExecuteNonQuery();
           DataTable dt = new DataTable();
           SqlDataAdapter adp = new SqlDataAdapter(cmde);
           adp.Fill(dt);
           lbl_msg.Visible = false;

           string idd = Encrypt(dt.Rows[0][0].ToString());
           string embed = "<center><object data=\"{0}{1}\" type=\"application/pdf\" width=\"1200px\" height=\"600px\">";
           embed += "If you are unable to view file, you can download from <a href = \"{0}{1}&download=1\">here</a>";
           embed += " or download <a target = \"_blank\" href = \"http://get.adobe.com/reader/\">Adobe PDF Reader</a> to view the file.";
           embed += "</object>";
           ltEmbed.Text = string.Format(embed, ResolveUrl("~/PDFHandler.ashx?PLid="), idd);

       }
       catch (Exception ex)
       {

       }
       finally
       {

       }
   }

   public string Encrypt(string Input)
   {
       try
       {
           key = System.Text.Encoding.UTF8.GetBytes(EncryptionKey.Substring(0, 8));
           DESCryptoServiceProvider des = new DESCryptoServiceProvider();
           Byte[] inputByteArray = Encoding.UTF8.GetBytes(Input);
           MemoryStream ms = new MemoryStream();
           CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(key, IV), CryptoStreamMode.Write);
           cs.Write(inputByteArray, 0, inputByteArray.Length);
           cs.FlushFinalBlock();
           return Convert.ToBase64String(ms.ToArray());
       }
       catch (Exception ex)
       {
           return "";
       }
   }

}
