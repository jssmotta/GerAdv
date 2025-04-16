#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IAtividadesWriter
{
    Entity.DBAtividades Write(Models.Atividades atividades, int auditorQuem, SqlConnection oCnn);
}

public class Atividades : IAtividadesWriter
{
    public Entity.DBAtividades Write(Models.Atividades atividades, int auditorQuem, SqlConnection oCnn)
    {
        var dbRec = atividades.Id.IsEmptyIDNumber() ? new Entity.DBAtividades() : new Entity.DBAtividades(atividades.Id, oCnn);
        dbRec.FDescricao = atividades.Descricao;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}