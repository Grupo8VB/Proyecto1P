Public Class Provincia

    Private _nombre As String
    Public Property nombre() As String
        Get
            Return _nombre
        End Get
        Set(ByVal value As String)
            _nombre = value
        End Set
    End Property

    Private _porcentajeIva As String
    Public Property porcentajeIva() As String
        Get
            Return _porcentajeIva
        End Get
        Set(ByVal value As String)
            _porcentajeIva = value
        End Set
    End Property

    Public Sub New(ByVal nombre As String, ByVal porcentajeIva As String)
        Me.nombre = nombre
        Me.porcentajeIva = porcentajeIva
    End Sub

    Public Sub New()
    End Sub

    Public Sub mostrarProv()
        Console.Write("NOMBRE PROVINCIA : " & Me.nombre)
        Console.WriteLine()
        Console.Write("PORCENTAJE IVA : " & Me.porcentajeIva & "%")
        Console.WriteLine()
    End Sub
End Class
