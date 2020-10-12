' *****************************************************************
' Team Number: 40
' Team Member 1 Details: Beck, K (215044596)
' Team Member 2 Details: Malinga, LKM (220096457)
' Team Member 3 Details: Mann, JSL (201376743)
' Team Member 4 Details: Makda, LM (219004098)
' Practical: World Disease Protection
' Class name: (Malaria)
' *****************************************************************
Option Explicit On
Option Strict On
Option Infer Off

<Serializable()> Public Class Malaria
    Inherits Disease
    Implements IMeds

    ' Malaria Attributes/Variables
    Private _Antibiotics As Integer
    Private Shared _AntibioticsPerMonthPerCase As Integer
    Private _CanHandle As Boolean
    Private _MaxCases As Integer
    Private _PreventionMeasure As String
    Private _MedType As String

    ' Malaria Constructor
    Public Sub New(nCases As Integer, nDeaths As Integer)
        MyBase.New(nCases, nDeaths)
        _AntibioticsPerMonthPerCase = 60
        _MedType = "Antibiotics"
    End Sub

    ' To get and set the "Antibiotics()" value.
    Public Property Antibiotics() As Integer
        Get
            Return _Antibiotics
        End Get
        Set(value As Integer)
            _Antibiotics = Validation(value)
        End Set
    End Property

    ' To get and set the "AntibioticsPerMonthPerCase()" value.
    Public Shared Property AntibioticsPerMonthPerCase() As Integer
        Get
            Return _AntibioticsPerMonthPerCase
        End Get
        Set(value As Integer)
            _AntibioticsPerMonthPerCase = value
        End Set
    End Property

    ' To get and set the "CanHandle()" value.
    Public Property CanHandle() As Boolean
        Get
            Return _CanHandle
        End Get
        Set(value As Boolean)
            If value = False Then
                _CanHandle = value
            Else
                _CanHandle = True
            End If
        End Set
    End Property

    ' To get and set the "MaxCases()" value.
    Public Property MaxCases() As Integer
        Get
            Return _MaxCases
        End Get
        Set(value As Integer)
            _MaxCases = Validation(value)
        End Set
    End Property

    ' To get and set the "PreventionMeasure()" value.
    Public Property PreventionMeasure() As String
        Get
            Return _PreventionMeasure
        End Get
        Set(value As String)
            _PreventionMeasure = value
        End Set
    End Property

    Public Property MedType As String Implements IMeds.MedType
        Get
            Return _MedType
        End Get
        Set(value As String)
            _MedType = value
        End Set
    End Property

    ' Function that checks whether the country can supply the demand needed for antibiotics.
    Public Function CheckCanHandle() As Boolean
        Dim antibioticInSupply As Integer
        antibioticInSupply = CalcMaxCases()
        If (antibioticInSupply < Cases) Then
            _CanHandle = False
        Else
            _CanHandle = True
        End If
        Return _CanHandle
    End Function

    ' Function that determines whether the country is short on supply on anitbiotics or if it can meet the demand.
    Public Overrides Function CalcGuidelines() As String
        If CheckCanHandle() = True Then
            Guidelines = "Order more antibiotics."
        Else
            Guidelines = "There are enough antibiotics."
        End If
        Return Guidelines
    End Function

    ' Function that calculates the amount of antibiotics that the country can supply.
    Public Function CalcMaxCases() As Integer
        _MaxCases = CInt(_Antibiotics / 60)
        Return _MaxCases
    End Function

    Public Function PreventionSolution() As String
        Select Case PercentInfected
            Case Is > 10
                PreventionMeasure = "Produce Insecticide-Treated Bed Nets"
            Case 5 To 10
                PreventionMeasure = "Pyrethroids"
            Case 0 To 4
                PreventionMeasure = "Indoor Residual Spraying"
        End Select
        Return PreventionMeasure
    End Function



End Class

