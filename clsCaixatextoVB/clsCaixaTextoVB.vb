Imports System
Imports System.Globalization
Imports System.Drawing
Imports System.Windows.Forms

''' <summary>
''' Based on the text below, but added new functions:
''' Baseado no texto abaixo, mas adicionadas novas funções:
'''
''' How to: Control User Input in a Numeric Text Box
''' https://msdn.microsoft.com/en-us/library/vstudio/dd183783(v=vs.90).aspx
'''
''' Como: Criar um controle de usuário de entrada em uma caixa de texto numérica
''' https://msdn.microsoft.com/pt-br/library/ms229644(v=VS.90).aspx
''' </summary>
''' <remarks></remarks>
Public Class clsCaixaTextoVB
    Inherits TextBox

#Region "Atributos"

    Public Enum ListaOpcoes
        Nao = 0             'No
        Sim = 1             'Yes
    End Enum

    Public Enum Lista
        Normal = 0          'Normal
        Numero = 1          'Number
        Letra = 2           'Letter
    End Enum

    Public Enum CursorInicial
        Inicio = 0          'Start
        Fim = 1             'End
        Completo = 2        'Complete
    End Enum

    Private Structure VariaveisP
        Dim blnPermitirEspaco As Boolean
        Dim blnPermitirSinalNegativo As Boolean
        Dim strSeparadorDecimal As String
        Dim oleCorFundoDepois As Color
        Dim oleCorFundoDurante As Color
        Dim oleCorLetraDepois As Color
        Dim oleCorLetraDurante As Color
        Dim strTexto As String
        Dim oBloqueado As ListaOpcoes
        Dim strTipo As Lista
        Dim strPosicaoCursor As CursorInicial
    End Structure

    Dim Variaveis As VariaveisP

    Private strTentativaBloqueada As String

#End Region

#Region "Métodos"

    ''' <summary>
    ''' Shortcut to create a constructor, type: "Public Sub New()
    ''' Atalho para criar um construtor, digite: "Public Sub New()"
    ''' This constructor "pre-configures" the inheritance to clsCaixatexto.
    ''' Este construtor "pré-configura" a herança a clsCaixatexto.
    ''' If you want the "boot" of a different, change below. "
    ''' Se você quiser que a caixa "inicialize" de uma fora diferente, mude abaixo."
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        Variaveis.blnPermitirEspaco = True
        Variaveis.blnPermitirSinalNegativo = True
        BackColor = Color.LightCyan
        Variaveis.oleCorFundoDurante = Color.LightYellow
        Variaveis.oleCorFundoDepois = Color.PaleTurquoise
        Variaveis.strSeparadorDecimal = ","
    End Sub

#End Region

