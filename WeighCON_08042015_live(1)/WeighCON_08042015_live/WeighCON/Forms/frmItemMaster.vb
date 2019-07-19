Public Class frmItemMaster
    Dim myConn As New DbConn

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnInsert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInsert.Click
        myConn.CONNUpload("Insert into ITEMMASTER(Item_Code,BarCode,Description,Theoretical_Mass,UOM,[Permitted_Tol_Upper_%],[Permitted_Tol_Lower_%])VALUES(" & Me.txtItemcode.Text & ",'" & Me.txtBarcode.Text & "','" & Me.txtDescription.Text & "'," & Me.txtStandardMass.Text & ",'" & Me.txtUnitofMass.Text & "','" & Me.txtTolencePositive.Text & "','" & Me.txtTolenceNegative.Text & "') ")
    End Sub
End Class