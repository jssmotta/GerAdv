#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IProDespesasReader
{
    ProDespesasResponse? Read(int id, MsiSqlConnection oCnn);
    ProDespesasResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    ProDespesasResponse? Read(Entity.DBProDespesas dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    ProDespesasResponse? Read(DBProDespesas dbRec);
    ProDespesasResponseAll? ReadAll(DBProDespesas dbRec, DataRow dr);
}

public partial class ProDespesas : IProDespesasReader
{
    public ProDespesasResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBProDespesas(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ProDespesasResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBProDespesas(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ProDespesasResponse? Read(Entity.DBProDespesas dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var prodespesas = new ProDespesasResponse
        {
            Id = dbRec.ID,
            LigacaoID = dbRec.FLigacaoID,
            Cliente = dbRec.FCliente,
            Corrigido = dbRec.FCorrigido,
            ValorOriginal = dbRec.FValorOriginal,
            Processo = dbRec.FProcesso,
            Quitado = dbRec.FQuitado,
            Valor = dbRec.FValor,
            Tipo = dbRec.FTipo,
            Historico = dbRec.FHistorico ?? string.Empty,
            LivroCaixa = dbRec.FLivroCaixa,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            prodespesas.Data = dbRec.FData;
        if (DateTime.TryParse(dbRec.FDataCorrecao, out _))
            prodespesas.DataCorrecao = dbRec.FDataCorrecao;
        return prodespesas;
    }

    public ProDespesasResponse? Read(DBProDespesas dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var prodespesas = new ProDespesasResponse
        {
            Id = dbRec.ID,
            LigacaoID = dbRec.FLigacaoID,
            Cliente = dbRec.FCliente,
            Corrigido = dbRec.FCorrigido,
            ValorOriginal = dbRec.FValorOriginal,
            Processo = dbRec.FProcesso,
            Quitado = dbRec.FQuitado,
            Valor = dbRec.FValor,
            Tipo = dbRec.FTipo,
            Historico = dbRec.FHistorico ?? string.Empty,
            LivroCaixa = dbRec.FLivroCaixa,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            prodespesas.Data = dbRec.FData;
        if (DateTime.TryParse(dbRec.FDataCorrecao, out _))
            prodespesas.DataCorrecao = dbRec.FDataCorrecao;
        return prodespesas;
    }

    public ProDespesasResponseAll? ReadAll(DBProDespesas dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var prodespesas = new ProDespesasResponseAll
        {
            Id = dbRec.ID,
            LigacaoID = dbRec.FLigacaoID,
            Cliente = dbRec.FCliente,
            Corrigido = dbRec.FCorrigido,
            ValorOriginal = dbRec.FValorOriginal,
            Processo = dbRec.FProcesso,
            Quitado = dbRec.FQuitado,
            Valor = dbRec.FValor,
            Tipo = dbRec.FTipo,
            Historico = dbRec.FHistorico ?? string.Empty,
            LivroCaixa = dbRec.FLivroCaixa,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            prodespesas.Data = dbRec.FData;
        if (DateTime.TryParse(dbRec.FDataCorrecao, out _))
            prodespesas.DataCorrecao = dbRec.FDataCorrecao;
        prodespesas.NomeClientes = dr["cliNome"]?.ToString() ?? string.Empty;
        prodespesas.NroPastaProcessos = dr["proNroPasta"]?.ToString() ?? string.Empty;
        return prodespesas;
    }
}