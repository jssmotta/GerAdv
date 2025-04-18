#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial class Setor
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
            WHEN setDtAtu IS NULL THEN setDtCad 
            WHEN setDtAtu > setDtCad THEN setDtAtu 
            ELSE setDtCad 
        END, 'yyyy-MM-dd-HH-mm') AS data
FROM dbo.Setor WITH (NOLOCK, INDEX = idx_Setor_Auditor)
WHERE setCodigo = @id
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
        ConfiguracoesDBT.ExecuteSqlCreate(@"IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'idx_Setor_Auditor' AND object_id = OBJECT_ID('dbo.Setor'))
                BEGIN
                    CREATE INDEX idx_Setor_Auditor ON dbo.Setor(setCodigo, setDtCad, setDtAtu);
                END
                ", oCnnRw);
    }
}