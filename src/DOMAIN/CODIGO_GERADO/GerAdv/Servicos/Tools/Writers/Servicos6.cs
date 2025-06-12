#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IServicosWriter
{
    Entity.DBServicos Write(Models.Servicos servicos, int auditorQuem, MsiSqlConnection oCnn);
    void Delete(ServicosResponse servicos, int operadorId, MsiSqlConnection oCnn);
}

public class Servicos : IServicosWriter
{
    public void Delete(ServicosResponse servicos, int operadorId, MsiSqlConnection oCnn)
    {
        ConfiguracoesDBT.ExecuteDelete($"DELETE FROM [{oCnn.UseDbo}].[Servicos] WHERE serCodigo={servicos.Id};", oCnn);
    }

    public Entity.DBServicos Write(Models.Servicos servicos, int auditorQuem, MsiSqlConnection oCnn)
    {
        var dbRec = servicos.Id.IsEmptyIDNumber() ? new Entity.DBServicos() : new Entity.DBServicos(servicos.Id, oCnn);
        dbRec.FCobrar = servicos.Cobrar;
        dbRec.FDescricao = servicos.Descricao;
        dbRec.FBasico = servicos.Basico;
        dbRec.FGUID = servicos.GUID;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}