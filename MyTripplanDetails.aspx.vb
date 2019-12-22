Imports System.Data
Imports System.Data.SqlClient

Partial Class MyTripplanDetails
    Inherits System.Web.UI.Page
    Dim obj_Authenticated As String
    Dim maPlaceHolder As New PlaceHolder
    Dim obj_Tabs As UserControl
    Dim obj_LoginCtrl As UserControl
    Dim obj_WelcomCtrl As UserControl
    Dim obj_bannerCtrl As UserControl

    Dim obj_Navi As UserControl
    Dim obj_Navihome As UserControl
    Dim obj_class As New BizConnectClass
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ChkAuthentication()
        GetData()
    End Sub
    Sub GetData()
        Try

       
            Dim ds As DataSet
            ds = obj_class.GetMyTripplan(Session("UserId").ToString())
            LblPlanno.Text = ds.Tables(0).Rows(0).Item(1)
            Lbltraveldate.Text = ds.Tables(0).Rows(0).Item(0)
            Lblsource.Text = ds.Tables(0).Rows(0).Item(2)
            LblDesination.Text = ds.Tables(0).Rows(0).Item(3)
            Lblnooftrucks.Text = ds.Tables(0).Rows(0).Item(4)
            LblTrucktype.Text = ds.Tables(0).Rows(0).Item(5)
            Lbltraveltype.Text = ds.Tables(0).Rows(0).Item(6)
            Lblpostedon.Text = ds.Tables(0).Rows(0).Item(7)
            Lblproductname.Text = ds.Tables(0).Rows(0).Item(9)
            LblQuantity.Text = ds.Tables(0).Rows(0).Item(10)
            Lblcostpertruck.Text = ds.Tables(0).Rows(0).Item(11)
            Lblvolume.Text = ds.Tables(0).Rows(0).Item(12)
            Lblweight.Text = ds.Tables(0).Rows(0).Item(13)
            Lbllength.Text = ds.Tables(0).Rows(0).Item(14)
            Lblwidth.Text = ds.Tables(0).Rows(0).Item(15)
            Lblheight.Text = ds.Tables(0).Rows(0).Item(16)
            If ds.Tables(0).Rows(0).Item(17) = "1" Then

                lblEncl.Text = "Open"
            Else
                lblEncl.Text = "Closed"
            End If


            lblTransit.Text = ds.Tables(0).Rows(0).Item(18)
        Catch ex As Exception

        End Try
    End Sub
    Public Sub ChkAuthentication()
        obj_Authenticated = Session("Authenticated").ToString()
        maPlaceHolder = CType(Master.FindControl("P1"), PlaceHolder)
        If Not IsDBNull(maPlaceHolder) Then
            obj_Tabs = CType(maPlaceHolder.FindControl("loginheader1"), UserControl)
            If Not IsDBNull(obj_Tabs) Then
                obj_LoginCtrl = CType(obj_Tabs.FindControl("login1"), UserControl)
                obj_WelcomCtrl = CType(obj_Tabs.FindControl("welcome1"), UserControl)

                'obj_Navi = CType(obj_Tabs.FindControl("Navii"), UserControl)
                'Dim contp As ContentPlaceHolder
                'contp = CType(Master.FindControl("ContentPlaceHolder1"), ContentPlaceHolder)
                'obj_Navihome = CType(contp.FindControl("navihome1"), UserControl)

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
End Class
