Public Class eInventarioInmuebles

#Region "Propiedad"

    Private _codigo_inm As Integer
    Private _nombresitio_inm As String
    Private _caserio_inm As String
    Private _departamento_inm As String
    Private _provincia_inm As String
    Private _distrito_inm As String
    Private _utme_inm As Integer
    Private _utmn_inm As Integer
    Private _datum_inm As String
    'Inicio JAZ
    'Private _perimetro_inm As Integer
    Private _perimetro_inm As Double
    'Fin JAZ
    Private _normalega_inm As String
    Private _fecha_inm As Date
    Private _levplano_inm As Integer
    Private _elaboroplano_inm As String
    Private _fichatec_inm As Integer
    Private _memoriades_inm As Integer
    Private _cultur_inm As String
    Private _tipositio_inm As String
    Private _estado_inm As String

    Private _fechareg As Date
    Private _usuarioreg As String
    Private _fechamod As Date
    Private _usuariomod As String
    Private _activo_cat As Integer
    Private _id_dgc As Integer

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

    Public Property id_dgc() As Integer
        Get
            Return _id_dgc
        End Get
        Set(ByVal value As Integer)
            _id_dgc = value

        End Set
    End Property

    Public Property codigo_inm() As Integer
        Get
            Return _codigo_inm
        End Get
        Set(ByVal value As Integer)
            _codigo_inm = value

        End Set
    End Property

    Public Property nombresitio_inm() As String
        Get
            Return _nombresitio_inm
        End Get
        Set(ByVal value As String)
            _nombresitio_inm = value

        End Set
    End Property

    Public Property caserio_inm() As String
        Get
            Return _caserio_inm
        End Get
        Set(ByVal value As String)
            _caserio_inm = value

        End Set
    End Property

    Public Property departamento_inm() As String
        Get
            Return _departamento_inm
        End Get
        Set(ByVal value As String)
            _departamento_inm = value

        End Set
    End Property

    Public Property provincia_inm() As String
        Get
            Return _provincia_inm
        End Get
        Set(ByVal value As String)
            _provincia_inm = value

        End Set
    End Property

    Public Property distrito_inm() As String
        Get
            Return _distrito_inm
        End Get
        Set(ByVal value As String)
            _distrito_inm = value

        End Set
    End Property

    Public Property utme_inm() As Integer
        Get
            Return _utme_inm
        End Get
        Set(ByVal value As Integer)
            _utme_inm = value

        End Set
    End Property

    Public Property utmn_inm() As Integer
        Get
            Return _utmn_inm
        End Get
        Set(ByVal value As Integer)
            _utmn_inm = value

        End Set
    End Property

    Public Property datum_inm() As String
        Get
            Return _datum_inm
        End Get
        Set(ByVal value As String)
            _datum_inm = value

        End Set
    End Property
    'Inicio JAZ
    'Public Property perimetro_inm() As Integer
    Public Property perimetro_inm() As Double
        'Fin JAZ
        Get
            Return _perimetro_inm
        End Get
        'Inicio JAZ
        'Set(ByVal value As Integer)
        Set(ByVal value As Double)
            'Fin JAZ
            _perimetro_inm = value

        End Set
    End Property

    Public Property normalega_inm() As String
        Get
            Return _normalega_inm
        End Get
        Set(ByVal value As String)
            _normalega_inm = value

        End Set
    End Property

    Public Property levplano_inm() As Integer
        Get
            Return _levplano_inm
        End Get
        Set(ByVal value As Integer)
            _levplano_inm = value

        End Set
    End Property

    Public Property elaboroplano_inm() As String
        Get
            Return _elaboroplano_inm
        End Get
        Set(ByVal value As String)
            _elaboroplano_inm = value

        End Set
    End Property

    Public Property fichatec_inm() As Integer
        Get
            Return _fichatec_inm
        End Get
        Set(ByVal value As Integer)
            _fichatec_inm = value

        End Set
    End Property

    Public Property memoriades_inm() As Integer
        Get
            Return _memoriades_inm
        End Get
        Set(ByVal value As Integer)
            _memoriades_inm = value

        End Set
    End Property

    Public Property cultur_inm() As String
        Get
            Return _cultur_inm
        End Get
        Set(ByVal value As String)
            _cultur_inm = value

        End Set
    End Property


    Public Property tipositio_inm() As String
        Get
            Return _tipositio_inm
        End Get
        Set(ByVal value As String)
            _tipositio_inm = value

        End Set
    End Property

    Public Property estado_inm() As String
        Get
            Return _estado_inm
        End Get
        Set(ByVal value As String)
            _estado_inm = value

        End Set
    End Property

    Public Property fecha_inm() As Date
        Get
            Return _fecha_inm
        End Get
        Set(ByVal value As Date)
            _fecha_inm = value

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

    Public Property activo_cat() As Integer
        Get
            Return _activo_cat
        End Get
        Set(ByVal value As Integer)
            _activo_cat = value

        End Set
    End Property

