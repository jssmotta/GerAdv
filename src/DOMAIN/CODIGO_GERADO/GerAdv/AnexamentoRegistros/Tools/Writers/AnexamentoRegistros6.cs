#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IAnexamentoRegistrosWriter
{
    Entity.DBAnexamentoRegistros Write(Models.AnexamentoRegistros anexamentoregistros, int auditorQuem, SqlConnection oCnn);
}

public class AnexamentoRegistros : IAnexamentoRegistrosWriter
{
    public Entity.DBAnexamentoRegistros Write(Models.AnexamentoRegistros anexamentoregistros, int auditorQuem, SqlConnection oCnn)
    {
        var dbRec = anexamentoregistros.Id.IsEmptyIDNumber() ? new Entity.DBAnexamentoRegistros() : new Entity.DBAnexamentoRegistros(anexamentoregistros.Id, oCnn);
        dbRec.FCliente = anexamentoregistros.Cliente;
        dbRec.FCodigoReg = anexamentoregistros.CodigoReg;
        dbRec.FIDReg = anexamentoregistros.IDReg;
        if (anexamentoregistros.Data != null)
            dbRec.FData = anexamentoregistros.Data.ToString();
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}