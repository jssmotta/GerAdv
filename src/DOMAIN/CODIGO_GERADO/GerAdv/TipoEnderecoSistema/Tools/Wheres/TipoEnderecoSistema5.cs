#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Wheres;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ITipoEnderecoSistemaWhere
{
    TipoEnderecoSistemaResponse Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
}

public partial class TipoEnderecoSistema : ITipoEnderecoSistemaWhere
{
    public TipoEnderecoSistemaResponse Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBTipoEnderecoSistema(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        var tipoenderecosistema = new TipoEnderecoSistemaResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return tipoenderecosistema;
    }
}