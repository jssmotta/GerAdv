#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IEnquadramentoEmpresaReader
{
    EnquadramentoEmpresaResponse? Read(int id, SqlConnection oCnn);
    EnquadramentoEmpresaResponse? Read(string where, SqlConnection oCnn);
    EnquadramentoEmpresaResponse? Read(Entity.DBEnquadramentoEmpresa dbRec);
    Task<string> ReadStringAuditor(int id, string uri, SqlConnection oCnn);
    EnquadramentoEmpresaResponse? Read(DBEnquadramentoEmpresa dbRec);
}

public partial class EnquadramentoEmpresa : IEnquadramentoEmpresaReader
{
    public EnquadramentoEmpresaResponse? Read(int id, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBEnquadramentoEmpresa(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public EnquadramentoEmpresaResponse? Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBEnquadramentoEmpresa(sqlWhere: where, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public EnquadramentoEmpresaResponse? Read(Entity.DBEnquadramentoEmpresa dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

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

    public EnquadramentoEmpresaResponse? Read(DBEnquadramentoEmpresa dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

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