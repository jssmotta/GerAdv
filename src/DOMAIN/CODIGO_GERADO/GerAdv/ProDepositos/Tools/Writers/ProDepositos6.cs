#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IProDepositosWriter
{
    Entity.DBProDepositos Write(Models.ProDepositos prodepositos, int auditorQuem, SqlConnection oCnn);
}

public class ProDepositos : IProDepositosWriter
{
    public Entity.DBProDepositos Write(Models.ProDepositos prodepositos, int auditorQuem, SqlConnection oCnn)
    {
        var dbRec = prodepositos.Id.IsEmptyIDNumber() ? new Entity.DBProDepositos() : new Entity.DBProDepositos(prodepositos.Id, oCnn);
        dbRec.FProcesso = prodepositos.Processo;
        dbRec.FFase = prodepositos.Fase;
        if (prodepositos.Data != null)
            dbRec.FData = prodepositos.Data.ToString();
        dbRec.FValor = prodepositos.Valor;
        dbRec.FTipoProDesposito = prodepositos.TipoProDesposito;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}