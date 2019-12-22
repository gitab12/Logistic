<%@ Page  Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="StatusUpdate_bak.aspx.cs" Inherits="StatusUpdate" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

<link  rel="shortcut icon"  type="image/x-icon" href="images/favicon.ico" />
  <link id="Link2" runat="server" rel="icon" href="images/favicon.ico" type="image/ico"/>
        <title>BizConnect | Supply Chain Management | Road Transports | Indian Road Transportation
            | Supply Demand Matching | Trucks Available | Trucks Wanted | Goods Transport |
            Logistics</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br /><br /><br /><br /><br /><br />
<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div style="margin-left:300px">
<asp:Label ID="Label7" runat="server" Font-Bold="False" Font-Names="Arial" 
                    Font-Size="10pt" ForeColor="Red" Text="Appointment Date"></asp:Label>
                    <asp:TextBox ID="txtappdate" runat="server" BorderColor="Black" 
                    BorderStyle="Solid" BorderWidth="1px" Width="227px" ></asp:TextBox>  
                    <asp:ImageButton ID="imgdate1" 
            runat="server" ImageUrl="~/images/calendar_icon.gif" Width="16px" 
                />
    <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" 
 PopupButtonID="imgdate1" TargetControlID="txtappdate" >
 </ajaxToolkit:CalendarExtender>
                
    <asp:Button ID="ButShow" runat="server" Text="Show" onclick="ButShow_Click" Class="btn btn-primary"  />
    <asp:Label ID="lblwelcome" runat="server" Text="" Font-Bold ="true" ForeColor="Red"  ></asp:Label>

    <asp:Button ID="btnexport" runat="server" Text="Export" onclick="btnexport_Click" Class="btn btn-primary"  />
 
    &nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btn_Sendmail" runat="server" Text="Send Mail" OnClick ="btn_Sendmail_Click"  Class="btn btn-primary"  />
&nbsp;
    <asp:LinkButton ID="LinkLogout" runat="server" OnClick="LinkLogout_Click">LogOut</asp:LinkButton>
    
    <br /> <br />
    Search by :
    <asp:DropDownList ID="ddl_Search" runat="server" Width="90px">
<asp:ListItem >--Select--</asp:ListItem>
        <asp:ListItem >Client</asp:ListItem>
        <asp:ListItem >Location</asp:ListItem>
        <asp:ListItem >Industry</asp:ListItem>
    </asp:DropDownList>
&nbsp;&nbsp;
   Enter Text : <asp:TextBox ID="txt_Search" Width ="250px" runat="server"></asp:TextBox>
&nbsp;&nbsp; 
    <asp:Button ID="btn_Search" runat="server" Text="Search" OnClick ="btn_Search_Click"  Class="btn btn-primary" />
    <br /> <br />
         </div>
    <asp:Panel ID="pal_1" runat="server"  BorderColor="#0000" BorderStyle="Solid" Font-Bold="false" Height ="270px" ScrollBars="Auto" Width="50%" GroupingText="" Style="margin-left:50px">

