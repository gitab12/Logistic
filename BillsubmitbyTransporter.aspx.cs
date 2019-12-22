using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class BillsubmitbyTransporter : System.Web.UI.Page
{
    ProjectBased Obj_Class = new ProjectBased();
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            VehiclePlaced();
        }
    }
    public void VehiclePlaced()
    {
        ds.Clear();
        ds = Obj_Class.Get_BillSubmitted();
        grd_BillSubmit. DataSource = ds;
        grd_BillSubmit.DataBind();
    }
}