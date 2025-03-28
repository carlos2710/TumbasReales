Public Class eExposicion

#Region "Propiedad"

    Private _numero As Integer
    Private _codregnac_exp As String
    Private _codpropietario_exp As String
    Private _codexcavacion_exp As String
    Private _otroscodigos_exp As String
    Private _denominacion_exp As String
    Private _sitio_exp As String
    Private _contexto_exp As String
    Private _nombre_exp As String
    Private _lugar_exp As String
    Private _pais_exp As String
    Private _inmueble_exp As String
    Private _resolucacion_exp As String
    Private _institucion_exp As String
    Private _comisario_exp As String
    Private _nropiliza_exp As String
    Private _monto_exp As Double
    Private _salida_exp As Date
    Private _retorno_exp As Date
    Private _fechareg As Date
    Private _usuarioreg As String
    Private _fechamod As Date
    Private _usuariomod As String
    Private _activo_exp As Integer

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

    Public Property numero() As Integer
        Get
            Return _numero
        End Get
        Set(ByVal value As Integer)
            _numero = value

        End Set
    End Property

    Public Property codregnac_exp() As String
        Get
            Return _codregnac_exp
        End Get
        Set(ByVal value As String)
            _codregnac_exp = value

        End Set
    End Property

    Public Property codpropietario_exp() As String
        Get
            Return _codpropietario_exp
        End Get
        Set(ByVal value As String)
            _codpropietario_exp = value

        End Set
    End Property

    Public Property codexcavacion_exp() As String
        Get
            Return _codexcavacion_exp
        End Get
        Set(ByVal value As String)
            _codexcavacion_exp = value

        End Set
    End Property

    Public Property otroscodigos_exp() As String
        Get
            Return _otroscodigos_exp
        End Get
        Set(ByVal value As String)
            _otroscodigos_exp = value

        End Set
    End Property

    Public Property denominacion_exp() As String
        Get
            Return _denominacion_exp
        End Get
        Set(ByVal value As String)
            _denominacion_exp = value

        End Set
    End Property

    Public Property sitio_exp() As String
        Get
            Return _sitio_exp
        End Get
        Set(ByVal value As String)
            _sitio_exp = value

        End Set
    End Property
    Public Property contexto_exp() As String
        Get
            Return _contexto_exp
        End Get
        Set(ByVal value As String)
            _contexto_exp = value

        End Set
    End Property

    Public Property nombre_exp() As String
        Get
            Return _nombre_exp
        End Get
        Set(ByVal value As String)
            _nombre_exp = value

        End Set
    End Property
    Public Property lugar_exp() As String
        Get
            Return _lugar_exp
        End Get
        Set(ByVal value As String)
            _lugar_exp = value

        End Set
    End Property
    Public Property pais_exp() As String
        Get
            Return _pais_exp
        End Get
        Set(ByVal value As String)
            _pais_exp = value

        End Set
    End Property
    Public Property inmueble_exp() As String
        Get
            Return _inmueble_exp
        End Get
        Set(ByVal value As String)
            _inmueble_exp = value

        End Set
    End Property
    Public Property resolucacion_exp() As String
        Get
            Return _resolucacion_exp
        End Get
        Set(ByVal value As String)
            _resolucacion_exp = value

        End Set
    End Property
    Public Property institucion_exp() As String
        Get
            Return _institucion_exp
        End Get
        Set(ByVal value As String)
            _institucion_exp = value

        End Set
    End Property
    Public Property comisario_exp() As String
        Get
            Return _comisario_exp
        End Get
        Set(ByVal value As String)
            _comisario_exp = value

        End Set
    End Property
    Public Property nropiliza_exp() As String
        Get
            Return _nropiliza_exp
        End Get
        Set(ByVal value As String)
            _nropiliza_exp = value

        End Set
    End Property
    Public Property monto_exp() As Double
        Get
            Return _monto_exp
        End Get
        Set(ByVal value As Double)
            _monto_exp = value

        End Set
    End Property

    Public Property salida_exp() As Date
        Get
            Return _salida_exp
        End Get
        Set(ByVal value As Date)
            _salida_exp = value

        End Set
    End Property

    Public Property retorno_exp() As Date
        Get
            Return _retorno_exp
        End Get
        Set(ByVal value As Date)
            _retorno_exp = value

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

    Public Property activo_exp() As Integer
        Get
            Return _activo_exp
        End Get
        Set(ByVal value As Integer)
            _activo_exp = value

        End Set
    End Property

#End Region
#Region "Constructor"
    Public Sub New()
        _codregnac_exp = String.Empty
        _codpropietario_exp = String.Empty
        _codexcavacion_exp = String.Empty
        _otroscodigos_exp = String.Empty
        _denominacion_exp = String.Empty
        _sitio_exp = String.Empty
        _contexto_exp = String.Empty
        _nombre_exp = String.Empty
        _lugar_exp = String.Empty
        _pais_exp = String.Empty
        _inmueble_exp = String.Empty
        _resolucacion_exp = String.Empty
        _institucion_exp = String.Empty
        _comisario_exp = String.Empty
        _nropiliza_exp = String.Empty
        _usuarioreg = String.Empty
        _usuariomod = String.Empty
    End Sub

    Public Sub New( _
              ByVal ln_numero As Integer _
              , ByVal ls_codregnac_exp As String _
              , ByVal ls_codpropietario_exp As String _
              , ByVal ls_codexcavacion_exp As String _
              , ByVal ls_otroscodigos_exp As String _
              , ByVal ls_denominacion_exp As String _
              , ByVal ls_sitio_exp As String _
              , ByVal ls_contexto_exp As String _
              , ByVal ls_nombre_exp As String _
              , ByVal ls_lugar_exp As String _
              , ByVal ls_pais_exp As String _
              , ByVal ls_inmueble_exp As String _
              , ByVal ls_resolucacion_exp As String _
              , ByVal ls_institucion_exp As String _
              , ByVal ls_comisario_exp As String _
              , ByVal ls_nropiliza_exp As String _
              , ByVal ls_monto_exp As Double _
              , ByVal ld_salida_exp As Date _
              , ByVal ld_retorno_exp As Date _
              , ByVal ld_fechareg As Date _
              , ByVal ls_usuarioreg As String _
              , ByVal ld_fechamod As Date _
              , ByVal ls_usuariomod As String _
              , ByVal ln_activo_exp As Integer _
           )
        _numero = ln_numero
        _codregnac_exp = ls_codregnac_exp
        _codpropietario_exp = ls_codpropietario_exp
        _codexcavacion_exp = ls_codexcavacion_exp
        _otroscodigos_exp = ls_otroscodigos_exp
        _denominacion_exp = ls_denominacion_exp
        _sitio_exp = ls_sitio_exp
        _contexto_exp = ls_contexto_exp
        _nombre_exp = ls_nombre_exp
        _lugar_exp = ls_lugar_exp
        _pais_exp = ls_pais_exp
        _inmueble_exp = ls_inmueble_exp
        _resolucacion_exp = ls_resolucacion_exp
        _institucion_exp = ls_institucion_exp
        _comisario_exp = ls_comisario_exp
        _nropiliza_exp = ls_nropiliza_exp
        _monto_exp = ls_monto_exp
        _salida_exp = ld_salida_exp
        _retorno_exp = ld_retorno_exp
        _fechareg = ld_fechareg
        _usuarioreg = ls_usuarioreg
        _fechamod = ld_fechamod
        _usuariomod = ls_usuariomod
        _activo_exp = ln_activo_exp
    End Sub

#End Region

End Class
