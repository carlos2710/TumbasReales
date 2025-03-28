Imports cEntidad
Imports System.Transactions
Imports System.Data.SqlClient
Imports System.Data
Public Class dAlumno
    Dim SqlHelper As New SqlHelper

    Public Function RecuperarClave_persona(ByVal oeAlumno As eAlumno) As DataTable
        Dim ds As DataSet
        Dim dt As DataTable
        Try
            With oeAlumno
                ds = SqlHelper.ExecuteDataset("ConsultarPersona", "PER", .nroDocIdent_Alu)
                If ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
                    dt = ds.Tables(0)
                Else
                    dt = Nothing
                End If

                Return dt
            End With
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function ActualizarArchivoCompartivo(ByVal oeAlumno As eAlumno) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oeAlumno
                ds = SqlHelper.ExecuteDataset("INV_ActualizarIDArchivoCompartido", .param1, .param2, .param3)
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
    Public Function ListarArchivosCompartidos(ByVal oeAlumno As eAlumno) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oeAlumno
                ds = SqlHelper.ExecuteDataset("USP_LISTARARCHIVOSCOMPARTIDOS", .param1, .param2, .param3)
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
    Public Function infoDeudaAlumno(ByVal oeAlumno As eAlumno) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oeAlumno
                ds = SqlHelper.ExecuteDataset("ConsultarMovimientosAlumnoDeuda", .codigoUniver_Alu, .param1)
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
    '#002 FIN - JR
    'CONCURSOS
    Public Function actualizarEquipoEstudiante(ByVal oeAlumno As eAlumno) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oeAlumno
                ds = SqlHelper.ExecuteDataset("INV_ActualizarEquipoPostulacion", .codigo_Pso, .codigo_Pai, .codigo_Alu, .param1, .param2, .codigo_Alu)
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
    Public Function listarObjetivosPostulacion(ByVal oeAlumno As eAlumno) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oeAlumno
                ds = SqlHelper.ExecuteDataset("INV_ListarObjetivosPostulacion", .param1)
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
    Public Function ListaPostulacionesXConcurso(ByVal oeAlumno As eAlumno) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oeAlumno
                ds = SqlHelper.ExecuteDataset("INV_listarPostulacionesEstudiantes", .param1, .codigo_Alu)
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
    Public Function listaDocentes(ByVal oeAlumno As eAlumno) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oeAlumno
                ds = SqlHelper.ExecuteDataset("DocentesListar")
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
    Public Function actualizarRutaArchivo(ByVal oeAlumno As eAlumno) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oeAlumno
                ds = SqlHelper.ExecuteDataset("INV_ActualizarArchivosPostulacion", .codigo_test, .param2, .param3)
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
    Public Function registrarObjetivosPostulacion(ByVal oeAlumno As eAlumno) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oeAlumno
                ds = SqlHelper.ExecuteDataset("INV_RegistrarObjetivoPostulacionEstudiante", .codigo_test, .param2, .param3, .codigo_Alu)
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
    Public Function registrarPostulacionEstudiante(ByVal oeAlumno As eAlumno) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oeAlumno
                ds = SqlHelper.ExecuteDataset("INV_ActualizarPostulacion", 0, .codigo_test, 0, 0, .codigo_Alu, .param2, .codigo_Pso, 0, 0, 0, 0, " ", .param3, .param1, .condicion_Alu, .fechaServidor, .fechaServidor2, .codigo_Alu, 0)

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
    Public Function DatosAlumnoCarFacInvestigacion(ByVal oeAlumno As eAlumno) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oeAlumno
                ds = SqlHelper.ExecuteDataset("INV_extrarFacultaAlumno", .codigo_Alu)
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
    Public Function DatosAlumnoInvestigacion(ByVal oeAlumno As eAlumno) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oeAlumno
                ds = SqlHelper.ExecuteDataset("ConsultarAlumno", .param2, .codigo_Alu)
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
    Public Function ListarRegiones(ByVal oeAlumno As eAlumno) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oeAlumno
                ds = SqlHelper.ExecuteDataset("INV_listarDepartamentos")
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
    Public Function consultarLineas(ByVal oeAlumno As eAlumno) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oeAlumno
                ds = SqlHelper.ExecuteDataset("INV_ListaLineasInvestigacion", .param1)
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
    Public Function ListarConcursos(ByVal oeAlumno As eAlumno) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oeAlumno
                ds = SqlHelper.ExecuteDataset("INV_ListarConcursoEstudiante", .param2, .param1)
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

    ' FIN CONCURSOS

    Public Function ActualizarInfoAcadEgresadoGyT(ByVal oeAlumno As eAlumno) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oeAlumno
                ds = SqlHelper.ExecuteDataset("ALUMNI_ActualizarFormacionAcademica_ge", .param3, .codigo_Alu, .anioi_egre, .anioe_egre, .fechaacto_egre, .gradoobt_egre, .instituto_egre, "", .procedencia_egre, .situacion_egre, .param1, "", .param2)
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
    Public Function RegistrarInfoAcadEgresadoGyT(ByVal oeAlumno As eAlumno) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oeAlumno
                ds = SqlHelper.ExecuteDataset("ALUMNI_RegistrarFormacionAcademica_ge", .codigo_Alu, .anioi_egre, .anioe_egre, .fechaacto_egre, .gradoobt_egre, .instituto_egre, "", .procedencia_egre, .situacion_egre, .param1, "", .param2)

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
    Public Function listadoUniGrado(ByVal oeAlumno As eAlumno) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oeAlumno
                ds = SqlHelper.ExecuteDataset("ALUMNI_ListarUniversidad_v2")
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
    Public Function HistorialOfertaLaboral(ByVal oeAlumno As eAlumno) As DataTable
        Dim dt As New DataTable '#001 INICIO - JR
        Dim ds As New DataSet
        Try
            With oeAlumno
                ds = SqlHelper.ExecuteDataset("Alumni_RegistrarEgresadoEnviaCV", .codigo_Alu, .param1)
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
    Public Function ActualizaFotoEgresado(ByVal oeAlumno As eAlumno) As DataTable
        Dim dt As New DataTable '#001 INICIO - JR
        Dim ds As New DataSet
        Try
            With oeAlumno
                ds = SqlHelper.ExecuteDataset("ALUMNI_ActualizaDatosEgre", .codigo_Alu, .param1, "", "", "", "", "", "", .foto_Alu)
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
    Public Function ExisteArchivoEgresado(ByVal oeAlumno As eAlumno) As DataTable
        Dim dt As New DataTable '#001 INICIO - JR
        Dim ds As New DataSet
        Try
            With oeAlumno
                ds = SqlHelper.ExecuteDataset("ALUMNI_ExisteArchivoPreEgresado_v2", .foto_Alu)
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
    Public Function CambioClaveEgresado(ByVal oeAlumno As eAlumno) As String
        Dim strMensaje As String = "" '#001 INICIO - JR
        Try
            With oeAlumno
                strMensaje = SqlHelper.ExecuteScalar("CV_CambiarClaveEgresado", .codigo_Alu, .password_Alu, .nuevaClave)
                Return strMensaje
            End With
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Public Function ConsultarAnuncios(ByVal oeAlumno As eAlumno) As DataTable
        Dim dt As New DataTable '#001 INICIO - JR
        Dim ds As New DataSet
        Try
            With oeAlumno
                ds = SqlHelper.ExecuteDataset("ALUMNI_ConsultarTipoAnuncio", .param1)
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
    Public Function InsertaDJEgresado(ByVal oeAlumno As eAlumno) As DataTable
        Dim dt As New DataTable '#001 INICIO - JR
        Dim ds As New DataSet
        Try
            With oeAlumno
                ds = SqlHelper.ExecuteDataset("ALUMNI_InsertaBitacoraUpdateDatos", .codigo_Pso, .param1)
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
    Public Function consultarDeclaracionJurada(ByVal oeAlumno As eAlumno) As DataTable
        Dim dt As New DataTable '#001 INICIO - JR
        Dim ds As New DataSet
        Try
            With oeAlumno
                ds = SqlHelper.ExecuteDataset("Alumni_AceptoDeclaracionJurada", .codigo_Pso, .param1)
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
    Public Function DatosOfertaPostular(ByVal oeAlumno As eAlumno) As DataTable
        Dim dt As New DataTable '#001 INICIO - JR
        Dim ds As New DataSet
        Try
            With oeAlumno
                ds = SqlHelper.ExecuteDataset("ALUMNI_CargarDatosPostular", .codigo_Alu, .param1)
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
    Public Function ActualizarNivelHojaVida(ByVal oeAlumno As eAlumno) As DataTable
        Dim dt As New DataTable '#001 INICIO - JR
        Dim ds As New DataSet
        Try
            With oeAlumno
                ds = SqlHelper.ExecuteDataset("ALUMNI_ActualizarNivelHojaVida", .codigo_Pso, .param1, .param2, .param3)
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
    Public Function ConsultarNivelHojaVida(ByVal oeAlumno As eAlumno) As DataTable
        Dim dt As New DataTable '#001 INICIO - JR
        Dim ds As New DataSet
        Try
            With oeAlumno
                ds = SqlHelper.ExecuteDataset("ALUMNI_ConsultarNivelHojaVida", .param1, .param2)
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
    Public Function registrarNivelHojaVida(ByVal oeAlumno As eAlumno) As DataTable
        Dim dt As New DataTable '#001 INICIO - JR
        Dim ds As New DataSet
        Try
            With oeAlumno
                ds = SqlHelper.ExecuteDataset("ALUMNI_RegistrarNivelHojaVida", .codigo_Pso, .param1)
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
    Public Function consultarDatosReferenciaLaboral(ByVal oeAlumno As eAlumno) As DataTable
        Dim dt As New DataTable '#001 INICIO - JR
        Dim ds As New DataSet
        Try
            With oeAlumno
                ds = SqlHelper.ExecuteDataset("ALUMNI_ConsultarDatosEgresadoLaboral", .codigo_Pso)
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
    Public Function confirmaExperienciaLaboral(ByVal oeAlumno As eAlumno) As DataTable
        Dim dt As New DataTable '#001 INICIO - JR
        Dim ds As New DataSet
        Try
            With oeAlumno
                ds = SqlHelper.ExecuteDataset("ALUMNI_ConfirmaReferenciaLaboral", .param1, .param2)
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
    Public Function EliminarRefLabEgresado(ByVal oeAlumno As eAlumno) As DataTable
        Dim dt As New DataTable '#001 INICIO - JR
        Dim ds As New DataSet
        Try
            With oeAlumno
                ds = SqlHelper.ExecuteDataset("ALUMNI_EliminarReferenciaLabEgresado", .param1)
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
    Public Function actualizaRefLaboralEgresado(ByVal oeAlumno As eAlumno) As DataTable
        Dim dt As New DataTable '#001 INICIO - JR
        Dim ds As New DataSet
        Try
            With oeAlumno
                ds = SqlHelper.ExecuteDataset("ALUMNI_ActualizarReferenciaLaboral", .egresado_Alu, .codigo_Alu, .apellidoPat_Alu, .apellidoMat_Alu, .nombres_Alu, .email_Alu, .telefonomovil_alu, .param1, .param2, .cargo_egre, .param3)
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
    Public Function addRefLaboralEgresado(ByVal oeAlumno As eAlumno) As DataTable
        Dim dt As New DataTable '#001 INICIO - JR
        Dim ds As New DataSet
        Try
            With oeAlumno
                ds = SqlHelper.ExecuteDataset("ALUMNI_RegistrarReferenciaLaboralEgresado", .codigo_Alu, .apellidoPat_Alu, .apellidoMat_Alu, .nombres_Alu, .email_Alu, .telefonomovil_alu, .param1, .param2, .cargo_egre)
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
    Public Function listadoRefLabEgresado(ByVal oeAlumno As eAlumno) As DataTable
        Dim dt As New DataTable '#001 INICIO - JR
        Dim ds As New DataSet
        Try
            With oeAlumno
                ds = SqlHelper.ExecuteDataset("ALUMNI_ConsultarAlumni_ReferenciaLaboral", .codigo_Alu)
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
    Public Function ActualizaObjLabEgresado(ByVal oeAlumno As eAlumno) As DataTable
        Dim dt As New DataTable '#001 INICIO - JR
        Dim ds As New DataSet
        Try
            With oeAlumno
                ds = SqlHelper.ExecuteDataset("ALUMNI_ActualizaFuturoEmpleo", .codigo_Alu, .param2, .cargo_egre, .contrato_egre, .area_egre, .codigo_Dep, .sector_egre, .param1)
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
    Public Function objetivoLaboralEgresado(ByVal oeAlumno As eAlumno) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oeAlumno
                ds = SqlHelper.ExecuteDataset("ALUMNI_BuscaDatosEgresado", .codigo_Pso, .param2)
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
    Public Function listadoObjLaboral(ByVal oeAlumno As eAlumno) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oeAlumno
                ds = SqlHelper.ExecuteDataset("ALUMNI_BUSCARDATOSFE", .param1, .param2)
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
    Public Function ActualizaIdiomaEgresado(ByVal oeAlumno As eAlumno) As DataTable
        Dim dt As New DataTable '#001 INICIO - JR
        Dim ds As New DataSet
        Try
            With oeAlumno
                ds = SqlHelper.ExecuteDataset("ALUMNI_ActualizarFormacionAcademica", .param3, .codigo_Alu, .anioi_egre, .anioe_egre, .fechaacto_egre, .gradoobt_egre, .instituto_egre, .tipoinst_egre, .procedencia_egre, .situacion_egre, .param1, .param2)

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
    Public Function ActualizarInfoAcadEgresado(ByVal oeAlumno As eAlumno) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oeAlumno
                ds = SqlHelper.ExecuteDataset("ALUMNI_ActualizarFormacionAcademica", .param3, .codigo_Alu, .anioi_egre, .anioe_egre, .fechaacto_egre, .gradoobt_egre, .instituto_egre, "", .procedencia_egre, .situacion_egre, .param1, "")
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
    Public Function actualizaExpLaboralEgresado(ByVal oeAlumno As eAlumno) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oeAlumno
                ds = SqlHelper.ExecuteDataset("ALUMNI_ActualizarExperienciaLaboral", .param3, .codigo_Alu, .anioi_egre, .anioe_egre, .situacion_egre, .param1, .codigo_Dis, .logros_egre, .sector_egre, .area_egre, .cargo_egre, .contrato_egre, .param2, .codigo_Pai)
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
    Public Function listadoTipoInstitucion(ByVal oeAlumno As eAlumno) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oeAlumno
                ds = SqlHelper.ExecuteDataset("ALUMNI_ConsultarDatosidioma", .param1)
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
    Public Function listadoUni(ByVal oeAlumno As eAlumno) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oeAlumno
                ds = SqlHelper.ExecuteDataset("ALUMNI_ListarUniversidad")
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
    Public Function listadoCargo(ByVal oeAlumno As eAlumno) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oeAlumno
                ds = SqlHelper.ExecuteDataset("ALUMNI_ListarCargo")
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
    Public Function listadoTipoContrato(ByVal oeAlumno As eAlumno) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oeAlumno
                ds = SqlHelper.ExecuteDataset("ALUMNI_ListarTipoContrato")
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
    Public Function listadoCiudades(ByVal oeAlumno As eAlumno) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oeAlumno
                ds = SqlHelper.ExecuteDataset("ALUMNI_ListarCiudades", .param1)
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
    Public Function listadoSector(ByVal oeAlumno As eAlumno) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oeAlumno
                ds = SqlHelper.ExecuteDataset("ALUMNI_ListarSector", .param1, .param2, .param3)

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
    Public Function listadoEmpresas(ByVal oeAlumno As eAlumno) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oeAlumno
                ds = SqlHelper.ExecuteDataset("ALUMNI_ListarEmpresas", "%")

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
    Public Function IdiomaEgresado(ByVal oeAlumno As eAlumno) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oeAlumno
                ds = SqlHelper.ExecuteDataset("ALUMNI_RegistrarFormacionAcademica", .codigo_Alu, .anioi_egre, .anioe_egre, .fechaacto_egre, .gradoobt_egre, .instituto_egre, .tipoinst_egre, .procedencia_egre, .situacion_egre, .param1, .param2)

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
    Public Function eliminaIdiomaEgresado(ByVal oeAlumno As eAlumno) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oeAlumno
                ds = SqlHelper.ExecuteDataset("ALUMNI_EliminarFormacion", .param1)

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
    Public Function ExperienciaLaboralEgresado(ByVal oeAlumno As eAlumno) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oeAlumno
                ds = SqlHelper.ExecuteDataset("ALUMNI_RegistrarExperienciaLaboral", .codigo_Alu, .anioi_egre, .anioe_egre, .situacion_egre, .param1, .codigo_Dis, .logros_egre, .sector_egre, .area_egre, .cargo_egre, .contrato_egre, .param2, .codigo_Pai)

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
    Public Function ListarDistrito(ByVal oeAlumno As eAlumno) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oeAlumno
                ds = SqlHelper.ExecuteDataset("ALUMNI_ListarCiudades", .nombre_Dis)
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
    Public Function RegistrarSector(ByVal oeAlumno As eAlumno) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oeAlumno
                ds = SqlHelper.ExecuteDataset("ALUMNI_RegistrarSector", .sector_egre, .param1)

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
    Public Function ListarSector(ByVal oeAlumno As eAlumno) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oeAlumno
                ds = SqlHelper.ExecuteDataset("ALUMNI_ListarSector", .sector_egre, .param1, .instituto_egre)

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
    Public Function RegistrarEmpresas(ByVal oeAlumno As eAlumno) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oeAlumno
                ds = SqlHelper.ExecuteDataset("ALUMNI_RegistrarEmpresa", .instituto_egre)

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

    Public Function ListarEmpresas(ByVal oeAlumno As eAlumno) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oeAlumno
                ds = SqlHelper.ExecuteDataset("ALUMNI_ListarEmpresas", .instituto_egre)

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
    Public Function eliminaExpLabEgresado(ByVal oeAlumno As eAlumno) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oeAlumno
                ds = SqlHelper.ExecuteDataset("ALUMNI_EliminarExperiencia", .param1)

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

    Public Function EliminarGradoEgresado(ByVal oeAlumno As eAlumno) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oeAlumno
                ds = SqlHelper.ExecuteDataset("ALUMNI_EliminarFormacion", .param1)

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
    Public Function RegistrarInfoAcadEgresado(ByVal oeAlumno As eAlumno) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oeAlumno
                ds = SqlHelper.ExecuteDataset("ALUMNI_RegistrarFormacionAcademica", .codigo_Alu, .anioi_egre, .anioe_egre, .fechaacto_egre, .gradoobt_egre, .instituto_egre, "", .procedencia_egre, .situacion_egre, .param1, "")

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
    Public Function consultarUltimoUpdateEgresado(ByVal oeAlumno As eAlumno) As DataTable
        Try
            Dim ds As DataSet
            Dim dt As DataTable
            With oeAlumno
                ds = SqlHelper.ExecuteDataset("[dbo].[Alumni_UltimoUpdate]", .codigo_Pso)
                If ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
                    dt = ds.Tables(0)
                Else
                    dt = Nothing
                End If

            End With

            Return dt
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Function consultarDatosAddEgresado(ByVal oeAlumno As eAlumno) As DataTable
        Try
            Dim ds As DataSet
            Dim dt As DataTable
            With oeAlumno
                ds = SqlHelper.ExecuteDataset("[dbo].[ALUMNI_BuscaEgresado]", .codigo_Pso)
                If ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
                    dt = ds.Tables(0)
                Else
                    dt = Nothing
                End If

            End With

            Return dt
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Function consultarGradoyTituloEgresadoAlumni(ByVal oeAlumno As eAlumno) As DataTable
        Try
            Dim ds As DataSet
            Dim dt As DataTable
            With oeAlumno
                ds = SqlHelper.ExecuteDataset("[dbo].[ALUMNI_ConsultarAlumni_FormacionAcademicaEgresado]", .codigo_Alu, .param1)
                If ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
                    dt = ds.Tables(0)
                Else
                    dt = Nothing
                End If

            End With

            Return dt
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Function consultarGradoyTituloEgresado(ByVal oeAlumno As eAlumno) As DataTable
        Try
            Dim ds As DataSet
            Dim dt As DataTable
            With oeAlumno
                ds = SqlHelper.ExecuteDataset("[dbo].[ALUMNI_ConsultarAlumni_FormacionAcademica]", .codigo_Alu, .param1)
                If ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
                    dt = ds.Tables(0)
                Else
                    dt = Nothing
                End If

            End With

            Return dt
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Function consultarExperienciaEgresado(ByVal oeAlumno As eAlumno) As DataTable
        Try
            Dim ds As DataSet
            Dim dt As DataTable
            With oeAlumno
                ds = SqlHelper.ExecuteDataset("[dbo].[ALUMNI_ConsultarAlumni_ExperienciaLaboral]", .codigo_Alu)
                If ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
                    dt = ds.Tables(0)
                Else
                    dt = Nothing
                End If

            End With

            Return dt
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Function actualizaPerfilEgresado(ByVal oeAlumno As eAlumno) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oeAlumno
                ds = SqlHelper.ExecuteDataset("ALUMNI_ActualizaDatosEgre", .codigo_Alu, .param1, "", .param2, .param3, "", "", "", "")
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
    Public Function actualizarDatosEgresado(ByVal oeAlumno As eAlumno) As DataTable
        Dim dt As New DataTable
        Dim ds As New DataSet
        Try
            With oeAlumno
                ds = SqlHelper.ExecuteDataset("ALUMNI_ActualizaDatosCV", .codigo_Alu, .email_Alu, .email_Alu2, .direccion, .codigo_Dis, .telefonocasa, .telefonomovil, .telefonomovil_alu, .sexo_Alu, .estadocivil_Pso, .fechaNacimiento_Alu, .religion_alu, .sacramento_alu, .discapacidad_pso, .otradiscapacidad_pso, .codigo_Pai)
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
    Public Function ListarTiposEstudio(ByVal oeAlumno As eAlumno) As DataTable
        Try
            Dim ds As DataSet
            Dim dt As DataTable
            With oeAlumno
                ds = SqlHelper.ExecuteDataset("[dbo].[ALUMNI_ListarTiposEstudio]", .nroDocIdent_Alu)
                If ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
                    dt = ds.Tables(0)
                Else
                    dt = Nothing
                End If

            End With

            Return dt
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function consultarLugarResidencia(ByVal oeAlumno As eAlumno) As DataTable
        Try
            Dim ds As DataSet
            Dim dt As DataTable
            With oeAlumno
                ds = SqlHelper.ExecuteDataset("[dbo].[ConsultarLugares]", .param1, .param2, .param3)
                If ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
                    dt = ds.Tables(0)
                Else
                    dt = Nothing
                End If

            End With

            Return dt
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function consultarAlumnoEgresado(ByVal oeAlumno As eAlumno) As DataTable
        Try
            Dim ds As DataSet
            Dim dt As DataTable
            With oeAlumno
                ds = SqlHelper.ExecuteDataset("[dbo].[ALUMNI_ConsultarDatosEgresado]", .codigo_Alu)
                If ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
                    dt = ds.Tables(0)
                Else
                    dt = Nothing
                End If

            End With

            Return dt
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function consultarAccesoAlumni(ByVal oeAlumno As eAlumno) As eAlumno
        Try
            '#001 - JR
            Dim ds As DataSet
            With oeAlumno
                ds = SqlHelper.ExecuteDataset("[dbo].[Alumni_ConsultarAcceso_v2]", .nroDocIdent_Alu, .password_Alu)
            End With

            oeAlumno = Nothing
            If ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
                oeAlumno = New eAlumno
                With oeAlumno
                    'oeAlumno.descripcion_Tpe = .Item("descripcion_Tpe".ToString
                    .codigo_Alu = ds.Tables(0).Rows(0).Item("codigo_Alu")
                    .egresado_Alu = ds.Tables(0).Rows(0).Item("egresado_alu").ToString
                    .codigoUniver_Alu = ds.Tables(0).Rows(0).Item("codigoUniver_Alu").ToString
                    .cicloActual_Alu = ds.Tables(0).Rows(0).Item("cicloActual_Alu")
                    .nombreCompleto = ds.Tables(0).Rows(0).Item("nombre_usu").ToString
                    .estadoActual_Alu = ds.Tables(0).Rows(0).Item("estadoActual_Alu").ToString
                    .email_Alu = ds.Tables(0).Rows(0).Item("eMail_Alu").ToString
                    .nombre_Cpf = ds.Tables(0).Rows(0).Item("nombre_Cpf").ToString
                    .codigo_Pes = ds.Tables(0).Rows(0).Item("codigo_pso")
                    .fechaServidor = ds.Tables(0).Rows(0).Item("fechaServidor").ToString
                    .nroDocIdent_Alu = ds.Tables(0).Rows(0).Item("nroDocIdent_Alu").ToString
                    .foto_Alu = ds.Tables(0).Rows(0).Item("foto_Ega").ToString

                End With
            End If
            ds = Nothing
            Return oeAlumno
        Catch ex As Exception
            Throw
        End Try
        '#001 FIN - JR
    End Function

    Public Function consultarAcceso(ByVal oeAlumno As eAlumno) As DataTable
        Try
            Dim ds As DataSet
            Dim dt As DataTable
            With oeAlumno
                ds = SqlHelper.ExecuteDataset("consultaracceso", "A", .codigoUniver_Alu, .password_Alu)
            End With

            If ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
                dt = ds.Tables(0)
            Else
                dt = Nothing
            End If
            Return dt
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function consultarAlumno(ByVal oeAlumno As eAlumno) As DataTable
        Try
            Dim ds As DataSet
            Dim dt As DataTable
            With oeAlumno
                ds = SqlHelper.ExecuteDataset("[dbo].[ConsultarAlumno]", .tipoOperacion, .codigo_Alu)
                If ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
                    dt = ds.Tables(0)
                Else
                    dt = Nothing
                End If

            End With

            Return dt
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function consultarAlumnoUniv(ByVal oeAlumno As eAlumno) As DataTable
        Try
            Dim ds As DataSet
            Dim dt As DataTable
            With oeAlumno
                ds = SqlHelper.ExecuteDataset("[dbo].[ConsultarAlumno]", .tipoOperacion, .codigoUniver_Alu)
                If ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
                    dt = ds.Tables(0)
                Else
                    dt = Nothing
                End If

            End With

            Return dt
        Catch ex As Exception
            Throw
        End Try
    End Function


    Public Function CambiarClave(ByVal oeAlumno As eAlumno) As String
        Dim strMensaje As String = ""
        Try
            With oeAlumno
                strMensaje = SqlHelper.ExecuteScalar("CV_CambiarClave", .codigo_Alu, .password_Alu, .nuevaClave)
                Return strMensaje
            End With
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    Public Function RecuperarClave(ByVal oeAlumno As eAlumno) As DataTable
        Dim ds As DataSet
        Dim dt As DataTable
        Try
            With oeAlumno
                ds = SqlHelper.ExecuteDataset("consultarAlumno", "AC", .codigoUniver_Alu)
                If ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
                    dt = ds.Tables(0)
                Else
                    dt = Nothing
                End If

                Return dt
            End With
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function RecuperarClave_egresado(ByVal oeAlumno As eAlumno) As DataTable
        Dim ds As DataSet
        Dim dt As DataTable
        Try
            With oeAlumno
                ds = SqlHelper.ExecuteDataset("consultarAlumno", "EGR", .nroDocIdent_Alu)
                If ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
                    dt = ds.Tables(0)
                Else
                    dt = Nothing
                End If

                Return dt
            End With
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function ConsultarParaCambiodeGrupo(ByVal oeAlumno As eAlumno) As DataTable
        Dim ds As DataSet
        Dim dt As DataTable
        Try
            ds = SqlHelper.ExecuteDataset("EVE_ConsultarAlumnoParaCambioDeGrupo", oeAlumno.codigoUniver_Alu)
            If ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
                dt = ds.Tables(0)
            Else
                dt = Nothing
            End If

            Return dt
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Function RetornaCodUniversitario(ByVal oeAlumno As eAlumno) As DataTable
        Dim ds As DataSet
        Dim dt As DataTable
        Try
            ds = SqlHelper.ExecuteDataset("ACAD_RetornaCodUniversitario", oeAlumno.codigo_Alu)
            If ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
                dt = ds.Tables(0)
            Else
                dt = Nothing
            End If

            Return dt
        Catch ex As Exception
            Throw
        End Try
    End Function


    Public Function ModificaDatosAlumno(ByVal oeAlumno As eAlumno) As DataTable
        Dim ds As DataSet
        Dim dt As DataTable
        Try
            With oeAlumno
                ds = SqlHelper.ExecuteDataset("ActualizaDatosAlumnoCVE", .codigo_Alu, .email_Alu, .email_Alu2, .direccion, .telefonocasa, .telefonomovil, .confirmaDatos)

            End With
            If ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
                dt = ds.Tables(0)
            Else
                dt = Nothing
            End If

            Return dt
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function ModificaDatosAlumnoV2(ByVal oeAlumno As eAlumno) As DataTable
        Dim ds As DataSet
        Dim dt As DataTable
        Try
            With oeAlumno
                ds = SqlHelper.ExecuteDataset("ActualizaDatosAlumnoCVE_V2", .codigo_Alu, .email_Alu, .email_Alu2, .direccion, .telefonocasa, .telefonomovil)

            End With
            If ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
                dt = ds.Tables(0)
            Else
                dt = Nothing
            End If

            Return dt
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function ConsultarDatosAlumno(ByVal oeAlumno As eAlumno) As DataTable
        Dim ds As DataSet
        Dim dt As DataTable
        Try
            ds = SqlHelper.ExecuteDataset("ALU_DatosAlumno", oeAlumno.codigo_Alu)
            If ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
                dt = ds.Tables(0)
            Else
                dt = Nothing
            End If

            Return dt
        Catch ex As Exception
            Throw
        End Try
    End Function