#End Region
#Region "Constructor"
    Public Sub New()
        _nombresitio_inm = String.Empty
        _caserio_inm = String.Empty
        _departamento_inm = String.Empty
        _provincia_inm = String.Empty
        _distrito_inm = String.Empty
        _normalega_inm = String.Empty
        _elaboroplano_inm = String.Empty
        _cultur_inm = String.Empty
        _tipositio_inm = String.Empty
        _estado_inm = String.Empty
        _usuarioreg = String.Empty
        _usuariomod = String.Empty
        _datum_inm = String.Empty
    End Sub

    Public Sub New(
              ByVal ln_codigo_inm As Integer _
              , ByVal ls_nombresitio_inm As String _
              , ByVal ls_caserio_inm As String _
              , ByVal ls_departamento_inm As String _
              , ByVal ls_provincia_inm As String _
              , ByVal ls_distrito_inm As String _
              , ByVal ln_utme_inm As Integer _
              , ByVal ln_utmn_inm As Integer _
              , ByVal ln_datum_inm As String _
              , ByVal ln_perimetro_inm As Double _
              , ByVal ls_normalega_inm As String _
              , ByVal ld_fecha_inm As Date _
              , ByVal ln_levplano_inm As Integer _
              , ByVal ls_elaboroplano_inm As String _
              , ByVal ln_fichatec_inm As Integer _
              , ByVal ln_memoriades_inm As Integer _
              , ByVal ls_cultur_inm As String _
              , ByVal ls_tipositio_inm As String _
              , ByVal ls_estado_inm As String _
              , ByVal ld_fechareg As Date _
              , ByVal ls_usuarioreg As String _
              , ByVal ld_fechamod As Date _
              , ByVal ls_usuariomod As String _
              , ByVal ln_activo_cat As Integer _
              , ByVal ln_id_dgc As Integer
           )
        _codigo_inm = ln_codigo_inm
        _nombresitio_inm = ls_nombresitio_inm
        _caserio_inm = ls_caserio_inm
        _departamento_inm = ls_departamento_inm
        _provincia_inm = ls_provincia_inm
        _distrito_inm = ls_distrito_inm
        _utme_inm = ln_utme_inm
        _utmn_inm = ln_utmn_inm
        _datum_inm = ln_datum_inm
        _perimetro_inm = ln_perimetro_inm
        _normalega_inm = ls_normalega_inm
        _levplano_inm = ln_levplano_inm
        _elaboroplano_inm = ls_elaboroplano_inm
        _fichatec_inm = ln_fichatec_inm
        _memoriades_inm = ln_memoriades_inm
        _cultur_inm = ls_cultur_inm
        _tipositio_inm = ls_tipositio_inm
        _estado_inm = ls_estado_inm
        _fecha_inm = ld_fecha_inm
        _fechareg = ld_fechareg
        _usuarioreg = ls_usuarioreg
        _fechamod = ld_fechamod
        _usuariomod = ls_usuariomod
        _activo_cat = ln_activo_cat
        _id_dgc = ln_id_dgc
    End Sub

#End Region

End Class
