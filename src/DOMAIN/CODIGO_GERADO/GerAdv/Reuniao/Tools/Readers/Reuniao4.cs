#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IReuniaoReader
{
    ReuniaoResponse? Read(int id, MsiSqlConnection oCnn);
    ReuniaoResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    ReuniaoResponse? Read(Entity.DBReuniao dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    ReuniaoResponse? Read(DBReuniao dbRec);
    ReuniaoResponseAll? ReadAll(DBReuniao dbRec, DataRow dr);
}

public partial class Reuniao : IReuniaoReader
{
    public ReuniaoResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBReuniao(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ReuniaoResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBReuniao(sqlWhere: where, parameters: parameters, oCnn: oCnn);
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
            GUID = dbRec.FGUID ?? string.Empty,
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
            GUID = dbRec.FGUID ?? string.Empty,
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
        return reuniao;
    }

    public ReuniaoResponseAll? ReadAll(DBReuniao dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var reuniao = new ReuniaoResponseAll
        {
            Id = dbRec.ID,
            Cliente = dbRec.FCliente,
            IDAgenda = dbRec.FIDAgenda,
            Pauta = dbRec.FPauta ?? string.Empty,
            ATA = dbRec.FATA ?? string.Empty,
            Externa = dbRec.FExterna,
            PrincipaisDecisoes = dbRec.FPrincipaisDecisoes ?? string.Empty,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
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
        reuniao.NomeClientes = dr["cliNome"]?.ToString() ?? string.Empty;
        return reuniao;
    }
}