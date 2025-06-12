#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Wheres;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IAtividadesWhere
{
    AtividadesResponse Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
}

public partial class Atividades : IAtividadesWhere
{
    public AtividadesResponse Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBAtividades(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        var atividades = new AtividadesResponse
        {
            Id = dbRec.ID,
            Descricao = dbRec.FDescricao ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return atividades;
    }
}