#Region "BecasEstudio"

    Public Function Beca_VerificarEstudiante(ByVal oeAlumno As eAlumno) As DataTable
        Dim ds As DataSet
        Dim dt As DataTable
        Try
            ds = SqlHelper.ExecuteDataset("Beca_VerificarEstudiante", oeAlumno.codigo_Alu)
            If ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
                dt = ds.Tables(0)
            Else
                dt = Nothing
            End If

            Return dt
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Function Beca_ConsultarRequisitoAlumno(ByVal oeAlumno As eAlumno) As DataTable
        Dim ds As DataSet
        Dim dt As DataTable
        Try
            ds = SqlHelper.ExecuteDataset("Beca_ConsultarRequisitoAlumno", oeAlumno.codigo_Alu)
            If ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
                dt = ds.Tables(0)
            Else
                dt = Nothing
            End If

            Return dt
        Catch ex As Exception
            Throw
        End Try
    End Function


    Public Function Beca_ConsultarSolicitud(ByVal oeAlumno As eAlumno) As DataTable
        Dim ds As DataSet
        Dim dt As DataTable
        Try
            ds = SqlHelper.ExecuteDataset("Beca_ConsultarSolicitud", oeAlumno.codigo_Alu)
            If ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
                dt = ds.Tables(0)
            Else
                dt = Nothing
            End If

            Return dt
        Catch ex As Exception
            Throw
        End Try
    End Function



    Public Function Beca_RegistrarSolicitud(ByVal oeAlumno As eAlumno) As DataTable
        Dim ds As DataSet
        Dim dt As DataTable
        Try
            ds = SqlHelper.ExecuteDataset("Beca_RegistrarSolicitud", oeAlumno.codigo_Alu)
            If ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
                dt = ds.Tables(0)
            Else
                dt = Nothing
            End If

            Return dt
        Catch ex As Exception
            Throw
        End Try
    End Function


#End Region
End Class
