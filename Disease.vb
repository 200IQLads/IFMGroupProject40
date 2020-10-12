' *****************************************************************
' Team Number: 40
' Team Member 1 Details: Beck, K (215044596)
' Team Member 2 Details: Malinga, LKM (220096457)
' Team Member 3 Details: Mann, JSL (201376743)
' Team Member 4 Details: Makda, LM (219004098)
' Practical: World Disease Protection
' Class name: (Disease)
' *****************************************************************
Option Explicit On
Option Strict On
Option Infer Off

<Serializable()> Public MustInherit Class Disease
    Private _PercentInfected As Double
    Private _Lethality As Double
    Private _Deaths As Integer
    Protected _Cases As Integer
    Private _Guidelines As String

    ' Disease constructor.
    Public Sub New(nCases As Integer, nDeaths As Integer)
        _Cases = nCases
        _Deaths = nDeaths
    End Sub

    ' To get and set the "PercentInfected()" value.
    Public Property PercentInfected() As Double
        Get
            Return _PercentInfected
        End Get
        Set(value As Double)
            _PercentInfected = Validation(value)
        End Set
    End Property

    ' To get and set the "Lethality()" value.
    Public Property Lethality() As Double
        Get
            Return _Lethality
        End Get
        Set(value As Double)
            _Lethality = Validation(value)

        End Set
    End Property ' calculated

    ' To get and set the "Deaths()" value.
    Public Property Deaths() As Integer
        Get
            Return _Deaths

        End Get
        Set(value As Integer)
            _Deaths = Validation(value)

        End Set
    End Property ' given

    ' To get and set the "Cases()" value.
    Public Property Cases() As Integer
        Get
            Return _Cases

        End Get
        Set(value As Integer)
            _Cases = Validation(value)

        End Set
    End Property ' given

    ' To get and set the "Guidelines()" value.
    Public Property Guidelines() As String
        Get
            Return _Guidelines
        End Get
        Set(value As String)
            _Guidelines = value
        End Set
    End Property ' calculated


    Public Function CalcPercentageInfected(population As Double) As Double
        _PercentInfected = (_Cases / (population * 1000000)) * 100
        Return _PercentInfected
    End Function


    Public Function CalcLethality() As Double
        _Lethality = (_Deaths / _Cases) * 100
        Return _Lethality
    End Function


    Public MustOverride Function CalcGuidelines() As String

    Public Function Validation(x As Double) As Double
        If x < 0 Then
            Return 0
        Else
            Return x
        End If
    End Function

    'Doing  overloading
    Public Function Validation(x As Integer) As Integer
        If x < 0 Then
            Return 0
        Else
            Return x
        End If
    End Function

End Class