# AZ-1717-Repro
This is an attempt to reproduce https://github.com/Azure/Azure-Functions/issues/1717

Currently unable to reproduce, and the code above work with the following steps:

1. Create an Azure Sql Database
2. Create a table using

```sql
CREATE TABLE [dbo].[MyTable](
	[ID] [int] NULL,
	[Name] [nvarchar](150) NULL
) 
```
3. Insert a Value to the table

```sql
  INSERT INTO MyTable([ID], [NAME]) VALUES (1, 'Ben')
```
4. Update the connection string on [line 22](https://github.com/Jtango18/AZ-1717-Repro/blob/1cc54f5cb93ee027dd97197f9320a0aeb2fc7482/Repro1717/Repro1717.cs#L22) to be a valid connection string to your database

5. Deploy/Run your function - it can be triggered using an HTTP Get request.
