Public Class eInventario
#Region "Propiedad"

    Private _id_inv As Integer
    Private _nro_inv As Integer
    Private _proyecto_inv As String
    Private _temporada_inv As Integer
    Private _sector_inv As String
    Private _subsector_inv As String
    Private _unidad_inv As String
    Private _capa_inv As String
    Private _nivel_inv As String
    Private _cuadricula_inv As Integer
    Private _contexto_inv As String
    Private _plano_inv As Integer
    Private _tipomaterial_inv As Integer
    Private _descripcion_inv As String
    Private _cultura_inv As String
    Private _estilo_inv As String
    Private _otrosdatos_inv As String
    Private _nrocaja_inv As String
    Private _nrobolsa_inv As String
    Private _codpropietario_inv As String
    Private _codexcavacion_inv As String
    Private _ini_rotulacion_inv As String
    Private _fin_rotulacion_inv As String
    Private _cantidad_inv As Integer
    Private _peso_inv As Integer
    Private _fechaalmacen_inv As Date
    Private _registro_inv As String
    Private _almacen_inv As Integer
    Private _estante_inv As Integer
    Private _observacion_inv As String
    Private _fechareg As Date
    Private _usuarioreg As String
    Private _fechamod As Date
    Private _usuariomod As String
    Private _activo_inv As Integer
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

    Public Property id_inv() As Integer
        Get
            Return _id_inv
        End Get
        Set(ByVal value As Integer)
            _id_inv = value
            RaiseEvent DatoCambiado()
        End Set
    End Property

    Public Property nro_inv() As Integer
        Get
            Return _nro_inv
        End Get
        Set(ByVal value As Integer)
            _nro_inv = value
            RaiseEvent DatoCambiado()
        End Set
    End Property

    Public Property proyecto_inv() As String
        Get
            Return _proyecto_inv
        End Get
        Set(ByVal value As String)
            _proyecto_inv = value
            RaiseEvent DatoCambiado()
        End Set
    End Property

    Public Property temporada_inv() As Integer
        Get
            Return _temporada_inv
        End Get
        Set(ByVal value As Integer)
            _temporada_inv = value
            RaiseEvent DatoCambiado()
        End Set
    End Property

    Public Property sector_inv() As String
        Get
            Return _sector_inv
        End Get
        Set(ByVal value As String)
            _sector_inv = value
            RaiseEvent DatoCambiado()
        End Set
    End Property

    Public Property subsector_inv() As String
        Get
            Return _subsector_inv
        End Get
        Set(ByVal value As String)
            _subsector_inv = value
            RaiseEvent DatoCambiado()
        End Set
    End Property

    Public Property unidad_inv() As String
        Get
            Return _unidad_inv
        End Get
        Set(ByVal value As String)
            _unidad_inv = value
            RaiseEvent DatoCambiado()
        End Set
    End Property

    Public Property capa_inv() As String
        Get
            Return _capa_inv
        End Get
        Set(ByVal value As String)
            _capa_inv = value
            RaiseEvent DatoCambiado()
        End Set
    End Property

    Public Property nivel_inv() As String
        Get
            Return _nivel_inv
        End Get
        Set(ByVal value As String)
            _nivel_inv = value
            RaiseEvent DatoCambiado()
        End Set
    End Property

    Public Property cuadricula_inv() As Integer
        Get
            Return _cuadricula_inv
        End Get
        Set(ByVal value As Integer)
            _cuadricula_inv = value
            RaiseEvent DatoCambiado()
        End Set
    End Property

    Public Property contexto_inv() As String
        Get
            Return _contexto_inv
        End Get
        Set(ByVal value As String)
            _contexto_inv = value
            RaiseEvent DatoCambiado()
        End Set
    End Property

    Public Property plano_inv() As Integer
        Get
            Return _plano_inv
        End Get
        Set(ByVal value As Integer)
            _plano_inv = value
            RaiseEvent DatoCambiado()
        End Set
    End Property

    Public Property tipomaterial_inv() As Integer
        Get
            Return _tipomaterial_inv
        End Get
        Set(ByVal value As Integer)
            _tipomaterial_inv = value
            RaiseEvent DatoCambiado()
        End Set
    End Property

    Public Property descripcion_inv() As String
        Get
            Return _descripcion_inv
        End Get
        Set(ByVal value As String)
            _descripcion_inv = value
            RaiseEvent DatoCambiado()
        End Set
    End Property

    Public Property cultura_inv() As String
        Get
            Return _cultura_inv
        End Get
        Set(ByVal value As String)
            _cultura_inv = value
            RaiseEvent DatoCambiado()
        End Set
    End Property

    Public Property estilo_inv() As String
        Get
            Return _estilo_inv
        End Get
        Set(ByVal value As String)
            _estilo_inv = value
            RaiseEvent DatoCambiado()
        End Set
    End Property

    Public Property otrosdatos_inv() As String
        Get
            Return _otrosdatos_inv
        End Get
        Set(ByVal value As String)
            _otrosdatos_inv = value
            RaiseEvent DatoCambiado()
        End Set
    End Property

    Public Property nrocaja_inv() As String
        Get
            Return _nrocaja_inv
        End Get
        Set(ByVal value As String)
            _nrocaja_inv = value
            RaiseEvent DatoCambiado()
        End Set
    End Property

    Public Property nrobolsa_inv() As String
        Get
            Return _nrobolsa_inv
        End Get
        Set(ByVal value As String)
            _nrobolsa_inv = value
            RaiseEvent DatoCambiado()
        End Set
    End Property

    Public Property codpropietario_inv() As String
        Get
            Return _codpropietario_inv
        End Get
        Set(ByVal value As String)
            _codpropietario_inv = value
            RaiseEvent DatoCambiado()
        End Set
    End Property

    Public Property codexcavacion_inv() As String
        Get
            Return _codexcavacion_inv
        End Get
        Set(ByVal value As String)
            _codexcavacion_inv = value
            RaiseEvent DatoCambiado()
        End Set
    End Property

    Public Property ini_rotulacion_inv() As String
        Get
            Return _ini_rotulacion_inv
        End Get
        Set(ByVal value As String)
            _ini_rotulacion_inv = value
            RaiseEvent DatoCambiado()
        End Set
    End Property

    Public Property fin_rotulacion_inv() As String
        Get
            Return _fin_rotulacion_inv
        End Get
        Set(ByVal value As String)
            _fin_rotulacion_inv = value
            RaiseEvent DatoCambiado()
        End Set
    End Property

    Public Property cantidad_inv() As Integer
        Get
            Return _cantidad_inv
        End Get
        Set(ByVal value As Integer)
            _cantidad_inv = value
            RaiseEvent DatoCambiado()
        End Set
    End Property

    Public Property peso_inv() As Integer
        Get
            Return _peso_inv
        End Get
        Set(ByVal value As Integer)
            _peso_inv = value
            RaiseEvent DatoCambiado()
        End Set
    End Property

    Public Property fechaalmacen_inv() As Date
        Get
            Return _fechaalmacen_inv
        End Get
        Set(ByVal value As Date)
            _fechaalmacen_inv = value
            RaiseEvent DatoCambiado()
        End Set
    End Property

    Public Property registro_inv() As String
        Get
            Return _registro_inv
        End Get
        Set(ByVal value As String)
            _registro_inv = value
            RaiseEvent DatoCambiado()
        End Set
    End Property

    Public Property almacen_inv() As Integer
        Get
            Return _almacen_inv
        End Get
        Set(ByVal value As Integer)
            _almacen_inv = value
            RaiseEvent DatoCambiado()
        End Set
    End Property

    Public Property estante_inv() As Integer
        Get
            Return _estante_inv
        End Get
        Set(ByVal value As Integer)
            _estante_inv = value
            RaiseEvent DatoCambiado()
        End Set
    End Property

    Public Property observacion_inv() As String
        Get
            Return _observacion_inv
        End Get
        Set(ByVal value As String)
            _observacion_inv = value
            RaiseEvent DatoCambiado()
        End Set
    End Property

    Public Property fechareg() As Date
        Get
            Return _fechareg
        End Get
        Set(ByVal value As Date)
            _fechareg = value
            RaiseEvent DatoCambiado()
        End Set
    End Property

    Public Property usuarioreg() As String
        Get
            Return _usuarioreg
        End Get
        Set(ByVal value As String)
            _usuarioreg = value
            RaiseEvent DatoCambiado()
        End Set
    End Property

    Public Property fechamod() As Date
        Get
            Return _fechamod
        End Get
        Set(ByVal value As Date)
            _fechamod = value
            RaiseEvent DatoCambiado()
        End Set
    End Property

    Public Property usuariomod() As String
        Get
            Return _usuariomod
        End Get
        Set(ByVal value As String)
            _usuariomod = value
            RaiseEvent DatoCambiado()
        End Set
    End Property

    Public Property activo_inv() As Integer
        Get
            Return _activo_inv
        End Get
        Set(ByVal value As Integer)
            _activo_inv = value
            RaiseEvent DatoCambiado()
        End Set
    End Property

    Public Property id_dgc() As Integer
        Get
            Return _id_dgc
        End Get
        Set(ByVal value As Integer)
            _id_dgc = value
            RaiseEvent DatoCambiado()
        End Set
    End Property
