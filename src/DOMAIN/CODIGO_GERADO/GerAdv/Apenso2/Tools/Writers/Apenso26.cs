#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IApenso2Writer
{
    Entity.DBApenso2 Write(Models.Apenso2 apenso2, int auditorQuem, SqlConnection oCnn);
}

public class Apenso2 : IApenso2Writer
{
    public Entity.DBApenso2 Write(Models.Apenso2 apenso2, int auditorQuem, SqlConnection oCnn)
    {
        var dbRec = apenso2.Id.IsEmptyIDNumber() ? new Entity.DBApenso2() : new Entity.DBApenso2(apenso2.Id, oCnn);
        dbRec.FProcesso = apenso2.Processo;
        dbRec.FApensado = apenso2.Apensado;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}