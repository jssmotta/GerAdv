﻿namespace MenphisSI.GerAdv.Interface;
public partial interface IDBClientesSocios
{
    public int ID { get; set; }
    public bool FSomenteRepresentante { get; set; }
    public int FIdade { get; set; }
    public bool FIsRepresentanteLegal { get; set; }
    public string? FQualificacao { get; set; }
    public bool FSexo { get; set; }
    public string? FDtNasc { get; set; }
    public string? FNome { get; set; }
    public string? FSite { get; set; }
    public string? FRepresentanteLegal { get; set; }
    public int FCliente { get; set; }
    public string? FEndereco { get; set; }
    public string? FBairro { get; set; }
    public string? FCEP { get; set; }
    public int FCidade { get; set; }
    public string? FRG { get; set; }
    public string? FCPF { get; set; }
    public string? FFone { get; set; }
    public string? FParticipacao { get; set; }
    public string? FCargo { get; set; }
    public string? FEMail { get; set; }
    public string? FObs { get; set; }
    public string? FCNH { get; set; }
    public string? FDataContrato { get; set; }
    public string? FCNPJ { get; set; }
    public string? FInscEst { get; set; }
    public string? FSocioEmpresaAdminNome { get; set; }
    public string? FEnderecoSocio { get; set; }
    public string? FBairroSocio { get; set; }
    public string? FCEPSocio { get; set; }
    public int FCidadeSocio { get; set; }
    public string? FRGDataExp { get; set; }
    public bool FSocioEmpresaAdminSomente { get; set; }
    public bool FTipo { get; set; }
    public string? FFax { get; set; }
    public string? FClass { get; set; }
    public bool FEtiqueta { get; set; }
    public bool FAni { get; set; }
    public bool FBold { get; set; }
    public string? FGUID { get; set; }
}