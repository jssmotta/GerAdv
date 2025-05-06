#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IOperadorGruposReader
{
    OperadorGruposResponse? Read(int id, SqlConnection oCnn);
    OperadorGruposResponse? Read(string where, SqlConnection oCnn);
    OperadorGruposResponse? Read(Entity.DBOperadorGrupos dbRec);
    Task<string> ReadStringAuditor(int id, string uri, SqlConnection oCnn);
    OperadorGruposResponse? Read(DBOperadorGrupos dbRec);
}

public partial class OperadorGrupos : IOperadorGruposReader
{
    public OperadorGruposResponse? Read(int id, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBOperadorGrupos(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public OperadorGruposResponse? Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBOperadorGrupos(sqlWhere: where, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public OperadorGruposResponse? Read(Entity.DBOperadorGrupos dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var operadorgrupos = new OperadorGruposResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
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
        operadorgrupos.Auditor = auditor;
        return operadorgrupos;
    }

    public OperadorGruposResponse? Read(DBOperadorGrupos dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var operadorgrupos = new OperadorGruposResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
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
        operadorgrupos.Auditor = auditor;
        return operadorgrupos;
    }
}