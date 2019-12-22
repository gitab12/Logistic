using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class UserControl_PreRequestApproval : System.Web.UI.Page
{

    BizConnectClass obj_class=new BizConnectClass();
     string obj_Authenticated;
    PlaceHolder maPlaceHolder;
    
       UserControl obj_Tabs;
    UserControl obj_LoginCtrl;
    UserControl obj_WelcomCtrl;
    UserControl obj_Navi;
   UserControl obj_Navihome;
   

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack == false)
        {
            ChkAuthentication();
            gridbind();
        }
    }
    public void gridbind()
    {
  
        DataSet ds = new DataSet();
        DataTable dt = new DataTable("Data");
        DataRow dr;
        dt.Columns.Add("select");
        dt.Columns.Add("adid");
        dt.Columns.Add("from");
        dt.Columns.Add("to");
        dt.Columns.Add("trucktype");
        dt.Columns.Add("Bcost");
        dt.Columns.Add("cost");
        dt.Columns.Add("trucks");
        dt.Columns.Add("assigned");
        dt.Columns.Add("saving");
        dt.Columns.Add("status");
        dt.Columns.Add("PreAssid");

        ds = obj_class.GetBizConnectApproval(Session["UserId"].ToString());

        for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
        {
            dr = dt.NewRow();
            dr[1] = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr[1] = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            dr[2] = ds.Tables[0].Rows[i].ItemArray[2].ToString();
            dr[3] = ds.Tables[0].Rows[i].ItemArray[3].ToString();
            dr[4] = ds.Tables[0].Rows[i].ItemArray[4].ToString();
            dr[5] = ds.Tables[0].Rows[i].ItemArray[5].ToString();
            dr[6] = ds.Tables[0].Rows[i].ItemArray[6].ToString();
            dr[7] = ds.Tables[0].Rows[i].ItemArray[7].ToString();
            dr[8] = ds.Tables[0].Rows[i].ItemArray[8].ToString();
            dr[9] = ((Convert.ToInt32 (dr[5])) - (Convert.ToInt32 (dr[6])))*Convert.ToInt32( dr[7]) ;
            dr[10] = "awaiting trip confirm";
            dr[11] = ds.Tables[0].Rows[i].ItemArray[9].ToString();
            dt.Rows.Add(dr);
        }

        GridAssign.DataSource = dt;
        GridAssign.DataBind();
    }
   
    protected void GridAssign_RowDataBound(Object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label LblAdid = (Label)e.Row.FindControl("lbladid");
            CheckBox check = (CheckBox)e.Row.FindControl("check");
            TextBox Txtassign = (TextBox)e.Row.FindControl("Txtassign");
            TextBox Txtcost = (TextBox)e.Row.FindControl("Txtcost");
            bool validDate = false;
            DateTime result;
          validDate = DateTime.TryParse(LblAdid.Text, out result);
           if (validDate == true)
           {
              e.Row.Cells[1].ForeColor = System.Drawing.Color.Red;
               check.Visible = false;
              Txtassign.Visible = false;
               Txtcost.Visible = false;
           }

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
       //  obj_Navihome.Visible = true;

    }
    public void SetVisualOFF()
    {
        obj_LoginCtrl.Visible = true;
        obj_WelcomCtrl.Visible = false;
        //obj_Navi.Visible = true;
      //  obj_Navihome.Visible = false;
    }
    protected void Butapprove_Click(object sender, EventArgs e)
    {
        int resp = 0;
        foreach (GridViewRow row in GridAssign.Rows)
        {
            CheckBox chkrow = (CheckBox)row.FindControl("Check");
            if (chkrow.Checked == true)
            {
                Label lblID = (Label)row.FindControl("LblID");
                resp = obj_class.Update_Approval(Convert.ToInt32 (lblID.Text));
            }
        }
        if (resp == 1)
        {

            Lblmsg.Visible = true;
        }
    }

}