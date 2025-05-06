#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IHorasTrabReader
{
    HorasTrabResponse? Read(int id, SqlConnection oCnn);
    HorasTrabResponse? Read(string where, SqlConnection oCnn);
    HorasTrabResponse? Read(Entity.DBHorasTrab dbRec);
    Task<string> ReadStringAuditor(int id, string uri, SqlConnection oCnn);
    HorasTrabResponse? Read(DBHorasTrab dbRec);
}

public partial class HorasTrab : IHorasTrabReader
{
    public HorasTrabResponse? Read(int id, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBHorasTrab(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public HorasTrabResponse? Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBHorasTrab(sqlWhere: where, oCnn: oCnn);
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
        horastrab.Auditor = auditor;
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
        horastrab.Auditor = auditor;
        return horastrab;
    }
}