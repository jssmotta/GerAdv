#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Wheres;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ITipoOrigemSucumbenciaWhere
{
    TipoOrigemSucumbenciaResponse Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
}

public partial class TipoOrigemSucumbencia : ITipoOrigemSucumbenciaWhere
{
    public TipoOrigemSucumbenciaResponse Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBTipoOrigemSucumbencia(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        var tipoorigemsucumbencia = new TipoOrigemSucumbenciaResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
        };
        return tipoorigemsucumbencia;
    }
}