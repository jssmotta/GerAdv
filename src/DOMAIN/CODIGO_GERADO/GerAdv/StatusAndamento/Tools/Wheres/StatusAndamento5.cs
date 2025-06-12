#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Wheres;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IStatusAndamentoWhere
{
    StatusAndamentoResponse Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
}

public partial class StatusAndamento : IStatusAndamentoWhere
{
    public StatusAndamentoResponse Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBStatusAndamento(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        var statusandamento = new StatusAndamentoResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Icone = dbRec.FIcone,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return statusandamento;
    }
}