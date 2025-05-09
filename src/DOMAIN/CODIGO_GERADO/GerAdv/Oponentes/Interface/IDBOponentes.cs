﻿namespace MenphisSI.GerAdv.Interface;
public partial interface IDBOponentes
{
    public int ID { get; set; }
    public int FEMPFuncao { get; set; }
    public string? FCTPSNumero { get; set; }
    public string? FSite { get; set; }
    public string? FCTPSSerie { get; set; }
    public string? FNome { get; set; }
    public int FAdv { get; set; }
    public int FEMPCliente { get; set; }
    public int FIDRep { get; set; }
    public string? FPIS { get; set; }
    public string? FContato { get; set; }
    public string? FCNPJ { get; set; }
    public string? FRG { get; set; }
    public bool FJuridica { get; set; }
    public bool FTipo { get; set; }
    public bool FSexo { get; set; }
    public string? FCPF { get; set; }
    public string? FEndereco { get; set; }
    public string? FFone { get; set; }
    public string? FFax { get; set; }
    public int FCidade { get; set; }
    public string? FBairro { get; set; }
    public string? FCEP { get; set; }
    public string? FInscEst { get; set; }
    public string? FObservacao { get; set; }
    public string? FEMail { get; set; }
    public string? FClass { get; set; }
    public bool FTop { get; set; }
    public bool FEtiqueta { get; set; }
    public bool FBold { get; set; }
    public string? FGUID { get; set; }
}