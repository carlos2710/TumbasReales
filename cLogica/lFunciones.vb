Imports System.Security.Cryptography
Imports System.Collections.Specialized

Imports System.Text

Public Class lFunciones
    Public Function NombreDiaSemana(ByVal dia As String) As String
        Dim nombre As String = String.Empty
        dia = dia.ToUpper
        Select Case dia
            Case "LU"
                nombre = "lunes"

            Case "MA"
                nombre = "martes"
            Case "MI"
                nombre = "miercoles"
            Case "JU"
                nombre = "jueves"
            Case "VI"
                nombre = "viernes"

        End Select

        Return nombre
    End Function

    Public Function DevuelveFechaCalendario(ByVal nombreDia As String) As String
        'Dim dia As String = "LU"  'entrada
        Dim numeroDia As Integer = 1 ' entrada
        Dim fechaActual As Date = Now
        Dim numeroDiaActual As Integer = Weekday(fechaActual)
        Dim fechaCalendario As Date = Now
        Dim dias As Double
        numeroDiaActual = numeroDiaActual - 1
        Select Case nombreDia
            Case "LU"
                numeroDia = 1
            Case "MA"
                numeroDia = 2
            Case "MI"
                numeroDia = 3
            Case "JU"
                numeroDia = 4
            Case "VI"
                numeroDia = 5
            Case "SA"
                numeroDia = 6
            Case Else
                numeroDia = 7
        End Select

        If numeroDia = numeroDiaActual Then
            fechaCalendario = fechaActual
        Else
            dias = numeroDia - numeroDiaActual
            fechaCalendario = fechaActual.AddDays(dias)
        End If

        Return fechaCalendario.Year.ToString & "-" & fechaCalendario.Month.ToString & "-" & fechaCalendario.Day.ToString("00")




    End Function



    Public Function NombreNumeroRomano(ByVal numero As String) As String
        Dim nombre As String = String.Empty

        Select Case numero
            Case "1"
                nombre = "I"
            Case "2"
                nombre = "II"
            Case "3"
                nombre = "III"
            Case "4"
                nombre = "IV"
            Case "5"
                nombre = "V"
            Case "6"
                nombre = "VI"
            Case "7"
                nombre = "VII"
            Case "8"
                nombre = "VIII"
            Case "9"
                nombre = "IX"
            Case "10"
                nombre = "X"
            Case "11"
                nombre = "XI"
            Case "12"
                nombre = "XII"
        End Select

        Return nombre
    End Function

    Private Function encriptarCadena(ByVal cadena As String) As String
        Try
            Dim sha As New SHA1CryptoServiceProvider ' declare sha as a new SHA1CryptoServiceProvider
            Dim bytesToHash() As Byte ' and here is a byte variable

            bytesToHash = System.Text.Encoding.ASCII.GetBytes(cadena) ' covert the password into ASCII code
            bytesToHash = sha.ComputeHash(bytesToHash) ' this is where the magic starts and the encryption begins

            Dim encPassword As String = ""

            For Each b As Byte In bytesToHash
                encPassword += b.ToString("x2").ToUpper
            Next

            'Return "0x" & encPassword & "00000000000000000000" ' boom there goes the encrypted password!
            Return "0x" & encPassword ' boom there goes the encrypted password!
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function EncrytedString64(ByVal _stringToEncrypt As String) As String
        Dim result As String = ""
        Dim encryted As Byte()
        encryted = System.Text.Encoding.Unicode.GetBytes(_stringToEncrypt)
        result = Convert.ToBase64String(encryted)
        Return result
    End Function

    Public Function DecrytedString64(ByVal _stringToDecrypt As String) As String
        Dim result As String = ""
        Dim decryted As Byte()
        decryted = Convert.FromBase64String(_stringToDecrypt)        
        result = System.Text.Encoding.Unicode.GetString(decryted, 0, decryted.Length)
        Return result
    End Function


    ''' <summary>
    ''' Esta funcion permite retornar los key deun array param enviados desde jquery por metodo get
    ''' </summary>
    ''' <param name="postedValues">obtiene los key de params</param>
    ''' <param name="nameParam">nombre del paramnetro que será evaluado</param>
    ''' <returns>retorna lista de key del array param</returns>
    ''' <remarks></remarks>
    Public Function ParamsValues(ByVal postedValues As NameValueCollection, ByVal nameParam As String) As ArrayList
        Dim list As New List(Of Dictionary(Of String, Object))()
        Dim dict As New Dictionary(Of String, Object)()
        Dim blnResultado As String = ""
        Dim arrayValues As New ArrayList
        Dim displayValues As New StringBuilder()
        'Dim postedValues As NameValueCollection = request.Params
        Dim nextKey As String
        'Dim cadvalue As String
        For i As Integer = 0 To postedValues.AllKeys.Length - 1
            nextKey = postedValues.AllKeys(i)
            If nextKey.ToString.Length >= 6 AndAlso nextKey.ToString.Contains(nameParam) Then
                If nextKey.Substring(0, 2) <> "__" Then
                    'displayValues.Append("<br>")
                    'displayValues.Append(nextKey)
                    'displayValues.Append(" = ")
                    'displayValues.Append(postedValues(i))
                    '//cadvalue = request(nextKey)
                    arrayValues.Add(nextKey)
                End If
            End If
        Next
        Return arrayValues

    End Function


End Class
