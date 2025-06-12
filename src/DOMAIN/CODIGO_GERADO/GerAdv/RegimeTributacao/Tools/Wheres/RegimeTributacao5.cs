#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Wheres;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IRegimeTributacaoWhere
{
    RegimeTributacaoResponse Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
}

public partial class RegimeTributacao : IRegimeTributacaoWhere
{
    public RegimeTributacaoResponse Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBRegimeTributacao(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        var regimetributacao = new RegimeTributacaoResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return regimetributacao;
    }
}