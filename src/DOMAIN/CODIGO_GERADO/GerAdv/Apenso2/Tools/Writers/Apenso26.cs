#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IApenso2Writer
{
    Entity.DBApenso2 Write(Models.Apenso2 apenso2, int auditorQuem, MsiSqlConnection oCnn);
    void Delete(Apenso2Response apenso2, int operadorId, MsiSqlConnection oCnn);
}

public class Apenso2 : IApenso2Writer
{
    public void Delete(Apenso2Response apenso2, int operadorId, MsiSqlConnection oCnn)
    {
        ConfiguracoesDBT.ExecuteDelete($"DELETE FROM [{oCnn.UseDbo}].[Apenso2] WHERE ap2Codigo={apenso2.Id};", oCnn);
    }

    public Entity.DBApenso2 Write(Models.Apenso2 apenso2, int auditorQuem, MsiSqlConnection oCnn)
    {
        var dbRec = apenso2.Id.IsEmptyIDNumber() ? new Entity.DBApenso2() : new Entity.DBApenso2(apenso2.Id, oCnn);
        dbRec.FProcesso = apenso2.Processo;
        dbRec.FApensado = apenso2.Apensado;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}