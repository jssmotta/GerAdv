namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBHorasTrab
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBHorasTrabDicInfo.IDContatoCRM:
                FIDContatoCRM = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBHorasTrabDicInfo.Honorario:
                FHonorario = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBHorasTrabDicInfo.IDAgenda:
                FIDAgenda = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBHorasTrabDicInfo.Data:
                FData = $"{value}"; // rgo J3: DateTime
                return;
            case DBHorasTrabDicInfo.Cliente:
                FCliente = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBHorasTrabDicInfo.Status:
                FStatus = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBHorasTrabDicInfo.Processo:
                FProcesso = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBHorasTrabDicInfo.Advogado:
                FAdvogado = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBHorasTrabDicInfo.Funcionario:
                FFuncionario = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBHorasTrabDicInfo.HrIni:
                FHrIni = $"{value}"; // rgo J3: string
                return;
            case DBHorasTrabDicInfo.HrFim:
                FHrFim = $"{value}"; // rgo J3: string
                return;
            case DBHorasTrabDicInfo.Tempo:
                FTempo = Convert.ToDecimal(value); // rgo J3: decimal
                return;
            case DBHorasTrabDicInfo.Valor:
                FValor = Convert.ToDecimal(value); // rgo J3: decimal
                return;
            case DBHorasTrabDicInfo.OBS:
                FOBS = $"{value}"; // rgo J3: string
                return;
            case DBHorasTrabDicInfo.Anexo:
                FAnexo = $"{value}"; // rgo J3: string
                return;
            case DBHorasTrabDicInfo.AnexoComp:
                FAnexoComp = $"{value}"; // rgo J3: string
                return;
            case DBHorasTrabDicInfo.AnexoUNC:
                FAnexoUNC = $"{value}"; // rgo J3: string
                return;
            case DBHorasTrabDicInfo.Servico:
                FServico = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBHorasTrabDicInfo.GUID:
                FGUID = $"{value}"; // rgo J3: string
                return;
            case DBHorasTrabDicInfo.QuemCad:
                FQuemCad = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBHorasTrabDicInfo.DtCad:
                FDtCad = $"{value}"; // rgo J3: DateTime
                return;
            case DBHorasTrabDicInfo.QuemAtu:
                FQuemAtu = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBHorasTrabDicInfo.DtAtu:
                FDtAtu = $"{value}"; // rgo J3: DateTime
                return;
            case DBHorasTrabDicInfo.Visto:
                FVisto = $"{value}".Equals("True"); // rgo J3: bool
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBHorasTrabDicInfo.IDContatoCRM => NFIDContatoCRM(),
        DBHorasTrabDicInfo.Honorario => FHonorario.ToString(),
        DBHorasTrabDicInfo.IDAgenda => NFIDAgenda(),
        DBHorasTrabDicInfo.Data => NFData(),
        DBHorasTrabDicInfo.Cliente => NFCliente(),
        DBHorasTrabDicInfo.Status => NFStatus(),
        DBHorasTrabDicInfo.Processo => NFProcesso(),
        DBHorasTrabDicInfo.Advogado => NFAdvogado(),
        DBHorasTrabDicInfo.Funcionario => NFFuncionario(),
        DBHorasTrabDicInfo.HrIni => NFHrIni(),
        DBHorasTrabDicInfo.HrFim => NFHrFim(),
        DBHorasTrabDicInfo.Tempo => NFTempo(),
        DBHorasTrabDicInfo.Valor => NFValor(),
        DBHorasTrabDicInfo.OBS => NFOBS(),
        DBHorasTrabDicInfo.Anexo => NFAnexo(),
        DBHorasTrabDicInfo.AnexoComp => NFAnexoComp(),
        DBHorasTrabDicInfo.AnexoUNC => NFAnexoUNC(),
        DBHorasTrabDicInfo.Servico => NFServico(),
        DBHorasTrabDicInfo.GUID => NFGUID(),
        DBHorasTrabDicInfo.QuemCad => NFQuemCad(),
        DBHorasTrabDicInfo.DtCad => MDtCad,
        DBHorasTrabDicInfo.QuemAtu => NFQuemAtu(),
        DBHorasTrabDicInfo.DtAtu => MDtAtu,
        DBHorasTrabDicInfo.Visto => FVisto.ToString(),
        _ => nameof(GetValueByNameField)};
}