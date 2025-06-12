#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IPontoVirtualAcessosReader
{
    PontoVirtualAcessosResponse? Read(int id, MsiSqlConnection oCnn);
    PontoVirtualAcessosResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    PontoVirtualAcessosResponse? Read(Entity.DBPontoVirtualAcessos dbRec);
    PontoVirtualAcessosResponse? Read(DBPontoVirtualAcessos dbRec);
    PontoVirtualAcessosResponseAll? ReadAll(DBPontoVirtualAcessos dbRec, DataRow dr);
}

public partial class PontoVirtualAcessos : IPontoVirtualAcessosReader
{
    public PontoVirtualAcessosResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBPontoVirtualAcessos(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public PontoVirtualAcessosResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBPontoVirtualAcessos(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public PontoVirtualAcessosResponse? Read(Entity.DBPontoVirtualAcessos dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var pontovirtualacessos = new PontoVirtualAcessosResponse
        {
            Id = dbRec.ID,
            Operador = dbRec.FOperador,
            Tipo = dbRec.FTipo,
            Origem = dbRec.FOrigem ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FDataHora, out _))
            pontovirtualacessos.DataHora = dbRec.FDataHora;
        return pontovirtualacessos;
    }

    public PontoVirtualAcessosResponse? Read(DBPontoVirtualAcessos dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var pontovirtualacessos = new PontoVirtualAcessosResponse
        {
            Id = dbRec.ID,
            Operador = dbRec.FOperador,
            Tipo = dbRec.FTipo,
            Origem = dbRec.FOrigem ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FDataHora, out _))
            pontovirtualacessos.DataHora = dbRec.FDataHora;
        return pontovirtualacessos;
    }

    public PontoVirtualAcessosResponseAll? ReadAll(DBPontoVirtualAcessos dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var pontovirtualacessos = new PontoVirtualAcessosResponseAll
        {
            Id = dbRec.ID,
            Operador = dbRec.FOperador,
            Tipo = dbRec.FTipo,
            Origem = dbRec.FOrigem ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FDataHora, out _))
            pontovirtualacessos.DataHora = dbRec.FDataHora;
        pontovirtualacessos.NomeOperador = dr["operNome"]?.ToString() ?? string.Empty;
        return pontovirtualacessos;
    }
}