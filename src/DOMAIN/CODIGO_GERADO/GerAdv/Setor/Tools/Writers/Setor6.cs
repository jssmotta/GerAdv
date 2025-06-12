#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ISetorWriter
{
    Entity.DBSetor Write(Models.Setor setor, int auditorQuem, MsiSqlConnection oCnn);
    void Delete(SetorResponse setor, int operadorId, MsiSqlConnection oCnn);
}

public class Setor : ISetorWriter
{
    public void Delete(SetorResponse setor, int operadorId, MsiSqlConnection oCnn)
    {
        ConfiguracoesDBT.ExecuteDelete($"DELETE FROM [{oCnn.UseDbo}].[Setor] WHERE setCodigo={setor.Id};", oCnn);
    }

    public Entity.DBSetor Write(Models.Setor setor, int auditorQuem, MsiSqlConnection oCnn)
    {
        var dbRec = setor.Id.IsEmptyIDNumber() ? new Entity.DBSetor() : new Entity.DBSetor(setor.Id, oCnn);
        dbRec.FDescricao = setor.Descricao;
        dbRec.FGUID = setor.GUID;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}