﻿Public Class Form1


    Private Sub AçToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AçToolStripMenuItem.Click
        Try
            OpenFileDialog1.Filter = "JPG Dosyaları (*.jpg)|*.jpg|JPEG Dosyaları (*.jpeg)|*.jpeg|Hepsi (*.*)|*.*"
            OpenFileDialog1.ShowDialog()
            Me.Text = OpenFileDialog1.FileName.ToString

            Try
                PictureBox1.ImageLocation = Me.Text

            Catch ex As Exception

            End Try

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        System.Threading.Thread.Sleep(1000)

        Anla()




    End Sub

    Private Sub formtik(sender As Object, e As EventArgs) Handles MyBase.Click
        '   Dim renk As New Color
        '  renk = Color.FromArgb(0, 0, 0, 0)
        Try
            Dim Harita As Bitmap
            Harita = CType(PictureBox1.Image, Bitmap)
            MessageBox.Show(Harita.GetPixel(0, 0).ToString)
            MessageBox.Show(Harita.GetPixel(0, 1).ToString)
        Catch ex As Exception

        End Try


    End Sub

    Private Sub Ciz(ByVal Durum As Boolean, ByVal heightt As Integer, ByVal widthh As Integer)
        If (Durum = True) Then
            ' ÜSTÜNE
            Dim x As Bitmap
            x = CType(PictureBox1.Image, Bitmap)
            Dim i As Integer = 0
            Dim k As Integer = 0
            Dim rnd As New Random
            Try
                Try
                    While (k < widthh)
                        i = 0
                        Try
                            While (i < heightt)
                                x.SetPixel(i, k, Color.FromArgb(255, rnd.Next(255), rnd.Next(255), rnd.Next(255)))
                                i += 1
                            End While
                        Catch ex As Exception
                        End Try
                        k += 1
                    End While
                Catch ex As Exception
                End Try
            Catch ex As Exception
            End Try


            PictureBox1.Image = x

        Else
            'SIFIRDAN
            Dim x As New Bitmap(Convert.ToInt32(ToolStripTextBox1.Text), Convert.ToInt32(ToolStripTextBox2.Text))
            Dim i As Integer = 0
            Dim k As Integer = 0
            Dim rnd As New Random

            Try
                Try
                    While (k < widthh)
                        i = 0
                        Try
                            While (i < heightt)
                                x.SetPixel(i, k, Color.FromArgb(255, rnd.Next(255), rnd.Next(255), rnd.Next(255)))
                                i += 1

                            End While

                        Catch ex As Exception
                        End Try
                        k += 1

                    End While
                Catch ex As Exception
                End Try
            Catch ex As Exception
            End Try


            PictureBox1.Image = x
        End If
    End Sub
    Private Sub ÇizToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ÇizToolStripMenuItem.Click
        Try
            Ciz(False, Convert.ToInt32(ToolStripTextBox1.Text), Convert.ToInt32(ToolStripTextBox2.Text))
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub Anla()
        Try
            Dim h As Integer = CType(PictureBox1.Image, Bitmap).Size.Height
            Dim w As Integer = CType(PictureBox1.Image, Bitmap).Size.Width
            MessageBox.Show("Yükseklik: " + h.ToString + " , " + "Genişlik: " + w.ToString)

        Catch ex As Exception

        End Try
    End Sub



    Private Sub ÜstüneÇizToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ÜstüneÇizToolStripMenuItem.Click
        Ciz(True, Convert.ToInt32(ToolStripTextBox1.Text), Convert.ToInt32(ToolStripTextBox2.Text))
    End Sub


    Private Sub OpenFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk
        Anla()

    End Sub

    Private Sub KaydetToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles KaydetToolStripMenuItem1.Click
        Try
            SaveFileDialog1.Filter = "JPG Dosyaları (*.jpg)|*.jpg|JPEG Dosyaları (*.jpeg)|*.jpeg"
            SaveFileDialog1.ShowDialog()
            Dim FileToSaveAs As String = System.IO.Path.Combine(My.Computer.FileSystem.SpecialDirectories.Temp, SaveFileDialog1.FileName)
            PictureBox1.Image.Save(FileToSaveAs, System.Drawing.Imaging.ImageFormat.Jpeg)
        Catch ex As Exception

        End Try
    End Sub


    Private Sub TıkToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TıkToolStripMenuItem.Click
        If (PictureBox1.Visible = True) Then
            PictureBox1.Visible = False
            PictureBox2.Visible = True
        Else
            PictureBox1.Visible = True
            PictureBox2.Visible = False
        End If
    End Sub


    Private Sub KopyalaToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles KopyalaToolStripMenuItem1.Click
        Dim allthings As String = ""
        Dim x As Bitmap
        x = CType(PictureBox1.Image, Bitmap)
        Dim y As New Bitmap(PictureBox1.Image.Width, PictureBox1.Image.Height)
        MessageBox.Show("h:" + x.Height.ToString + " w:" + x.Width.ToString)
        Dim a, b As Integer
        a = 0
        b = 0
        Dim say As Integer = 0
        While (a < x.Width)
            b = 0

            While (b < x.Height)
                say += 1
                y.SetPixel(a, b, x.GetPixel(a, b))
                allthings = allthings + say.ToString + "-" + x.GetPixel(a, b).R.ToString + " " + x.GetPixel(a, b).G.ToString + " " + x.GetPixel(a, b).B.ToString + vbNewLine
                b += 1
            End While

            a = a + 1

        End While

        PictureBox2.Image = y
        RichTextBox1.Text = allthings



    End Sub

    Private Sub KaplaToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles KaplaToolStripMenuItem1.Click
        Try
            RichTextBox1.Text = ""
            Dim h As Integer = CType(PictureBox1.Image, Bitmap).Size.Height
            Dim w As Integer = CType(PictureBox1.Image, Bitmap).Size.Width
            Dim k As Integer = 0
            Dim i As Integer = 0
            Dim max As Integer = 0

            Dim r As New Random


            Try
                Try
                    While (k < h)
                        i = 0
                        Try
                            While (i < w)

                                CType(PictureBox1.Image, Bitmap).SetPixel(i, k, Color.FromArgb(255, r.Next(0, 255), r.Next(0, 255), r.Next(0, 255)))

                                i += 1
                            End While
                        Catch ex As Exception
                        End Try
                        PictureBox1.Refresh()
                        k += 1
                    End While
                Catch ex As Exception
                End Try
            Catch ex As Exception
            End Try
        Catch ex As Exception

        End Try
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click

    End Sub

    Private Sub TahminEtToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles TahminEtToolStripMenuItem1.Click
        RichTextBox1.Text = ""
        Dim h As Integer = CType(PictureBox1.Image, Bitmap).Size.Height
        Dim w As Integer = CType(PictureBox1.Image, Bitmap).Size.Width
        Dim k As Integer = 0
        Dim i As Integer = 0
        Dim max As Integer = 0
        Dim renk As Char
        Dim satir_kirmizi As Integer = 0
        Dim satir_yesil As Integer = 0
        Dim satir_mavi As Integer = 0
        Dim Satırbilgisi As String = ""

        Try
            Try
                While (k < h)
                    i = 0
                    Try

                        While (i < w)


                            Dim Anlık = CType(PictureBox1.Image, Bitmap).GetPixel(i, k)
                            Dim enbuyuk As Integer = 0
                            If (Anlık.R = Anlık.G And Anlık.G = Anlık.B And Anlık.R = Anlık.B) Then
                                If (Anlık.R > 100) Then
                                    'beyaz
                                    CType(PictureBox1.Image, Bitmap).SetPixel(i, k, Color.White)

                                Else
                                    'siyah
                                    CType(PictureBox1.Image, Bitmap).SetPixel(i, k, Color.Black)
                                End If
                            ElseIf (Anlık.R = Anlık.G) Then
                                ' Kırmızı yeşil = Sarı
                                CType(PictureBox1.Image, Bitmap).SetPixel(i, k, Color.Yellow)
                            ElseIf (Anlık.R = Anlık.B) Then
                                ' Kırmızı mavi = magenta
                                CType(PictureBox1.Image, Bitmap).SetPixel(i, k, Color.Magenta)
                            ElseIf (Anlık.G = Anlık.B) Then
                                ' Mavi yeşil = Cyan
                                CType(PictureBox1.Image, Bitmap).SetPixel(i, k, Color.Cyan)
                            Else

                                If (Anlık.R > enbuyuk) Then
                                    enbuyuk = Anlık.R
                                    renk = "r"
                                End If
                                If (Anlık.G > enbuyuk) Then
                                    enbuyuk = Anlık.G
                                    renk = "g"
                                End If
                                If (Anlık.B > enbuyuk) Then
                                    enbuyuk = Anlık.B
                                    renk = "b"
                                End If
                                If (renk = "r") Then
                                    CType(PictureBox1.Image, Bitmap).SetPixel(i, k, Color.FromArgb(255, enbuyuk, 0, 0))
                                    satir_kirmizi += 1
                                ElseIf (renk = "g") Then
                                    CType(PictureBox1.Image, Bitmap).SetPixel(i, k, Color.FromArgb(255, 0, enbuyuk, 0))
                                    satir_yesil += 1
                                ElseIf (renk = "b") Then
                                    CType(PictureBox1.Image, Bitmap).SetPixel(i, k, Color.FromArgb(255, 0, 0, enbuyuk))
                                    satir_mavi += 1
                                End If


                            End If




                            i += 1
                        End While
                    Catch ex As Exception
                    End Try
                    If (satir_kirmizi > satir_yesil And satir_kirmizi > satir_mavi) Then
                        Satırbilgisi = Satırbilgisi + "Satır: " + k.ToString + " Hakim Renk: " + satir_kirmizi.ToString + " renk ile Kırmızı" + vbNewLine
                    ElseIf (satir_mavi > satir_yesil And satir_mavi > satir_kirmizi) Then
                        Satırbilgisi = Satırbilgisi + "Satır: " + k.ToString + " Hakim Renk: " + satir_mavi.ToString + " renk ile Mavi" + vbNewLine
                    ElseIf (satir_yesil > satir_mavi And satir_yesil > satir_kirmizi) Then
                        Satırbilgisi = Satırbilgisi + "Satır: " + k.ToString + " Hakim Renk: " + satir_yesil.ToString + " renk ile Yeşil" + vbNewLine
                    ElseIf (satir_yesil = satir_kirmizi And satir_kirmizi = satir_mavi And satir_yesil = satir_mavi) Then
                        Satırbilgisi = Satırbilgisi + "Satır: " + k.ToString + " Hakim Renk: " + "??" + " renk ile Beyaz" + vbNewLine
                    ElseIf (satir_kirmizi = satir_mavi) Then
                        Satırbilgisi = Satırbilgisi + "Satır: " + k.ToString + " Hakim Renk: " + satir_kirmizi.ToString + " renk ile Magenta" + vbNewLine
                    ElseIf (satir_kirmizi = satir_yesil) Then
                        Satırbilgisi = Satırbilgisi + "Satır: " + k.ToString + " Hakim Renk: " + satir_kirmizi.ToString + " renk ile Sarı" + vbNewLine
                    ElseIf (satir_yesil = satir_mavi) Then
                        Satırbilgisi = Satırbilgisi + "Satır: " + k.ToString + " Hakim Renk: " + satir_yesil.ToString + " renk ile Cyan" + vbNewLine
                    Else
                        MessageBox.Show("Bir değişiklik var ; MAVİ: " + satir_mavi.ToString + " Kırmızı: " + satir_kirmizi.ToString + " Yeşil: " + satir_yesil.ToString)
                    End If
                    satir_yesil = 0
                    satir_kirmizi = 0
                    satir_mavi = 0
                    PictureBox1.Refresh()
                    k += 1
                End While
            Catch ex As Exception
            End Try
        Catch ex As Exception
        End Try
        RichTextBox1.Text = RichTextBox1.Text + Satırbilgisi + vbNewLine

        Dim gecicisatir As Integer = 0
        Dim gecicirenk As String = ""
        For Each satir In RichTextBox1.Lines
            Try
                If (Not satir = "") Then
                    gecicisatir = Convert.ToInt32(satir.Split("Hakim")(0).ToString.Split(":")(1).ToString.Trim)
                    If (satir.Contains("Yeşil")) Then
                        gecicirenk = "Yeşil"
                    ElseIf (satir.Contains("Mavi")) Then
                        gecicirenk = "Mavi"
                    ElseIf (satir.Contains("Kırmızı")) Then
                        gecicirenk = "Kırmızı"
                    ElseIf (satir.Contains("Beyaz")) Then
                        gecicirenk = "Beyaz"
                    ElseIf (satir.Contains("Cyan")) Then
                        gecicirenk = "Cyan"
                    ElseIf (satir.Contains("Magenta")) Then
                        gecicirenk = "Magenta"
                    ElseIf (satir.Contains("Sarı")) Then
                        gecicirenk = "Cyan"
                    End If


                    Try
                        i = 0
                        k = 0
                        While (k < h)
                            'satır satır
                            i = 0
                            If (k = gecicisatir) Then
                                If (gecicirenk = "Yeşil") Then
                                    While (i < w)
                                        'sütun
                                        CType(PictureBox1.Image, Bitmap).SetPixel(i, k, Color.Green)
                                        i += 1

                                    End While

                                ElseIf (gecicirenk = "Mavi") Then
                                    While (i < w)
                                        'sütun
                                        CType(PictureBox1.Image, Bitmap).SetPixel(i, k, Color.Blue)
                                        i += 1
                                    End While

                                ElseIf (gecicirenk = "Kırmızı") Then
                                    While (i < w)
                                        'sütun
                                        CType(PictureBox1.Image, Bitmap).SetPixel(i, k, Color.Red)
                                        i += 1
                                    End While

                                ElseIf (gecicirenk = "Cyan") Then
                                    While (i < w)
                                        'sütun
                                        CType(PictureBox1.Image, Bitmap).SetPixel(i, k, Color.Cyan)
                                        i += 1
                                    End While

                                ElseIf (gecicirenk = "Magenta") Then
                                    While (i < w)
                                        'sütun
                                        CType(PictureBox1.Image, Bitmap).SetPixel(i, k, Color.Magenta)
                                        i += 1
                                    End While

                                ElseIf (gecicirenk = "Sarı") Then
                                    While (i < w)
                                        'sütun
                                        CType(PictureBox1.Image, Bitmap).SetPixel(i, k, Color.Yellow)
                                        i += 1
                                    End While

                                ElseIf (gecicirenk = "Beyaz") Then
                                    While (i < w)
                                        'sütun
                                        CType(PictureBox1.Image, Bitmap).SetPixel(i, k, Color.White)
                                        i += 1
                                    End While
                                End If
                                'While (i < w)
                                '    CType(PictureBox1.Image, Bitmap).SetPixel(i, k, Color.Black)
                                '    i += 1
                                'End While
                            End If

                            k += 1
                        End While
                        PictureBox1.Refresh()

                        'CType(PictureBox1.Image, Bitmap).SetPixel(0, 0, Color.Black)
                    Catch ex As Exception

                    End Try

                End If

            Catch ex As Exception

            End Try
        Next

    End Sub

    Private Sub AnlaToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles AnlaToolStripMenuItem1.Click
        Anla()
    End Sub

    Private Sub KırmızıSüzgeçToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles KırmızıSüzgeçToolStripMenuItem.Click
        Dim aksiyon As New Form
        aksiyon.ShowIcon = False
        aksiyon.Text = "Kırmızı Süzgeç"

        Dim allthings As String = ""
        Dim x As Bitmap
        x = CType(PictureBox1.Image, Bitmap)
        Dim y As New Bitmap(PictureBox1.Image.Width, PictureBox1.Image.Height)

        Dim a, b As Integer
        a = 0
        b = 0
        Dim say As Integer = 0
        While (a < x.Width)
            b = 0

            While (b < x.Height)
                say += 1
                If (x.GetPixel(a, b).R > x.GetPixel(a, b).B And x.GetPixel(a, b).R > x.GetPixel(a, b).G) Then
                    y.SetPixel(a, b, Color.Red)
                Else
                    y.SetPixel(a, b, x.GetPixel(a, b))
                End If

                b += 1
            End While

            a = a + 1

        End While

        PictureBox2.Image = y
        aksiyon.BackgroundImage = y
        aksiyon.BackgroundImageLayout = ImageLayout.None
        aksiyon.Show()
    End Sub

    Private Sub MaviSkalaToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles MaviSkalaToolStripMenuItem1.Click
        Dim aksiyon As New Form
        aksiyon.ShowIcon = False
        aksiyon.Text = "Mavi Süzgeç"
        Dim allthings As String = ""
        Dim x As Bitmap
        x = CType(PictureBox1.Image, Bitmap)
        Dim y As New Bitmap(PictureBox1.Image.Width, PictureBox1.Image.Height)

        Dim a, b As Integer
        a = 0
        b = 0
        Dim say As Integer = 0
        While (a < x.Width)
            b = 0

            While (b < x.Height)
                say += 1
                If (x.GetPixel(a, b).B > x.GetPixel(a, b).G And x.GetPixel(a, b).B > x.GetPixel(a, b).R) Then
                    y.SetPixel(a, b, Color.Blue)
                Else
                    y.SetPixel(a, b, x.GetPixel(a, b))
                End If

                b += 1
            End While

            a = a + 1

        End While

        PictureBox2.Image = y

        aksiyon.BackgroundImage = y
        aksiyon.BackgroundImageLayout = ImageLayout.None
        aksiyon.Show()
    End Sub

    Private Sub RGBSüzgeçToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RGBSüzgeçToolStripMenuItem.Click
        Dim aksiyon As New Form
        aksiyon.ShowIcon = False
        aksiyon.Text = "KYM Süzgeç"
        Dim allthings As String = ""
        Dim x As Bitmap
        x = CType(PictureBox1.Image, Bitmap)
        Dim y As New Bitmap(PictureBox1.Image.Width, PictureBox1.Image.Height)
        MessageBox.Show("h:" + x.Height.ToString + " w:" + x.Width.ToString)
        Dim a, b As Integer
        a = 0
        b = 0
        Dim say As Integer = 0
        While (a < x.Width)
            b = 0

            While (b < x.Height)
                say += 1
                If (x.GetPixel(a, b).R > x.GetPixel(a, b).B And x.GetPixel(a, b).R > x.GetPixel(a, b).G) Then
                    y.SetPixel(a, b, Color.Red)
                ElseIf (x.GetPixel(a, b).B > x.GetPixel(a, b).R And x.GetPixel(a, b).B > x.GetPixel(a, b).G) Then
                    y.SetPixel(a, b, Color.Blue)
                ElseIf (x.GetPixel(a, b).G > x.GetPixel(a, b).R And x.GetPixel(a, b).G > x.GetPixel(a, b).B) Then
                    y.SetPixel(a, b, Color.Green)
                Else
                    y.SetPixel(a, b, x.GetPixel(a, b))
                End If

                b += 1
            End While

            a = a + 1

        End While

        PictureBox2.Image = y
        aksiyon.BackgroundImage = y
        aksiyon.BackgroundImageLayout = ImageLayout.None
        aksiyon.Show()
    End Sub

    Private Sub YeşilSüzgeçToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles YeşilSüzgeçToolStripMenuItem.Click
        Dim aksiyon As New Form
        aksiyon.ShowIcon = False
        aksiyon.Text = "Yeşil Süzgeç"
        Dim allthings As String = ""
        Dim x As Bitmap
        x = CType(PictureBox1.Image, Bitmap)
        Dim y As New Bitmap(PictureBox1.Image.Width, PictureBox1.Image.Height)

        Dim a, b As Integer
        a = 0
        b = 0
        Dim say As Integer = 0
        While (a < x.Width)
            b = 0

            While (b < x.Height)
                say += 1
                If (x.GetPixel(a, b).G > x.GetPixel(a, b).B And x.GetPixel(a, b).G > x.GetPixel(a, b).R) Then
                    y.SetPixel(a, b, Color.Green)
                Else
                    y.SetPixel(a, b, x.GetPixel(a, b))
                End If

                b += 1
            End While

            a = a + 1

        End While

        PictureBox2.Image = y

        aksiyon.BackgroundImage = y
        aksiyon.BackgroundImageLayout = ImageLayout.None
        aksiyon.Show()
    End Sub

    Private Sub TahminEtYarımToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TahminEtYarımToolStripMenuItem.Click
        RichTextBox1.Text = ""
        Dim h As Integer = CType(PictureBox1.Image, Bitmap).Size.Height
        Dim w As Integer = CType(PictureBox1.Image, Bitmap).Size.Width
        Dim k As Integer = 0
        Dim i As Integer = 0
        Dim max As Integer = 0
        Dim renk As Char
        Dim satir_kirmizi As Integer = 0
        Dim satir_yesil As Integer = 0
        Dim satir_mavi As Integer = 0
        Dim Satırbilgisi As String = ""

        Try
            Try
                While (k < h)
                    i = 0
                    Try

                        While (i < w)


                            Dim Anlık = CType(PictureBox1.Image, Bitmap).GetPixel(i, k)
                            Dim enbuyuk As Integer = 0
                            If (Anlık.R = Anlık.G And Anlık.G = Anlık.B And Anlık.R = Anlık.B) Then
                                If (Anlık.R > 100) Then
                                    'beyaz
                                    CType(PictureBox1.Image, Bitmap).SetPixel(i, k, Color.White)

                                Else
                                    'siyah
                                    CType(PictureBox1.Image, Bitmap).SetPixel(i, k, Color.Black)
                                End If
                            ElseIf (Anlık.R = Anlık.G) Then
                                ' Kırmızı yeşil = Sarı
                                CType(PictureBox1.Image, Bitmap).SetPixel(i, k, Color.Yellow)
                            ElseIf (Anlık.R = Anlık.B) Then
                                ' Kırmızı mavi = magenta
                                CType(PictureBox1.Image, Bitmap).SetPixel(i, k, Color.Magenta)
                            ElseIf (Anlık.G = Anlık.B) Then
                                ' Mavi yeşil = Cyan
                                CType(PictureBox1.Image, Bitmap).SetPixel(i, k, Color.Cyan)
                            Else

                                If (Anlık.R > enbuyuk) Then
                                    enbuyuk = Anlık.R
                                    renk = "r"
                                End If
                                If (Anlık.G > enbuyuk) Then
                                    enbuyuk = Anlık.G
                                    renk = "g"
                                End If
                                If (Anlık.B > enbuyuk) Then
                                    enbuyuk = Anlık.B
                                    renk = "b"
                                End If
                                If (renk = "r") Then
                                    CType(PictureBox1.Image, Bitmap).SetPixel(i, k, Color.FromArgb(255, enbuyuk, 0, 0))
                                    satir_kirmizi += 1
                                ElseIf (renk = "g") Then
                                    CType(PictureBox1.Image, Bitmap).SetPixel(i, k, Color.FromArgb(255, 0, enbuyuk, 0))
                                    satir_yesil += 1
                                ElseIf (renk = "b") Then
                                    CType(PictureBox1.Image, Bitmap).SetPixel(i, k, Color.FromArgb(255, 0, 0, enbuyuk))
                                    satir_mavi += 1
                                End If


                            End If




                            i += 1
                        End While
                    Catch ex As Exception
                    End Try
                    If (satir_kirmizi > satir_yesil And satir_kirmizi > satir_mavi) Then
                        Satırbilgisi = Satırbilgisi + "Satır: " + k.ToString + " Hakim Renk: " + satir_kirmizi.ToString + " renk ile Kırmızı" + vbNewLine
                    ElseIf (satir_mavi > satir_yesil And satir_mavi > satir_kirmizi) Then
                        Satırbilgisi = Satırbilgisi + "Satır: " + k.ToString + " Hakim Renk: " + satir_mavi.ToString + " renk ile Mavi" + vbNewLine
                    ElseIf (satir_yesil > satir_mavi And satir_yesil > satir_kirmizi) Then
                        Satırbilgisi = Satırbilgisi + "Satır: " + k.ToString + " Hakim Renk: " + satir_yesil.ToString + " renk ile Yeşil" + vbNewLine
                    ElseIf (satir_yesil = satir_kirmizi And satir_kirmizi = satir_mavi And satir_yesil = satir_mavi) Then
                        Satırbilgisi = Satırbilgisi + "Satır: " + k.ToString + " Hakim Renk: " + "??" + " renk ile Beyaz" + vbNewLine
                    ElseIf (satir_kirmizi = satir_mavi) Then
                        Satırbilgisi = Satırbilgisi + "Satır: " + k.ToString + " Hakim Renk: " + satir_kirmizi.ToString + " renk ile Magenta" + vbNewLine
                    ElseIf (satir_kirmizi = satir_yesil) Then
                        Satırbilgisi = Satırbilgisi + "Satır: " + k.ToString + " Hakim Renk: " + satir_kirmizi.ToString + " renk ile Sarı" + vbNewLine
                    ElseIf (satir_yesil = satir_mavi) Then
                        Satırbilgisi = Satırbilgisi + "Satır: " + k.ToString + " Hakim Renk: " + satir_yesil.ToString + " renk ile Cyan" + vbNewLine
                    Else
                        MessageBox.Show("Bir değişiklik var ; MAVİ: " + satir_mavi.ToString + " Kırmızı: " + satir_kirmizi.ToString + " Yeşil: " + satir_yesil.ToString)
                    End If
                    satir_yesil = 0
                    satir_kirmizi = 0
                    satir_mavi = 0
                    PictureBox1.Refresh()
                    k += 1
                End While
            Catch ex As Exception
            End Try
        Catch ex As Exception
        End Try
        RichTextBox1.Text = RichTextBox1.Text + Satırbilgisi + vbNewLine

        'Dim gecicisatir As Integer = 0
        'Dim gecicirenk As String = ""
        'For Each satir In RichTextBox1.Lines
        '    Try
        '        If (Not satir = "") Then
        '            gecicisatir = Convert.ToInt32(satir.Split("Hakim")(0).ToString.Split(":")(1).ToString.Trim)
        '            If (satir.Contains("Yeşil")) Then
        '                gecicirenk = "Yeşil"
        '            ElseIf (satir.Contains("Mavi")) Then
        '                gecicirenk = "Mavi"
        '            ElseIf (satir.Contains("Kırmızı")) Then
        '                gecicirenk = "Kırmızı"
        '            ElseIf (satir.Contains("Beyaz")) Then
        '                gecicirenk = "Beyaz"
        '            ElseIf (satir.Contains("Cyan")) Then
        '                gecicirenk = "Cyan"
        '            ElseIf (satir.Contains("Magenta")) Then
        '                gecicirenk = "Magenta"
        '            ElseIf (satir.Contains("Sarı")) Then
        '                gecicirenk = "Cyan"
        '            End If


        '            Try
        '                i = 0
        '                k = 0
        '                While (k < h)
        '                    'satır satır
        '                    i = 0
        '                    If (k = gecicisatir) Then
        '                        If (gecicirenk = "Yeşil") Then
        '                            While (i < w)
        '                                'sütun
        '                                CType(PictureBox1.Image, Bitmap).SetPixel(i, k, Color.Green)
        '                                i += 1

        '                            End While

        '                        ElseIf (gecicirenk = "Mavi") Then
        '                            While (i < w)
        '                                'sütun
        '                                CType(PictureBox1.Image, Bitmap).SetPixel(i, k, Color.Blue)
        '                                i += 1
        '                            End While

        '                        ElseIf (gecicirenk = "Kırmızı") Then
        '                            While (i < w)
        '                                'sütun
        '                                CType(PictureBox1.Image, Bitmap).SetPixel(i, k, Color.Red)
        '                                i += 1
        '                            End While

        '                        ElseIf (gecicirenk = "Cyan") Then
        '                            While (i < w)
        '                                'sütun
        '                                CType(PictureBox1.Image, Bitmap).SetPixel(i, k, Color.Cyan)
        '                                i += 1
        '                            End While

        '                        ElseIf (gecicirenk = "Magenta") Then
        '                            While (i < w)
        '                                'sütun
        '                                CType(PictureBox1.Image, Bitmap).SetPixel(i, k, Color.Magenta)
        '                                i += 1
        '                            End While

        '                        ElseIf (gecicirenk = "Sarı") Then
        '                            While (i < w)
        '                                'sütun
        '                                CType(PictureBox1.Image, Bitmap).SetPixel(i, k, Color.Yellow)
        '                                i += 1
        '                            End While

        '                        ElseIf (gecicirenk = "Beyaz") Then
        '                            While (i < w)
        '                                'sütun
        '                                CType(PictureBox1.Image, Bitmap).SetPixel(i, k, Color.White)
        '                                i += 1
        '                            End While
        '                        End If
        '                        'While (i < w)
        '                        '    CType(PictureBox1.Image, Bitmap).SetPixel(i, k, Color.Black)
        '                        '    i += 1
        '                        'End While
        '                    End If

        '                    k += 1
        '                End While
        '                PictureBox1.Refresh()

        '                'CType(PictureBox1.Image, Bitmap).SetPixel(0, 0, Color.Black)
        '            Catch ex As Exception

        '            End Try

        '        End If

        '    Catch ex As Exception

        '    End Try
        'Next

    End Sub
    Private Sub AnalizToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles AnalizToolStripMenuItem1.Click
        Dim allthings As String = ""
        Dim x As Bitmap
        x = CType(PictureBox1.Image, Bitmap)
        MessageBox.Show("h:" + x.Height.ToString + " w:" + x.Width.ToString)
        Dim a, b As Integer
        a = 0
        b = 0
        Dim saygreen As Integer = 0
        Dim sayblue As Integer = 0
        Dim sayred As Integer = 0
        Dim say As Integer = 0
        Dim total As Double = 0


        While (a < x.Width)
            b = 0

            While (b < x.Height)
                say += 1

                If (x.GetPixel(a, b).R > x.GetPixel(a, b).B And x.GetPixel(a, b).R > x.GetPixel(a, b).G) Then
                    sayred += 1
                ElseIf (x.GetPixel(a, b).B > x.GetPixel(a, b).R And x.GetPixel(a, b).B > x.GetPixel(a, b).G) Then
                    sayblue += 1
                ElseIf (x.GetPixel(a, b).G > x.GetPixel(a, b).R And x.GetPixel(a, b).G > x.GetPixel(a, b).B) Then
                    saygreen += 1
                Else

                End If

                b += 1
            End While

            a = a + 1

        End While
        RichTextBox1.Text = "Red: " + sayred.ToString + " " + " Green: " + saygreen.ToString + " " + " Blue: " + sayblue.ToString

        MsgBox(RichTextBox1.Text)

    End Sub
End Class
