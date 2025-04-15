namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBProDepositos
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBProDepositosDicInfo.Processo:
                FProcesso = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBProDepositosDicInfo.Fase:
                FFase = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBProDepositosDicInfo.Data:
                FData = $"{value}"; // rgo J3: DateTime
                return;
            case DBProDepositosDicInfo.Valor:
                FValor = Convert.ToDecimal(value); // rgo J3: decimal
                return;
            case DBProDepositosDicInfo.TipoProDesposito:
                FTipoProDesposito = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBProDepositosDicInfo.QuemCad:
                FQuemCad = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBProDepositosDicInfo.DtCad:
                FDtCad = $"{value}"; // rgo J3: DateTime
                return;
            case DBProDepositosDicInfo.QuemAtu:
                FQuemAtu = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBProDepositosDicInfo.DtAtu:
                FDtAtu = $"{value}"; // rgo J3: DateTime
                return;
            case DBProDepositosDicInfo.Visto:
                FVisto = $"{value}".Equals("True"); // rgo J3: bool
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBProDepositosDicInfo.Processo => NFProcesso(),
        DBProDepositosDicInfo.Fase => NFFase(),
        DBProDepositosDicInfo.Data => NFData(),
        DBProDepositosDicInfo.Valor => NFValor(),
        DBProDepositosDicInfo.TipoProDesposito => NFTipoProDesposito(),
        DBProDepositosDicInfo.QuemCad => NFQuemCad(),
        DBProDepositosDicInfo.DtCad => MDtCad,
        DBProDepositosDicInfo.QuemAtu => NFQuemAtu(),
        DBProDepositosDicInfo.DtAtu => MDtAtu,
        DBProDepositosDicInfo.Visto => FVisto.ToString(),
        _ => nameof(GetValueByNameField)};
}