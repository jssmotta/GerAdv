#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Wheres;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IPosicaoOutrasPartesWhere
{
    PosicaoOutrasPartesResponse Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
}

public partial class PosicaoOutrasPartes : IPosicaoOutrasPartesWhere
{
    public PosicaoOutrasPartesResponse Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBPosicaoOutrasPartes(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        var posicaooutraspartes = new PosicaoOutrasPartesResponse
        {
            Id = dbRec.ID,
            Descricao = dbRec.FDescricao ?? string.Empty,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return posicaooutraspartes;
    }
}