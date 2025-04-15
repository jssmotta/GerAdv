namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBProProcuradores
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBProProcuradoresDicInfo.Advogado:
                FAdvogado = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBProProcuradoresDicInfo.Nome:
                FNome = $"{value}"; // rgo J3: string
                return;
            case DBProProcuradoresDicInfo.Processo:
                FProcesso = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBProProcuradoresDicInfo.Data:
                FData = $"{value}"; // rgo J3: DateTime
                return;
            case DBProProcuradoresDicInfo.Substabelecimento:
                FSubstabelecimento = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBProProcuradoresDicInfo.Procuracao:
                FProcuracao = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBProProcuradoresDicInfo.Bold:
                FBold = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBProProcuradoresDicInfo.GUID:
                FGUID = $"{value}"; // rgo J3: string
                return;
            case DBProProcuradoresDicInfo.QuemCad:
                FQuemCad = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBProProcuradoresDicInfo.DtCad:
                FDtCad = $"{value}"; // rgo J3: DateTime
                return;
            case DBProProcuradoresDicInfo.QuemAtu:
                FQuemAtu = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBProProcuradoresDicInfo.DtAtu:
                FDtAtu = $"{value}"; // rgo J3: DateTime
                return;
            case DBProProcuradoresDicInfo.Visto:
                FVisto = $"{value}".Equals("True"); // rgo J3: bool
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBProProcuradoresDicInfo.Advogado => NFAdvogado(),
        DBProProcuradoresDicInfo.Nome => NFNome(),
        DBProProcuradoresDicInfo.Processo => NFProcesso(),
        DBProProcuradoresDicInfo.Data => NFData(),
        DBProProcuradoresDicInfo.Substabelecimento => FSubstabelecimento.ToString(),
        DBProProcuradoresDicInfo.Procuracao => FProcuracao.ToString(),
        DBProProcuradoresDicInfo.Bold => FBold.ToString(),
        DBProProcuradoresDicInfo.GUID => NFGUID(),
        DBProProcuradoresDicInfo.QuemCad => NFQuemCad(),
        DBProProcuradoresDicInfo.DtCad => MDtCad,
        DBProProcuradoresDicInfo.QuemAtu => NFQuemAtu(),
        DBProProcuradoresDicInfo.DtAtu => MDtAtu,
        DBProProcuradoresDicInfo.Visto => FVisto.ToString(),
        _ => nameof(GetValueByNameField)};
}