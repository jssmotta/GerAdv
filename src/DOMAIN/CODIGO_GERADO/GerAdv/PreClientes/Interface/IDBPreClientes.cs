﻿namespace MenphisSI.GerAdv.Interface;
public partial interface IDBPreClientes
{
    public int ID { get; set; }
    public bool FInativo { get; set; }
    public string? FQuemIndicou { get; set; }
    public string? FNome { get; set; }
    public int FAdv { get; set; }
    public int FIDRep { get; set; }
    public bool FJuridica { get; set; }
    public string? FNomeFantasia { get; set; }
    public string? FClass { get; set; }
    public bool FTipo { get; set; }
    public string? FDtNasc { get; set; }
    public string? FInscEst { get; set; }
    public string? FQualificacao { get; set; }
    public bool FSexo { get; set; }
    public int FIdade { get; set; }
    public string? FCNPJ { get; set; }
    public string? FCPF { get; set; }
    public string? FRG { get; set; }
    public bool FTipoCaptacao { get; set; }
    public string? FObservacao { get; set; }
    public string? FEndereco { get; set; }
    public string? FBairro { get; set; }
    public int FCidade { get; set; }
    public string? FCEP { get; set; }
    public string? FFax { get; set; }
    public string? FFone { get; set; }
    public string? FData { get; set; }
    public string? FHomePage { get; set; }
    public string? FEMail { get; set; }
    public string? FAssistido { get; set; }
    public string? FAssRG { get; set; }
    public string? FAssCPF { get; set; }
    public string? FAssEndereco { get; set; }
    public string? FCNH { get; set; }
    public bool FEtiqueta { get; set; }
    public bool FAni { get; set; }
    public bool FBold { get; set; }
}