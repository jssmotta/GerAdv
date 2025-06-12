#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Wheres;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IAcaoWhere
{
    AcaoResponse Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
}

public partial class Acao : IAcaoWhere
{
    public AcaoResponse Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBAcao(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        var acao = new AcaoResponse
        {
            Id = dbRec.ID,
            Justica = dbRec.FJustica,
            Area = dbRec.FArea,
            Descricao = dbRec.FDescricao ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return acao;
    }
}