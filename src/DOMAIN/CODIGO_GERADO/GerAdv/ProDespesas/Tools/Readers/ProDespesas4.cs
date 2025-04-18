#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IProDespesasReader
{
    ProDespesasResponse? Read(int id, SqlConnection oCnn);
    ProDespesasResponse? Read(string where, SqlConnection oCnn);
    ProDespesasResponse? Read(Entity.DBProDespesas dbRec);
    Task<string> ReadStringAuditor(int id, string uri, SqlConnection oCnn);
    ProDespesasResponse? Read(DBProDespesas dbRec);
}

public partial class ProDespesas : IProDespesasReader
{
    public ProDespesasResponse? Read(int id, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBProDespesas(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ProDespesasResponse? Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBProDespesas(sqlWhere: where, oCnn: oCnn);
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
            Guid = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            prodespesas.Data = dbRec.FData;
        if (DateTime.TryParse(dbRec.FDataCorrecao, out _))
            prodespesas.DataCorrecao = dbRec.FDataCorrecao;
        var auditor = new Auditor
        {
            Visto = dbRec.FVisto,
            QuemCad = dbRec.FQuemCad
        };
        if (auditor.QuemAtu > 0)
            auditor.QuemAtu = dbRec.FQuemAtu;
        if (dbRec.FDtCad.NotIsEmpty())
            auditor.DtCad = Convert.ToDateTime(dbRec.FDtCad);
        if (!(dbRec.FDtAtu is { }))
            auditor.DtAtu = Convert.ToDateTime(dbRec.FDtAtu);
        prodespesas.Auditor = auditor;
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
            Guid = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            prodespesas.Data = dbRec.FData;
        if (DateTime.TryParse(dbRec.FDataCorrecao, out _))
            prodespesas.DataCorrecao = dbRec.FDataCorrecao;
        var auditor = new Auditor
        {
            Visto = dbRec.FVisto,
            QuemCad = dbRec.FQuemCad
        };
        if (auditor.QuemAtu > 0)
            auditor.QuemAtu = dbRec.FQuemAtu;
        if (dbRec.FDtCad.NotIsEmpty())
            auditor.DtCad = Convert.ToDateTime(dbRec.FDtCad);
        if (!(dbRec.FDtAtu is { }))
            auditor.DtAtu = Convert.ToDateTime(dbRec.FDtAtu);
        prodespesas.Auditor = auditor;
        return prodespesas;
    }
}