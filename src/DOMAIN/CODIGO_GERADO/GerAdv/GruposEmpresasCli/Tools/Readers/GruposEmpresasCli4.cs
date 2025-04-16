#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IGruposEmpresasCliReader
{
    GruposEmpresasCliResponse? Read(int id, SqlConnection oCnn);
    GruposEmpresasCliResponse? Read(string where, SqlConnection oCnn);
    GruposEmpresasCliResponse? Read(Entity.DBGruposEmpresasCli dbRec);
    GruposEmpresasCliResponse? Read(DBGruposEmpresasCli dbRec);
}

public partial class GruposEmpresasCli : IGruposEmpresasCliReader
{
    public GruposEmpresasCliResponse? Read(int id, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBGruposEmpresasCli(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public GruposEmpresasCliResponse? Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBGruposEmpresasCli(sqlWhere: where, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public GruposEmpresasCliResponse? Read(Entity.DBGruposEmpresasCli dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var gruposempresascli = new GruposEmpresasCliResponse
        {
            Id = dbRec.ID,
            Grupo = dbRec.FGrupo,
            Cliente = dbRec.FCliente,
            Oculto = dbRec.FOculto,
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
        gruposempresascli.Auditor = auditor;
        return gruposempresascli;
    }

    public GruposEmpresasCliResponse? Read(DBGruposEmpresasCli dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var gruposempresascli = new GruposEmpresasCliResponse
        {
            Id = dbRec.ID,
            Grupo = dbRec.FGrupo,
            Cliente = dbRec.FCliente,
            Oculto = dbRec.FOculto,
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
        gruposempresascli.Auditor = auditor;
        return gruposempresascli;
    }
}