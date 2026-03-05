Public Class SeniorCitizen
    Public Property IDNumber As String
    Public Property FullName As String
    Public Property Gender As String
    Public Property Birthday As Date
    Public Property CurrentAge As Integer
    Public Property Address As String
    Public Property RelativeName As String
    Public Property RelativeContactNumber As String

    Public Sub New()
    End Sub

    Public Sub New(idNumber As String, fullName As String, gender As String, birthday As Date, address As String, relativeName As String, relativeContact As String)
        Me.IDNumber = idNumber
        Me.FullName = fullName
        Me.Gender = gender
        Me.Birthday = birthday
        Me.CurrentAge = CalculateAge(birthday)
        Me.Address = address
        Me.RelativeName = relativeName
        Me.RelativeContactNumber = relativeContact
    End Sub

    Private Function CalculateAge(birthday As Date) As Integer
        Dim today As Date = Date.Today
        Dim age As Integer = today.Year - birthday.Year
        If birthday > today.AddYears(-age) Then
            age -= 1
        End If
        Return age
    End Function
End Class

' Shared data storage for all registered senior citizens
Public Module SeniorCitizenData
    Public RegisteredCitizens As New List(Of SeniorCitizen)
End Module
