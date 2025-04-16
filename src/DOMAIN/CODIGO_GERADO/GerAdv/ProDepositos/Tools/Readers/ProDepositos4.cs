#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IProDepositosReader
{
    ProDepositosResponse? Read(int id, SqlConnection oCnn);
    ProDepositosResponse? Read(string where, SqlConnection oCnn);
    ProDepositosResponse? Read(Entity.DBProDepositos dbRec);
    ProDepositosResponse? Read(DBProDepositos dbRec);
}

public partial class ProDepositos : IProDepositosReader
{
    public ProDepositosResponse? Read(int id, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBProDepositos(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ProDepositosResponse? Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBProDepositos(sqlWhere: where, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ProDepositosResponse? Read(Entity.DBProDepositos dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var prodepositos = new ProDepositosResponse
        {
            Id = dbRec.ID,
            Processo = dbRec.FProcesso,
            Fase = dbRec.FFase,
            Valor = dbRec.FValor,
            TipoProDesposito = dbRec.FTipoProDesposito,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            prodepositos.Data = dbRec.FData;
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
        prodepositos.Auditor = auditor;
        return prodepositos;
    }

    public ProDepositosResponse? Read(DBProDepositos dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var prodepositos = new ProDepositosResponse
        {
            Id = dbRec.ID,
            Processo = dbRec.FProcesso,
            Fase = dbRec.FFase,
            Valor = dbRec.FValor,
            TipoProDesposito = dbRec.FTipoProDesposito,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            prodepositos.Data = dbRec.FData;
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
        prodepositos.Auditor = auditor;
        return prodepositos;
    }
}