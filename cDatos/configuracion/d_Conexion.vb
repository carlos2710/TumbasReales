
Imports System.Configuration
Imports System.Data.SqlClient

''' <summary>
''' Clase para administrar las cadenas de conexión al SGI
''' </summary>
''' <remarks>Esta clase se utiliza junto al sql helper,Capa del Sistema:Capa de Datos</remarks>
Public Class d_Conexion

    Public Sub New()

    End Sub

    ''' <summary>
    ''' Cadena de conexión de la base de datos de la empresa ISL
    ''' </summary>
    ''' <returns>Devuelve un cadena</returns>
    ''' <remarks></remarks>
    Public Function CadenaConexion() As String
        Try
            Dim str As String
            'str = "Data Source=.; Initial Catalog=TUMBASREALES; Integrated Security=false; uid=utumbas; password=123456"
            str = "Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=TUMBASREALES; Integrated Security=false; uid=sa; password=123456"
            Return str
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class