#End Region


#Region "Constructor"
    Public Sub New()



        _proyecto_inv = String.Empty
        _sector_inv = String.Empty
        _subsector_inv = String.Empty
        _unidad_inv = String.Empty
        _capa_inv = String.Empty
        _nivel_inv = String.Empty
        _contexto_inv = String.Empty
        _descripcion_inv = String.Empty
        _cultura_inv = String.Empty
        _estilo_inv = String.Empty
        _otrosdatos_inv = String.Empty
        _nrocaja_inv = String.Empty
        _nrobolsa_inv = String.Empty
        _codpropietario_inv = String.Empty
        _codexcavacion_inv = String.Empty
        _ini_rotulacion_inv = String.Empty
        _fin_rotulacion_inv = String.Empty
        _registro_inv = String.Empty
        _observacion_inv = String.Empty
        _usuarioreg = String.Empty
        _usuariomod = String.Empty
    End Sub

    Public Sub New( _
              ByVal ln_id_inv As Integer _
              , ByVal ln_nro_inv As Integer _
              , ByVal ls_proyecto_inv As String _
              , ByVal ln_temporada_inv As Integer _
              , ByVal ls_sector_inv As String _
              , ByVal ls_subsector_inv As String _
              , ByVal ls_unidad_inv As String _
              , ByVal ls_capa_inv As String _
              , ByVal ls_nivel_inv As String _
              , ByVal ln_cuadricula_inv As Integer _
              , ByVal ls_contexto_inv As String _
              , ByVal ln_plano_inv As Integer _
              , ByVal ln_tipomaterial_inv As Integer _
              , ByVal ls_descripcion_inv As String _
              , ByVal ls_cultura_inv As String _
              , ByVal ls_estilo_inv As String _
              , ByVal ls_otrosdatos_inv As String _
              , ByVal ls_nrocaja_inv As String _
              , ByVal ls_nrobolsa_inv As String _
              , ByVal ls_codpropietario_inv As String _
              , ByVal ls_codexcavacion_inv As String _
              , ByVal ls_ini_rotulacion_inv As String _
              , ByVal ls_fin_rotulacion_inv As String _
              , ByVal ln_cantidad_inv As Integer _
              , ByVal ln_peso_inv As Integer _
              , ByVal ld_fechaalmacen_inv As Date _
              , ByVal ls_registro_inv As String _
              , ByVal ln_almacen_inv As Integer _
              , ByVal ln_estante_inv As Integer _
              , ByVal ls_observacion_inv As String _
              , ByVal ld_fechareg As Date _
              , ByVal ls_usuarioreg As String _
              , ByVal ld_fechamod As Date _
              , ByVal ls_usuariomod As String _
              , ByVal ln_activo_inv As Integer _
              , ByVal ln_id_dgc As Integer _
           )
        _id_inv = ln_id_inv
        _nro_inv = ln_nro_inv
        _proyecto_inv = ls_proyecto_inv
        _temporada_inv = ln_temporada_inv
        _sector_inv = ls_sector_inv
        _subsector_inv = ls_subsector_inv
        _unidad_inv = ls_unidad_inv
        _capa_inv = ls_capa_inv
        _nivel_inv = ls_nivel_inv
        _cuadricula_inv = ln_cuadricula_inv
        _contexto_inv = ls_contexto_inv
        _plano_inv = ln_plano_inv
        _tipomaterial_inv = ln_tipomaterial_inv
        _descripcion_inv = ls_descripcion_inv
        _cultura_inv = ls_cultura_inv
        _estilo_inv = ls_estilo_inv
        _otrosdatos_inv = ls_otrosdatos_inv
        _nrocaja_inv = ls_nrocaja_inv
        _nrobolsa_inv = ls_nrobolsa_inv
        _codpropietario_inv = ls_codpropietario_inv
        _codexcavacion_inv = ls_codexcavacion_inv
        _ini_rotulacion_inv = ls_ini_rotulacion_inv
        _fin_rotulacion_inv = ls_fin_rotulacion_inv
        _cantidad_inv = ln_cantidad_inv
        _peso_inv = ln_peso_inv
        _fechaalmacen_inv = ld_fechaalmacen_inv
        _registro_inv = ls_registro_inv
        _almacen_inv = ln_almacen_inv
        _estante_inv = ln_estante_inv
        _observacion_inv = ls_observacion_inv
        _fechareg = ld_fechareg
        _usuarioreg = ls_usuarioreg
        _fechamod = ld_fechamod
        _usuariomod = ls_usuariomod
        _activo_inv = ln_activo_inv
        _id_dgc = ln_id_dgc
    End Sub

#End Region
End Class
