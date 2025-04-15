#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Wheres;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ICargosEscWhere
{
    CargosEscResponse Read(string where, SqlConnection oCnn);
}

public partial class CargosEsc : ICargosEscWhere
{
    public CargosEscResponse Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBCargosEsc(sqlWhere: where, oCnn: oCnn);
        var cargosesc = new CargosEscResponse
        {
            Id = dbRec.ID,
            Percentual = dbRec.FPercentual,
            Nome = dbRec.FNome ?? string.Empty,
            Classificacao = dbRec.FClassificacao,
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
        cargosesc.Auditor = auditor;
        return cargosesc;
    }
}