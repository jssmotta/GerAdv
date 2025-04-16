#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IAndamentosMDReader
{
    AndamentosMDResponse? Read(int id, SqlConnection oCnn);
    AndamentosMDResponse? Read(string where, SqlConnection oCnn);
    AndamentosMDResponse? Read(Entity.DBAndamentosMD dbRec);
    AndamentosMDResponse? Read(DBAndamentosMD dbRec);
}

public partial class AndamentosMD : IAndamentosMDReader
{
    public AndamentosMDResponse? Read(int id, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBAndamentosMD(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public AndamentosMDResponse? Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBAndamentosMD(sqlWhere: where, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public AndamentosMDResponse? Read(Entity.DBAndamentosMD dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var andamentosmd = new AndamentosMDResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Processo = dbRec.FProcesso,
            Andamento = dbRec.FAndamento,
            PathFull = dbRec.FPathFull ?? string.Empty,
            UNC = dbRec.FUNC ?? string.Empty,
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
        andamentosmd.Auditor = auditor;
        return andamentosmd;
    }

    public AndamentosMDResponse? Read(DBAndamentosMD dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var andamentosmd = new AndamentosMDResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Processo = dbRec.FProcesso,
            Andamento = dbRec.FAndamento,
            PathFull = dbRec.FPathFull ?? string.Empty,
            UNC = dbRec.FUNC ?? string.Empty,
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
        andamentosmd.Auditor = auditor;
        return andamentosmd;
    }
}