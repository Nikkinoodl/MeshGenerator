Imports System.Reflection

Public NotInheritable Class IoC : Inherits Base
    'IoC Container for interface - class implementation lookups

    'the Of keyword is used for a list of types in place of the <> brackets in C#
    Private Shared ReadOnly _types As IDictionary(Of Type, Type) = New Dictionary(Of Type, Type)()
    Private Shared _registeredtypes As Dictionary(Of Type, Object) = New Dictionary(Of Type, Object)

    'a type list in () brackets precedes the parameter list in () brackets
    Public Shared Sub Register(Of TContract, TImplementation)()

        _types.Add(GetType(TContract), GetType(TImplementation))

    End Sub

    Public Shared Sub Register(Of TContract, TImplementation)(instance As TImplementation)

        _registeredtypes.Add(GetType(TContract), instance)

    End Sub

    Public Shared Function Resolve(Of T)() As T
        Dim ret As T = Nothing

        If _registeredtypes.ContainsValue(GetType(T)) Then
            ret = _registeredtypes.Item(GetType(T))()
        End If

        Return ret
    End Function

    Public Shared Function Resolve(ByVal contract As Type) As Object

        If (_registeredtypes.ContainsKey(contract)) Then

            Return _registeredtypes(contract)
        Else
            Dim implementation As Type = _types(contract)
            Dim constructor As ConstructorInfo = implementation.GetConstructors()(0)
            Dim constructorParameters As ParameterInfo() = constructor.GetParameters()

            If (constructorParameters.Length = 0) Then

                Return Activator.CreateInstance(implementation)

            End If

            Dim parameters As List(Of Object) = New List(Of Object)(constructorParameters.Length)
            Dim parameterInfo As ParameterInfo

            For Each parameterInfo In constructorParameters

                parameters.Add(Resolve(parameterInfo.ParameterType))

            Next
            Return constructor.Invoke(parameters.ToArray())
        End If
    End Function
End Class