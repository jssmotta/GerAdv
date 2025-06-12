#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IStatusBiuWriter
{
    Entity.DBStatusBiu Write(Models.StatusBiu statusbiu, MsiSqlConnection oCnn);
    void Delete(StatusBiuResponse statusbiu, int operadorId, MsiSqlConnection oCnn);
}

public class StatusBiu : IStatusBiuWriter
{
    public void Delete(StatusBiuResponse statusbiu, int operadorId, MsiSqlConnection oCnn)
    {
        ConfiguracoesDBT.ExecuteDelete($"DELETE FROM [{oCnn.UseDbo}].[StatusBiu] WHERE stbCodigo={statusbiu.Id};", oCnn);
    }

    public Entity.DBStatusBiu Write(Models.StatusBiu statusbiu, MsiSqlConnection oCnn)
    {
        var dbRec = statusbiu.Id.IsEmptyIDNumber() ? new Entity.DBStatusBiu() : new Entity.DBStatusBiu(statusbiu.Id, oCnn);
        dbRec.FNome = statusbiu.Nome;
        dbRec.FTipoStatusBiu = statusbiu.TipoStatusBiu;
        dbRec.FOperador = statusbiu.Operador;
        dbRec.FIcone = statusbiu.Icone;
        dbRec.Update(oCnn);
        return dbRec;
    }
}