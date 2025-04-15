CREATE OR ALTER TRIGGER trg_Agenda_Update
ON dbo.Agenda
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    -- Atualiza a quantidade de desistências no cliente
    UPDATE dbo.Clientes
		SET cliQtdeDesistencia = COALESCE(cliQtdeDesistencia, 0) + 1,
		cliQuemAtu = ageQuemAtu,
		cliDtAtu = ageDtAtu,
		cliVisto = 0

    FROM dbo.Clientes c
    INNER JOIN inserted i ON c.cliCodigo = i.ageCliente
    WHERE i.ageNaoCampareceu = 1 AND i.ageCliente <> 0;  -- Verifica se ageCliente é diferente de zero
END;
