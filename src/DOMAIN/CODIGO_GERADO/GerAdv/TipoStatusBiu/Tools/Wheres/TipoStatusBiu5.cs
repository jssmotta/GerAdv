#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Wheres;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ITipoStatusBiuWhere
{
    TipoStatusBiuResponse Read(string where, SqlConnection oCnn);
}

public partial class TipoStatusBiu : ITipoStatusBiuWhere
{
    public TipoStatusBiuResponse Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBTipoStatusBiu(sqlWhere: where, oCnn: oCnn);
        var tipostatusbiu = new TipoStatusBiuResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
        };
        return tipostatusbiu;
    }
}