﻿'Public Class MainForm
'    Private Sub btnViewSubmissions_Click(sender As Object, e As EventArgs) Handles btnViewSubmissions.Click
'        Dim viewForm As New ViewSubmissionsForm()
'        viewForm.ShowDialog()
'    End Sub

'    Private Sub btnCreateSubmission_Click(sender As Object, e As EventArgs) Handles btnCreateSubmission.Click
'        Dim createForm As New CreateSubmissionForm()
'        createForm.ShowDialog()
'    End Sub
'End Class

Public Class MainForm
    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
    End Sub

    Private Sub btnViewSubmissions_Click(sender As Object, e As EventArgs) Handles btnViewSubmissions.Click
        ViewSubmissions()
    End Sub

    Private Sub btnCreateSubmission_Click(sender As Object, e As EventArgs) Handles btnCreateSubmission.Click
        CreateSubmission()
    End Sub

    Private Sub MainForm_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.Control Then
            Select Case e.KeyCode
                Case Keys.V
                    ViewSubmissions()
                Case Keys.N
                    CreateSubmission()
            End Select
        End If
    End Sub

    Private Sub ViewSubmissions()
        Dim viewForm As New ViewSubmissionsForm()
        viewForm.ShowDialog()
    End Sub

    Private Sub CreateSubmission()
        Dim createForm As New CreateSubmissionForm()
        createForm.ShowDialog()
    End Sub
End Class
