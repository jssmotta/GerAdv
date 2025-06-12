#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Wheres;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IDocsRecebidosItensWhere
{
    DocsRecebidosItensResponse Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
}

public partial class DocsRecebidosItens : IDocsRecebidosItensWhere
{
    public DocsRecebidosItensResponse Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBDocsRecebidosItens(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        var docsrecebidositens = new DocsRecebidosItensResponse
        {
            Id = dbRec.ID,
            ContatoCRM = dbRec.FContatoCRM,
            Nome = dbRec.FNome ?? string.Empty,
            Devolvido = dbRec.FDevolvido,
            SeraDevolvido = dbRec.FSeraDevolvido,
            Observacoes = dbRec.FObservacoes ?? string.Empty,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return docsrecebidositens;
    }
}