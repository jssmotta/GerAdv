#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IPontoVirtualWriter
{
    Entity.DBPontoVirtual Write(Models.PontoVirtual pontovirtual, MsiSqlConnection oCnn);
    void Delete(PontoVirtualResponse pontovirtual, int operadorId, MsiSqlConnection oCnn);
}

public class PontoVirtual : IPontoVirtualWriter
{
    public void Delete(PontoVirtualResponse pontovirtual, int operadorId, MsiSqlConnection oCnn)
    {
        ConfiguracoesDBT.ExecuteDelete($"DELETE FROM [{oCnn.UseDbo}].[PontoVirtual] WHERE pvtCodigo={pontovirtual.Id};", oCnn);
    }

    public Entity.DBPontoVirtual Write(Models.PontoVirtual pontovirtual, MsiSqlConnection oCnn)
    {
        var dbRec = pontovirtual.Id.IsEmptyIDNumber() ? new Entity.DBPontoVirtual() : new Entity.DBPontoVirtual(pontovirtual.Id, oCnn);
        if (pontovirtual.HoraEntrada != null)
            dbRec.FHoraEntrada = pontovirtual.HoraEntrada.ToString();
        if (pontovirtual.HoraSaida != null)
            dbRec.FHoraSaida = pontovirtual.HoraSaida.ToString();
        dbRec.FOperador = pontovirtual.Operador;
        dbRec.FKey = pontovirtual.Key;
        dbRec.Update(oCnn);
        return dbRec;
    }
}