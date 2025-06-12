#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Wheres;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IFaseWhere
{
    FaseResponse Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
}

public partial class Fase : IFaseWhere
{
    public FaseResponse Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBFase(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        var fase = new FaseResponse
        {
            Id = dbRec.ID,
            Descricao = dbRec.FDescricao ?? string.Empty,
            Justica = dbRec.FJustica,
            Area = dbRec.FArea,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return fase;
    }
}