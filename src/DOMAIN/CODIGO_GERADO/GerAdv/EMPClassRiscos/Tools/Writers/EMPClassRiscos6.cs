#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IEMPClassRiscosWriter
{
    Entity.DBEMPClassRiscos Write(Models.EMPClassRiscos empclassriscos, int auditorQuem, SqlConnection oCnn);
}

public class EMPClassRiscos : IEMPClassRiscosWriter
{
    public Entity.DBEMPClassRiscos Write(Models.EMPClassRiscos empclassriscos, int auditorQuem, SqlConnection oCnn)
    {
        var dbRec = empclassriscos.Id.IsEmptyIDNumber() ? new Entity.DBEMPClassRiscos() : new Entity.DBEMPClassRiscos(empclassriscos.Id, oCnn);
        dbRec.FNome = empclassriscos.Nome;
        dbRec.FBold = empclassriscos.Bold;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}