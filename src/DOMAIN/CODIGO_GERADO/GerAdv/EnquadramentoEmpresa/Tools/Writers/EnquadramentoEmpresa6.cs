#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IEnquadramentoEmpresaWriter
{
    Entity.DBEnquadramentoEmpresa Write(Models.EnquadramentoEmpresa enquadramentoempresa, int auditorQuem, MsiSqlConnection oCnn);
    void Delete(EnquadramentoEmpresaResponse enquadramentoempresa, int operadorId, MsiSqlConnection oCnn);
}

public class EnquadramentoEmpresa : IEnquadramentoEmpresaWriter
{
    public void Delete(EnquadramentoEmpresaResponse enquadramentoempresa, int operadorId, MsiSqlConnection oCnn)
    {
        ConfiguracoesDBT.ExecuteDelete($"DELETE FROM [{oCnn.UseDbo}].[EnquadramentoEmpresa] WHERE eqeCodigo={enquadramentoempresa.Id};", oCnn);
    }

    public Entity.DBEnquadramentoEmpresa Write(Models.EnquadramentoEmpresa enquadramentoempresa, int auditorQuem, MsiSqlConnection oCnn)
    {
        var dbRec = enquadramentoempresa.Id.IsEmptyIDNumber() ? new Entity.DBEnquadramentoEmpresa() : new Entity.DBEnquadramentoEmpresa(enquadramentoempresa.Id, oCnn);
        dbRec.FNome = enquadramentoempresa.Nome;
        dbRec.FGUID = enquadramentoempresa.GUID;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}