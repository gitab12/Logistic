using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using System.Collections;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;



using System.Data.SqlClient ;
public partial class DespatchPlan : System.Web.UI.Page
{
    string obj_Authenticated;
    PlaceHolder maPlaceHolder;
    UserControl obj_Tabs;
    UserControl obj_LoginCtrl;
    UserControl obj_WelcomCtrl;
    UserControl obj_Navi;
    UserControl obj_Navihome;
    EncryptAndDecryot obj = new EncryptAndDecryot();
      BizConnectClient obj_client = new BizConnectClient();
    float checktotal = 0;
    AARMEmail.EmailControl mail = new AARMEmail.EmailControl();
    string Email = "";
    string toemail;
    
    
    string connStr = ConfigurationManager.ConnectionStrings["BizCon"].ConnectionString;
    string Conn = ConfigurationManager.ConnectionStrings["CFormCon"].ConnectionString;
    BizConnectClass bizconnect = new BizConnectClass();
    BizConnectLogisticsPlan obj_class = new BizConnectLogisticsPlan();
    TripAcceptance obj_trip = new TripAcceptance();
    BizConnectClient obj_ClientClass = new BizConnectClient();
    DataTable dt = new DataTable();
    DataTable dt_PCode = new DataTable();
    DataSet ds_Loc = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ////SqlConnection conn = new SqlConnection(connStr);
            ////conn.Open();

            ChkAuthentication();
            //try
            //{
            //    int clientid = Convert.ToInt32(Session["ClientID"].ToString());
            //    string qry = "select ProductDescription as ProductName,ProductID from Bizconnect_ProductMaster where clientid=" + clientid + " ";

            //    SqlCommand cmd = new SqlCommand(qry, conn);
            //    DataTable dt = new DataTable();
            //    SqlDataAdapter adp = new SqlDataAdapter(cmd);

            //    adp.Fill(dt);
            //    ddlProduct.DataSource = dt;
            //    ddlProduct.DataTextField = "ProductName";
            //    ddlProduct.DataValueField = "ProductID";
            //    ddlProduct.DataBind();
            //    ddlProduct.Items.Insert(0, new ListItem("--Select--", "0"));
            //    //  DateTime dtt = new DateTime();
            //    //  dtt = DateTime.Now.Date;
            //    //  txtdate.Text = dtt.ToString("dd-MMM-yyyy");
               CreateDataTable();
            //}
            //catch (Exception ex)
            //{
            //}
            //finally
            //{
            //    conn.Close();
            //}

