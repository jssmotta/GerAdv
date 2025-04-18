#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IBensMateriaisReader
{
    BensMateriaisResponse? Read(int id, SqlConnection oCnn);
    BensMateriaisResponse? Read(string where, SqlConnection oCnn);
    BensMateriaisResponse? Read(Entity.DBBensMateriais dbRec);
    Task<string> ReadStringAuditor(int id, string uri, SqlConnection oCnn);
    BensMateriaisResponse? Read(DBBensMateriais dbRec);
}

public partial class BensMateriais : IBensMateriaisReader
{
    public BensMateriaisResponse? Read(int id, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBBensMateriais(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public BensMateriaisResponse? Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBBensMateriais(sqlWhere: where, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public BensMateriaisResponse? Read(Entity.DBBensMateriais dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var bensmateriais = new BensMateriaisResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            BensClassificacao = dbRec.FBensClassificacao,
            NFNRO = dbRec.FNFNRO ?? string.Empty,
            Fornecedor = dbRec.FFornecedor,
            ValorBem = dbRec.FValorBem,
            NroSerieProduto = dbRec.FNroSerieProduto ?? string.Empty,
            Comprador = dbRec.FComprador ?? string.Empty,
            Cidade = dbRec.FCidade,
            GarantiaLoja = dbRec.FGarantiaLoja,
            Observacoes = dbRec.FObservacoes ?? string.Empty,
            NomeVendedor = dbRec.FNomeVendedor ?? string.Empty,
            Bold = dbRec.FBold,
            Guid = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FDataCompra, out _))
            bensmateriais.DataCompra = dbRec.FDataCompra;
        if (DateTime.TryParse(dbRec.FDataFimDaGarantia, out _))
            bensmateriais.DataFimDaGarantia = dbRec.FDataFimDaGarantia;
        if (DateTime.TryParse(dbRec.FDataTerminoDaGarantiaDaLoja, out _))
            bensmateriais.DataTerminoDaGarantiaDaLoja = dbRec.FDataTerminoDaGarantiaDaLoja;
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
        bensmateriais.Auditor = auditor;
        return bensmateriais;
    }

    public BensMateriaisResponse? Read(DBBensMateriais dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var bensmateriais = new BensMateriaisResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            BensClassificacao = dbRec.FBensClassificacao,
            NFNRO = dbRec.FNFNRO ?? string.Empty,
            Fornecedor = dbRec.FFornecedor,
            ValorBem = dbRec.FValorBem,
            NroSerieProduto = dbRec.FNroSerieProduto ?? string.Empty,
            Comprador = dbRec.FComprador ?? string.Empty,
            Cidade = dbRec.FCidade,
            GarantiaLoja = dbRec.FGarantiaLoja,
            Observacoes = dbRec.FObservacoes ?? string.Empty,
            NomeVendedor = dbRec.FNomeVendedor ?? string.Empty,
            Bold = dbRec.FBold,
            Guid = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FDataCompra, out _))
            bensmateriais.DataCompra = dbRec.FDataCompra;
        if (DateTime.TryParse(dbRec.FDataFimDaGarantia, out _))
            bensmateriais.DataFimDaGarantia = dbRec.FDataFimDaGarantia;
        if (DateTime.TryParse(dbRec.FDataTerminoDaGarantiaDaLoja, out _))
            bensmateriais.DataTerminoDaGarantiaDaLoja = dbRec.FDataTerminoDaGarantiaDaLoja;
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
        bensmateriais.Auditor = auditor;
        return bensmateriais;
    }
}