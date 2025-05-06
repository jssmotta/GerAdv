#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IOperadorGruposAgendaReader
{
    OperadorGruposAgendaResponse? Read(int id, SqlConnection oCnn);
    OperadorGruposAgendaResponse? Read(string where, SqlConnection oCnn);
    OperadorGruposAgendaResponse? Read(Entity.DBOperadorGruposAgenda dbRec);
    Task<string> ReadStringAuditor(int id, string uri, SqlConnection oCnn);
    OperadorGruposAgendaResponse? Read(DBOperadorGruposAgenda dbRec);
}

public partial class OperadorGruposAgenda : IOperadorGruposAgendaReader
{
    public OperadorGruposAgendaResponse? Read(int id, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBOperadorGruposAgenda(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public OperadorGruposAgendaResponse? Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBOperadorGruposAgenda(sqlWhere: where, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public OperadorGruposAgendaResponse? Read(Entity.DBOperadorGruposAgenda dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var operadorgruposagenda = new OperadorGruposAgendaResponse
        {
            Id = dbRec.ID,
            SQLWhere = dbRec.FSQLWhere ?? string.Empty,
            Nome = dbRec.FNome ?? string.Empty,
            Operador = dbRec.FOperador,
            GUID = dbRec.FGUID ?? string.Empty,
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
        operadorgruposagenda.Auditor = auditor;
        return operadorgruposagenda;
    }

    public OperadorGruposAgendaResponse? Read(DBOperadorGruposAgenda dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var operadorgruposagenda = new OperadorGruposAgendaResponse
        {
            Id = dbRec.ID,
            SQLWhere = dbRec.FSQLWhere ?? string.Empty,
            Nome = dbRec.FNome ?? string.Empty,
            Operador = dbRec.FOperador,
            GUID = dbRec.FGUID ?? string.Empty,
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
        operadorgruposagenda.Auditor = auditor;
        return operadorgruposagenda;
    }
}