#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial class Agenda2Agenda
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
            WHEN ag2DtAtu IS NULL THEN ag2DtCad 
            WHEN ag2DtAtu > ag2DtCad THEN ag2DtAtu 
            ELSE ag2DtCad 
        END, 'yyyy-MM-dd-HH-mm') AS data
FROM dbo.Agenda2Agenda WITH (NOLOCK, INDEX = idx_Agenda2Agenda_Auditor)
WHERE ag2Codigo = @id
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
        ConfiguracoesDBT.ExecuteSqlCreate(@"IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'idx_Agenda2Agenda_Auditor' AND object_id = OBJECT_ID('dbo.Agenda2Agenda'))
                BEGIN
                    CREATE INDEX idx_Agenda2Agenda_Auditor ON dbo.Agenda2Agenda(ag2Codigo, ag2DtCad, ag2DtAtu);
                END
                ", oCnnRw);
    }
}