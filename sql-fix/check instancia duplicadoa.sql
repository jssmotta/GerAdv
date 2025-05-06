SELECT  sum(1) as total, insDivisao, insSubDivisao, insNroProcesso
  FROM [dbo].[Instancia]
  group by insDivisao, insSubDivisao, insNroProcesso
  having count(*)>1
  ;

 