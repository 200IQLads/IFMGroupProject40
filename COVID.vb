' *****************************************************************
' Team Number: 40
' Team Member 1 Details: Beck, K (215044596)
' Team Member 2 Details: Malinga, LKM (220096457)
' Team Member 3 Details: Mann, JSL (201376743)
' Team Member 4 Details: Makda, LM (219004098)
' Practical: World Disease Protection
' Class name: (Covid)
' *****************************************************************
Option Explicit On
Option Strict On
Option Infer Off
<Serializable()> Public Class COVID
    Inherits Disease
    ' Covid-19 Attributes/Variables
    Private _LockdownLevel As String

    ' Covid-19 constructor.
    Public Sub New(nCases As Integer, nDeaths As Integer)
        MyBase.New(nCases, nDeaths)
    End Sub

    ' To get and set the "LockdownLevel()" value.
    Public Property LockdownLevel() As String
        Get
            Return _LockdownLevel
        End Get
        Set(value As String)
            _LockdownLevel = value
        End Set
    End Property

    ' Function to display guidlines the country needs to take to combat covid-19.
    Public Overrides Function CalcGuidelines() As String
        Guidelines = "Lockdown Level: " & calcLockdown()
        Return Guidelines
    End Function

    ' Function to determine the lockdown level based on the percentage of the population infected with covid-19.
    Public Function calcLockdown() As String
        Select Case PercentInfected
            Case 0 To 2
                _LockdownLevel = "1"
            Case 2 To 5
                _LockdownLevel = "2"
            Case 5 To 10
                _LockdownLevel = "3"
            Case 10 To 15
                _LockdownLevel = "4"
            Case > 15
                _LockdownLevel = "5"
        End Select
        Return _LockdownLevel
    End Function

End Class
