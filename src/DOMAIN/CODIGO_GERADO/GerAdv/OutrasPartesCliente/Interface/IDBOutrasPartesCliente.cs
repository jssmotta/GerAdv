﻿namespace MenphisSI.GerAdv.Interface;
public partial interface IDBOutrasPartesCliente
{
    public int ID { get; set; }
    public string? FNome { get; set; }
    public bool FTerceirizado { get; set; }
    public int FClientePrincipal { get; set; }
    public bool FTipo { get; set; }
    public bool FSexo { get; set; }
    public string? FDtNasc { get; set; }
    public string? FCPF { get; set; }
    public string? FRG { get; set; }
    public string? FCNPJ { get; set; }
    public string? FInscEst { get; set; }
    public string? FNomeFantasia { get; set; }
    public string? FEndereco { get; set; }
    public int FCidade { get; set; }
    public string? FCEP { get; set; }
    public string? FBairro { get; set; }
    public string? FFone { get; set; }
    public string? FFax { get; set; }
    public string? FEMail { get; set; }
    public string? FSite { get; set; }
    public string? FClass { get; set; }
    public bool FEtiqueta { get; set; }
    public bool FAni { get; set; }
    public bool FBold { get; set; }
    public string? FGUID { get; set; }
}