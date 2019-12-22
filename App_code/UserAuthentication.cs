using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

/// <summary>
/// Summary description for UserAuthentication
/// </summary>
public class UserAuthentication
{
    SqlConnection obj_BizConn = new SqlConnection();
    SqlConnection obj_SCMConn = new SqlConnection();

    public UserAuthentication()
    {
        //
        // TODO: Add constructor logic here
        //

        string BizConnStr = ConfigurationManager.ConnectionStrings["BizCon"].ConnectionString;
       // string SCMConnStr = ConfigurationManager.ConnectionStrings["SCMCon"].ConnectionString;
        obj_BizConn.ConnectionString = BizConnStr;
       // obj_SCMConn.ConnectionString = SCMConnStr;

        obj_BizConn.Open();
       // obj_SCMConn.Open();
    }

    ~UserAuthentication()
    {
        //obj_BizConn.Close();
        // obj_SCMConn.Close();
    }

    //User Type checking
    public ArrayList Verify_Usertype(String obj_UID, String obj_PWD)
    {
        Int32 obj_Resp = 0;
        ArrayList obj_list = new ArrayList();
        string fname, lname, name, userid, obj_AarmsUser,obj_IsprimaryUser;
      
        try
        {
            using (SqlCommand comm = new SqlCommand("Verify_Usertype", obj_BizConn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                ada.SelectCommand.Parameters.AddWithValue("@obj_UID", obj_UID);
                SqlDataReader dr = ada.SelectCommand.ExecuteReader();
                if (dr.HasRows)
                {
                    if (dr.Read())
                    {
                        if (!dr.IsDBNull(0))
                        {
                            //If found then flag value will be 1
                            string pwd = dr[1].ToString().Trim();
                            if (obj_PWD.Trim() == dr[1].ToString().Trim())
                            {


                                fname = dr[2].ToString().Trim();
                                lname = dr[3].ToString().Trim();
                                name = fname + @" " + lname;
                                userid = dr[5].ToString().Trim();
                                obj_AarmsUser = dr[6].ToString().Trim();
                                obj_IsprimaryUser = dr[7].ToString().Trim();
                                if (obj_AarmsUser.Trim() == "True")
                                {
                                    obj_Resp = 1;
                                }
                                else
                                {
                                    obj_Resp = 0;
                                }
                                obj_list.Add(obj_Resp);
                                obj_list.Add(name);
                                obj_list.Add(userid);
                                obj_list.Add(obj_AarmsUser);
                                obj_list.Add(obj_IsprimaryUser);
                              
                                
                            }
                            else
                            {
                                obj_Resp = 0;
                                obj_list.Add(obj_Resp);
                            }
                        }
                    }
                }
                else
                {
                    obj_Resp = 0;
                    obj_list.Add(obj_Resp);
                }
                dr.Close();
            }
        }
        
        catch (Exception err)
        {
            obj_Resp = 0;
            obj_list.Add(obj_Resp);
        }
        finally
        {

        }
        return obj_list;
    }



    //User Authentication
    public ArrayList Verify_User(String obj_UID, String obj_PWD)
    {
        Int32 obj_Resp = 0;
        ArrayList obj_list = new ArrayList();
        string fname, lname, name, clientid, clientcode, userid, obj_CompanyName, obj_AarmsUser,obj_ClientAdrID;
        try
        {
            using (SqlCommand comm = new SqlCommand("Get_BizConnect_PasswordByEmailID", obj_BizConn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                ada.SelectCommand.Parameters.AddWithValue("@obj_UID", obj_UID);
                SqlDataReader dr = ada.SelectCommand.ExecuteReader();
                if (dr.HasRows)
                {
                    if (dr.Read())
                    {
                        if (!dr.IsDBNull(0))
                        {
                            //If found then flag value will be 1
                            string pwd = dr[1].ToString().Trim();
                            if (obj_PWD.Trim() == dr[1].ToString().Trim())
                            {

                                obj_Resp = 1;
                                fname = dr[2].ToString().Trim();
                                lname = dr[3].ToString().Trim();
                                name = fname + @" " + lname;
                                clientid = dr[4].ToString().Trim();
                                clientcode = dr[5].ToString().Trim();
                                userid = dr[6].ToString().Trim();
                                obj_CompanyName = dr[7].ToString().Trim();
                                obj_AarmsUser = dr[8].ToString().Trim();
                                obj_ClientAdrID = dr[10].ToString().Trim();
                                obj_list.Add(obj_Resp);
                                obj_list.Add(name);
                                obj_list.Add(clientid);
                                obj_list.Add(clientcode);
                                obj_list.Add(userid);
                                obj_list.Add(obj_CompanyName);
                                obj_list.Add(obj_AarmsUser);
                                obj_list.Add(obj_ClientAdrID);
                            }
                            else
                            {
                                obj_Resp = 0;
                                obj_list.Add(obj_Resp);
                            }
                        }
                    }
                }
                else
                {
                    obj_Resp = 0;
                    obj_list.Add(obj_Resp);
                }
                dr.Close();
            }
        }
        catch (Exception err)
        {
            obj_Resp = 0;
            obj_list.Add(obj_Resp);
        }
        finally
        {

        }
        return obj_list;
    }

    //Check services
    public int CheckService(String obj_UID, int obj_serviceid)
    {
        Int32 obj_Resp = 0;

        try
        {
            using (SqlCommand comm = new SqlCommand("Check_Services", obj_BizConn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                ada.SelectCommand.Parameters.AddWithValue("@obj_UID", obj_UID);
                ada.SelectCommand.Parameters.AddWithValue("@obj_ServiceID", obj_serviceid);
                SqlDataReader dr = ada.SelectCommand.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    string permission = dr[0].ToString().Trim();
                    if (permission.Trim() == "1")
                    {
                        obj_Resp = 1;
                    }
                    else
                    {
                        obj_Resp = 0;
                    }

                }
                else
                {
                    obj_Resp = 0;
                }

                dr.Close();
            }
        }
        catch (Exception err)
        {
            obj_Resp = 0;

        }
        finally
        {

        }
        return obj_Resp;
    }


    //insert into suggestions master
    public Int32 Insert_Suggestions(string name, string occupation, string companyname, string companywebsite, string email, string location,
                                    string mobile, string phoneno, string websites, string arch, string look, string design, string lang,
                                    string concept, string addinfo, string relatedbiz, string referals)
    {
        int res;

        using (SqlCommand cmd = new SqlCommand("Insert_BizConnect_SuggestionsMaster", obj_BizConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(cmd);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                ada.SelectCommand.Parameters.AddWithValue("@obj_Name", name);
                ada.SelectCommand.Parameters.AddWithValue("@obj_Occupation", occupation);
                ada.SelectCommand.Parameters.AddWithValue("@obj_Companyname", companyname);
                ada.SelectCommand.Parameters.AddWithValue("@obj_Companywebsite", companywebsite);
                ada.SelectCommand.Parameters.AddWithValue("@obj_Emailaddress", email);
                ada.SelectCommand.Parameters.AddWithValue("@obj_Location", location);
                ada.SelectCommand.Parameters.AddWithValue("@obj_Mobile", mobile);
                ada.SelectCommand.Parameters.AddWithValue("@obj_PhoneNo", phoneno);
                ada.SelectCommand.Parameters.AddWithValue("@obj_websites", websites);
                ada.SelectCommand.Parameters.AddWithValue("@obj_Sitearch", arch);
                ada.SelectCommand.Parameters.AddWithValue("@obj_Look", look);
                ada.SelectCommand.Parameters.AddWithValue("@obj_Design", design);
                ada.SelectCommand.Parameters.AddWithValue("@obj_Language", lang);
                ada.SelectCommand.Parameters.AddWithValue("@obj_Concept", concept);
                ada.SelectCommand.Parameters.AddWithValue("@obj_Addinfo", addinfo);
                ada.SelectCommand.Parameters.AddWithValue("@obj_Relatedbiz", relatedbiz);
                ada.SelectCommand.Parameters.AddWithValue("@obj_Referrals", referals);
                ada.SelectCommand.ExecuteNonQuery();
                res = 1;



            }
            catch (Exception exe)
            {
                res = 0;
            }
        }


        return res;
    }
}