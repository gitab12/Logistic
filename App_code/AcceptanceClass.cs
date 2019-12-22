using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Data.Sql;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public class AcceptanceClass
{
    string connStr = ConfigurationManager.ConnectionStrings["con1"].ConnectionString;
    ArrayList arr = new ArrayList();

    public AcceptanceClass()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    //Retrieving all Post Type
    public DataSet get_Assignment(Int32 obj_LoginID, Int32 obj_Flag)
    {
        DataSet ds = new DataSet();
        ds.Clear();
        if (obj_Flag == 1) //Vehicle Available
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand comm = new SqlCommand("get_MyAssignmentForAcceptanceVA", conn))
                {
                    ds.Clear();
                    SqlDataAdapter ada = new SqlDataAdapter(comm);
                    ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                    ada.SelectCommand.Parameters.AddWithValue("@obj_LoginID", obj_LoginID);
                    try
                    {
                        conn.Open();
                        ada.Fill(ds, "MyAssignment");
                    }
                    catch (Exception err)
                    {

                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
        }
        else if (obj_Flag == 2) // Vehicle Wanted
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand comm = new SqlCommand("get_MyAssignmentForAcceptanceVW", conn))
                {
                    ds.Clear();
                    SqlDataAdapter ada = new SqlDataAdapter(comm);
                    ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                    ada.SelectCommand.Parameters.AddWithValue("@obj_LoginID", obj_LoginID);
                    try
                    {
                        conn.Open();
                        ada.Fill(ds, "MyAssignment");
                    }
                    catch (Exception err)
                    {

                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
        }
        return ds;
    }

    //Updating SCMJunction_PostReply and SCMJunction_PostAd
    public Int32 Update_PostReplyForAcceptance(int obj_PostReplyID)
    {
        int resp = 0;
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            using (SqlCommand comm = new SqlCommand("Update_PostReplyForAcceptance", conn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                //ada.SelectCommand.Parameters.AddWithValue("@obj_PostID", obj_PostID);
                ada.SelectCommand.Parameters.AddWithValue("@obj_PostReplyID", obj_PostReplyID);
                //ada.SelectCommand.Parameters.AddWithValue("@obj_NumOfTrucks", obj_NumOfTrucks);
                try
                {
                    conn.Open();
                    ada.SelectCommand.ExecuteNonQuery();
                    resp = 1;
                }
                catch (Exception err)
                {
                    resp = 0;
                }
                finally
                {
                    conn.Close();
                    comm.Dispose();
                    ada.Dispose();
                }
            }
        }
        return resp;
    }

    //Updating SCMJunction_PostReply and SCMJunction_PostAd
    public Int32 Update_PostReplyForReject(int obj_PostReplyID)
    {
        int resp = 0;
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            using (SqlCommand comm = new SqlCommand("Update_PostReplyForReject", conn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                //ada.SelectCommand.Parameters.AddWithValue("@obj_PostID", obj_PostID);
                ada.SelectCommand.Parameters.AddWithValue("@obj_PostReplyID", obj_PostReplyID);
                //ada.SelectCommand.Parameters.AddWithValue("@obj_NumOfTrucks", obj_NumOfTrucks);
                try
                {
                    conn.Open();
                    ada.SelectCommand.ExecuteNonQuery();
                    resp = 1;
                }
                catch (Exception err)
                {
                    resp = 0;
                }
                finally
                {
                    conn.Close();
                    comm.Dispose();
                    ada.Dispose();
                }
            }
        }
        return resp;
    }


    //Retreiving Email and Mobile Number By AdID

    public ArrayList get_EmailAndMobileNumber(String obj_AdID)
    {
        String obj_Email, obj_MobileNo;
        Int32 resp = 3;
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            using (SqlCommand comm = new SqlCommand("get_EmailAndMobileNumberByAdID", conn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                ada.SelectCommand.Parameters.AddWithValue("@obj_AdID", obj_AdID);
                try
                {
                    conn.Open();
                    SqlDataReader dr = ada.SelectCommand.ExecuteReader();
                    if (dr.HasRows)
                    {
                        if (dr.Read())
                        {
                            if (!dr.IsDBNull(0))
                            {
                                resp = 1;
                                obj_MobileNo = dr.GetValue(0).ToString();
                                obj_Email = dr.GetValue(1).ToString();
                                arr.Add(obj_MobileNo);
                                arr.Add(obj_Email);
                            }
                            else
                            {
                                resp = 0;
                            }
                        }
                        else
                        {
                            resp = 0;
                        }
                    }
                    else
                    {
                        resp = 0;
                    }
                    dr.Close();
                }
                catch (Exception err)
                {
                    resp = 0;
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        arr.Add(resp);
        return arr;
    }

    //Retrieving Mobile No and Email from Registration by ReplyByID
    public ArrayList get_MobileNumberAndEmailByReplyByID(String obj_ReplyByID)
    {
        String obj_MobileNo;
        String obj_Email;
        Int32 resp = 3;
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            using (SqlCommand comm = new SqlCommand("get_MobileNumberAndEmailByReplyByID", conn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                ada.SelectCommand.Parameters.AddWithValue("@obj_ReplyByID", obj_ReplyByID);
                try
                {
                    conn.Open();
                    SqlDataReader dr = ada.SelectCommand.ExecuteReader();
                    if (dr.HasRows)
                    {
                        if (dr.Read())
                        {
                            if (!dr.IsDBNull(0))
                            {
                                resp = 1;
                                obj_MobileNo = dr.GetValue(0).ToString();
                                obj_Email = dr.GetValue(1).ToString();
                                arr.Add(obj_MobileNo);
                                arr.Add(obj_Email);
                            }
                            else
                            {
                                resp = 0;
                            }
                        }
                        else
                        {
                            resp = 0;
                        }
                    }
                    else
                    {
                        resp = 0;
                    }
                    dr.Close();
                }
                catch (Exception err)
                {
                    resp = 0;
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        arr.Add(resp);
        return arr;
    }

    //Retrieving PostID from Reply Table ******************
    // public ArrayList get_PostIDByReplyByID(Int32 obj_LoginID)
    // {
    //     Int32 obj_PostID;
    //     Int32 resp = 3;
    //     using (SqlConnection conn = new SqlConnection(connStr))
    //     {
    //         using (SqlCommand comm = new SqlCommand("get_PostIDByReplyByID", conn))
    //         {
    //             SqlDataAdapter ada = new SqlDataAdapter(comm);
    //             ada.SelectCommand.CommandType = CommandType.StoredProcedure;
    //             ada.SelectCommand.Parameters.AddWithValue("@obj_ReplyByID", obj_LoginID);
    //             try
    //             {
    //                 conn.Open();
    //                 SqlDataReader dr = ada.SelectCommand.ExecuteReader();
    //                 if (dr.HasRows)
    //                 {
    //                     if (dr.Read())
    //                     {
    //                         if (!dr.IsDBNull(0))
    //                         {
    //                             resp = 1;
    //                             obj_PostID = Convert.ToInt32(dr.GetValue(0).ToString());
    //                             arr.Add(obj_PostID);
    //                         }
    //                         else
    //                         {
    //                             resp = 0;
    //                         }
    //                     }
    //                     else
    //                     {
    //                         resp = 0;
    //                     }
    //                 }
    //                 else
    //                 {
    //                     resp = 0;
    //                 }
    //                 dr.Close();
    //             }
    //             catch (Exception err)
    //             {
    //                 resp = 0;
    //             }
    //             finally
    //             {
    //                 conn.Close();
    //             }
    //         }
    //     }
    //     arr.Add(resp);
    //     return arr;
    // }

    //Useractivate
    public int Useractivate(int obj_rid, int obj_type)
    {
        int resp = 0;
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            using (SqlCommand comm = new SqlCommand("UserDeactivate", conn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                ada.SelectCommand.Parameters.AddWithValue("@obj_rid", obj_rid);
                ada.SelectCommand.Parameters.AddWithValue("@obj_type", obj_type);
                try
                {
                    conn.Open();
                    ada.SelectCommand.ExecuteNonQuery();
                    resp = 1;
                }
                catch (Exception err)
                {
                    resp = 0;
                }
                finally
                {
                    conn.Close();
                    comm.Dispose();
                    ada.Dispose();
                }
            }
        }
        return resp;
    }




    //Updating Update_scmjunction_registration 
    public Int32 Update_AdminReport(int @obj_rid, string @obj_Firstname, string @obj_Lastname, string Email, string @obj_SecEmail, string @obj_Mobile, string @obj_phone)
    {
        int resp = 0;
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            using (SqlCommand comm = new SqlCommand("Update_scmjunction_registration", conn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                ada.SelectCommand.Parameters.AddWithValue("@obj_rid", @obj_rid);
                ada.SelectCommand.Parameters.AddWithValue("@obj_Firstname", @obj_Firstname);
                ada.SelectCommand.Parameters.AddWithValue("@obj_Lastname", @obj_Lastname);
                ada.SelectCommand.Parameters.AddWithValue("@obj_Email", Email);
                ada.SelectCommand.Parameters.AddWithValue("@obj_SecEmail", @obj_SecEmail);
                ada.SelectCommand.Parameters.AddWithValue("@obj_Mobile", @obj_Mobile);
                ada.SelectCommand.Parameters.AddWithValue("@obj_phone", @obj_phone);

                try
                {
                    conn.Open();
                    ada.SelectCommand.ExecuteNonQuery();
                    resp = 1;
                }
                catch (Exception err)
                {
                    resp = 0;
                }
                finally
                {
                    conn.Close();
                    comm.Dispose();
                    ada.Dispose();
                }
            }
        }
        return resp;
    }

    public int Update_ClientAdminReport(int @UserId, string @EmailId, string @Mobile, string @phone)
    {
        int res = 0;
        String conn = ConfigurationManager.ConnectionStrings["Bizcon"].ConnectionString;
        using (SqlConnection con = new SqlConnection(conn))
        {
            using (SqlCommand comm = new SqlCommand("Update_UserLogDB", con))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                ada.SelectCommand.Parameters.AddWithValue("@UserId", @UserId);
                ada.SelectCommand.Parameters.AddWithValue("@EmailId", @EmailId);
                ada.SelectCommand.Parameters.AddWithValue("@Mobile", @Mobile);
                ada.SelectCommand.Parameters.AddWithValue("@phone", @phone);
                try
                {
                    con.Open();
                    ada.SelectCommand.ExecuteNonQuery();
                    res = 1;
                }
                catch(Exception ex)
                {
                    res = 0;
                }
            }
        }
        return res;
    }
}
