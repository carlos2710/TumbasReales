Public Class eNotificacion

    Private _codigo_notificacionAlu As Integer
    Private _codigo_noti As Integer
    Private _titulo As String
    Private _descripcion As String
    Private _leido As Integer
    Private _codigo_per As Integer
    Private _codigo_alu As Integer
    Public tipo As String

    Public Property codigo_alu() As Integer
        Get
            Return _codigo_alu
        End Get
        Set(ByVal value As Integer)
            _codigo_alu = value
        End Set
    End Property

    Public Property codigo_per() As Integer
        Get
            Return _codigo_per
        End Get
        Set(ByVal value As Integer)
            _codigo_per = value
        End Set
    End Property


    Public Property leido() As Integer
        Get
            Return _leido
        End Get
        Set(ByVal value As Integer)
            _leido = value
        End Set
    End Property



    Public Property descripcion() As String
        Get
            Return _descripcion
        End Get
        Set(ByVal value As String)
            _descripcion = value
        End Set
    End Property



    Public Property titulo() As String
        Get
            Return _titulo
        End Get
        Set(ByVal value As String)
            _titulo = value
        End Set
    End Property


    Public Property codigo_noti() As Integer
        Get
            Return _codigo_noti
        End Get
        Set(ByVal value As Integer)
            _codigo_noti = value
        End Set
    End Property

    Public Property codigo_notificacionAlu() As Integer
        Get
            Return _codigo_notificacionAlu
        End Get
        Set(ByVal value As Integer)
            _codigo_notificacionAlu = value
        End Set
    End Property


End Class
