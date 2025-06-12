#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Wheres;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ICargosEscWhere
{
    CargosEscResponse Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
}

public partial class CargosEsc : ICargosEscWhere
{
    public CargosEscResponse Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBCargosEsc(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        var cargosesc = new CargosEscResponse
        {
            Id = dbRec.ID,
            Percentual = dbRec.FPercentual,
            Nome = dbRec.FNome ?? string.Empty,
            Classificacao = dbRec.FClassificacao,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return cargosesc;
    }
}