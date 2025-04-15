#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IProCDAWriter
{
    Entity.DBProCDA Write(Models.ProCDA procda, int auditorQuem, SqlConnection oCnn);
}

public class ProCDA : IProCDAWriter
{
    public Entity.DBProCDA Write(Models.ProCDA procda, int auditorQuem, SqlConnection oCnn)
    {
        var dbRec = procda.Id.IsEmptyIDNumber() ? new Entity.DBProCDA() : new Entity.DBProCDA(procda.Id, oCnn);
        dbRec.FProcesso = procda.Processo;
        dbRec.FNome = procda.Nome;
        dbRec.FNroInterno = procda.NroInterno;
        dbRec.FBold = procda.Bold;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}