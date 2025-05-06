#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IEnquadramentoEmpresaWriter
{
    Entity.DBEnquadramentoEmpresa Write(Models.EnquadramentoEmpresa enquadramentoempresa, int auditorQuem, SqlConnection oCnn);
}

public class EnquadramentoEmpresa : IEnquadramentoEmpresaWriter
{
    public Entity.DBEnquadramentoEmpresa Write(Models.EnquadramentoEmpresa enquadramentoempresa, int auditorQuem, SqlConnection oCnn)
    {
        var dbRec = enquadramentoempresa.Id.IsEmptyIDNumber() ? new Entity.DBEnquadramentoEmpresa() : new Entity.DBEnquadramentoEmpresa(enquadramentoempresa.Id, oCnn);
        dbRec.FNome = enquadramentoempresa.Nome;
        dbRec.FGUID = enquadramentoempresa.GUID;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}