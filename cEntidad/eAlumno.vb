Public Class eAlumno

#Region "Declaracion de variables"
    Private _codigo_Alu As Integer
    Private _codigo_Pso As Integer
    Private _codigoUniver_Alu As String
    Private _apellidoPat_Alu As String
    Private _apellidoMat_Alu As String
    Private _nombres_Alu As String
    Private _estadoActual_Alu As String
    Private _fechaNacimiento_Alu As Date
    Private _sexo_Alu As String
    Private _tipoDocIdent_Alu As String
    Private _nroDocIdent_Alu As String
    Private _foto_Alu As String
    Private _cicloIng_Alu As String
    Private _cicloEgr_Alu As String
    Private _email_Alu As String
    Private _password_Alu As String
    Private _codigo_Min As Integer
    Private _precioCreditoAct_Alu As Decimal
    Private _monedaPrecioCred_Alu As String
    Private _estadoDeuda_Alu As Integer
    Private _condicion_Alu As String
    Private _beneficio_Alu As String
    Private _bloqueoReg_Alu As String
    Private _nivel_Alu As String
    Private _tempcodigo_cpf As Integer
    Private _codigo_Per As Integer
    Private _creditosAprobadosActual_Alu As Integer
    Private _ccreditosAprobados_Alu As Integer
    Private _ocreditosObligNoComp_Alu As Integer
    Private _rcursosObligNoComp_Alu As Integer
    Private _codigo_cco As Integer
    Private _codigo_test As Integer
    Private _nombreCompleto As String
    Private _nombre_Cpf As String
    Private _codigo_Pes As Integer
    Private _descripcion_Pes As String
    Private _descripcion_Tpe As String
    Private _cicloActual_Alu As Integer
    Private _tipoPension_Alu As String

    Private _ultimaMatricula As String

    Private _precioCreditoNew_Alu As Decimal

    Private _confirmaDatos As Integer

    Private _email_Alu2 As String

    Private _direccion As String

    Private _telefonocasa As String

    Private _telefonomovil As String

    Public tipoOperacion As String

    '#002 - ED
    Private _principalUserName As String



    'Variables para Aula Virtual
    Private _hu As String  'username av
    Private _hp As String 'pass av

    'Variables
    Public nuevaClave As String
    Public confirmaClave As String
    Public fechaServidor As Date
    Public fechaServidor2 As DateTime

    '#001 - JR
    Private _egresado_Alu As String
    Private _codigo_Pai As Integer
    Private _codigo_Dep As Integer
    Private _codigo_Pro As Integer
    Private _codigo_Dis As Integer
    Private _nombre_Pai As String
    Private _nombre_Dep As String
    Private _nombre_Pro As String
    Private _nombre_Dis As String
    Private _estadocivil_Pso As String
    Private _telefonomovil_alu As String
    Private _religion_alu As String
    Private _sacramento_alu As String

    Public param1 As String
    Public param2 As String
    Public param3 As String

    Public _anioi_egre As String
    Public _anioe_egre As String
    Public _fechaacto_egre As String
    Public _gradoobt_egre As String
    Public _instituto_egre As String
    Public _tipoinst_egre As String
    Public _procedencia_egre As String
    Public _situacion_egre As String

    Public _sector_egre As String
    Public _logros_egre As String
    Public _area_egre As String
    Public _contrato_egre As String
    Public _cargo_egre As String
    Public _discapacidad_pso As String
    Public _otradiscapacidad_pso As String


    Public Property hp() As String
        Get
            Return _hp
        End Get
        Set(ByVal value As String)
            _hp = value
        End Set
    End Property

    Public Property hu() As String
        Get
            Return _hu
        End Get
        Set(ByVal value As String)
            _hu = value
        End Set
    End Property
    Public Property ultimaMatricula() As String
        Get
            Return _ultimaMatricula
        End Get
        Set(ByVal value As String)
            _ultimaMatricula = value
        End Set
    End Property

    Public Property precioCreditoNew_Alu() As Decimal
        Get
            Return _precioCreditoNew_Alu
        End Get
        Set(ByVal value As Decimal)
            _precioCreditoNew_Alu = value
        End Set
    End Property

