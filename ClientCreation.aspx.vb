Imports System.Data
Imports System.Data.SqlClient
Imports AARMEmail
Partial Class ClientCreation
    Inherits System.Web.UI.Page
    Dim obj_Authenticated As String
    Dim maPlaceHolder As New PlaceHolder
    Dim obj_Tabs As UserControl
    Dim obj_LoginCtrl As UserControl
    Dim obj_WelcomCtrl As UserControl
    Dim obj_bannerCtrl As UserControl

    Dim obj_Navi As UserControl
    Dim obj_Navihome As UserControl
    Dim qry As String
    Dim Bizconnect As New BizConnectClass
    Public Sub ChkAuthentication()
        obj_Authenticated = Session("Authenticated").ToString()
        maPlaceHolder = CType(Master.FindControl("P1"), PlaceHolder)
        If Not IsDBNull(maPlaceHolder) Then
            obj_Tabs = CType(maPlaceHolder.FindControl("right1"), UserControl)
            If Not IsDBNull(obj_Tabs) Then
                obj_LoginCtrl = CType(obj_Tabs.FindControl("Login1"), UserControl)
                obj_WelcomCtrl = CType(obj_Tabs.FindControl("Welcome1"), UserControl)

                obj_Navi = CType(obj_Tabs.FindControl("Navii"), UserControl)
                Dim contp As ContentPlaceHolder
                contp = CType(Master.FindControl("ContentPlaceHolder1"), ContentPlaceHolder)
                obj_Navihome = CType(contp.FindControl("navihome1"), UserControl)

                If Not IsDBNull(obj_LoginCtrl) And Not IsDBNull(obj_WelcomCtrl) Then

                    If obj_Authenticated = "1" Then

                        SetVisualON()
                    Else
                        SetVisualOFF()

                    End If

                Else
                End If

            Else
            End If
        End If
    End Sub
    Public Sub SetVisualON()

        obj_LoginCtrl.Visible = False
        obj_WelcomCtrl.Visible = True
        'obj_Navi.Visible = False
        'obj_Navihome.Visible = True

    End Sub
    Public Sub SetVisualOFF()

        obj_LoginCtrl.Visible = True
        obj_WelcomCtrl.Visible = False
        'obj_Navi.Visible = True
        'obj_Navihome.Visible = False
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ChkAuthentication()
        'filllocation()
    End Sub
    'Sub filllocation()
        'Dim ds As DataSet
       'ds = Bizconnect.get_LocationType()

        'DDLLocation.DataSource = ds
        'DDLLocation.DataTextField = "LocationType"
        'DDLLocation.DataValueField = "LocationTypeID"
        'DDLLocation.DataBind()
    'End Sub

    Protected Sub Btn_submit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btn_submit.Click
        Dim res As Integer
        res = Bizconnect.Insert_Client(Txt_companyname.Text, txt_noE.Text, Txt_YOE.Text, txt_Annualturnover.Text, txt_url.Text, DDLLocation.SelectedValue, Txt_address.Text, Txt_city.Text, Txt_state.Text, txt_pincode.Text, txt_Boardno.Text, Txt_fax.Text, txt_Email.Text, Txt_country.Text)

    End Sub
End Class
