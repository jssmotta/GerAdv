namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBCargosEscClass
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBCargosEscClassDicInfo.Nome:
                FNome = $"{value}"; // rgo J3: string
                return;
            case DBCargosEscClassDicInfo.GUID:
                FGUID = $"{value}"; // rgo J3: string
                return;
            case DBCargosEscClassDicInfo.QuemCad:
                FQuemCad = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBCargosEscClassDicInfo.DtCad:
                FDtCad = $"{value}"; // rgo J3: DateTime
                return;
            case DBCargosEscClassDicInfo.QuemAtu:
                FQuemAtu = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBCargosEscClassDicInfo.DtAtu:
                FDtAtu = $"{value}"; // rgo J3: DateTime
                return;
            case DBCargosEscClassDicInfo.Visto:
                FVisto = $"{value}".Equals("True"); // rgo J3: bool
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBCargosEscClassDicInfo.Nome => NFNome(),
        DBCargosEscClassDicInfo.GUID => NFGUID(),
        DBCargosEscClassDicInfo.QuemCad => NFQuemCad(),
        DBCargosEscClassDicInfo.DtCad => MDtCad,
        DBCargosEscClassDicInfo.QuemAtu => NFQuemAtu(),
        DBCargosEscClassDicInfo.DtAtu => MDtAtu,
        DBCargosEscClassDicInfo.Visto => FVisto.ToString(),
        _ => nameof(GetValueByNameField)};
}