<asp:GridView ID="GridStatus" runat="server" width="100px" 
        AutoGenerateColumns="False" BorderColor="#E0E0E0"
    CellPadding="4" ForeColor="#333333" GridLines="Both"
     onrowediting="GridStatus_RowEditing" DataKeyNames="ActivityID"
                    onrowcancelingedit="GridStatus_RowCancelingEdit" 
                    onrowupdating="GridStatus_RowUpdating"
     AllowSorting="True" onrowdeleting="GridStatus_RowDeleting" >
    <RowStyle BackColor="#C2DDEB" ForeColor="#333333" />
    <Columns>
       <asp:TemplateField HeaderText="ID">
            <EditItemTemplate>
                 <asp:Label ID="lblActivityID" runat="server" Text='<%# Bind("ActivityID") %>'></asp:Label>
                
            </EditItemTemplate>
            <HeaderTemplate>
              <asp:Label ID="lblAdIDheader" Text="ID" runat="server" />
                             
            </HeaderTemplate>
            <ItemTemplate>
                <asp:CheckBox ID ="chk_ID" runat ="server" />
                <asp:Label ID="lblActivityID" runat="server" Text='<%# Bind("ActivityID") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
    
    
    
        <asp:TemplateField HeaderText="Client">
            <EditItemTemplate>
                  <asp:Label ID="lblsource" runat="server" Text='<%# Bind("ClientName") %>'></asp:Label>
            </EditItemTemplate>
   
            <ItemTemplate>
                <asp:Label ID="lblsource" runat="server" Text='<%# Bind("ClientName") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Location">
            <EditItemTemplate>
                <asp:Label ID="lbllocation" runat="server" Text='<%# Bind("Location") %>'></asp:Label>
            </EditItemTemplate>
          
            <ItemTemplate>
                <asp:Label ID="lbllocation" runat="server" Text='<%# Bind("Location") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Industry">
            <EditItemTemplate>
                 <asp:Label ID="lblIndustry" runat="server" Text='<%# Bind("Industry") %>'></asp:Label>
            </EditItemTemplate>
          
            <ItemTemplate>
                <asp:Label ID="lblIndustry" runat="server" Text='<%# Bind("Industry") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="ContactPerson">
            <EditItemTemplate>
                <asp:TextBox ID="txtcontactperson" runat="server" Text='<%# Bind("ContactPerson") %>' ></asp:TextBox>
            </EditItemTemplate>
        
            <ItemTemplate>
                     <asp:Label ID="lblcontactperson" runat="server" Text='<%# Bind("ContactPerson") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        
         <asp:TemplateField HeaderText="MobileNumber">
            <EditItemTemplate>
                <asp:TextBox ID="txtMobileNumber" runat="server" Text='<%# Bind("MobileNumber") %>' ></asp:TextBox>
            </EditItemTemplate>
        
            <ItemTemplate>
                     <asp:Label ID="lblMobileNumber" runat="server" Text='<%# Bind("MobileNumber") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        
        
         <asp:TemplateField HeaderText="EmailId">
            <EditItemTemplate>
                <asp:TextBox ID="txtEmailId" runat="server" Text='<%# Bind("EmailID") %>' ></asp:TextBox>
            </EditItemTemplate>
        
            <ItemTemplate>
                     <asp:Label ID="lblEmailID" runat="server" Text='<%# Bind("EmailID") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        
        <asp:TemplateField HeaderText="Department">
            <EditItemTemplate>
                <asp:TextBox ID="txtDept" runat="server" Text='<%# Bind("Department") %>' ></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="lblDept" runat="server" Text='<%# Bind("Department") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="EnterBy">
            <EditItemTemplate>
                <asp:TextBox ID="txtenterby" runat="server" Text='<%# Bind("EnteredBy") %>' ></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="lblenterby" runat="server" Text='<%# Bind("EnteredBy") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="AppointmentDate">
            <EditItemTemplate>
                <asp:TextBox ID="txtAppdate" runat="server" Text='<%# Bind("AppointmentDate") %>' ></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="lblAppdate" runat="server" Text='<%# Bind("AppointmentDate") %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle/>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="MetBy">
            <EditItemTemplate>
                <asp:TextBox ID="txtMetBy" runat="server" Text='<%# Bind("MetBy") %>' ></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="lblMetBy" runat="server" Text='<%# Bind("MetBy") %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle/>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Tripplan">
            <EditItemTemplate>
                <asp:TextBox ID="txtTripplan" runat="server" Text='<%# Bind("Tripplan") %>' ></asp:TextBox>
                <asp:ImageButton ID="imgtripplan" runat="server" ImageUrl="~/images/calendar_icon.gif" Width="16px" />
         <ajaxtoolkit:calendarextender ID="CalendarExtender4" runat="server" 
                    PopupButtonID="imgtripplan" TargetControlID="txtTripplan">                
    </ajaxtoolkit:calendarextender>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="lblTripplan" runat="server" Text='<%# Bind("Tripplan") %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle/>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Action">
            <EditItemTemplate>
               <%-- <asp:TextBox ID="txtaction" runat="server" Text='<%# Bind("Action") %>' Width="75px"></asp:TextBox>--%>
               <asp:DropDownList ID="ddlaction" runat="server" Width="120px">
                <asp:ListItem>--Choose--</asp:ListItem>
                <asp:ListItem>Interested</asp:ListItem>
                <asp:ListItem>Not Interested</asp:ListItem>
                <asp:ListItem>Meeting Fixed</asp:ListItem>
                <asp:ListItem>Contact Later</asp:ListItem>
                <asp:ListItem>Trip Plan Received</asp:ListItem>
                </asp:DropDownList>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="lblaction" runat="server" Text='<%# Bind("Action") %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle/>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Remarks">
            <EditItemTemplate>
                <asp:TextBox ID="txtRemarks" runat="server" Text='<%# Bind("Remarks") %>'  TextMode ="MultiLine" Width="125px"></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
              <asp:TextBox ID="txtRemarks" runat="server" Text='<%# Bind("Remarks") %>' TextMode ="MultiLine"></asp:TextBox>
            </ItemTemplate>
            <ItemStyle/>
        </asp:TemplateField>
        <asp:CommandField ShowEditButton="True" HeaderText="UpdateStatus"/>
        <asp:CommandField ShowDeleteButton="true" HeaderText="DeleteStatus"/>
    </Columns>
    <EmptyDataTemplate >
       <center > <asp:Label ID ="lbl_Emptydata" runat ="server" Text ="No records found" ></asp:Label></center>
    </EmptyDataTemplate>
    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
    <SelectedRowStyle BackColor="#333333" BorderStyle="None" Font-Bold="True" ForeColor="#333333" />
    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
    <EditRowStyle BackColor="#C2DDEB" />
    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />       
  
</asp:GridView>  

        </asp:Panel>
     <br /><br /><br /><br /><br /><br />
</asp:Content>

