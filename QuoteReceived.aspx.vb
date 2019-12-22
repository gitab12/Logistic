
Partial Class QuoteReceived
    Inherits System.Web.UI.Page
    Dim obj_Authenticated As String
    Dim maPlaceHolder As New PlaceHolder
    Dim obj_Tabs As UserControl
    Dim obj_LoginCtrl As UserControl
    Dim obj_WelcomCtrl As UserControl
    Dim obj_bannerCtrl As UserControl

    Dim obj_Navi As UserControl
    Dim obj_Navihome As UserControl
    Public Sub ChkAuthentication()


        obj_Authenticated = Session("Authenticated").ToString()
        maPlaceHolder = CType(Master.FindControl("P1"), PlaceHolder)
        If Not IsDBNull(maPlaceHolder) Then

            obj_Tabs = CType(maPlaceHolder.FindControl("loginheader1"), UserControl)
            If Not IsDBNull(obj_Tabs) Then


                obj_LoginCtrl = CType(obj_Tabs.FindControl("login1"), UserControl)
                obj_WelcomCtrl = CType(obj_Tabs.FindControl("Welcome1"), UserControl)

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
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ChkAuthentication()
    End Sub
  
End Class

