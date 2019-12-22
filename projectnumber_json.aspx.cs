using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class projectnumber_json : System.Web.UI.Page
{
    BizCon_DB_ConnectionString con_biz = new BizCon_DB_ConnectionString();
    Aumjunction_DB_ConnectionString con_arfoc = new Aumjunction_DB_ConnectionString();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string projectid = Convert.ToString(Request.QueryString.Get("id"));
            //string projectid = "1061";

            string[] args = { "@ProjectName" };
            string[] argsval = { projectid };

            DataSet ds = new DataSet();
            ds = con_biz.Sql_GetData("SP_Get_Projectumber_By_projectname", args, argsval);

            List<MYMODEL> projectno_model = new List<MYMODEL>();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                MYMODEL projectno_model_item = new MYMODEL();
                projectno_model_item.ProjectID = dr["ProjectID"].ToString();
                projectno_model_item.ProjectName = dr["ProjectName"].ToString();
                projectno_model_item.ProjectNo = dr["ProjectNo"].ToString();
                projectno_model.Add(projectno_model_item);
            }
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            string projectnomodel_list_output = serializer.Serialize(projectno_model);
            Response.Write(projectnomodel_list_output);
        }
        catch
        {
        }
    }
}