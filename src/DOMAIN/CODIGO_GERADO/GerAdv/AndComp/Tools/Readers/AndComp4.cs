#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IAndCompReader
{
    AndCompResponse? Read(int id, MsiSqlConnection oCnn);
    AndCompResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    AndCompResponse? Read(Entity.DBAndComp dbRec);
    AndCompResponse? Read(DBAndComp dbRec);
    AndCompResponseAll? ReadAll(DBAndComp dbRec, DataRow dr);
}

public partial class AndComp : IAndCompReader
{
    public AndCompResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBAndComp(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public AndCompResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBAndComp(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public AndCompResponse? Read(Entity.DBAndComp dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var andcomp = new AndCompResponse
        {
            Id = dbRec.ID,
            Andamento = dbRec.FAndamento,
            Compromisso = dbRec.FCompromisso,
        };
        return andcomp;
    }

    public AndCompResponse? Read(DBAndComp dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var andcomp = new AndCompResponse
        {
            Id = dbRec.ID,
            Andamento = dbRec.FAndamento,
            Compromisso = dbRec.FCompromisso,
        };
        return andcomp;
    }

    public AndCompResponseAll? ReadAll(DBAndComp dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var andcomp = new AndCompResponseAll
        {
            Id = dbRec.ID,
            Andamento = dbRec.FAndamento,
            Compromisso = dbRec.FCompromisso,
        };
        return andcomp;
    }
}