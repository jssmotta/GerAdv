namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBPaises
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBPaisesDicInfo.Nome:
                FNome = $"{value}"; // rgo J3: string
                return;
            case DBPaisesDicInfo.GUID:
                FGUID = $"{value}"; // rgo J3: string
                return;
            case DBPaisesDicInfo.QuemCad:
                FQuemCad = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBPaisesDicInfo.DtCad:
                FDtCad = $"{value}"; // rgo J3: DateTime
                return;
            case DBPaisesDicInfo.QuemAtu:
                FQuemAtu = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBPaisesDicInfo.DtAtu:
                FDtAtu = $"{value}"; // rgo J3: DateTime
                return;
            case DBPaisesDicInfo.Visto:
                FVisto = $"{value}".Equals("True"); // rgo J3: bool
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBPaisesDicInfo.Nome => NFNome(),
        DBPaisesDicInfo.GUID => NFGUID(),
        DBPaisesDicInfo.QuemCad => NFQuemCad(),
        DBPaisesDicInfo.DtCad => MDtCad,
        DBPaisesDicInfo.QuemAtu => NFQuemAtu(),
        DBPaisesDicInfo.DtAtu => MDtAtu,
        DBPaisesDicInfo.Visto => FVisto.ToString(),
        _ => nameof(GetValueByNameField)};
}