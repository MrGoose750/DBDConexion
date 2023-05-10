Public Class Ciudades

    'Atributos'
    Dim _id As Integer
    Dim _nombre As String
    Dim _estado As Boolean

    Public Sub New()

    End Sub

    'Constructor'
    Public Sub New(id As Integer, nombre As String, estado As Boolean)
        _id = id
        _nombre = nombre
        _estado = estado
    End Sub

    ''
    Public Property Id As Integer
        Get
            Return _id
        End Get
        Set(value As Integer)
            _id = value
        End Set
    End Property

    'Propiedades'
    Public Property Nombre As String
        Get
            Return _nombre
        End Get
        Set(value As String)
            _nombre = value
        End Set
    End Property

    Public Property Estado As Boolean
        Get
            Return _estado
        End Get
        Set(value As Boolean)
            _estado = value
        End Set
    End Property
End Class
