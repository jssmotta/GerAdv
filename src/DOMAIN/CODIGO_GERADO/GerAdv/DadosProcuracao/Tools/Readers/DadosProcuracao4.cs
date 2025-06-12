#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IDadosProcuracaoReader
{
    DadosProcuracaoResponse? Read(int id, MsiSqlConnection oCnn);
    DadosProcuracaoResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    DadosProcuracaoResponse? Read(Entity.DBDadosProcuracao dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    DadosProcuracaoResponse? Read(DBDadosProcuracao dbRec);
    DadosProcuracaoResponseAll? ReadAll(DBDadosProcuracao dbRec, DataRow dr);
}

public partial class DadosProcuracao : IDadosProcuracaoReader
{
    public DadosProcuracaoResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBDadosProcuracao(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public DadosProcuracaoResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBDadosProcuracao(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public DadosProcuracaoResponse? Read(Entity.DBDadosProcuracao dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var dadosprocuracao = new DadosProcuracaoResponse
        {
            Id = dbRec.ID,
            Cliente = dbRec.FCliente,
            EstadoCivil = dbRec.FEstadoCivil ?? string.Empty,
            Nacionalidade = dbRec.FNacionalidade ?? string.Empty,
            Profissao = dbRec.FProfissao ?? string.Empty,
            CTPS = dbRec.FCTPS ?? string.Empty,
            PisPasep = dbRec.FPisPasep ?? string.Empty,
            Remuneracao = dbRec.FRemuneracao ?? string.Empty,
            Objeto = dbRec.FObjeto ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return dadosprocuracao;
    }

    public DadosProcuracaoResponse? Read(DBDadosProcuracao dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var dadosprocuracao = new DadosProcuracaoResponse
        {
            Id = dbRec.ID,
            Cliente = dbRec.FCliente,
            EstadoCivil = dbRec.FEstadoCivil ?? string.Empty,
            Nacionalidade = dbRec.FNacionalidade ?? string.Empty,
            Profissao = dbRec.FProfissao ?? string.Empty,
            CTPS = dbRec.FCTPS ?? string.Empty,
            PisPasep = dbRec.FPisPasep ?? string.Empty,
            Remuneracao = dbRec.FRemuneracao ?? string.Empty,
            Objeto = dbRec.FObjeto ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return dadosprocuracao;
    }

    public DadosProcuracaoResponseAll? ReadAll(DBDadosProcuracao dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var dadosprocuracao = new DadosProcuracaoResponseAll
        {
            Id = dbRec.ID,
            Cliente = dbRec.FCliente,
            EstadoCivil = dbRec.FEstadoCivil ?? string.Empty,
            Nacionalidade = dbRec.FNacionalidade ?? string.Empty,
            Profissao = dbRec.FProfissao ?? string.Empty,
            CTPS = dbRec.FCTPS ?? string.Empty,
            PisPasep = dbRec.FPisPasep ?? string.Empty,
            Remuneracao = dbRec.FRemuneracao ?? string.Empty,
            Objeto = dbRec.FObjeto ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        dadosprocuracao.NomeClientes = dr["cliNome"]?.ToString() ?? string.Empty;
        return dadosprocuracao;
    }
}