#End Region

#Region "Propiedades"

    Public Property codigo_Alu() As Integer
        Get
            Return _codigo_Alu
        End Get
        Set(ByVal value As Integer)
            _codigo_Alu = value
        End Set
    End Property
    Public Property codigo_Pso() As Integer
        Get
            Return _codigo_Pso
        End Get
        Set(ByVal value As Integer)
            _codigo_Pso = value
        End Set
    End Property
    Public Property codigoUniver_Alu() As String
        Get
            Return _codigoUniver_Alu
        End Get
        Set(ByVal value As String)
            _codigoUniver_Alu = value
        End Set
    End Property
    Public Property apellidoPat_Alu() As String
        Get
            Return _apellidoPat_Alu
        End Get
        Set(ByVal value As String)
            _apellidoPat_Alu = value
        End Set
    End Property
    Public Property apellidoMat_Alu() As String
        Get
            Return _apellidoMat_Alu
        End Get
        Set(ByVal value As String)
            _apellidoMat_Alu = value
        End Set
    End Property
    Public Property nombres_Alu() As String
        Get
            Return _nombres_Alu
        End Get
        Set(ByVal value As String)
            _nombres_Alu = value
        End Set
    End Property
    Public Property estadoActual_Alu() As String
        Get
            Return _estadoActual_Alu
        End Get
        Set(ByVal value As String)
            _estadoActual_Alu = value
        End Set
    End Property
    Public Property fechaNacimiento_Alu() As Date
        Get
            Return _fechaNacimiento_Alu
        End Get
        Set(ByVal value As Date)
            _fechaNacimiento_Alu = value
        End Set
    End Property
    Public Property sexo_Alu() As String
        Get
            Return _sexo_Alu
        End Get
        Set(ByVal value As String)
            _sexo_Alu = value
        End Set
    End Property
    Public Property tipoDocIdent_Alu() As String
        Get
            Return _tipoDocIdent_Alu
        End Get
        Set(ByVal value As String)
            _tipoDocIdent_Alu = value
        End Set
    End Property
    Public Property nroDocIdent_Alu() As String
        Get
            Return _nroDocIdent_Alu
        End Get
        Set(ByVal value As String)
            _nroDocIdent_Alu = value
        End Set
    End Property
    Public Property foto_Alu() As String
        Get
            Return _foto_Alu
        End Get
        Set(ByVal value As String)
            _foto_Alu = value
        End Set
    End Property
    Public Property cicloIng_Alu() As String
        Get
            Return _cicloIng_Alu
        End Get
        Set(ByVal value As String)
            _cicloIng_Alu = value
        End Set
    End Property
    Public Property cicloEgr_Alu() As String
        Get
            Return _cicloEgr_Alu
        End Get
        Set(ByVal value As String)
            _cicloEgr_Alu = value
        End Set
    End Property
    Public Property email_Alu() As String
        Get
            Return _email_Alu
        End Get
        Set(ByVal value As String)
            _email_Alu = value
        End Set
    End Property
    Public Property password_Alu() As String
        Get
            Return _password_Alu
        End Get
        Set(ByVal value As String)
            _password_Alu = value
        End Set
    End Property
    Public Property codigo_Min() As Integer
        Get
            Return _codigo_Min
        End Get
        Set(ByVal value As Integer)
            _codigo_Min = value
        End Set
    End Property
    Public Property precioCreditoAct_Alu() As Decimal
        Get
            Return _precioCreditoAct_Alu
        End Get
        Set(ByVal value As Decimal)
            _precioCreditoAct_Alu = value
        End Set
    End Property
    Public Property monedaPrecioCred_Alu() As String
        Get
            Return _monedaPrecioCred_Alu
        End Get
        Set(ByVal value As String)
            _monedaPrecioCred_Alu = value
        End Set
    End Property
    Public Property estadoDeuda_Alu() As Integer
        Get
            Return _estadoDeuda_Alu
        End Get
        Set(ByVal value As Integer)
            _estadoDeuda_Alu = value
        End Set
    End Property
    Public Property condicion_Alu() As String
        Get
            Return _condicion_Alu
        End Get
        Set(ByVal value As String)
            _condicion_Alu = value
        End Set
    End Property
    Public Property beneficio_Alu() As String
        Get
            Return _beneficio_Alu
        End Get
        Set(ByVal value As String)
            _beneficio_Alu = value
        End Set
    End Property
    Public Property bloqueoReg_Alu() As String
        Get
            Return _bloqueoReg_Alu
        End Get
        Set(ByVal value As String)
            _bloqueoReg_Alu = value
        End Set
    End Property
    Public Property nivel_Alu() As String
        Get
            Return _nivel_Alu
        End Get
        Set(ByVal value As String)
            _nivel_Alu = value
        End Set
    End Property
    Public Property tempcodigo_cpf() As Integer
        Get
            Return _tempcodigo_cpf
        End Get
        Set(ByVal value As Integer)
            _tempcodigo_cpf = value
        End Set
    End Property
    Public Property codigo_Per() As Integer
        Get
            Return _codigo_Per
        End Get
        Set(ByVal value As Integer)
            _codigo_Per = value
        End Set
    End Property
    Public Property creditosAprobadosActual_Alu() As String
        Get
            Return _creditosAprobadosActual_Alu
        End Get
        Set(ByVal value As String)
            _creditosAprobadosActual_Alu = value
        End Set
    End Property
    Public Property ccreditosAprobados_Alu() As Integer
        Get
            Return _ccreditosAprobados_Alu
        End Get
        Set(ByVal value As Integer)
            _ccreditosAprobados_Alu = value
        End Set
    End Property
    Public Property ocreditosObligNoComp_Alu() As Integer
        Get
            Return _ocreditosObligNoComp_Alu
        End Get
        Set(ByVal value As Integer)
            _ocreditosObligNoComp_Alu = value
        End Set
    End Property
    Public Property rcursosObligNoComp_Alu() As Integer
        Get
            Return _rcursosObligNoComp_Alu
        End Get
        Set(ByVal value As Integer)
            _rcursosObligNoComp_Alu = value
        End Set
    End Property
    Public Property codigo_cco() As Integer
        Get
            Return _codigo_cco
        End Get
        Set(ByVal value As Integer)
            _codigo_cco = value
        End Set
    End Property
    Public Property codigo_test() As Integer
        Get
            Return _codigo_test
        End Get
        Set(ByVal value As Integer)
            _codigo_test = value
        End Set
    End Property
    Public Property nombreCompleto() As String
        Get
            Return _nombreCompleto
        End Get
        Set(ByVal value As String)
            _nombreCompleto = value
        End Set
    End Property
    Public Property nombre_Cpf() As String
        Get
            Return _nombre_Cpf
        End Get
        Set(ByVal value As String)
            _nombre_Cpf = value
        End Set
    End Property
    Public Property codigo_Pes() As Integer
        Get
            Return _codigo_Pes
        End Get
        Set(ByVal value As Integer)
            _codigo_Pes = value
        End Set
    End Property
    Public Property descripcion_Pes() As String
        Get
            Return _descripcion_Pes
        End Get
        Set(ByVal value As String)
            _descripcion_Pes = value
        End Set
    End Property
    Public Property descripcion_Tpe() As String
        Get
            Return _descripcion_Tpe
        End Get
        Set(ByVal value As String)
            _descripcion_Tpe = value
        End Set
    End Property
    Public Property cicloActual_Alu() As Integer
        Get
            Return _cicloActual_Alu
        End Get
        Set(ByVal value As Integer)
            _cicloActual_Alu = value
        End Set
    End Property
    Public Property tipoPension_Alu() As String
        Get
            Return _tipoPension_Alu
        End Get
        Set(ByVal value As String)
            _tipoPension_Alu = value
        End Set
    End Property
    Public Property confirmaDatos() As Integer
        Get
            Return _confirmaDatos
        End Get
        Set(ByVal value As Integer)
            _confirmaDatos = value
        End Set
    End Property

    Public Property telefonomovil() As String
        Get
            Return _telefonomovil
        End Get
        Set(ByVal value As String)
            _telefonomovil = value
        End Set
    End Property

    Public Property telefonocasa() As String
        Get
            Return _telefonocasa
        End Get
        Set(ByVal value As String)
            _telefonocasa = value
        End Set
    End Property

    Public Property direccion() As String
        Get
            Return _direccion
        End Get
        Set(ByVal value As String)
            _direccion = value
        End Set
    End Property

    Public Property email_Alu2() As String
        Get
            Return _email_Alu2
        End Get
        Set(ByVal value As String)
            _email_Alu2 = value
        End Set
    End Property
    '#002 - ED
    Public Property principalUserName() As String
        Get
            Return _principalUserName
        End Get
        Set(ByVal value As String)
            _principalUserName = value
        End Set
    End Property
    '#001 INICIO- JR

    Public Property egresado_Alu() As String
        Get
            Return _egresado_Alu
        End Get
        Set(ByVal value As String)
            _egresado_Alu = value
        End Set
    End Property

    Public Property codigo_Pai() As Integer
        Get
            Return _codigo_Pai
        End Get
        Set(ByVal value As Integer)
            _codigo_Pai = value
        End Set
    End Property
    Public Property codigo_Dep() As Integer
        Get
            Return _codigo_Dep
        End Get
        Set(ByVal value As Integer)
            _codigo_Dep = value
        End Set
    End Property
    Public Property codigo_Pro() As Integer
        Get
            Return _codigo_Pro
        End Get
        Set(ByVal value As Integer)
            _codigo_Pro = value
        End Set
    End Property
    Public Property codigo_Dis() As Integer
        Get
            Return _codigo_Dis
        End Get
        Set(ByVal value As Integer)
            _codigo_Dis = value
        End Set
    End Property
    Public Property nombre_Pai() As String
        Get
            Return _nombre_Pai
        End Get
        Set(ByVal value As String)
            _nombre_Pai = value
        End Set
    End Property
    Public Property nombre_Dep() As String
        Get
            Return _nombre_Dep
        End Get
        Set(ByVal value As String)
            _nombre_Dep = value
        End Set
    End Property
    Public Property nombre_Pro() As String
        Get
            Return _nombre_Pro
        End Get
        Set(ByVal value As String)
            _nombre_Pro = value
        End Set
    End Property
    Public Property nombre_Dis() As String
        Get
            Return _nombre_Dis
        End Get
        Set(ByVal value As String)
            _nombre_Dis = value
        End Set
    End Property
    Public Property estadocivil_Pso() As String
        Get
            Return _estadocivil_Pso
        End Get
        Set(ByVal value As String)
            _estadocivil_Pso = value
        End Set
    End Property
    Public Property telefonomovil_alu() As String
        Get
            Return _telefonomovil_alu
        End Get
        Set(ByVal value As String)
            _telefonomovil_alu = value
        End Set
    End Property

    Public Property religion_alu() As String
        Get
            Return _religion_alu
        End Get
        Set(ByVal value As String)
            _religion_alu = value
        End Set
    End Property
    Public Property sacramento_alu() As String
        Get
            Return _sacramento_alu
        End Get
        Set(ByVal value As String)
            _sacramento_alu = value
        End Set
    End Property

    Public Property anioi_egre() As String
        Get
            Return _anioi_egre
        End Get
        Set(ByVal value As String)
            _anioi_egre = value
        End Set
    End Property
    Public Property anioe_egre() As String
        Get
            Return _anioe_egre
        End Get
        Set(ByVal value As String)
            _anioe_egre = value
        End Set
    End Property
    Public Property fechaacto_egre() As String
        Get
            Return _fechaacto_egre
        End Get
        Set(ByVal value As String)
            _fechaacto_egre = value
        End Set
    End Property
    Public Property gradoobt_egre() As String
        Get
            Return _gradoobt_egre
        End Get
        Set(ByVal value As String)
            _gradoobt_egre = value
        End Set
    End Property
    Public Property instituto_egre() As String
        Get
            Return _instituto_egre
        End Get
        Set(ByVal value As String)
            _instituto_egre = value
        End Set
    End Property

    Public Property tipoinst_egre() As String
        Get
            Return _tipoinst_egre
        End Get
        Set(ByVal value As String)
            _tipoinst_egre = value
        End Set
    End Property
    Public Property procedencia_egre() As String
        Get
            Return _procedencia_egre
        End Get
        Set(ByVal value As String)
            _procedencia_egre = value
        End Set
    End Property
    Public Property situacion_egre() As String
        Get
            Return _situacion_egre
        End Get
        Set(ByVal value As String)
            _situacion_egre = value
        End Set
    End Property
    Public Property sector_egre() As String
        Get
            Return _sector_egre
        End Get
        Set(ByVal value As String)
            _sector_egre = value
        End Set
    End Property
    Public Property logros_egre() As String
        Get
            Return _logros_egre
        End Get
        Set(ByVal value As String)
            _logros_egre = value
        End Set
    End Property
    Public Property area_egre() As String
        Get
            Return _area_egre
        End Get
        Set(ByVal value As String)
            _area_egre = value
        End Set
    End Property
    Public Property contrato_egre() As String
        Get
            Return _contrato_egre
        End Get
        Set(ByVal value As String)
            _contrato_egre = value
        End Set
    End Property
    Public Property cargo_egre() As String
        Get
            Return _cargo_egre
        End Get
        Set(ByVal value As String)
            _cargo_egre = value
        End Set
        '#001 FIN - JR
    End Property
    Public Property discapacidad_pso() As String
        Get
            Return _discapacidad_pso
        End Get
        Set(ByVal value As String)
            _discapacidad_pso = value
        End Set
        '#001 FIN - JR
    End Property
    Public Property otradiscapacidad_pso() As String
        Get
            Return _otradiscapacidad_pso
        End Get
        Set(ByVal value As String)
            _otradiscapacidad_pso = value
        End Set
        '#001 FIN - JR
    End Property

