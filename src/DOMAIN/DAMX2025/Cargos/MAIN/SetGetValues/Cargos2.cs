namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBCargos
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBCargosDicInfo.Nome:
                FNome = $"{value}"; // rgo J3: string
                return;
            case DBCargosDicInfo.QuemCad:
                FQuemCad = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBCargosDicInfo.DtCad:
                FDtCad = $"{value}"; // rgo J3: DateTime
                return;
            case DBCargosDicInfo.QuemAtu:
                FQuemAtu = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBCargosDicInfo.DtAtu:
                FDtAtu = $"{value}"; // rgo J3: DateTime
                return;
            case DBCargosDicInfo.Visto:
                FVisto = $"{value}".Equals("True"); // rgo J3: bool
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBCargosDicInfo.Nome => NFNome(),
        DBCargosDicInfo.QuemCad => NFQuemCad(),
        DBCargosDicInfo.DtCad => MDtCad,
        DBCargosDicInfo.QuemAtu => NFQuemAtu(),
        DBCargosDicInfo.DtAtu => MDtAtu,
        DBCargosDicInfo.Visto => FVisto.ToString(),
        _ => nameof(GetValueByNameField)};
}