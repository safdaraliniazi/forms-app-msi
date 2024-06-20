'Imports System.Net.Http
'Imports System.Text
'Imports Newtonsoft.Json
'Imports System.Diagnostics

'Public Class CreateSubmissionForm
'    Private stopwatch As New Stopwatch()
'    Private WithEvents timer As New Timer()

'    Public Sub New()
'        ' This call is required by the designer.
'        InitializeComponent()

'        ' Initialize the timer
'        timer.Interval = 1000 ' 1 second
'    End Sub

'    Private Sub btnStopwatch_Click(sender As Object, e As EventArgs) Handles btnStopwatch.Click
'        If stopwatch.IsRunning Then
'            stopwatch.Stop()
'            btnStopwatch.Text = "Resume"
'            timer.Stop()
'        Else
'            stopwatch.Start()
'            btnStopwatch.Text = "Pause"
'            timer.Start()
'        End If
'    End Sub

'    Private Sub timer_Tick(sender As Object, e As EventArgs) Handles timer.Tick
'        lblStopwatchTime.Text = stopwatch.Elapsed.ToString("hh\:mm\:ss")
'    End Sub

'    Private Async Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
'        Dim submission As New Dictionary(Of String, String) From {
'            {"name", txtName.Text},
'            {"email", txtEmail.Text},
'            {"phone", txtPhone.Text},
'            {"github_link", txtGithub.Text},
'            {"stopwatch_time", lblStopwatchTime.Text}
'        }
'        Await SubmitForm(submission)
'    End Sub

'    Private Async Function SubmitForm(submission As Dictionary(Of String, String)) As Task
'        Dim client As New HttpClient()
'        Dim json As String = JsonConvert.SerializeObject(submission)
'        Dim content As New StringContent(json, Encoding.UTF8, "application/json")

'        Dim response As HttpResponseMessage = Await client.PostAsync("http://localhost:3000/submit", content)
'        If response.IsSuccessStatusCode Then
'            MessageBox.Show("Submission successful")
'        Else
'            MessageBox.Show("Error submitting form")
'        End If
'    End Function

'    ' Handle Ctrl + S to submit the form
'    Private Sub CreateSubmissionForm_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
'        If e.Control AndAlso e.KeyCode = Keys.S Then
'            btnSubmit.PerformClick()
'        End If
'    End Sub

'    Private Sub CreateSubmissionForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
'        Me.KeyPreview = True
'    End Sub
'End Class


Imports System.Net.Http
Imports System.Text
Imports Newtonsoft.Json
Imports System.Diagnostics

Public Class CreateSubmissionForm
    Private stopwatch As New Stopwatch()
    Private WithEvents timer As New Timer()

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Initialize the timer
        timer.Interval = 1000 ' 1 second
    End Sub

    Private Sub btnStopwatch_Click(sender As Object, e As EventArgs) Handles btnStopwatch.Click
        ToggleStopwatch()
    End Sub

    Private Sub ToggleStopwatch()
        If stopwatch.IsRunning Then
            stopwatch.Stop()
            btnStopwatch.Text = "Resume"
            timer.Stop()
        Else
            stopwatch.Start()
            btnStopwatch.Text = "Pause"
            timer.Start()
        End If
    End Sub

    Private Sub timer_Tick(sender As Object, e As EventArgs) Handles timer.Tick
        lblStopwatchTime.Text = stopwatch.Elapsed.ToString("hh\:mm\:ss")
    End Sub

    Private Async Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Dim submission As New Dictionary(Of String, String) From {
            {"name", txtName.Text},
            {"email", txtEmail.Text},
            {"phone", txtPhone.Text},
            {"github_link", txtGithub.Text},
            {"stopwatch_time", lblStopwatchTime.Text}
        }
        Await SubmitForm(submission)
    End Sub

    Private Async Function SubmitForm(submission As Dictionary(Of String, String)) As Task
        Dim client As New HttpClient()
        Dim json As String = JsonConvert.SerializeObject(submission)
        Dim content As New StringContent(json, Encoding.UTF8, "application/json")

        Dim response As HttpResponseMessage = Await client.PostAsync("http://localhost:3000/submit", content)
        If response.IsSuccessStatusCode Then
            MessageBox.Show("Submission successful")
        Else
            MessageBox.Show("Error submitting form")
        End If
    End Function

    ' Handle keyboard shortcuts
    Private Sub CreateSubmissionForm_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.Control AndAlso e.KeyCode = Keys.S Then
            btnSubmit.PerformClick()
        ElseIf e.Control AndAlso e.KeyCode = Keys.T Then
            ToggleStopwatch()
        End If
    End Sub

    Private Sub CreateSubmissionForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
    End Sub
End Class

