#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IFuncaoWriter
{
    Entity.DBFuncao Write(Models.Funcao funcao, int auditorQuem, MsiSqlConnection oCnn);
    void Delete(FuncaoResponse funcao, int operadorId, MsiSqlConnection oCnn);
}

public class Funcao : IFuncaoWriter
{
    public void Delete(FuncaoResponse funcao, int operadorId, MsiSqlConnection oCnn)
    {
        ConfiguracoesDBT.ExecuteDelete($"DELETE FROM [{oCnn.UseDbo}].[Funcao] WHERE funCodigo={funcao.Id};", oCnn);
    }

    public Entity.DBFuncao Write(Models.Funcao funcao, int auditorQuem, MsiSqlConnection oCnn)
    {
        var dbRec = funcao.Id.IsEmptyIDNumber() ? new Entity.DBFuncao() : new Entity.DBFuncao(funcao.Id, oCnn);
        dbRec.FDescricao = funcao.Descricao;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}