#End Region

#Region "Constructor"
    Public Sub New()
        _codigoUniver_Alu = String.Empty
        _apellidoPat_Alu = String.Empty
        _apellidoMat_Alu = String.Empty
        _nombres_Alu = String.Empty
        _estadoActual_Alu = String.Empty
        _fechaNacimiento_Alu = #1/1/1901#
        _sexo_Alu = String.Empty
        _tipoDocIdent_Alu = String.Empty
        _nroDocIdent_Alu = String.Empty
        _foto_Alu = String.Empty
        _cicloIng_Alu = String.Empty
        _cicloEgr_Alu = String.Empty
        _email_Alu = String.Empty
        _password_Alu = String.Empty
        _monedaPrecioCred_Alu = String.Empty
        _condicion_Alu = String.Empty
        _beneficio_Alu = String.Empty
        _bloqueoReg_Alu = String.Empty
        _nivel_Alu = String.Empty
        _nombreCompleto = String.Empty
        _nombre_Cpf = String.Empty
        _descripcion_Pes = String.Empty
        _descripcion_Tpe = String.Empty
        _ultimaMatricula = String.Empty
        '002 - ED
        _principalUserName = String.Empty

        '#001 INICIO - JR
        _egresado_Alu = String.Empty
        _nombre_Pai = String.Empty
        _nombre_Dep = String.Empty
        _nombre_Pro = String.Empty
        _nombre_Dis = String.Empty
        _estadocivil_Pso = String.Empty
        _telefonomovil_alu = String.Empty
        _religion_alu = String.Empty
        _sacramento_alu = String.Empty
        _anioi_egre = String.Empty
        _anioe_egre = String.Empty
        _fechaacto_egre = String.Empty
        _gradoobt_egre = String.Empty
        _instituto_egre = String.Empty
        _tipoinst_egre = String.Empty
        _procedencia_egre = String.Empty
        _situacion_egre = String.Empty
        _sector_egre = String.Empty
        _logros_egre = String.Empty
        _area_egre = String.Empty
        _contrato_egre = String.Empty
        _cargo_egre = String.Empty
        _discapacidad_pso = String.Empty
        _otradiscapacidad_pso = String.Empty
        '#001 FIN  - JR
    End Sub

    Public Sub New(ByVal codigo_Alu As Integer, _
                    ByVal codigo_Pso As Integer, _
                    ByVal odigoUniver_Alu As String, _
                    ByVal apellidoPat_Alu As String, _
                    ByVal apellidoMat_Alu As String, _
                    ByVal nombres_Alu As String, _
                    ByVal estadoActual_Alu As String, _
                    ByVal fechaNacimiento_Alu As Date, _
                    ByVal sexo_Alu As String, _
                    ByVal tipoDocIdent_Alu As String, _
                    ByVal nroDocIdent_Alu As String, _
                    ByVal foto_Alu As String, _
                    ByVal cicloIng_Alu As String, _
                    ByVal cicloEgr_Alu As String, _
                    ByVal email_Alu As String, _
                    ByVal password_Alu As String, _
                    ByVal codigo_Min As Integer, _
                    ByVal precioCreditoAct_Alu As Decimal, _
                    ByVal monedaPrecioCred_Alu As String, _
                    ByVal estadoDeuda_Alu As Integer, _
                    ByVal condicion_Alu As String, _
                    ByVal beneficio_Alu As String, _
                    ByVal bloqueoReg_Alu As String, _
                    ByVal nivel_Alu As String, _
                    ByVal tempcodigo_cpf As Integer, _
                    ByVal codigo_Per As Integer, _
                    ByVal creditosAprobadosActual_Alu As Integer, _
                    ByVal ccreditosAprobados_Alu As Integer, _
                    ByVal ocreditosObligNoComp_Alu As Integer, _
                    ByVal rcursosObligNoComp_Alu As Integer, _
                    ByVal codigo_cco As Integer, _
                    ByVal codigo_test As Integer, _
                    ByVal nombreCompleto As String, _
                    ByVal nombre_Cpf As String, _
                    ByVal codigo_Pes As Integer, _
                    ByVal descripcion_Pes As String, _
                    ByVal descripcion_Tpe As String, _
                    ByVal cicloActual_Alu As Integer, _
                    ByVal tipoPension_Alu As String, _
                    ByVal precioCreditoNew_Alu As Decimal, _
                    ByVal princiaplUserName As String, _
                    ByVal egresado_Alu As String, _
                    ByVal codigo_Pai As Integer, _
                    ByVal codigo_Dep As Integer, _
                    ByVal codigo_Pro As Integer, _
                    ByVal codigo_Dis As Integer, _
                    ByVal nombre_Pai As String, _
                    ByVal nombre_Dep As String, _
                    ByVal nombre_Pro As String, _
                    ByVal nombre_Dis As String, _
                    ByVal estadocivil_Pso As String, _
                    ByVal telefonomovil_alu As String, _
                    ByVal _religion_alu As String, _
                    ByVal _sacramento_alu As String, _
                    ByVal _anioi_egre As String, _
                    ByVal _anioe_egre As String, _
                    ByVal _fechaacto_egre As String, _
                    ByVal _gradoobt_egre As String, _
                    ByVal _instituto_egre As String, _
                    ByVal _tipoinst_egre As String, _
                    ByVal _procedencia_egre As String, _
                    ByVal _situacion_egre As String, _
                    ByVal _sector_egre As String, _
                    ByVal _logros_egre As String, _
                    ByVal _area_egre As String, _
                    ByVal _contrato_egre As String, _
                    ByVal _cargo_egre As String, _
                    ByVal _discapacidad_pso As String, _
                    ByVal _otradiscapacidad_pso As String)
        '#001 - JR : INICIO=egresado_Alu FIN=_otradiscapacidad_pso
        '#002 - ED : ByVal princiaplUserName As String
        _codigo_Alu = codigo_Alu
        _codigo_Pso = codigo_Pso
        _codigoUniver_Alu = codigoUniver_Alu
        _apellidoPat_Alu = apellidoPat_Alu
        _apellidoMat_Alu = apellidoMat_Alu
        _nombres_Alu = nombres_Alu
        _estadoActual_Alu = estadoActual_Alu
        _fechaNacimiento_Alu = fechaNacimiento_Alu
        _sexo_Alu = sexo_Alu
        _tipoDocIdent_Alu = tipoDocIdent_Alu
        _nroDocIdent_Alu = nroDocIdent_Alu
        _foto_Alu = foto_Alu
        _cicloIng_Alu = cicloIng_Alu
        _cicloEgr_Alu = cicloEgr_Alu
        _email_Alu = email_Alu
        _password_Alu = password_Alu
        _codigo_Min = codigo_Min
        _precioCreditoAct_Alu = precioCreditoAct_Alu
        _monedaPrecioCred_Alu = monedaPrecioCred_Alu
        _estadoDeuda_Alu = estadoDeuda_Alu
        _condicion_Alu = condicion_Alu
        _beneficio_Alu = beneficio_Alu
        _bloqueoReg_Alu = bloqueoReg_Alu
        _nivel_Alu = nivel_Alu
        _tempcodigo_cpf = tempcodigo_cpf
        _codigo_Per = codigo_Per
        _creditosAprobadosActual_Alu = creditosAprobadosActual_Alu
        _ccreditosAprobados_Alu = ccreditosAprobados_Alu
        _ocreditosObligNoComp_Alu = ocreditosObligNoComp_Alu
        _rcursosObligNoComp_Alu = rcursosObligNoComp_Alu
        _codigo_cco = codigo_cco
        _codigo_test = codigo_test
        _nombreCompleto = nombreCompleto
        _nombre_Cpf = nombre_Cpf
        _codigo_Pes = codigo_Pes
        _descripcion_Pes = descripcion_Pes
        _descripcion_Tpe = descripcion_Tpe
        _cicloActual_Alu = cicloActual_Alu
        _tipoPension_Alu = tipoPension_Alu
        _precioCreditoNew_Alu = precioCreditoNew_Alu
        '#002 - ED
        _principalUserName = princiaplUserName
        '#001 INICIO- JR
        _egresado_Alu = egresado_Alu
        _codigo_Pai = codigo_Pai
        _codigo_Dep = codigo_Dep
        _codigo_Pro = codigo_Pro
        _codigo_Dis = codigo_Dis
        _nombre_Pai = nombre_Pai
        _nombre_Dep = nombre_Dep
        _nombre_Pro = nombre_Pro
        _nombre_Dis = nombre_Dis
        _estadocivil_Pso = estadocivil_Pso
        _telefonomovil_alu = telefonomovil_alu
        _religion_alu = religion_alu
        _sacramento_alu = sacramento_alu
        _anioi_egre = anioi_egre
        _anioe_egre = anioe_egre
        _fechaacto_egre = fechaacto_egre
        _gradoobt_egre = gradoobt_egre
        _instituto_egre = instituto_egre
        _tipoinst_egre = tipoinst_egre
        _procedencia_egre = procedencia_egre
        _situacion_egre = situacion_egre
        _sector_egre = sector_egre
        _logros_egre = logros_egre
        _area_egre = area_egre
        _contrato_egre = contrato_egre
        _cargo_egre = cargo_egre
        _discapacidad_pso = discapacidad_pso
        _otradiscapacidad_pso = otradiscapacidad_pso
        '#001 FIN- JR
    End Sub
#End Region
End Class
