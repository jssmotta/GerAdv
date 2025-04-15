namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBCidade
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBCidadeDicInfo.DDD:
                FDDD = $"{value}"; // rgo J3: string
                return;
            case DBCidadeDicInfo.Top:
                FTop = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBCidadeDicInfo.Comarca:
                FComarca = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBCidadeDicInfo.Capital:
                FCapital = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBCidadeDicInfo.Nome:
                FNome = $"{value}"; // rgo J3: string
                return;
            case DBCidadeDicInfo.UF:
                FUF = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBCidadeDicInfo.Sigla:
                FSigla = $"{value}"; // rgo J3: string
                return;
            case DBCidadeDicInfo.GUID:
                FGUID = $"{value}"; // rgo J3: string
                return;
            case DBCidadeDicInfo.QuemCad:
                FQuemCad = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBCidadeDicInfo.DtCad:
                FDtCad = $"{value}"; // rgo J3: DateTime
                return;
            case DBCidadeDicInfo.QuemAtu:
                FQuemAtu = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBCidadeDicInfo.DtAtu:
                FDtAtu = $"{value}"; // rgo J3: DateTime
                return;
            case DBCidadeDicInfo.Visto:
                FVisto = $"{value}".Equals("True"); // rgo J3: bool
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBCidadeDicInfo.DDD => NFDDD(),
        DBCidadeDicInfo.Top => FTop.ToString(),
        DBCidadeDicInfo.Comarca => FComarca.ToString(),
        DBCidadeDicInfo.Capital => FCapital.ToString(),
        DBCidadeDicInfo.Nome => NFNome(),
        DBCidadeDicInfo.UF => NFUF(),
        DBCidadeDicInfo.Sigla => NFSigla(),
        DBCidadeDicInfo.GUID => NFGUID(),
        DBCidadeDicInfo.QuemCad => NFQuemCad(),
        DBCidadeDicInfo.DtCad => MDtCad,
        DBCidadeDicInfo.QuemAtu => NFQuemAtu(),
        DBCidadeDicInfo.DtAtu => MDtAtu,
        DBCidadeDicInfo.Visto => FVisto.ToString(),
        _ => nameof(GetValueByNameField)};
}