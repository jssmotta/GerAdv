﻿namespace MenphisSI.GerAdv.Interface;
public partial interface IDBAgenda
{
    public int ID { get; set; }
    public int FIDCOB { get; set; }
    public bool FClienteAvisado { get; set; }
    public bool FRevisarP2 { get; set; }
    public int FIDNE { get; set; }
    public int FCidade { get; set; }
    public int FOculto { get; set; }
    public int FCartaPrecatoria { get; set; }
    public bool FRevisar { get; set; }
    public string? FHrFinal { get; set; }
    public int FAdvogado { get; set; }
    public int FEventoGerador { get; set; }
    public string? FEventoData { get; set; }
    public int FFuncionario { get; set; }
    public string? FData { get; set; }
    public int FEventoPrazo { get; set; }
    public string? FHora { get; set; }
    public string? FCompromisso { get; set; }
    public int FTipoCompromisso { get; set; }
    public int FCliente { get; set; }
    public bool FLiberado { get; set; }
    public bool FImportante { get; set; }
    public bool FConcluido { get; set; }
    public int FArea { get; set; }
    public int FJustica { get; set; }
    public int FProcesso { get; set; }
    public int FIDHistorico { get; set; }
    public int FIDInsProcesso { get; set; }
    public int FUsuario { get; set; }
    public int FPreposto { get; set; }
    public int FQuemID { get; set; }
    public int FQuemCodigo { get; set; }
    public string? FStatus { get; set; }
    public decimal FValor { get; set; }
    public string? FDecisao { get; set; }
    public int FSempre { get; set; }
    public int FPrazoDias { get; set; }
    public int FProtocoloIntegrado { get; set; }
    public string? FDataInicioPrazo { get; set; }
    public bool FUsuarioCiente { get; set; }
}