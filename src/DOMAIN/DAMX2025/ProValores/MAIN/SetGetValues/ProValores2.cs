namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBProValores
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBProValoresDicInfo.Processo:
                FProcesso = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBProValoresDicInfo.TipoValorProcesso:
                FTipoValorProcesso = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBProValoresDicInfo.Indice:
                FIndice = $"{value}"; // rgo J3: string
                return;
            case DBProValoresDicInfo.Ignorar:
                FIgnorar = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBProValoresDicInfo.Data:
                FData = $"{value}"; // rgo J3: DateTime
                return;
            case DBProValoresDicInfo.ValorOriginal:
                FValorOriginal = Convert.ToDecimal(value); // rgo J3: decimal
                return;
            case DBProValoresDicInfo.PercMulta:
                FPercMulta = Convert.ToDecimal(value); // rgo J3: decimal
                return;
            case DBProValoresDicInfo.ValorMulta:
                FValorMulta = Convert.ToDecimal(value); // rgo J3: decimal
                return;
            case DBProValoresDicInfo.PercJuros:
                FPercJuros = Convert.ToDecimal(value); // rgo J3: decimal
                return;
            case DBProValoresDicInfo.ValorOriginalCorrigidoIndice:
                FValorOriginalCorrigidoIndice = Convert.ToDecimal(value); // rgo J3: decimal
                return;
            case DBProValoresDicInfo.ValorMultaCorrigido:
                FValorMultaCorrigido = Convert.ToDecimal(value); // rgo J3: decimal
                return;
            case DBProValoresDicInfo.ValorJurosCorrigido:
                FValorJurosCorrigido = Convert.ToDecimal(value); // rgo J3: decimal
                return;
            case DBProValoresDicInfo.ValorFinal:
                FValorFinal = Convert.ToDecimal(value); // rgo J3: decimal
                return;
            case DBProValoresDicInfo.DataUltimaCorrecao:
                FDataUltimaCorrecao = $"{value}"; // rgo J3: DateTime
                return;
            case DBProValoresDicInfo.GUID:
                FGUID = $"{value}"; // rgo J3: string
                return;
            case DBProValoresDicInfo.QuemCad:
                FQuemCad = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBProValoresDicInfo.DtCad:
                FDtCad = $"{value}"; // rgo J3: DateTime
                return;
            case DBProValoresDicInfo.QuemAtu:
                FQuemAtu = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBProValoresDicInfo.DtAtu:
                FDtAtu = $"{value}"; // rgo J3: DateTime
                return;
            case DBProValoresDicInfo.Visto:
                FVisto = $"{value}".Equals("True"); // rgo J3: bool
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBProValoresDicInfo.Processo => NFProcesso(),
        DBProValoresDicInfo.TipoValorProcesso => NFTipoValorProcesso(),
        DBProValoresDicInfo.Indice => NFIndice(),
        DBProValoresDicInfo.Ignorar => FIgnorar.ToString(),
        DBProValoresDicInfo.Data => NFData(),
        DBProValoresDicInfo.ValorOriginal => NFValorOriginal(),
        DBProValoresDicInfo.PercMulta => NFPercMulta(),
        DBProValoresDicInfo.ValorMulta => NFValorMulta(),
        DBProValoresDicInfo.PercJuros => NFPercJuros(),
        DBProValoresDicInfo.ValorOriginalCorrigidoIndice => NFValorOriginalCorrigidoIndice(),
        DBProValoresDicInfo.ValorMultaCorrigido => NFValorMultaCorrigido(),
        DBProValoresDicInfo.ValorJurosCorrigido => NFValorJurosCorrigido(),
        DBProValoresDicInfo.ValorFinal => NFValorFinal(),
        DBProValoresDicInfo.DataUltimaCorrecao => NFDataUltimaCorrecao(),
        DBProValoresDicInfo.GUID => NFGUID(),
        DBProValoresDicInfo.QuemCad => NFQuemCad(),
        DBProValoresDicInfo.DtCad => MDtCad,
        DBProValoresDicInfo.QuemAtu => NFQuemAtu(),
        DBProValoresDicInfo.DtAtu => MDtAtu,
        DBProValoresDicInfo.Visto => FVisto.ToString(),
        _ => nameof(GetValueByNameField)};
}