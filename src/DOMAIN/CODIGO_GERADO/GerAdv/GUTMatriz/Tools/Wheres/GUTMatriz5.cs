#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Wheres;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IGUTMatrizWhere
{
    GUTMatrizResponse Read(string where, SqlConnection oCnn);
}

public partial class GUTMatriz : IGUTMatrizWhere
{
    public GUTMatrizResponse Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBGUTMatriz(sqlWhere: where, oCnn: oCnn);
        var gutmatriz = new GUTMatrizResponse
        {
            Id = dbRec.ID,
            Descricao = dbRec.FDescricao ?? string.Empty,
            GUTTipo = dbRec.FGUTTipo,
            Valor = dbRec.FValor,
        };
        return gutmatriz;
    }
}