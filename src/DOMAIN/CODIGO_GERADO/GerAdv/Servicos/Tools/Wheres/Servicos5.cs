#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Wheres;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IServicosWhere
{
    ServicosResponse Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
}

public partial class Servicos : IServicosWhere
{
    public ServicosResponse Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBServicos(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        var servicos = new ServicosResponse
        {
            Id = dbRec.ID,
            Cobrar = dbRec.FCobrar,
            Descricao = dbRec.FDescricao ?? string.Empty,
            Basico = dbRec.FBasico,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return servicos;
    }
}