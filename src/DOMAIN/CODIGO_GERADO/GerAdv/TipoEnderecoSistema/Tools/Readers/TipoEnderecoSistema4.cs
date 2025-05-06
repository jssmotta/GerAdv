#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ITipoEnderecoSistemaReader
{
    TipoEnderecoSistemaResponse? Read(int id, SqlConnection oCnn);
    TipoEnderecoSistemaResponse? Read(string where, SqlConnection oCnn);
    TipoEnderecoSistemaResponse? Read(Entity.DBTipoEnderecoSistema dbRec);
    Task<string> ReadStringAuditor(int id, string uri, SqlConnection oCnn);
    TipoEnderecoSistemaResponse? Read(DBTipoEnderecoSistema dbRec);
}

public partial class TipoEnderecoSistema : ITipoEnderecoSistemaReader
{
    public TipoEnderecoSistemaResponse? Read(int id, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBTipoEnderecoSistema(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public TipoEnderecoSistemaResponse? Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBTipoEnderecoSistema(sqlWhere: where, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public TipoEnderecoSistemaResponse? Read(Entity.DBTipoEnderecoSistema dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var tipoenderecosistema = new TipoEnderecoSistemaResponse
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
        tipoenderecosistema.Auditor = auditor;
        return tipoenderecosistema;
    }

    public TipoEnderecoSistemaResponse? Read(DBTipoEnderecoSistema dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var tipoenderecosistema = new TipoEnderecoSistemaResponse
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
        tipoenderecosistema.Auditor = auditor;
        return tipoenderecosistema;
    }
}