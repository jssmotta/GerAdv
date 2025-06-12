#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Wheres;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IAndamentosMDWhere
{
    AndamentosMDResponse Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
}

public partial class AndamentosMD : IAndamentosMDWhere
{
    public AndamentosMDResponse Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBAndamentosMD(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        var andamentosmd = new AndamentosMDResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Processo = dbRec.FProcesso,
            Andamento = dbRec.FAndamento,
            PathFull = dbRec.FPathFull ?? string.Empty,
            UNC = dbRec.FUNC ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return andamentosmd;
    }
}