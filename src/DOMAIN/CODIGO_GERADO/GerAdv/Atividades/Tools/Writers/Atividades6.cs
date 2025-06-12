#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IAtividadesWriter
{
    Entity.DBAtividades Write(Models.Atividades atividades, int auditorQuem, MsiSqlConnection oCnn);
    void Delete(AtividadesResponse atividades, int operadorId, MsiSqlConnection oCnn);
}

public class Atividades : IAtividadesWriter
{
    public void Delete(AtividadesResponse atividades, int operadorId, MsiSqlConnection oCnn)
    {
        ConfiguracoesDBT.ExecuteDelete($"DELETE FROM [{oCnn.UseDbo}].[Atividades] WHERE atvCodigo={atividades.Id};", oCnn);
    }

    public Entity.DBAtividades Write(Models.Atividades atividades, int auditorQuem, MsiSqlConnection oCnn)
    {
        var dbRec = atividades.Id.IsEmptyIDNumber() ? new Entity.DBAtividades() : new Entity.DBAtividades(atividades.Id, oCnn);
        dbRec.FDescricao = atividades.Descricao;
        dbRec.FGUID = atividades.GUID;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}