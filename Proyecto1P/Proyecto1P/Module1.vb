Imports System.Xml

Module Module1

    Dim path As String = "C:\Users\Galo\Desktop\ROSA\ESPOL 2016\Visual\"
    Dim xmlDoc As New XmlDocument()

    Dim administradores As List(Of Administrador) = New List(Of Administrador)
    Dim vendedores As List(Of Vendedor) = New List(Of Vendedor)

    Dim usuarioEnUso As String
    Dim claveEnUso As String

    Sub Main()

        Console.Title = "SISTEMA DE FACTURACION "
        Console.ForegroundColor = ConsoleColor.Yellow
        xmlDoc.Load(path + "sistemaFacturacion.xml")

        cargarUsuarios()
        iniciarSesion()

        Console.ReadLine()

        ''xmlDoc.Load(pathW)
        ''Dim raiz As XmlNodeList = xmlDoc.GetElementsByTagName("collection")
        ''For Each nodo As XmlNode In raiz
        '    Console.WriteLine("Nodo: " & nodo.Name & " attr:" & nodo.Attributes(0).Value)
        '    For Each pelicula As XmlNode In nodo.ChildNodes
        '        Console.WriteLine("Nodo: " & pelicula.Name & " attr:" & pelicula.Attributes(0).Value)
        'dim p as Pelicula = new Pelicula(....)
        'çoleccion.peliculas.add(p)
        'Dim rented As XmlElement = xmlDoc.CreateElement("rented")
        'rented.InnerText = "unkown"
        'pelicula.AppendChild(rented)

        'generacion del numero
        'Next

        ''nodo.AppendChild(CrearCategoria(xmlDoc))

        ''Next

        'Escribir en un archivo distinto
        ''xmlDoc.Save(pathW)
        'Dim xmlFile As XmlTextWriter = New XmlTextWriter(pathW, Nothing)
        'xmlFile.Formatting = Formatting.Indented
        'xmlDoc.WriteContentTo(xmlFile)
        'xmlFile.Close()

        ''Console.ReadLine()

    End Sub

    Sub cargarUsuarios()
        Dim nodoPrincipal As XmlNodeList = xmlDoc.GetElementsByTagName("usuarios")
        Dim id As String = ""
        Dim clave As String
        Dim usuario As String
        'Dim id As String
        Dim administrador As Administrador
        Dim vendedor As Vendedor


        Dim cont As Integer = 0

        For Each nodo As XmlNode In nodoPrincipal
            For Each nodoUsuario As XmlNode In nodo.ChildNodes
                For Each nodoAdmin As XmlNode In nodoUsuario
                    If nodoAdmin.Name = "administrador" Then
                        usuario = nodoAdmin.Attributes(1).Value
                        clave = nodoAdmin.Attributes(2).Value
                        id = nodoAdmin.Attributes(0).Value
                        administrador = New Administrador(id, usuario, clave)
                        administradores.Add(administrador)
                    End If

                    If nodoAdmin.Name = "vendedor" Then
                        usuario = nodoAdmin.Attributes(1).Value
                        clave = nodoAdmin.Attributes(2).Value
                        id = nodoAdmin.Attributes(0).Value
                        vendedor = New Vendedor(id, usuario, clave)
                        vendedores.Add(vendedor)
                    End If

                Next
                Try

                Catch ex As Exception

                End Try

            Next
        Next
    End Sub

    Sub iniciarSesion()
        Console.Clear()
        Dim usuario As String
        Dim clave As String
        Console.WriteLine(vbTab & "INICIAR SESION " & vbCrLf)
        Console.Write("USUARIO :" & vbTab)
        usuario = Console.ReadLine()
        Console.Write("CLAVE :" & vbTab & vbTab)
        clave = Console.ReadLine()

        Dim acceso As Boolean = False

        For Each admin As Administrador In administradores
            If admin.clave = clave And admin.usuario = usuario Then
                acceso = True
                usuarioEnUso = admin.usuario
                claveEnUso = admin.clave
                Console.Clear()
                menuAdministradores()
                Exit For
            End If
        Next

        For Each asis As Vendedor In vendedores
            If asis.clave = clave And asis.usuario = usuario Then
                acceso = True
                usuarioEnUso = asis.usuario
                claveEnUso = asis.clave
                Console.Clear()
                menuVendedores()
                Exit For
            End If
        Next

        If acceso = False Then
            Console.WriteLine("VERIFIQUE QUE SU USUARIO Y CONTRASEÑA SEAN VALIDOS....")
            Console.ReadLine()
            iniciarSesion()
        End If

    End Sub
    Private Sub menuAdministradores()
        Console.Clear()
        Dim number = 0
        'Dim number2 = 0
        Dim opcion


        Do
            Console.WriteLine("")
            Console.WriteLine(vbTab & vbTab & "--- MENU ADMINISTRADORES --- ")
            Console.WriteLine("")
            Console.WriteLine("1. MENÚ CATEGORÍAS")
            Console.WriteLine("2. MENÚ PRODUCTOS")
            Console.WriteLine("3. MENÚ IMPUESTOS")
            Console.WriteLine("4. SALIR DEL SISTEMA")
            Console.WriteLine("")
            Console.Write(vbCrLf & "DIGITE OPCION DEL MENU:" & vbTab)

            opcion = Console.ReadLine()
            Try
                number = Byte.Parse(opcion)
                Select Case number
                    Case 1
                        Console.Clear()
                        Dim number1 = 0
                        Dim opcion1
                        Do
                            Console.WriteLine("")
                            Console.WriteLine(vbTab & vbTab & "--- MENU CATEGORÍAS --- ")
                            Console.WriteLine("")
                            Console.WriteLine("1. INGRESAR NUEVA CATEGORÍA")
                            Console.WriteLine("2. MODIFICAR UNA CATEGORÍA")
                            Console.WriteLine("3. SALIR DEL SISTEMA")
                            Console.WriteLine("")
                            Console.Write(vbCrLf & "DIGITE OPCION DEL MENU:" & vbTab)

                            opcion1 = Console.ReadLine()
                            Try
                                number1 = Byte.Parse(opcion)
                                Select Case number1
                                    Case 1
                                        Try
                                            'agregarCategoria()
                                            Console.WriteLine("LA CATEGORIA SE INGRESO CORRECTAMENTE")
                                            Console.ReadLine()
                                            menuAdministradores()
                                        Catch ex As Exception
                                            Console.WriteLine("LA CATEGORIA NO SE INGRESO CORRECTAMENTE")
                                            Console.ReadLine()
                                            menuAdministradores()
                                        End Try

                                    Case 2
                                        Try
                                            'modificarCategoria()
                                            Console.WriteLine("LA CATEGORIA SE MODIFICÓ CORRECTAMENTE")
                                            Console.ReadLine()
                                            menuAdministradores()
                                        Catch ex As Exception
                                            Console.WriteLine("LA CATEGORIA NO SE MODIFICÓ CORRECTAMENTE")
                                            Console.ReadLine()
                                            menuAdministradores()
                                        End Try

                                    Case 3
                                        Console.WriteLine("Saliendo del Sistema....")
                                        Exit Do
                                End Select
                                Exit Do
                            Catch ex1 As FormatException
                                Console.WriteLine(vbNewLine)
                                Console.WriteLine("------------Error de formato------------")

                            Catch ex2 As OverflowException
                                Console.WriteLine(vbNewLine)
                                Console.WriteLine("-----------Error rango de datos------------")

                            Catch ex As Exception
                                Console.WriteLine(vbNewLine)
                                Console.WriteLine("------------Error general--------------")
                            End Try
                            menuAdministradores()
                        Loop Until (number <> 3)

                    Case 2
                        Console.Clear()
                        Dim number2 = 0
                        Dim opcion2
                        Do
                            Console.WriteLine("")
                            Console.WriteLine(vbTab & vbTab & "--- MENU PRODUCTOS --- ")
                            Console.WriteLine("")
                            Console.WriteLine("1. INGRESAR NUEVO PRODUCTO")
                            Console.WriteLine("2. MODIFICAR UN PRODUCTO")
                            Console.WriteLine("3. SALIR DEL SISTEMA")
                            Console.WriteLine("")
                            Console.Write(vbCrLf & "DIGITE OPCION DEL MENU:" & vbTab)

                            opcion2 = Console.ReadLine()
                            Try
                                number2 = Byte.Parse(opcion)
                                Select Case number2
                                    Case 1
                                        Try
                                            'agregarProducto()
                                            Console.WriteLine("EL PRODUCTO SE INGRESO CORRECTAMENTE")
                                            Console.ReadLine()
                                            menuAdministradores()
                                        Catch ex As Exception
                                            Console.WriteLine("EL PRODUCTO NO SE INGRESO CORRECTAMENTE")
                                            Console.ReadLine()
                                            menuAdministradores()
                                        End Try

                                    Case 2
                                        Try
                                            'modificarProducto()
                                            Console.WriteLine("EL PRODUCTO SE MODIFICÓ CORRECTAMENTE")
                                            Console.ReadLine()
                                            menuAdministradores()
                                        Catch ex As Exception
                                            Console.WriteLine("EL PRODUCTO NO SE MODIFICÓ CORRECTAMENTE")
                                            Console.ReadLine()
                                            menuAdministradores()
                                        End Try

                                    Case 3
                                        Console.WriteLine("Saliendo del Sistema....")
                                        Exit Do
                                End Select
                                Exit Do
                            Catch ex1 As FormatException
                                Console.WriteLine(vbNewLine)
                                Console.WriteLine("------------Error de formato------------")

                            Catch ex2 As OverflowException
                                Console.WriteLine(vbNewLine)
                                Console.WriteLine("-----------Error rango de datos------------")

                            Catch ex As Exception
                                Console.WriteLine(vbNewLine)
                                Console.WriteLine("------------Error general--------------")
                            End Try
                            menuAdministradores()
                        Loop Until (number <> 3)

                    Case 3
                        Console.Clear()
                        Dim number3 = 0
                        Dim opcion3
                        Do
                            Console.WriteLine("")
                            Console.WriteLine(vbTab & vbTab & "--- MENU IMPUESTOS --- ")
                            Console.WriteLine("")
                            Console.WriteLine("1. MODIFICAR IMPUESTO")
                            Console.WriteLine("2. IVA POR TIPO DE PAGO")
                            Console.WriteLine("3. IVA POR PROVINCIA")
                            Console.WriteLine("4. SALIR DEL SISTEMA")
                            Console.WriteLine("")
                            Console.Write(vbCrLf & "DIGITE OPCION DEL MENU:" & vbTab)

                            opcion3 = Console.ReadLine()
                            Try
                                number3 = Byte.Parse(opcion)
                                Select Case number3
                                    Case 1

                                    Case 2

                                    Case 3

                                    Case 4
                                        Console.WriteLine("Saliendo del Sistema....")
                                        Exit Do
                                End Select
                                Exit Do
                            Catch ex1 As FormatException
                                Console.WriteLine(vbNewLine)
                                Console.WriteLine("------------Error de formato------------")

                            Catch ex2 As OverflowException
                                Console.WriteLine(vbNewLine)
                                Console.WriteLine("-----------Error rango de datos------------")

                            Catch ex As Exception
                                Console.WriteLine(vbNewLine)
                                Console.WriteLine("------------Error general--------------")
                            End Try
                            menuAdministradores()
                        Loop Until (number <> 4)

                    Case 4
                        Console.WriteLine("Saliendo del Sistema....")
                        Exit Do
                End Select
                Exit Do
            Catch ex1 As FormatException
                Console.WriteLine(vbNewLine)
                Console.WriteLine("------------Error de formato------------")

            Catch ex2 As OverflowException
                Console.WriteLine(vbNewLine)
                Console.WriteLine("-----------Error rango de datos------------")

            Catch ex As Exception
                Console.WriteLine(vbNewLine)
                Console.WriteLine("------------Error general--------------")
            End Try
            menuAdministradores()
        Loop Until (number <> 4)
    End Sub



    Sub menuVendedores()

        Console.Clear()
        Dim number = 0
        Dim opcion
        Do
            Console.WriteLine(vbCrLf & vbTab & vbTab & "MENU VENDEDORES:" & vbCrLf)
            Console.WriteLine("1. INGRESAR FACTURA")
            Console.WriteLine("2. LISTAR PRODUCTOS")
            Console.WriteLine("3. BUSQUEDA POR PRODUCTOS")
            Console.WriteLine("4. SALIR DEL SISTEMA")
            Console.Write(vbCrLf & "DIGITE OPCION DEL MENU:" & vbTab)
            opcion = Console.ReadLine()
            Try
                number = Byte.Parse(opcion)
                Select Case number
                    Case 1
                        Try
                            'ingresarFactura()
                            Console.WriteLine("LA FACTURA SE INGRESO CORRECTAMENTE")
                            Console.ReadLine()
                            menuVendedores()
                        Catch ex As Exception
                            Console.WriteLine("LA FACTURA NO SE INGRESO CORRECTAMENTE")
                            Console.ReadLine()
                            menuVendedores()
                        End Try
                        Exit Do
                    Case 2
                        'listarProductos()
                        Exit Do
                    Case 3
                        Console.Clear()
                        'busquedaPorProducto()
                        Exit Do
                    Case 4
                        Console.WriteLine(vbCrLf & "SALIENDO DEL SISTEMA......")
                        Exit Do
                End Select
                Exit Do

            Catch ex1 As FormatException

                Console.WriteLine("------------Error de formato------------")

            Catch ex2 As OverflowException
                Console.WriteLine(vbNewLine)
                Console.WriteLine("-----------Error rango de datos------------")

            Catch ex As Exception
                Console.WriteLine("Aqui")
                Console.WriteLine("------------Error general--------------")

            End Try
            menuVendedores()
        Loop Until (number <> 4)

    End Sub


End Module
