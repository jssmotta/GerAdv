#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.WarmUp;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial class OperadorGruposAgenda
{
    public async Task WarmReadStringAuditor(string uri, MsiSqlConnection oCnn) => await CreateIdx(uri, oCnn);
    private async Task CreateIdx(string uri, MsiSqlConnection oCnn)
    {
        Console.WriteLine($"WarmUp OperadorGruposAgenda: {uri}");
        var testSql = $"SELECT TOP (1) '1' FROM sys.indexes WHERE name = 'idx_OperadorGruposAgenda_AuditorDtAtu' AND object_id = OBJECT_ID('[{oCnn.UseDbo}].[OperadorGruposAgenda]')";
        using var cmd = new SqlCommand(testSql, oCnn.InnerConnection);
        var result = $"{await cmd.ExecuteScalarAsync()}";
        if (result == "1")
        {
            return;
        }

        using var oCnnRw = Configuracoes.GetConnectionByUriRw(uri);
        if (oCnnRw is null)
            return;
        ConfiguracoesDBT.ExecuteSqlCreate($@"IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'idx_OperadorGruposAgenda_AuditorDtAtu' AND object_id = OBJECT_ID('[{oCnnRw.UseDbo}].[OperadorGruposAgenda]'))
                BEGIN
                    DROP INDEX [{oCnnRw.UseDbo}]idx_OperadorGruposAgenda_Auditor;
                END
                ", oCnnRw);
        ConfiguracoesDBT.ExecuteSqlCreate($@"IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'idx_OperadorGruposAgenda_AuditorDtAtu' AND object_id = OBJECT_ID('[{oCnnRw.UseDbo}].[OperadorGruposAgenda]'))
                BEGIN                    
                    CREATE INDEX idx_OperadorGruposAgenda_AuditorDtAtu ON [{oCnnRw.UseDbo}].[OperadorGruposAgenda](groCodigo, groDtAtu);
                END
                ", oCnnRw);
    }
}