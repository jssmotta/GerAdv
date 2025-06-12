#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Wheres;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IUFWhere
{
    UFResponse Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
}

public partial class UF : IUFWhere
{
    public UFResponse Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBUF(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        var uf = new UFResponse
        {
            Id = dbRec.ID,
            DDD = dbRec.FDDD ?? string.Empty,
            IdUF = dbRec.FID ?? string.Empty,
            Pais = dbRec.FPais,
            Top = dbRec.FTop,
            Descricao = dbRec.FDescricao ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return uf;
    }
}