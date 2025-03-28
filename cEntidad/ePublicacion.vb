Public Class ePublicacion

#Region "Propiedad"

    Private _numero As Integer
    Private _denominacion_pub As String
    Private _codpropietario_pub As String
    Private _codexcavacion_pub As String
    Private _sitio_pub As String
    Private _contexto_pub As String
    Private _presentabio_pub As Integer
    Private _tipobio_pub As Integer
    Private _autores_pub As String
    Private _titulo_pub As String
    Private _anio_pub As Integer
    Private _titulolibro_pub As String
    Private _edicion_pub As String
    Private _paginas_pub As Integer
    Private _nrofigura_pub As Integer
    Private _volumen_pub As Integer
    Private _seccion As String
    Private _fechaconsulta_pub As Date
    Private _direccionelect_pub As String
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

    Public Property numero() As Integer
        Get
            Return _numero
        End Get
        Set(ByVal value As Integer)
            _numero = value

        End Set
    End Property

    Public Property denominacion_pub() As String
        Get
            Return _denominacion_pub
        End Get
        Set(ByVal value As String)
            _denominacion_pub = value

        End Set
    End Property

    Public Property codpropietario_pub() As String
        Get
            Return _codpropietario_pub
        End Get
        Set(ByVal value As String)
            _codpropietario_pub = value

        End Set
    End Property

    Public Property codexcavacion_pub() As String
        Get
            Return _codexcavacion_pub
        End Get
        Set(ByVal value As String)
            _codexcavacion_pub = value

        End Set
    End Property

    Public Property sitio_pub() As String
        Get
            Return _sitio_pub
        End Get
        Set(ByVal value As String)
            _sitio_pub = value

        End Set
    End Property

    Public Property contexto_pub() As String
        Get
            Return _contexto_pub
        End Get
        Set(ByVal value As String)
            _contexto_pub = value

        End Set
    End Property

    Public Property presentabio_pub() As Integer
        Get
            Return _presentabio_pub
        End Get
        Set(ByVal value As Integer)
            _presentabio_pub = value

        End Set
    End Property
    Public Property tipobio_pub() As Integer
        Get
            Return _tipobio_pub
        End Get
        Set(ByVal value As Integer)
            _tipobio_pub = value

        End Set
    End Property
    Public Property autores_pub() As String
        Get
            Return _autores_pub
        End Get
        Set(ByVal value As String)
            _autores_pub = value

        End Set
    End Property
    Public Property titulo_pub() As String
        Get
            Return _titulo_pub
        End Get
        Set(ByVal value As String)
            _titulo_pub = value

        End Set
    End Property

    Public Property anio_pub() As Integer
        Get
            Return _anio_pub
        End Get
        Set(ByVal value As Integer)
            _anio_pub = value

        End Set
    End Property
    Public Property titulolibro_pub() As String
        Get
            Return _titulolibro_pub
        End Get
        Set(ByVal value As String)
            _titulolibro_pub = value

        End Set
    End Property

    Public Property edicion_pub() As String
        Get
            Return _edicion_pub
        End Get
        Set(ByVal value As String)
            _edicion_pub = value

        End Set
    End Property
    Public Property paginas_pub() As Integer
        Get
            Return _paginas_pub
        End Get
        Set(ByVal value As Integer)
            _paginas_pub = value

        End Set
    End Property

    Public Property nrofigura_pub() As Integer
        Get
            Return _nrofigura_pub
        End Get
        Set(ByVal value As Integer)
            _nrofigura_pub = value

        End Set
    End Property
    Public Property volumen_pub() As Integer
        Get
            Return _volumen_pub
        End Get
        Set(ByVal value As Integer)
            _volumen_pub = value

        End Set
    End Property

    Public Property seccion() As String
        Get
            Return _seccion
        End Get
        Set(ByVal value As String)
            _seccion = value

        End Set
    End Property
    Public Property fechaconsulta_pub() As Date
        Get
            Return _fechaconsulta_pub
        End Get
        Set(ByVal value As Date)
            _fechaconsulta_pub = value

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
        _denominacion_pub = String.Empty
        _codpropietario_pub = String.Empty
        _codexcavacion_pub = String.Empty
        _sitio_pub = String.Empty
        _contexto_pub = String.Empty
        _autores_pub = String.Empty
        _titulo_pub = String.Empty
        _titulolibro_pub = String.Empty
        _seccion = String.Empty
        _edicion_pub = String.Empty
    End Sub

    Public Sub New( _
              ByVal ln_numero As Integer _
              , ByVal ls_denominacion_pub As String _
              , ByVal ln_codpropietario_pub As String _
              , ByVal ls_codexcavacion_pub As String _
              , ByVal ls_sitio_pub As String _
              , ByVal ls_contexto_pub As String _
              , ByVal ln_presentabio_pub As Integer _
              , ByVal ln_tipobio_pub As Integer _
              , ByVal ls_autores_pub As String _
              , ByVal ls_titulo_pub As String _
              , ByVal ln_anio_pub As Integer _
              , ByVal ls_titulolibro_pub As String _
              , ByVal ln_edicion_pub As String _
              , ByVal ln_paginas_pub As Integer _
              , ByVal ln_nrofigura_pub As Integer _
              , ByVal ln_volumen_pub As Integer _
              , ByVal ls_seccion As String _
              , ByVal ld_fechaconsulta_pub As Date _
              , ByVal ls_direccionelect_pub As String _
              , ByVal ld_fechareg As Date _
              , ByVal ls_usuarioreg As String _
              , ByVal ld_fechamod As Date _
              , ByVal ls_usuariomod As String _
              , ByVal ln_activo As Integer _
           )
        _numero = ln_numero
        _denominacion_pub = ls_denominacion_pub
        _codpropietario_pub = ln_codpropietario_pub
        _codexcavacion_pub = ls_codexcavacion_pub
        _sitio_pub = ls_sitio_pub
        _contexto_pub = ls_contexto_pub
        _presentabio_pub = ln_presentabio_pub
        _tipobio_pub = ln_tipobio_pub
        _autores_pub = ls_autores_pub
        _titulo_pub = ls_titulo_pub
        _anio_pub = ln_anio_pub
        _titulolibro_pub = ls_titulolibro_pub
        _edicion_pub = ln_edicion_pub
        _paginas_pub = ln_paginas_pub
        _nrofigura_pub = ln_nrofigura_pub
        _volumen_pub = ln_volumen_pub
        _seccion = ls_seccion
        _fechaconsulta_pub = ld_fechaconsulta_pub
        _direccionelect_pub = ls_direccionelect_pub
        _fechareg = ld_fechareg
        _usuarioreg = ls_usuarioreg
        _fechamod = ld_fechamod
        _usuariomod = ls_usuariomod
        _activo = ln_activo
    End Sub

#End Region

End Class
