﻿namespace MenphisSI.GerAdv.Interface;
public partial interface IDBDadosProcuracao
{
    public int ID { get; set; }
    public int FCliente { get; set; }
    public string? FEstadoCivil { get; set; }
    public string? FNacionalidade { get; set; }
    public string? FProfissao { get; set; }
    public string? FCTPS { get; set; }
    public string? FPisPasep { get; set; }
    public string? FRemuneracao { get; set; }
    public string? FObjeto { get; set; }
    public string? FGUID { get; set; }
}