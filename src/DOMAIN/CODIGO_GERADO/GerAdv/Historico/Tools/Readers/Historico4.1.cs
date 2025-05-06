#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial class Historico
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
            WHEN hisDtAtu IS NULL THEN hisDtCad 
            WHEN hisDtAtu > hisDtCad THEN hisDtAtu 
            ELSE hisDtCad 
        END, 'yyyy-MM-dd-HH-mm') AS data
FROM dbo.Historico WITH (NOLOCK, INDEX = idx_Historico_Auditor)
WHERE hisCodigo = @id
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
        ConfiguracoesDBT.ExecuteSqlCreate(@"IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'idx_Historico_Auditor' AND object_id = OBJECT_ID('dbo.Historico'))
                BEGIN
                    CREATE INDEX idx_Historico_Auditor ON dbo.Historico(hisCodigo, hisDtCad, hisDtAtu);
                END
                ", oCnnRw);
    }
}