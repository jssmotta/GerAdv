#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Wheres;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IGUTPeriodicidadeWhere
{
    GUTPeriodicidadeResponse Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
}

public partial class GUTPeriodicidade : IGUTPeriodicidadeWhere
{
    public GUTPeriodicidadeResponse Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBGUTPeriodicidade(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        var gutperiodicidade = new GUTPeriodicidadeResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            IntervaloDias = dbRec.FIntervaloDias,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return gutperiodicidade;
    }
}