#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IReuniaoPessoasReader
{
    ReuniaoPessoasResponse? Read(int id, MsiSqlConnection oCnn);
    ReuniaoPessoasResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    ReuniaoPessoasResponse? Read(Entity.DBReuniaoPessoas dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    ReuniaoPessoasResponse? Read(DBReuniaoPessoas dbRec);
    ReuniaoPessoasResponseAll? ReadAll(DBReuniaoPessoas dbRec, DataRow dr);
}

public partial class ReuniaoPessoas : IReuniaoPessoasReader
{
    public ReuniaoPessoasResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBReuniaoPessoas(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ReuniaoPessoasResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBReuniaoPessoas(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ReuniaoPessoasResponse? Read(Entity.DBReuniaoPessoas dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var reuniaopessoas = new ReuniaoPessoasResponse
        {
            Id = dbRec.ID,
            Reuniao = dbRec.FReuniao,
            Operador = dbRec.FOperador,
        };
        return reuniaopessoas;
    }

    public ReuniaoPessoasResponse? Read(DBReuniaoPessoas dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var reuniaopessoas = new ReuniaoPessoasResponse
        {
            Id = dbRec.ID,
            Reuniao = dbRec.FReuniao,
            Operador = dbRec.FOperador,
        };
        return reuniaopessoas;
    }

    public ReuniaoPessoasResponseAll? ReadAll(DBReuniaoPessoas dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var reuniaopessoas = new ReuniaoPessoasResponseAll
        {
            Id = dbRec.ID,
            Reuniao = dbRec.FReuniao,
            Operador = dbRec.FOperador,
        };
        reuniaopessoas.NomeOperador = dr["operNome"]?.ToString() ?? string.Empty;
        return reuniaopessoas;
    }
}