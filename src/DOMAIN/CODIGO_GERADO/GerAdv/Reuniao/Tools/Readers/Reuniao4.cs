#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IReuniaoReader
{
    ReuniaoResponse? Read(int id, SqlConnection oCnn);
    ReuniaoResponse? Read(string where, SqlConnection oCnn);
    ReuniaoResponse? Read(Entity.DBReuniao dbRec);
    ReuniaoResponse? Read(DBReuniao dbRec);
}

public partial class Reuniao : IReuniaoReader
{
    public ReuniaoResponse? Read(int id, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBReuniao(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ReuniaoResponse? Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBReuniao(sqlWhere: where, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ReuniaoResponse? Read(Entity.DBReuniao dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var reuniao = new ReuniaoResponse
        {
            Id = dbRec.ID,
            Cliente = dbRec.FCliente,
            IDAgenda = dbRec.FIDAgenda,
            Pauta = dbRec.FPauta ?? string.Empty,
            ATA = dbRec.FATA ?? string.Empty,
            Externa = dbRec.FExterna,
            PrincipaisDecisoes = dbRec.FPrincipaisDecisoes ?? string.Empty,
            Bold = dbRec.FBold,
            Guid = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            reuniao.Data = dbRec.FData;
        if (DateTime.TryParse(dbRec.FHoraInicial, out _))
            reuniao.HoraInicial = dbRec.FHoraInicial;
        if (DateTime.TryParse(dbRec.FHoraFinal, out _))
            reuniao.HoraFinal = dbRec.FHoraFinal;
        if (DateTime.TryParse(dbRec.FHoraSaida, out _))
            reuniao.HoraSaida = dbRec.FHoraSaida;
        if (DateTime.TryParse(dbRec.FHoraRetorno, out _))
            reuniao.HoraRetorno = dbRec.FHoraRetorno;
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
        reuniao.Auditor = auditor;
        return reuniao;
    }

    public ReuniaoResponse? Read(DBReuniao dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var reuniao = new ReuniaoResponse
        {
            Id = dbRec.ID,
            Cliente = dbRec.FCliente,
            IDAgenda = dbRec.FIDAgenda,
            Pauta = dbRec.FPauta ?? string.Empty,
            ATA = dbRec.FATA ?? string.Empty,
            Externa = dbRec.FExterna,
            PrincipaisDecisoes = dbRec.FPrincipaisDecisoes ?? string.Empty,
            Bold = dbRec.FBold,
            Guid = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            reuniao.Data = dbRec.FData;
        if (DateTime.TryParse(dbRec.FHoraInicial, out _))
            reuniao.HoraInicial = dbRec.FHoraInicial;
        if (DateTime.TryParse(dbRec.FHoraFinal, out _))
            reuniao.HoraFinal = dbRec.FHoraFinal;
        if (DateTime.TryParse(dbRec.FHoraSaida, out _))
            reuniao.HoraSaida = dbRec.FHoraSaida;
        if (DateTime.TryParse(dbRec.FHoraRetorno, out _))
            reuniao.HoraRetorno = dbRec.FHoraRetorno;
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
        reuniao.Auditor = auditor;
        return reuniao;
    }
}