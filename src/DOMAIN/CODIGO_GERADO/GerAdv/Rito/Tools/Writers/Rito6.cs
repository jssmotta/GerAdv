#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IRitoWriter
{
    Entity.DBRito Write(Models.Rito rito, int auditorQuem, SqlConnection oCnn);
}

public class Rito : IRitoWriter
{
    public Entity.DBRito Write(Models.Rito rito, int auditorQuem, SqlConnection oCnn)
    {
        var dbRec = rito.Id.IsEmptyIDNumber() ? new Entity.DBRito() : new Entity.DBRito(rito.Id, oCnn);
        dbRec.FDescricao = rito.Descricao;
        dbRec.FTop = rito.Top;
        dbRec.FBold = rito.Bold;
        dbRec.FGUID = rito.GUID;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}