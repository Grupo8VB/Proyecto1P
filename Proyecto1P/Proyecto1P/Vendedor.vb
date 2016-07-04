Public Class Vendedor : Inherits Usuario

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(ByVal usuario As String)
        MyBase.New(usuario)
    End Sub

    Sub New(id As String, usuario As String, clave As String)
        MyBase.New(id, usuario, clave)
    End Sub

    Public Sub New(ByVal id As String, ByVal usuario As String, ByVal clave As String, ByVal nombre As String)
        MyBase.New(id, usuario, clave, nombre)
    End Sub

    Public Sub mostrarPersona()
        MyBase.mostrarDatos()
    End Sub

    Sub New(usuario As String, clave As String)
        MyBase.New(usuario, clave)
    End Sub

End Class
