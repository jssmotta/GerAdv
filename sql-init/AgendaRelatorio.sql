CREATE OR ALTER VIEW [dbo].[AgendaRelatorio] AS SELECT qa.*, vp.* FROM [dbo].[view_QAgenda] qa JOIN agenda a on a.ageCodigo = qa.vqaCodigo LEFT JOIN [dbo].[view_QProcessos] vp
  on a.ageIDInsProcesso = vp.insCodigo  
