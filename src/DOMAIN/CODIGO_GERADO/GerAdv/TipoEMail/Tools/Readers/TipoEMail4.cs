#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ITipoEMailReader
{
    TipoEMailResponse? Read(int id, SqlConnection oCnn);
    TipoEMailResponse? Read(string where, SqlConnection oCnn);
    TipoEMailResponse? Read(Entity.DBTipoEMail dbRec);
    TipoEMailResponse? Read(DBTipoEMail dbRec);
}

public partial class TipoEMail : ITipoEMailReader
{
    public TipoEMailResponse? Read(int id, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBTipoEMail(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public TipoEMailResponse? Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBTipoEMail(sqlWhere: where, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public TipoEMailResponse? Read(Entity.DBTipoEMail dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var tipoemail = new TipoEMailResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
        };
        return tipoemail;
    }

    public TipoEMailResponse? Read(DBTipoEMail dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var tipoemail = new TipoEMailResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
        };
        return tipoemail;
    }
}