Public Class eSitioArqueI

#Region "Propiedad"

    Private _codigo_arq As Integer
    Private _sitio_arq As String
    Private _tipoarchivo_arq As Integer
    Private _archivo_arq As Integer
    Private _activo As Integer
    Private _fechareg As Date
    Private _usuarioreg As String
    Private _fechamod As Date
    Private _usuariomod As String

    Public TipoOperacion As String

    Public Modificado As Boolean

    Public _param1 As String
    Public _param2 As String
    Public _param3 As String
    Public _param4 As String

    Event DatoCambiado()

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

    Public Property param4() As String
        Get
            Return _param4
        End Get
        Set(ByVal value As String)
            _param4 = value
        End Set
    End Property

    Public Property codigo_arq() As Integer
        Get
            Return _codigo_arq
        End Get
        Set(ByVal value As Integer)
            _codigo_arq = value

        End Set
    End Property

    Public Property sitio_arq() As String
        Get
            Return _sitio_arq
        End Get
        Set(ByVal value As String)
            _sitio_arq = value

        End Set
    End Property

    Public Property tipoarchivo_arqe() As Integer
        Get
            Return _tipoarchivo_arq
        End Get
        Set(ByVal value As Integer)
            _tipoarchivo_arq = value

        End Set
    End Property

    Public Property archivo_arq() As String
        Get
            Return _archivo_arq
        End Get
        Set(ByVal value As String)
            _archivo_arq = value

        End Set
    End Property

    Public Property activo() As Integer
        Get
            Return _activo
        End Get
        Set(ByVal value As Integer)
            _activo = value

        End Set
    End Property

    Public Property fechareg() As Date
        Get
            Return _fechareg
        End Get
        Set(ByVal value As Date)
            _fechareg = value

        End Set
    End Property

    Public Property usuarioreg() As String
        Get
            Return _usuarioreg
        End Get
        Set(ByVal value As String)
            _usuarioreg = value

        End Set
    End Property

    Public Property fechamod() As Date
        Get
            Return _fechamod
        End Get
        Set(ByVal value As Date)
            _fechamod = value

        End Set
    End Property

    Public Property usuariomod() As String
        Get
            Return _usuariomod
        End Get
        Set(ByVal value As String)
            _usuariomod = value

        End Set
    End Property

#End Region
#Region "Constructor"
    Public Sub New()
        _usuarioreg = String.Empty
        _usuariomod = String.Empty
    End Sub

    Public Sub New( _
                 ByVal ln_codigo_arq As Integer _
                , ByVal ls_sitio_arq As String _
                , ByVal ln_tipoarchivo_arq As Integer _
                , ByVal ln_archivo_arq As Integer _
                , ByVal ln_activo As Integer _
                , ByVal ld_fechareg As Date _
                , ByVal ls_usuarioreg As String _
                , ByVal ld_fechamod As Date _
                , ByVal ls_usuariomod As String _
                )
        _codigo_arq = ln_codigo_arq
        _sitio_arq = ls_sitio_arq
        _tipoarchivo_arq = ln_tipoarchivo_arq
        _archivo_arq = ln_archivo_arq
        _activo = ln_activo
        _fechareg = ld_fechareg
        _usuarioreg = ls_usuarioreg
        _fechamod = ld_fechamod
        _usuariomod = ls_usuariomod

    End Sub

#End Region

End Class


