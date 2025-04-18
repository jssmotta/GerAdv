#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial class Apenso2
{
    private static bool _checkIndex;
    public async Task<string> ReadStringAuditor(int id, string uri, SqlConnection oCnn)
    {
        if (!_checkIndex)
        {
            CreateIdx(uri);
        }

        string query = @"
SELECT TOP 1 
    FORMAT(
        CASE 
            WHEN ap2DtAtu IS NULL THEN ap2DtCad 
            WHEN ap2DtAtu > ap2DtCad THEN ap2DtAtu 
            ELSE ap2DtCad 
        END, 'yyyy-MM-dd-HH-mm') AS data
FROM dbo.Apenso2 WITH (NOLOCK, INDEX = idx_Apenso2_Auditor)
WHERE ap2Codigo = @id
OPTION (OPTIMIZE FOR (@id UNKNOWN), FAST 1);";
        using var cmd = new SqlCommand(query, oCnn);
        cmd.Parameters.AddWithValue("@id", id);
        var dataFormatada = $"{await cmd.ExecuteScalarAsync()}";
        return dataFormatada;
    }

    private static void CreateIdx(string uri)
    {
        _checkIndex = true;
        using var oCnnRw = Configuracoes.GetConnectionByUriRw(uri);
        if (oCnnRw is null)
            return;
        ConfiguracoesDBT.ExecuteSqlCreate(@"IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'idx_Apenso2_Auditor' AND object_id = OBJECT_ID('dbo.Apenso2'))
                BEGIN
                    CREATE INDEX idx_Apenso2_Auditor ON dbo.Apenso2(ap2Codigo, ap2DtCad, ap2DtAtu);
                END
                ", oCnnRw);
    }
}