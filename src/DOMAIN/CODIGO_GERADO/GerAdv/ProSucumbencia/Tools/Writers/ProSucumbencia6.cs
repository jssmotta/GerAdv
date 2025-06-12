#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IProSucumbenciaWriter
{
    Entity.DBProSucumbencia Write(Models.ProSucumbencia prosucumbencia, int auditorQuem, MsiSqlConnection oCnn);
    void Delete(ProSucumbenciaResponse prosucumbencia, int operadorId, MsiSqlConnection oCnn);
}

public class ProSucumbencia : IProSucumbenciaWriter
{
    public void Delete(ProSucumbenciaResponse prosucumbencia, int operadorId, MsiSqlConnection oCnn)
    {
        ConfiguracoesDBT.ExecuteDelete($"DELETE FROM [{oCnn.UseDbo}].[ProSucumbencia] WHERE scbCodigo={prosucumbencia.Id};", oCnn);
    }

    public Entity.DBProSucumbencia Write(Models.ProSucumbencia prosucumbencia, int auditorQuem, MsiSqlConnection oCnn)
    {
        var dbRec = prosucumbencia.Id.IsEmptyIDNumber() ? new Entity.DBProSucumbencia() : new Entity.DBProSucumbencia(prosucumbencia.Id, oCnn);
        dbRec.FProcesso = prosucumbencia.Processo;
        dbRec.FInstancia = prosucumbencia.Instancia;
        if (prosucumbencia.Data != null)
            dbRec.FData = prosucumbencia.Data.ToString();
        dbRec.FNome = prosucumbencia.Nome;
        dbRec.FTipoOrigemSucumbencia = prosucumbencia.TipoOrigemSucumbencia;
        dbRec.FValor = prosucumbencia.Valor;
        dbRec.FPercentual = prosucumbencia.Percentual;
        dbRec.FGUID = prosucumbencia.GUID;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}