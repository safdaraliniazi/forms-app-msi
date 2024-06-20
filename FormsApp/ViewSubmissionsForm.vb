Imports System.Net.Http
Imports Newtonsoft.Json

Public Class ViewSubmissionsForm
    Private currentIndex As Integer = 0
    Private submissions As List(Of Submission)

    Private Async Sub ViewSubmissionsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        submissions = Await FetchSubmissions()
        If submissions.Count > 0 Then
            DisplaySubmission(currentIndex)
        End If
    End Sub

    Private Sub btnPrevious_Click(sender As Object, e As EventArgs) Handles btnPrevious.Click
        If currentIndex > 0 Then
            currentIndex -= 1
            DisplaySubmission(currentIndex)
        End If
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        If currentIndex < submissions.Count - 1 Then
            currentIndex += 1
            DisplaySubmission(currentIndex)
        End If
    End Sub

    Private Sub DisplaySubmission(index As Integer)
        Dim submission = submissions(index)
        txtName.Text = submission.Name
        txtEmail.Text = submission.Email
        txtPhone.Text = submission.Phone
        txtGithub.Text = submission.github_link
        txtStopwatch.Text = submission.stopwatch_time


    End Sub

    Private Async Function FetchSubmissions() As Task(Of List(Of Submission))
        Dim client As New HttpClient()
        Dim response As HttpResponseMessage = Await client.GetAsync("http://localhost:3000/read?index=0")
        If response.IsSuccessStatusCode Then
            Dim json As String = Await response.Content.ReadAsStringAsync()

            Try
                ' Attempt to deserialize as List(Of Submission)
                Return JsonConvert.DeserializeObject(Of List(Of Submission))(json)

            Catch ex As JsonSerializationException
                ' Handle the exception when JSON is not in the expected format
                MessageBox.Show("Error: Unexpected JSON format received.")
                Console.WriteLine(ex.Message)
                Return New List(Of Submission)() ' or handle differently as needed

            End Try

        Else
            MessageBox.Show("Error fetching submissions")
            Return New List(Of Submission)()
        End If
    End Function

    Public Class Submission
        Public Property Name As String
        Public Property Email As String
        Public Property Phone As String
        Public Property github_link As String
        Public Property stopwatch_time As String
    End Class

    Private Sub ViewSubmissionsForm_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.Control AndAlso e.KeyCode = Keys.N Then
            btnNext.PerformClick()
        ElseIf e.Control AndAlso e.KeyCode = Keys.P Then
            btnPrevious.PerformClick()
        End If
    End Sub

    Private Sub lblSubmission_Click(sender As Object, e As EventArgs)



    End Sub
End Class
