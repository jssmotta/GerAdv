#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Wheres;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IDiario2Where
{
    Diario2Response Read(string where, SqlConnection oCnn);
}

public partial class Diario2 : IDiario2Where
{
    public Diario2Response Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBDiario2(sqlWhere: where, oCnn: oCnn);
        var diario2 = new Diario2Response
        {
            Id = dbRec.ID,
            Operador = dbRec.FOperador,
            Nome = dbRec.FNome ?? string.Empty,
            Ocorrencia = dbRec.FOcorrencia ?? string.Empty,
            Cliente = dbRec.FCliente,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            diario2.Data = dbRec.FData;
        if (DateTime.TryParse(dbRec.FHora, out _))
            diario2.Hora = dbRec.FHora;
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
        diario2.Auditor = auditor;
        return diario2;
    }
}