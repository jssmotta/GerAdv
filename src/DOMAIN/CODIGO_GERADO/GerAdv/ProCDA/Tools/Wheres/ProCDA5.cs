#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Wheres;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IProCDAWhere
{
    ProCDAResponse Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
}

public partial class ProCDA : IProCDAWhere
{
    public ProCDAResponse Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBProCDA(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        var procda = new ProCDAResponse
        {
            Id = dbRec.ID,
            Processo = dbRec.FProcesso,
            Nome = dbRec.FNome ?? string.Empty,
            NroInterno = dbRec.FNroInterno ?? string.Empty,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return procda;
    }
}