namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBAndamentosMD
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBAndamentosMDDicInfo.Nome:
                FNome = $"{value}"; // rgo J3: string
                return;
            case DBAndamentosMDDicInfo.Processo:
                FProcesso = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBAndamentosMDDicInfo.Andamento:
                FAndamento = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBAndamentosMDDicInfo.PathFull:
                FPathFull = $"{value}"; // rgo J3: string
                return;
            case DBAndamentosMDDicInfo.UNC:
                FUNC = $"{value}"; // rgo J3: string
                return;
            case DBAndamentosMDDicInfo.GUID:
                FGUID = $"{value}"; // rgo J3: string
                return;
            case DBAndamentosMDDicInfo.QuemCad:
                FQuemCad = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBAndamentosMDDicInfo.DtCad:
                FDtCad = $"{value}"; // rgo J3: DateTime
                return;
            case DBAndamentosMDDicInfo.QuemAtu:
                FQuemAtu = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBAndamentosMDDicInfo.DtAtu:
                FDtAtu = $"{value}"; // rgo J3: DateTime
                return;
            case DBAndamentosMDDicInfo.Visto:
                FVisto = $"{value}".Equals("True"); // rgo J3: bool
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBAndamentosMDDicInfo.Nome => NFNome(),
        DBAndamentosMDDicInfo.Processo => NFProcesso(),
        DBAndamentosMDDicInfo.Andamento => NFAndamento(),
        DBAndamentosMDDicInfo.PathFull => NFPathFull(),
        DBAndamentosMDDicInfo.UNC => NFUNC(),
        DBAndamentosMDDicInfo.GUID => NFGUID(),
        DBAndamentosMDDicInfo.QuemCad => NFQuemCad(),
        DBAndamentosMDDicInfo.DtCad => MDtCad,
        DBAndamentosMDDicInfo.QuemAtu => NFQuemAtu(),
        DBAndamentosMDDicInfo.DtAtu => MDtAtu,
        DBAndamentosMDDicInfo.Visto => FVisto.ToString(),
        _ => nameof(GetValueByNameField)};
}