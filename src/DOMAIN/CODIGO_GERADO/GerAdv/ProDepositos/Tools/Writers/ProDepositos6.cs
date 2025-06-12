#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IProDepositosWriter
{
    Entity.DBProDepositos Write(Models.ProDepositos prodepositos, int auditorQuem, MsiSqlConnection oCnn);
    void Delete(ProDepositosResponse prodepositos, int operadorId, MsiSqlConnection oCnn);
}

public class ProDepositos : IProDepositosWriter
{
    public void Delete(ProDepositosResponse prodepositos, int operadorId, MsiSqlConnection oCnn)
    {
        ConfiguracoesDBT.ExecuteDelete($"DELETE FROM [{oCnn.UseDbo}].[ProDepositos] WHERE pdsCodigo={prodepositos.Id};", oCnn);
    }

    public Entity.DBProDepositos Write(Models.ProDepositos prodepositos, int auditorQuem, MsiSqlConnection oCnn)
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