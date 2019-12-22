using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AARMEmail;

public partial class ImportExport_ImportExportRegistration : System.Web.UI.Page
{
    ImportExport obj_Class = new ImportExport();
    int res = 0;
    AARMEmail.EmailControl mail = new AARMEmail.EmailControl();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            pnl_CHA.Visible = false;
            pnl_Registration.Visible = true;
            pnl_FreightForwarders.Visible = true;
        }

    }
    protected void btn_Submit_Click(object sender, EventArgs e)
    {
       
        try
        {
            obj_Class.CompanyName = txt_CHACompanyName.Text;
                obj_Class.Address = txt_CHACompanyAddress.Text;
                obj_Class.ContactPerson = rdb_CHAPromotor.Checked ? rdb_CHAPromotor.Text + " - " + txt_CHAContactName.Text : rdb_CHAMD.Checked ? rdb_CHAMD.Text + " - " + txt_CHAContactName.Text : rdb_CEO.Checked ? rdb_CHACEO.Text + " - " + txt_CHAContactName.Text : "";
                obj_Class.MarketingHead = txt_CHAMarketingHead.Text;
                obj_Class.OperationHead = txt_CHAOperationHead.Text;
                obj_Class.MobileNo = txt_CHAMobileno.Text;
                obj_Class.BoardLine = txt_CHABoardline.Text;
                obj_Class.EmailID = txt_CHAEmailid.Text;
                obj_Class.Password = txt_CHAPassword.Text;
                obj_Class.LocationofBranches = rdb_CHABranchesIndia.Checked ? rdb_CHABranchesIndia.Text : rdb_CHABranchesIndia.Checked && rdb_CHABranchesAbroad.Checked ? rdb_CHABranchesIndia.Text + "-" + rdb_CHABranchesAbroad.Text : rdb_CHABranchesAbroad.Checked ? rdb_CHABranchesAbroad.Text : "";
                obj_Class.CHALicence = rdb_CHALicenceYes.Checked ? true : false;
                obj_Class.CHALicenceNo = txt_CHAlicencenum.Text;
                obj_Class.ProductsSpecialisedIn = txt_CHASpecilizedProducts.Text;
                obj_Class.handlingAIRAndSeaClearance = rdb_CHAClearanceYes.Checked ? true : false;
                obj_Class.SpecialisedServices = txt_CHASpecilizedServices.Text;
                obj_Class.RegistrationType = rdb_CHA.Text;

                obj_Class.IATAMember = rdb_IATAYes.Checked ? true : false;
                obj_Class.IssueAWB = rdb_AWBYes.Checked ? true : false;
                obj_Class.CompetitiveSector = "NA";
                obj_Class.consolidationServices = false;
                obj_Class.consolidationServicesSector = "NA";
                res = obj_Class.Bizconnect_Insert_ImportExportRegistration();
                if (res != 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Registration completed successfully');</script>");
                    SendCHAMail();
                    ClearCHAFields();
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Already registered with this company');</script>");
                }
        }
        catch (Exception  ex)
        {

        }

    }
    protected void rdb_FreightForwarders_CheckedChanged(object sender, EventArgs e)
    {
        pnl_CHA.Visible = false;
        pnl_FreightForwarders.Visible = true;
        ClearCHAFields();
        rdb_Promotor.Checked = true;
    }
    protected void rdb_CHA_CheckedChanged(object sender, EventArgs e)
    {
        pnl_CHA.Visible = true ;
        pnl_FreightForwarders.Visible = false;
        ClearFrieghtForwardersFields();
        rdb_CHAPromotor.Checked = true;
    }

    public void ClearFrieghtForwardersFields()
    {
        txt_CompanyName.Text = "";
        txt_Address.Text = "";
        rdb_Promotor.Checked = false;
        rdb_MD.Checked = false;
        rdb_CEO.Checked = false;
        rdb_CHALicenceNo.Checked = false;
        rdb_CHALicenceYes.Checked = false;
        rdb_India.Checked = false;
        rdb_Abroad.Checked = false;
        rdb_IATAYes.Checked = false;
        rdb_IATANo.Checked = false;
        rdb_AWBYes.Checked = false;
        rdb_AWBNo.Checked = false;
        rdb_SectorAir.Checked = false;
        rdb_SectoSea.Checked = false;
        rdb_ConsolidationYes.Checked = false;
        rdb_ConsolidationNo.Checked = false;
        txt_Contactperson.Text = "";
        txt_MarketHead.Text = "";
        txt_OperationHead.Text = "";
        txt_Mobileno.Text = "";
        txt_Boardline.Text = "";
        txt_EmailId.Text = "";
        txt_FreightForwarderPassword.Text = "";
        txt_CHALicenceno.Text = "";
        txt_Sectors.Text = "";
    }

    public void ClearCHAFields()
    {
        txt_CHACompanyName.Text = "";
        txt_CHACompanyAddress.Text = "";
        txt_CHAContactName.Text = "";
        txt_CHAMarketingHead.Text = "";
        txt_CHAOperationHead.Text = "";
        txt_CHAMobileno.Text = "";
        txt_CHABoardline.Text = "";
        txt_CHAEmailid.Text = "";
        txt_CHAPassword.Text = "";
        txt_CHAlicencenum.Text = "";
        txt_CHASpecilizedProducts.Text = "";
        txt_CHASpecilizedServices.Text = "";
        rdb_CHAPromotor.Checked = false;
        rdb_CHAMD.Checked = false;
        rdb_CHACEO.Checked = false;
        rdb_CHABranchesIndia.Checked = false;
        rdb_CHABranchesAbroad.Checked = false;
       rdb_OwnCHALicenceYes.Checked = false;
       rdb_OwnCHALicenceNo.Checked = false;
        rdb_CHAClearanceYes.Checked = false;
        rdb_CHALicenceNo.Checked = false;
    }
    protected void btn_FreightSubmit_Click(object sender, EventArgs e)
    {
            try
            {
                 if (rdb_FreightForwarders.Checked)
                {
                obj_Class.CompanyName = txt_CompanyName.Text;
                obj_Class.Address = txt_Address.Text;
                obj_Class .ContactPerson = rdb_Promotor .Checked?rdb_Promotor.Text +" - "+ txt_Contactperson .Text : rdb_MD .Checked?rdb_MD.Text+" - "+ txt_Contactperson .Text :rdb_CEO .Checked ?rdb_CEO .Text +" - "+ txt_Contactperson .Text:"";
                obj_Class.MarketingHead = txt_MarketHead.Text;
                obj_Class.OperationHead = txt_OperationHead.Text;
                obj_Class.MobileNo = txt_Mobileno.Text;
                obj_Class.BoardLine = txt_Boardline.Text;
                obj_Class.EmailID = txt_EmailId.Text;
                obj_Class.Password = txt_FreightForwarderPassword.Text;
                obj_Class.LocationofBranches = rdb_India.Checked && rdb_Abroad.Checked ? rdb_India.Text + "-" + rdb_Abroad.Text : rdb_India.Checked ? rdb_India.Text : rdb_Abroad.Checked ? rdb_Abroad.Text : "";
                obj_Class.CHALicence = rdb_CHALicenceYes.Checked ? true  :  false;
                obj_Class.CHALicenceNo = txt_CHALicenceno.Text;
                obj_Class.IATAMember = rdb_IATAYes.Checked ? true : false;
                obj_Class.IssueAWB = rdb_AWBYes.Checked ? true : false;
                obj_Class.CompetitiveSector = rdb_SectorAir.Checked && rdb_SectoSea.Checked ? rdb_SectorAir.Text + "-" + rdb_SectoSea.Text : rdb_SectorAir.Checked ? rdb_SectorAir.Text : rdb_SectoSea.Checked ? rdb_SectoSea.Text : "";
                obj_Class.consolidationServices = rdb_ConsolidationYes.Checked ? true : false;
                obj_Class.consolidationServicesSector = txt_Sectors.Text;
                obj_Class.RegistrationType = rdb_FreightForwarders.Text;
                
                obj_Class.ProductsSpecialisedIn = "NA";
                obj_Class.SpecialisedServices = "NA";
                res = obj_Class.Bizconnect_Insert_ImportExportRegistration();
                if (res!=0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Registration completed successfully');</script>");
                    SendFreightMail();
                    ClearFrieghtForwardersFields();
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Already registered with this company');</script>");
                }
            }
         }
        catch (Exception  ex)
        {

        }

}

    public void SendFreightMail()
    {
        string body = "Dear Sir/Madam,<br/><br/>Your registration done successfully.<br/><br/><br/>Your User ID and Password are as given below.<br/><br/> UserID : "+ txt_EmailId .Text+"<br/><br/> Password : "+ txt_FreightForwarderPassword .Text +" <br/><br/> Regards, <br/> Bizconnect Team.";
        mail.SendEmail( txt_EmailId .Text, "krishna.irki@gmail.com", "irrinkidattu", "", "", "", "", "Registration completed successfully", body, System.Web.Mail.MailFormat.Html, System.Web.Mail.MailPriority.High, "smtp.gmail.com", "465", "2", "1", true, "");
    }


    public void SendCHAMail()
    {
        string body = "Dear Sir/Madam,<br/><br/>Your registration done successfully.<br/><br/><br/>Your User ID and Password are as given below.<br/><br/> UserID : " + txt_CHAEmailid.Text + "<br/><br/> Password : " + txt_CHAPassword.Text + " <br/><br/> Regards, <br/> Bizconnect Team.";
        mail.SendEmail(txt_CHAEmailid.Text, "krishna.irki@gmail.com", "irrinkidattu", "", "", "", "", "Registration completed successfully", body, System.Web.Mail.MailFormat.Html, System.Web.Mail.MailPriority.High, "smtp.gmail.com", "465", "2", "1", true, "");
    }

}


