CREATE OR ALTER VIEW [dbo].[AgendaRelatorio] AS SELECT qa.*, 

vp.advNome as xxxNomeAdvogado,
vp.forNome as xxxNomeForo,
vp.jusNome as xxxNomeJustica,
vp.areDescricao as xxxNomeArea

FROM [dbo].[view_QAgenda] qa JOIN agenda a on a.ageCodigo = qa.vqaCodigo LEFT JOIN [dbo].[view_QProcessos] vp
  on a.ageIDInsProcesso = vp.insCodigo  
