Public Class eAfectacionInmueble

#Region "Propiedad"

    Private _codigo_ain As Integer
    Private _fecha_ain As Date
    Private _sitio_ain As String
    Private _denunciante_ain As String
    Private _denunciado_ain As String
    Private _tipoafect_ain As String
    Private _inspeccion_ain As Integer
    Private _realizoinspec_ain As String
    Private _instancia_ain As Integer

    Private _fechareg As Date
    Private _usuarioreg As String
    Private _fechamod As Date
    Private _usuariomod As String
    Private _activo As Integer

    Public TipoOperacion As String

    Public Modificado As Boolean

    Public _param1 As String
    Public _param2 As String
    Public _param3 As String

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

    Public Property codigo_ain() As Integer
        Get
            Return _codigo_ain
        End Get
        Set(ByVal value As Integer)
            _codigo_ain = value

        End Set
    End Property

    Public Property sitio_ain() As String
        Get
            Return _sitio_ain
        End Get
        Set(ByVal value As String)
            _sitio_ain = value

        End Set
    End Property

    Public Property denunciante_ain() As String
        Get
            Return _denunciante_ain
        End Get
        Set(ByVal value As String)
            _denunciante_ain = value

        End Set
    End Property

    Public Property denunciado_ain() As String
        Get
            Return _denunciado_ain
        End Get
        Set(ByVal value As String)
            _denunciado_ain = value

        End Set
    End Property

    Public Property tipoafect_ain() As String
        Get
            Return _tipoafect_ain
        End Get
        Set(ByVal value As String)
            _tipoafect_ain = value

        End Set
    End Property

    Public Property inspeccion_ain() As Integer
        Get
            Return _inspeccion_ain
        End Get
        Set(ByVal value As Integer)
            _inspeccion_ain = value

        End Set
    End Property

    Public Property realizoinspec_ain() As String
        Get
            Return _realizoinspec_ain
        End Get
        Set(ByVal value As String)
            _realizoinspec_ain = value

        End Set
    End Property

    Public Property instancia_ain() As Integer
        Get
            Return _instancia_ain
        End Get
        Set(ByVal value As Integer)
            _instancia_ain = value

        End Set
    End Property

    Public Property fecha_ain() As Date
        Get
            Return _fecha_ain
        End Get
        Set(ByVal value As Date)
            _fecha_ain = value

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

    Public Property activo() As Integer
        Get
            Return _activo
        End Get
        Set(ByVal value As Integer)
            _activo = value

        End Set
    End Property

#End Region
#Region "Constructor"
    Public Sub New()
        _sitio_ain = String.Empty
        _denunciante_ain = String.Empty
        _denunciado_ain = String.Empty
        _tipoafect_ain = String.Empty
        _realizoinspec_ain = String.Empty
        _usuarioreg = String.Empty
        _usuariomod = String.Empty
    End Sub

    Public Sub New( _
              ByVal ln_codigo_ain As Integer _
              , ByVal ls_sitio_ain As String _
              , ByVal ls_denunciante_ain As String _
              , ByVal ls_denunciado_ain As String _
              , ByVal ls_tipoafect_ain As String _
              , ByVal ln_inspeccion_ain As Integer _
              , ByVal ls_realizoinspec_ain As String _
              , ByVal ld_fecha_ain As Date _
              , ByVal ln_instancia_ain As Integer _
              , ByVal ld_fechareg As Date _
              , ByVal ls_usuarioreg As String _
              , ByVal ld_fechamod As Date _
              , ByVal ls_usuariomod As String _
              , ByVal ln_activo As Integer _
              , ByVal ln_id_dgc As Integer _
           )
        _codigo_ain = ln_codigo_ain
        _sitio_ain = ls_sitio_ain
        _denunciante_ain = ls_denunciante_ain
        _denunciado_ain = ls_denunciado_ain
        _tipoafect_ain = ls_tipoafect_ain
        _inspeccion_ain = ln_inspeccion_ain
        _realizoinspec_ain = ls_realizoinspec_ain
        _instancia_ain = ln_instancia_ain
        _fecha_ain = ld_fecha_ain
        _fechareg = ld_fechareg
        _usuarioreg = ls_usuarioreg
        _fechamod = ld_fechamod
        _usuariomod = ls_usuariomod
        _activo = ln_activo
    End Sub

#End Region

End Class
