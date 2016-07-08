﻿Imports System.Xml

Module Module1

    Dim path As String = "C:\Users\Alvaro\Documents\Visual Studio 2015\Projects\Proyecto1P\"
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

        For Each vendedor As Vendedor In vendedores
            If vendedor.clave = clave And vendedor.usuario = usuario Then
                acceso = True
                usuarioEnUso = vendedor.usuario
                claveEnUso = vendedor.clave
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
                            ingresarFactura()
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

    Private Sub ingresarFactura()
        Dim Generator As System.Random = New System.Random()

        Dim factu As XmlElement = xmlDoc.CreateElement("facturas")
        factu.SetAttribute("title", "Nueva factura" & Generator.Next(1, 100))
        Dim fecha As XmlElement = xmlDoc.CreateElement("fechaEmision")
        Console.Write("Fecha Emision :" & vbTab)
        fecha.InnerText = Console.ReadLine()
        factu.AppendChild(fecha)
        Dim numFactura As XmlElement = xmlDoc.CreateElement("factura numFactura")
        Console.Write("Numero Factura :" & vbTab)
        numFactura.InnerText = Console.ReadLine()
        factu.AppendChild(numFactura)
        Dim datosEmpr As XmlElement = xmlDoc.CreateElement("datosEmpresa razonSocial")
        Console.Write("Razon social :" & vbTab)
        numFactura.InnerText = Console.ReadLine()
        factu.AppendChild(datosEmpr)
        Dim ruc As XmlElement = xmlDoc.CreateElement("ruc")
        Console.Write("RUC :" & vbTab)
        ruc.InnerText = Console.ReadLine()
        factu.AppendChild(ruc)
        Dim datoClienteid As XmlElement = xmlDoc.CreateElement("datosCliente id")
        Console.Write("Id Cliente :" & vbTab)
        datoClienteid.InnerText = Console.ReadLine()
        factu.AppendChild(datoClienteid)
        Dim nombreCliente As XmlElement = xmlDoc.CreateElement("nombre")
        Console.Write("Nombre Cliente :" & vbTab)
        nombreCliente.InnerText = Console.ReadLine()
        factu.AppendChild(nombreCliente)
        Dim provinciaCliente As XmlElement = xmlDoc.CreateElement("provincia")
        Console.Write("Provincia :" & vbTab)
        provinciaCliente.InnerText = Console.ReadLine()
        factu.AppendChild(provinciaCliente)
        Dim direccionCliente As XmlElement = xmlDoc.CreateElement("direccion")
        Console.Write("Direcccion :" & vbTab)
        direccionCliente.InnerText = Console.ReadLine()
        factu.AppendChild(direccionCliente)
        Dim idProducto As XmlElement = xmlDoc.CreateElement("idProducto")
        Console.Write("Id Producto :" & vbTab)
        idProducto.InnerText = Console.ReadLine()
        factu.AppendChild(idProducto)
        Dim cantidad As XmlElement = xmlDoc.CreateElement("cantidad")
        Console.Write("cantidad :" & vbTab)
        cantidad.InnerText = Console.ReadLine()
        factu.AppendChild(cantidad)
        Dim nombreProd As XmlElement = xmlDoc.CreateElement("nombreProducto")
        Console.Write("Nombre producto :" & vbTab)
        nombreProd.InnerText = Console.ReadLine()
        factu.AppendChild(nombreProd)
        Dim precioUni As XmlElement = xmlDoc.CreateElement("precioUnitario")
        Console.Write("Precio Unitario :" & vbTab)
        precioUni.InnerText = Console.ReadLine()
        factu.AppendChild(precioUni)
        Dim precioTot As XmlElement = xmlDoc.CreateElement("precioTotal")
        Console.Write("Precio total :" & vbTab)
        precioTot.InnerText = Console.ReadLine()
        factu.AppendChild(precioTot)
        Dim subtotal As XmlElement = xmlDoc.CreateElement("subtotal")
        Console.Write("Subtotal :" & vbTab)
        subtotal.InnerText = Console.ReadLine()
        factu.AppendChild(subtotal)
        If provinciaCliente.InnerText = Console.ReadLine = "Manabi" Or "Esmeraldas" Then
            Dim porcentajeiva As XmlElement = xmlDoc.CreateElement("porcentaIva")
            porcentajeiva.InnerText = 1.12
            porcentajeiva.InnerText = Console.ReadLine()
            factu.AppendChild(porcentajeiva)
            Dim importeiva As XmlElement = xmlDoc.CreateElement("precioUnitario")
            importeiva.InnerText = porcentajeiva.InnerText * subtotal.InnerText = Console.ReadLine()
            importeiva.InnerText = Console.ReadLine()
            factu.AppendChild(importeiva)
        Else
            Dim porcentajeiva As XmlElement = xmlDoc.CreateElement("porcentaIva")
            porcentajeiva.InnerText = 1.14
            porcentajeiva.InnerText = Console.ReadLine()
            factu.AppendChild(porcentajeiva)
            Dim importeiva As XmlElement = xmlDoc.CreateElement("precioUnitario")
            importeiva.InnerText = porcentajeiva.InnerText * subtotal.InnerText = Console.ReadLine()
            importeiva.InnerText = Console.ReadLine()
            factu.AppendChild(importeiva)
        End If

        Dim tipoPago As XmlElement = xmlDoc.CreateElement("tipoPago")
        Console.Write("Tipo de pago :" & vbTab)
        tipoPago.InnerText = Console.ReadLine()
        factu.AppendChild(tipoPago)





        'Console.Write("USUARIO :" & vbTab)
        'Usuario = Console.ReadLine()

        'Dim formato As XmlElement = xmlDoc.CreateElement("format")
        'formato.InnerText = "Bluray"
        'peli.AppendChild(formato)

        'Dim rating As XmlElement = xmlDoc.CreateElement("rating")
        'rating.InnerText = "PG"
        'peli.AppendChild(rating)

        'Dim stars As XmlElement = xmlDoc.CreateElement("stars")
        'stars.InnerText = "4"
        'peli.AppendChild(stars)

        'Dim description As XmlElement = xmlDoc.CreateElement("description")
        'description.InnerText = "Hola mundo"
        'peli.AppendChild(description)


        Return

    End Sub
End Module
