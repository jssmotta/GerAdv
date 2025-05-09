﻿namespace MenphisSI.GerAdv.Interface;
public partial interface IDBAgendaRelatorio
{
    public int ID { get; set; }
    public string? FData { get; set; }
    public int FProcesso { get; set; }
    public string? FParaNome { get; set; }
    public string? FParaPessoas { get; set; }
    public string? FBoxAudiencia { get; set; }
    public string? FBoxAudienciaMobile { get; set; }
    public string? FNomeAdvogado { get; set; }
    public string? FNomeForo { get; set; }
    public string? FNomeJustica { get; set; }
    public string? FNomeArea { get; set; }
}