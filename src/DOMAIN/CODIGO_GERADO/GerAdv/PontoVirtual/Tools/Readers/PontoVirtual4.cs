#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IPontoVirtualReader
{
    PontoVirtualResponse? Read(int id, SqlConnection oCnn);
    PontoVirtualResponse? Read(string where, SqlConnection oCnn);
    PontoVirtualResponse? Read(Entity.DBPontoVirtual dbRec);
    PontoVirtualResponse? Read(DBPontoVirtual dbRec);
}

public partial class PontoVirtual : IPontoVirtualReader
{
    public PontoVirtualResponse? Read(int id, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBPontoVirtual(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public PontoVirtualResponse? Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBPontoVirtual(sqlWhere: where, oCnn: oCnn);
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
}