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
),
RankedDuplicates AS (
    SELECT 
        dt.divCodigo,
        dt.divJustica,
        dt.divArea,
        dt.divTribunal,
        dt.divCidade,
        dt.divForo, 
        dt.divNumCodigo,
        ROW_NUMBER() OVER (
            PARTITION BY 
                dt.divJustica,
                dt.divArea,
                dt.divTribunal,
                dt.divCidade,
                dt.divForo, 
                dt.divNumCodigo
            ORDER BY 
                dt.divCodigo
        ) AS RowNum
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
)
SELECT 
    divCodigo,
    divJustica,
    divArea,
    divTribunal,
    divCidade,
    divForo, 
    divNumCodigo
FROM 
    RankedDuplicates
WHERE 
    RowNum = 2;