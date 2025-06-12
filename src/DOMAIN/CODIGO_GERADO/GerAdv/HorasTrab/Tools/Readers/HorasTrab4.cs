#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IHorasTrabReader
{
    HorasTrabResponse? Read(int id, MsiSqlConnection oCnn);
    HorasTrabResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    HorasTrabResponse? Read(Entity.DBHorasTrab dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    HorasTrabResponse? Read(DBHorasTrab dbRec);
    HorasTrabResponseAll? ReadAll(DBHorasTrab dbRec, DataRow dr);
}

public partial class HorasTrab : IHorasTrabReader
{
    public HorasTrabResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBHorasTrab(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public HorasTrabResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBHorasTrab(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public HorasTrabResponse? Read(Entity.DBHorasTrab dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var horastrab = new HorasTrabResponse
        {
            Id = dbRec.ID,
            IDContatoCRM = dbRec.FIDContatoCRM,
            Honorario = dbRec.FHonorario,
            IDAgenda = dbRec.FIDAgenda,
            Cliente = dbRec.FCliente,
            Status = dbRec.FStatus,
            Processo = dbRec.FProcesso,
            Advogado = dbRec.FAdvogado,
            Funcionario = dbRec.FFuncionario,
            HrIni = dbRec.FHrIni ?? string.Empty,
            HrFim = dbRec.FHrFim ?? string.Empty,
            Tempo = dbRec.FTempo,
            Valor = dbRec.FValor,
            OBS = dbRec.FOBS ?? string.Empty,
            Anexo = dbRec.FAnexo ?? string.Empty,
            AnexoComp = dbRec.FAnexoComp ?? string.Empty,
            AnexoUNC = dbRec.FAnexoUNC ?? string.Empty,
            Servico = dbRec.FServico,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            horastrab.Data = dbRec.FData;
        return horastrab;
    }

    public HorasTrabResponse? Read(DBHorasTrab dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var horastrab = new HorasTrabResponse
        {
            Id = dbRec.ID,
            IDContatoCRM = dbRec.FIDContatoCRM,
            Honorario = dbRec.FHonorario,
            IDAgenda = dbRec.FIDAgenda,
            Cliente = dbRec.FCliente,
            Status = dbRec.FStatus,
            Processo = dbRec.FProcesso,
            Advogado = dbRec.FAdvogado,
            Funcionario = dbRec.FFuncionario,
            HrIni = dbRec.FHrIni ?? string.Empty,
            HrFim = dbRec.FHrFim ?? string.Empty,
            Tempo = dbRec.FTempo,
            Valor = dbRec.FValor,
            OBS = dbRec.FOBS ?? string.Empty,
            Anexo = dbRec.FAnexo ?? string.Empty,
            AnexoComp = dbRec.FAnexoComp ?? string.Empty,
            AnexoUNC = dbRec.FAnexoUNC ?? string.Empty,
            Servico = dbRec.FServico,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            horastrab.Data = dbRec.FData;
        return horastrab;
    }

    public HorasTrabResponseAll? ReadAll(DBHorasTrab dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var horastrab = new HorasTrabResponseAll
        {
            Id = dbRec.ID,
            IDContatoCRM = dbRec.FIDContatoCRM,
            Honorario = dbRec.FHonorario,
            IDAgenda = dbRec.FIDAgenda,
            Cliente = dbRec.FCliente,
            Status = dbRec.FStatus,
            Processo = dbRec.FProcesso,
            Advogado = dbRec.FAdvogado,
            Funcionario = dbRec.FFuncionario,
            HrIni = dbRec.FHrIni ?? string.Empty,
            HrFim = dbRec.FHrFim ?? string.Empty,
            Tempo = dbRec.FTempo,
            Valor = dbRec.FValor,
            OBS = dbRec.FOBS ?? string.Empty,
            Anexo = dbRec.FAnexo ?? string.Empty,
            AnexoComp = dbRec.FAnexoComp ?? string.Empty,
            AnexoUNC = dbRec.FAnexoUNC ?? string.Empty,
            Servico = dbRec.FServico,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            horastrab.Data = dbRec.FData;
        horastrab.NomeClientes = dr["cliNome"]?.ToString() ?? string.Empty;
        horastrab.NroPastaProcessos = dr["proNroPasta"]?.ToString() ?? string.Empty;
        horastrab.NomeAdvogados = dr["advNome"]?.ToString() ?? string.Empty;
        horastrab.NomeFuncionarios = dr["funNome"]?.ToString() ?? string.Empty;
        horastrab.DescricaoServicos = dr["serDescricao"]?.ToString() ?? string.Empty;
        return horastrab;
    }
}