﻿namespace MenphisSI.GerAdv.Interface;
public partial interface IDBFornecedores
{
    public int ID { get; set; }
    public int FGrupo { get; set; }
    public string? FNome { get; set; }
    public int FSubGrupo { get; set; }
    public bool FTipo { get; set; }
    public bool FSexo { get; set; }
    public string? FCNPJ { get; set; }
    public string? FInscEst { get; set; }
    public string? FCPF { get; set; }
    public string? FRG { get; set; }
    public string? FEndereco { get; set; }
    public string? FBairro { get; set; }
    public string? FCEP { get; set; }
    public int FCidade { get; set; }
    public string? FFone { get; set; }
    public string? FFax { get; set; }
    public string? FEmail { get; set; }
    public string? FSite { get; set; }
    public string? FObs { get; set; }
    public string? FProdutos { get; set; }
    public string? FContatos { get; set; }
    public bool FEtiqueta { get; set; }
    public bool FBold { get; set; }
    public string? FGUID { get; set; }
}