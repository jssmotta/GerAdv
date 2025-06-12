#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Wheres;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IPenhoraWhere
{
    PenhoraResponse Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
}

public partial class Penhora : IPenhoraWhere
{
    public PenhoraResponse Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBPenhora(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        var penhora = new PenhoraResponse
        {
            Id = dbRec.ID,
            Processo = dbRec.FProcesso,
            Nome = dbRec.FNome ?? string.Empty,
            Descricao = dbRec.FDescricao ?? string.Empty,
            PenhoraStatus = dbRec.FPenhoraStatus,
            Master = dbRec.FMaster,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FDataPenhora, out _))
            penhora.DataPenhora = dbRec.FDataPenhora;
        return penhora;
    }
}