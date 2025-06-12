#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Wheres;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ISetorWhere
{
    SetorResponse Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
}

public partial class Setor : ISetorWhere
{
    public SetorResponse Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBSetor(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        var setor = new SetorResponse
        {
            Id = dbRec.ID,
            Descricao = dbRec.FDescricao ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return setor;
    }
}