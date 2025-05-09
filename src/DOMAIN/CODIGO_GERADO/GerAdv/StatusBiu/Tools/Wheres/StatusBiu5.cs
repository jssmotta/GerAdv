﻿#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Wheres;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IStatusBiuWhere
{
    StatusBiuResponse Read(string where, SqlConnection oCnn);
}

public partial class StatusBiu : IStatusBiuWhere
{
    public StatusBiuResponse Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBStatusBiu(sqlWhere: where, oCnn: oCnn);
        var statusbiu = new StatusBiuResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            TipoStatusBiu = dbRec.FTipoStatusBiu,
            Operador = dbRec.FOperador,
            Icone = dbRec.FIcone,
        };
        return statusbiu;
    }
}