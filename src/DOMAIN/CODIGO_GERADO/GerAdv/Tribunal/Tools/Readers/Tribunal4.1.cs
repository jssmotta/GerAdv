#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial class Tribunal
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
            WHEN triDtAtu IS NULL THEN triDtCad 
            WHEN triDtAtu > triDtCad THEN triDtAtu 
            ELSE triDtCad 
        END, 'yyyy-MM-dd-HH-mm') AS data
FROM dbo.Tribunal WITH (NOLOCK, INDEX = idx_Tribunal_Auditor)
WHERE triCodigo = @id
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
        ConfiguracoesDBT.ExecuteSqlCreate(@"IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'idx_Tribunal_Auditor' AND object_id = OBJECT_ID('dbo.Tribunal'))
                BEGIN
                    CREATE INDEX idx_Tribunal_Auditor ON dbo.Tribunal(triCodigo, triDtCad, triDtAtu);
                END
                ", oCnnRw);
    }
}