
Partial Class Colecciones
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.Page.User.Identity.IsAuthenticated Then
            FormsAuthentication.RedirectToLoginPage()
        End If
        If Session("dni") Is Nothing Then
            FormsAuthentication.RedirectToLoginPage()
        Else
            Me.tfu.Value = Session("codigo_Tfu")
        End If
    End Sub
End Class
