WITH DuplicateGroups AS (
    SELECT 
        divJustica,
        divArea,
        divTribunal,
        divCidade,
        divForo, 
        divNumCodigo,
        COUNT(*) AS NumOccurrences
    FROM 
        DivisaoTribunal
    GROUP BY 
        divJustica,
        divArea,
        divTribunal,
        divCidade,
        divForo, 
        divNumCodigo
    HAVING 
        COUNT(*) > 1
)
select qq.* from (
SELECT 
    dt.divCodigo,  -- A chave primária
    dt.divJustica,
    dt.divArea,
    dt.divTribunal,
    dt.divCidade,
    dt.divForo, 
    dt.divNumCodigo
FROM 
    DivisaoTribunal dt
INNER JOIN 
    DuplicateGroups dg ON 
        dt.divJustica = dg.divJustica AND
        dt.divArea = dg.divArea AND
        dt.divTribunal = dg.divTribunal AND
        dt.divCidade = dg.divCidade AND
        dt.divForo = dg.divForo AND
        dt.divNumCodigo = dg.divNumCodigo
 ) qq;
 
 select * from DivisaoTribunal where divJustica=3 and divArea = 1 and divTribunal=12 and divCidade = 1 and divForo=0 and divNumCodigo=1;