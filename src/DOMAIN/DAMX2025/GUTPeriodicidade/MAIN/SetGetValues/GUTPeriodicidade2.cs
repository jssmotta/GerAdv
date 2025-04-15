namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBGUTPeriodicidade
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBGUTPeriodicidadeDicInfo.Nome:
                FNome = $"{value}"; // rgo J3: string
                return;
            case DBGUTPeriodicidadeDicInfo.IntervaloDias:
                FIntervaloDias = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBGUTPeriodicidadeDicInfo.GUID:
                FGUID = $"{value}"; // rgo J3: string
                return;
            case DBGUTPeriodicidadeDicInfo.QuemCad:
                FQuemCad = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBGUTPeriodicidadeDicInfo.DtCad:
                FDtCad = $"{value}"; // rgo J3: DateTime
                return;
            case DBGUTPeriodicidadeDicInfo.QuemAtu:
                FQuemAtu = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBGUTPeriodicidadeDicInfo.DtAtu:
                FDtAtu = $"{value}"; // rgo J3: DateTime
                return;
            case DBGUTPeriodicidadeDicInfo.Visto:
                FVisto = $"{value}".Equals("True"); // rgo J3: bool
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBGUTPeriodicidadeDicInfo.Nome => NFNome(),
        DBGUTPeriodicidadeDicInfo.IntervaloDias => NFIntervaloDias(),
        DBGUTPeriodicidadeDicInfo.GUID => NFGUID(),
        DBGUTPeriodicidadeDicInfo.QuemCad => NFQuemCad(),
        DBGUTPeriodicidadeDicInfo.DtCad => MDtCad,
        DBGUTPeriodicidadeDicInfo.QuemAtu => NFQuemAtu(),
        DBGUTPeriodicidadeDicInfo.DtAtu => MDtAtu,
        DBGUTPeriodicidadeDicInfo.Visto => FVisto.ToString(),
        _ => nameof(GetValueByNameField)};
}