namespace MenphisSI.GerAdv.Interface;
public partial interface IDBEnderecoSistema
{
    public int ID { get; set; }
    public int FCadastro { get; set; }
    public int FCadastroExCod { get; set; }
    public int FTipoEnderecoSistema { get; set; }
    public int FProcesso { get; set; }
    public string? FMotivo { get; set; }
    public string? FContatoNoLocal { get; set; }
    public int FCidade { get; set; }
    public string? FEndereco { get; set; }
    public string? FBairro { get; set; }
    public string? FCEP { get; set; }
    public string? FFone { get; set; }
    public string? FFax { get; set; }
    public string? FObservacao { get; set; }
}