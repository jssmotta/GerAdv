#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Wheres;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IBensClassificacaoWhere
{
    BensClassificacaoResponse Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
}

public partial class BensClassificacao : IBensClassificacaoWhere
{
    public BensClassificacaoResponse Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBBensClassificacao(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        var bensclassificacao = new BensClassificacaoResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return bensclassificacao;
    }
}