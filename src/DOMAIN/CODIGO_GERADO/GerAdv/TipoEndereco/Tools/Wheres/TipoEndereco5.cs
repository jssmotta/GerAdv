#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Wheres;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ITipoEnderecoWhere
{
    TipoEnderecoResponse Read(string where, SqlConnection oCnn);
}

public partial class TipoEndereco : ITipoEnderecoWhere
{
    public TipoEnderecoResponse Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBTipoEndereco(sqlWhere: where, oCnn: oCnn);
        var tipoendereco = new TipoEnderecoResponse
        {
            Id = dbRec.ID,
            Descricao = dbRec.FDescricao ?? string.Empty,
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
        tipoendereco.Auditor = auditor;
        return tipoendereco;
    }
}