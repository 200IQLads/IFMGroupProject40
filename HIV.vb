' *****************************************************************
' Team Number: 40
' Team Member 1 Details: Beck, K (215044596)
' Team Member 2 Details: Malinga, LKM (220096457)
' Team Member 3 Details: Mann, JSL (201376743)
' Team Member 4 Details: Makda, LM (219004098)
' Practical: World Disease Protection
' Class name: (HIV)
' *****************************************************************
Option Explicit On
Option Strict On
Option Infer Off

<Serializable()> Public Class HIV
    Inherits Disease
    Implements IMeds
    ' HIV/Aids Attributes/Variables
    Private _MedType As String

    ' HIV/Aids constructor.
    Public Sub New(nCases As Integer, nDeaths As Integer)
        MyBase.New(nCases, nDeaths)
        _MedType = "Antiretrovirals (ARVs)"
    End Sub

    ' To get and set the "MedType()" value.
    Public Property MedType() As String Implements IMeds.MedType
        Get
            Return _MedType
        End Get
        Set(value As String)
            _MedType = value
        End Set
    End Property

    ' Function that determines the prevention measure needed to combat HIV/Aids.
    Public Overrides Function CalcGuidelines() As String
        Select Case PercentInfected
            Case Is > 15
                Guidelines = "Government Provide Free Condoms"
            Case 6 To 15
                Guidelines = "Sexual Education Programs"
            Case 0 To 5
                Guidelines = "Use Proctection and Get Tested Regualarly"
        End Select
        Return Guidelines
    End Function

End Class
