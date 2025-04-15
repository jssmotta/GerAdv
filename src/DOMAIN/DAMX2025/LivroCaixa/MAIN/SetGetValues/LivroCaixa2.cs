namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBLivroCaixa
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBLivroCaixaDicInfo.IDDes:
                FIDDes = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBLivroCaixaDicInfo.Pessoal:
                FPessoal = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBLivroCaixaDicInfo.Ajuste:
                FAjuste = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBLivroCaixaDicInfo.IDHon:
                FIDHon = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBLivroCaixaDicInfo.IDHonParc:
                FIDHonParc = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBLivroCaixaDicInfo.IDHonSuc:
                FIDHonSuc = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBLivroCaixaDicInfo.Data:
                FData = $"{value}"; // rgo J3: DateTime
                return;
            case DBLivroCaixaDicInfo.Processo:
                FProcesso = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBLivroCaixaDicInfo.Valor:
                FValor = Convert.ToDecimal(value); // rgo J3: decimal
                return;
            case DBLivroCaixaDicInfo.Tipo:
                FTipo = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBLivroCaixaDicInfo.Historico:
                FHistorico = $"{value}"; // rgo J3: string
                return;
            case DBLivroCaixaDicInfo.Previsto:
                FPrevisto = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBLivroCaixaDicInfo.Grupo:
                FGrupo = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBLivroCaixaDicInfo.QuemCad:
                FQuemCad = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBLivroCaixaDicInfo.DtCad:
                FDtCad = $"{value}"; // rgo J3: DateTime
                return;
            case DBLivroCaixaDicInfo.QuemAtu:
                FQuemAtu = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBLivroCaixaDicInfo.DtAtu:
                FDtAtu = $"{value}"; // rgo J3: DateTime
                return;
            case DBLivroCaixaDicInfo.Visto:
                FVisto = $"{value}".Equals("True"); // rgo J3: bool
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBLivroCaixaDicInfo.IDDes => NFIDDes(),
        DBLivroCaixaDicInfo.Pessoal => NFPessoal(),
        DBLivroCaixaDicInfo.Ajuste => FAjuste.ToString(),
        DBLivroCaixaDicInfo.IDHon => NFIDHon(),
        DBLivroCaixaDicInfo.IDHonParc => NFIDHonParc(),
        DBLivroCaixaDicInfo.IDHonSuc => FIDHonSuc.ToString(),
        DBLivroCaixaDicInfo.Data => NFData(),
        DBLivroCaixaDicInfo.Processo => NFProcesso(),
        DBLivroCaixaDicInfo.Valor => NFValor(),
        DBLivroCaixaDicInfo.Tipo => FTipo.ToString(),
        DBLivroCaixaDicInfo.Historico => NFHistorico(),
        DBLivroCaixaDicInfo.Previsto => FPrevisto.ToString(),
        DBLivroCaixaDicInfo.Grupo => NFGrupo(),
        DBLivroCaixaDicInfo.QuemCad => NFQuemCad(),
        DBLivroCaixaDicInfo.DtCad => MDtCad,
        DBLivroCaixaDicInfo.QuemAtu => NFQuemAtu(),
        DBLivroCaixaDicInfo.DtAtu => MDtAtu,
        DBLivroCaixaDicInfo.Visto => FVisto.ToString(),
        _ => nameof(GetValueByNameField)};
}