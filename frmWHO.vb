' *****************************************************************
' Team Number: 40
' Team Member 1 Details: Beck, K (215044596)
' Team Member 2 Details: Malinga, LKM (220096457)
' Team Member 3 Details: Mann, JSL (201376743)
' Team Member 4 Details: Makda, LM (219004098)
' Practical: World Disease Protection
' Class name: (frmWHO)
' *****************************************************************

Option Explicit On
Option Strict On
Option Infer Off

Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary

Public Class frmWHO
    ' Country record structure.
    Private Structure CountryRec
        Public countryName As String
        Public Population As Double
        Public Diseases() As Disease
    End Structure

    ' Enum to select a specific disease to record.
    Enum DiseaseType
        Covid = 1
        HIVAids = 2
        Malaria = 3
    End Enum

    ' Declaring variables.
    Private numCountries As Integer
    Private Countries() As CountryRec
    Private FS As FileStream
    Private BF As BinaryFormatter
    Private Const fileName As String = "CountryDiseases.ifm"

    ' A subroutine to display the inputs entered and calcutions on a grid.
    Public Sub PlaceText(ByVal r As Integer, ByVal c As Integer, ByVal t As String)
        grdDisplay.Row = r
        grdDisplay.Col = c
        grdDisplay.Text = t
    End Sub

    Private Sub frmWHO_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' Setting the size of grid.
        grdDisplay.Rows = 22
        ' Labeling the grid.
        PlaceText(0, 0, "Country Name")
        PlaceText(1, 0, "Population")
        PlaceText(2, 0, "Covid Cases")
        PlaceText(3, 0, "Covid Deaths")
        PlaceText(4, 0, "Population Infected with Covid-19")
        PlaceText(5, 0, "Covid Lethality")
        PlaceText(6, 0, "Lockdown status for Covid")
        PlaceText(7, 0, "")
        PlaceText(8, 0, "HIV Cases")
        PlaceText(9, 0, "HIV Deaths")
        PlaceText(10, 0, "Population Infected with HIV/Aids")
        PlaceText(11, 0, "HIV Lethality")
        PlaceText(12, 0, "Treatment for HIV/Aids")
        PlaceText(13, 0, "Recommendation to prevent HIV/Aids")
        PlaceText(14, 0, "")
        PlaceText(15, 0, "Malaria Cases")
        PlaceText(16, 0, "Malaria Deaths")
        PlaceText(17, 0, "Population Infected with Malaria")
        PlaceText(18, 0, "Malaria Lethality")
        PlaceText(19, 0, "Treatment for Malaria")
        PlaceText(20, 0, "Treatment Supply Status")
        PlaceText(21, 0, "Recommendation to prevent Malaria")
    End Sub

    Private Sub btnCountry_Click(sender As Object, e As EventArgs) Handles btnCountry.Click
        ' Getting the number of countries to record.
        numCountries = CInt(InputBox("How many countries?"))
        ' Resizing the "Countries" array.
        ReDim Countries(numCountries)

        ' Resizing the "Disease" array.
        Dim c, d As Integer
        For c = 1 To numCountries
            ReDim Countries(c).Diseases(3)
        Next c

        ' Setting the size of grid.
        grdDisplay.Cols = numCountries + 1

        ' For loop to get the information of each country and a code typed by the user to get the records of the dieseases(Covid-19, HIV/Aids, Malaria) in each country with a select case. 
        ' Display the information inputted by user
        For c = 1 To numCountries
            Countries(c).countryName = InputBox("Name of country " & CStr(c) & "?")
            PlaceText(0, c, Countries(c).countryName)
            Countries(c).Population = CDbl(InputBox("Population of country " & CStr(c) & "?"))
            PlaceText(1, c, CStr(Countries(c).Population))
            For d = 1 To 3
                Dim typeOfDisease As Integer
                typeOfDisease = CInt(InputBox("Type the code of the disease to record:" & Environment.NewLine & "1 - Covid-19" & Environment.NewLine & "2 - HIV/Aids" & Environment.NewLine & "3 - Malaria"))

                Dim numCases, numDeath As Integer
                Select Case typeOfDisease
                    Case DiseaseType.Covid
                        ' To get the information of Covid-19.
                        numCases = CInt(InputBox("Number of covid-19 casse in country " & CStr(c) & "?"))
                        numDeath = CInt(InputBox("Number of deaths caused by Covid-19 in country " & CStr(c) & "?"))
                        Dim covid As COVID
                        covid = New COVID(numCases, numDeath)
                        Countries(c).Diseases(d) = covid
                        PlaceText(2, c, CStr(covid.Cases))
                        PlaceText(3, c, CStr(covid.Deaths))
                    Case DiseaseType.HIVAids
                        ' To get the information of HIV/Aids.
                        numCases = CInt(InputBox("Number of HIV/Aids cases in country " & CStr(c) & "?"))
                        numDeath = CInt(InputBox("Number of deaths caused by HIV/Aids in country " & CStr(c) & "?"))
                        Dim HIVAids As HIV
                        HIVAids = New HIV(numCases, numDeath)
                        Countries(c).Diseases(d) = HIVAids
                        PlaceText(8, c, CStr(HIVAids.Cases))
                        PlaceText(9, c, CStr(HIVAids.Deaths))
                        PlaceText(12, c, HIVAids.MedType)
                    Case DiseaseType.Malaria
                        ' To get the information of malaria.
                        numCases = CInt(InputBox("Number of malaria cases in country " & CStr(c) & "?"))
                        numDeath = CInt(InputBox("Number of deaths caused by malaria in country " & CStr(c) & "?"))
                        Dim malaria As Malaria
                        malaria = New Malaria(numCases, numDeath)
                        Countries(c).Diseases(d) = malaria
                        malaria.Antibiotics = CInt(InputBox("How many antibiotics available in country " & CStr(c) & "?"))
                        PlaceText(15, c, CStr(malaria.Cases))
                        PlaceText(16, c, CStr(malaria.Deaths))
                        PlaceText(19, c, malaria.MedType)
                    Case Else
                        MsgBox("Invalid input")
                        d -= 1
                End Select
            Next d
        Next c


    End Sub

    Private Sub btnCalcInfected_Click(sender As Object, e As EventArgs) Handles btnCalcInfected.Click
        Dim c As Integer

        ' For loop to calculate and display the percentage of the population infected with the disease(Covid-19, HIV/Aids, Malaria)
        For c = 1 To numCountries
            PlaceText(4, c, Format(Countries(c).Diseases(1).CalcPercentageInfected(Countries(c).Population), ".00") & "%")
            PlaceText(10, c, Format(Countries(c).Diseases(2).CalcPercentageInfected(Countries(c).Population), ".00") & "%")
            PlaceText(17, c, Format(Countries(c).Diseases(3).CalcPercentageInfected(Countries(c).Population), ".00") & "%")
        Next c
    End Sub

    Private Sub btnCalLethality_Click(sender As Object, e As EventArgs) Handles btnCalLethality.Click
        Dim c As Integer

        ' For loop to calculate and display the lethality of each disease(Covid-19, HIV/Aids, Malaria)
        For c = 1 To numCountries
            PlaceText(5, c, Format(Countries(c).Diseases(1).CalcLethality(), ".00") & "%")
            PlaceText(11, c, Format(Countries(c).Diseases(2).CalcLethality(), ".00") & "%")
            PlaceText(18, c, Format(Countries(c).Diseases(3).CalcLethality(), ".00") & "%")
        Next c

    End Sub

    Private Sub btnGuidelines_Click(sender As Object, e As EventArgs) Handles btnGuidelines.Click
        Dim c As Integer

        ' For loop to calculate and display the guidelines for each disease(Covid-19, HIV/Aids, Malaria)
        For c = 1 To numCountries
            PlaceText(6, c, Countries(c).Diseases(1).CalcGuidelines())
            PlaceText(13, c, Countries(c).Diseases(2).CalcGuidelines())
            PlaceText(20, c, Countries(c).Diseases(3).CalcGuidelines())
        Next c

        ' Forloop to determine the prevention solution for malaria.
        For c = 1 To numCountries
            If TypeOf Countries(c).Diseases(3) Is Malaria Then
                Dim malariaTemp As Malaria
                malariaTemp = DirectCast(Countries(c).Diseases(3), Malaria)
                PlaceText(21, c, malariaTemp.PreventionSolution())
            End If
        Next c

    End Sub

    Private Sub btnFileSave_Click(sender As Object, e As EventArgs) Handles btnFileSave.Click
        'create a file stream
        FS = New FileStream(fileName, FileMode.Create, FileAccess.Write)

        'binary formatter
        BF = New BinaryFormatter()

        'serialise the desired disease
        For c As Integer = 1 To numCountries
            For d As Integer = 1 To 3
                If TypeOf Countries(c).Diseases(d) Is COVID Then
                    Dim covidTemp As COVID
                    covidTemp = DirectCast(Countries(c).Diseases(d), COVID)
                    BF.Serialize(FS, covidTemp)
                End If
            Next d
        Next c

        ' Closes the file connection
        FS.Close()
        FS = Nothing
        BF = Nothing
    End Sub

End Class
