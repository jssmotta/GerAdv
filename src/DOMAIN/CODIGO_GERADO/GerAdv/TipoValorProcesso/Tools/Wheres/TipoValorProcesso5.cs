#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Wheres;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ITipoValorProcessoWhere
{
    TipoValorProcessoResponse Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
}

public partial class TipoValorProcesso : ITipoValorProcessoWhere
{
    public TipoValorProcessoResponse Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBTipoValorProcesso(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        var tipovalorprocesso = new TipoValorProcessoResponse
        {
            Id = dbRec.ID,
            Descricao = dbRec.FDescricao ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return tipovalorprocesso;
    }
}