namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBCargosEsc
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBCargosEscDicInfo.Percentual:
                FPercentual = Convert.ToDecimal(value); // rgo J3: decimal
                return;
            case DBCargosEscDicInfo.Nome:
                FNome = $"{value}"; // rgo J3: string
                return;
            case DBCargosEscDicInfo.Classificacao:
                FClassificacao = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBCargosEscDicInfo.GUID:
                FGUID = $"{value}"; // rgo J3: string
                return;
            case DBCargosEscDicInfo.QuemCad:
                FQuemCad = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBCargosEscDicInfo.DtCad:
                FDtCad = $"{value}"; // rgo J3: DateTime
                return;
            case DBCargosEscDicInfo.QuemAtu:
                FQuemAtu = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBCargosEscDicInfo.DtAtu:
                FDtAtu = $"{value}"; // rgo J3: DateTime
                return;
            case DBCargosEscDicInfo.Visto:
                FVisto = $"{value}".Equals("True"); // rgo J3: bool
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBCargosEscDicInfo.Percentual => NFPercentual(),
        DBCargosEscDicInfo.Nome => NFNome(),
        DBCargosEscDicInfo.Classificacao => NFClassificacao(),
        DBCargosEscDicInfo.GUID => NFGUID(),
        DBCargosEscDicInfo.QuemCad => NFQuemCad(),
        DBCargosEscDicInfo.DtCad => MDtCad,
        DBCargosEscDicInfo.QuemAtu => NFQuemAtu(),
        DBCargosEscDicInfo.DtAtu => MDtAtu,
        DBCargosEscDicInfo.Visto => FVisto.ToString(),
        _ => nameof(GetValueByNameField)};
}