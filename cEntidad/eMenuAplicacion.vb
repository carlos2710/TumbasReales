
Public Class eMenuAplicacion

#Region "Declaracion de variables"

    Private _codigo_Men As Integer
    Private _descripcion_Men As String
    Private _enlace_Men As String
    Private _codigo_Apl As Integer
    Private _codigoRaiz_Men As Integer
    Private _icono_Men As String
    Private _iconosel_men As String
    Private _expandible_men As String
    Private _nivel_men As String
    Private _orden_men As Integer
    Private _variable_men As String
    Private _formulario_men As String
    Private _codigo_Tfu As Integer
    Private _target As String

    Private _link As String


    Private _accesoAlumnoInactivo As String





    Public tipoOperacion As String
    Public param1 As String
    Public param2 As String
    Public param3 As String
#End Region
#Region "Propiedades"
    Public Property codigo_Men() As Integer
        Get
            Return _codigo_Men
        End Get
        Set(ByVal value As Integer)
            _codigo_Men = value
        End Set
    End Property
    Public Property descripcion_Men() As String
        Get
            Return _descripcion_Men
        End Get
        Set(ByVal value As String)
            _descripcion_Men = value
        End Set
    End Property
    Public Property enlace_men() As String
        Get
            Return _enlace_Men
        End Get
        Set(ByVal value As String)
            _enlace_Men = value
        End Set
    End Property
    Public Property codigo_Apl() As Integer
        Get
            Return _codigo_Apl
        End Get
        Set(ByVal value As Integer)
            _codigo_Apl = value
        End Set
    End Property
    Public Property codigoRaiz_Men() As Integer
        Get
            Return _codigoRaiz_Men
        End Get
        Set(ByVal value As Integer)
            _codigoRaiz_Men = value
        End Set
    End Property
    Public Property icono_Men() As String
        Get
            Return _icono_Men
        End Get
        Set(ByVal value As String)
            _icono_Men = value
        End Set
    End Property
    Public Property iconosel_men() As String
        Get
            Return _iconosel_men
        End Get
        Set(ByVal value As String)
            _iconosel_men = value
        End Set
    End Property
    Public Property expandible_men() As String
        Get
            Return _expandible_men
        End Get
        Set(ByVal value As String)
            _expandible_men = value
        End Set
    End Property
    Public Property nivel_men() As String
        Get
            Return _nivel_men
        End Get
        Set(ByVal value As String)
            _nivel_men = value
        End Set
    End Property
    Public Property orden_men() As Integer
        Get
            Return _orden_men
        End Get
        Set(ByVal value As Integer)
            _orden_men = value
        End Set
    End Property
    Public Property variable_men() As String
        Get
            Return _variable_men
        End Get
        Set(ByVal value As String)
            _variable_men = value
        End Set
    End Property
    Public Property formulario_men() As String
        Get
            Return _formulario_men
        End Get
        Set(ByVal value As String)
            _formulario_men = value
        End Set
    End Property
    Public Property codigo_Tfu() As Integer
        Get
            Return _codigo_Tfu
        End Get
        Set(ByVal value As Integer)
            _codigo_Tfu = value
        End Set
    End Property

    Public Property target() As String
        Get
            Return _target
        End Get
        Set(ByVal value As String)
            _target = value
        End Set
    End Property

    Public Property link() As String
        Get
            Return _link
        End Get
        Set(ByVal value As String)
            _link = value
        End Set
    End Property

    Public Property accesoAlumnoInactivo() As String
        Get
            Return _accesoAlumnoInactivo
        End Get
        Set(ByVal value As String)
            _accesoAlumnoInactivo = value
        End Set
    End Property

#End Region
#Region "Constructor"

    Public Sub New()
        _enlace_Men = String.Empty
        _icono_Men = String.Empty
        _iconosel_men = String.Empty
        _expandible_men = String.Empty
        _nivel_men = String.Empty
        _variable_men = String.Empty
        _formulario_men = String.Empty
        _target = String.Empty
        _link = String.Empty
        _accesoAlumnoInactivo = String.Empty
    End Sub

    Public Sub New(ByVal codigo_Men As Integer, _
        ByVal descripcion_Men As String, _
        ByVal enlace_Men As String, _
        ByVal codigo_Apl As Integer, _
        ByVal codigoRaiz_Men As Integer, _
        ByVal icono_Men As String, _
        ByVal iconosel_men As String, _
        ByVal expandible_men As String, _
        ByVal nivel_men As String, _
        ByVal orden_men As Integer, _
        ByVal variable_men As String, _
        ByVal formulario_men As String, _
        ByVal codigo_Tfu As Integer, _
        ByVal target As String, _
        ByVal link As String, _
        ByVal accesoAlumnoInactivo As String)

        _codigo_Men = codigo_Men
        _descripcion_Men = descripcion_Men
        _enlace_Men = enlace_Men
        _codigo_Apl = codigo_Apl
        _codigoRaiz_Men = codigoRaiz_Men
        _icono_Men = icono_Men
        _iconosel_men = iconosel_men
        _expandible_men = expandible_men
        _nivel_men = nivel_men
        _orden_men = orden_men
        _variable_men = variable_men
        _formulario_men = formulario_men
        _codigo_Tfu = codigo_Tfu
        _target = target
        _link = link
        _accesoAlumnoInactivo = accesoAlumnoInactivo
    End Sub
#End Region

End Class
