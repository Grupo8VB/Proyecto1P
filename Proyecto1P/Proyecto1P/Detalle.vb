﻿Imports System.Xml

Public Class Detalle
    Protected _idProducto As String

    Property IdProducto() As String
        Get
            Return _idProducto
        End Get
        Set(value As String)
            _idProducto = value
        End Set
    End Property

    Protected _cantidad As Integer

    Property Cantidad() As Integer
        Get
            Return _cantidad
        End Get
        Set(value As Integer)
            _cantidad = value
        End Set
    End Property

    Protected _nombreProducto As String

    Property NombreProducto() As String
        Get
            Return _nombreProducto
        End Get
        Set(value As String)
            _nombreProducto = value
        End Set
    End Property


    Protected _valorUnitario As Double

    Property ValorUnitario() As Double
        Get
            Return _valorUnitario 
        End Get
        Set(value As Double)
            _valorUnitario = value
        End Set
    End Property

    Protected _valorTotal As Double
    Property ValorTotal() As Double
        Get
            Return _valorTotal 
        End Get
        Set(value As Double)
            _valorTotal = value
        End Set
    End Property

    Protected _subTotal As Double
    Property SubTotal() As Double
        Get
            Return _subTotal
        End Get
        Set(value As Double)
            _subTotal = value
        End Set
    End Property

    Protected _porcentajeIva As Integer
    Property PorcentajeIva() As Integer
        Get
            Return _porcentajeIva
        End Get
        Set(value As Integer)
            _porcentajeIva = value
        End Set
    End Property

    Protected _importeIva As Double

    Property ImporteIva() As Double
        Get
            Return _importeIva
        End Get
        Set(value As Double)
            _importeIva = value
        End Set
    End Property

    Protected _importeTotal As Double

    Property ImporteTotal() As Double
        Get
            Return _importeTotal
        End Get
        Set(value As Double)
            _importeTotal = value
        End Set
    End Property

    Protected _tipoDePago As String
    Property TipoDePago() As String
        Get
            Return _tipoDePago
        End Get
        Set(value As String)
            _tipoDePago = value
        End Set
    End Property

    Protected _porcentajeDevolucion As Integer
    Property PorcentajeDevolucion() As Integer
        Get
            Return _porcentajeDevolucion
        End Get
        Set(value As Integer)
            _porcentajeDevolucion = value
        End Set
    End Property

    Protected _importeDevolucion As Integer
    Property ImporteDecolucion() As Integer
        Get
            Return _importeDevolucion
        End Get
        Set(value As Integer)
            _importeDevolucion = value
        End Set
    End Property

    Protected _precioTotal As Double
    Property PrecioTotal() As Double
        Get
            Return _precioTotal
        End Get
        Set(value As Double)
            _precioTotal = value
        End Set
    End Property



    'Public Sub New(ciudad As String, provincia As String, descripcion As Integer, cantidad As Integer, precioUnitario As Double, precioTotal As Double, subtotal As Double, descuento As Double, iva As Double, tipoPago As String)

    '    Me._ciudad = ciudad
    '    Me._provincia = provincia
    '    Me._descripcion = descripcion
    '    Me._cantidad = cantidad
    '    Me._precioUnitario = precioUnitario
    '    Me._precioTotal = precioTotal
    '    Me._subTotal = subtotal
    '    Me._descuento = descuento
    '    Me._Iva = iva
    '    Me._tipoDePago = tipoPago
    '    'arreglo productos

    'End Sub


End Class
