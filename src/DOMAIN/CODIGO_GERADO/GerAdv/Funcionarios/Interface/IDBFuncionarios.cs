﻿namespace MenphisSI.GerAdv.Interface;
public partial interface IDBFuncionarios
{
    public int ID { get; set; }
    public string? FEMailPro { get; set; }
    public int FCargo { get; set; }
    public string? FNome { get; set; }
    public int FFuncao { get; set; }
    public bool FSexo { get; set; }
    public string? FRegistro { get; set; }
    public string? FCPF { get; set; }
    public string? FRG { get; set; }
    public bool FTipo { get; set; }
    public string? FObservacao { get; set; }
    public string? FEndereco { get; set; }
    public string? FBairro { get; set; }
    public int FCidade { get; set; }
    public string? FCEP { get; set; }
    public string? FContato { get; set; }
    public string? FFax { get; set; }
    public string? FFone { get; set; }
    public string? FEMail { get; set; }
    public string? FPeriodo_Ini { get; set; }
    public string? FPeriodo_Fim { get; set; }
    public string? FCTPSNumero { get; set; }
    public string? FCTPSSerie { get; set; }
    public string? FPIS { get; set; }
    public decimal FSalario { get; set; }
    public string? FCTPSDtEmissao { get; set; }
    public string? FDtNasc { get; set; }
    public string? FData { get; set; }
    public bool FLiberaAgenda { get; set; }
    public string? FPasta { get; set; }
    public string? FClass { get; set; }
    public bool FEtiqueta { get; set; }
    public bool FAni { get; set; }
    public bool FBold { get; set; }
}