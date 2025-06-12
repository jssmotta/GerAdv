#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IProCDAWriter
{
    Entity.DBProCDA Write(Models.ProCDA procda, int auditorQuem, MsiSqlConnection oCnn);
    void Delete(ProCDAResponse procda, int operadorId, MsiSqlConnection oCnn);
}

public class ProCDA : IProCDAWriter
{
    public void Delete(ProCDAResponse procda, int operadorId, MsiSqlConnection oCnn)
    {
        ConfiguracoesDBT.ExecuteDelete($"DELETE FROM [{oCnn.UseDbo}].[ProCDA] WHERE pcdCodigo={procda.Id};", oCnn);
    }

    public Entity.DBProCDA Write(Models.ProCDA procda, int auditorQuem, MsiSqlConnection oCnn)
    {
        var dbRec = procda.Id.IsEmptyIDNumber() ? new Entity.DBProCDA() : new Entity.DBProCDA(procda.Id, oCnn);
        dbRec.FProcesso = procda.Processo;
        dbRec.FNome = procda.Nome;
        dbRec.FNroInterno = procda.NroInterno;
        dbRec.FBold = procda.Bold;
        dbRec.FGUID = procda.GUID;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}