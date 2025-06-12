#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IPontoVirtualReader
{
    PontoVirtualResponse? Read(int id, MsiSqlConnection oCnn);
    PontoVirtualResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    PontoVirtualResponse? Read(Entity.DBPontoVirtual dbRec);
    PontoVirtualResponse? Read(DBPontoVirtual dbRec);
    PontoVirtualResponseAll? ReadAll(DBPontoVirtual dbRec, DataRow dr);
}

public partial class PontoVirtual : IPontoVirtualReader
{
    public PontoVirtualResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBPontoVirtual(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public PontoVirtualResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBPontoVirtual(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public PontoVirtualResponse? Read(Entity.DBPontoVirtual dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var pontovirtual = new PontoVirtualResponse
        {
            Id = dbRec.ID,
            Operador = dbRec.FOperador,
            Key = dbRec.FKey ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FHoraEntrada, out _))
            pontovirtual.HoraEntrada = dbRec.FHoraEntrada;
        if (DateTime.TryParse(dbRec.FHoraSaida, out _))
            pontovirtual.HoraSaida = dbRec.FHoraSaida;
        return pontovirtual;
    }

    public PontoVirtualResponse? Read(DBPontoVirtual dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var pontovirtual = new PontoVirtualResponse
        {
            Id = dbRec.ID,
            Operador = dbRec.FOperador,
            Key = dbRec.FKey ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FHoraEntrada, out _))
            pontovirtual.HoraEntrada = dbRec.FHoraEntrada;
        if (DateTime.TryParse(dbRec.FHoraSaida, out _))
            pontovirtual.HoraSaida = dbRec.FHoraSaida;
        return pontovirtual;
    }

    public PontoVirtualResponseAll? ReadAll(DBPontoVirtual dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var pontovirtual = new PontoVirtualResponseAll
        {
            Id = dbRec.ID,
            Operador = dbRec.FOperador,
            Key = dbRec.FKey ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FHoraEntrada, out _))
            pontovirtual.HoraEntrada = dbRec.FHoraEntrada;
        if (DateTime.TryParse(dbRec.FHoraSaida, out _))
            pontovirtual.HoraSaida = dbRec.FHoraSaida;
        pontovirtual.NomeOperador = dr["operNome"]?.ToString() ?? string.Empty;
        return pontovirtual;
    }
}