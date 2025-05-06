#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Wheres;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IServicosWhere
{
    ServicosResponse Read(string where, SqlConnection oCnn);
}

public partial class Servicos : IServicosWhere
{
    public ServicosResponse Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBServicos(sqlWhere: where, oCnn: oCnn);
        var servicos = new ServicosResponse
        {
            Id = dbRec.ID,
            Cobrar = dbRec.FCobrar,
            Descricao = dbRec.FDescricao ?? string.Empty,
            Basico = dbRec.FBasico,
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
        servicos.Auditor = auditor;
        return servicos;
    }
}