- **How to delete a row from DataTable and update to SQL Server?**
- **Why the delete result does not update to SQL Server?**

See more details from [this](http://www.mamicode.com/info-detail-2523323.html)

Do not use *DataTable.Rows.Remove(row)*, which equals to *DataTable.Rows[rowIndex].Delete()* and *DataTable.AcceptChanges()* combined. But *DataTable.AcceptChanges()* should be used AFTER *DataAdapter.Update()*.