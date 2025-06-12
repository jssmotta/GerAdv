#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Wheres;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ITribunalWhere
{
    TribunalResponse Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
}

public partial class Tribunal : ITribunalWhere
{
    public TribunalResponse Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBTribunal(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        var tribunal = new TribunalResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Area = dbRec.FArea,
            Justica = dbRec.FJustica,
            Descricao = dbRec.FDescricao ?? string.Empty,
            Instancia = dbRec.FInstancia,
            Sigla = dbRec.FSigla ?? string.Empty,
            Web = dbRec.FWeb ?? string.Empty,
            Etiqueta = dbRec.FEtiqueta,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return tribunal;
    }
}