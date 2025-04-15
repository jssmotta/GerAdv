#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Wheres;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ITipoEMailWhere
{
    TipoEMailResponse Read(string where, SqlConnection oCnn);
}

public partial class TipoEMail : ITipoEMailWhere
{
    public TipoEMailResponse Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBTipoEMail(sqlWhere: where, oCnn: oCnn);
        var tipoemail = new TipoEMailResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
        };
        return tipoemail;
    }
}