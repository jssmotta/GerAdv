﻿#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Wheres;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IProSucumbenciaWhere
{
    ProSucumbenciaResponse Read(string where, SqlConnection oCnn);
}

public partial class ProSucumbencia : IProSucumbenciaWhere
{
    public ProSucumbenciaResponse Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBProSucumbencia(sqlWhere: where, oCnn: oCnn);
        var prosucumbencia = new ProSucumbenciaResponse
        {
            Id = dbRec.ID,
            Processo = dbRec.FProcesso,
            Instancia = dbRec.FInstancia,
            Nome = dbRec.FNome ?? string.Empty,
            TipoOrigemSucumbencia = dbRec.FTipoOrigemSucumbencia,
            Valor = dbRec.FValor,
            Percentual = dbRec.FPercentual ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            prosucumbencia.Data = dbRec.FData;
        var auditor = new Auditor
        {
            Visto = dbRec.FVisto,
            QuemCad = dbRec.FQuemCad
        };
        if (auditor.QuemAtu > 0)
            auditor.QuemAtu = dbRec.FQuemAtu;
        if (dbRec.FDtCad.NotIsEmpty())
            auditor.DtCad = Convert.ToDateTime(dbRec.FDtCad);
        if (!(dbRec.FDtAtu is { }))
            auditor.DtAtu = Convert.ToDateTime(dbRec.FDtAtu);
        prosucumbencia.Auditor = auditor;
        return prosucumbencia;
    }
}