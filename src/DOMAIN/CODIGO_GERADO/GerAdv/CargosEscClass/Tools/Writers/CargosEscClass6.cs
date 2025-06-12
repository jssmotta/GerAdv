#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ICargosEscClassWriter
{
    Entity.DBCargosEscClass Write(Models.CargosEscClass cargosescclass, int auditorQuem, MsiSqlConnection oCnn);
    void Delete(CargosEscClassResponse cargosescclass, int operadorId, MsiSqlConnection oCnn);
}

public class CargosEscClass : ICargosEscClassWriter
{
    public void Delete(CargosEscClassResponse cargosescclass, int operadorId, MsiSqlConnection oCnn)
    {
        ConfiguracoesDBT.ExecuteDelete($"DELETE FROM [{oCnn.UseDbo}].[CargosEscClass] WHERE cecCodigo={cargosescclass.Id};", oCnn);
    }

    public Entity.DBCargosEscClass Write(Models.CargosEscClass cargosescclass, int auditorQuem, MsiSqlConnection oCnn)
    {
        var dbRec = cargosescclass.Id.IsEmptyIDNumber() ? new Entity.DBCargosEscClass() : new Entity.DBCargosEscClass(cargosescclass.Id, oCnn);
        dbRec.FNome = cargosescclass.Nome;
        dbRec.FGUID = cargosescclass.GUID;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}