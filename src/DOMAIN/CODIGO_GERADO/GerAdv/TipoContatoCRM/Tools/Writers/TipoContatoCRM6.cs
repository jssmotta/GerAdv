#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ITipoContatoCRMWriter
{
    Entity.DBTipoContatoCRM Write(Models.TipoContatoCRM tipocontatocrm, int auditorQuem, MsiSqlConnection oCnn);
    void Delete(TipoContatoCRMResponse tipocontatocrm, int operadorId, MsiSqlConnection oCnn);
}

public class TipoContatoCRM : ITipoContatoCRMWriter
{
    public void Delete(TipoContatoCRMResponse tipocontatocrm, int operadorId, MsiSqlConnection oCnn)
    {
        ConfiguracoesDBT.ExecuteDelete($"DELETE FROM [{oCnn.UseDbo}].[TipoContatoCRM] WHERE tccCodigo={tipocontatocrm.Id};", oCnn);
    }

    public Entity.DBTipoContatoCRM Write(Models.TipoContatoCRM tipocontatocrm, int auditorQuem, MsiSqlConnection oCnn)
    {
        var dbRec = tipocontatocrm.Id.IsEmptyIDNumber() ? new Entity.DBTipoContatoCRM() : new Entity.DBTipoContatoCRM(tipocontatocrm.Id, oCnn);
        dbRec.FNome = tipocontatocrm.Nome;
        dbRec.FBold = tipocontatocrm.Bold;
        dbRec.FGUID = tipocontatocrm.GUID;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}