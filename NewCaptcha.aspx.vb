Imports VerificationCode
Partial Class NewCaptcha
    Inherits System.Web.UI.Page
    Dim captcha As New VerficationCode
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Session("vcode") = captcha.GenerateVCodeImage()
    End Sub
End Class
