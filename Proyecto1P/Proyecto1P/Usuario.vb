Public Class Usuario
    Private _id As String
    Public Property id() As String
        Get
            Return _id
        End Get
        Set(ByVal value As String)
            _id = value
        End Set
    End Property
    Private _usuario As String
    Public Property usuario() As String
        Get
            Return _usuario
        End Get
        Set(ByVal value As String)
            _usuario = value
        End Set
    End Property
    Private _clave As String
    Public Property clave() As String
        Get
            Return _clave
        End Get
        Set(ByVal value As String)
            _clave = value
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

    Public Sub New()

    End Sub

    Sub New(usuario As String, clave As String)
        Me.usuario = usuario
        Me.clave = clave
    End Sub

    Sub New(id As String, usuario As String, clave As String)
        Me.usuario = usuario
        Me.clave = clave
        Me.id = id
    End Sub

    Public Sub New(ByVal usuario As String)
        Me.usuario = usuario
    End Sub

    Public Sub New(ByVal id As Integer, ByVal usuario As String, ByVal clave As Integer, ByVal nombre As String)
        Me.id = id
        Me.usuario = usuario
        Me.clave = clave
        Me.nombre = nombre
    End Sub

    Public Overridable Sub mostrarDatos()
        Console.WriteLine("ID :" & vbTab & Me.id)
        Console.WriteLine("CLAVE :  " & vbTab & Me.clave)
        Console.WriteLine("USUARIO :" & vbTab & Me.usuario)
        Console.WriteLine("NOMBRE :" & vbTab & Me.nombre)

    End Sub

End Class
