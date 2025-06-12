#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ITiposAcaoWriter
{
    Entity.DBTiposAcao Write(Models.TiposAcao tiposacao, int auditorQuem, MsiSqlConnection oCnn);
    void Delete(TiposAcaoResponse tiposacao, int operadorId, MsiSqlConnection oCnn);
}

public class TiposAcao : ITiposAcaoWriter
{
    public void Delete(TiposAcaoResponse tiposacao, int operadorId, MsiSqlConnection oCnn)
    {
        ConfiguracoesDBT.ExecuteDelete($"DELETE FROM [{oCnn.UseDbo}].[TiposAcao] WHERE tacCodigo={tiposacao.Id};", oCnn);
    }

    public Entity.DBTiposAcao Write(Models.TiposAcao tiposacao, int auditorQuem, MsiSqlConnection oCnn)
    {
        var dbRec = tiposacao.Id.IsEmptyIDNumber() ? new Entity.DBTiposAcao() : new Entity.DBTiposAcao(tiposacao.Id, oCnn);
        dbRec.FNome = tiposacao.Nome;
        dbRec.FInativo = tiposacao.Inativo;
        dbRec.FBold = tiposacao.Bold;
        dbRec.FGUID = tiposacao.GUID;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}