#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IEndTitWriter
{
    Entity.DBEndTit Write(Models.EndTit endtit, SqlConnection oCnn);
}

public class EndTit : IEndTitWriter
{
    public Entity.DBEndTit Write(Models.EndTit endtit, SqlConnection oCnn)
    {
        var dbRec = endtit.Id.IsEmptyIDNumber() ? new Entity.DBEndTit() : new Entity.DBEndTit(endtit.Id, oCnn);
        dbRec.FEndereco = endtit.Endereco;
        dbRec.FTitulo = endtit.Titulo;
        dbRec.Update(oCnn);
        return dbRec;
    }
}