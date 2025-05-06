#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial class ContatoCRM
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
            WHEN ctcDtAtu IS NULL THEN ctcDtCad 
            WHEN ctcDtAtu > ctcDtCad THEN ctcDtAtu 
            ELSE ctcDtCad 
        END, 'yyyy-MM-dd-HH-mm') AS data
FROM dbo.ContatoCRM WITH (NOLOCK, INDEX = idx_ContatoCRM_Auditor)
WHERE ctcCodigo = @id
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
        ConfiguracoesDBT.ExecuteSqlCreate(@"IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'idx_ContatoCRM_Auditor' AND object_id = OBJECT_ID('dbo.ContatoCRM'))
                BEGIN
                    CREATE INDEX idx_ContatoCRM_Auditor ON dbo.ContatoCRM(ctcCodigo, ctcDtCad, ctcDtAtu);
                END
                ", oCnnRw);
    }
}