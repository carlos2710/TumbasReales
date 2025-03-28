Public Class eUsuario

#Region "Declaracion de variables"
    Private _item As Integer
    Private _codigo_mEst As Integer
    Private _codigo_Men As Integer
    Private _codigo_Apl As Integer
    Private _codigoRaizMen As Integer
    Private _descripcion_Men As String
    Private _enlace As String
    Private _nivel_men As Integer
    Private _orden_men As Integer
    Private _aPaterno As String
    Private _aMaterno As String
    Private _nombres As String
    Private _tsexo As String
    Private _tipodoc As String
    Private _docidentidad As String
    Private _email As String
    Private _email2 As String
    Private _password As String
    Private _codigo_tfu As Integer
    Private _codigo_uap As Integer
    Private _tipouap As String

    Public _param1 As String
    Public _param2 As String
    Public _param3 As String

#End Region

#Region "Propiedades"

    Public Property item() As Integer
        Get
            Return _item
        End Get
        Set(ByVal value As Integer)
            _item = value
        End Set
    End Property
    Public Property codigo_mEst() As Integer
        Get
            Return _codigo_mEst
        End Get
        Set(ByVal value As Integer)
            _codigo_mEst = value
        End Set
    End Property
    Public Property codigo_Men() As Integer
        Get
            Return _codigo_Men
        End Get
        Set(ByVal value As Integer)
            _codigo_Men = value
        End Set
    End Property
    Public Property codigo_Apl() As Integer
        Get
            Return _codigo_Apl
        End Get
        Set(ByVal value As Integer)
            _codigo_Apl = value
        End Set
    End Property
    Public Property codigoRaizMen() As Integer
        Get
            Return _codigoRaizMen
        End Get
        Set(ByVal value As Integer)
            _codigoRaizMen = value
        End Set
    End Property
    Public Property descripcion_Men() As String
        Get
            Return _descripcion_Men
        End Get
        Set(ByVal value As String)
            _descripcion_Men = value
        End Set
    End Property
    Public Property enlace() As String
        Get
            Return _enlace
        End Get
        Set(ByVal value As String)
            _enlace = value
        End Set
    End Property
    Public Property nivel_men() As Integer
        Get
            Return _nivel_men
        End Get
        Set(ByVal value As Integer)
            _nivel_men = value
        End Set
    End Property
    Public Property orden_men() As Integer
        Get
            Return _orden_men
        End Get
        Set(ByVal value As Integer)
            _orden_men = value
        End Set
    End Property
    Public Property param1() As String
        Get
            Return _param1
        End Get
        Set(ByVal value As String)
            _param1 = value
        End Set
    End Property
    Public Property param2() As String
        Get
            Return _param2
        End Get
        Set(ByVal value As String)
            _param2 = value
        End Set
    End Property

    Public Property param3() As String
        Get
            Return _param3
        End Get
        Set(ByVal value As String)
            _param3 = value
        End Set
    End Property

    Public Property aPaterno() As String
        Get
            Return _aPaterno
        End Get
        Set(ByVal value As String)
            _aPaterno = value
        End Set
    End Property

    Public Property aMaterno() As String
        Get
            Return _aMaterno
        End Get
        Set(ByVal value As String)
            _aMaterno = value
        End Set
    End Property
    Public Property nombres() As String
        Get
            Return _nombres
        End Get
        Set(ByVal value As String)
            _nombres = value
        End Set
    End Property
    Public Property tsexo() As String
        Get
            Return _tsexo
        End Get
        Set(ByVal value As String)
            _tsexo = value
        End Set
    End Property


    Public Property tipodoc() As String
        Get
            Return _tipodoc
        End Get
        Set(ByVal value As String)
            _tipodoc = value
        End Set
    End Property
    Public Property docidentidad() As String
        Get
            Return _docidentidad
        End Get
        Set(ByVal value As String)
            _docidentidad = value
        End Set
    End Property
    Public Property email() As String
        Get
            Return _email
        End Get
        Set(ByVal value As String)
            _email = value
        End Set
    End Property
    Public Property email2() As String
        Get
            Return _email2
        End Get
        Set(ByVal value As String)
            _email2 = value
        End Set
    End Property
    Public Property password() As String
        Get
            Return _password
        End Get
        Set(ByVal value As String)
            _password = value
        End Set
    End Property
    Public Property tipouap() As String
        Get
            Return _tipouap
        End Get
        Set(ByVal value As String)
            _tipouap = value
        End Set
    End Property
    Public Property codigo_tfu() As Integer
        Get
            Return _codigo_tfu
        End Get
        Set(ByVal value As Integer)
            _codigo_tfu = value
        End Set
    End Property
    Public Property codigo_uap() As Integer
        Get
            Return _codigo_uap
        End Get
        Set(ByVal value As Integer)
            _codigo_uap = value
        End Set
    End Property


#End Region

#Region "Constructor"
    Public Sub New()
        _descripcion_Men = String.Empty
        _enlace = String.Empty
    End Sub

    Public Sub New(ByVal item As Integer, _
                    ByVal codigo_mEst As Integer, _
                    ByVal codigo_Men As Integer, _
                    ByVal codigo_Apl As Integer, _
                    ByVal codigoRaizMen As Integer, _
                    ByVal descripcion_Men As String, _
                    ByVal enlace As String, _
                    ByVal nivel_men As Integer, _
                    ByVal orden_men As Integer, _
                    ByVal aPaterno As String, _
                    ByVal aMaterno As String, _
                    ByVal nombres As String, _
                    ByVal tsexo As String, _
                    ByVal tipodoc As String, _
                    ByVal docidentidad As String, _
                    ByVal email As String, _
                    ByVal email2 As String, _
                    ByVal password As String, _
                    ByVal codigo_tfu As Integer, _
                    ByVal codigo_uap As Integer, _
                    ByVal tipouap As String _
                    )
        _item = item
        _codigo_mEst = codigo_mEst
        _codigo_Men = codigo_Men
        _codigo_Apl = codigo_Apl
        _codigoRaizMen = codigoRaizMen
        _descripcion_Men = descripcion_Men
        _enlace = enlace
        _nivel_men = nivel_men
        _orden_men = orden_men
        _aPaterno = aPaterno
        _aMaterno = aMaterno
        _nombres = nombres
        _tsexo = tsexo
        _tipodoc = tipodoc
        _docidentidad = docidentidad
        _email = email
        _email2 = email2
        _password = password
        _codigo_tfu = codigo_tfu
        _codigo_uap = codigo_uap
        _tipouap = tipouap
    End Sub
#End Region
End Class
