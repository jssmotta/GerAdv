#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Wheres;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ICidadeWhere
{
    CidadeResponse Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
}

public partial class Cidade : ICidadeWhere
{
    public CidadeResponse Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBCidade(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        var cidade = new CidadeResponse
        {
            Id = dbRec.ID,
            DDD = dbRec.FDDD ?? string.Empty,
            Top = dbRec.FTop,
            Comarca = dbRec.FComarca,
            Capital = dbRec.FCapital,
            Nome = dbRec.FNome ?? string.Empty,
            UF = dbRec.FUF,
            Sigla = dbRec.FSigla ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return cidade;
    }
}