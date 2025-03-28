Public Class eInvestMuebles

#Region "Propiedad"

    Private _codigo_mue As Integer
    Private _anio_mue As Integer
    Private _coleccion_mue As Integer
    Private _tipoarchivo_mue As Integer
    Private _archivo_mue As Integer
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

    Public Property codigo_mue() As Integer
        Get
            Return _codigo_mue
        End Get
        Set(ByVal value As Integer)
            _codigo_mue = value

        End Set
    End Property

    Public Property anio_mue() As Integer
        Get
            Return _anio_mue
        End Get
        Set(ByVal value As Integer)
            _anio_mue = value

        End Set
    End Property

    Public Property coleccion_mue() As Integer
        Get
            Return _coleccion_mue
        End Get
        Set(ByVal value As Integer)
            _coleccion_mue = value

        End Set
    End Property

    Public Property tipoarchivo_mue() As String
        Get
            Return _tipoarchivo_mue
        End Get
        Set(ByVal value As String)
            _tipoarchivo_mue = value

        End Set
    End Property

    Public Property archivo_mue() As String
        Get
            Return _archivo_mue
        End Get
        Set(ByVal value As String)
            _archivo_mue = value

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
                 ByVal ln_codigo_mue As Integer _
                , ByVal ln_anio_mue As Integer _
                , ByVal ln_coleccion_mue As Integer _
                , ByVal ln_tipoarchivo_mue As Integer _
                , ByVal ln_archivo_mue As Integer _
                , ByVal ln_activo As Integer _
                , ByVal ld_fechareg As Date _
                , ByVal ls_usuarioreg As String _
                , ByVal ld_fechamod As Date _
                , ByVal ls_usuariomod As String _
                )
        _codigo_mue = ln_codigo_mue
        _anio_mue = ln_anio_mue
        _coleccion_mue = ln_coleccion_mue
        _tipoarchivo_mue = ln_tipoarchivo_mue
        _archivo_mue = ln_archivo_mue
        _activo = ln_activo
        _fechareg = ld_fechareg
        _usuarioreg = ls_usuarioreg
        _fechamod = ld_fechamod
        _usuariomod = ls_usuariomod

    End Sub

#End Region

End Class


