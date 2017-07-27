Imports System
Imports System.Threading
Imports System.IO.Ports
Imports System.ComponentModel

Public Class Form1
    Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        If Button1.Text = "Connect" Then
            Try
                SerialPort1.PortName = ComboBox1.Text
                SerialPort1.BaudRate = ComboBox2.Text
                SerialPort1.Open()
                Button2.Enabled = True
                Button3.Enabled = True
                TextBox1.Enabled = True
                TextBox2.Enabled = True
                Button1.Text = "Disconnect"
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        Else
            Try
                SerialPort1.Close()
                Button2.Enabled = False
                Button3.Enabled = False
                TextBox1.Enabled = False
                TextBox2.Enabled = False
                Button1.Text = "Connect"
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub
    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        Dim myPort As Array
        myPort = IO.Ports.SerialPort.GetPortNames()
        ComboBox1.Items.AddRange(myPort)
        ComboBox2.SelectedIndex = 0

        Button2.Enabled = False
        Button3.Enabled = False
        TextBox1.Enabled = False
        TextBox2.Enabled = False
    End Sub

    Private Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button2.Click
        'command1
        'SerialPort1.Write("test1" & vbCr)
        SerialPort1.WriteLine(TextBox1.Text)

    End Sub

    Private Sub Button3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button3.Click
        'command2
        'SerialPort1.Write("test2" & vbCr)
        SerialPort1.WriteLine(TextBox2.Text)
    End Sub
End Class
