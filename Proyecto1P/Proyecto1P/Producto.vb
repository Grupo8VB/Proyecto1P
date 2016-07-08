Public Class Producto

    Private _idProducto As String
    Public Property IdProducto() As String
        Get
            Return _idProducto
        End Get
        Set(ByVal value As String)
            _idProducto = value
        End Set
    End Property
    Private _nombre As String
    Public Property Nombre() As String
        Get
            Return _nombre
        End Get
        Set(ByVal value As String)
            _nombre = value
        End Set
    End Property

    Private _precioUnitario As String
    Public Property PrecioUnitario() As String
        Get
            Return _precioUnitario
        End Get
        Set(ByVal value As String)
            _precioUnitario = value
        End Set
    End Property

    Public Sub New(ByVal idProducto As String, ByVal nombre As String, ByVal precioUnitario As String)
        Me.IdProducto = idProducto
        Me.Nombre = nombre
        Me.PrecioUnitario = precioUnitario
    End Sub

    Public Sub New()
    End Sub

End Class
