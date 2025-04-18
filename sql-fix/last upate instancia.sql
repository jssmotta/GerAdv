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
        COUNT(*) > 1;

		select divCodigo from DivisaoTribunal where divJustica=5 and divArea =4 and divTribunal=13 and divCidade =1 and divForo is null and divNumCodigo=8;
		update instancia set insSubDivisao=1045 where insSubDivisao=1046;
		select i. * from instancia i where insSubDivisao = 1046;
		delete from divisaotribunal where divCodigo=1046;