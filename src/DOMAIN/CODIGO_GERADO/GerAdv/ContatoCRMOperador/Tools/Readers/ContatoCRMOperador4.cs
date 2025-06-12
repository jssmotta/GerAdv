#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IContatoCRMOperadorReader
{
    ContatoCRMOperadorResponse? Read(int id, MsiSqlConnection oCnn);
    ContatoCRMOperadorResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    ContatoCRMOperadorResponse? Read(Entity.DBContatoCRMOperador dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    ContatoCRMOperadorResponse? Read(DBContatoCRMOperador dbRec);
    ContatoCRMOperadorResponseAll? ReadAll(DBContatoCRMOperador dbRec, DataRow dr);
}

public partial class ContatoCRMOperador : IContatoCRMOperadorReader
{
    public ContatoCRMOperadorResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBContatoCRMOperador(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ContatoCRMOperadorResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBContatoCRMOperador(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ContatoCRMOperadorResponse? Read(Entity.DBContatoCRMOperador dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var contatocrmoperador = new ContatoCRMOperadorResponse
        {
            Id = dbRec.ID,
            ContatoCRM = dbRec.FContatoCRM,
            CargoEsc = dbRec.FCargoEsc,
            Operador = dbRec.FOperador,
        };
        return contatocrmoperador;
    }

    public ContatoCRMOperadorResponse? Read(DBContatoCRMOperador dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var contatocrmoperador = new ContatoCRMOperadorResponse
        {
            Id = dbRec.ID,
            ContatoCRM = dbRec.FContatoCRM,
            CargoEsc = dbRec.FCargoEsc,
            Operador = dbRec.FOperador,
        };
        return contatocrmoperador;
    }

    public ContatoCRMOperadorResponseAll? ReadAll(DBContatoCRMOperador dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var contatocrmoperador = new ContatoCRMOperadorResponseAll
        {
            Id = dbRec.ID,
            ContatoCRM = dbRec.FContatoCRM,
            CargoEsc = dbRec.FCargoEsc,
            Operador = dbRec.FOperador,
        };
        contatocrmoperador.NomeOperador = dr["operNome"]?.ToString() ?? string.Empty;
        return contatocrmoperador;
    }
}