#Region "Eventos"

    ''' <summary>
    ''' Restricts the entry of characters to digits, the space, the negative sign, the decimal
    ''' Restringe a entrada de caracteres para dígitos, o espaço, o sinal negativo, o ponto 
    ''' point, and editing keys (rewind).
    ''' decimal, e edição de teclas (retrocesso).
    ''' Put the box in Uppercase (upper case) or lowercase (lower case) automatically.
    ''' Coloca a Caixa em Maiúscula (Caixa Alta) ou Minúscula (Caixa Baixa) Automaticamente.
    ''' </summary>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Overrides Sub OnKeyPress(e As KeyPressEventArgs)
        MyBase.OnKeyPress(e)

        Dim numberFormatInfo As NumberFormatInfo = System.Globalization.CultureInfo.CurrentCulture.NumberFormat
        Dim SeparadorDecimal As String = numberFormatInfo.NumberDecimalSeparator
        Dim SeparadorGrupo As String = numberFormatInfo.NumberGroupSeparator
        Dim SinalNegativo As String = numberFormatInfo.NegativeSign
        Dim keyInput As String = e.KeyChar.ToString()
        strTentativaBloqueada = ""

        '#Region "Bloqueado"
        If Variaveis.oBloqueado = ListaOpcoes.Sim Then
            e.Handled = True
            strTentativaBloqueada = "Propriedade Bloqueado"
        End If
        '#End Region

        '#Region "PermiteEspaco"
        If Not (Variaveis.blnPermitirEspaco) Then

            If e.KeyChar = " " Then
                e.Handled = True
                strTentativaBloqueada = "Espaço Bloqueado"
            End If

        End If
        '#End Region

        '#Region "Numero Letra"
        If Variaveis.strTipo = Lista.Numero Then

            If Not ([Char].IsNumber(e.KeyChar) OrElse e.KeyChar = "-" OrElse keyInput.Equals(Variaveis.strSeparadorDecimal) OrElse e.KeyChar = ControlChars.Back) Then
                e.Handled = True
                strTentativaBloqueada = "Somente Números"
            End If

            If Not (Variaveis.blnPermitirSinalNegativo) Then

                If e.KeyChar = "-" Then
                    e.Handled = True
                    strTentativaBloqueada = "Não Permite Negativo"
                End If

            End If

        ElseIf Variaveis.strTipo = Lista.Letra Then

            If Char.IsNumber(e.KeyChar) Then
                e.Handled = True
                strTentativaBloqueada = "Somente Letras"
            End If

        End If
        '#End Region

    End Sub

    ''' <summary>
    ''' Positions the alignment of Letter, the background colors and the font into the box.
    ''' Posiciona o Alinhamento da Letra, as cores de fundo e de letra ao entrar na caixa.
    ''' </summary>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Overrides Sub OnEnter(e As EventArgs)
        MyBase.OnEnter(e)
        MyBase.BackColor = Variaveis.oleCorFundoDurante
        MyBase.ForeColor = Variaveis.oleCorLetraDurante
    End Sub

    ''' <summary>
    ''' Positions the alignment of Letter, background colors and fonts when you leave in the box.
    ''' Posiciona o Alinhamento da Letra, as cores de fundo e de letra ao sair na caixa.
    ''' </summary>
    ''' <param name="e"></param>
    Protected Overrides Sub OnLeave(e As System.EventArgs)
        BackColor = Variaveis.oleCorFundoDepois
        ForeColor = Variaveis.oleCorLetraDepois
    End Sub

    ''' <summary>
    ''' To receive the focus positions the cursor within the text box.
    ''' Ao receber o foco posiciona o cursor dentro da caixa de texto.
    ''' </summary>
    ''' <param name="e"></param>
    Protected Overrides Sub OnGotFocus(e As EventArgs)
        MyBase.OnGotFocus(e)

        '#Region "Posição Cursor"
        If Variaveis.strPosicaoCursor = CursorInicial.Inicio Then
            MyBase.SelectionStart = 0
        ElseIf Variaveis.strPosicaoCursor = CursorInicial.Fim Then
            MyBase.SelectionStart = MyBase.TextLength
        Else
            MyBase.SelectionStart = 0
            MyBase.SelectionLength = MyBase.TextLength
        End If
        '#End Region

    End Sub

    ''' <summary>
    ''' ToolboxBitmapAttribute
    ''' ToolboxBitmapAttribute Class
    ''' https://msdn.microsoft.com/en-us/library/system.drawing.toolboxbitmapattribute(v=vs.110).aspx
    ''' </summary>
    Protected Overrides Sub InitLayout()
        MyBase.InitLayout()
    End Sub

    ''' <summary>
    ''' Returns an integer value
    ''' Retorna um valor inteiro
    ''' </summary>
    ''' <returns>O valor inteiro</returns>
    Public Function RetornaInteiro() As Int32
        Return ValorInteiro
    End Function

    ''' <summary>
    ''' Checks if the passed text "is numeric?"
    ''' Verifica se o texto passado "É Numérico?"
    ''' </summary>
    ''' <returns>Returns: true or False - Retorna: Verdadeiro ou False</returns>
    Public Function ENumerico() As [Boolean]
        Dim output As Single
        Return Single.TryParse(Me.Text, output)
    End Function

#End Region

#Region "Propriedades"
    ''' <summary>
    ''' Returns an integer value
    ''' Retorna o valor inteiro.
    ''' </summary>
    Private ReadOnly Property ValorInteiro() As Int32

        Get

            If ENumerico() Then
                Return Convert.ToInt32(Me.ValorDecimal)
            Else
                Return 0
            End If

        End Get

    End Property

    ''' <summary>
    ''' Returns a decimal value
    ''' Retorna o valor decimal.
    ''' </summary>
    Private ReadOnly Property ValorDecimal() As [Decimal]

        Get

            If ENumerico() Then
                Return [Decimal].Parse(Me.Text)
            Else
                Return 0
            End If

        End Get

    End Property

    ''' <summary>
    ''' Checks if space allows
    ''' Verifica se permite espaço
    ''' </summary>
    Public Property PermitirEspaco() As [Boolean]

        Get
            Return Me.Variaveis.blnPermitirEspaco
        End Get

        Set(value As [Boolean])
            Me.Variaveis.blnPermitirEspaco = value
        End Set

    End Property

    ''' <summary>
    ''' Check allowed negative sinal.
    ''' Verifica se permite sinal negativo.
    ''' </summary>
    Public Property PermitirSinalNegativo() As [Boolean]

        Get
            Return Me.Variaveis.blnPermitirSinalNegativo
        End Get

        Set(value As [Boolean])
            Me.Variaveis.blnPermitirSinalNegativo = value
        End Set

    End Property

    ''' <summary>
    ''' Checks the decimal separator.
    ''' Verifica separador decimal.
    ''' </summary>
    Public Property SeparadorDecimal() As [String]

        Get
            Return Me.Variaveis.strSeparadorDecimal
        End Get

        Set(value As [String])
            Me.Variaveis.strSeparadorDecimal = value
        End Set

    End Property

    ''' <summary>
    ''' Background color During the pointer
    ''' Cor de Fundo Durante o Cursor
    ''' </summary>
    Public Property CorFundoDurante() As Color

        Get
            Return Variaveis.oleCorFundoDurante
        End Get

        Set(value As Color)
            Variaveis.oleCorFundoDurante = value
        End Set

    End Property

    ''' <summary>
    ''' Background Color After the Cursor
    ''' Cor de Fundo Depois do Cursor
    ''' </summary>
    Public Property CorFundoDepois() As Color

        Get
            Return Variaveis.oleCorFundoDepois
        End Get

        Set(value As Color)
            Variaveis.oleCorFundoDepois = value
        End Set

    End Property

    ''' <summary>
    ''' Color the Letter During the Cursor
    ''' Cor da Letra Durante o Cursor
    ''' </summary>
    Public Property CorLetraDurante() As Color

        Get
            Return Variaveis.oleCorLetraDurante
        End Get

        Set(value As Color)
            Variaveis.oleCorLetraDurante = value
        End Set

    End Property

    ''' <summary>
    ''' Color the letter After the Cursor
    ''' Cor da Letra Depois o Cursor
    ''' </summary>
    Public Property CorLetraDepois() As Color

        Get
            Return Variaveis.oleCorLetraDepois
        End Get

        Set(value As Color)
            Variaveis.oleCorLetraDepois = value
        End Set

    End Property

    ''' <summary>
    ''' Stores Default Text
    ''' Armazena Texto Padrão
    ''' </summary>
    Public Property Texto() As [String]

        Get
            Return Variaveis.strTexto
        End Get

        Set(value As [String])
            Variaveis.strTexto = value
        End Set

    End Property

    ''' <summary>
    ''' Block Check
    ''' Verifica Bloqueio
    ''' </summary>
    Public Property Bloqueado() As ListaOpcoes

        Get
            Return Variaveis.oBloqueado
        End Get

        Set(value As ListaOpcoes)
            Variaveis.oBloqueado = value
        End Set

    End Property

    ''' <summary>
    ''' Type of Text: Normal, Number or letter.
    ''' Tipo do Texto: Normal, Número ou Letra.
    ''' </summary>
    Public Property Tipo() As Lista

        Get
            Return Variaveis.strTipo
        End Get

        Set(value As Lista)
            Variaveis.strTipo = value
        End Set

    End Property

    ''' <summary>
    ''' Cursor Position to receive focus.
    ''' Posição do Cursor ao receber foco.
    ''' </summary>
    Public Property PosicaoCursor() As CursorInicial

        Get
            Return Variaveis.strPosicaoCursor
        End Get

        Set(value As CursorInicial)
            Variaveis.strPosicaoCursor = value
        End Set

    End Property

    ''' <summary>
    ''' Read-only Variable.
    ''' Variável somente de leitura.
    ''' Returns the type of lock, if blocked.
    ''' Retorna o tipo de bloqueio, caso seja bloqueado.
    ''' </summary>
    Public ReadOnly Property TentativaBloqueada() As String

        Get
            Return strTentativaBloqueada
        End Get

    End Property

#End Region

End Class
