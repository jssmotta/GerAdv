﻿#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Wheres;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IEnquadramentoEmpresaWhere
{
    EnquadramentoEmpresaResponse Read(string where, SqlConnection oCnn);
}

public partial class EnquadramentoEmpresa : IEnquadramentoEmpresaWhere
{
    public EnquadramentoEmpresaResponse Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBEnquadramentoEmpresa(sqlWhere: where, oCnn: oCnn);
        var enquadramentoempresa = new EnquadramentoEmpresaResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
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
        enquadramentoempresa.Auditor = auditor;
        return enquadramentoempresa;
    }
}