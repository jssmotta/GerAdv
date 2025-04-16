namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBPenhoraStatus
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBPenhoraStatusDicInfo.Nome:
                FNome = $"{value}"; // rgo J3: string
                return;
            case DBPenhoraStatusDicInfo.GUID:
                FGUID = $"{value}"; // rgo J3: string
                return;
            case DBPenhoraStatusDicInfo.QuemCad:
                FQuemCad = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBPenhoraStatusDicInfo.DtCad:
                FDtCad = $"{value}"; // rgo J3: DateTime
                return;
            case DBPenhoraStatusDicInfo.QuemAtu:
                FQuemAtu = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBPenhoraStatusDicInfo.DtAtu:
                FDtAtu = $"{value}"; // rgo J3: DateTime
                return;
            case DBPenhoraStatusDicInfo.Visto:
                FVisto = $"{value}".Equals("True"); // rgo J3: bool
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBPenhoraStatusDicInfo.Nome => NFNome(),
        DBPenhoraStatusDicInfo.GUID => NFGUID(),
        DBPenhoraStatusDicInfo.QuemCad => NFQuemCad(),
        DBPenhoraStatusDicInfo.DtCad => MDtCad,
        DBPenhoraStatusDicInfo.QuemAtu => NFQuemAtu(),
        DBPenhoraStatusDicInfo.DtAtu => MDtAtu,
        DBPenhoraStatusDicInfo.Visto => FVisto.ToString(),
        _ => nameof(GetValueByNameField)};
}