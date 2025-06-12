#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IApensoWriter
{
    Entity.DBApenso Write(Models.Apenso apenso, int auditorQuem, MsiSqlConnection oCnn);
    void Delete(ApensoResponse apenso, int operadorId, MsiSqlConnection oCnn);
}

public class Apenso : IApensoWriter
{
    public void Delete(ApensoResponse apenso, int operadorId, MsiSqlConnection oCnn)
    {
        ConfiguracoesDBT.ExecuteDelete($"DELETE FROM [{oCnn.UseDbo}].[Apenso] WHERE apeCodigo={apenso.Id};", oCnn);
    }

    public Entity.DBApenso Write(Models.Apenso apenso, int auditorQuem, MsiSqlConnection oCnn)
    {
        var dbRec = apenso.Id.IsEmptyIDNumber() ? new Entity.DBApenso() : new Entity.DBApenso(apenso.Id, oCnn);
        dbRec.FProcesso = apenso.Processo;
        dbRec.FApenso = apenso.ApensoX;
        dbRec.FAcao = apenso.Acao;
        if (apenso.DtDist != null)
            dbRec.FDtDist = apenso.DtDist.ToString();
        dbRec.FOBS = apenso.OBS;
        dbRec.FValorCausa = apenso.ValorCausa;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}