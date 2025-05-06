SELECT DISTINCT
    c.cliCodigo,
    c.cliNome,
    DAY(c.cliDtNasc) as dia,
	MONTH(c.cliDtNasc) as mes,
    a.advCodigo,
    a.advNome
FROM
    dbo.Clientes c
LEFT JOIN
    dbo.Processos p ON c.cliCodigo = p.proCliente
LEFT JOIN
    dbo.Historico h ON p.proCodigo = h.hisProcesso
LEFT JOIN
    dbo.Agenda ag ON c.cliCodigo = ag.ageCliente
LEFT JOIN
    dbo.Advogados a ON a.advCodigo = p.proAdvogado OR a.advCodigo = ag.ageAdvogado
left join
	dbo.Operador o ON o.operCadCod = a.advCodigo AND o.operCadID=1
WHERE
	o.operSituacao=1 AND
    MONTH(c.cliDtNasc) = MONTH(GETDATE()) AND
    DAY(c.cliDtNasc) BETWEEN DAY(GETDATE()) AND DAY(DATEADD(DAY, 7, GETDATE())) AND
	c.cliInativo=0
ORDER BY a.advCodigo, MONTH(c.cliDtNasc), DAY(c.cliDtNasc), c.cliNome, a.advNome 