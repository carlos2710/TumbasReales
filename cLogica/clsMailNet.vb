Public Class clsMailNet
    Protected _mServidor As String
    Protected _mPuerto As Integer
    Protected _mUser As String
    Protected _mPass As String

    Sub New()
        '_mServidor = "172.16.1.7" '"192.168.2.4" "172.16.1.7"  PRODUCCION
        _mServidor = "10.10.1.25" '"192.168.2.4" "172.16.1.7 SERVIDOR DE PRUEBAS"

        _mPuerto = 2526


        '_mPuerto = 25
    End Sub

    Sub New(ByVal Servidor As String, ByVal Puerto As Integer)
        Me.New()
        _mServidor = Servidor
        _mPuerto = Puerto
    End Sub

    Sub New(ByVal Servidor As String, ByVal puerto As Integer, ByVal Usuario As String, ByVal Password As String)
        Me.New()
        Me.Servidor = Servidor
        Me.Puerto = puerto
        Me.User = Usuario
        Me.Password = Password
    End Sub

    'Nombre del Servidor
    Public WriteOnly Property Servidor() As String
        Set(ByVal Value As String)
            _mServidor = Value
        End Set
    End Property

    'Nombre del Usuario
    Public WriteOnly Property User() As String
        Set(ByVal value As String)
            _mUser = value
        End Set
    End Property

    'Nombre de la contraseña
    Public WriteOnly Property Password() As String
        Set(ByVal value As String)
            _mPass = value
        End Set
    End Property

    'Numero del Puerto
    Public WriteOnly Property Puerto() As Integer
        Set(ByVal value As Integer)
            _mPuerto = value
        End Set
    End Property

    Public Function EnviarMail(ByVal De As String, ByVal nombreenvia As String, ByVal Para As String, ByVal Asunto As String, _
        ByVal Mensaje As String, ByVal HTML As Boolean, Optional ByVal NombreResponderA As String = "", Optional ByVal MailResponderA As String = "") As Boolean
        Dim correo As New System.Net.Mail.MailMessage()
        Try
            Dim Destinos() As String
            Destinos = Split(Para, ";")

            'correo.From = New System.Net.Mail.MailAddress(De, nombreenvia)
            correo.From = New System.Net.Mail.MailAddress("avasipan@gmail.com", nombreenvia)
            If Len(NombreResponderA) <> 0 AndAlso Len(MailResponderA) <> 0 Then
                correo.ReplyTo = New System.Net.Mail.MailAddress(MailResponderA, NombreResponderA)
            End If

            For i As Integer = 0 To Destinos.Length - 1
                correo.To.Add(Trim(Destinos(i)))
            Next

            correo.Subject = Asunto
            correo.Body = Mensaje
            correo.IsBodyHtml = HTML
            correo.Priority = System.Net.Mail.MailPriority.High

            'Dim smtp As New System.Net.Mail.SmtpClient
            'smtp.Port = 465
            'smtp.Host = "smtp.gmail.com"
            'smtp.UseDefaultCredentials = False
            'smtp.DeliveryMethod = Net.Mail.SmtpDeliveryMethod.Network

            'smtp.EnableSsl = True
            'smtp.Credentials = New System.Net.NetworkCredential("avasipan@gmail.com", "jnni0r*jr*22*1")
            'smtp.EnableSsl = True
            Dim smtp As New System.Net.Mail.SmtpClient
            smtp.Host = "smtp.gmail.com"
            smtp.Port = 587
            smtp.Credentials = New System.Net.NetworkCredential("avasipan@gmail.com", "datasipan1987")
            smtp.EnableSsl = True

            smtp.Send(correo)

            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Public Function EnviarMail_cc(ByVal De As String, ByVal nombreenvia As String, ByVal Para As String, ByVal Asunto As String, _
    ByVal Mensaje As String, ByVal HTML As Boolean, Optional ByVal NombreResponderA As String = "", Optional ByVal MailResponderA As String = "", Optional ByVal Copia As String = "") As Boolean

        Dim correo As New System.Net.Mail.MailMessage()

        Try
            correo.From = New System.Net.Mail.MailAddress(De, nombreenvia)
            correo.From = New System.Net.Mail.MailAddress("correocampo", nombreenvia)

            If Len(NombreResponderA) <> 0 AndAlso Len(MailResponderA) <> 0 Then
                correo.ReplyTo = New System.Net.Mail.MailAddress(MailResponderA, NombreResponderA)
            End If
            correo.To.Add(Para)
            correo.CC.Add(copia)
            correo.Subject = Asunto
            correo.Body = Mensaje
            correo.IsBodyHtml = HTML
            correo.Priority = System.Net.Mail.MailPriority.High

            Dim smtp As New System.Net.Mail.SmtpClient
            smtp.Port = _mPuerto
            smtp.Host = _mServidor
            smtp.DeliveryMethod = Net.Mail.SmtpDeliveryMethod.Network

            'smtp.UseDefaultCredentials = True

            If Len(_mUser) <> 0 And Len(_mPass) <> 0 Then
                smtp.UseDefaultCredentials = True
            Else
                smtp.Credentials = New System.Net.NetworkCredential("campo", "123")
                'smtp.Credentials = New System.Net.NetworkCredential("campo, "NLH951")
            End If

            smtp.EnableSsl = False

            smtp.Send(correo)

            Return True
        Catch ex As Exception
            Return ex.Message
            'Return False
        End Try
    End Function

    Public Sub EnviarMailVarios(ByVal De As String, ByVal nombreenvia As String, ByVal Para As String, ByVal asunto As String, ByVal Mensaje As String, ByVal HTML As Boolean, _
    Optional ByVal NombreResponderA As String = "", Optional ByVal MailResponderA As String = "")
        Dim Destinos() As String
        Destinos = Split(Para, ";")
        Dim correo As New System.Net.Mail.MailMessage()

        'correo.From = New System.Net.Mail.MailAddress(De, nombreenvia)
        correo.From = New System.Net.Mail.MailAddress("correocampo", nombreenvia)
        If Len(NombreResponderA) <> 0 AndAlso Len(MailResponderA) <> 0 Then
            correo.ReplyTo = New System.Net.Mail.MailAddress(MailResponderA, NombreResponderA)
        End If

        For i As Integer = 0 To Destinos.Length - 1
            correo.To.Add(Trim(Destinos(i)))
        Next

        correo.Subject = asunto
        correo.Body = Mensaje
        correo.IsBodyHtml = HTML
        correo.Priority = System.Net.Mail.MailPriority.High

        Dim smtp As New System.Net.Mail.SmtpClient
        smtp.Port = _mPuerto
        smtp.Host = _mServidor
        smtp.DeliveryMethod = Net.Mail.SmtpDeliveryMethod.Network
        smtp.EnableSsl = False

        'smtp.UseDefaultCredentials = True

        If Len(_mUser) <> 0 And Len(_mPass) <> 0 Then
            smtp.UseDefaultCredentials = True
        Else
            smtp.Credentials = New System.Net.NetworkCredential("campo", "123")
        End If

        smtp.EnableSsl = False

        smtp.Send(correo)
    End Sub

    Public Function fnEnviarMailVarios(ByVal De As String, ByVal nombreenvia As String, ByVal Para As String, ByVal asunto As String, ByVal Mensaje As String, ByVal HTML As Boolean, _
    Optional ByVal NombreResponderA As String = "", Optional ByVal MailResponderA As String = "") As Boolean
        Try

            Dim Destinos() As String
            Destinos = Split(Para, ";")
            Dim correo As New System.Net.Mail.MailMessage()

            'correo.From = New System.Net.Mail.MailAddress(De, nombreenvia)
            correo.From = New System.Net.Mail.MailAddress("avasipan@gmail.com", nombreenvia)
            If Len(NombreResponderA) <> 0 AndAlso Len(MailResponderA) <> 0 Then
                correo.ReplyTo = New System.Net.Mail.MailAddress(MailResponderA, NombreResponderA)
            End If

            For i As Integer = 0 To Destinos.Length - 1
                correo.To.Add(Trim(Destinos(i)))
            Next

            correo.Subject = asunto
            correo.Body = Mensaje
            correo.IsBodyHtml = HTML
            correo.Priority = System.Net.Mail.MailPriority.High

            'Dim smtp As New System.Net.Mail.SmtpClient
            'smtp.Port = 465
            'smtp.Host = "smtp.gmail.com"
            'smtp.UseDefaultCredentials = False
            'smtp.DeliveryMethod = Net.Mail.SmtpDeliveryMethod.Network

            'smtp.EnableSsl = True
            'smtp.Credentials = New System.Net.NetworkCredential("avasipan@gmail.com", "jnni0r*jr*22*1")
            'smtp.EnableSsl = True
            Dim smtp As New System.Net.Mail.SmtpClient
            smtp.Host = "smtp.gmail.com"
            smtp.Port = 587
            smtp.Credentials = New System.Net.NetworkCredential("avasipan@gmail.com", "datasipan1987")
            smtp.EnableSsl = True

            smtp.Send(correo)

            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function
End Class

