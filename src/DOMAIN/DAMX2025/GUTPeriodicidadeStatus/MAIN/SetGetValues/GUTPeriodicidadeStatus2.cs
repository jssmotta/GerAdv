namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBGUTPeriodicidadeStatus
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBGUTPeriodicidadeStatusDicInfo.GUTAtividade:
                FGUTAtividade = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBGUTPeriodicidadeStatusDicInfo.DataRealizado:
                FDataRealizado = $"{value}"; // rgo J3: DateTime
                return;
            case DBGUTPeriodicidadeStatusDicInfo.GUID:
                FGUID = $"{value}"; // rgo J3: string
                return;
            case DBGUTPeriodicidadeStatusDicInfo.QuemCad:
                FQuemCad = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBGUTPeriodicidadeStatusDicInfo.DtCad:
                FDtCad = $"{value}"; // rgo J3: DateTime
                return;
            case DBGUTPeriodicidadeStatusDicInfo.QuemAtu:
                FQuemAtu = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBGUTPeriodicidadeStatusDicInfo.DtAtu:
                FDtAtu = $"{value}"; // rgo J3: DateTime
                return;
            case DBGUTPeriodicidadeStatusDicInfo.Visto:
                FVisto = $"{value}".Equals("True"); // rgo J3: bool
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBGUTPeriodicidadeStatusDicInfo.GUTAtividade => NFGUTAtividade(),
        DBGUTPeriodicidadeStatusDicInfo.DataRealizado => NFDataRealizado(),
        DBGUTPeriodicidadeStatusDicInfo.GUID => NFGUID(),
        DBGUTPeriodicidadeStatusDicInfo.QuemCad => NFQuemCad(),
        DBGUTPeriodicidadeStatusDicInfo.DtCad => MDtCad,
        DBGUTPeriodicidadeStatusDicInfo.QuemAtu => NFQuemAtu(),
        DBGUTPeriodicidadeStatusDicInfo.DtAtu => MDtAtu,
        DBGUTPeriodicidadeStatusDicInfo.Visto => FVisto.ToString(),
        _ => nameof(GetValueByNameField)};
}