Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Web.Security
Imports EncriptaCodigos
Imports System.Security
Imports System.Security.Cryptography

Imports cEntidad
Imports cLogica
Partial Class _Default

    Inherits System.Web.UI.Page
    Private oeAlumno As eAlumno
    Private olAlumno As lAlumno
    Private dt As DataTable

    Private codigoFoto As String = String.Empty

    Protected Sub lnkbtnIngresar1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkbtnIngresar1.Click
        Try
            dt = New DataTable
            oeAlumno = New eAlumno
            olAlumno = New lAlumno

            Dim fn As New lFunciones
            oeAlumno.codigoUniver_Alu = Me.txtUsername.Text.ToString.Trim
            oeAlumno.password_Alu = encriptarCadena(Me.txtPassword1.Text.ToString.Trim)

            'oeAlumno.codigoUniver_Alu = "45407444"
            'oeAlumno.password_Alu = "1234"
            Dim foto As String

            dt = olAlumno.consultarAcceso(oeAlumno)

            '#001 INICIO - JR
            If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                FormsAuthentication.RedirectFromLoginPage(1 & CStr(Now), 1)
                Session.Add("codigo_per", fn.EncrytedString64(dt.Rows(0).Item("codigo_per").ToString()))
                Session.Add("apellidoPat", dt.Rows(0).Item("apellidopat_per").ToString())
                Session.Add("apellidoMat", dt.Rows(0).Item("apellidomat_per").ToString())
                Session.Add("nombres", dt.Rows(0).Item("nombres_per").ToString())
                Session.Add("estado", dt.Rows(0).Item("estadoactual_per").ToString())
                Session.Add("sexo", dt.Rows(0).Item("sexo_per").ToString())
                Session.Add("tipoident", dt.Rows(0).Item("tipodocident_per").ToString())
                Session.Add("dni", dt.Rows(0).Item("nrodocident_per").ToString())
                Session.Add("foto", dt.Rows(0).Item("foto_per").ToString())
                Session.Add("email", dt.Rows(0).Item("email_per").ToString())
                Session.Add("email2", dt.Rows(0).Item("email2_per").ToString())
                Session.Add("activo", dt.Rows(0).Item("activo_per").ToString())
                Session.Add("codigo_Tfu", dt.Rows(0).Item("codigo_Tfu").ToString())
                foto = oeAlumno.foto_Alu
            Else
                Me.lblMensaje1.Text = "Ingrese correctamente sus datos"
                Me.txtPassword1.Focus()
            End If

            ' MsgBox(encriptarCadena(Me.txtPassword.Text.ToString.Trim))
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
    End Sub

    Private Function encriptarCadena(ByVal cadena As String) As String
        Try
            Dim sha As New SHA1CryptoServiceProvider ' declare sha as a new SHA1CryptoServiceProvider
            Dim bytesToHash() As Byte ' and here is a byte variable

            bytesToHash = System.Text.Encoding.ASCII.GetBytes(cadena) ' covert the password into ASCII code

            bytesToHash = sha.ComputeHash(bytesToHash) ' this is where the magic starts and the encryption begins

            Dim encPassword As String = ""

            For Each b As Byte In bytesToHash
                encPassword += b.ToString("x2").ToUpper
            Next

            'Return "0x" & encPassword & "00000000000000000000" ' boom there goes the encrypted password!
            Return "0x" & encPassword ' boom there goes the encrypted password!

        Catch ex As Exception
            Throw
        End Try

    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            'Server.Transfer("main.aspx", True)
            If (Request.QueryString("tipo") <> "") Then
                Dim tipo As Integer
                tipo = decode(Request.QueryString("tipo"))

            End If

            'End If

        Catch ex As Exception

        End Try

    End Sub

    Function encode(ByVal str As String) As String
        Return (Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(str)))
    End Function

    Function decode(ByVal str As String) As String
        Return System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(str))
    End Function

End Class
