#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Wheres;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IProObservacoesWhere
{
    ProObservacoesResponse Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
}

public partial class ProObservacoes : IProObservacoesWhere
{
    public ProObservacoesResponse Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBProObservacoes(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        var proobservacoes = new ProObservacoesResponse
        {
            Id = dbRec.ID,
            Processo = dbRec.FProcesso,
            Nome = dbRec.FNome ?? string.Empty,
            Observacoes = dbRec.FObservacoes ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            proobservacoes.Data = dbRec.FData;
        return proobservacoes;
    }
}