#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Wheres;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IAtividadesWhere
{
    AtividadesResponse Read(string where, SqlConnection oCnn);
}

public partial class Atividades : IAtividadesWhere
{
    public AtividadesResponse Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBAtividades(sqlWhere: where, oCnn: oCnn);
        var atividades = new AtividadesResponse
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
        atividades.Auditor = auditor;
        return atividades;
    }
}