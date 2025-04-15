#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Wheres;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IStatusInstanciaWhere
{
    StatusInstanciaResponse Read(string where, SqlConnection oCnn);
}

public partial class StatusInstancia : IStatusInstanciaWhere
{
    public StatusInstanciaResponse Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBStatusInstancia(sqlWhere: where, oCnn: oCnn);
        var statusinstancia = new StatusInstanciaResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Bold = dbRec.FBold,
        };
        var auditor = new Auditor
        {
            Visto = dbRec.FVisto,
            QuemCad = dbRec.FQuemCad
        };
        if (auditor.QuemAtu > 0)
            auditor.QuemAtu = dbRec.FQuemAtu;
        if (dbRec.FDtCad.NotIsEmpty())
            auditor.DtCad = Convert.ToDateTime(dbRec.FDtCad);
        if (!(dbRec.FDtAtu is { }))
            auditor.DtAtu = Convert.ToDateTime(dbRec.FDtAtu);
        statusinstancia.Auditor = auditor;
        return statusinstancia;
    }
}