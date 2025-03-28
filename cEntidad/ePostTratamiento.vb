Public Class ePostTratamiento
#Region "Propiedad"

    Private _nroficha_ptr As Integer
    Private _id_dgc As Integer
    Private _codregnac_ptr As String
    Private _codpropietario_ptr As String
    Private _codexcavacion_ptr As String
    Private _codrestauracion_ptr As String
    Private _sector_ptr As String
    Private _unidad_ptr As String
    Private _capa_ptr As String
    Private _nivel_ptr As String
    Private _cuadricula_ptr As String
    Private _plano_ptr As String
    Private _contexto_ptr As String
    Private _ubicontexto_ptr As String
    Private _alturaobs_ptr As String
    Private _otrosdatos_ptr As String
    Private _material_ptr As String
    Private _denominacion_ptr As String
    Private _descripcion_ptr As String
    Private _alto_ptr As Integer
    Private _largo_ptr As Integer
    Private _ancho_ptr As Integer
    Private _espesor_ptr As Integer
    Private _diametromax_ptr As Integer
    Private _diametromin_ptr As Integer
    Private _diametrobase_ptr As Integer
    Private _peso_ptr As Integer
    Private _ubicinmueble_ptr As String
    Private _nrocaja_ptr As String
    Private _nrobolsa_ptr As String
    Private _problematica_ptr As String
    Private _varicacion_ptr As String
    Private _reacciones_ptr As String
    Private _presentaafec_ptr As String
    Private _tipoafec_ptr As String
    Private _causaafec_ptr As String
    Private _recomendaciones_ptr As String
    Private _conservadorcargo_ptr As String
    Private _fecha_ptr As Date
    Private _foto_ptr As Integer
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

    Public Property nroficha_ptr() As Integer
        Get
            Return _nroficha_ptr
        End Get
        Set(ByVal value As Integer)
            _nroficha_ptr = value

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

    Public Property codregnac_ptr() As String
        Get
            Return _codregnac_ptr
        End Get
        Set(ByVal value As String)
            _codregnac_ptr = value

        End Set
    End Property

    Public Property codpropietario_ptr() As String
        Get
            Return _codpropietario_ptr
        End Get
        Set(ByVal value As String)
            _codpropietario_ptr = value

        End Set
    End Property

    Public Property codexcavacion_ptr() As String
        Get
            Return _codexcavacion_ptr
        End Get
        Set(ByVal value As String)
            _codexcavacion_ptr = value

        End Set
    End Property

    Public Property codrestauracion_ptr() As String
        Get
            Return _codrestauracion_ptr
        End Get
        Set(ByVal value As String)
            _codrestauracion_ptr = value

        End Set
    End Property

    Public Property sector_ptr() As String
        Get
            Return _sector_ptr
        End Get
        Set(ByVal value As String)
            _sector_ptr = value

        End Set
    End Property

    Public Property unidad_ptr() As String
        Get
            Return _unidad_ptr
        End Get
        Set(ByVal value As String)
            _unidad_ptr = value

        End Set
    End Property

    Public Property capa_ptr() As String
        Get
            Return _capa_ptr
        End Get
        Set(ByVal value As String)
            _capa_ptr = value

        End Set
    End Property

    Public Property nivel_ptr() As String
        Get
            Return _nivel_ptr
        End Get
        Set(ByVal value As String)
            _nivel_ptr = value

        End Set
    End Property

    Public Property cuadricula_ptr() As String
        Get
            Return _cuadricula_ptr
        End Get
        Set(ByVal value As String)
            _cuadricula_ptr = value

        End Set
    End Property

    Public Property plano_ptr() As String
        Get
            Return _plano_ptr
        End Get
        Set(ByVal value As String)
            _plano_ptr = value

        End Set
    End Property

    Public Property contexto_ptr() As String
        Get
            Return _contexto_ptr
        End Get
        Set(ByVal value As String)
            _contexto_ptr = value

        End Set
    End Property

    Public Property ubicontexto_ptr() As String
        Get
            Return _ubicontexto_ptr
        End Get
        Set(ByVal value As String)
            _ubicontexto_ptr = value

        End Set
    End Property

    Public Property alturaobs_ptr() As String
        Get
            Return _alturaobs_ptr
        End Get
        Set(ByVal value As String)
            _alturaobs_ptr = value

        End Set
    End Property

    Public Property otrosdatos_ptr() As String
        Get
            Return _otrosdatos_ptr
        End Get
        Set(ByVal value As String)
            _otrosdatos_ptr = value

        End Set
    End Property

    Public Property material_ptr() As String
        Get
            Return _material_ptr
        End Get
        Set(ByVal value As String)
            _material_ptr = value

        End Set
    End Property

    Public Property denominacion_ptr() As String
        Get
            Return _denominacion_ptr
        End Get
        Set(ByVal value As String)
            _denominacion_ptr = value

        End Set
    End Property

    Public Property descripcion_ptr() As String
        Get
            Return _descripcion_ptr
        End Get
        Set(ByVal value As String)
            _descripcion_ptr = value

        End Set
    End Property

    Public Property alto_ptr() As Integer
        Get
            Return _alto_ptr
        End Get
        Set(ByVal value As Integer)
            _alto_ptr = value

        End Set
    End Property

    Public Property largo_ptr() As Integer
        Get
            Return _largo_ptr
        End Get
        Set(ByVal value As Integer)
            _largo_ptr = value

        End Set
    End Property

    Public Property ancho_ptr() As Integer
        Get
            Return _ancho_ptr
        End Get
        Set(ByVal value As Integer)
            _ancho_ptr = value

        End Set
    End Property

    Public Property espesor_ptr() As Integer
        Get
            Return _espesor_ptr
        End Get
        Set(ByVal value As Integer)
            _espesor_ptr = value

        End Set
    End Property

    Public Property diametromax_ptr() As Integer
        Get
            Return _diametromax_ptr
        End Get
        Set(ByVal value As Integer)
            _diametromax_ptr = value

        End Set
    End Property

    Public Property diametromin_ptr() As Integer
        Get
            Return _diametromin_ptr
        End Get
        Set(ByVal value As Integer)
            _diametromin_ptr = value

        End Set
    End Property

    Public Property diametrobase_ptr() As Integer
        Get
            Return _diametrobase_ptr
        End Get
        Set(ByVal value As Integer)
            _diametrobase_ptr = value

        End Set
    End Property

    Public Property peso_ptr() As Integer
        Get
            Return _peso_ptr
        End Get
        Set(ByVal value As Integer)
            _peso_ptr = value

        End Set
    End Property

    Public Property ubicinmueble_ptr() As String
        Get
            Return _ubicinmueble_ptr
        End Get
        Set(ByVal value As String)
            _ubicinmueble_ptr = value

        End Set
    End Property

    Public Property nrobolsa_ptr() As String
        Get
            Return _nrobolsa_ptr
        End Get
        Set(ByVal value As String)
            _nrobolsa_ptr = value

        End Set
    End Property

    Public Property problematica_ptr() As String
        Get
            Return _problematica_ptr
        End Get
        Set(ByVal value As String)
            _problematica_ptr = value

        End Set
    End Property

    Public Property varicacion_ptr() As String
        Get
            Return _varicacion_ptr
        End Get
        Set(ByVal value As String)
            _varicacion_ptr = value

        End Set
    End Property

    Public Property reacciones_ptr() As String
        Get
            Return _reacciones_ptr
        End Get
        Set(ByVal value As String)
            _reacciones_ptr = value

        End Set
    End Property

    Public Property nrocaja_ptr() As String
        Get
            Return _nrocaja_ptr
        End Get
        Set(ByVal value As String)
            _nrocaja_ptr = value

        End Set
    End Property

    Public Property presentaafec_ptr() As String
        Get
            Return _presentaafec_ptr
        End Get
        Set(ByVal value As String)
            _presentaafec_ptr = value

        End Set
    End Property

    Public Property tipoafec_ptr() As String
        Get
            Return _tipoafec_ptr
        End Get
        Set(ByVal value As String)
            _tipoafec_ptr = value

        End Set
    End Property

    Public Property causaafec_ptr() As String
        Get
            Return _causaafec_ptr
        End Get
        Set(ByVal value As String)
            _causaafec_ptr = value

        End Set
    End Property

    Public Property recomendaciones_ptr() As String
        Get
            Return _recomendaciones_ptr
        End Get
        Set(ByVal value As String)
            _recomendaciones_ptr = value

        End Set
    End Property

    Public Property conservadorcargo_ptr() As String
        Get
            Return _conservadorcargo_ptr
        End Get
        Set(ByVal value As String)
            _conservadorcargo_ptr = value

        End Set
    End Property

    Public Property fecha_ptr() As Date
        Get
            Return _fecha_ptr
        End Get
        Set(ByVal value As Date)
            _fecha_ptr = value

        End Set
    End Property

    Public Property foto_ptr() As Integer
        Get
            Return _foto_ptr
        End Get
        Set(ByVal value As Integer)
            _foto_ptr = value

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
        _codpropietario_ptr = String.Empty
        _codexcavacion_ptr = String.Empty
        _codrestauracion_ptr = String.Empty
        _sector_ptr = String.Empty
        _unidad_ptr = String.Empty
        _capa_ptr = String.Empty
        _nivel_ptr = String.Empty
        _cuadricula_ptr = String.Empty
        _plano_ptr = String.Empty
        _contexto_ptr = String.Empty
        _ubicontexto_ptr = String.Empty
        _alturaobs_ptr = String.Empty
        _otrosdatos_ptr = String.Empty
        _material_ptr = String.Empty
        _denominacion_ptr = String.Empty
        _descripcion_ptr = String.Empty
        _ubicinmueble_ptr = String.Empty
        _nrocaja_ptr = String.Empty
        _nrobolsa_ptr = String.Empty
        _problematica_ptr = String.Empty
        _varicacion_ptr = String.Empty
        _reacciones_ptr = String.Empty
        _tipoafec_ptr = String.Empty
        _causaafec_ptr = String.Empty
        _recomendaciones_ptr = String.Empty
        _conservadorcargo_ptr = String.Empty
        _usuarioreg = String.Empty
        _usuariomod = String.Empty
        _presentaafec_ptr = String.Empty
    End Sub

    Public Sub New(
                 ByVal ln_nroficha_ptr As Integer _
                , ByVal ln_id_dgc As Integer _
                , ByVal ln_codregnac_ptr As String _
                , ByVal ls_codpropietario_ptr As String _
                , ByVal ls_codexcavacion_ptr As String _
                , ByVal ls_codrestauracion_ptr As String _
                , ByVal ls_sector_ptr As String _
                , ByVal ls_unidad_ptr As String _
                , ByVal ls_capa_ptr As String _
                , ByVal ls_nivel_ptr As String _
                , ByVal ls_cuadricula_ptr As String _
                , ByVal ls_plano_ptr As String _
                , ByVal ls_contexto_ptr As String _
                , ByVal ls_ubicontexto_ptr As String _
                , ByVal ls_alturaobs_ptr As String _
                , ByVal ls_otrosdatos_ptr As String _
                , ByVal ls_material_ptr As String _
                , ByVal ls_denominacion_ptr As String _
                , ByVal ls_descripcion_ptr As String _
                , ByVal ln_alto_ptr As Integer _
                , ByVal ln_largo_ptr As Integer _
                , ByVal ln_ancho_ptr As Integer _
                , ByVal ln_espesor_ptr As Integer _
                , ByVal ln_diametromax_ptr As Integer _
                , ByVal ln_diametromin_ptr As Integer _
                , ByVal ln_diametrobase_ptr As Integer _
                , ByVal ln_peso_ptr As Integer _
                , ByVal ls_ubicinmueble_ptr As String _
                , ByVal ls_nrocaja_ptr As String _
                , ByVal ls_nrobolsa_ptr As String _
                , ByVal ls_problematica_ptr As String _
                , ByVal ls_varicacion_ptr As String _
                , ByVal ls_reacciones_ptr As String _
                , ByVal ln_presentaafec_ptr As String _
                , ByVal ls_tipoafec_ptr As String _
                , ByVal ls_causaafec_ptr As String _
                , ByVal ls_recomendaciones_ptr As String _
                , ByVal ls_conservadorcargo_ptr As String _
                , ByVal ld_fecha_ptr As Date _
                , ByVal ln_foto_ptr As Integer _
                , ByVal ln_activo As Integer _
                , ByVal ld_fechareg As Date _
                , ByVal ls_usuarioreg As String _
                , ByVal ld_fechamod As Date _
                , ByVal ls_usuariomod As String
                )
        _nroficha_ptr = ln_nroficha_ptr
        _id_dgc = ln_id_dgc
        _codregnac_ptr = ln_codregnac_ptr
        _codpropietario_ptr = ls_codpropietario_ptr
        _codexcavacion_ptr = ls_codexcavacion_ptr
        _codrestauracion_ptr = ls_codrestauracion_ptr
        _sector_ptr = ls_sector_ptr
        _unidad_ptr = ls_unidad_ptr
        _capa_ptr = ls_capa_ptr
        _nivel_ptr = ls_nivel_ptr
        _cuadricula_ptr = ls_cuadricula_ptr
        _plano_ptr = ls_plano_ptr
        _contexto_ptr = ls_contexto_ptr
        _ubicontexto_ptr = ls_ubicontexto_ptr
        _alturaobs_ptr = ls_alturaobs_ptr
        _otrosdatos_ptr = ls_otrosdatos_ptr
        _material_ptr = ls_material_ptr
        _denominacion_ptr = ls_denominacion_ptr
        _descripcion_ptr = ls_descripcion_ptr
        _alto_ptr = ln_alto_ptr
        _largo_ptr = ln_largo_ptr
        _ancho_ptr = ln_ancho_ptr
        _espesor_ptr = ln_espesor_ptr
        _diametromax_ptr = ln_diametromax_ptr
        _diametromin_ptr = ln_diametromin_ptr
        _diametrobase_ptr = ln_diametrobase_ptr
        _peso_ptr = ln_peso_ptr
        _ubicinmueble_ptr = ls_ubicinmueble_ptr
        _nrocaja_ptr = ls_nrocaja_ptr
        _nrobolsa_ptr = ls_nrobolsa_ptr
        _problematica_ptr = ls_problematica_ptr
        _varicacion_ptr = ls_varicacion_ptr
        _reacciones_ptr = ls_reacciones_ptr
        _presentaafec_ptr = ln_presentaafec_ptr
        _tipoafec_ptr = ls_tipoafec_ptr
        _causaafec_ptr = ls_causaafec_ptr
        _recomendaciones_ptr = ls_recomendaciones_ptr
        _conservadorcargo_ptr = ls_conservadorcargo_ptr
        _fecha_ptr = ld_fecha_ptr
        _foto_ptr = ln_foto_ptr
        _activo = ln_activo
        _fechareg = ld_fechareg
        _usuarioreg = ls_usuarioreg
        _fechamod = ld_fechamod
        _usuariomod = ls_usuariomod

    End Sub

#End Region

End Class

