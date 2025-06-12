#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IOperadorGrupoReader
{
    OperadorGrupoResponse? Read(int id, MsiSqlConnection oCnn);
    OperadorGrupoResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    OperadorGrupoResponse? Read(Entity.DBOperadorGrupo dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    OperadorGrupoResponse? Read(DBOperadorGrupo dbRec);
    OperadorGrupoResponseAll? ReadAll(DBOperadorGrupo dbRec, DataRow dr);
}

public partial class OperadorGrupo : IOperadorGrupoReader
{
    public OperadorGrupoResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBOperadorGrupo(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public OperadorGrupoResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBOperadorGrupo(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public OperadorGrupoResponse? Read(Entity.DBOperadorGrupo dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var operadorgrupo = new OperadorGrupoResponse
        {
            Id = dbRec.ID,
            Operador = dbRec.FOperador,
            Grupo = dbRec.FGrupo,
            Inativo = dbRec.FInativo,
        };
        return operadorgrupo;
    }

    public OperadorGrupoResponse? Read(DBOperadorGrupo dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var operadorgrupo = new OperadorGrupoResponse
        {
            Id = dbRec.ID,
            Operador = dbRec.FOperador,
            Grupo = dbRec.FGrupo,
            Inativo = dbRec.FInativo,
        };
        return operadorgrupo;
    }

    public OperadorGrupoResponseAll? ReadAll(DBOperadorGrupo dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var operadorgrupo = new OperadorGrupoResponseAll
        {
            Id = dbRec.ID,
            Operador = dbRec.FOperador,
            Grupo = dbRec.FGrupo,
            Inativo = dbRec.FInativo,
        };
        operadorgrupo.NomeOperador = dr["operNome"]?.ToString() ?? string.Empty;
        return operadorgrupo;
    }
}