#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ITipoEnderecoReader
{
    TipoEnderecoResponse? Read(int id, SqlConnection oCnn);
    TipoEnderecoResponse? Read(string where, SqlConnection oCnn);
    TipoEnderecoResponse? Read(Entity.DBTipoEndereco dbRec);
    Task<string> ReadStringAuditor(int id, string uri, SqlConnection oCnn);
    TipoEnderecoResponse? Read(DBTipoEndereco dbRec);
}

public partial class TipoEndereco : ITipoEnderecoReader
{
    public TipoEnderecoResponse? Read(int id, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBTipoEndereco(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public TipoEnderecoResponse? Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBTipoEndereco(sqlWhere: where, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public TipoEnderecoResponse? Read(Entity.DBTipoEndereco dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var tipoendereco = new TipoEnderecoResponse
        {
            Id = dbRec.ID,
            Descricao = dbRec.FDescricao ?? string.Empty,
            Guid = dbRec.FGUID ?? string.Empty,
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
        tipoendereco.Auditor = auditor;
        return tipoendereco;
    }

    public TipoEnderecoResponse? Read(DBTipoEndereco dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var tipoendereco = new TipoEnderecoResponse
        {
            Id = dbRec.ID,
            Descricao = dbRec.FDescricao ?? string.Empty,
            Guid = dbRec.FGUID ?? string.Empty,
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
        tipoendereco.Auditor = auditor;
        return tipoendereco;
    }
}