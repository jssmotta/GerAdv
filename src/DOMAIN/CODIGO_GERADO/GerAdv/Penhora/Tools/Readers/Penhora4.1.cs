#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial class Penhora
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
            WHEN phrDtAtu IS NULL THEN phrDtCad 
            WHEN phrDtAtu > phrDtCad THEN phrDtAtu 
            ELSE phrDtCad 
        END, 'yyyy-MM-dd-HH-mm') AS data
FROM dbo.Penhora WITH (NOLOCK, INDEX = idx_Penhora_Auditor)
WHERE phrCodigo = @id
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
        ConfiguracoesDBT.ExecuteSqlCreate(@"IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'idx_Penhora_Auditor' AND object_id = OBJECT_ID('dbo.Penhora'))
                BEGIN
                    CREATE INDEX idx_Penhora_Auditor ON dbo.Penhora(phrCodigo, phrDtCad, phrDtAtu);
                END
                ", oCnnRw);
    }
}