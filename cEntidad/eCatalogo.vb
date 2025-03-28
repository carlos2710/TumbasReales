Public Class eCatalogo

#Region "Propiedad"

    Private _codpropietario_cat As String
    Private _codregnac_cat As String
    Private _codexcavacion_cat As String
    Private _codreginc_cat As Integer
    Private _codinvinc_cat As String
    Private _otrocodigos_cat As String
    Private _cultura_cat As String
    Private _estilo_cat As String
    Private _periodo_cat As Integer
    Private _cronologia_cat As Integer
    Private _areageografica_cat As Integer
    Private _origenclasif_cat As Integer
    Private _nombreclasif_cat As String
    Private _region_cat As String
    Private _valle_cat As String
    Private _margen_cat As Integer
    Private _provieneexcav_cat As Integer
    Private _sector_cat As String
    Private _unidad_cat As String
    Private _capa_cat As String
    Private _nivel_cat As String
    Private _cuadricula_cat As String
    Private _plano_cat As String
    Private _contexto_cat As String
    Private _ubicacioncontexto_cat As String
    Private _alturaabs_cat As String
    Private _otrosdatos_cat As String
    Private _material_cat As String
    Private _tipo_cat As String
    Private _denominacion_cat As String
    Private _manufactura_cat As String
    Private _decoracion_cat As String
    Private _descripcion_cat As String
    Private _colores_cat As String
    Private _acabadosuperf_cat As String
    Private _representaciones_cat As String
    Private _motivodecorativo_cat As String
    Private _alto_cat As Integer
    Private _largo_cat As Integer
    Private _ancho_cat As Integer
    Private _espesor_cat As Integer
    Private _diametromax_cat As Integer
    Private _diametromin_cat As Integer
    Private _diametrobase_cat As Integer
    Private _peso_cat As Integer
    Private _tipopropietario_cat As Integer
    Private _propietario_cat As String
    Private _tipocustodio_cat As Integer
    Private _nombrecustodio_cat As String
    Private _adquisicion_cat As Integer
    Private _referenciaadq_cat As String
    Private _direccioninmueble_cat As String
    Private _nombreinmueble_cat As String
    Private _ubicacionespecif_cat As String
    Private _situacion_cat As Integer
    Private _pisovitrina_cat As String
    Private _almacenanaquel_cat As String
    Private _cajacontenedor_cat As String
    Private _bolsa_cat As String
    Private _vistafrontal_cat As String
    Private _vistalateral_cat As String
    Private _otrasvistar_cat As String
    Private _detalle_cat As String
    Private _dibujo_cat As String
    Private _fichacampoelab_cat As String
    Private _fechafichacampo_cat As Date
    Private _fototomada_cat As String
    Private _fechafoto As Date
    Private _tipodoc_cat As Integer
    Private _nrodocumento_cat As Integer
    Private _fechadocumento_cat As Date
    Private _otrasreferencias_cat As String
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

    Public Property codpropietario_cat() As String
        Get
            Return _codpropietario_cat
        End Get
        Set(ByVal value As String)
            _codpropietario_cat = value

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

    Public Property codregnac_cat() As String
        Get
            Return _codregnac_cat
        End Get
        Set(ByVal value As String)
            _codregnac_cat = value

        End Set
    End Property

    Public Property codexcavacion_cat() As String
        Get
            Return _codexcavacion_cat
        End Get
        Set(ByVal value As String)
            _codexcavacion_cat = value

        End Set
    End Property

    Public Property codreginc_cat() As Integer
        Get
            Return _codreginc_cat
        End Get
        Set(ByVal value As Integer)
            _codreginc_cat = value

        End Set
    End Property

    Public Property codinvinc_cat() As String
        Get
            Return _codinvinc_cat
        End Get
        Set(ByVal value As String)
            _codinvinc_cat = value

        End Set
    End Property

    Public Property otrocodigos_cat() As String
        Get
            Return _otrocodigos_cat
        End Get
        Set(ByVal value As String)
            _otrocodigos_cat = value

        End Set
    End Property

    Public Property cultura_cat() As String
        Get
            Return _cultura_cat
        End Get
        Set(ByVal value As String)
            _cultura_cat = value

        End Set
    End Property

    Public Property estilo_cat() As String
        Get
            Return _estilo_cat
        End Get
        Set(ByVal value As String)
            _estilo_cat = value

        End Set
    End Property

    Public Property periodo_cat() As Integer
        Get
            Return _periodo_cat
        End Get
        Set(ByVal value As Integer)
            _periodo_cat = value

        End Set
    End Property

    Public Property cronologia_cat() As Integer
        Get
            Return _cronologia_cat
        End Get
        Set(ByVal value As Integer)
            _cronologia_cat = value

        End Set
    End Property

    Public Property areageografica_cat() As Integer
        Get
            Return _areageografica_cat
        End Get
        Set(ByVal value As Integer)
            _areageografica_cat = value

        End Set
    End Property

    Public Property origenclasif_cat() As Integer
        Get
            Return _origenclasif_cat
        End Get
        Set(ByVal value As Integer)
            _origenclasif_cat = value

        End Set
    End Property

    Public Property nombreclasif_cat() As String
        Get
            Return _nombreclasif_cat
        End Get
        Set(ByVal value As String)
            _nombreclasif_cat = value

        End Set
    End Property

    Public Property region_cat() As String
        Get
            Return _region_cat
        End Get
        Set(ByVal value As String)
            _region_cat = value

        End Set
    End Property

    Public Property valle_cat() As String
        Get
            Return _valle_cat
        End Get
        Set(ByVal value As String)
            _valle_cat = value

        End Set
    End Property

    Public Property margen_cat() As Integer
        Get
            Return _margen_cat
        End Get
        Set(ByVal value As Integer)
            _margen_cat = value

        End Set
    End Property

    Public Property provieneexcav_cat() As Integer
        Get
            Return _provieneexcav_cat
        End Get
        Set(ByVal value As Integer)
            _provieneexcav_cat = value

        End Set
    End Property

    Public Property sector_cat() As String
        Get
            Return _sector_cat
        End Get
        Set(ByVal value As String)
            _sector_cat = value

        End Set
    End Property

    Public Property unidad_cat() As String
        Get
            Return _unidad_cat
        End Get
        Set(ByVal value As String)
            _unidad_cat = value

        End Set
    End Property

    Public Property capa_cat() As String
        Get
            Return _capa_cat
        End Get
        Set(ByVal value As String)
            _capa_cat = value

        End Set
    End Property

    Public Property nivel_cat() As String
        Get
            Return _nivel_cat
        End Get
        Set(ByVal value As String)
            _nivel_cat = value

        End Set
    End Property

    Public Property cuadricula_cat() As String
        Get
            Return _cuadricula_cat
        End Get
        Set(ByVal value As String)
            _cuadricula_cat = value

        End Set
    End Property

    Public Property plano_cat() As String
        Get
            Return _plano_cat
        End Get
        Set(ByVal value As String)
            _plano_cat = value

        End Set
    End Property

    Public Property contexto_cat() As String
        Get
            Return _contexto_cat
        End Get
        Set(ByVal value As String)
            _contexto_cat = value

        End Set
    End Property

    Public Property ubicacioncontexto_cat() As String
        Get
            Return _ubicacioncontexto_cat
        End Get
        Set(ByVal value As String)
            _ubicacioncontexto_cat = value

        End Set
    End Property

    Public Property alturaabs_cat() As String
        Get
            Return _alturaabs_cat
        End Get
        Set(ByVal value As String)
            _alturaabs_cat = value

        End Set
    End Property

    Public Property otrosdatos_cat() As String
        Get
            Return _otrosdatos_cat
        End Get
        Set(ByVal value As String)
            _otrosdatos_cat = value

        End Set
    End Property

    Public Property material_cat() As String
        Get
            Return _material_cat
        End Get
        Set(ByVal value As String)
            _material_cat = value

        End Set
    End Property

    Public Property tipo_cat() As String
        Get
            Return _tipo_cat
        End Get
        Set(ByVal value As String)
            _tipo_cat = value

        End Set
    End Property

    Public Property denominacion_cat() As String
        Get
            Return _denominacion_cat
        End Get
        Set(ByVal value As String)
            _denominacion_cat = value

        End Set
    End Property

    Public Property manufactura_cat() As String
        Get
            Return _manufactura_cat
        End Get
        Set(ByVal value As String)
            _manufactura_cat = value

        End Set
    End Property

    Public Property decoracion_cat() As String
        Get
            Return _decoracion_cat
        End Get
        Set(ByVal value As String)
            _decoracion_cat = value

        End Set
    End Property

    Public Property descripcion_cat() As String
        Get
            Return _descripcion_cat
        End Get
        Set(ByVal value As String)
            _descripcion_cat = value

        End Set
    End Property

    Public Property colores_cat() As String
        Get
            Return _colores_cat
        End Get
        Set(ByVal value As String)
            _colores_cat = value

        End Set
    End Property

    Public Property acabadosuperf_cat() As String
        Get
            Return _acabadosuperf_cat
        End Get
        Set(ByVal value As String)
            _acabadosuperf_cat = value

        End Set
    End Property

    Public Property representaciones_cat() As String
        Get
            Return _representaciones_cat
        End Get
        Set(ByVal value As String)
            _representaciones_cat = value

        End Set
    End Property

    Public Property motivodecorativo_cat() As String
        Get
            Return _motivodecorativo_cat
        End Get
        Set(ByVal value As String)
            _motivodecorativo_cat = value

        End Set
    End Property

    Public Property alto_cat() As Integer
        Get
            Return _alto_cat
        End Get
        Set(ByVal value As Integer)
            _alto_cat = value

        End Set
    End Property

    Public Property largo_cat() As Integer
        Get
            Return _largo_cat
        End Get
        Set(ByVal value As Integer)
            _largo_cat = value

        End Set
    End Property

    Public Property ancho_cat() As Integer
        Get
            Return _ancho_cat
        End Get
        Set(ByVal value As Integer)
            _ancho_cat = value

        End Set
    End Property

    Public Property espesor_cat() As Integer
        Get
            Return _espesor_cat
        End Get
        Set(ByVal value As Integer)
            _espesor_cat = value

        End Set
    End Property

    Public Property diametromax_cat() As Integer
        Get
            Return _diametromax_cat
        End Get
        Set(ByVal value As Integer)
            _diametromax_cat = value

        End Set
    End Property

    Public Property diametromin_cat() As Integer
        Get
            Return _diametromin_cat
        End Get
        Set(ByVal value As Integer)
            _diametromin_cat = value

        End Set
    End Property

    Public Property diametrobase_cat() As Integer
        Get
            Return _diametrobase_cat
        End Get
        Set(ByVal value As Integer)
            _diametrobase_cat = value

        End Set
    End Property

    Public Property peso_cat() As Integer
        Get
            Return _peso_cat
        End Get
        Set(ByVal value As Integer)
            _peso_cat = value

        End Set
    End Property

    Public Property tipopropietario_cat() As Integer
        Get
            Return _tipopropietario_cat
        End Get
        Set(ByVal value As Integer)
            _tipopropietario_cat = value

        End Set
    End Property

    Public Property propietario_cat() As String
        Get
            Return _propietario_cat
        End Get
        Set(ByVal value As String)
            _propietario_cat = value

        End Set
    End Property

    Public Property tipocustodio_cat() As Integer
        Get
            Return _tipocustodio_cat
        End Get
        Set(ByVal value As Integer)
            _tipocustodio_cat = value

        End Set
    End Property

    Public Property nombrecustodio_cat() As String
        Get
            Return _nombrecustodio_cat
        End Get
        Set(ByVal value As String)
            _nombrecustodio_cat = value

        End Set
    End Property

    Public Property adquisicion_cat() As Integer
        Get
            Return _adquisicion_cat
        End Get
        Set(ByVal value As Integer)
            _adquisicion_cat = value

        End Set
    End Property

    Public Property referenciaadq_cat() As String
        Get
            Return _referenciaadq_cat
        End Get
        Set(ByVal value As String)
            _referenciaadq_cat = value

        End Set
    End Property

    Public Property direccioninmueble_cat() As String
        Get
            Return _direccioninmueble_cat
        End Get
        Set(ByVal value As String)
            _direccioninmueble_cat = value

        End Set
    End Property

    Public Property nombreinmueble_cat() As String
        Get
            Return _nombreinmueble_cat
        End Get
        Set(ByVal value As String)
            _nombreinmueble_cat = value

        End Set
    End Property

    Public Property ubicacionespecif_cat() As String
        Get
            Return _ubicacionespecif_cat
        End Get
        Set(ByVal value As String)
            _ubicacionespecif_cat = value

        End Set
    End Property

    Public Property situacion_cat() As Integer
        Get
            Return _situacion_cat
        End Get
        Set(ByVal value As Integer)
            _situacion_cat = value

        End Set
    End Property

    Public Property pisovitrina_cat() As String
        Get
            Return _pisovitrina_cat
        End Get
        Set(ByVal value As String)
            _pisovitrina_cat = value

        End Set
    End Property

    Public Property almacenanaquel_cat() As String
        Get
            Return _almacenanaquel_cat
        End Get
        Set(ByVal value As String)
            _almacenanaquel_cat = value

        End Set
    End Property

    Public Property cajacontenedor_cat() As String
        Get
            Return _cajacontenedor_cat
        End Get
        Set(ByVal value As String)
            _cajacontenedor_cat = value

        End Set
    End Property

    Public Property bolsa_cat() As String
        Get
            Return _bolsa_cat
        End Get
        Set(ByVal value As String)
            _bolsa_cat = value

        End Set
    End Property

    Public Property vistafrontal_cat() As String
        Get
            Return _vistafrontal_cat
        End Get
        Set(ByVal value As String)
            _vistafrontal_cat = value

        End Set
    End Property

    Public Property vistalateral_cat() As String
        Get
            Return _vistalateral_cat
        End Get
        Set(ByVal value As String)
            _vistalateral_cat = value

        End Set
    End Property

    Public Property otrasvistar_cat() As String
        Get
            Return _otrasvistar_cat
        End Get
        Set(ByVal value As String)
            _otrasvistar_cat = value

        End Set
    End Property

    Public Property detalle_cat() As String
        Get
            Return _detalle_cat
        End Get
        Set(ByVal value As String)
            _detalle_cat = value

        End Set
    End Property

    Public Property dibujo_cat() As String
        Get
            Return _dibujo_cat
        End Get
        Set(ByVal value As String)
            _dibujo_cat = value

        End Set
    End Property

    Public Property fichacampoelab_cat() As String
        Get
            Return _fichacampoelab_cat
        End Get
        Set(ByVal value As String)
            _fichacampoelab_cat = value

        End Set
    End Property

    Public Property fechafichacampo_cat() As Date
        Get
            Return _fechafichacampo_cat
        End Get
        Set(ByVal value As Date)
            _fechafichacampo_cat = value

        End Set
    End Property

    Public Property fototomada_cat() As String
        Get
            Return _fototomada_cat
        End Get
        Set(ByVal value As String)
            _fototomada_cat = value

        End Set
    End Property

    Public Property fechafoto() As Date
        Get
            Return _fechafoto
        End Get
        Set(ByVal value As Date)
            _fechafoto = value

        End Set
    End Property

    Public Property tipodoc_cat() As Integer
        Get
            Return _tipodoc_cat
        End Get
        Set(ByVal value As Integer)
            _tipodoc_cat = value

        End Set
    End Property

    Public Property nrodocumento_cat() As Integer
        Get
            Return _nrodocumento_cat
        End Get
        Set(ByVal value As Integer)
            _nrodocumento_cat = value

        End Set
    End Property

    Public Property fechadocumento_cat() As Date
        Get
            Return _fechadocumento_cat
        End Get
        Set(ByVal value As Date)
            _fechadocumento_cat = value

        End Set
    End Property

    Public Property otrasreferencias_cat() As String
        Get
            Return _otrasreferencias_cat
        End Get
        Set(ByVal value As String)
            _otrasreferencias_cat = value

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
        _codpropietario_cat = String.Empty
        _codexcavacion_cat = String.Empty
        _codinvinc_cat = String.Empty
        _otrocodigos_cat = String.Empty
        _cultura_cat = String.Empty
        _estilo_cat = String.Empty
        _nombreclasif_cat = String.Empty
        _region_cat = String.Empty
        _valle_cat = String.Empty
        _sector_cat = String.Empty
        _unidad_cat = String.Empty
        _capa_cat = String.Empty
        _nivel_cat = String.Empty
        _cuadricula_cat = String.Empty
        _contexto_cat = String.Empty
        _ubicacioncontexto_cat = String.Empty
        _alturaabs_cat = String.Empty
        _otrosdatos_cat = String.Empty
        _material_cat = String.Empty
        _tipo_cat = String.Empty
        _denominacion_cat = String.Empty
        _manufactura_cat = String.Empty
        _decoracion_cat = String.Empty
        _descripcion_cat = String.Empty
        _colores_cat = String.Empty
        _acabadosuperf_cat = String.Empty
        _representaciones_cat = String.Empty
        _motivodecorativo_cat = String.Empty
        _propietario_cat = String.Empty
        _nombrecustodio_cat = String.Empty
        _referenciaadq_cat = String.Empty
        _direccioninmueble_cat = String.Empty
        _nombreinmueble_cat = String.Empty
        _ubicacionespecif_cat = String.Empty
        _pisovitrina_cat = String.Empty
        _almacenanaquel_cat = String.Empty
        _bolsa_cat = String.Empty
        _vistafrontal_cat = String.Empty
        _vistalateral_cat = String.Empty
        _otrasvistar_cat = String.Empty
        _detalle_cat = String.Empty
        _dibujo_cat = String.Empty
        _fichacampoelab_cat = String.Empty
        _fototomada_cat = String.Empty
        _otrasreferencias_cat = String.Empty
        _usuarioreg = String.Empty
        _usuariomod = String.Empty
        _plano_cat = String.Empty
        _cajacontenedor_cat = String.Empty
    End Sub

    Public Sub New(
              ByVal ls_codpropietario_cat As String _
              , ByVal ln_codregnac_cat As String _
              , ByVal ls_codexcavacion_cat As String _
              , ByVal ln_codreginc_cat As Integer _
              , ByVal ls_codinvinc_cat As String _
              , ByVal ls_otrocodigos_cat As String _
              , ByVal ls_cultura_cat As String _
              , ByVal ls_estilo_cat As String _
              , ByVal ln_periodo_cat As Integer _
              , ByVal ln_cronologia_cat As Integer _
              , ByVal ln_areageografica_cat As Integer _
              , ByVal ln_origenclasif_cat As Integer _
              , ByVal ls_nombreclasif_cat As String _
              , ByVal ls_region_cat As String _
              , ByVal ls_valle_cat As String _
              , ByVal ln_margen_cat As Integer _
              , ByVal ln_provieneexcav_cat As Integer _
              , ByVal ls_sector_cat As String _
              , ByVal ls_unidad_cat As String _
              , ByVal ls_capa_cat As String _
              , ByVal ls_nivel_cat As String _
              , ByVal ls_cuadricula_cat As String _
              , ByVal ln_plano_cat As String _
              , ByVal ls_contexto_cat As String _
              , ByVal ls_ubicacioncontexto_cat As String _
              , ByVal ls_alturaabs_cat As String _
              , ByVal ls_otrosdatos_cat As String _
              , ByVal ls_material_cat As String _
              , ByVal ls_tipo_cat As String _
              , ByVal ls_denominacion_cat As String _
              , ByVal ls_manufactura_cat As String _
              , ByVal ls_decoracion_cat As String _
              , ByVal ls_descripcion_cat As String _
              , ByVal ls_colores_cat As String _
              , ByVal ls_acabadosuperf_cat As String _
              , ByVal ls_representaciones_cat As String _
              , ByVal ls_motivodecorativo_cat As String _
              , ByVal ln_alto_cat As Integer _
              , ByVal ln_largo_cat As Integer _
              , ByVal ln_ancho_cat As Integer _
              , ByVal ln_espesor_cat As Integer _
              , ByVal ln_diametromax_cat As Integer _
              , ByVal ln_diametromin_cat As Integer _
              , ByVal ln_diametrobase_cat As Integer _
              , ByVal ln_peso_cat As Integer _
              , ByVal ln_tipopropietario_cat As Integer _
              , ByVal ls_propietario_cat As String _
              , ByVal ln_tipocustodio_cat As Integer _
              , ByVal ls_nombrecustodio_cat As String _
              , ByVal ln_adquisicion_cat As Integer _
              , ByVal ls_referenciaadq_cat As String _
              , ByVal ls_direccioninmueble_cat As String _
              , ByVal ls_nombreinmueble_cat As String _
              , ByVal ls_ubicacionespecif_cat As String _
              , ByVal ln_situacion_cat As Integer _
              , ByVal ls_pisovitrina_cat As String _
              , ByVal ls_almacenanaquel_cat As String _
              , ByVal ln_cajacontenedor_cat As String _
              , ByVal ls_bolsa_cat As String _
              , ByVal ls_vistafrontal_cat As String _
              , ByVal ls_vistalateral_cat As String _
              , ByVal ls_otrasvistar_cat As String _
              , ByVal ls_detalle_cat As String _
              , ByVal ls_dibujo_cat As String _
              , ByVal ls_fichacampoelab_cat As String _
              , ByVal ld_fechafichacampo_cat As Date _
              , ByVal ls_fototomada_cat As String _
              , ByVal ld_fechafoto As Date _
              , ByVal ln_tipodoc_cat As Integer _
              , ByVal ln_nrodocumento_cat As Integer _
              , ByVal ld_fechadocumento_cat As Date _
              , ByVal ls_otrasreferencias_cat As String _
              , ByVal ld_fechareg As Date _
              , ByVal ls_usuarioreg As String _
              , ByVal ld_fechamod As Date _
              , ByVal ls_usuariomod As String _
              , ByVal ln_activo_cat As Integer _
              , ByVal ln_id_dgc As Integer
           )
        _codpropietario_cat = ls_codpropietario_cat
        _codregnac_cat = ln_codregnac_cat
        _codexcavacion_cat = ls_codexcavacion_cat
        _codreginc_cat = ln_codreginc_cat
        _codinvinc_cat = ls_codinvinc_cat
        _otrocodigos_cat = ls_otrocodigos_cat
        _cultura_cat = ls_cultura_cat
        _estilo_cat = ls_estilo_cat
        _periodo_cat = ln_periodo_cat
        _cronologia_cat = ln_cronologia_cat
        _areageografica_cat = ln_areageografica_cat
        _origenclasif_cat = ln_origenclasif_cat
        _nombreclasif_cat = ls_nombreclasif_cat
        _region_cat = ls_region_cat
        _valle_cat = ls_valle_cat
        _margen_cat = ln_margen_cat
        _provieneexcav_cat = ln_provieneexcav_cat
        _sector_cat = ls_sector_cat
        _unidad_cat = ls_unidad_cat
        _capa_cat = ls_capa_cat
        _nivel_cat = ls_nivel_cat
        _cuadricula_cat = ls_cuadricula_cat
        _plano_cat = ln_plano_cat
        _contexto_cat = ls_contexto_cat
        _ubicacioncontexto_cat = ls_ubicacioncontexto_cat
        _alturaabs_cat = ls_alturaabs_cat
        _otrosdatos_cat = ls_otrosdatos_cat
        _material_cat = ls_material_cat
        _tipo_cat = ls_tipo_cat
        _denominacion_cat = ls_denominacion_cat
        _manufactura_cat = ls_manufactura_cat
        _decoracion_cat = ls_decoracion_cat
        _descripcion_cat = ls_descripcion_cat
        _colores_cat = ls_colores_cat
        _acabadosuperf_cat = ls_acabadosuperf_cat
        _representaciones_cat = ls_representaciones_cat
        _motivodecorativo_cat = ls_motivodecorativo_cat
        _alto_cat = ln_alto_cat
        _largo_cat = ln_largo_cat
        _ancho_cat = ln_ancho_cat
        _espesor_cat = ln_espesor_cat
        _diametromax_cat = ln_diametromax_cat
        _diametromin_cat = ln_diametromin_cat
        _diametrobase_cat = ln_diametrobase_cat
        _peso_cat = ln_peso_cat
        _tipopropietario_cat = ln_tipopropietario_cat
        _propietario_cat = ls_propietario_cat
        _tipocustodio_cat = ln_tipocustodio_cat
        _nombrecustodio_cat = ls_nombrecustodio_cat
        _adquisicion_cat = ln_adquisicion_cat
        _referenciaadq_cat = ls_referenciaadq_cat
        _direccioninmueble_cat = ls_direccioninmueble_cat
        _nombreinmueble_cat = ls_nombreinmueble_cat
        _ubicacionespecif_cat = ls_ubicacionespecif_cat
        _situacion_cat = ln_situacion_cat
        _pisovitrina_cat = ls_pisovitrina_cat
        _almacenanaquel_cat = ls_almacenanaquel_cat
        _cajacontenedor_cat = ln_cajacontenedor_cat
        _bolsa_cat = ls_bolsa_cat
        _vistafrontal_cat = ls_vistafrontal_cat
        _vistalateral_cat = ls_vistalateral_cat
        _otrasvistar_cat = ls_otrasvistar_cat
        _detalle_cat = ls_detalle_cat
        _dibujo_cat = ls_dibujo_cat
        _fichacampoelab_cat = ls_fichacampoelab_cat
        _fechafichacampo_cat = ld_fechafichacampo_cat
        _fototomada_cat = ls_fototomada_cat
        _fechafoto = ld_fechafoto
        _tipodoc_cat = ln_tipodoc_cat
        _nrodocumento_cat = ln_nrodocumento_cat
        _fechadocumento_cat = ld_fechadocumento_cat
        _otrasreferencias_cat = ls_otrasreferencias_cat
        _fechareg = ld_fechareg
        _usuarioreg = ls_usuarioreg
        _fechamod = ld_fechamod
        _usuariomod = ls_usuariomod
        _activo_cat = ln_activo_cat
        _id_dgc = ln_id_dgc
    End Sub

#End Region

End Class
