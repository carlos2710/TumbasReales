Imports System.Security.Cryptography.X509Certificates

Public Class eArchivoCompartido
#Region "Propiedad"
    Private _IdArchivosCompartidos As Integer
    Private _NombreArchivo As String
    Private _Fecha As Date
    Private _Extencion As String
    Private _IdTabla As Integer
    Private _IdTransaccion As String
    Private _NroOperacion As String
    Private _Descripcion As String
    Private _RutaArchivo As String
    Private _FechaReg As Date
    Private _FechaAct As Date
    Private _UsuarioReg As String
    Private _UsuarioAct As String
    Private _IpReg As String
    Private _IpAct As String

    Public _param1 As String
    Public _param2 As String
    Public _param3 As String

    Private ReadOnly ln_ArchivosCompartidos As Integer
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

    Public Property IdArchivosCompartidos() As Integer
        Get
            Return _IdArchivosCompartidos

        End Get
        Set(ByVal value As Integer)
            _IdArchivosCompartidos = value
            RaiseEvent DatoCambiado()
        End Set
    End Property

    Public Property NombreArchivo() As String
        Get
            Return _NombreArchivo

        End Get
        Set(ByVal value As String)
            _NombreArchivo = value
            RaiseEvent DatoCambiado()
        End Set
    End Property

    Public Property Fecha() As Date
        Get
            Return _Fecha

        End Get
        Set(ByVal value As Date)
            _Fecha = value
            RaiseEvent DatoCambiado()
        End Set
    End Property

    Public Property Extencion() As String
        Get
            Return _Extencion
        End Get
        Set(ByVal value As String)
            _Extencion = value
            RaiseEvent DatoCambiado()
        End Set
    End Property

    Public Property IdTabla() As Integer
        Get
            Return _IdTabla
        End Get
        Set(ByVal value As Integer)
            _IdTabla = value
            RaiseEvent DatoCambiado()
        End Set
    End Property

    Public Property IdTransaccion() As String
        Get
            Return _IdTransaccion
        End Get
        Set(ByVal value As String)
            _IdTransaccion = value
            RaiseEvent DatoCambiado()
        End Set
    End Property

    Public Property NroOperacion() As String
        Get
            Return _NroOperacion
        End Get
        Set(ByVal value As String)
            _NroOperacion = value
            RaiseEvent DatoCambiado()
        End Set
    End Property

    Public Property Descripcion() As String
        Get
            Return _Descripcion
        End Get
        Set(ByVal value As String)
            _Descripcion = value
            RaiseEvent DatoCambiado()
        End Set
    End Property

    Public Property RutaArchivo() As String
        Get
            Return _RutaArchivo
        End Get
        Set(ByVal value As String)
            _RutaArchivo = value
            RaiseEvent DatoCambiado()
        End Set
    End Property

    Public Property FechaReg() As Date
        Get
            Return _FechaReg
        End Get
        Set(ByVal value As Date)
            _FechaReg = value
            RaiseEvent DatoCambiado()
        End Set
    End Property

    Public Property FechaAct() As Date
        Get
            Return _FechaAct
        End Get
        Set(ByVal value As Date)
            _FechaAct = value
            RaiseEvent DatoCambiado()
        End Set
    End Property

    Public Property UsuarioReg() As String
        Get
            Return _UsuarioReg
        End Get
        Set(ByVal value As String)
            _UsuarioReg = value
            RaiseEvent DatoCambiado()
        End Set
    End Property

    Public Property UsuarioAct() As String
        Get
            Return _UsuarioAct
        End Get
        Set(ByVal value As String)
            _UsuarioAct = value
            RaiseEvent DatoCambiado()
        End Set
    End Property

    Public Property IpReg() As String
        Get
            Return _IpReg
        End Get
        Set(ByVal value As String)
            _IpReg = value
            RaiseEvent DatoCambiado()
        End Set
    End Property

    Public Property IpAct() As String
        Get
            Return _IpAct
        End Get
        Set(ByVal value As String)
            _IpAct = value
            RaiseEvent DatoCambiado()
        End Set
    End Property

#End Region

#Region "Constructor"
    Public Sub New()
        _NombreArchivo = String.Empty
        _Extencion = String.Empty
        _IdTransaccion = String.Empty
        _NroOperacion = String.Empty
        _Descripcion = String.Empty
        _RutaArchivo = String.Empty
        _UsuarioReg = String.Empty
        _UsuarioAct = String.Empty
        _IpReg = String.Empty
        _IpAct = String.Empty
    End Sub

    Public Sub New(
                    ByVal ln_IdArchivosCompartidos As Integer _
                  , ByVal ln_NombreArchivo As String _
                  , ByVal ln_Fecha As Date _
                  , ByVal ln_Extencion As String _
                  , ByVal ln_IdTabla As Integer _
                  , ByVal ln_IdTransaccion As String _
                  , ByVal ln_NroOperacion As String _
                  , ByVal ln_Descripcion As String _
                  , ByVal ln_RutaArchivo As String _
                  , ByVal ln_FechaReg As Date _
                  , ByVal ln_FechaAct As Date _
                  , ByVal ln_UsuarioReg As String _
                  , ByVal ln_UsuarioAct As String _
                  , ByVal ln_IpReg As String _
                  , ByVal ln_IpAct As String
                  )
        _IdArchivosCompartidos = ln_IdArchivosCompartidos
        _NombreArchivo = ln_NombreArchivo
        _Fecha = ln_Fecha
        _Extencion = ln_Extencion
        _IdTabla = ln_IdTabla
        _IdTransaccion = ln_IdTransaccion
        _NroOperacion = ln_NroOperacion
        _Descripcion = ln_Descripcion
        _RutaArchivo = ln_RutaArchivo
        _FechaReg = ln_FechaReg
        _FechaAct = ln_FechaAct
        _UsuarioReg = ln_UsuarioReg
        _UsuarioAct = ln_UsuarioAct
        _IpReg = ln_IpReg
        _IpAct = ln_IpAct
    End Sub

#End Region
End Class
