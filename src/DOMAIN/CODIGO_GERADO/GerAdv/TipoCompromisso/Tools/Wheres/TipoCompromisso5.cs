#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Wheres;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ITipoCompromissoWhere
{
    TipoCompromissoResponse Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
}

public partial class TipoCompromisso : ITipoCompromissoWhere
{
    public TipoCompromissoResponse Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBTipoCompromisso(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        var tipocompromisso = new TipoCompromissoResponse
        {
            Id = dbRec.ID,
            Icone = dbRec.FIcone,
            Descricao = dbRec.FDescricao ?? string.Empty,
            Financeiro = dbRec.FFinanceiro,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return tipocompromisso;
    }
}