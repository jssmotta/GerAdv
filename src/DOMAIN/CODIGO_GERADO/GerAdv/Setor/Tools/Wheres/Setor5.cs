﻿#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Wheres;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ISetorWhere
{
    SetorResponse Read(string where, SqlConnection oCnn);
}

public partial class Setor : ISetorWhere
{
    public SetorResponse Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBSetor(sqlWhere: where, oCnn: oCnn);
        var setor = new SetorResponse
        {
            Id = dbRec.ID,
            Descricao = dbRec.FDescricao ?? string.Empty,
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
        setor.Auditor = auditor;
        return setor;
    }
}