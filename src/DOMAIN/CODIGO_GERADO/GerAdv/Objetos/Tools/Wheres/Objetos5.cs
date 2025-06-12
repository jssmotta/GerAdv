#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Wheres;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IObjetosWhere
{
    ObjetosResponse Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
}

public partial class Objetos : IObjetosWhere
{
    public ObjetosResponse Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBObjetos(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        var objetos = new ObjetosResponse
        {
            Id = dbRec.ID,
            Justica = dbRec.FJustica,
            Area = dbRec.FArea,
            Nome = dbRec.FNome ?? string.Empty,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return objetos;
    }
}