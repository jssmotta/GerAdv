#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ICargosEscWriter
{
    Entity.DBCargosEsc Write(Models.CargosEsc cargosesc, int auditorQuem, MsiSqlConnection oCnn);
    void Delete(CargosEscResponse cargosesc, int operadorId, MsiSqlConnection oCnn);
}

public class CargosEsc : ICargosEscWriter
{
    public void Delete(CargosEscResponse cargosesc, int operadorId, MsiSqlConnection oCnn)
    {
        ConfiguracoesDBT.ExecuteDelete($"DELETE FROM [{oCnn.UseDbo}].[CargosEsc] WHERE cgeCodigo={cargosesc.Id};", oCnn);
    }

    public Entity.DBCargosEsc Write(Models.CargosEsc cargosesc, int auditorQuem, MsiSqlConnection oCnn)
    {
        var dbRec = cargosesc.Id.IsEmptyIDNumber() ? new Entity.DBCargosEsc() : new Entity.DBCargosEsc(cargosesc.Id, oCnn);
        dbRec.FPercentual = cargosesc.Percentual;
        dbRec.FNome = cargosesc.Nome;
        dbRec.FClassificacao = cargosesc.Classificacao;
        dbRec.FGUID = cargosesc.GUID;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}