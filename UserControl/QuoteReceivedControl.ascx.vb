Imports System.Data
Imports System.Data.SqlClient
Partial Class UserControl_QuoteReceivedrControl
    Inherits System.Web.UI.UserControl
    Dim ds As New DataSet
    Dim obj_Class As New BizConnectClass
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        gridbind()
    End Sub
    Sub gridbind()
        Try

            Session("UserId") = "1"
            Dim dt As New DataTable
            Dim dr As DataRow
            Dim traveldate As DateTime
            dt.Columns.Add("Adid")
            dt.Columns.Add("source")
            dt.Columns.Add("designation")
            dt.Columns.Add("truckcapacity")
            dt.Columns.Add("traveltype")
            dt.Columns.Add("truckreq")
            dt.Columns.Add("cost")
            dt.Columns.Add("quoteid")
            dt.Columns.Add("trans")
            dt.Columns.Add("trucksreqed")
            dt.Columns.Add("QuotedDate")

            ds = obj_Class.GetQuotesReceived(Session("UserId").ToString())
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1

                If traveldate <> ds.Tables(0).Rows(i).Item(0) Then

                    traveldate = ds.Tables(0).Rows(i).Item(0)
                    dr = dt.NewRow()
                    dr(0) = Format(ds.Tables(0).Rows(i).Item(0), "dd/MMM/yyyy")
                    dt.Rows.Add(dr)
                End If

                dr = dt.NewRow()
                dr(0) = ds.Tables(0).Rows(i).Item(1)
                dr(1) = ds.Tables(0).Rows(i).Item(2)
                dr(2) = ds.Tables(0).Rows(i).Item(3)
                dr(3) = ds.Tables(0).Rows(i).Item(11) + "/" + ds.Tables(0).Rows(i).Item(4)
                dr(4) = ds.Tables(0).Rows(i).Item(10)
                dr(5) = ds.Tables(0).Rows(i).Item(8)
                dr(6) = ds.Tables(0).Rows(i).Item(9)
                dr(7) = ds.Tables(0).Rows(i).Item(5)
                dr(8) = ds.Tables(0).Rows(i).Item(6)
                dr(9) = ds.Tables(0).Rows(i).Item(7)
                dr(10) = ds.Tables(0).Rows(i).Item(12)
                dt.Rows.Add(dr)


                GridQuote.DataSource = dt
                GridQuote.DataBind()

            Next

        Catch ex As Exception

        End Try

    End Sub


    
    Protected Sub GridQuote_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridQuote.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then

            Dim LblAdid As Label = CType(e.Row.FindControl("lblAdID"), Label)

            If IsDate(LblAdid.Text) Then


                e.Row.Cells(0).ForeColor = System.Drawing.Color.Red
            End If
        End If

    End Sub

    Protected Sub btnexport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnexport.Click
        ExportToExcel("QuoteReceived.xls", GridQuote)
    End Sub
    Public Overloads Sub VerifyRenderingInServerForm(ByVal control As Control)

    End Sub
    Private Sub ExportToExcel(ByVal strFileName As String, ByVal oGrid As GridView)

        HttpContext.Current.Response.Clear()
        HttpContext.Current.Response.Buffer = True
        HttpContext.Current.Response.ContentType = "application/vnd.ms-excel"
        'HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=\"" + exportFile + " \ "")

        'Clear the character set
        HttpContext.Current.Response.Charset = ""

        'Create a string and Html writer needed for output
        Dim oStringWriter As New System.IO.StringWriter
        Dim oHtmlTextWriter As New System.Web.UI.HtmlTextWriter(oStringWriter)
        'Clear the controls from the pased grid
        ' ClearControls(oGrid)

        'Show grid lines
        oGrid.GridLines = GridLines.Both

        'Color header
        oGrid.HeaderStyle.BackColor = System.Drawing.Color.LightGray

        'Render the grid to the writer
        oGrid.RenderControl(oHtmlTextWriter)

        'Write out the response (file), then end the response
        HttpContext.Current.Response.Write(oStringWriter.ToString())
        HttpContext.Current.Response.End()



    End Sub
    'private sub ClearControls(Control control)

    '    'Recursively loop through the controls, calling this method
    '    For i = Control.Controls.Count - 1 To i >= 0

    '        ClearControls(Control.Controls(i))
    '    Next i

    '    'If we have a control that is anything other than a table cell
    '    if (!(control is TableCell))
    '    {
    '        if (control.GetType().GetProperty("SelectedItem") != null)
    '        {
    '            LiteralControl literal = new LiteralControl();
    '            control.Parent.Controls.Add(literal);
    '            Try
    '            {
    '                literal.Text = (string)control.GetType().GetProperty("SelectedItem").GetValue(control, null);
    '            }
    '            Catch
    '            {
    '            }
    '            control.Parent.Controls.Remove(control);
    '        }
    '        else
    '            if  ( control.GetType().GetProperty("Text")) != null

    '                    LiteralControl(Literal = New LiteralControl())
    '                    Control.Parent.Controls.Add(Literal)
    '                literal.Text = (string)control.GetType().GetProperty("Text").GetValue(control, null)
    '                    Control.Parent.Controls.Remove(Control)


    '                    Return
    'End Sub
End Class
