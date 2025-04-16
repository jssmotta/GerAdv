namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBProSucumbencia
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBProSucumbenciaDicInfo.Processo:
                FProcesso = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBProSucumbenciaDicInfo.Instancia:
                FInstancia = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBProSucumbenciaDicInfo.Data:
                FData = $"{value}"; // rgo J3: DateTime
                return;
            case DBProSucumbenciaDicInfo.Nome:
                FNome = $"{value}"; // rgo J3: string
                return;
            case DBProSucumbenciaDicInfo.TipoOrigemSucumbencia:
                FTipoOrigemSucumbencia = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBProSucumbenciaDicInfo.Valor:
                FValor = Convert.ToDecimal(value); // rgo J3: decimal
                return;
            case DBProSucumbenciaDicInfo.Percentual:
                FPercentual = $"{value}"; // rgo J3: string
                return;
            case DBProSucumbenciaDicInfo.GUID:
                FGUID = $"{value}"; // rgo J3: string
                return;
            case DBProSucumbenciaDicInfo.QuemCad:
                FQuemCad = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBProSucumbenciaDicInfo.DtCad:
                FDtCad = $"{value}"; // rgo J3: DateTime
                return;
            case DBProSucumbenciaDicInfo.QuemAtu:
                FQuemAtu = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBProSucumbenciaDicInfo.DtAtu:
                FDtAtu = $"{value}"; // rgo J3: DateTime
                return;
            case DBProSucumbenciaDicInfo.Visto:
                FVisto = $"{value}".Equals("True"); // rgo J3: bool
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBProSucumbenciaDicInfo.Processo => NFProcesso(),
        DBProSucumbenciaDicInfo.Instancia => NFInstancia(),
        DBProSucumbenciaDicInfo.Data => NFData(),
        DBProSucumbenciaDicInfo.Nome => NFNome(),
        DBProSucumbenciaDicInfo.TipoOrigemSucumbencia => NFTipoOrigemSucumbencia(),
        DBProSucumbenciaDicInfo.Valor => NFValor(),
        DBProSucumbenciaDicInfo.Percentual => NFPercentual(),
        DBProSucumbenciaDicInfo.GUID => NFGUID(),
        DBProSucumbenciaDicInfo.QuemCad => NFQuemCad(),
        DBProSucumbenciaDicInfo.DtCad => MDtCad,
        DBProSucumbenciaDicInfo.QuemAtu => NFQuemAtu(),
        DBProSucumbenciaDicInfo.DtAtu => MDtAtu,
        DBProSucumbenciaDicInfo.Visto => FVisto.ToString(),
        _ => nameof(GetValueByNameField)};
}