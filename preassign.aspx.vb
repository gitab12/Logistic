Imports System.Data
Imports System.Data.SqlClient
Partial Class preassign
    Inherits System.Web.UI.Page
    Dim obj_Authenticated As String
    Dim maPlaceHolder As New PlaceHolder
    Dim obj_Tabs As UserControl
    Dim obj_LoginCtrl As UserControl
    Dim obj_WelcomCtrl As UserControl
    Dim obj_bannerCtrl As UserControl

    Dim obj_Navi As UserControl
    Dim obj_Navihome As UserControl
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ChkAuthentication()
        gridbind()
    End Sub
    Sub gridbind()
        Dim dt As New DataTable
        Dim dr As DataRow
        dt.Columns.Add("select")
        dt.Columns.Add("adid")
        dt.Columns.Add("quoteid")
        dt.Columns.Add("clients")
        dt.Columns.Add("trucks")
        dt.Columns.Add("assigned")
        dt.Columns.Add("assignedtrucks")
        dt.Columns.Add("cost")
        dt.Columns.Add("Bcost")
        dt.Columns.Add("saving")

        dr = dt.NewRow()
        dr(1) = "26/Dec/2010"
        dt.Rows.Add(dr)


        dr = dt.NewRow()
        dr(0) = "check"
        dr(1) = "AARMS-1234"
        dr(2) = "Q1"
        dr(3) = "LG"
        dr(4) = "8"
        dr(5) = "10"
        dr(6) = "8"
        dr(7) = "30000"
        dr(8) = "35000"
        dr(9) = "40000"

        dt.Rows.Add(dr)
        dr = dt.NewRow()
        dr(0) = "check"
        dr(1) = "AARMS-1234"
        dr(2) = "Q1"
        dr(3) = "SG"
        dr(4) = "20"
        dr(5) = "50"
        dr(6) = "20"
        dr(7) = "30000"
        dr(8) = "35000"
        dr(9) = "100000"
        dt.Rows.Add(dr)

        dr = dt.NewRow()
        dr(0) = "check"
        dr(1) = "AARMS-1234"
        dr(2) = "Q1"
        dr(3) = "BS"
        dr(4) = "30"
        dr(5) = "50"
        dr(6) = "30"
        dr(7) = "30000"
        dr(8) = "35000"
        dr(9) = "150000"
        dt.Rows.Add(dr)

        dr = dt.NewRow()
        dr(0) = "check"
        dr(1) = "AARMS-1234"
        dr(2) = "Q2"
        dr(3) = "LG"
        dr(4) = "10"
        dr(5) = "15"
        dr(6) = "10"
        dr(7) = "30000"
        dr(8) = "35000"
        dr(9) = "50000"
        dt.Rows.Add(dr)


        dr = dt.NewRow()
        dr(1) = "27/Dec/2010"
        dt.Rows.Add(dr)

        dr = dt.NewRow()
        dr(0) = "check"
        dr(1) = "AARMS-1235"
        dr(2) = "Q1"
        dr(3) = "LG"
        dr(4) = "10"
        dr(5) = "50"
        dr(6) = "10"
        dr(7) = "30000"
        dr(8) = "35000"
        dr(9) = "50000"
        dt.Rows.Add(dr)

        GridAssign.DataSource = dt
        GridAssign.DataBind()
    End Sub


    Protected Sub GridAssign_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridAssign.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then

            Dim LblAdid As Label = CType(e.Row.FindControl("lbladid"), Label)
            Dim check As CheckBox = CType(e.Row.FindControl("check"), CheckBox)
            Dim txtassign As TextBox = CType(e.Row.FindControl("txtassign"), TextBox)


            If IsDate(LblAdid.Text) Then

                e.Row.Cells(1).ForeColor = System.Drawing.Color.Red
                check.Visible = False
                txtassign.Visible = False
            End If
        End If

    End Sub
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
End Class
