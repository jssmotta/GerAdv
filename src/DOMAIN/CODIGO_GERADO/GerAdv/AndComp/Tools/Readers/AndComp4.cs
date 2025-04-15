#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IAndCompReader
{
    AndCompResponse? Read(int id, SqlConnection oCnn);
    AndCompResponse? Read(string where, SqlConnection oCnn);
    AndCompResponse? Read(Entity.DBAndComp dbRec);
    AndCompResponse? Read(DBAndComp dbRec);
}

public partial class AndComp : IAndCompReader
{
    public AndCompResponse? Read(int id, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBAndComp(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public AndCompResponse? Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBAndComp(sqlWhere: where, oCnn: oCnn);
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
}