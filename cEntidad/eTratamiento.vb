Public Class eTratamiento

#Region "Propiedad"

    Private _nroficha_tra As Integer
    Private _id_dgc As Integer
    Private _codregnac_tra As String
    Private _codpropietario_tra As String
    Private _codexcavacion_tra As String
    Private _codrestauracion_tra As String
    Private _sector_tra As String
    Private _unidad_tra As String
    Private _capa_tra As String
    Private _nivel_tra As String
    Private _cuadricula_tra As String
    Private _plano_tra As String
    Private _contexto_tra As String
    Private _ubicontexto_tra As String
    Private _alturaobs_tra As String
    Private _otrosdatos_tra As String
    Private _material_tra As String
    Private _denominacion_tra As String
    Private _descripcion_tra As String
    Private _alto_tra As Integer
    Private _largo_tra As Integer
    Private _ancho_tra As Integer
    Private _espesor_tra As Integer
    Private _diametromax_tra As Integer
    Private _diametromin_tra As Integer
    Private _diametrobase_tra As Integer
    Private _pesoini_tra As Integer
    Private _pesofin_tra As Integer
    Private _ubicinmueble_tra As String
    Private _nrocaja_tra As String
    Private _nrobolsa_tra As String
    Private _integridadbien_tra As Integer
    Private _conservacionbien_tra As Integer
    Private _detconservacion_tra As String
    Private _intervenciones_tra As String
    Private _retiroconsolidante_tra As String
    Private _limpiezasuperf_tra As String
    Private _despegado_tra As String
    Private _pegado_tra As String
    Private _refuerzo_tra As String
    Private _otros_tra As String
    Private _fini_tra As Date
    Private _ffin_tra As Date
    Private _mecanica_tra As String
    Private _quimica_tra As String
    Private _finilim_tra As Date
    Private _ffinlim_tra As Date
    Private _intervenido_tra As Integer
    Private _dettratamiento_tra As String
    Private _inhibicion_tra As String
    Private _estabilizacion_tra As String
    Private _desalacion_tra As String
    Private _neutralizacion_tra As String
    Private _otrostrat_tra As String
    Private _finitrat_tra As Date
    Private _ffintrat_tra As Date
    Private _secadopost_tra As String
    Private _pegadopost_tra As String
    Private _consolidacion_tra As String
    Private _reintegracion_tra As String
    Private _otrospost_tra As String
    Private _finipost_tra As Date
    Private _ffinpost_tra As Date
    Private _temperatura_tra As Integer
    Private _humedad_tra As String
    Private _manipulacion_tra As String
    Private _iluminacion_tra As String
    Private _otrosrec_tra As String
    Private _materialrec_tra As String
    Private _observaciones_tra As String
    Private _conservadorcargo_tra As String
    Private _fecha_tra As Date
    Private _fotoini_tra As Date
    Private _fotofin_tra As Date
    Private _detalle_tra As String
    Private _foto1_tra As Integer
    Private _foto2_tra As Integer
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

    Public Property nroficha_tra() As Integer
        Get
            Return _nroficha_tra
        End Get
        Set(ByVal value As Integer)
            _nroficha_tra = value

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

    Public Property codregnac_tra() As String
        Get
            Return _codregnac_tra
        End Get
        Set(ByVal value As String)
            _codregnac_tra = value

        End Set
    End Property

    Public Property codpropietario_tra() As String
        Get
            Return _codpropietario_tra
        End Get
        Set(ByVal value As String)
            _codpropietario_tra = value

        End Set
    End Property

    Public Property codexcavacion_tra() As String
        Get
            Return _codexcavacion_tra
        End Get
        Set(ByVal value As String)
            _codexcavacion_tra = value

        End Set
    End Property

    Public Property codrestauracion_tra() As String
        Get
            Return _codrestauracion_tra
        End Get
        Set(ByVal value As String)
            _codrestauracion_tra = value

        End Set
    End Property

    Public Property sector_tra() As String
        Get
            Return _sector_tra
        End Get
        Set(ByVal value As String)
            _sector_tra = value

        End Set
    End Property

    Public Property unidad_tra() As String
        Get
            Return _unidad_tra
        End Get
        Set(ByVal value As String)
            _unidad_tra = value

        End Set
    End Property

    Public Property capa_tra() As String
        Get
            Return _capa_tra
        End Get
        Set(ByVal value As String)
            _capa_tra = value

        End Set
    End Property

    Public Property nivel_tra() As String
        Get
            Return _nivel_tra
        End Get
        Set(ByVal value As String)
            _nivel_tra = value

        End Set
    End Property

    Public Property cuadricula_tra() As String
        Get
            Return _cuadricula_tra
        End Get
        Set(ByVal value As String)
            _cuadricula_tra = value

        End Set
    End Property

    Public Property plano_tra() As String
        Get
            Return _plano_tra
        End Get
        Set(ByVal value As String)
            _plano_tra = value

        End Set
    End Property

    Public Property contexto_tra() As String
        Get
            Return _contexto_tra
        End Get
        Set(ByVal value As String)
            _contexto_tra = value

        End Set
    End Property

    Public Property ubicontexto_tra() As String
        Get
            Return _ubicontexto_tra
        End Get
        Set(ByVal value As String)
            _ubicontexto_tra = value

        End Set
    End Property

    Public Property alturaobs_tra() As String
        Get
            Return _alturaobs_tra
        End Get
        Set(ByVal value As String)
            _alturaobs_tra = value

        End Set
    End Property

    Public Property otrosdatos_tra() As String
        Get
            Return _otrosdatos_tra
        End Get
        Set(ByVal value As String)
            _otrosdatos_tra = value

        End Set
    End Property

    Public Property material_tra() As String
        Get
            Return _material_tra
        End Get
        Set(ByVal value As String)
            _material_tra = value

        End Set
    End Property

    Public Property denominacion_tra() As String
        Get
            Return _denominacion_tra
        End Get
        Set(ByVal value As String)
            _denominacion_tra = value

        End Set
    End Property

    Public Property descripcion_tra() As String
        Get
            Return _descripcion_tra
        End Get
        Set(ByVal value As String)
            _descripcion_tra = value

        End Set
    End Property

    Public Property alto_tra() As Integer
        Get
            Return _alto_tra
        End Get
        Set(ByVal value As Integer)
            _alto_tra = value

        End Set
    End Property

    Public Property largo_tra() As Integer
        Get
            Return _largo_tra
        End Get
        Set(ByVal value As Integer)
            _largo_tra = value

        End Set
    End Property

    Public Property ancho_tra() As Integer
        Get
            Return _ancho_tra
        End Get
        Set(ByVal value As Integer)
            _ancho_tra = value

        End Set
    End Property

    Public Property espesor_tra() As Integer
        Get
            Return _espesor_tra
        End Get
        Set(ByVal value As Integer)
            _espesor_tra = value

        End Set
    End Property

    Public Property diametromax_tra() As Integer
        Get
            Return _diametromax_tra
        End Get
        Set(ByVal value As Integer)
            _diametromax_tra = value

        End Set
    End Property

    Public Property diametromin_tra() As Integer
        Get
            Return _diametromin_tra
        End Get
        Set(ByVal value As Integer)
            _diametromin_tra = value

        End Set
    End Property

    Public Property diametrobase_tra() As Integer
        Get
            Return _diametrobase_tra
        End Get
        Set(ByVal value As Integer)
            _diametrobase_tra = value

        End Set
    End Property

    Public Property pesoini_tra() As Integer
        Get
            Return _pesoini_tra
        End Get
        Set(ByVal value As Integer)
            _pesoini_tra = value

        End Set
    End Property

    Public Property pesofin_tra() As Integer
        Get
            Return _pesofin_tra
        End Get
        Set(ByVal value As Integer)
            _pesofin_tra = value

        End Set
    End Property

    Public Property ubicinmueble_tra() As String
        Get
            Return _ubicinmueble_tra
        End Get
        Set(ByVal value As String)
            _ubicinmueble_tra = value

        End Set
    End Property

    Public Property nrocaja_tra() As String
        Get
            Return _nrocaja_tra
        End Get
        Set(ByVal value As String)
            _nrocaja_tra = value

        End Set
    End Property

    Public Property nrobolsa_tra() As Integer
        Get
            Return _nrobolsa_tra
        End Get
        Set(ByVal value As Integer)
            _nrobolsa_tra = value

        End Set
    End Property

    Public Property integridadbien_tra() As Integer
        Get
            Return _integridadbien_tra
        End Get
        Set(ByVal value As Integer)
            _integridadbien_tra = value

        End Set
    End Property

    Public Property conservacionbien_tra() As Integer
        Get
            Return _conservacionbien_tra
        End Get
        Set(ByVal value As Integer)
            _conservacionbien_tra = value

        End Set
    End Property

    Public Property detconservacion_tra() As String
        Get
            Return _detconservacion_tra
        End Get
        Set(ByVal value As String)
            _detconservacion_tra = value

        End Set
    End Property

    Public Property intervenciones_tra() As String
        Get
            Return _intervenciones_tra
        End Get
        Set(ByVal value As String)
            _intervenciones_tra = value

        End Set
    End Property

    Public Property retiroconsolidante_tra() As String
        Get
            Return _retiroconsolidante_tra
        End Get
        Set(ByVal value As String)
            _retiroconsolidante_tra = value

        End Set
    End Property

    Public Property limpiezasuperf_tra() As String
        Get
            Return _limpiezasuperf_tra
        End Get
        Set(ByVal value As String)
            _limpiezasuperf_tra = value

        End Set
    End Property

    Public Property despegado_tra() As String
        Get
            Return _despegado_tra
        End Get
        Set(ByVal value As String)
            _despegado_tra = value

        End Set
    End Property

    Public Property pegado_tra() As String
        Get
            Return _pegado_tra
        End Get
        Set(ByVal value As String)
            _pegado_tra = value

        End Set
    End Property

    Public Property refuerzo_tra() As String
        Get
            Return _refuerzo_tra
        End Get
        Set(ByVal value As String)
            _refuerzo_tra = value

        End Set
    End Property

    Public Property otros_tra() As String
        Get
            Return _otros_tra
        End Get
        Set(ByVal value As String)
            _otros_tra = value

        End Set
    End Property

    Public Property fini_tra() As Date
        Get
            Return _fini_tra
        End Get
        Set(ByVal value As Date)
            _fini_tra = value

        End Set
    End Property

    Public Property ffin_tra() As Date
        Get
            Return _ffin_tra
        End Get
        Set(ByVal value As Date)
            _ffin_tra = value

        End Set
    End Property

    Public Property mecanica_tra() As String
        Get
            Return _mecanica_tra
        End Get
        Set(ByVal value As String)
            _mecanica_tra = value

        End Set
    End Property

    Public Property quimica_tra() As String
        Get
            Return _quimica_tra
        End Get
        Set(ByVal value As String)
            _quimica_tra = value

        End Set
    End Property

    Public Property finilim_tra() As Date
        Get
            Return _finilim_tra
        End Get
        Set(ByVal value As Date)
            _finilim_tra = value

        End Set
    End Property

    Public Property ffinlim_tra() As Date
        Get
            Return _ffinlim_tra
        End Get
        Set(ByVal value As Date)
            _ffinlim_tra = value

        End Set
    End Property

    Public Property intervenido_tra() As Integer
        Get
            Return _intervenido_tra
        End Get
        Set(ByVal value As Integer)
            _intervenido_tra = value

        End Set
    End Property

    Public Property dettratamiento_tra() As String
        Get
            Return _dettratamiento_tra
        End Get
        Set(ByVal value As String)
            _dettratamiento_tra = value

        End Set
    End Property

    Public Property inhibicion_tra() As String
        Get
            Return _inhibicion_tra
        End Get
        Set(ByVal value As String)
            _inhibicion_tra = value

        End Set
    End Property

    Public Property estabilizacion_tra() As String
        Get
            Return _estabilizacion_tra
        End Get
        Set(ByVal value As String)
            _estabilizacion_tra = value

        End Set
    End Property

    Public Property desalacion_tra() As String
        Get
            Return _desalacion_tra
        End Get
        Set(ByVal value As String)
            _desalacion_tra = value

        End Set
    End Property

    Public Property neutralizacion_tra() As String
        Get
            Return _neutralizacion_tra
        End Get
        Set(ByVal value As String)
            _neutralizacion_tra = value

        End Set
    End Property

    Public Property otrostrat_tra() As String
        Get
            Return _otrostrat_tra
        End Get
        Set(ByVal value As String)
            _otrostrat_tra = value

        End Set
    End Property

    Public Property finitrat_tra() As Date
        Get
            Return _finitrat_tra
        End Get
        Set(ByVal value As Date)
            _finitrat_tra = value

        End Set
    End Property

    Public Property ffintrat_tra() As Date
        Get
            Return _ffintrat_tra
        End Get
        Set(ByVal value As Date)
            _ffintrat_tra = value

        End Set
    End Property

    Public Property secadopost_tra() As String
        Get
            Return _secadopost_tra
        End Get
        Set(ByVal value As String)
            _secadopost_tra = value

        End Set
    End Property

    Public Property pegadopost_tra() As String
        Get
            Return _pegadopost_tra
        End Get
        Set(ByVal value As String)
            _pegadopost_tra = value

        End Set
    End Property

    Public Property consolidacion_tra() As String
        Get
            Return _consolidacion_tra
        End Get
        Set(ByVal value As String)
            _consolidacion_tra = value

        End Set
    End Property

    Public Property reintegracion_tra() As String
        Get
            Return _reintegracion_tra
        End Get
        Set(ByVal value As String)
            _reintegracion_tra = value

        End Set
    End Property

    Public Property otrospost_tra() As String
        Get
            Return _otrospost_tra
        End Get
        Set(ByVal value As String)
            _otrospost_tra = value

        End Set
    End Property

    Public Property finipost_tra() As Date
        Get
            Return _finipost_tra
        End Get
        Set(ByVal value As Date)
            _finipost_tra = value

        End Set
    End Property

    Public Property ffinpost_tra() As Date
        Get
            Return _ffinpost_tra
        End Get
        Set(ByVal value As Date)
            _ffinpost_tra = value

        End Set
    End Property

    Public Property temperatura_tra() As Integer
        Get
            Return _temperatura_tra
        End Get
        Set(ByVal value As Integer)
            _temperatura_tra = value

        End Set
    End Property

    Public Property humedad_tra() As String
        Get
            Return _humedad_tra
        End Get
        Set(ByVal value As String)
            _humedad_tra = value

        End Set
    End Property

    Public Property manipulacion_tra() As String
        Get
            Return _manipulacion_tra
        End Get
        Set(ByVal value As String)
            _manipulacion_tra = value

        End Set
    End Property

    Public Property iluminacion_tra() As String
        Get
            Return _iluminacion_tra
        End Get
        Set(ByVal value As String)
            _iluminacion_tra = value

        End Set
    End Property

    Public Property otrosrec_tra() As String
        Get
            Return _otrosrec_tra
        End Get
        Set(ByVal value As String)
            _otrosrec_tra = value

        End Set
    End Property

    Public Property materialrec_tra() As String
        Get
            Return _materialrec_tra
        End Get
        Set(ByVal value As String)
            _materialrec_tra = value

        End Set
    End Property

    Public Property observaciones_tra() As String
        Get
            Return _observaciones_tra
        End Get
        Set(ByVal value As String)
            _observaciones_tra = value

        End Set
    End Property

    Public Property conservadorcargo_tra() As String
        Get
            Return _conservadorcargo_tra
        End Get
        Set(ByVal value As String)
            _conservadorcargo_tra = value

        End Set
    End Property

    Public Property fecha_tra() As Date
        Get
            Return _fecha_tra
        End Get
        Set(ByVal value As Date)
            _fecha_tra = value

        End Set
    End Property

    Public Property fotoini_tra() As Date
        Get
            Return _fotoini_tra
        End Get
        Set(ByVal value As Date)
            _fotoini_tra = value

        End Set
    End Property

    Public Property fotofin_tra() As Date
        Get
            Return _fotofin_tra
        End Get
        Set(ByVal value As Date)
            _fotofin_tra = value

        End Set
    End Property

    Public Property detalle_tra() As String
        Get
            Return _detalle_tra
        End Get
        Set(ByVal value As String)
            _detalle_tra = value

        End Set
    End Property

    Public Property foto1_tra() As Integer
        Get
            Return _foto1_tra
        End Get
        Set(ByVal value As Integer)
            _foto1_tra = value

        End Set
    End Property

    Public Property foto2_tra() As Integer
        Get
            Return _foto2_tra
        End Get
        Set(ByVal value As Integer)
            _foto2_tra = value

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
        _codpropietario_tra = String.Empty
        _codexcavacion_tra = String.Empty
        _codrestauracion_tra = String.Empty
        _sector_tra = String.Empty
        _unidad_tra = String.Empty
        _capa_tra = String.Empty
        _nivel_tra = String.Empty
        _cuadricula_tra = String.Empty
        _plano_tra = String.Empty
        _contexto_tra = String.Empty
        _ubicontexto_tra = String.Empty
        _alturaobs_tra = String.Empty
        _otrosdatos_tra = String.Empty
        _material_tra = String.Empty
        _denominacion_tra = String.Empty
        _descripcion_tra = String.Empty
        _ubicinmueble_tra = String.Empty
        _nrocaja_tra = String.Empty
        _nrobolsa_tra = String.Empty
        _detconservacion_tra = String.Empty
        _intervenciones_tra = String.Empty
        _retiroconsolidante_tra = String.Empty
        _limpiezasuperf_tra = String.Empty
        _despegado_tra = String.Empty
        _pegado_tra = String.Empty
        _refuerzo_tra = String.Empty
        _otros_tra = String.Empty
        _mecanica_tra = String.Empty
        _quimica_tra = String.Empty
        _dettratamiento_tra = String.Empty
        _inhibicion_tra = String.Empty
        _estabilizacion_tra = String.Empty
        _desalacion_tra = String.Empty
        _neutralizacion_tra = String.Empty
        _otrostrat_tra = String.Empty
        _secadopost_tra = String.Empty
        _pegadopost_tra = String.Empty
        _consolidacion_tra = String.Empty
        _reintegracion_tra = String.Empty
        _otrospost_tra = String.Empty
        _humedad_tra = String.Empty
        _manipulacion_tra = String.Empty
        _iluminacion_tra = String.Empty
        _otrosrec_tra = String.Empty
        _materialrec_tra = String.Empty
        _observaciones_tra = String.Empty
        _conservadorcargo_tra = String.Empty
        _detalle_tra = String.Empty
        _usuarioreg = String.Empty
        _usuariomod = String.Empty
    End Sub

    Public Sub New(
                ByVal ln_nroficha_tra As Integer _
                , ByVal ln_id_dgc As Integer _
                , ByVal ln_codregnac_tra As String _
                , ByVal ls_codpropietario_tra As String _
                , ByVal ls_codexcavacion_tra As String _
                , ByVal ls_codrestauracion_tra As String _
                , ByVal ls_sector_tra As String _
                , ByVal ls_unidad_tra As String _
                , ByVal ls_capa_tra As String _
                , ByVal ls_nivel_tra As String _
                , ByVal ls_cuadricula_tra As String _
                , ByVal ls_plano_tra As String _
                , ByVal ls_contexto_tra As String _
                , ByVal ls_ubicontexto_tra As String _
                , ByVal ls_alturaobs_tra As String _
                , ByVal ls_otrosdatos_tra As String _
                , ByVal ls_material_tra As String _
                , ByVal ls_denominacion_tra As String _
                , ByVal ls_descripcion_tra As String _
                , ByVal ln_alto_tra As Integer _
                , ByVal ln_largo_tra As Integer _
                , ByVal ln_ancho_tra As Integer _
                , ByVal ln_espesor_tra As Integer _
                , ByVal ln_diametromax_tra As Integer _
                , ByVal ln_diametromin_tra As Integer _
                , ByVal ln_diametrobase_tra As Integer _
                , ByVal ln_pesoini_tra As Integer _
                , ByVal ln_pesofin_tra As Integer _
                , ByVal ls_ubicinmueble_tra As String _
                , ByVal ls_nrocaja_tra As String _
                , ByVal ls_nrobolsa_tra As String _
                , ByVal ln_integridadbien_tra As Integer _
                , ByVal ln_conservacionbien_tra As Integer _
                , ByVal ls_detconservacion_tra As String _
                , ByVal ls_intervenciones_tra As String _
                , ByVal ls_retiroconsolidante_tra As String _
                , ByVal ls_limpiezasuperf_tra As String _
                , ByVal ls_despegado_tra As String _
                , ByVal ls_pegado_tra As String _
                , ByVal ls_refuerzo_tra As String _
                , ByVal ls_otros_tra As String _
                , ByVal ld_fini_tra As Date _
                , ByVal ld_ffin_tra As Date _
                , ByVal ls_mecanica_tra As String _
                , ByVal ls_quimica_tra As String _
                , ByVal ld_finilim_tra As Date _
                , ByVal ld_ffinlim_tra As Date _
                , ByVal ln_intervenido_tra As Integer _
                , ByVal ls_dettratamiento_tra As String _
                , ByVal ls_inhibicion_tra As String _
                , ByVal ls_estabilizacion_tra As String _
                , ByVal ls_desalacion_tra As String _
                , ByVal ls_neutralizacion_tra As String _
                , ByVal ls_otrostrat_tra As String _
                , ByVal ld_finitrat_tra As Date _
                , ByVal ld_ffintrat_tra As Date _
                , ByVal ls_secadopost_tra As String _
                , ByVal ls_pegadopost_tra As String _
                , ByVal ls_consolidacion_tra As String _
                , ByVal ls_reintegracion_tra As String _
                , ByVal ls_otrospost_tra As String _
                , ByVal ld_finipost_tra As Date _
                , ByVal ld_ffinpost_tra As Date _
                , ByVal ln_temperatura_tra As Integer _
                , ByVal ls_humedad_tra As String _
                , ByVal ls_manipulacion_tra As String _
                , ByVal ls_iluminacion_tra As String _
                , ByVal ls_otrosrec_tra As String _
                , ByVal ls_materialrec_tra As String _
                , ByVal ls_observaciones_tra As String _
                , ByVal ls_conservadorcargo_tra As String _
                , ByVal ld_fecha_tra As Date _
                , ByVal ld_fotoini_tra As Date _
                , ByVal ld_fotofin_tra As Date _
                , ByVal ls_detalle_tra As String _
                , ByVal ln_foto1_tra As Integer _
                , ByVal ln_foto2_tra As Integer _
                , ByVal ln_activo As Integer _
                , ByVal ld_fechareg As Date _
                , ByVal ls_usuarioreg As String _
                , ByVal ld_fechamod As Date _
                , ByVal ls_usuariomod As String
                )
        _nroficha_tra = ln_nroficha_tra
        _id_dgc = ln_id_dgc
        _codregnac_tra = ln_codregnac_tra
        _codpropietario_tra = ls_codpropietario_tra
        _codexcavacion_tra = ls_codexcavacion_tra
        _codrestauracion_tra = ls_codrestauracion_tra
        _sector_tra = ls_sector_tra
        _unidad_tra = ls_unidad_tra
        _capa_tra = ls_capa_tra
        _nivel_tra = ls_nivel_tra
        _cuadricula_tra = ls_cuadricula_tra
        _plano_tra = ls_plano_tra
        _contexto_tra = ls_contexto_tra
        _ubicontexto_tra = ls_ubicontexto_tra
        _alturaobs_tra = ls_alturaobs_tra
        _otrosdatos_tra = ls_otrosdatos_tra
        _material_tra = ls_material_tra
        _denominacion_tra = ls_denominacion_tra
        _descripcion_tra = ls_descripcion_tra
        _alto_tra = ln_alto_tra
        _largo_tra = ln_largo_tra
        _ancho_tra = ln_ancho_tra
        _espesor_tra = ln_espesor_tra
        _diametromax_tra = ln_diametromax_tra
        _diametromin_tra = ln_diametromin_tra
        _diametrobase_tra = ln_diametrobase_tra
        _pesoini_tra = ln_pesoini_tra
        _pesofin_tra = ln_pesofin_tra
        _ubicinmueble_tra = ls_ubicinmueble_tra
        _nrocaja_tra = ls_nrocaja_tra
        _nrobolsa_tra = ls_nrobolsa_tra
        _integridadbien_tra = ln_integridadbien_tra
        _conservacionbien_tra = ln_conservacionbien_tra
        _detconservacion_tra = ls_detconservacion_tra
        _intervenciones_tra = ls_intervenciones_tra
        _retiroconsolidante_tra = ls_retiroconsolidante_tra
        _limpiezasuperf_tra = ls_limpiezasuperf_tra
        _despegado_tra = ls_despegado_tra
        _pegado_tra = ls_pegado_tra
        _refuerzo_tra = ls_refuerzo_tra
        _otros_tra = ls_otros_tra
        _fini_tra = ld_fini_tra
        _ffin_tra = ld_ffin_tra
        _mecanica_tra = ls_mecanica_tra
        _quimica_tra = ls_quimica_tra
        _finilim_tra = ld_finilim_tra
        _ffinlim_tra = ld_ffinlim_tra
        _intervenido_tra = ln_intervenido_tra
        _dettratamiento_tra = ls_dettratamiento_tra
        _inhibicion_tra = ls_inhibicion_tra
        _estabilizacion_tra = ls_estabilizacion_tra
        _desalacion_tra = ls_desalacion_tra
        _neutralizacion_tra = ls_neutralizacion_tra
        _otrostrat_tra = ls_otrostrat_tra
        _finitrat_tra = ld_finitrat_tra
        _ffintrat_tra = ld_ffintrat_tra
        _secadopost_tra = ls_secadopost_tra
        _pegadopost_tra = ls_pegadopost_tra
        _consolidacion_tra = ls_consolidacion_tra
        _reintegracion_tra = ls_reintegracion_tra
        _otrospost_tra = ls_otrospost_tra
        _finipost_tra = ld_finipost_tra
        _ffinpost_tra = ld_ffinpost_tra
        _temperatura_tra = ln_temperatura_tra
        _humedad_tra = ls_humedad_tra
        _manipulacion_tra = ls_manipulacion_tra
        _iluminacion_tra = ls_iluminacion_tra
        _otrosrec_tra = ls_otrosrec_tra
        _materialrec_tra = ls_materialrec_tra
        _observaciones_tra = ls_observaciones_tra
        _conservadorcargo_tra = ls_conservadorcargo_tra
        _fecha_tra = ld_fecha_tra
        _fotoini_tra = ld_fotoini_tra
        _fotofin_tra = ld_fotofin_tra
        _detalle_tra = ls_detalle_tra
        _foto1_tra = ln_foto1_tra
        _foto2_tra = ln_foto2_tra
        _activo = ln_activo
        _fechareg = ld_fechareg
        _usuarioreg = ls_usuarioreg
        _fechamod = ld_fechamod
        _usuariomod = ls_usuariomod

    End Sub

#End Region

End Class
