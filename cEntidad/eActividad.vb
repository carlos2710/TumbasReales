Public Class eActividad

#Region "Declaracion de variables"

    Private _codigo_Act As Integer
    Private _descripcion_Act As String
    Private _identificador_Act As String

#End Region

#Region "Propiedades"

    Public Property codigo_Act() As Integer
        Get
            Return _codigo_Act
        End Get
        Set(ByVal value As Integer)
            _codigo_Act = value
        End Set
    End Property

    Public Property descripcion_Act() As String
        Get
            Return _descripcion_Act
        End Get
        Set(ByVal value As String)
            _descripcion_Act = value
        End Set
    End Property

    Public Property identificador_Act() As String
        Get
            Return _identificador_Act
        End Get
        Set(ByVal value As String)
            _identificador_Act = value
        End Set
    End Property

#End Region

End Class
