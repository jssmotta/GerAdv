namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBProObservacoes
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBProObservacoesDicInfo.Processo:
                FProcesso = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBProObservacoesDicInfo.Nome:
                FNome = $"{value}"; // rgo J3: string
                return;
            case DBProObservacoesDicInfo.Observacoes:
                FObservacoes = $"{value}"; // rgo J3: string
                return;
            case DBProObservacoesDicInfo.Data:
                FData = $"{value}"; // rgo J3: DateTime
                return;
            case DBProObservacoesDicInfo.GUID:
                FGUID = $"{value}"; // rgo J3: string
                return;
            case DBProObservacoesDicInfo.QuemCad:
                FQuemCad = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBProObservacoesDicInfo.DtCad:
                FDtCad = $"{value}"; // rgo J3: DateTime
                return;
            case DBProObservacoesDicInfo.QuemAtu:
                FQuemAtu = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBProObservacoesDicInfo.DtAtu:
                FDtAtu = $"{value}"; // rgo J3: DateTime
                return;
            case DBProObservacoesDicInfo.Visto:
                FVisto = $"{value}".Equals("True"); // rgo J3: bool
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBProObservacoesDicInfo.Processo => NFProcesso(),
        DBProObservacoesDicInfo.Nome => NFNome(),
        DBProObservacoesDicInfo.Observacoes => NFObservacoes(),
        DBProObservacoesDicInfo.Data => NFData(),
        DBProObservacoesDicInfo.GUID => NFGUID(),
        DBProObservacoesDicInfo.QuemCad => NFQuemCad(),
        DBProObservacoesDicInfo.DtCad => MDtCad,
        DBProObservacoesDicInfo.QuemAtu => NFQuemAtu(),
        DBProObservacoesDicInfo.DtAtu => MDtAtu,
        DBProObservacoesDicInfo.Visto => FVisto.ToString(),
        _ => nameof(GetValueByNameField)};
}