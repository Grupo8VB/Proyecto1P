Public Class Categoria

    Private _id As String
    Public Property id() As String
        Get
            Return _id
        End Get
        Set(ByVal value As String)
            _id = value
        End Set
    End Property
    Private _nombre As String
    Public Property nombre() As String
        Get
            Return _nombre
        End Get
        Set(ByVal value As String)
            _nombre = value
        End Set
    End Property

    Public _listaProductos As List(Of Producto)

    Public Property listaProductos() As List(Of Producto)
        Get
            Return _listaProductos
        End Get
        Set(ByVal value As List(Of Producto))
            _listaProductos = value
        End Set
    End Property


    Public Sub New()
        Me.listaProductos = New List(Of Producto)
    End Sub

    Public Sub New(ByVal id As String, ByVal nombre As String)
        Me.id = id
        Me.nombre = nombre
        Me.listaProductos = New List(Of Producto)
    End Sub

    Public Sub mostrarCategorias()
        Console.Write("TITULO : " & Me.nombre)
        Console.WriteLine()
    End Sub

End Class
