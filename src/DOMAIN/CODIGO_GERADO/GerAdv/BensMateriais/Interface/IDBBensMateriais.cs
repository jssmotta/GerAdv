namespace MenphisSI.GerAdv.Interface;
public partial interface IDBBensMateriais
{
    public int ID { get; set; }
    public string? FNome { get; set; }
    public int FBensClassificacao { get; set; }
    public string? FDataCompra { get; set; }
    public string? FDataFimDaGarantia { get; set; }
    public string? FNFNRO { get; set; }
    public int FFornecedor { get; set; }
    public decimal FValorBem { get; set; }
    public string? FNroSerieProduto { get; set; }
    public string? FComprador { get; set; }
    public int FCidade { get; set; }
    public bool FGarantiaLoja { get; set; }
    public string? FDataTerminoDaGarantiaDaLoja { get; set; }
    public string? FObservacoes { get; set; }
    public string? FNomeVendedor { get; set; }
    public bool FBold { get; set; }
    public string? FGUID { get; set; }
}