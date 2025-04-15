SELECT TOP (100) [vqaData]       
      ,[xxxParaNome] 
      ,[xxxBoxAudiencia] 
  FROM [dbo].[AgendaRelatorio]
  WHERE vqaData >= GETDATE()-1 and vqaData <= GETDATE()+8 and xxxParaNome = 'Gina'
  ORDER BY vqaData
