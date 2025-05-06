#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IGruposEmpresasReader
{
    GruposEmpresasResponse? Read(int id, SqlConnection oCnn);
    GruposEmpresasResponse? Read(string where, SqlConnection oCnn);
    GruposEmpresasResponse? Read(Entity.DBGruposEmpresas dbRec);
    Task<string> ReadStringAuditor(int id, string uri, SqlConnection oCnn);
    GruposEmpresasResponse? Read(DBGruposEmpresas dbRec);
}

public partial class GruposEmpresas : IGruposEmpresasReader
{
    public GruposEmpresasResponse? Read(int id, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBGruposEmpresas(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public GruposEmpresasResponse? Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBGruposEmpresas(sqlWhere: where, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public GruposEmpresasResponse? Read(Entity.DBGruposEmpresas dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

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

    public GruposEmpresasResponse? Read(DBGruposEmpresas dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

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