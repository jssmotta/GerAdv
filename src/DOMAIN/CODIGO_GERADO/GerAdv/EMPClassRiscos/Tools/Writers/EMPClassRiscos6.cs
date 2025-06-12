#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IEMPClassRiscosWriter
{
    Entity.DBEMPClassRiscos Write(Models.EMPClassRiscos empclassriscos, int auditorQuem, MsiSqlConnection oCnn);
    void Delete(EMPClassRiscosResponse empclassriscos, int operadorId, MsiSqlConnection oCnn);
}

public class EMPClassRiscos : IEMPClassRiscosWriter
{
    public void Delete(EMPClassRiscosResponse empclassriscos, int operadorId, MsiSqlConnection oCnn)
    {
        ConfiguracoesDBT.ExecuteDelete($"DELETE FROM [{oCnn.UseDbo}].[EMPClassRiscos] WHERE ecrCodigo={empclassriscos.Id};", oCnn);
    }

    public Entity.DBEMPClassRiscos Write(Models.EMPClassRiscos empclassriscos, int auditorQuem, MsiSqlConnection oCnn)
    {
        var dbRec = empclassriscos.Id.IsEmptyIDNumber() ? new Entity.DBEMPClassRiscos() : new Entity.DBEMPClassRiscos(empclassriscos.Id, oCnn);
        dbRec.FNome = empclassriscos.Nome;
        dbRec.FBold = empclassriscos.Bold;
        dbRec.FGUID = empclassriscos.GUID;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}