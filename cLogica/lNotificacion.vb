Imports cDatos
Imports cEntidad

Public Class lNotificacion
    Private odNotificacion As New dNotificacion

    Public Function NotificacionCampusEstudiante(ByVal oNotificacion As eNotificacion) As DataTable
        Try

            Return odNotificacion.NotificacionCampusEstudiante(oNotificacion)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function NotificacionLeido(ByVal oNotificacion As eNotificacion) As DataTable
        Try

            Return odNotificacion.NotificacionLeido(oNotificacion)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
