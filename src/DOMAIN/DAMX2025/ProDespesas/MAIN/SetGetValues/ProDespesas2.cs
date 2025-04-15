namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBProDespesas
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBProDespesasDicInfo.LigacaoID:
                FLigacaoID = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBProDespesasDicInfo.Cliente:
                FCliente = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBProDespesasDicInfo.Corrigido:
                FCorrigido = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBProDespesasDicInfo.Data:
                FData = $"{value}"; // rgo J3: DateTime
                return;
            case DBProDespesasDicInfo.ValorOriginal:
                FValorOriginal = Convert.ToDecimal(value); // rgo J3: decimal
                return;
            case DBProDespesasDicInfo.Processo:
                FProcesso = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBProDespesasDicInfo.Quitado:
                FQuitado = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBProDespesasDicInfo.DataCorrecao:
                FDataCorrecao = $"{value}"; // rgo J3: DateTime
                return;
            case DBProDespesasDicInfo.Valor:
                FValor = Convert.ToDecimal(value); // rgo J3: decimal
                return;
            case DBProDespesasDicInfo.Tipo:
                FTipo = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBProDespesasDicInfo.Historico:
                FHistorico = $"{value}"; // rgo J3: string
                return;
            case DBProDespesasDicInfo.LivroCaixa:
                FLivroCaixa = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBProDespesasDicInfo.GUID:
                FGUID = $"{value}"; // rgo J3: string
                return;
            case DBProDespesasDicInfo.QuemCad:
                FQuemCad = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBProDespesasDicInfo.DtCad:
                FDtCad = $"{value}"; // rgo J3: DateTime
                return;
            case DBProDespesasDicInfo.QuemAtu:
                FQuemAtu = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBProDespesasDicInfo.DtAtu:
                FDtAtu = $"{value}"; // rgo J3: DateTime
                return;
            case DBProDespesasDicInfo.Visto:
                FVisto = $"{value}".Equals("True"); // rgo J3: bool
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBProDespesasDicInfo.LigacaoID => NFLigacaoID(),
        DBProDespesasDicInfo.Cliente => NFCliente(),
        DBProDespesasDicInfo.Corrigido => FCorrigido.ToString(),
        DBProDespesasDicInfo.Data => NFData(),
        DBProDespesasDicInfo.ValorOriginal => NFValorOriginal(),
        DBProDespesasDicInfo.Processo => NFProcesso(),
        DBProDespesasDicInfo.Quitado => NFQuitado(),
        DBProDespesasDicInfo.DataCorrecao => NFDataCorrecao(),
        DBProDespesasDicInfo.Valor => NFValor(),
        DBProDespesasDicInfo.Tipo => FTipo.ToString(),
        DBProDespesasDicInfo.Historico => NFHistorico(),
        DBProDespesasDicInfo.LivroCaixa => FLivroCaixa.ToString(),
        DBProDespesasDicInfo.GUID => NFGUID(),
        DBProDespesasDicInfo.QuemCad => NFQuemCad(),
        DBProDespesasDicInfo.DtCad => MDtCad,
        DBProDespesasDicInfo.QuemAtu => NFQuemAtu(),
        DBProDespesasDicInfo.DtAtu => MDtAtu,
        DBProDespesasDicInfo.Visto => FVisto.ToString(),
        _ => nameof(GetValueByNameField)};
}