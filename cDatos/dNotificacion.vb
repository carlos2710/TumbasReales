Imports cEntidad
Public Class dNotificacion
    Dim SqlHelper As New SqlHelper

    Public Function NotificacionCampusEstudiante(ByVal oNotificacion As eNotificacion) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oNotificacion
                'ds = SqlHelper.ExecuteDataset("NotificacionCampusEstudiante", .tipo, .codigo_notificacionAlu, .codigo_noti, .titulo, .descripcion, .leido, .codigo_per, .codigo_alu)
            End With

            If (ds.Tables.Count > 0) Then
                dt = ds.Tables(0)
            Else
                Return Nothing
            End If

            Return dt
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Function NotificacionLeido(ByVal oNotificacion As eNotificacion) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oNotificacion
                ds = SqlHelper.ExecuteDataset("NotificacionLeido", .codigo_notificacionAlu)
            End With

            If (ds.Tables.Count > 0) Then
                dt = ds.Tables(0)
            Else
                Return Nothing
            End If

            Return dt
        Catch ex As Exception
            Throw
        End Try
    End Function
End Class
