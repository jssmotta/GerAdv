﻿#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IProcessosParadosReader
{
    ProcessosParadosResponse? Read(int id, SqlConnection oCnn);
    ProcessosParadosResponse? Read(string where, SqlConnection oCnn);
    ProcessosParadosResponse? Read(Entity.DBProcessosParados dbRec);
    ProcessosParadosResponse? Read(DBProcessosParados dbRec);
}

public partial class ProcessosParados : IProcessosParadosReader
{
    public ProcessosParadosResponse? Read(int id, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBProcessosParados(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ProcessosParadosResponse? Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBProcessosParados(sqlWhere: where, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ProcessosParadosResponse? Read(Entity.DBProcessosParados dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var processosparados = new ProcessosParadosResponse
        {
            Id = dbRec.ID,
            Processo = dbRec.FProcesso,
            Semana = dbRec.FSemana,
            Ano = dbRec.FAno,
            Operador = dbRec.FOperador,
        };
        if (DateTime.TryParse(dbRec.FDataHora, out _))
            processosparados.DataHora = dbRec.FDataHora;
        if (DateTime.TryParse(dbRec.FDataHistorico, out _))
            processosparados.DataHistorico = dbRec.FDataHistorico;
        if (DateTime.TryParse(dbRec.FDataNENotas, out _))
            processosparados.DataNENotas = dbRec.FDataNENotas;
        return processosparados;
    }

    public ProcessosParadosResponse? Read(DBProcessosParados dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var processosparados = new ProcessosParadosResponse
        {
            Id = dbRec.ID,
            Processo = dbRec.FProcesso,
            Semana = dbRec.FSemana,
            Ano = dbRec.FAno,
            Operador = dbRec.FOperador,
        };
        if (DateTime.TryParse(dbRec.FDataHora, out _))
            processosparados.DataHora = dbRec.FDataHora;
        if (DateTime.TryParse(dbRec.FDataHistorico, out _))
            processosparados.DataHistorico = dbRec.FDataHistorico;
        if (DateTime.TryParse(dbRec.FDataNENotas, out _))
            processosparados.DataNENotas = dbRec.FDataNENotas;
        return processosparados;
    }
}