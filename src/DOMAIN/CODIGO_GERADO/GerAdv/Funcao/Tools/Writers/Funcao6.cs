#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IFuncaoWriter
{
    Entity.DBFuncao Write(Models.Funcao funcao, int auditorQuem, SqlConnection oCnn);
}

public class Funcao : IFuncaoWriter
{
    public Entity.DBFuncao Write(Models.Funcao funcao, int auditorQuem, SqlConnection oCnn)
    {
        var dbRec = funcao.Id.IsEmptyIDNumber() ? new Entity.DBFuncao() : new Entity.DBFuncao(funcao.Id, oCnn);
        dbRec.FDescricao = funcao.Descricao;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}