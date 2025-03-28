Public Class etbInventario
#Region "Propiedad"
    Private _cod_inventario As Integer
    Private _registro_nacional As String
    Private _codigo_propiet As String
    Private _otro_codigo As String
    Private _categoria As String
    Private _taxonomia As String
    Private _denominacion As String
    Private _cultura As String
    Private _periodo As String
    Private _descripcion_identificacion As String
    Private _tipo_material As String
    Private _tecnicas As String
    Private _alto As String
    Private _largo As String
    Private _ancho As String
    Private _diam_maximo As String
    Private _diam_min As String
    Private _peso As String
    Private _estado_integridad As String
    Private _cantidad As Integer
    Private _detalle_conservacion As String
    Private _procedencia As String
    Private _region_origen As String
    Private _sitio_origen As String
    Private _sector_origen As String
    Private _subsector_origen As String
    Private _unidad_origen As String
    Private _cuadrante_origen As String
    Private _capa_origen As String
    Private _cuadricula_origen As String
    Private _contexto_origen As String
    Private _coleccion_propiedad As String
    Private _adquisicion_propiedad As String
    Private _documento_propiedad As String
    Private _fecha_propiedad As Date
    Private _ubicacion As String
    Private _area_ubicacion As String
    Private _especifica_ubicacion As String
    Private _nivel_ubicacion As String
    Private _caja_ubicacion As String
    Private _bolsa_ubicacion As String
    Private _excavado_adic As String
    Private _registrado_adic As String
    Private _fecha_adic As Date
    Private _observacion_adic As String

    'inicio jaz
    Private _cod_dgc As Integer
    'fin jaz

    Public TipoOperacion As String

    Public Modificado As Boolean

    Public _param1 As String
    Public _param2 As String
    Public _param3 As String
    Private ReadOnly ln_Cod_Inventario As Integer
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

    Public Property cod_inventario() As Integer
        Get
            Return _cod_inventario

        End Get
        Set(ByVal value As Integer)
            _cod_inventario = value
            RaiseEvent DatoCambiado()
        End Set
    End Property

    Public Property Registro_nacional() As String
        Get
            Return _registro_nacional
        End Get
        Set(ByVal value As String)
            _registro_nacional = value
            RaiseEvent DatoCambiado()
        End Set
    End Property

    Public Property Codigo_propiet() As String
        Get
            Return _codigo_propiet
        End Get
        Set(ByVal value As String)
            _codigo_propiet = value
            RaiseEvent DatoCambiado()
        End Set
    End Property

    Public Property Otro_codigo() As String
        Get
            Return _otro_codigo
        End Get
        Set(ByVal value As String)
            _otro_codigo = value
            RaiseEvent DatoCambiado()
        End Set
    End Property

    Public Property Categoria() As String
        Get
            Return _categoria
        End Get
        Set(ByVal value As String)
            _categoria = value
            RaiseEvent DatoCambiado()
        End Set
    End Property

    Public Property Taxonomia() As String
        Get
            Return _taxonomia
        End Get
        Set(ByVal value As String)
            _taxonomia = value
            RaiseEvent DatoCambiado()
        End Set
    End Property

    Public Property Denominacion() As String
        Get
            Return _denominacion
        End Get
        Set(ByVal value As String)
            _denominacion = value
            RaiseEvent DatoCambiado()
        End Set
    End Property

    Public Property Cultura() As String
        Get
            Return _cultura
        End Get
        Set(ByVal value As String)
            _cultura = value
            RaiseEvent DatoCambiado()
        End Set
    End Property

    Public Property Periodo() As String
        Get
            Return _periodo
        End Get
        Set(ByVal value As String)
            _periodo = value
            RaiseEvent DatoCambiado()
        End Set
    End Property

    Public Property Descripcion_identificacion() As String
        Get
            Return _descripcion_identificacion
        End Get
        Set(ByVal value As String)
            _descripcion_identificacion = value
            RaiseEvent DatoCambiado()
        End Set
    End Property

    Public Property Tipo_material() As String
        Get
            Return _tipo_material
        End Get
        Set(ByVal value As String)
            _tipo_material = value
            RaiseEvent DatoCambiado()
        End Set
    End Property

    Public Property Tecnicas() As String
        Get
            Return _tecnicas
        End Get
        Set(ByVal value As String)
            _tecnicas = value
            RaiseEvent DatoCambiado()
        End Set
    End Property

    Public Property Alto() As String
        Get
            Return _alto
        End Get
        Set(ByVal value As String)
            _alto = value
            RaiseEvent DatoCambiado()
        End Set
    End Property

    Public Property Largo() As String
        Get
            Return _largo
        End Get
        Set(ByVal value As String)
            _largo = value
            RaiseEvent DatoCambiado()
        End Set
    End Property

    Public Property Ancho() As String
        Get
            Return _ancho
        End Get
        Set(ByVal value As String)
            _ancho = value
            RaiseEvent DatoCambiado()
        End Set
    End Property

    Public Property Diam_maximo() As String
        Get
            Return _diam_maximo
        End Get
        Set(ByVal value As String)
            _diam_maximo = value
            RaiseEvent DatoCambiado()
        End Set
    End Property

    Public Property Diam_min() As String
        Get
            Return _diam_min
        End Get
        Set(ByVal value As String)
            _diam_min = value
            RaiseEvent DatoCambiado()
        End Set
    End Property

    Public Property Peso() As String
        Get
            Return _peso
        End Get
        Set(ByVal value As String)
            _peso = value
            RaiseEvent DatoCambiado()
        End Set
    End Property

    Public Property Estado_integridad() As String
        Get
            Return _estado_integridad
        End Get
        Set(ByVal value As String)
            _estado_integridad = value
            RaiseEvent DatoCambiado()
        End Set
    End Property

    Public Property Cantidad() As Integer
        Get
            Return _cantidad
        End Get
        Set(ByVal value As Integer)
            _cantidad = value
            RaiseEvent DatoCambiado()
        End Set
    End Property

    Public Property Detalle_conservacion() As String
        Get
            Return _detalle_conservacion
        End Get
        Set(ByVal value As String)
            _detalle_conservacion = value
            RaiseEvent DatoCambiado()
        End Set
    End Property

    Public Property Procedencia() As String
        Get
            Return _procedencia
        End Get
        Set(ByVal value As String)
            _procedencia = value
            RaiseEvent DatoCambiado()
        End Set
    End Property

    Public Property Region_origen() As String
        Get
            Return _region_origen
        End Get
        Set(ByVal value As String)
            _region_origen = value
            RaiseEvent DatoCambiado()
        End Set
    End Property

    Public Property Sitio_origen() As String
        Get
            Return _sitio_origen
        End Get
        Set(ByVal value As String)
            _sitio_origen = value
            RaiseEvent DatoCambiado()
        End Set
    End Property

    Public Property Sector_origen() As String
        Get
            Return _sector_origen
        End Get
        Set(ByVal value As String)
            _sector_origen = value
            RaiseEvent DatoCambiado()
        End Set
    End Property

    Public Property Subsector_origen() As String
        Get
            Return _subsector_origen
        End Get
        Set(ByVal value As String)
            _subsector_origen = value
            RaiseEvent DatoCambiado()
        End Set
    End Property

    Public Property Unidad_origen() As String
        Get
            Return _unidad_origen
        End Get
        Set(ByVal value As String)
            _unidad_origen = value
            RaiseEvent DatoCambiado()
        End Set
    End Property

    Public Property Cuadrante_origen() As String
        Get
            Return _cuadrante_origen
        End Get
        Set(ByVal value As String)
            _cuadrante_origen = value
            RaiseEvent DatoCambiado()
        End Set
    End Property

    Public Property Capa_origen() As String
        Get
            Return _capa_origen
        End Get
        Set(ByVal value As String)
            _capa_origen = value
            RaiseEvent DatoCambiado()
        End Set
    End Property

    Public Property Cuadricula_origen() As String
        Get
            Return _cuadricula_origen
        End Get
        Set(ByVal value As String)
            _cuadricula_origen = value
            RaiseEvent DatoCambiado()
        End Set
    End Property

    Public Property Contexto_origen() As String
        Get
            Return _contexto_origen
        End Get
        Set(ByVal value As String)
            _contexto_origen = value
            RaiseEvent DatoCambiado()
        End Set
    End Property

    Public Property Coleccion_propiedad() As String
        Get
            Return _coleccion_propiedad
        End Get
        Set(ByVal value As String)
            _coleccion_propiedad = value
            RaiseEvent DatoCambiado()
        End Set
    End Property

    Public Property Adquisicion_propiedad() As String
        Get
            Return _adquisicion_propiedad
        End Get
        Set(ByVal value As String)
            _adquisicion_propiedad = value
            RaiseEvent DatoCambiado()
        End Set
    End Property

    Public Property Documento_propiedad() As String
        Get
            Return _documento_propiedad
        End Get
        Set(ByVal value As String)
            _documento_propiedad = value
            RaiseEvent DatoCambiado()
        End Set
    End Property

    Public Property Fecha_propiedad() As Date
        Get
            Return _fecha_propiedad
        End Get
        Set(ByVal value As Date)
            _fecha_propiedad = value
            RaiseEvent DatoCambiado()
        End Set
    End Property

    Public Property Ubicacion() As String
        Get
            Return _ubicacion
        End Get
        Set(ByVal value As String)
            _ubicacion = value
            RaiseEvent DatoCambiado()
        End Set
    End Property

    Public Property Area_ubicacion() As String
        Get
            Return _area_ubicacion
        End Get
        Set(ByVal value As String)
            _area_ubicacion = value
            RaiseEvent DatoCambiado()
        End Set
    End Property

    Public Property Especifica_ubicacion() As String
        Get
            Return _especifica_ubicacion
        End Get
        Set(ByVal value As String)
            _especifica_ubicacion = value
            RaiseEvent DatoCambiado()
        End Set
    End Property

    Public Property Nivel_ubicacion() As String
        Get
            Return _nivel_ubicacion
        End Get
        Set(ByVal value As String)
            _nivel_ubicacion = value
            RaiseEvent DatoCambiado()
        End Set
    End Property

    Public Property Caja_ubicacion() As String
        Get
            Return _caja_ubicacion
        End Get
        Set(ByVal value As String)
            _caja_ubicacion = value
            RaiseEvent DatoCambiado()
        End Set
    End Property

    Public Property Bolsa_ubicacion() As String
        Get
            Return _bolsa_ubicacion
        End Get
        Set(ByVal value As String)
            _bolsa_ubicacion = value
            RaiseEvent DatoCambiado()
        End Set
    End Property

    Public Property Excavado_adic() As String
        Get
            Return _excavado_adic
        End Get
        Set(ByVal value As String)
            _excavado_adic = value
            RaiseEvent DatoCambiado()
        End Set
    End Property

    Public Property Registrado_adic() As String
        Get
            Return _registrado_adic
        End Get
        Set(ByVal value As String)
            _registrado_adic = value
            RaiseEvent DatoCambiado()
        End Set
    End Property

    Public Property Fecha_adic() As Date
        Get
            Return _fecha_adic
        End Get
        Set(ByVal value As Date)
            _fecha_adic = value
            RaiseEvent DatoCambiado()
        End Set
    End Property

    Public Property Observacion_adic() As String
        Get
            Return _observacion_adic
        End Get
        Set(ByVal value As String)
            _observacion_adic = value
            RaiseEvent DatoCambiado()
        End Set
    End Property
    'Inicio jaz
    Public Property cod_dgc() As Integer
        Get
            Return _cod_dgc

        End Get
        Set(ByVal value As Integer)
            _cod_dgc = value
            RaiseEvent DatoCambiado()
        End Set
    End Property
    'Fin jaz


