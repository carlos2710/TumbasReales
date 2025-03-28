Public Class eColeccion
#Region "Declaracion de variables"

    Private _codigo_mEst As Integer
    Private _descripcion_Men As String


    Public _param1 As String
    Public _param2 As String
    Public _param3 As String

#End Region

#Region "Propiedades"
    Public Property codigo_mEst() As Integer
        Get
            Return _codigo_mEst
        End Get
        Set(ByVal value As Integer)
            _codigo_mEst = value
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
#End Region


End Class
