﻿namespace MenphisSI.GerAdv.Interface;
public partial interface IDBAdvogados
{
    public int ID { get; set; }
    public int FCargo { get; set; }
    public string? FEMailPro { get; set; }
    public string? FCPF { get; set; }
    public string? FNome { get; set; }
    public string? FRG { get; set; }
    public bool FCasa { get; set; }
    public string? FNomeMae { get; set; }
    public int FEscritorio { get; set; }
    public bool FEstagiario { get; set; }
    public string? FOAB { get; set; }
    public string? FNomeCompleto { get; set; }
    public string? FEndereco { get; set; }
    public int FCidade { get; set; }
    public string? FCEP { get; set; }
    public bool FSexo { get; set; }
    public string? FBairro { get; set; }
    public string? FCTPSSerie { get; set; }
    public string? FCTPS { get; set; }
    public string? FFone { get; set; }
    public string? FFax { get; set; }
    public int FComissao { get; set; }
    public string? FDtInicio { get; set; }
    public string? FDtFim { get; set; }
    public string? FDtNasc { get; set; }
    public decimal FSalario { get; set; }
    public string? FSecretaria { get; set; }
    public string? FTextoProcuracao { get; set; }
    public string? FEMail { get; set; }
    public string? FEspecializacao { get; set; }
    public string? FPasta { get; set; }
    public string? FObservacao { get; set; }
    public string? FContaBancaria { get; set; }
    public bool FParcTop { get; set; }
    public string? FClass { get; set; }
    public bool FTop { get; set; }
    public bool FEtiqueta { get; set; }
    public bool FAni { get; set; }
    public bool FBold { get; set; }
    public string? FGUID { get; set; }
}