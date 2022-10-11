Public Class Form1
    Private randomizer As New Random

    Private addend1 As Integer
    Private addend2 As Integer

    Private minuend As Integer
    Private subtrahend As Integer

    Private multiplicand As Integer
    Private multiplier As Integer

    Private dividend As Integer
    Private divisor As Integer

    Private timeLeft As Integer

    ''' <summary>
    ''' Start the quiz by filling in all of the problems
    ''' and starting the timer.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub StartTheQuiz()
        ' Addition
        addend1 = randomizer.Next(51)
        addend2 = randomizer.Next(51)
        lblPlusLeft.Text = addend1.ToString()
        lblPlusRight.Text = addend2.ToString()
        sum.Value = 0

        ' Subtraktion
        minuend = randomizer.Next(1, 101)
        subtrahend = randomizer.Next(1, minuend)
        lblMinusLeft.Text = minuend.ToString()
        lblMinusRight.Text = subtrahend.ToString()
        difference.Value = 0

        ' Multiplikation
        multiplicand = randomizer.Next(2, 11)
        multiplier = randomizer.Next(2, 11)
        lblTimesLeft.Text = multiplicand.ToString()
        lblTimesRight.Text = multiplier.ToString()
        product.Value = 0

        ' Division
        divisor = randomizer.Next(2, 11)
        Dim temporaryQuotient As Integer = randomizer.Next(2, 11)
        dividend = divisor * temporaryQuotient
        lblDivideLeft.Text = dividend.ToString()
        lblDivideRight.Text = divisor.ToString()
        quotient.Value = 0

        ' Start the timer.
        timeLeft = 30
        lblTime.Text = "30 seconds"
        Timer1.Start()
    End Sub

    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        StartTheQuiz()
        btnStart.Enabled = False
    End Sub

    Public Function CheckTheAnswer() As Boolean
        If addend1 + addend2 = sum.Value AndAlso
           minuend - subtrahend = difference.Value AndAlso
           multiplicand * multiplier = product.Value AndAlso
           dividend / divisor = quotient.Value Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        If CheckTheAnswer() Then
            Timer1.Stop()
            MessageBox.Show("You got all of the answers right!", "Congratulations!")
            btnStart.Enabled = True
        ElseIf timeLeft > 0 Then
            timeLeft -= 1
            lblTime.Text = timeLeft & " seconds"
        Else
            Timer1.Stop()
            lblTime.Text = "Time's up!"
            MessageBox.Show("You didn't finish in time.", "Sorry!")
            sum.Value = addend1 + addend2
            difference.Value = minuend - subtrahend
            product.Value = multiplicand * multiplier
            quotient.Value = CDec(dividend / divisor)
            btnStart.Enabled = True
        End If

        If timeLeft < 10 Then
            lblTime.BackColor = Color.Orange
            If timeLeft < 5 Then
                lblTime.BackColor = Color.Red
            End If
        End If
    End Sub

    Private Sub answer_Enter(sender As Object, e As EventArgs) Handles sum.Enter, quotient.Enter, product.Enter, difference.Enter
        ' Select the whole answer in the NumericUpDown control.
        Dim answerBox = TryCast(sender, NumericUpDown)

        If answerBox IsNot Nothing Then
            Dim lengthOfAnswer = answerBox.Value.ToString().Length
            answerBox.Select(0, lengthOfAnswer)
        End If
    End Sub
End Class