            LoadProductCode();
            Load_FromLoc();
            Load_ToLoc();
        }
    }

    public void LoadProductCode()
    {
        dt = obj_trip.Bizconnect_LoadProductCode(Convert.ToInt32(Session["ClientID"].ToString()));
        ddl_ProductCode.DataSource = dt;

        ddl_ProductCode.DataValueField = "ProductID";
        ddl_ProductCode.DataTextField = "ProductCode";
        ddl_ProductCode.DataBind();
        ddl_ProductCode.Items.Insert(0, "--Select--");
    }

    public void Load_FromLoc()
    {
        ds_Loc  = obj_ClientClass.FillBankLocation();
        ddl_From.DataSource = ds_Loc;
        ddl_From.DataTextField = "City";
        ddl_From.DataBind();
        ddl_From.Items.Insert(0, new ListItem("--Select--", "0"));
    }
    public void Load_ToLoc()
    {
        ds_Loc = obj_ClientClass.FillBankLocation();
        ddl_To.DataSource = ds_Loc;
        ddl_To.DataTextField = "City";
        ddl_To.DataBind();
        ddl_To.Items.Insert(0, new ListItem("--Select--", "0"));
    }


    public void CreateDataTable()
    {
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        DataColumn PI = new DataColumn("PID");
        DataColumn PRN = new DataColumn("Product");
        DataColumn SKU = new DataColumn("SKU");
        DataColumn TD = new DataColumn("TravelDate");
        DataColumn TW = new DataColumn("Weight of Carton");
        DataColumn FM = new DataColumn("From");
        DataColumn TO = new DataColumn("To");
        DataColumn PN = new DataColumn("PlanNo");
        DataColumn NoofCt = new DataColumn("No of Cartons");
        DataColumn Qty = new DataColumn("Qty");
        DataColumn WT = new DataColumn("Total Weight");
        dt.Columns.Add(PI);
        dt.Columns.Add(PRN );
        dt.Columns.Add(SKU );
        dt.Columns.Add(TD);
        dt.Columns.Add(TW);
        dt.Columns.Add(FM);
        dt.Columns.Add(TO);
        dt.Columns.Add(PN);
        dt.Columns.Add(NoofCt);
        dt.Columns.Add(Qty);
        dt.Columns.Add(WT);
        ds.Tables.Add(dt);
        Session["data"] = ds;
    }


    protected void ddlProduct_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
        DataSet ds = new DataSet();
        ds = bizconnect.FillProductsDetails(Convert.ToInt32(ddlProduct.SelectedValue));
        txtSKU.Text=ds.Tables[0].Rows[0].ItemArray[2].ToString();
        txtweight.Text = Math.Round (Convert.ToDouble ( ds.Tables[0].Rows[0].ItemArray[8].ToString()),2).ToString();
        txtnoofqty.Text = ds.Tables[0].Rows[0].ItemArray[18].ToString();
       SqlConnection conn = new SqlConnection(connStr);
        conn.Open();
       string qry = "select max(PlanNo) from Bizconnect_DespatchPlan where ClientID="+ Convert.ToInt32(Session["ClientID"].ToString())+" ";

        SqlCommand cmd = new SqlCommand(qry, conn);
        DataSet ds2 = new DataSet();
        SqlDataAdapter adp = new SqlDataAdapter(cmd);

        adp.Fill(ds2);

        if (ds2.Tables[0].Rows[0][0] == string.Empty)
        {
            txtPlanNo.Text = "1000";
        }
        else
        {
            txtPlanNo.Text = (Convert.ToInt32(ds2.Tables[0].Rows[0].ItemArray[0].ToString()) + 1).ToString();
        }
    }
         catch
        {
            txtPlanNo.Text = "1000";
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
    protected void ButAdd_Click(object sender, EventArgs e)
    {
        DataSet ds = (DataSet)Session["data"];
        DataRow dr = ds.Tables[0].NewRow();
        dr[0] = ddlProduct.SelectedValue.ToString();
        dr[1] = ddlProduct.SelectedItem.Text;
        dr[2] = txtSKU.Text;
        String[] tokens = new String[3];
        tokens =  txtdate.Text.Split('/');
        dr[3] = tokens[2]+"/"+tokens[1]+"/"+tokens[0];
        dr[4] = txtweight.Text;
//        dr[5] = txtFrom.Text;
        dr[5] = ddl_From .SelectedItem .Text;
//        dr[6] = txtTo.Text;
        dr[6] = ddl_To .SelectedItem .Text;
        dr[7] = txtPlanNo.Text;
        dr[8] = txtqty.Text;
        dr[9] = txtnoofqty.Text;
        dr[10] = (Convert.ToDouble(txtweight.Text) * Convert.ToDouble(txtqty.Text)).ToString();

        string a = ((Convert.ToDouble(lblton.Text) + Convert.ToDouble(dr[10].ToString())) / 1000).ToString();
         lblton.Text =Math.Round ( (Convert.ToDouble(a.ToString()) + Convert.ToDouble(lblton.Text)),2).ToString();

         double Boxes = (Convert.ToDouble(lbl_TotalBoxes.Text));
         double TotalBoxes = Boxes + Convert.ToDouble(txtqty.Text);
         lbl_TotalBoxes.Text = TotalBoxes.ToString();

        ds.Tables[0].Rows.Add(dr);
        GridViewPlan.DataSource = ds;
        GridViewPlan.DataBind();
        ButSubmit.Enabled = true;
    }
    protected void ButSubmit_Click(object sender, EventArgs e)
    {
        try
        {
       
            for(int i=0 ;i<=GridViewPlan.Rows.Count-1;i++)
            {
                CheckBox Check = (CheckBox)GridViewPlan.Rows[i].FindControl("Check");
                if (Check.Checked)
                {
                  int resp = obj_class.Bizconnect_InsertDespatchPlan(Convert.ToInt32(GridViewPlan.Rows[i].Cells[1].Text), GridViewPlan.Rows[i].Cells[2].Text, Convert.ToInt32(GridViewPlan.Rows[i].Cells[3].Text), Convert.ToDateTime(GridViewPlan.Rows[i].Cells[4].Text), Convert.ToDouble(lblton.Text), GridViewPlan.Rows[i].Cells[6].Text, GridViewPlan.Rows[i].Cells[7].Text, Convert.ToInt32(GridViewPlan.Rows[i].Cells[8].Text), Convert.ToInt32(Session["ClientID"].ToString()), Convert.ToInt32(GridViewPlan.Rows[i].Cells[9].Text),Convert.ToDouble(GridViewPlan.Rows[i].Cells[11].Text), Convert.ToInt32(GridViewPlan.Rows[i].Cells[10].Text));
                }
            }
            
            DataTable mail = obj_class.Get_Bizconnect_InsertGrid(txtPlanNo.Text);
            GridMail.DataSource = mail;
            GridMail.DataBind();

            checktotal = Convert.ToSingle(lblton.Text);
            if (checktotal <= 7.0 || checktotal >= 7.2)
            {
                Sendmail();
            }
            else
            {

            }
            
            GridViewPlan.DataSource = null;
            GridViewPlan.DataBind();
            GridViewPlan.Columns.Clear();    
          
          
          lblton.Text="";
            ButSubmit.Enabled = false ;
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Data Saved Successfully');</script>");
            Session["data"] = "";
            ClearFields();
            CreateDataTable();
        }

        catch (Exception ex)
        {
        }
    }

    public void ClearFields()
    {
        txtPlanNo.Text = "";
        ddlProduct.SelectedIndex = -1;
        txtTotTons.Text = "";
        txtnoofqty.Text = "";
        txtSKU.Text = "";
        txtdate.Text = "";
        txtweight.Text = "";
        ddl_From .SelectedIndex = -1;
        ddl_To.SelectedIndex = -1;
        txtqty.Text = "";
    }

    public string GetGridviewData(GridView gv)
    {
        StringBuilder strBuilder = new StringBuilder();
        StringWriter strWriter = new StringWriter(strBuilder);
        HtmlTextWriter htw = new HtmlTextWriter(strWriter);
        gv.RenderControl(htw);
        return strBuilder.ToString();
    }
    
    public override void VerifyRenderingInServerForm(Control control)
    {

    }
    
     public void Sendmail()
    {
        SqlDataReader mydatareader;
        string body="";
        DataTable ds = new DataTable();
        ds = obj_trip.Bizconnect_GetClientEmail(Convert.ToInt32(Session["ClientID"].ToString()));
       // string obj_Message = "<pre>" + "<font size=4>" + "Please Click on the link for receiving information" + "<a href=http://www.scmbizconnect.com/ReceivingInfo.aspx?Cid=" + obj.Encrypt(Session["ClientID"].ToString()) + "> Click the link to view Receiving Information</a> </b><br/><br/>Thank You,<br/>AARMSCM SOLUTIONS PRIVATE LIMITED<br>307, 2nd floor, 100 ft ring road,<br>(above sagar clinic)<br>7th block, BSK III STAGE<br> BANGALORE-560085<br>Ph:09845497950;09739960001<br><a href=http://www.scmjunction.com>www.scmjunction.com</a> </font><br/><br/><center><a href=http://www.aaumconnect.com/> <img src=http://www.scmjunction.com/images/AaumLogo.jpg alt=ad banner></center>";
        //string obj_Message = "<pre>" + "<font size=4>" + "Despatch Plan" + GetGridviewData(GridMail);
        //Mail Compose
         string tableheader = "<table bgcolor=White bordercolor=#003366 border=1 style=width: 650px ><tr><td align=center><b>Despatch Plan</b></td></tr><tr><td align=center bgcolor=#585858><Font size=2 color=White><strong>Plan No</strong></font></td><td align=center bgcolor=#585858><Font size=2 color=White><strong>ProductName</strong></font></td><td align=center bgcolor=#585858><Font size=2 color=White><strong>SKU</strong></font></td><td align=center bgcolor=#585858><Font size=2 color=White><strong>TravelDate</strong></font></td><td align=center bgcolor=#585858><Font size=2 color=White><strong>WtofCartoon</strong></font></td><td align=center bgcolor=#585858><Font size=2 color=White><strong>Destination</strong></font></td> <td align=center bgcolor=#585858><Font size=2 color=White><strong>No of Cartons</strong></font></td><td align=center bgcolor=#585858><Font size=2 color=White><strong>Qty</strong></font></td><td align=center bgcolor=#585858><Font size=2 color=White><strong>TotalWeight</strong></font></td></tr>";
        if (GridMail.Rows.Count != 0)
                {
                
                    for (int j = 0; j <= GridMail.Rows.Count - 1; j++)
                    {
                        
                        body += "<tr><td align=center><font size=2>" + GridMail.Rows[j].Cells[0].Text + "</font></td><td align=center><font size=2>" + GridMail.Rows[j].Cells[1].Text + "</font></td><td align=center><font size=2 >" + GridMail.Rows[j].Cells[2].Text + "</font></td><td align=center><font size=2 >" + GridMail.Rows[j].Cells[3].Text + "</font></td><td align=center><font size=2>" + GridMail.Rows[j].Cells[4].Text + "</font></td><td align=center><font size=2>" + GridMail.Rows[j].Cells[6].Text + "</font></td><td align=center><font size=2>" + GridMail.Rows[j].Cells[7].Text + "</font></td><td align=center><font size=2>" + GridMail.Rows[j].Cells[8].Text + "</font></td><td align=center><font size=2>" + GridMail.Rows[j].Cells[9].Text + "</font></td></tr>";
                     

                    }
        
        }
        
        string obj_Message = "<pre>" + "<font size=4>" + "Despatch Plan" + tableheader +body.ToString()+"</table><br/>Total Tons Despatched:"+lblton.Text +"";
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = Conn;
        conn.Open();
        SqlCommand cmd = new SqlCommand();
        DataSet ds1=new DataSet();
        ds1=obj_client.Fillclientcity (Convert.ToInt32(Session["ClientID"].ToString()));
                                            
        for (int i = 0; i <ds1.Tables[0].Rows.Count; i++)
        {
            toemail = ds1.Tables[0].Rows[i].ItemArray[3].ToString() + "," + toemail;
        }
                        string qry = "select Emailid,password from Clients_EmailID where clientID='" + Session["ClientID"].ToString() + " ' ";
                        cmd = new SqlCommand(qry, conn);
                        mydatareader = cmd.ExecuteReader();

                        mydatareader.Read();
        if (mydatareader.HasRows)
        {
            mail.SendEmail(toemail, mydatareader.GetValue(0).ToString(), mydatareader.GetValue(1).ToString(), "", "", "tripschedule@scmbizconnect.com", "bounceback@scmjunction.com", "Despatch plan ", obj_Message.ToString().Trim(), System.Web.Mail.MailFormat.Html, System.Web.Mail.MailPriority.High, "smtp.gmail.com", "465", "2", "1", true, "");
        }

        else
        {
          mail.SendEmail(ds.ToString(), "maricotripschedule@scmbizconnect.com", "tripschedule", "", "", "tripschedule@scmbizconnect.com", "bounceback@scmjunction.com", "Despatch plan", obj_Message.ToString().Trim(), System.Web.Mail.MailFormat.Html, System.Web.Mail.MailPriority.High, "smtp.gmail.com", "465", "2", "1", true, "");
        } 
 //mail.SendEmail("nandha@aarmscmsolutions.com", "maricotripschedule@scmbizconnect.com", "tripschedule", "", "", "tripschedule@scmbizconnect.com", "bounceback@scmjunction.com", "Despatch plan", obj_Message.ToString().Trim(), System.Web.Mail.MailFormat.Html, System.Web.Mail.MailPriority.High, "smtp.gmail.com", "465", "2", "1", true, "");
    }
     protected void btnexport_Click(object sender, EventArgs e)
     {
         try
         {
             DataSet dt = new DataSet();
             dt = obj_class.Get_Bizconnect_LoadDespatchDetailsforDownloadToExcel(Convert.ToInt32(Session["ClientID"].ToString()));//,Session["year"].ToString(), Session["month"].ToString());
             grd_ExportToexcel.DataSource = dt;
             grd_ExportToexcel.DataBind();
             ExportGrid(grd_ExportToexcel, "DespatchPlan.xls");

         }
         catch (Exception ex)
         {
         }
       
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
         ClearControls(oGrid);

         //Show grid lines
         oGrid.GridLines = GridLines.Both;

         //Color header
         oGrid.HeaderStyle.BackColor = System.Drawing.Color.Yellow;
         oGrid.HeaderStyle.ForeColor = System.Drawing.Color.Black;

         //Render the grid to the writer
         oGrid.RenderControl(oHtmlTextWriter);

         //Write out the response (file), then end the response
         HttpContext.Current.Response.Write(oStringWriter.ToString());
         HttpContext.Current.Response.End();
     }
     private static void ClearControls(Control control)
     {
         //Recursively loop through the controls, calling this method
         for (int i = control.Controls.Count - 1; i >= 0; i--)
         {
             ClearControls(control.Controls[i]);
         }

         //If we have a control that is anything other than a table cell
         if (!(control is TableCell))
         {
             if (control.GetType().GetProperty("SelectedItem") != null)
             {
                 LiteralControl literal = new LiteralControl();
                 control.Parent.Controls.Add(literal);
                 try
                 {
                     literal.Text = (string)control.GetType().GetProperty("SelectedItem").GetValue(control, null);
                 }
                 catch
                 {
                 }
                 control.Parent.Controls.Remove(control);
             }
             else
                 if (control.GetType().GetProperty("Text") != null)
                 {
                     LiteralControl literal = new LiteralControl();
                     control.Parent.Controls.Add(literal);
                     literal.Text = (string)control.GetType().GetProperty("Text").GetValue(control, null);
                     control.Parent.Controls.Remove(control);
                 }
         }
         return;
     }


     protected void ddl_ProductCode_SelectedIndexChanged(object sender, EventArgs e)
     {
         dt_PCode = obj_trip.Bizconnect_LoadProductNameByProductCode(Convert.ToInt32(Session["ClientID"].ToString()), ddl_ProductCode.SelectedItem.Text);
         ddlProduct.DataSource = dt_PCode;
         ddlProduct.DataTextField = "ProductName";
         ddlProduct.DataValueField = "ProductID";
         ddlProduct.DataBind();
         ddlProduct.Items.Insert(0, new ListItem("--Select--", "0"));
     }

     protected void btn_Analysis_Click(object sender, EventArgs e)
     {
         Response.Redirect("~/Analysis.aspx");
     }
}
