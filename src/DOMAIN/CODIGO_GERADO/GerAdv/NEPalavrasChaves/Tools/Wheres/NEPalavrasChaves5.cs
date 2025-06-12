#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Wheres;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface INEPalavrasChavesWhere
{
    NEPalavrasChavesResponse Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
}

public partial class NEPalavrasChaves : INEPalavrasChavesWhere
{
    public NEPalavrasChavesResponse Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBNEPalavrasChaves(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        var nepalavraschaves = new NEPalavrasChavesResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Bold = dbRec.FBold,
        };
        return nepalavraschaves;
    }
}