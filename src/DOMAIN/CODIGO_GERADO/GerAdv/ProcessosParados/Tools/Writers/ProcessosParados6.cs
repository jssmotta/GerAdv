#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IProcessosParadosWriter
{
    Entity.DBProcessosParados Write(Models.ProcessosParados processosparados, MsiSqlConnection oCnn);
    void Delete(ProcessosParadosResponse processosparados, int operadorId, MsiSqlConnection oCnn);
}

public class ProcessosParados : IProcessosParadosWriter
{
    public void Delete(ProcessosParadosResponse processosparados, int operadorId, MsiSqlConnection oCnn)
    {
        ConfiguracoesDBT.ExecuteDelete($"DELETE FROM [{oCnn.UseDbo}].[ProcessosParados] WHERE pprCodigo={processosparados.Id};", oCnn);
    }

    public Entity.DBProcessosParados Write(Models.ProcessosParados processosparados, MsiSqlConnection oCnn)
    {
        var dbRec = processosparados.Id.IsEmptyIDNumber() ? new Entity.DBProcessosParados() : new Entity.DBProcessosParados(processosparados.Id, oCnn);
        dbRec.FProcesso = processosparados.Processo;
        dbRec.FSemana = processosparados.Semana;
        dbRec.FAno = processosparados.Ano;
        if (processosparados.DataHora != null)
            dbRec.FDataHora = processosparados.DataHora.ToString();
        dbRec.FOperador = processosparados.Operador;
        if (processosparados.DataHistorico != null)
            dbRec.FDataHistorico = processosparados.DataHistorico.ToString();
        if (processosparados.DataNENotas != null)
            dbRec.FDataNENotas = processosparados.DataNENotas.ToString();
        dbRec.Update(oCnn);
        return dbRec;
    }
}