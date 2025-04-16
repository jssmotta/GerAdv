namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBBensMateriais
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBBensMateriaisDicInfo.Nome:
                FNome = $"{value}"; // rgo J3: string
                return;
            case DBBensMateriaisDicInfo.BensClassificacao:
                FBensClassificacao = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBBensMateriaisDicInfo.DataCompra:
                FDataCompra = $"{value}"; // rgo J3: DateTime
                return;
            case DBBensMateriaisDicInfo.DataFimDaGarantia:
                FDataFimDaGarantia = $"{value}"; // rgo J3: DateTime
                return;
            case DBBensMateriaisDicInfo.NFNRO:
                FNFNRO = $"{value}"; // rgo J3: string
                return;
            case DBBensMateriaisDicInfo.Fornecedor:
                FFornecedor = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBBensMateriaisDicInfo.ValorBem:
                FValorBem = Convert.ToDecimal(value); // rgo J3: decimal
                return;
            case DBBensMateriaisDicInfo.NroSerieProduto:
                FNroSerieProduto = $"{value}"; // rgo J3: string
                return;
            case DBBensMateriaisDicInfo.Comprador:
                FComprador = $"{value}"; // rgo J3: string
                return;
            case DBBensMateriaisDicInfo.Cidade:
                FCidade = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBBensMateriaisDicInfo.GarantiaLoja:
                FGarantiaLoja = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBBensMateriaisDicInfo.DataTerminoDaGarantiaDaLoja:
                FDataTerminoDaGarantiaDaLoja = $"{value}"; // rgo J3: DateTime
                return;
            case DBBensMateriaisDicInfo.Observacoes:
                FObservacoes = $"{value}"; // rgo J3: string
                return;
            case DBBensMateriaisDicInfo.NomeVendedor:
                FNomeVendedor = $"{value}"; // rgo J3: string
                return;
            case DBBensMateriaisDicInfo.Bold:
                FBold = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBBensMateriaisDicInfo.GUID:
                FGUID = $"{value}"; // rgo J3: string
                return;
            case DBBensMateriaisDicInfo.QuemCad:
                FQuemCad = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBBensMateriaisDicInfo.DtCad:
                FDtCad = $"{value}"; // rgo J3: DateTime
                return;
            case DBBensMateriaisDicInfo.QuemAtu:
                FQuemAtu = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBBensMateriaisDicInfo.DtAtu:
                FDtAtu = $"{value}"; // rgo J3: DateTime
                return;
            case DBBensMateriaisDicInfo.Visto:
                FVisto = $"{value}".Equals("True"); // rgo J3: bool
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBBensMateriaisDicInfo.Nome => NFNome(),
        DBBensMateriaisDicInfo.BensClassificacao => NFBensClassificacao(),
        DBBensMateriaisDicInfo.DataCompra => NFDataCompra(),
        DBBensMateriaisDicInfo.DataFimDaGarantia => NFDataFimDaGarantia(),
        DBBensMateriaisDicInfo.NFNRO => NFNFNRO(),
        DBBensMateriaisDicInfo.Fornecedor => NFFornecedor(),
        DBBensMateriaisDicInfo.ValorBem => NFValorBem(),
        DBBensMateriaisDicInfo.NroSerieProduto => NFNroSerieProduto(),
        DBBensMateriaisDicInfo.Comprador => NFComprador(),
        DBBensMateriaisDicInfo.Cidade => NFCidade(),
        DBBensMateriaisDicInfo.GarantiaLoja => FGarantiaLoja.ToString(),
        DBBensMateriaisDicInfo.DataTerminoDaGarantiaDaLoja => NFDataTerminoDaGarantiaDaLoja(),
        DBBensMateriaisDicInfo.Observacoes => NFObservacoes(),
        DBBensMateriaisDicInfo.NomeVendedor => NFNomeVendedor(),
        DBBensMateriaisDicInfo.Bold => FBold.ToString(),
        DBBensMateriaisDicInfo.GUID => NFGUID(),
        DBBensMateriaisDicInfo.QuemCad => NFQuemCad(),
        DBBensMateriaisDicInfo.DtCad => MDtCad,
        DBBensMateriaisDicInfo.QuemAtu => NFQuemAtu(),
        DBBensMateriaisDicInfo.DtAtu => MDtAtu,
        DBBensMateriaisDicInfo.Visto => FVisto.ToString(),
        _ => nameof(GetValueByNameField)};
}