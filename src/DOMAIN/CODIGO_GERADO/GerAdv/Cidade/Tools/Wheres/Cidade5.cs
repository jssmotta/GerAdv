#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Wheres;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ICidadeWhere
{
    CidadeResponse Read(string where, SqlConnection oCnn);
}

public partial class Cidade : ICidadeWhere
{
    public CidadeResponse Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBCidade(sqlWhere: where, oCnn: oCnn);
        var cidade = new CidadeResponse
        {
            Id = dbRec.ID,
            DDD = dbRec.FDDD ?? string.Empty,
            Top = dbRec.FTop,
            Comarca = dbRec.FComarca,
            Capital = dbRec.FCapital,
            Nome = dbRec.FNome ?? string.Empty,
            UF = dbRec.FUF,
            Sigla = dbRec.FSigla ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
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
        cidade.Auditor = auditor;
        return cidade;
    }
}