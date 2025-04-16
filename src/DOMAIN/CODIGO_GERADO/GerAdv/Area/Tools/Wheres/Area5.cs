﻿#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Wheres;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IAreaWhere
{
    AreaResponse Read(string where, SqlConnection oCnn);
}

public partial class Area : IAreaWhere
{
    public AreaResponse Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBArea(sqlWhere: where, oCnn: oCnn);
        var area = new AreaResponse
        {
            Id = dbRec.ID,
            Descricao = dbRec.FDescricao ?? string.Empty,
            Top = dbRec.FTop,
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
        area.Auditor = auditor;
        return area;
    }
}