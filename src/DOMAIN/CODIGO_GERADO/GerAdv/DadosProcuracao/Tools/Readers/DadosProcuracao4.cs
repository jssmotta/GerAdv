#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IDadosProcuracaoReader
{
    DadosProcuracaoResponse? Read(int id, SqlConnection oCnn);
    DadosProcuracaoResponse? Read(string where, SqlConnection oCnn);
    DadosProcuracaoResponse? Read(Entity.DBDadosProcuracao dbRec);
    DadosProcuracaoResponse? Read(DBDadosProcuracao dbRec);
}

public partial class DadosProcuracao : IDadosProcuracaoReader
{
    public DadosProcuracaoResponse? Read(int id, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBDadosProcuracao(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public DadosProcuracaoResponse? Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBDadosProcuracao(sqlWhere: where, oCnn: oCnn);
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
            Guid = dbRec.FGUID ?? string.Empty,
        };
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
        dadosprocuracao.Auditor = auditor;
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
            Guid = dbRec.FGUID ?? string.Empty,
        };
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
        dadosprocuracao.Auditor = auditor;
        return dadosprocuracao;
    }
}