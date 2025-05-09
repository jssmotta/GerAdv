﻿namespace MenphisSI.GerAdv.Interface;
public partial interface IDBModelosDocumentos
{
    public int ID { get; set; }
    public string? FNome { get; set; }
    public string? FRemuneracao { get; set; }
    public string? FAssinatura { get; set; }
    public string? FHeader { get; set; }
    public string? FFooter { get; set; }
    public string? FExtra1 { get; set; }
    public string? FExtra2 { get; set; }
    public string? FExtra3 { get; set; }
    public string? FOutorgante { get; set; }
    public string? FOutorgados { get; set; }
    public string? FPoderes { get; set; }
    public string? FObjeto { get; set; }
    public string? FTitulo { get; set; }
    public string? FTestemunhas { get; set; }
    public int FTipoModeloDocumento { get; set; }
    public string? FCSS { get; set; }
    public string? FGUID { get; set; }
}