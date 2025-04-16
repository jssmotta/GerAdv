CREATE OR ALTER VIEW [dbo].[AgendaSemana] 
WITH SCHEMABINDING AS
SELECT
	case when f.funNome IS NULL then adv.advNome else f.funNome end as xxxParaNome,
    a.ageCodigo as xxxCodigo,
    a.ageData AS xxxData, 
    a.ageFuncionario AS xxxFuncionario, 
	a.ageAdvogado as xxxAdvogado,
    a.ageHora AS xxxHora, 
    a.ageTipoCompromisso AS xxxTipoCompromisso, 
    a.ageCompromisso AS xxxCompromisso, 
    a.ageConcluido AS xxxConcluido, 
    a.ageLiberado AS xxxLiberado,   
    a.ageImportante AS xxxImportante, 
    a.ageHrFinal AS xxxHoraFinal, 
    c.cliNome AS xxxNome,   
    a.ageCliente as xxxCliente,
	c.cliNome as xxxNomeCliente,
    t.tipDescricao as xxxTipo
FROM dbo.Agenda a
LEFT JOIN dbo.Funcionarios f on f.funCodigo = a.ageFuncionario
LEFT JOIN dbo.Advogados adv on adv.advCodigo = a.ageAdvogado
LEFT JOIN dbo.clientes c ON c.cliCodigo = a.ageCliente
JOIN dbo.TipoCompromisso t on t.tipCodigo = a.ageTipoCompromisso