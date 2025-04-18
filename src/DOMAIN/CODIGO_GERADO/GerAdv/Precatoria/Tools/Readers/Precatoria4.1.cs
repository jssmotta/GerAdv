#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial class Precatoria
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
            WHEN preDtAtu IS NULL THEN preDtCad 
            WHEN preDtAtu > preDtCad THEN preDtAtu 
            ELSE preDtCad 
        END, 'yyyy-MM-dd-HH-mm') AS data
FROM dbo.Precatoria WITH (NOLOCK, INDEX = idx_Precatoria_Auditor)
WHERE preCodigo = @id
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
        ConfiguracoesDBT.ExecuteSqlCreate(@"IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'idx_Precatoria_Auditor' AND object_id = OBJECT_ID('dbo.Precatoria'))
                BEGIN
                    CREATE INDEX idx_Precatoria_Auditor ON dbo.Precatoria(preCodigo, preDtCad, preDtAtu);
                END
                ", oCnnRw);
    }
}