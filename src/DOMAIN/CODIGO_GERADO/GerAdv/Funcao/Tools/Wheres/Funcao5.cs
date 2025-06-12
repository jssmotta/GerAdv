#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Wheres;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IFuncaoWhere
{
    FuncaoResponse Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
}

public partial class Funcao : IFuncaoWhere
{
    public FuncaoResponse Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBFuncao(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        var funcao = new FuncaoResponse
        {
            Id = dbRec.ID,
            Descricao = dbRec.FDescricao ?? string.Empty,
        };
        return funcao;
    }
}