#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Wheres;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IGruposEmpresasWhere
{
    GruposEmpresasResponse Read(string where, SqlConnection oCnn);
}

public partial class GruposEmpresas : IGruposEmpresasWhere
{
    public GruposEmpresasResponse Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBGruposEmpresas(sqlWhere: where, oCnn: oCnn);
        var gruposempresas = new GruposEmpresasResponse
        {
            Id = dbRec.ID,
            EMail = dbRec.FEMail ?? string.Empty,
            Inativo = dbRec.FInativo,
            Oponente = dbRec.FOponente,
            Descricao = dbRec.FDescricao ?? string.Empty,
            Observacoes = dbRec.FObservacoes ?? string.Empty,
            Cliente = dbRec.FCliente,
            Icone = dbRec.FIcone ?? string.Empty,
            DespesaUnificada = dbRec.FDespesaUnificada,
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
        gruposempresas.Auditor = auditor;
        return gruposempresas;
    }
}