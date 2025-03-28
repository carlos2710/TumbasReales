Imports cDatos
Imports cEntidad
Imports System.Data
Public Class lAlumno
    Dim odAlumno As New dAlumno
    Public Function RecuperarClave_persona(ByVal oeAlumno As eAlumno) As DataTable
        Try
            Return odAlumno.RecuperarClave_persona(oeAlumno)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function ActualizarArchivoCompartivo(ByVal oeAlumno As eAlumno) As DataTable
        Try
            Return odAlumno.ActualizarArchivoCompartivo(oeAlumno)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function ListarArchivosCompartidos(ByVal oeAlumno As eAlumno) As DataTable
        Try
            Return odAlumno.ListarArchivosCompartidos(oeAlumno)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function infoDeudaAlumno(ByVal oeAlumno As eAlumno) As DataTable
        Try
            Return odAlumno.infoDeudaAlumno(oeAlumno)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    '#002 FIN - JR
    Public Function actualizarEquipoEstudiante(ByVal oeAlumno As eAlumno) As DataTable
        Try
            Return odAlumno.actualizarEquipoEstudiante(oeAlumno)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function listarObjetivosPostulacion(ByVal oeAlumno As eAlumno) As DataTable
        Try
            Return odAlumno.listarObjetivosPostulacion(oeAlumno)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function ListaPostulacionesXConcurso(ByVal oeAlumno As eAlumno) As DataTable
        Try
            Return odAlumno.ListaPostulacionesXConcurso(oeAlumno)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function listaDocentes(ByVal oeAlumno As eAlumno) As DataTable
        Try
            Return odAlumno.listaDocentes(oeAlumno)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function actualizarRutaArchivo(ByVal oeAlumno As eAlumno) As DataTable
        Try
            Return odAlumno.actualizarRutaArchivo(oeAlumno)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function registrarObjetivosPostulacion(ByVal oeAlumno As eAlumno) As DataTable
        Try
            Return odAlumno.registrarObjetivosPostulacion(oeAlumno)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function registrarPostulacionEstudiante(ByVal oeAlumno As eAlumno) As DataTable
        Try
            Return odAlumno.registrarPostulacionEstudiante(oeAlumno)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function DatosAlumnoCarFacInvestigacion(ByVal oeAlumno As eAlumno) As DataTable
        Try
            Return odAlumno.DatosAlumnoCarFacInvestigacion(oeAlumno)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function DatosAlumnoInvestigacion(ByVal oeAlumno As eAlumno) As DataTable
        Try
            Return odAlumno.DatosAlumnoInvestigacion(oeAlumno)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function ListarRegiones(ByVal oeAlumno As eAlumno) As DataTable
        Try
            Return odAlumno.ListarRegiones(oeAlumno)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function consultarLineas(ByVal oeAlumno As eAlumno) As DataTable
        Try
            Return odAlumno.consultarLineas(oeAlumno)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function ListarConcursos(ByVal oeAlumno As eAlumno) As DataTable
        Try
            Return odAlumno.ListarConcursos(oeAlumno)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ActualizarInfoAcadEgresadoGyT(ByVal oeAlumno As eAlumno) As DataTable
        Try
            Return odAlumno.ActualizarInfoAcadEgresadoGyT(oeAlumno)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function RegistrarInfoAcadEgresadoGyT(ByVal oeAlumno As eAlumno) As DataTable
        Try
            Return odAlumno.RegistrarInfoAcadEgresadoGyT(oeAlumno)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function listadoUniGrado(ByVal oeAlumno As eAlumno) As DataTable
        Try
            Return odAlumno.listadoUniGrado(oeAlumno)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function HistorialOfertaLaboral(ByVal oeAlumno As eAlumno) As DataTable
        Try '#001 INICIO - JR
            Return odAlumno.HistorialOfertaLaboral(oeAlumno)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function ActualizaFotoEgresado(ByVal oeAlumno As eAlumno) As DataTable
        Try '#001 INICIO - JR
            Return odAlumno.ActualizaFotoEgresado(oeAlumno)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function ExisteArchivoEgresado(ByVal oeAlumno As eAlumno) As DataTable
        Try '#001 INICIO - JR
            Return odAlumno.ExisteArchivoEgresado(oeAlumno)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function CambioDeClaveEgresado(ByVal oeAlumno As eAlumno) As String
        Try '#001 INICIO - JR
            Return odAlumno.CambioClaveEgresado(oeAlumno)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function ConsultarAnuncios(ByVal oeAlumno As eAlumno) As DataTable
        Try
            Return odAlumno.ConsultarAnuncios(oeAlumno)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function InsertaDJEgresado(ByVal oeAlumno As eAlumno) As DataTable
        Try
            Return odAlumno.InsertaDJEgresado(oeAlumno)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function consultarDeclaracionJurada(ByVal oeAlumno As eAlumno) As DataTable
        Try
            Return odAlumno.consultarDeclaracionJurada(oeAlumno)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function DatosOfertaPostular(ByVal oeAlumno As eAlumno) As DataTable
        Try
            Return odAlumno.DatosOfertaPostular(oeAlumno)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function ActualizarNivelHojaVida(ByVal oeAlumno As eAlumno) As DataTable
        Try
            Return odAlumno.ActualizarNivelHojaVida(oeAlumno)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function ConsultarNivelHojaVida(ByVal oeAlumno As eAlumno) As DataTable
        Try
            Return odAlumno.ConsultarNivelHojaVida(oeAlumno)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function registrarNivelHojaVida(ByVal oeAlumno As eAlumno) As DataTable
        Try
            Return odAlumno.registrarNivelHojaVida(oeAlumno)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function consultarDatosReferenciaLaboral(ByVal oeAlumno As eAlumno) As DataTable
        Try
            Return odAlumno.consultarDatosReferenciaLaboral(oeAlumno)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function confirmaExperienciaLaboral(ByVal oeAlumno As eAlumno) As DataTable
        Try
            Return odAlumno.confirmaExperienciaLaboral(oeAlumno)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function EliminarRefLabEgresado(ByVal oeAlumno As eAlumno) As DataTable
        Try
            Return odAlumno.EliminarRefLabEgresado(oeAlumno)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function actualizaRefLaboralEgresado(ByVal oeAlumno As eAlumno) As DataTable
        Try
            Return odAlumno.actualizaRefLaboralEgresado(oeAlumno)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function addRefLaboralEgresado(ByVal oeAlumno As eAlumno) As DataTable
        Try
            Return odAlumno.addRefLaboralEgresado(oeAlumno)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function listadoRefLabEgresado(ByVal oeAlumno As eAlumno) As DataTable
        Try
            Return odAlumno.listadoRefLabEgresado(oeAlumno)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function ActualizaObjLabEgresado(ByVal oeAlumno As eAlumno) As DataTable
        Try
            Return odAlumno.ActualizaObjLabEgresado(oeAlumno)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function objetivoLaboralEgresado(ByVal oeAlumno As eAlumno) As DataTable
        Try
            Return odAlumno.objetivoLaboralEgresado(oeAlumno)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function listadoObjLaboral(ByVal oeAlumno As eAlumno) As DataTable
        Try
            Return odAlumno.listadoObjLaboral(oeAlumno)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function ActualizaIdiomaEgresado(ByVal oeAlumno As eAlumno) As DataTable
        Try
            Return odAlumno.ActualizaIdiomaEgresado(oeAlumno)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function ActualizarInfoAcadEgresado(ByVal oeAlumno As eAlumno) As DataTable
        Try
            Return odAlumno.ActualizarInfoAcadEgresado(oeAlumno)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function actualizaExpLaboralEgresado(ByVal oeAlumno As eAlumno) As DataTable
        Try
            Return odAlumno.actualizaExpLaboralEgresado(oeAlumno)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function listadoTipoInstitucion(ByVal oeAlumno As eAlumno) As DataTable
        Try
            Return odAlumno.listadoTipoInstitucion(oeAlumno)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function listadoUni(ByVal oeAlumno As eAlumno) As DataTable
        Try
            Return odAlumno.listadoUni(oeAlumno)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function listadoCargo(ByVal oeAlumno As eAlumno) As DataTable
        Try
            Return odAlumno.listadoCargo(oeAlumno)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function listadoTipoContrato(ByVal oeAlumno As eAlumno) As DataTable
        Try
            Return odAlumno.listadoTipoContrato(oeAlumno)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function listadoCiudades(ByVal oeAlumno As eAlumno) As DataTable
        Try
            Return odAlumno.listadoCiudades(oeAlumno)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function listadoSector(ByVal oeAlumno As eAlumno) As DataTable
        Try
            Return odAlumno.listadoSector(oeAlumno)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function listadoEmpresas(ByVal oeAlumno As eAlumno) As DataTable
        Try
            Return odAlumno.listadoEmpresas(oeAlumno)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function IdiomaEgresado(ByVal oeAlumno As eAlumno) As DataTable
        Try
            Return odAlumno.IdiomaEgresado(oeAlumno)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function eliminaIdiomaEgresado(ByVal oeAlumno As eAlumno) As DataTable
        Try
            Return odAlumno.eliminaIdiomaEgresado(oeAlumno)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function ExperienciaLaboralEgresado(ByVal oeAlumno As eAlumno) As DataTable
        Try
            Return odAlumno.ExperienciaLaboralEgresado(oeAlumno)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function ListarDistrito(ByVal oeAlumno As eAlumno) As DataTable
        Try
            Return odAlumno.ListarDistrito(oeAlumno)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function RegistrarSector(ByVal oeAlumno As eAlumno) As DataTable
        Try
            Return odAlumno.RegistrarSector(oeAlumno)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function RegistrarEmpresas(ByVal oeAlumno As eAlumno) As DataTable
        Try
            Return odAlumno.RegistrarEmpresas(oeAlumno)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function ListarSector(ByVal oeAlumno As eAlumno) As DataTable
        Try
            Return odAlumno.ListarSector(oeAlumno)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function ListarEmpresas(ByVal oeAlumno As eAlumno) As DataTable
        Try
            Return odAlumno.ListarEmpresas(oeAlumno)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function eliminaExpLabEgresado(ByVal oeAlumno As eAlumno) As DataTable
        Try
            Return odAlumno.eliminaExpLabEgresado(oeAlumno)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function EliminarGradoEgresado(ByVal oeAlumno As eAlumno) As DataTable
        Try
            Return odAlumno.EliminarGradoEgresado(oeAlumno)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function RegistrarInfoAcadEgresado(ByVal oeAlumno As eAlumno) As DataTable
        Try
            Return odAlumno.RegistrarInfoAcadEgresado(oeAlumno)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function consultarUltimoUpdateEgresado(ByVal oeAlumno As eAlumno) As DataTable
        Try
            Return odAlumno.consultarUltimoUpdateEgresado(oeAlumno)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function consultarDatosAddEgresado(ByVal oeAlumno As eAlumno) As DataTable

        Try
            Return odAlumno.consultarDatosAddEgresado(oeAlumno)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function consultarGradoyTituloEgresadoAlumni(ByVal oeAlumno As eAlumno) As DataTable

        Try
            Return odAlumno.consultarGradoyTituloEgresadoAlumni(oeAlumno)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function consultarGradoyTituloEgresado(ByVal oeAlumno As eAlumno) As DataTable

        Try
            Return odAlumno.consultarGradoyTituloEgresado(oeAlumno)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function consultarExperienciaEgresado(ByVal oeAlumno As eAlumno) As DataTable

        Try
            Return odAlumno.consultarExperienciaEgresado(oeAlumno)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function actualizaPerfilEgresado(ByVal oeAlumno As eAlumno) As DataTable

        Try
            Return odAlumno.actualizaPerfilEgresado(oeAlumno)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function actualizarDatosEgresado(ByVal oeAlumno As eAlumno) As DataTable

        Try
            Return odAlumno.actualizarDatosEgresado(oeAlumno)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function ListarTiposEstudio(ByVal oeAlumno As eAlumno) As DataTable

        Try
            Return odAlumno.ListarTiposEstudio(oeAlumno)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function consultarLugarResidencia(ByVal oeAlumno As eAlumno) As DataTable

        Try
            Return odAlumno.consultarLugarResidencia(oeAlumno)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function consultarAlumnoEgresado(ByVal oeAlumno As eAlumno) As DataTable

        Try
            Return odAlumno.consultarAlumnoEgresado(oeAlumno)
        Catch ex As Exception
            Throw ex
        End Try
    End Function     ' #001 FIN -JR 
    Public Function consultarAccesoAlumni(ByVal oeAlumno As eAlumno) As eAlumno
        Try
            Return odAlumno.consultarAccesoAlumni(oeAlumno)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function consultarAcceso(ByVal oeAlumno As eAlumno) As DataTable
        Try
            Return odAlumno.consultarAcceso(oeAlumno)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function consultarAlumno(ByVal oeAlumno As eAlumno) As DataTable

        Try
            Return odAlumno.consultarAlumno(oeAlumno)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function consultarAlumnoUniv(ByVal oeAlumno As eAlumno) As DataTable

        Try
            Return odAlumno.consultarAlumnoUniv(oeAlumno)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function CambioDeClave(ByVal oeAlumno As eAlumno) As String
        Try
            Return odAlumno.CambiarClave(oeAlumno)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function RecuperarClave(ByVal oeAlumno As eAlumno) As DataTable
        Try
            Return odAlumno.RecuperarClave(oeAlumno)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function RecuperarClave_egresado(ByVal oeAlumno As eAlumno) As DataTable
        Try
            Return odAlumno.RecuperarClave_egresado(oeAlumno)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ConsultarParaCambiodeGrupo(ByVal oeAlumno As eAlumno) As DataTable
        Try
            Return odAlumno.ConsultarParaCambiodeGrupo(oeAlumno)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function RetornaCodUniversitario(ByVal oeAlumno As eAlumno) As DataTable
        Try
            Return odAlumno.RetornaCodUniversitario(oeAlumno)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function Beca_VerificarEstudiante(ByVal oeAlumno As eAlumno) As DataTable
        Try
            Return odAlumno.Beca_VerificarEstudiante(oeAlumno)
        Catch ex As Exception
            Throw ex
        End Try
    End Function



    Public Function Beca_ConsultarRequisitoAlumno(ByVal oeAlumno As eAlumno) As DataTable
        Try
            Return odAlumno.Beca_ConsultarRequisitoAlumno(oeAlumno)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function Beca_ConsultarSolicitud(ByVal oeAlumno As eAlumno) As DataTable
        Try
            Return odAlumno.Beca_ConsultarSolicitud(oeAlumno)
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function Beca_RegistrarSolicitud(ByVal oeAlumno As eAlumno) As DataTable
        Try
            Return odAlumno.Beca_RegistrarSolicitud(oeAlumno)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function ModificaDatosAlumno(ByVal oeAlumno As eAlumno) As DataTable
        Try
            Return odAlumno.ModificaDatosAlumno(oeAlumno)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function ModificaDatosAlumnoV2(ByVal oeAlumno As eAlumno) As DataTable
        Try
            Return odAlumno.ModificaDatosAlumnoV2(oeAlumno)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function ConsultarDatosAlumno(ByVal oeAlumno As eAlumno) As DataTable
        Try
            Return odAlumno.ConsultarDatosAlumno(oeAlumno)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
