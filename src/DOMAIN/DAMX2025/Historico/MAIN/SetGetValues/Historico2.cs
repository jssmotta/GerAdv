namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBHistorico
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBHistoricoDicInfo.ExtraID:
                FExtraID = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBHistoricoDicInfo.IDNE:
                FIDNE = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBHistoricoDicInfo.ExtraGUID:
                FExtraGUID = $"{value}"; // rgo J3: string
                return;
            case DBHistoricoDicInfo.LiminarOrigem:
                FLiminarOrigem = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBHistoricoDicInfo.NaoPublicavel:
                FNaoPublicavel = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBHistoricoDicInfo.Processo:
                FProcesso = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBHistoricoDicInfo.Precatoria:
                FPrecatoria = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBHistoricoDicInfo.Apenso:
                FApenso = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBHistoricoDicInfo.IDInstProcesso:
                FIDInstProcesso = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBHistoricoDicInfo.Fase:
                FFase = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBHistoricoDicInfo.Data:
                FData = $"{value}"; // rgo J3: DateTime
                return;
            case DBHistoricoDicInfo.Observacao:
                FObservacao = $"{value}"; // rgo J3: string
                return;
            case DBHistoricoDicInfo.Agendado:
                FAgendado = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBHistoricoDicInfo.Concluido:
                FConcluido = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBHistoricoDicInfo.MesmaAgenda:
                FMesmaAgenda = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBHistoricoDicInfo.SAD:
                FSAD = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBHistoricoDicInfo.Resumido:
                FResumido = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBHistoricoDicInfo.StatusAndamento:
                FStatusAndamento = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBHistoricoDicInfo.Top:
                FTop = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBHistoricoDicInfo.GUID:
                FGUID = $"{value}"; // rgo J3: string
                return;
            case DBHistoricoDicInfo.QuemCad:
                FQuemCad = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBHistoricoDicInfo.DtCad:
                FDtCad = $"{value}"; // rgo J3: DateTime
                return;
            case DBHistoricoDicInfo.QuemAtu:
                FQuemAtu = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBHistoricoDicInfo.DtAtu:
                FDtAtu = $"{value}"; // rgo J3: DateTime
                return;
            case DBHistoricoDicInfo.Visto:
                FVisto = $"{value}".Equals("True"); // rgo J3: bool
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBHistoricoDicInfo.ExtraID => NFExtraID(),
        DBHistoricoDicInfo.IDNE => NFIDNE(),
        DBHistoricoDicInfo.ExtraGUID => NFExtraGUID(),
        DBHistoricoDicInfo.LiminarOrigem => NFLiminarOrigem(),
        DBHistoricoDicInfo.NaoPublicavel => FNaoPublicavel.ToString(),
        DBHistoricoDicInfo.Processo => NFProcesso(),
        DBHistoricoDicInfo.Precatoria => NFPrecatoria(),
        DBHistoricoDicInfo.Apenso => NFApenso(),
        DBHistoricoDicInfo.IDInstProcesso => NFIDInstProcesso(),
        DBHistoricoDicInfo.Fase => NFFase(),
        DBHistoricoDicInfo.Data => NFData(),
        DBHistoricoDicInfo.Observacao => NFObservacao(),
        DBHistoricoDicInfo.Agendado => FAgendado.ToString(),
        DBHistoricoDicInfo.Concluido => FConcluido.ToString(),
        DBHistoricoDicInfo.MesmaAgenda => FMesmaAgenda.ToString(),
        DBHistoricoDicInfo.SAD => NFSAD(),
        DBHistoricoDicInfo.Resumido => FResumido.ToString(),
        DBHistoricoDicInfo.StatusAndamento => NFStatusAndamento(),
        DBHistoricoDicInfo.Top => FTop.ToString(),
        DBHistoricoDicInfo.GUID => NFGUID(),
        DBHistoricoDicInfo.QuemCad => NFQuemCad(),
        DBHistoricoDicInfo.DtCad => MDtCad,
        DBHistoricoDicInfo.QuemAtu => NFQuemAtu(),
        DBHistoricoDicInfo.DtAtu => MDtAtu,
        DBHistoricoDicInfo.Visto => FVisto.ToString(),
        _ => nameof(GetValueByNameField)};
}