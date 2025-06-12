#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IAnexamentoRegistrosWriter
{
    Entity.DBAnexamentoRegistros Write(Models.AnexamentoRegistros anexamentoregistros, int auditorQuem, MsiSqlConnection oCnn);
    void Delete(AnexamentoRegistrosResponse anexamentoregistros, int operadorId, MsiSqlConnection oCnn);
}

public class AnexamentoRegistros : IAnexamentoRegistrosWriter
{
    public void Delete(AnexamentoRegistrosResponse anexamentoregistros, int operadorId, MsiSqlConnection oCnn)
    {
        ConfiguracoesDBT.ExecuteDelete($"DELETE FROM [{oCnn.UseDbo}].[AnexamentoRegistros] WHERE axrCodigo={anexamentoregistros.Id};", oCnn);
    }

    public Entity.DBAnexamentoRegistros Write(Models.AnexamentoRegistros anexamentoregistros, int auditorQuem, MsiSqlConnection oCnn)
    {
        var dbRec = anexamentoregistros.Id.IsEmptyIDNumber() ? new Entity.DBAnexamentoRegistros() : new Entity.DBAnexamentoRegistros(anexamentoregistros.Id, oCnn);
        dbRec.FCliente = anexamentoregistros.Cliente;
        dbRec.FGUIDReg = anexamentoregistros.GUIDReg;
        dbRec.FCodigoReg = anexamentoregistros.CodigoReg;
        dbRec.FIDReg = anexamentoregistros.IDReg;
        if (anexamentoregistros.Data != null)
            dbRec.FData = anexamentoregistros.Data.ToString();
        dbRec.FGUID = anexamentoregistros.GUID;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}