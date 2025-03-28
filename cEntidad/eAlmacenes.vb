Public Class eAlmacenes

#Region "Propiedad"

    Private _nroficha_alm As Integer
    Private _id_dgc As Integer
    Private _ambmonitoreo_alm As String
    Private _area_alm As String
    Private _tipoestruct_alm As String
    Private _ventanas_alm As Integer
    Private _tipoluz_alm As String
    Private _tipoaa_alm As String
    Private _cantidadaa_alm As Integer
    Private _tipoex_alm As String
    Private _cantidadex_alm As Integer
    Private _cantthermo_alm As Integer
    Private _deshumedecedor_alm As String
    Private _cantestantes_alm As Integer
    Private _nivelesestantes_alm As Integer
    Private _cajasplast_alm As Integer
    Private _cajascarton_alm As Integer
    Private _cajasmadera_alm As Integer
    Private _coleccion_alm As String
    Private _material_alm As String
    Private _otros_alm As String
    Private _fechamonit_alm As Date
    Private _hringresoa_alm As String
    Private _hrsalidaa_alm As String
    Private _primeraTa_alm As Integer
    Private _segundaTa_alm As Integer
    Private _primeraHa_alm As Integer
    Private _segundaHa_alm As Integer
    Private _hringresop_alm As String
    Private _hrsalidap_alm As String
    Private _primeraTp_alm As Integer
    Private _segundaTp_alm As Integer
    Private _primeraHp_alm As Integer
    Private _segundaHp_alm As String
    Private _observaciones_alm As String
    Private _conservadorcargo_alm As String
    Private _fecha_alm As Date
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

    Public Property nroficha_alm() As Integer
        Get
            Return _nroficha_alm
        End Get
        Set(ByVal value As Integer)
            _nroficha_alm = value

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

    Public Property ambmonitoreo_alm() As String
        Get
            Return _ambmonitoreo_alm
        End Get
        Set(ByVal value As String)
            _ambmonitoreo_alm = value

        End Set
    End Property

    Public Property area_alm() As String
        Get
            Return _area_alm
        End Get
        Set(ByVal value As String)
            _area_alm = value

        End Set
    End Property

    Public Property tipoestruct_alm() As String
        Get
            Return _tipoestruct_alm
        End Get
        Set(ByVal value As String)
            _tipoestruct_alm = value

        End Set
    End Property

    Public Property ventanas_alm() As Integer
        Get
            Return _ventanas_alm
        End Get
        Set(ByVal value As Integer)
            _ventanas_alm = value

        End Set
    End Property

    Public Property tipoluz_alm() As String
        Get
            Return _tipoluz_alm
        End Get
        Set(ByVal value As String)
            _tipoluz_alm = value

        End Set
    End Property

    Public Property tipoaa_alm() As String
        Get
            Return _tipoaa_alm
        End Get
        Set(ByVal value As String)
            _tipoaa_alm = value

        End Set
    End Property

    Public Property cantidadaa_alm() As Integer
        Get
            Return _cantidadaa_alm
        End Get
        Set(ByVal value As Integer)
            _cantidadaa_alm = value

        End Set
    End Property

    Public Property tipoex_alm() As String
        Get
            Return _tipoex_alm
        End Get
        Set(ByVal value As String)
            _tipoex_alm = value

        End Set
    End Property

    Public Property cantidadex_alm() As String
        Get
            Return _cantidadex_alm
        End Get
        Set(ByVal value As String)
            _cantidadex_alm = value

        End Set
    End Property

    Public Property cantthermo_alm() As Integer
        Get
            Return _cantthermo_alm
        End Get
        Set(ByVal value As Integer)
            _cantthermo_alm = value

        End Set
    End Property

    Public Property deshumedecedor_alm() As String
        Get
            Return _deshumedecedor_alm
        End Get
        Set(ByVal value As String)
            _deshumedecedor_alm = value

        End Set
    End Property

    Public Property cantestantes_alm() As Integer
        Get
            Return _cantestantes_alm
        End Get
        Set(ByVal value As Integer)
            _cantestantes_alm = value

        End Set
    End Property

    Public Property nivelesestantes_alm() As Integer
        Get
            Return _nivelesestantes_alm
        End Get
        Set(ByVal value As Integer)
            _nivelesestantes_alm = value

        End Set
    End Property

    Public Property cajasplast_alm() As Integer
        Get
            Return _cajasplast_alm
        End Get
        Set(ByVal value As Integer)
            _cajasplast_alm = value

        End Set
    End Property

    Public Property cajascarton_alm() As Integer
        Get
            Return _cajascarton_alm
        End Get
        Set(ByVal value As Integer)
            _cajascarton_alm = value

        End Set
    End Property

    Public Property cajasmadera_alm() As Integer
        Get
            Return _cajasmadera_alm
        End Get
        Set(ByVal value As Integer)
            _cajasmadera_alm = value

        End Set
    End Property

    Public Property coleccion_alm() As String
        Get
            Return _coleccion_alm
        End Get
        Set(ByVal value As String)
            _coleccion_alm = value

        End Set
    End Property

    Public Property material_alm() As String
        Get
            Return _material_alm
        End Get
        Set(ByVal value As String)
            _material_alm = value

        End Set
    End Property

    Public Property otros_alm() As String
        Get
            Return _otros_alm
        End Get
        Set(ByVal value As String)
            _otros_alm = value

        End Set
    End Property

    Public Property fechamonit_alm() As Date
        Get
            Return _fechamonit_alm
        End Get
        Set(ByVal value As Date)
            _fechamonit_alm = value

        End Set
    End Property

    Public Property hringresoa_alm() As String
        Get
            Return _hringresoa_alm
        End Get
        Set(ByVal value As String)
            _hringresoa_alm = value

        End Set
    End Property

    Public Property hrsalidaa_alm() As String
        Get
            Return _hrsalidaa_alm
        End Get
        Set(ByVal value As String)
            _hrsalidaa_alm = value

        End Set
    End Property

    Public Property primeraTa_alm() As Integer
        Get
            Return _primeraTa_alm
        End Get
        Set(ByVal value As Integer)
            _primeraTa_alm = value

        End Set
    End Property


    Public Property segundaTa_alm() As Integer
        Get
            Return _segundaTa_alm
        End Get
        Set(ByVal value As Integer)
            _segundaTa_alm = value

        End Set
    End Property

    Public Property primeraHa_alm() As Integer
        Get
            Return _primeraHa_alm
        End Get
        Set(ByVal value As Integer)
            _primeraHa_alm = value

        End Set
    End Property

    Public Property segundaHa_alm() As Integer
        Get
            Return _segundaHa_alm
        End Get
        Set(ByVal value As Integer)
            _segundaHa_alm = value

        End Set
    End Property


    Public Property hringresop_alm() As String
        Get
            Return _hringresop_alm
        End Get
        Set(ByVal value As String)
            _hringresop_alm = value

        End Set
    End Property

    Public Property hrsalidap_alm() As String
        Get
            Return _hrsalidap_alm
        End Get
        Set(ByVal value As String)
            _hrsalidap_alm = value

        End Set
    End Property

    Public Property primeraTp_alm() As Integer
        Get
            Return _primeraTp_alm
        End Get
        Set(ByVal value As Integer)
            _primeraTp_alm = value

        End Set
    End Property


    Public Property segundaTp_alm() As Integer
        Get
            Return _segundaTp_alm
        End Get
        Set(ByVal value As Integer)
            _segundaTp_alm = value

        End Set
    End Property

    Public Property primeraHp_alm() As Integer
        Get
            Return _primeraHp_alm
        End Get
        Set(ByVal value As Integer)
            _primeraHp_alm = value

        End Set
    End Property

    Public Property segundaHp_alm() As Integer
        Get
            Return _segundaHp_alm
        End Get
        Set(ByVal value As Integer)
            _segundaHp_alm = value

        End Set
    End Property

    Public Property observaciones_alm() As String
        Get
            Return _observaciones_alm
        End Get
        Set(ByVal value As String)
            _observaciones_alm = value

        End Set
    End Property

    Public Property conservadorcargo_alm() As String
        Get
            Return _conservadorcargo_alm
        End Get
        Set(ByVal value As String)
            _conservadorcargo_alm = value

        End Set
    End Property

    Public Property fecha_alm() As Date
        Get
            Return _fecha_alm
        End Get
        Set(ByVal value As Date)
            _fecha_alm = value

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
        _ambmonitoreo_alm = String.Empty
        _area_alm = String.Empty
        _tipoestruct_alm = String.Empty
        _tipoluz_alm = String.Empty
        _tipoaa_alm = String.Empty
        _tipoex_alm = String.Empty
        _deshumedecedor_alm = String.Empty
        _coleccion_alm = String.Empty
        _material_alm = String.Empty
        _otros_alm = String.Empty
        _segundaHp_alm = String.Empty
        _observaciones_alm = String.Empty
        _conservadorcargo_alm = String.Empty
        _usuarioreg = String.Empty
        _usuariomod = String.Empty
    End Sub

    Public Sub New( _
                 ByVal ln_nroficha_alm As Integer _
                , ByVal ln_id_dgc As Integer _
                , ByVal ls_ambmonitoreo_alm As String _
                , ByVal ls_area_alm As String _
                , ByVal ls_tipoestruct_alm As String _
                , ByVal ln_ventanas_alm As Integer _
                , ByVal ls_tipoluz_alm As String _
                , ByVal ls_tipoaa_alm As String _
                , ByVal ln_cantidadaa_alm As Integer _
                , ByVal ls_tipoex_alm As String _
                , ByVal ln_cantidadex_alm As Integer _
                , ByVal ln_cantthermo_alm As Integer _
                , ByVal ls_deshumedecedor_alm As String _
                , ByVal ln_cantestantes_alm As Integer _
                , ByVal ln_nivelesestantes_alm As Integer _
                , ByVal ln_cajasplast_alm As Integer _
                , ByVal ln_cajascarton_alm As Integer _
                , ByVal ln_cajasmadera_alm As Integer _
                , ByVal ls_coleccion_alm As String _
                , ByVal ls_material_alm As String _
                , ByVal ls_otros_alm As String _
                , ByVal ld_fechamonit_alm As Date _
                , ByVal ld_hringresoa_alm As String _
                , ByVal ld_hrsalidaa_alm As String _
                , ByVal ln_primeraTa_alm As Integer _
                , ByVal ln_segundaTa_alm As Integer _
                , ByVal ln_primeraHa_alm As Integer _
                , ByVal ln_segundaHa_alm As Integer _
                , ByVal ld_hringresop_alm As String _
                , ByVal ld_hrsalidap_alm As String _
                , ByVal ln_primeraTp_alm As Integer _
                , ByVal ln_segundaTp_alm As Integer _
                , ByVal ln_primeraHp_alm As Integer _
                , ByVal ls_segundaHp_alm As String _
                , ByVal ls_observaciones_alm As String _
                , ByVal ls_conservadorcargo_alm As String _
                , ByVal ld_fecha_alm As Date _
                , ByVal ln_activo As Integer _
                , ByVal ld_fechareg As Date _
                , ByVal ls_usuarioreg As String _
                , ByVal ld_fechamod As Date _
                , ByVal ls_usuariomod As String _
                )
        _nroficha_alm = ln_nroficha_alm
        _id_dgc = ln_id_dgc
        _ambmonitoreo_alm = ls_ambmonitoreo_alm
        _area_alm = ls_area_alm
        _tipoestruct_alm = ls_tipoestruct_alm
        _ventanas_alm = ln_ventanas_alm
        _tipoluz_alm = ls_tipoluz_alm
        _tipoaa_alm = ls_tipoaa_alm
        _cantidadaa_alm = ln_cantidadaa_alm
        _tipoex_alm = ls_tipoex_alm
        _cantidadex_alm = ln_cantidadex_alm
        _cantthermo_alm = ln_cantthermo_alm
        _deshumedecedor_alm = ls_deshumedecedor_alm
        _cantestantes_alm = ln_cantestantes_alm
        _nivelesestantes_alm = ln_nivelesestantes_alm
        _cajasplast_alm = ln_cajasplast_alm
        _cajascarton_alm = ln_cajascarton_alm
        _cajasmadera_alm = ln_cajasmadera_alm
        _coleccion_alm = ls_coleccion_alm
        _material_alm = ls_material_alm
        _otros_alm = ls_otros_alm
        _fechamonit_alm = ld_fechamonit_alm
        _hringresoa_alm = ld_hringresoa_alm
        _hrsalidaa_alm = ld_hrsalidaa_alm
        _primeraTa_alm = ln_primeraTa_alm
        _segundaTa_alm = ln_segundaTa_alm
        _primeraHa_alm = ln_primeraHa_alm
        _segundaHa_alm = ln_segundaHa_alm
        _hringresop_alm = ld_hringresop_alm
        _hrsalidap_alm = ld_hrsalidap_alm
        _primeraTp_alm = ln_primeraTp_alm
        _segundaTp_alm = ln_segundaTp_alm
        _primeraHp_alm = ln_primeraHp_alm
        _segundaHp_alm = ls_segundaHp_alm
        _observaciones_alm = ls_observaciones_alm
        _conservadorcargo_alm = ls_conservadorcargo_alm
        _fecha_alm = ld_fecha_alm
        _activo = ln_activo
        _fechareg = ld_fechareg
        _usuarioreg = ls_usuarioreg
        _fechamod = ld_fechamod
        _usuariomod = ls_usuariomod

    End Sub

#End Region

End Class

