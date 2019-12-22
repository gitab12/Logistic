Imports System.Data
Imports System.Data.SqlClient
Partial Class Myassignment
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
        If Not IsPostBack Then
            ChkAuthentication()
            gridbind()
            ' bindwindow()
        End If

    End Sub
    Sub gridbind()
        Try

            Dim ds As New DataSet
            Dim dt As New DataTable
            Dim dr As DataRow
            dt.Columns.Add("select")
            dt.Columns.Add("adid")
            dt.Columns.Add("from")
            dt.Columns.Add("to")
            dt.Columns.Add("trucktype")
            dt.Columns.Add("Bcost")
            dt.Columns.Add("cost")
            dt.Columns.Add("trucks")
            dt.Columns.Add("assigned")
            dt.Columns.Add("saving")
            dt.Columns.Add("status")
            dt.Columns.Add("client")
            dt.Columns.Add("quoteid")
            dt.Columns.Add("transname")
            dt.Columns.Add("recid")
            dt.Columns.Add("postid")

            ds = obj_class.BiZconnect_Assignment()
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                dr = dt.NewRow()
                dr(1) = ds.Tables(0).Rows(i).Item(0)
                dt.Rows.Add(dr)


                dr = dt.NewRow()
                dr(0) = "check"
                dr(1) = ds.Tables(0).Rows(i).Item(1)
                dr(2) = "from"
                dr(3) = "to"
                dr(4) = "Rigidtruck.50tons"
                dr(5) = ds.Tables(0).Rows(i).Item(4)
                dr(6) = ds.Tables(0).Rows(i).Item(8)
                dr(7) = ds.Tables(0).Rows(i).Item(3)
                dr(8) = ds.Tables(0).Rows(i).Item(9)
                dr(9) = (Val(dr(5)) - Val(dr(6))) * Val(dr(8))
                dr(10) = "2/2"
                dr(11) = ds.Tables(0).Rows(i).Item(2)
                dr(12) = ds.Tables(0).Rows(i).Item(6)
                dr(13) = ds.Tables(0).Rows(i).Item(5)
                dr(14) = ds.Tables(0).Rows(i).Item(10)
                dr(15) = ds.Tables(0).Rows(i).Item(11)
                dt.Rows.Add(dr)

            Next


            GridAssign.DataSource = dt
            GridAssign.DataBind()

        Catch ex As Exception

        End Try
    End Sub


    Protected Sub GridAssign_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridAssign.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then

            Dim LblAdid As Label = CType(e.Row.FindControl("lbladid"), Label)
            Dim check As CheckBox = CType(e.Row.FindControl("check"), CheckBox)

   

            If IsDate(LblAdid.Text) Then

                e.Row.Cells(1).ForeColor = System.Drawing.Color.Red
                e.Row.Cells(1).Font.Bold = True
                check.Visible = False
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


    Sub bindwindow()

        Dim dt As New DataTable
        Dim dr As DataRow


        dt.Columns.Add("Select")
        dt.Columns.Add("quoteid")
        dt.Columns.Add("trucks")
        dt.Columns.Add("cost")
        dt.Columns.Add("assign")
        dt.Columns.Add("status")
        dt.Columns.Add("approved")

        dr = dt.NewRow()

        dr(0) = "Saint Gobain"
        dr(1) = "2001"
        dr(2) = "30"
        dr(3) = "27000"
        dr(4) = "30"
        dr(5) = "Approved"
        dr(6) = "30"
        dt.Rows.Add(dr)


        dr = dt.NewRow()
        dr(0) = "LG Electronics"
        dr(1) = "2002"
        dr(2) = "20"
        dr(3) = "30000"
        dr(4) = "20"
        dr(5) = "Approved"
        dr(6) = "20"
        dt.Rows.Add(dr)


        Gridwindow.DataSource = dt
        Gridwindow.DataBind()
    End Sub

    Protected Sub Butassignment_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Butassignment.Click
        Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("SCMCon").ToString)
        con.Open()
        Dim resp As Integer
        Dim checkassign1 As CheckBox
        Dim replyid, Costpertruck, lblAssignedTrucks, lblpostid As Label
       
        For i As Integer = 0 To GridAssign.Rows.Count - 1
            checkassign1 = GridAssign.Rows(i).FindControl("Check")

            If checkassign1.Checked Then
                Costpertruck = GridAssign.Rows(i).FindControl("lblcost")
                lblAssignedTrucks = GridAssign.Rows(i).FindControl("lblAssignedTrucks")
                
                replyid = GridAssign.Rows(i).FindControl("lblrid")
                lblpostid = GridAssign.Rows(i).FindControl("lblpostid")
                resp = obj_class.Update_Assignment(Costpertruck.Text, lblAssignedTrucks.Text, replyid.Text, lblpostid.Text)

                'Sending SMS

                ' SendSMS(replyid.Text)
                'Sending Email


            End If
        Next
        If resp = 1 Then
            ClientScript.RegisterStartupScript(Me.GetType(), "clientscript", "alert ('Trip Assigned')", True)
        End If
        'Summary()

        gridbind()

    End Sub
End Class
