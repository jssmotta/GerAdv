#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ISituacaoWriter
{
    Entity.DBSituacao Write(Models.Situacao situacao, int auditorQuem, MsiSqlConnection oCnn);
    void Delete(SituacaoResponse situacao, int operadorId, MsiSqlConnection oCnn);
}

public class Situacao : ISituacaoWriter
{
    public void Delete(SituacaoResponse situacao, int operadorId, MsiSqlConnection oCnn)
    {
        ConfiguracoesDBT.ExecuteDelete($"DELETE FROM [{oCnn.UseDbo}].[Situacao] WHERE sitCodigo={situacao.Id};", oCnn);
    }

    public Entity.DBSituacao Write(Models.Situacao situacao, int auditorQuem, MsiSqlConnection oCnn)
    {
        var dbRec = situacao.Id.IsEmptyIDNumber() ? new Entity.DBSituacao() : new Entity.DBSituacao(situacao.Id, oCnn);
        dbRec.FParte_Int = situacao.Parte_Int;
        dbRec.FParte_Opo = situacao.Parte_Opo;
        dbRec.FTop = situacao.Top;
        dbRec.FBold = situacao.Bold;
        dbRec.FGUID = situacao.GUID;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}