#End Region

#Region "Constructor"
    Public Sub New()
        _registro_nacional = String.Empty
        _codigo_propiet = String.Empty
        _otro_codigo = String.Empty
        _categoria = String.Empty
        _taxonomia = String.Empty
        _denominacion = String.Empty
        _cultura = String.Empty
        _periodo = String.Empty
        _descripcion_identificacion = String.Empty
        _tipo_material = String.Empty
        _tecnicas = String.Empty
        _estado_integridad = String.Empty
        _detalle_conservacion = String.Empty
        _procedencia = String.Empty
        _region_origen = String.Empty
        _sitio_origen = String.Empty
        _sector_origen = String.Empty
        _subsector_origen = String.Empty
        _unidad_origen = String.Empty
        _cuadrante_origen = String.Empty
        _capa_origen = String.Empty
        _cuadricula_origen = String.Empty
        _contexto_origen = String.Empty
        _coleccion_propiedad = String.Empty
        _adquisicion_propiedad = String.Empty
        _documento_propiedad = String.Empty
        _ubicacion = String.Empty
        _area_ubicacion = String.Empty
        _especifica_ubicacion = String.Empty
        _nivel_ubicacion = String.Empty
        _caja_ubicacion = String.Empty
        _bolsa_ubicacion = String.Empty
        _excavado_adic = String.Empty
        _registrado_adic = String.Empty
        _observacion_adic = String.Empty
    End Sub

    Public Sub New(
                  ByVal ln_cod_inventario As Integer _
                , ByVal ln_registro_nacional As String _
                , ByVal ln_codigo_propiet As String _
                , ByVal ln_otro_codigo As String _
                , ByVal ln_categoria As String _
                , ByVal ln_taxonomia As String _
                , ByVal ln_denominacion As String _
                , ByVal ln_cultura As String _
                , ByVal ln_periodo As String _
                , ByVal ln_descripcion_identificacion As String _
                , ByVal ln_tipo_material As String _
                , ByVal ln_tecnicas As String _
                , ByVal ln_alto As String _
                , ByVal ln_largo As String _
                , ByVal ln_ancho As String _
                , ByVal ln_diam_maximo As String _
                , ByVal ln_diam_min As String _
                , ByVal ln_peso As String _
                , ByVal ln_estado_integridad As String _
                , ByVal ln_cantidad As Integer _
                , ByVal ln_detalle_conservacion As String _
                , ByVal ln_procedencia As String _
                , ByVal ln_region_origen As String _
                , ByVal ln_sitio_origen As String _
                , ByVal ln_sector_origen As String _
                , ByVal ln_subsector_origen As String _
                , ByVal ln_unidad_origen As String _
                , ByVal ln_cuadrante_origen As String _
                , ByVal ln_capa_origen As String _
                , ByVal ln_cuadricula_origen As String _
                , ByVal ln_contexto_origen As String _
                , ByVal ln_coleccion_propiedad As String _
                , ByVal ln_adquisicion_propiedad As String _
                , ByVal ln_documento_propiedad As String _
                , ByVal ln_fecha_propiedad As Date _
                , ByVal ln_ubicacion As String _
                , ByVal ln_area_ubicacion As String _
                , ByVal ln_especifica_ubicacion As String _
                , ByVal ln_nivel_ubicacion As String _
                , ByVal ln_caja_ubicacion As String _
                , ByVal ln_bolsa_ubicacion As String _
                , ByVal ln_excavado_adic As String _
                , ByVal ln_registrado_adic As String _
                , ByVal ln_fecha_adic As Date _
                , ByVal ln_observacion_adic As String _
                , ByVal ln_cod_dgc As Integer
                  )
        _cod_inventario = ln_cod_inventario
        _registro_nacional = ln_registro_nacional
        _codigo_propiet = ln_codigo_propiet
        _otro_codigo = ln_otro_codigo
        _categoria = ln_categoria
        _taxonomia = ln_taxonomia
        _denominacion = ln_denominacion
        _cultura = ln_cultura
        _periodo = ln_periodo
        _descripcion_identificacion = ln_descripcion_identificacion
        _tipo_material = ln_tipo_material
        _tecnicas = ln_tecnicas
        _alto = ln_alto
        _largo = ln_largo
        _ancho = ln_ancho
        _diam_maximo = ln_diam_maximo
        _diam_min = ln_diam_min
        _peso = ln_peso
        _estado_integridad = ln_estado_integridad
        _cantidad = ln_cantidad
        _detalle_conservacion = ln_detalle_conservacion
        _procedencia = ln_procedencia
        _region_origen = ln_region_origen
        _sitio_origen = ln_sitio_origen
        _sector_origen = ln_sector_origen
        _subsector_origen = ln_subsector_origen
        _unidad_origen = ln_unidad_origen
        _cuadrante_origen = ln_cuadrante_origen
        _capa_origen = ln_capa_origen
        _cuadricula_origen = ln_cuadricula_origen
        _contexto_origen = ln_contexto_origen
        _coleccion_propiedad = ln_coleccion_propiedad
        _adquisicion_propiedad = ln_adquisicion_propiedad
        _documento_propiedad = ln_documento_propiedad
        _fecha_propiedad = ln_fecha_propiedad
        _ubicacion = ln_ubicacion
        _area_ubicacion = ln_area_ubicacion
        _especifica_ubicacion = ln_especifica_ubicacion
        _nivel_ubicacion = ln_nivel_ubicacion
        _caja_ubicacion = ln_caja_ubicacion
        _bolsa_ubicacion = ln_bolsa_ubicacion
        _excavado_adic = ln_excavado_adic
        _registrado_adic = ln_registrado_adic
        _fecha_adic = ln_fecha_adic
        _observacion_adic = ln_observacion_adic
        'Inicio JAZ
        _cod_dgc = ln_cod_dgc
        'Fin JAZ

    End Sub
#End Region
End Class
