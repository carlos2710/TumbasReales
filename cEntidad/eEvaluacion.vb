Public Class eEvaluacion

#Region "Propiedad"

    Private _nroficha_con As Integer
    Private _id_dgc As Integer
    Private _codregnac_con As String
    Private _codpropietario_con As String
    Private _codexcavacion_con As String
    Private _codrestauracion_con As String
    Private _sector_con As String
    Private _unidad_con As String
    Private _capa_con As String
    Private _nivel_con As String
    Private _cuadricula_con As String
    Private _plano_con As String
    Private _contexto_con As String
    Private _ubicontexto_con As String
    Private _alturaobs_con As String
    Private _otrosdatos_con As String
    Private _material_con As String
    Private _denominacion_con As String
    Private _descripcion_con As String
    Private _alto_con As Integer
    Private _largo_con As Integer
    Private _ancho_con As Integer
    Private _espesor_con As Integer
    Private _diametromax_con As Integer
    Private _diametromin_con As Integer
    Private _diametrobase_con As Integer
    Private _peso_con As Integer
    Private _ubicinmueble_con As String
    Private _nrocaja_con As String
    Private _nrobolsa_con As String
    Private _integridadbien_con As Integer
    Private _conservacionbien_con As Integer
    Private _detconservacion_con As String
    Private _intervenciones_con As String
    Private _afectacion_con As String
    Private _tratamiento_con As String
    Private _limpieza_con As String
    Private _observaciones_con As String
    Private _temperatura_con As Integer
    Private _humedad_con As String
    Private _manipulacion_con As String
    Private _otros_con As String
    Private _conservadorcargo_con As String
    Private _fecha_con As Date
    Private _foto_con As Integer
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

    Public Property nroficha_con() As Integer
        Get
            Return _nroficha_con
        End Get
        Set(ByVal value As Integer)
            _nroficha_con = value

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

    Public Property codregnac_con() As String
        Get
            Return _codregnac_con
        End Get
        Set(ByVal value As String)
            _codregnac_con = value

        End Set
    End Property

    Public Property codpropietario_con() As String
        Get
            Return _codpropietario_con
        End Get
        Set(ByVal value As String)
            _codpropietario_con = value

        End Set
    End Property

    Public Property codexcavacion_con() As String
        Get
            Return _codexcavacion_con
        End Get
        Set(ByVal value As String)
            _codexcavacion_con = value

        End Set
    End Property

    Public Property codrestauracion_con() As String
        Get
            Return _codrestauracion_con
        End Get
        Set(ByVal value As String)
            _codrestauracion_con = value

        End Set
    End Property

    Public Property sector_con() As String
        Get
            Return _sector_con
        End Get
        Set(ByVal value As String)
            _sector_con = value

        End Set
    End Property

    Public Property unidad_con() As String
        Get
            Return _unidad_con
        End Get
        Set(ByVal value As String)
            _unidad_con = value

        End Set
    End Property

    Public Property capa_con() As String
        Get
            Return _capa_con
        End Get
        Set(ByVal value As String)
            _capa_con = value

        End Set
    End Property

    Public Property nivel_con() As String
        Get
            Return _nivel_con
        End Get
        Set(ByVal value As String)
            _nivel_con = value

        End Set
    End Property

    Public Property cuadricula_con() As String
        Get
            Return _cuadricula_con
        End Get
        Set(ByVal value As String)
            _cuadricula_con = value

        End Set
    End Property

    Public Property contexto_con() As String
        Get
            Return _contexto_con
        End Get
        Set(ByVal value As String)
            _contexto_con = value

        End Set
    End Property

    Public Property ubicontexto_con() As String
        Get
            Return _ubicontexto_con
        End Get
        Set(ByVal value As String)
            _ubicontexto_con = value

        End Set
    End Property

    Public Property alturaobs_con() As String
        Get
            Return _alturaobs_con
        End Get
        Set(ByVal value As String)
            _alturaobs_con = value

        End Set
    End Property

    Public Property otrosdatos_con() As String
        Get
            Return _otrosdatos_con
        End Get
        Set(ByVal value As String)
            _otrosdatos_con = value

        End Set
    End Property

    Public Property material_con() As String
        Get
            Return _material_con
        End Get
        Set(ByVal value As String)
            _material_con = value

        End Set
    End Property

    Public Property denominacion_con() As String
        Get
            Return _denominacion_con
        End Get
        Set(ByVal value As String)
            _denominacion_con = value

        End Set
    End Property

    Public Property descripcion_con() As String
        Get
            Return _descripcion_con
        End Get
        Set(ByVal value As String)
            _descripcion_con = value

        End Set
    End Property

    Public Property alto_con() As Integer
        Get
            Return _alto_con
        End Get
        Set(ByVal value As Integer)
            _alto_con = value

        End Set
    End Property

    Public Property largo_con() As Integer
        Get
            Return _largo_con
        End Get
        Set(ByVal value As Integer)
            _largo_con = value

        End Set
    End Property

    Public Property ancho_con() As Integer
        Get
            Return _ancho_con
        End Get
        Set(ByVal value As Integer)
            _ancho_con = value

        End Set
    End Property

    Public Property espesor_con() As Integer
        Get
            Return _espesor_con
        End Get
        Set(ByVal value As Integer)
            _espesor_con = value

        End Set
    End Property

    Public Property diametromax_con() As Integer
        Get
            Return _diametromax_con
        End Get
        Set(ByVal value As Integer)
            _diametromax_con = value

        End Set
    End Property

    Public Property diametromin_con() As Integer
        Get
            Return _diametromin_con
        End Get
        Set(ByVal value As Integer)
            _diametromin_con = value

        End Set
    End Property

    Public Property diametrobase_con() As Integer
        Get
            Return _diametrobase_con
        End Get
        Set(ByVal value As Integer)
            _diametrobase_con = value

        End Set
    End Property

    Public Property peso_con() As Integer
        Get
            Return _peso_con
        End Get
        Set(ByVal value As Integer)
            _peso_con = value

        End Set
    End Property

    Public Property ubicinmueble_con() As String
        Get
            Return _ubicinmueble_con
        End Get
        Set(ByVal value As String)
            _ubicinmueble_con = value

        End Set
    End Property

    Public Property nrocaja_con() As String
        Get
            Return _nrocaja_con
        End Get
        Set(ByVal value As String)
            _nrocaja_con = value

        End Set
    End Property

    Public Property nrobolsa_con() As String
        Get
            Return _nrobolsa_con
        End Get
        Set(ByVal value As String)
            _nrobolsa_con = value

        End Set
    End Property

    Public Property integridadbien_con() As Integer
        Get
            Return _integridadbien_con
        End Get
        Set(ByVal value As Integer)
            _integridadbien_con = value

        End Set
    End Property

    Public Property conservacionbien_con() As Integer
        Get
            Return _conservacionbien_con
        End Get
        Set(ByVal value As Integer)
            _conservacionbien_con = value

        End Set
    End Property

    Public Property detconservacion_con() As String
        Get
            Return _detconservacion_con
        End Get
        Set(ByVal value As String)
            _detconservacion_con = value

        End Set
    End Property

    Public Property intervenciones_con() As String
        Get
            Return _intervenciones_con
        End Get
        Set(ByVal value As String)
            _intervenciones_con = value

        End Set
    End Property

    Public Property afectacion_con() As String
        Get
            Return _afectacion_con
        End Get
        Set(ByVal value As String)
            _afectacion_con = value

        End Set
    End Property

    Public Property tratamiento_con() As String
        Get
            Return _tratamiento_con
        End Get
        Set(ByVal value As String)
            _tratamiento_con = value

        End Set
    End Property

    Public Property limpieza_con() As String
        Get
            Return _limpieza_con
        End Get
        Set(ByVal value As String)
            _limpieza_con = value

        End Set
    End Property

    Public Property observaciones_con() As String
        Get
            Return _observaciones_con
        End Get
        Set(ByVal value As String)
            _observaciones_con = value

        End Set
    End Property

    Public Property temperatura_con() As Integer
        Get
            Return _temperatura_con
        End Get
        Set(ByVal value As Integer)
            _temperatura_con = value

        End Set
    End Property

    Public Property humedad_con() As String
        Get
            Return _humedad_con
        End Get
        Set(ByVal value As String)
            _humedad_con = value

        End Set
    End Property

    Public Property manipulacion_con() As String
        Get
            Return _manipulacion_con
        End Get
        Set(ByVal value As String)
            _manipulacion_con = value

        End Set
    End Property

    Public Property fecha_con() As Date
        Get
            Return _fecha_con
        End Get
        Set(ByVal value As Date)
            _fecha_con = value

        End Set
    End Property

    Public Property otros_con() As String
        Get
            Return _otros_con
        End Get
        Set(ByVal value As String)
            _otros_con = value

        End Set
    End Property

    Public Property conservadorcargo_con() As String
        Get
            Return _conservadorcargo_con
        End Get
        Set(ByVal value As String)
            _conservadorcargo_con = value

        End Set
    End Property

    Public Property foto_con() As Integer
        Get
            Return _foto_con
        End Get
        Set(ByVal value As Integer)
            _foto_con = value

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
        _codpropietario_con = String.Empty
        _codexcavacion_con = String.Empty
        _codrestauracion_con = String.Empty
        _sector_con = String.Empty
        _unidad_con = String.Empty
        _capa_con = String.Empty
        _nivel_con = String.Empty
        _cuadricula_con = String.Empty
        _plano_con = String.Empty
        _contexto_con = String.Empty
        _ubicontexto_con = String.Empty
        _alturaobs_con = String.Empty
        _otrosdatos_con = String.Empty
        _material_con = String.Empty
        _denominacion_con = String.Empty
        _descripcion_con = String.Empty
        _ubicinmueble_con = String.Empty
        _nrocaja_con = String.Empty
        _nrobolsa_con = String.Empty
        _detconservacion_con = String.Empty
        _intervenciones_con = String.Empty
        _afectacion_con = String.Empty
        _tratamiento_con = String.Empty
        _limpieza_con = String.Empty
        _observaciones_con = String.Empty
        _manipulacion_con = String.Empty
        _otros_con = String.Empty
        _conservadorcargo_con = String.Empty
        _usuarioreg = String.Empty
        _usuariomod = String.Empty
        _humedad_con = String.Empty
    End Sub

    Public Sub New(
             ByVal ln_nroficha_con As Integer _
            , ByVal ln_id_dgc As Integer _
            , ByVal ln_codregnac_con As String _
            , ByVal ls_codpropietario_con As String _
            , ByVal ls_codexcavacion_con As String _
            , ByVal ls_codrestauracion_con As String _
            , ByVal ls_sector_con As String _
            , ByVal ls_unidad_con As String _
            , ByVal ls_capa_con As String _
            , ByVal ls_nivel_con As String _
            , ByVal ls_cuadricula_con As String _
            , ByVal ls_plano_con As String _
            , ByVal ls_contexto_con As String _
            , ByVal ls_ubicontexto_con As String _
            , ByVal ls_alturaobs_con As String _
            , ByVal ls_otrosdatos_con As String _
            , ByVal ls_material_con As String _
            , ByVal ls_denominacion_con As String _
            , ByVal ls_descripcion_con As String _
            , ByVal ln_alto_con As Integer _
            , ByVal ln_largo_con As Integer _
            , ByVal ln_ancho_con As Integer _
            , ByVal ln_espesor_con As Integer _
            , ByVal ln_diametromax_con As Integer _
            , ByVal ln_diametromin_con As Integer _
            , ByVal ln_diametrobase_con As Integer _
            , ByVal ln_peso_con As Integer _
            , ByVal ls_ubicinmueble_con As String _
            , ByVal ls_nrocaja_con As String _
            , ByVal ls_nrobolsa_con As String _
            , ByVal ln_integridadbien_con As Integer _
            , ByVal ln_conservacionbien_con As Integer _
            , ByVal ls_detconservacion_con As String _
            , ByVal ls_intervenciones_con As String _
            , ByVal ls_afectacion_con As String _
            , ByVal ls_tratamiento_con As String _
            , ByVal ls_limpieza_con As String _
            , ByVal ls_observaciones_con As String _
            , ByVal ln_temperatura_con As Integer _
            , ByVal ln_humedad_con As String _
            , ByVal ls_manipulacion_con As String _
            , ByVal ls_otros_con As String _
            , ByVal ls_conservadorcargo_con As String _
            , ByVal ld_fecha_con As Date _
            , ByVal ln_foto_con As Integer _
            , ByVal ln_activo As Integer _
            , ByVal ld_fechareg As Date _
            , ByVal ls_usuarioreg As String _
            , ByVal ld_fechamod As Date _
            , ByVal ls_usuariomod As String
           )
        _nroficha_con = ln_nroficha_con
        _id_dgc = ln_id_dgc
        _codregnac_con = ln_codregnac_con
        _codpropietario_con = ls_codpropietario_con
        _codexcavacion_con = ls_codexcavacion_con
        _codrestauracion_con = ls_codrestauracion_con
        _sector_con = ls_sector_con
        _unidad_con = ls_unidad_con
        _capa_con = ls_capa_con
        _nivel_con = ls_nivel_con
        _cuadricula_con = ls_cuadricula_con
        _plano_con = ls_plano_con
        _contexto_con = ls_contexto_con
        _ubicontexto_con = ls_ubicontexto_con
        _alturaobs_con = ls_alturaobs_con
        _otrosdatos_con = ls_otrosdatos_con
        _material_con = ls_material_con
        _denominacion_con = ls_denominacion_con
        _descripcion_con = ls_descripcion_con
        _alto_con = ln_alto_con
        _largo_con = ln_largo_con
        _ancho_con = ln_ancho_con
        _espesor_con = ln_espesor_con
        _diametromax_con = ln_diametromax_con
        _diametromin_con = ln_diametromin_con
        _diametrobase_con = ln_diametrobase_con
        _peso_con = ln_peso_con
        _ubicinmueble_con = ls_ubicinmueble_con
        _nrocaja_con = ls_nrocaja_con
        _nrobolsa_con = ls_nrobolsa_con
        _integridadbien_con = ln_integridadbien_con
        _conservacionbien_con = ln_conservacionbien_con
        _detconservacion_con = ls_detconservacion_con
        _intervenciones_con = ls_intervenciones_con
        _afectacion_con = ls_afectacion_con
        _tratamiento_con = ls_tratamiento_con
        _limpieza_con = ls_limpieza_con
        _observaciones_con = ls_observaciones_con
        _temperatura_con = ln_temperatura_con
        _humedad_con = ln_humedad_con
        _manipulacion_con = ls_manipulacion_con
        _otros_con = ls_otros_con
        _conservadorcargo_con = ls_conservadorcargo_con
        _fecha_con = ld_fecha_con
        _foto_con = ln_foto_con
        _activo = ln_activo
        _fechareg = ld_fechareg
        _usuarioreg = ls_usuarioreg
        _fechamod = ld_fechamod
        _usuariomod = ls_usuariomod

    End Sub

#End Region

End Class
