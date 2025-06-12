#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Wheres;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IEnquadramentoEmpresaWhere
{
    EnquadramentoEmpresaResponse Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
}

public partial class EnquadramentoEmpresa : IEnquadramentoEmpresaWhere
{
    public EnquadramentoEmpresaResponse Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBEnquadramentoEmpresa(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        var enquadramentoempresa = new EnquadramentoEmpresaResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return enquadramentoempresa;
    }
}